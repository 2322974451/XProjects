using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FirstPassRankInfo
	{

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

		public List<FirstPassInfoData> InfoDataList
		{
			get
			{
				return this.m_infoDataList;
			}
		}

		public uint PassTime
		{
			get
			{
				return this.m_passTime;
			}
		}

		public uint UseTime
		{
			get
			{
				return this.m_useTime;
			}
		}

		public string PassTimeStr
		{
			get
			{
				return this.m_passTimeStr;
			}
		}

		public uint StarNum
		{
			get
			{
				return this.m_starNum;
			}
		}

		private List<FirstPassInfoData> m_infoDataList;

		private uint m_passTime = 0U;

		private string m_passTimeStr = string.Empty;

		private uint m_starNum = 0U;

		private uint m_useTime;
	}
}
