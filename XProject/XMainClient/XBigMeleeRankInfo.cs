using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	public class XBigMeleeRankInfo : XBaseRankInfo
	{

		public void ProcessData(MayhemRankInfo info)
		{
			this.id = info.roleid;
			this.value = (ulong)info.point;
			this.name = info.name;
			this.serverName = info.svrname;
			this.profession = info.pro;
			this.kill = info.killcount;
		}

		public void InitMyData()
		{
			this.id = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			this.value = 0UL;
			this.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
			this.serverName = XSingleton<XClientNetwork>.singleton.Server;
			this.profession = (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
			this.kill = 0U;
		}

		public string serverName;

		public uint profession;

		public uint kill;
	}
}
