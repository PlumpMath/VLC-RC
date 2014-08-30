using System;

namespace VLCRemote {
	public partial class _Default : System.Web.UI.Page {
		protected void Page_Load (object sender, EventArgs e) {
			Context.Response.Cache.SetNoStore();
			Context.Response.Cache.SetNoServerCaching();
		}

		protected void PlayPause(object sender, EventArgs e) {
			VLC.Control(RcStrings.PauseToggle);
		}

		
		protected void LoadDvd(object sender, EventArgs e) {
			VLC.Control(RcStrings.Load_D_Drive);
		}
		protected void LoadFile(object sender, EventArgs e) {
			VLC.Control(RcStrings.Load_D_Drive);
		}
		protected void GoToMenu(object sender, EventArgs e) {
			VLC.Control(RcStrings.GoMenu);
		}
		protected void ChapterNext(object sender, EventArgs e) {
			VLC.Control(RcStrings.NextChapter);
		}
		protected void ChapterBack(object sender, EventArgs e) {
			VLC.Control(RcStrings.PrevChapter);
		}


		protected void NavUp (object sender, EventArgs e) {
			VLC.Control(RcStrings.NavUp);
		}
		protected void NavDown (object sender, EventArgs e) {
			VLC.Control(RcStrings.NavDown);
		}
		protected void NavLeft (object sender, EventArgs e) {
			VLC.Control(RcStrings.NavLeft);
		}
		protected void NavRight (object sender, EventArgs e) {
			VLC.Control(RcStrings.NavRight);
		}
		protected void NavActivate(object sender, EventArgs e) {
			VLC.Control(RcStrings.NavSelect);
		}
	}
}
