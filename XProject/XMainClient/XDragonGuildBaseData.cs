using System;
using KKSG;

namespace XMainClient
{

	internal class XDragonGuildBaseData : XDataBase
	{

		public XDragonGuildBaseData()
		{
			this.dragonGuildName = "";
			this.leaderName = "";
		}

		public virtual void Init(DragonGuildInfo info)
		{
			this.uid = info.id;
			this.dragonGuildName = info.name;
			this.leaderuid = info.leaderId;
			this.leaderName = info.leadername;
			this.level = info.level;
			this.memberCount = info.membercounts;
			this.maxMemberCount = info.capacity;
			this.totalPPT = info.totalPPT;
		}

		public ulong uid;

		public string dragonGuildName;

		public ulong leaderuid;

		public string leaderName;

		public uint level;

		public uint memberCount;

		public uint maxMemberCount;

		public ulong totalPPT;

		public uint curexp;

		public string sceneName;

		public uint sceneCnt;
	}
}
