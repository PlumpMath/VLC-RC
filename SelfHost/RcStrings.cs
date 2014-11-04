namespace SelfHost {
	public static class RcStrings {
		public const string Load_DVD_Drive = "add dvd://";// this only works if a default drive is specified in preferences?
		public const string PauseToggle = "pause";
		public const string NavLeft = "key key-nav-left";
		public const string NavRight = "key key-nav-right";
		public const string NavUp = "key key-nav-up";
		public const string NavDown = "key key-nav-down";
		public const string NavSelect = "key key-nav-activate";

		public const string NextChapter = "chapter_n";
		public const string PrevChapter = "chapter_p";

		public const string GoMenu = "title 0";

		public const string ExitFullscreen = "key key-leave-fullscreen";
		public const string ToggleFullscreen = "key key-toggle-fullscreen";
	}
}
// hot key names listed near the bottom of https://forum.videolan.org/viewtopic.php?f=14&t=53013&p=237594
/*
have a look in libvlc-module.c, there are the valid hotkey strings like key-pause:
const struct action libvlc_actions[] =
{
{ "key-quit", ACTIONID_QUIT, },
{ "key-play-pause", ACTIONID_PLAY_PAUSE, },
{ "key-play", ACTIONID_PLAY, },
{ "key-pause", ACTIONID_PAUSE, },
{ "key-stop", ACTIONID_STOP, },
{ "key-position", ACTIONID_POSITION, },
{ "key-jump-extrashort", ACTIONID_JUMP_BACKWARD_EXTRASHORT, },
{ "key-jump+extrashort", ACTIONID_JUMP_FORWARD_EXTRASHORT, },
{ "key-jump-short", ACTIONID_JUMP_BACKWARD_SHORT, },
{ "key-jump+short", ACTIONID_JUMP_FORWARD_SHORT, },
{ "key-jump-medium", ACTIONID_JUMP_BACKWARD_MEDIUM, },
{ "key-jump+medium", ACTIONID_JUMP_FORWARD_MEDIUM, },
{ "key-jump-long", ACTIONID_JUMP_BACKWARD_LONG, },
{ "key-jump+long", ACTIONID_JUMP_FORWARD_LONG, },
{ "key-frame-next", ACTIONID_FRAME_NEXT, },
{ "key-prev", ACTIONID_PREV, },
{ "key-next", ACTIONID_NEXT, },
{ "key-faster", ACTIONID_FASTER, },
{ "key-slower", ACTIONID_SLOWER, },
{ "key-rate-normal", ACTIONID_RATE_NORMAL, },
{ "key-rate-faster-fine", ACTIONID_RATE_FASTER_FINE, },
{ "key-rate-slower-fine", ACTIONID_RATE_SLOWER_FINE, },
{ "key-toggle-fullscreen", ACTIONID_TOGGLE_FULLSCREEN, },
{ "key-leave-fullscreen", ACTIONID_LEAVE_FULLSCREEN, },
{ "key-vol-up", ACTIONID_VOL_UP, },
{ "key-vol-down", ACTIONID_VOL_DOWN, },
{ "key-vol-mute", ACTIONID_VOL_MUTE, },
{ "key-subdelay-down", ACTIONID_SUBDELAY_DOWN, },
{ "key-subdelay-up", ACTIONID_SUBDELAY_UP, },
{ "key-audiodelay-down", ACTIONID_AUDIODELAY_DOWN, },
{ "key-audiodelay-up", ACTIONID_AUDIODELAY_UP, },
{ "key-audio-track", ACTIONID_AUDIO_TRACK, },
{ "key-subtitle-track", ACTIONID_SUBTITLE_TRACK, },
{ "key-aspect-ratio", ACTIONID_ASPECT_RATIO, },
{ "key-crop", ACTIONID_CROP, },
{ "key-deinterlace", ACTIONID_DEINTERLACE, },
{ "key-intf-show", ACTIONID_INTF_SHOW, },
{ "key-intf-hide", ACTIONID_INTF_HIDE, },
{ "key-snapshot", ACTIONID_SNAPSHOT, },
{ "key-zoom", ACTIONID_ZOOM, },
{ "key-unzoom", ACTIONID_UNZOOM, },
{ "key-crop-top", ACTIONID_CROP_TOP, },
{ "key-uncrop-top", ACTIONID_UNCROP_TOP, },
{ "key-crop-left", ACTIONID_CROP_LEFT, },
{ "key-uncrop-left", ACTIONID_UNCROP_LEFT, },
{ "key-crop-bottom", ACTIONID_CROP_BOTTOM, },
{ "key-uncrop-bottom", ACTIONID_UNCROP_BOTTOM, },
{ "key-crop-right", ACTIONID_CROP_RIGHT, },
{ "key-uncrop-right", ACTIONID_UNCROP_RIGHT, },
{ "key-nav-activate", ACTIONID_NAV_ACTIVATE, },
{ "key-nav-up", ACTIONID_NAV_UP, },
{ "key-nav-down", ACTIONID_NAV_DOWN, },
{ "key-nav-left", ACTIONID_NAV_LEFT, },
{ "key-nav-right", ACTIONID_NAV_RIGHT, },
{ "key-disc-menu", ACTIONID_DISC_MENU, },
{ "key-title-prev", ACTIONID_TITLE_PREV, },
{ "key-title-next", ACTIONID_TITLE_NEXT, },
{ "key-chapter-prev", ACTIONID_CHAPTER_PREV, },
{ "key-chapter-next", ACTIONID_CHAPTER_NEXT, },
{ "key-zoom-quarter", ACTIONID_ZOOM_QUARTER, },
{ "key-zoom-half", ACTIONID_ZOOM_HALF, },
{ "key-zoom-original", ACTIONID_ZOOM_ORIGINAL, },
{ "key-zoom-double", ACTIONID_ZOOM_DOUBLE, },
{ "key-set-bookmark1", ACTIONID_SET_BOOKMARK1, },
{ "key-set-bookmark2", ACTIONID_SET_BOOKMARK2, },
{ "key-set-bookmark3", ACTIONID_SET_BOOKMARK3, },
{ "key-set-bookmark4", ACTIONID_SET_BOOKMARK4, },
{ "key-set-bookmark5", ACTIONID_SET_BOOKMARK5, },
{ "key-set-bookmark6", ACTIONID_SET_BOOKMARK6, },
{ "key-set-bookmark7", ACTIONID_SET_BOOKMARK7, },
{ "key-set-bookmark8", ACTIONID_SET_BOOKMARK8, },
{ "key-set-bookmark9", ACTIONID_SET_BOOKMARK9, },
{ "key-set-bookmark10", ACTIONID_SET_BOOKMARK10, },
{ "key-play-bookmark1", ACTIONID_PLAY_BOOKMARK1, },
{ "key-play-bookmark2", ACTIONID_PLAY_BOOKMARK2, },
{ "key-play-bookmark3", ACTIONID_PLAY_BOOKMARK3, },
{ "key-play-bookmark4", ACTIONID_PLAY_BOOKMARK4, },
{ "key-play-bookmark5", ACTIONID_PLAY_BOOKMARK5, },
{ "key-play-bookmark6", ACTIONID_PLAY_BOOKMARK6, },
{ "key-play-bookmark7", ACTIONID_PLAY_BOOKMARK7, },
{ "key-play-bookmark8", ACTIONID_PLAY_BOOKMARK8, },
{ "key-play-bookmark9", ACTIONID_PLAY_BOOKMARK9, },
{ "key-play-bookmark10", ACTIONID_PLAY_BOOKMARK10, },
{ "key-history-back", ACTIONID_HISTORY_BACK, },
{ "key-history-forward", ACTIONID_HISTORY_FORWARD, },
{ "key-record", ACTIONID_RECORD, },
{ "key-dump", ACTIONID_DUMP, },
{ "key-random", ACTIONID_RANDOM, },
{ "key-loop", ACTIONID_LOOP, },
{ "key-wallpaper", ACTIONID_WALLPAPER, },
{ "key-menu-on", ACTIONID_MENU_ON, },
{ "key-menu-off", ACTIONID_MENU_OFF, },
{ "key-menu-right", ACTIONID_MENU_RIGHT, },
{ "key-menu-left", ACTIONID_MENU_LEFT, },
{ "key-menu-up", ACTIONID_MENU_UP, },
{ "key-menu-down", ACTIONID_MENU_DOWN, },
{ "key-menu-select", ACTIONID_MENU_SELECT, },
{ "key-audiodevice-cycle", ACTIONID_AUDIODEVICE_CYCLE, },
{ "key-toggle-autoscale", ACTIONID_TOGGLE_AUTOSCALE, },
{ "key-incr-scalefactor", ACTIONID_SCALE_UP, },
{ "key-decr-scalefactor", ACTIONID_SCALE_DOWN, },
};
*/