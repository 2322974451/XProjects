using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XGuildRedPacketDetail
	{

		public XGuildRedPacketBrief brif = new XGuildRedPacketBrief();

		public int itemTotalCount;

		public uint getTotalCount;

		public int getCount;

		public string content;

		public ulong leaderID;

		public ulong luckestID;

		public bool canThank;

		public List<ILogData> logList = new List<ILogData>();
	}
}
