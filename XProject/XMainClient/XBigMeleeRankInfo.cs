using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D5F RID: 3423
	public class XBigMeleeRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC6E RID: 48238 RVA: 0x0026DA14 File Offset: 0x0026BC14
		public void ProcessData(MayhemRankInfo info)
		{
			this.id = info.roleid;
			this.value = (ulong)info.point;
			this.name = info.name;
			this.serverName = info.svrname;
			this.profession = info.pro;
			this.kill = info.killcount;
		}

		// Token: 0x0600BC6F RID: 48239 RVA: 0x0026DA6C File Offset: 0x0026BC6C
		public void InitMyData()
		{
			this.id = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			this.value = 0UL;
			this.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
			this.serverName = XSingleton<XClientNetwork>.singleton.Server;
			this.profession = (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
			this.kill = 0U;
		}

		// Token: 0x04004C6F RID: 19567
		public string serverName;

		// Token: 0x04004C70 RID: 19568
		public uint profession;

		// Token: 0x04004C71 RID: 19569
		public uint kill;
	}
}
