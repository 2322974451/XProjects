using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D03 RID: 3331
	internal class FirstPassRankInfo
	{
		// Token: 0x0600BA54 RID: 47700 RVA: 0x0025F984 File Offset: 0x0025DB84
		public FirstPassRankInfo(RankData info, bool isFirstPassRank)
		{
			this.m_infoDataList = new List<FirstPassInfoData>();
			for (int i = 0; i < info.RoleNames.Count; i++)
			{
				FirstPassInfoData item = new FirstPassInfoData(info.RoleIds[i], info.RoleNames[i], info.titleIDs[i], isFirstPassRank);
				this.m_infoDataList.Add(item);
			}
			this.m_passTime = info.time;
			this.m_starNum = info.starlevel + 1U;
			this.m_useTime = info.usetime;
			if (isFirstPassRank)
			{
				this.m_passTimeStr = XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)info.time, XStringDefineProxy.GetString("TimeFormate"), true);
			}
			else
			{
				this.m_passTimeStr = XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)info.usetime, 5);
			}
		}

		// Token: 0x170032D2 RID: 13010
		// (get) Token: 0x0600BA55 RID: 47701 RVA: 0x0025FA78 File Offset: 0x0025DC78
		public List<FirstPassInfoData> InfoDataList
		{
			get
			{
				return this.m_infoDataList;
			}
		}

		// Token: 0x170032D3 RID: 13011
		// (get) Token: 0x0600BA56 RID: 47702 RVA: 0x0025FA90 File Offset: 0x0025DC90
		public uint PassTime
		{
			get
			{
				return this.m_passTime;
			}
		}

		// Token: 0x170032D4 RID: 13012
		// (get) Token: 0x0600BA57 RID: 47703 RVA: 0x0025FAA8 File Offset: 0x0025DCA8
		public uint UseTime
		{
			get
			{
				return this.m_useTime;
			}
		}

		// Token: 0x170032D5 RID: 13013
		// (get) Token: 0x0600BA58 RID: 47704 RVA: 0x0025FAC0 File Offset: 0x0025DCC0
		public string PassTimeStr
		{
			get
			{
				return this.m_passTimeStr;
			}
		}

		// Token: 0x170032D6 RID: 13014
		// (get) Token: 0x0600BA59 RID: 47705 RVA: 0x0025FAD8 File Offset: 0x0025DCD8
		public uint StarNum
		{
			get
			{
				return this.m_starNum;
			}
		}

		// Token: 0x04004A8A RID: 19082
		private List<FirstPassInfoData> m_infoDataList;

		// Token: 0x04004A8B RID: 19083
		private uint m_passTime = 0U;

		// Token: 0x04004A8C RID: 19084
		private string m_passTimeStr = string.Empty;

		// Token: 0x04004A8D RID: 19085
		private uint m_starNum = 0U;

		// Token: 0x04004A8E RID: 19086
		private uint m_useTime;
	}
}
