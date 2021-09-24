using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MobaMemberData
	{

		public MobaMemberData(ulong roleID, uint teamid)
		{
			this.uid = roleID;
			this.teamID = teamid;
			this.isMy = (XSingleton<XAttributeMgr>.singleton.XPlayerData != null && XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == roleID);
		}

		public bool isMy = false;

		public ulong uid;

		public string name = "";

		public uint heroID;

		public uint attackLevel;

		public uint defenseLevel;

		public uint kill;

		public uint dead;

		public uint assist;

		public int exp;

		public uint level;

		public int levelUpExp;

		public uint additionPoint;

		public uint teamID;

		public float reviveTime;
	}
}
