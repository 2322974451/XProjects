using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D63 RID: 3427
	public class XChickenDinnerRankInfo : XBaseRankInfo
	{
		// Token: 0x0600BC77 RID: 48247 RVA: 0x0026DBAF File Offset: 0x0026BDAF
		public void ProcessData(MayhemRankInfo info)
		{
			this.id = info.roleid;
			this.value = (ulong)info.point;
			this.name = info.name;
		}

		// Token: 0x0600BC78 RID: 48248 RVA: 0x0026DBD7 File Offset: 0x0026BDD7
		public void InitMyData()
		{
			this.id = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			this.value = 0UL;
			this.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
		}
	}
}
