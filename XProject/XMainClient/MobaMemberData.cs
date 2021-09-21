using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000954 RID: 2388
	internal class MobaMemberData
	{
		// Token: 0x06008FE8 RID: 36840 RVA: 0x00144FD8 File Offset: 0x001431D8
		public MobaMemberData(ulong roleID, uint teamid)
		{
			this.uid = roleID;
			this.teamID = teamid;
			this.isMy = (XSingleton<XAttributeMgr>.singleton.XPlayerData != null && XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == roleID);
		}

		// Token: 0x04002F79 RID: 12153
		public bool isMy = false;

		// Token: 0x04002F7A RID: 12154
		public ulong uid;

		// Token: 0x04002F7B RID: 12155
		public string name = "";

		// Token: 0x04002F7C RID: 12156
		public uint heroID;

		// Token: 0x04002F7D RID: 12157
		public uint attackLevel;

		// Token: 0x04002F7E RID: 12158
		public uint defenseLevel;

		// Token: 0x04002F7F RID: 12159
		public uint kill;

		// Token: 0x04002F80 RID: 12160
		public uint dead;

		// Token: 0x04002F81 RID: 12161
		public uint assist;

		// Token: 0x04002F82 RID: 12162
		public int exp;

		// Token: 0x04002F83 RID: 12163
		public uint level;

		// Token: 0x04002F84 RID: 12164
		public int levelUpExp;

		// Token: 0x04002F85 RID: 12165
		public uint additionPoint;

		// Token: 0x04002F86 RID: 12166
		public uint teamID;

		// Token: 0x04002F87 RID: 12167
		public float reviveTime;
	}
}
