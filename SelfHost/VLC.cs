using System;
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

			SendMessage("f on"); // start in fullscreen
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

		[DllImport("winmm.dll")]
		static extern Int32 mciSendString (String command, StringBuilder buffer, Int32 bufferSize, IntPtr hwndCallback);

		public static string Eject () {
			mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
			return null;
		}
	}

	public enum DisplayMode {
		Internal,
		External,
		Extend,
		Duplicate
	}
}