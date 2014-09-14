using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

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
				var data = System.Text.Encoding.ASCII.GetBytes(commandString + "\r\n");

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

		public static void SetDisplayMode (DisplayMode mode) {
			var proc = new Process();
			proc.StartInfo.FileName = "DisplaySwitch.exe";
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
		}

	}

	public enum DisplayMode {
		Internal,
		External,
		Extend,
		Duplicate
	}
}