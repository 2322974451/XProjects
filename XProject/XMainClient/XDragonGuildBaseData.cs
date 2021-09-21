using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000905 RID: 2309
	internal class XDragonGuildBaseData : XDataBase
	{
		// Token: 0x06008B9A RID: 35738 RVA: 0x0012B735 File Offset: 0x00129935
		public XDragonGuildBaseData()
		{
			this.dragonGuildName = "";
			this.leaderName = "";
		}

		// Token: 0x06008B9B RID: 35739 RVA: 0x0012B758 File Offset: 0x00129958
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

		// Token: 0x04002CAD RID: 11437
		public ulong uid;

		// Token: 0x04002CAE RID: 11438
		public string dragonGuildName;

		// Token: 0x04002CAF RID: 11439
		public ulong leaderuid;

		// Token: 0x04002CB0 RID: 11440
		public string leaderName;

		// Token: 0x04002CB1 RID: 11441
		public uint level;

		// Token: 0x04002CB2 RID: 11442
		public uint memberCount;

		// Token: 0x04002CB3 RID: 11443
		public uint maxMemberCount;

		// Token: 0x04002CB4 RID: 11444
		public ulong totalPPT;

		// Token: 0x04002CB5 RID: 11445
		public uint curexp;

		// Token: 0x04002CB6 RID: 11446
		public string sceneName;

		// Token: 0x04002CB7 RID: 11447
		public uint sceneCnt;
	}
}
