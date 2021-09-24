using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class CBrifGroupInfo : LoopItemData
	{

		public ulong id;

		public uint createtype;

		public string name;

		public DateTime msgtime = DateTime.Today;

		public bool captain;

		public uint memberCnt;

		public string rolename;

		public ulong leaderid;

		public string chat;

		public uint createTime;
	}
}
