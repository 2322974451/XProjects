using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200099C RID: 2460
	public class MailItem
	{
		// Token: 0x040031D2 RID: 12754
		public ulong id;

		// Token: 0x040031D3 RID: 12755
		public bool isRead;

		// Token: 0x040031D4 RID: 12756
		public MailState state;

		// Token: 0x040031D5 RID: 12757
		public MailType type;

		// Token: 0x040031D6 RID: 12758
		public bool isTemp;

		// Token: 0x040031D7 RID: 12759
		public string title;

		// Token: 0x040031D8 RID: 12760
		public DateTime date;

		// Token: 0x040031D9 RID: 12761
		public string content;

		// Token: 0x040031DA RID: 12762
		public List<ItemBrief> items;

		// Token: 0x040031DB RID: 12763
		public List<Item> xitems;

		// Token: 0x040031DC RID: 12764
		public int valit;
	}
}
