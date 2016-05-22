using System.Drawing;

namespace AradChat.Arad.ChatWindow {
	static class FontColor {
		public static class Grade {
			public static Color epic = Color.FromArgb( 255, 180, 0 );
			public static Color legendary = Color.FromArgb( 255, 120, 0 );
			public static Color unique = Color.FromArgb( 255, 0, 255 );
			public static Color chronicle = Color.FromArgb( 255, 102, 102 );
			public static Color rare = Color.FromArgb( 179, 107, 255 );
			public static Color uncommon = Color.FromArgb( 104, 213, 237 );
			public static Color common = Color.FromArgb( 255, 255, 255 );

		}
		public static class Text {

			public static Color megaphone = Color.FromArgb( 255, 240, 0 );
			public static Color tab = Color.FromArgb( 255, 255, 184 );
			public static Color general = Color.FromArgb( 255, 255, 255 );
			public static Color guild = Color.FromArgb( 255, 76, 245 );

		}

		public static class Channel {

			public static Color text = Color.FromArgb( 255, 255, 255 );
			public static Color min = Color.FromArgb( 120, 0, 0 );
			public static Color max = Color.FromArgb( 180, 60, 60 );

		}
	}
}
