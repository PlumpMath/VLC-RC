﻿using System;
			using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SelfHost {
	public static class VLC {
		public static string Control (string commandString) {
			CheckVLC();
			SendMessage(commandString);
			return null; // cheap trick for switch statements
		}

		static void SendMessage (string commandString) {
			using (var client = new TcpClient()) {
				client.Connect(new IPEndPoint(IPAddress.Loopback, 8765));
				var data = Encoding.ASCII.GetBytes(commandString + "\r\n");

				using (var stream = client.GetStream()) {
					stream.Write(data, 0, data.Length);
					stream.Flush();
				}
				
				client.Close();
			}
		}

		static void CheckVLC () {
			var procList = Process.GetProcessesByName("vlc");
			if (procList.Length > 0) return;

			var proc = Process.Start(new ProcessStartInfo {
				UseShellExecute = false,
				FileName = @"C:\Program Files\VideoLAN\VLC\vlc.exe",
				WindowStyle = ProcessWindowStyle.Normal,
				Arguments = ""
			});
			proc.WaitForInputIdle();

			//SendMessage("f on"); // start in fullscreen -- triggers an error in vlc 2.1.5
			// work around -- will go into fullscreen once video starts
			SendMessage(RcStrings.ExitFullscreen);
			Thread.Sleep(100);
			SendMessage(RcStrings.ToggleFullscreen);
		}

		public static string SetDisplayMode (DisplayMode mode) {
			var proc = new Process {StartInfo = {FileName = "DisplaySwitch.exe"}};
			switch (mode) {
				case DisplayMode.External:
					proc.StartInfo.Arguments = "/external";
					break;
				case DisplayMode.Internal:
					proc.StartInfo.Arguments = "/internal";
					break;
				case DisplayMode.Extend:
					proc.StartInfo.Arguments = "/extend";
					break;
				case DisplayMode.Duplicate:
					proc.StartInfo.Arguments = "/clone";
					break;
			}
			proc.Start();
			return null;
		}

		public static void KillAll() {
			var all = Process.GetProcessesByName("vlc");
			foreach (var process in all) {
				process.CloseMainWindow();
				if (!process.WaitForExit(500)) process.Kill();
			}
			Thread.Sleep(500);
		}
	}

	public enum DisplayMode {
		Internal,
		External,
		Extend,
		Duplicate
	}
}