using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SelfHost {
	class Program {
		static void Main (string[] args) {
			const string listen = "http://localhost:8080/";
			using (new WebServer(SendResponse, listen)) {
				Console.WriteLine("listening on " + listen + " to display git directories");
				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
			}
		}
		public static string SendResponse (HttpListenerRequest request, HttpListenerResponse rawResponse) {
			var repoPath = request.Url.AbsolutePath;
			var settings = request.QueryString;
			if (repoPath == "/favicon.ico") {
				WriteIcon(rawResponse);
				return null;
			}
			if (repoPath == "/control") {
				switch (settings["do"]) { // actions

				}
				return "OK";
			}

			// Otherwise, show the controller HTML
			rawResponse.AddHeader("Content-Type", "text/html");
			using (var fs = File.OpenRead("index.html")) {
				fs.CopyTo(rawResponse.OutputStream);
			}
			return null;
		}
		static void WriteIcon (HttpListenerResponse rawResponse) {
			if (!File.Exists("favicon.ico")) {
				rawResponse.StatusCode = 404;
				return;
			}
			rawResponse.AddHeader("Content-Type", "image/png");
			rawResponse.AddHeader("Cache-Control", "max-age=604800, public"); // check once a week
			using (var fs = File.OpenRead("favicon.ico")) {
				fs.CopyTo(rawResponse.OutputStream);
			}
		}
	}
}
