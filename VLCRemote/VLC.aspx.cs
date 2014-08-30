using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace VLCRemote {
	public static class VLC {
		public static void Control (string commandString) {
			CheckVLC();
			SendMessage(commandString);
		}

		static void SendMessage(string commandString) {
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

		static void CheckVLC() {
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
	}
}