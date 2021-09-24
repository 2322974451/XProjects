using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	internal class FirstPassRankList
	{

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

		public FirstPassRankList()
		{
		}

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

		public List<FirstPassRankInfo> InfoList
		{
			get
			{
				return this.m_InfoList;
			}
		}

		private List<FirstPassRankInfo> m_InfoList = new List<FirstPassRankInfo>();

		public uint timeStamp = 0U;
	}
}
