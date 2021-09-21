using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000D02 RID: 3330
	internal class FirstPassRankList
	{
		// Token: 0x0600BA50 RID: 47696 RVA: 0x0025F84C File Offset: 0x0025DA4C
		public FirstPassRankList(ClientQueryRankListRes oRes, bool isFirstPassRank = true)
		{
			this.timeStamp = oRes.TimeStamp;
			bool flag = oRes.RankList == null;
			if (!flag)
			{
				for (int i = 0; i < oRes.RankList.RankData.Count; i++)
				{
					FirstPassRankInfo item = new FirstPassRankInfo(oRes.RankList.RankData[i], isFirstPassRank);
					this.m_InfoList.Add(item);
				}
			}
		}

		// Token: 0x0600BA51 RID: 47697 RVA: 0x0025F8D4 File Offset: 0x0025DAD4
		public FirstPassRankList()
		{
		}

		// Token: 0x0600BA52 RID: 47698 RVA: 0x0025F8F0 File Offset: 0x0025DAF0
		public void Init(ClientQueryRankListRes oRes, bool isFirstPassRank = true)
		{
			this.timeStamp = oRes.TimeStamp;
			this.m_InfoList = new List<FirstPassRankInfo>();
			bool flag = oRes.RankList == null;
			if (!flag)
			{
				for (int i = 0; i < oRes.RankList.RankData.Count; i++)
				{
					FirstPassRankInfo item = new FirstPassRankInfo(oRes.RankList.RankData[i], isFirstPassRank);
					this.m_InfoList.Add(item);
				}
			}
		}

		// Token: 0x170032D1 RID: 13009
		// (get) Token: 0x0600BA53 RID: 47699 RVA: 0x0025F96C File Offset: 0x0025DB6C
		public List<FirstPassRankInfo> InfoList
		{
			get
			{
				return this.m_InfoList;
			}
		}

		// Token: 0x04004A88 RID: 19080
		private List<FirstPassRankInfo> m_InfoList = new List<FirstPassRankInfo>();

		// Token: 0x04004A89 RID: 19081
		public uint timeStamp = 0U;
	}
}
