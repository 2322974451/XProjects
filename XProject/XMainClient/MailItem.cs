using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class MailItem
	{

		public ulong id;

		public bool isRead;

		public MailState state;

		public MailType type;

		public bool isTemp;

		public string title;

		public DateTime date;

		public string content;

		public List<ItemBrief> items;

		public List<Item> xitems;

		public int valit;
	}
}
