using System.Windows.Forms;

namespace SelfHost {
	public static class PcSleep {
		public static string Sleep () {
			Application.SetSuspendState(PowerState.Suspend, false, false);
			return null;
		}
	}
}
