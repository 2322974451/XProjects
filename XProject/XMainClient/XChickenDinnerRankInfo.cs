using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	public class XChickenDinnerRankInfo : XBaseRankInfo
	{

		public void ProcessData(MayhemRankInfo info)
		{
			this.id = info.roleid;
			this.value = (ulong)info.point;
			this.name = info.name;
		}

		public void InitMyData()
		{
			this.id = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			this.value = 0UL;
			this.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
		}
	}
}
