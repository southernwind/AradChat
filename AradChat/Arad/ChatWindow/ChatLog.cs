using System.Collections.Generic;

namespace AradChat.Arad.ChatWindow {
	internal class ChatLog {

		internal string name = "";
		internal string detail = "";
		internal string[] itemType;
		internal List<string> raw;
		internal ChatLog() {
			this.raw = new List<string>();
		}

	}
}
