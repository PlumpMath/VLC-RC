using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading;

namespace SelfHost {
	class Program {
		static void Main () {
			for (; ; ) {
				try {
					var listen = new[] { "http://iain-pc:80/", "http://localhost:80/" };
					using (new WebServer(SendResponse, listen)) {
						Console.WriteLine("listening on " + string.Join(", ", listen));
						for (; ; ) {
							Thread.Sleep(250);
						}
					}
				} catch (Exception ex) {
					Console.WriteLine("Web host failed: " + ex.Message);
					Thread.Sleep(1000);
					Console.WriteLine("Restarting");
				}
			}
		}
		public static string SendResponse (HttpListenerRequest request, HttpListenerResponse rawResponse) {
			Console.WriteLine(request.Url.PathAndQuery);
			var url = request.Url.AbsolutePath;
			var settings = request.QueryString;
			if (url == "/favicon.ico") {
				return WriteIcon(rawResponse);
			}
			if (url == "/control") {
				rawResponse.AddHeader("Cache-Control", "no-cache");
				return Actions(settings);
			}
			if (url == "/files") {
				rawResponse.AddHeader("Content-Type", "text/html");
				return "FILES";
			}

			// Otherwise, show the controller HTML
			rawResponse.AddHeader("Content-Type", "text/html");
			using (var fs = File.OpenRead("index.html")) {
				fs.CopyTo(rawResponse.OutputStream);
			}
			return null;
		}

		static string Actions(NameValueCollection settings) {
			switch (settings["do"]) {
				case "playpause": return VLC.Control(RcStrings.PauseToggle);
				case "d-drive": {
					VLC.KillAll(); // reset vlc to ensure good starting params
					return VLC.Control(RcStrings.Load_DVD_Drive);
				}
				case "eject-d": {
					VLC.KillAll(); // reset vlc to ensure good starting params
					Thread.Sleep(1000); // VLC 2 seems to hang on to it for a while
					CdBayControl.EjectMedia('D');
					return null;
					}
				case "go-menu":return VLC.Control(RcStrings.GoMenu);
				case "ch-next":return VLC.Control(RcStrings.NextChapter);
				case "ch-prev":return VLC.Control(RcStrings.PrevChapter);
				case "up": return VLC.Control(RcStrings.NavUp);
				case "down": return VLC.Control(RcStrings.NavDown);
				case "left": return VLC.Control(RcStrings.NavLeft);
				case "right": return VLC.Control(RcStrings.NavRight);
				case "select": return VLC.Control(RcStrings.NavSelect);
				case "disp-external": return VLC.SetDisplayMode(DisplayMode.External);
				case "disp-internal": return VLC.SetDisplayMode(DisplayMode.Internal);
				case "sleep-system": return PcSleep.Sleep();
				default: return "UNKNOWN";
			}
		}

		static string WriteIcon (HttpListenerResponse rawResponse) {
			if (!File.Exists("favicon.ico")) {
				rawResponse.StatusCode = 404;
				return null;
			}
			rawResponse.AddHeader("Content-Type", "image/png");
			rawResponse.AddHeader("Cache-Control", "max-age=604800, public"); // check once a week
			using (var fs = File.OpenRead("favicon.ico")) {
				fs.CopyTo(rawResponse.OutputStream);
			}
			return null;
		}
	}
}
