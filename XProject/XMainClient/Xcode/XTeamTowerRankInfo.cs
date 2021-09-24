using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	public class XTeamTowerRankInfo : XBaseRankInfo
	{

		public override void ProcessData(RankData data)
		{
			this.memberCount = (uint)data.RoleIds.Count;
			bool flag = this.memberCount > 0U;
			if (flag)
			{
				this.name = data.RoleNames[0];
				this.id = data.RoleIds[0];
				this.formatname = XTitleDocument.GetTitleWithFormat((data.titleIDs.Count > 0) ? data.titleIDs[0] : 0U, XBaseRankInfo.GetUnderLineName(this.name));
			}
			bool flag2 = this.memberCount > 1U;
			if (flag2)
			{
				this.name1 = data.RoleNames[1];
				this.id1 = data.RoleIds[1];
				this.formatname1 = XTitleDocument.GetTitleWithFormat((data.titleIDs.Count > 1) ? data.titleIDs[1] : 0U, XBaseRankInfo.GetUnderLineName(this.name1));
			}
			this.rank = data.Rank;
			this.value = (ulong)data.towerThroughTime;
			this.diff = data.towerHardLevel;
			this.levelCount = data.towerFloor;
			this.m_Time = XSingleton<UiUtility>.singleton.TimeFormatString((int)this.value, 2, 3, 4, false, true);
			this.startType = data.starttype;
		}

		public override string GetValue()
		{
			return this.m_Time;
		}

		public ulong id1;

		public string name1;

		public string formatname1;

		public uint diff;

		public uint levelCount;

		public uint memberCount;

		private string m_Time;
	}
}
