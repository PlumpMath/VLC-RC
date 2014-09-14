using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace SelfHost {
	class Program {
		static void Main (string[] args) {
			var listen = new[]{"http://iain-pc:80/", "http://localhost:80/"};
			using (new WebServer(SendResponse, listen)) {
				Console.WriteLine("listening on " + listen);
				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
			}
		}
		public static string SendResponse (HttpListenerRequest request, HttpListenerResponse rawResponse) {
			var repoPath = request.Url.AbsolutePath;
			var settings = request.QueryString;
			if (repoPath == "/favicon.ico") {
				return WriteIcon(rawResponse);
			}
			if (repoPath == "/control") {
				rawResponse.AddHeader("Cache-Control", "no-cache");
				return Actions(settings);
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
				case "d-drive": return VLC.Control(RcStrings.Load_D_Drive);
				case "load-file": return "not-implemented";
				case "go-menu":return VLC.Control(RcStrings.GoMenu);
				case "ch-next":return VLC.Control(RcStrings.NextChapter);
				case "ch-prev":return VLC.Control(RcStrings.PrevChapter);
				case "up": return VLC.Control(RcStrings.NavUp);
				case "down": return VLC.Control(RcStrings.NavDown);
				case "left": return VLC.Control(RcStrings.NavLeft);
				case "right": return VLC.Control(RcStrings.NavRight);
				case "select": return VLC.Control(RcStrings.NavSelect);
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
