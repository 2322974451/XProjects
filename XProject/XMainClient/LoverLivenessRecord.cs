using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	public class LoverLivenessRecord : LoopItemData
	{

		public LoverLivenessRecord(PartnerLivenessItem item)
		{
			this.SetString(item);
			this.m_time = item.time;
			this.m_name = item.name;
			this.m_showTimeStr = XSingleton<UiUtility>.singleton.TimeAgoFormatString((int)item.time);
		}

		public string ShowString
		{
			get
			{
				return this.m_showString;
			}
		}

		public string ShowTimeStr
		{
			get
			{
				return this.m_showTimeStr;
			}
		}

		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		public uint Time
		{
			get
			{
				return this.m_time;
			}
		}

		private void SetString(PartnerLivenessItem item)
		{
			XDailyActivitiesDocument specificDocument = XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID);
			ActivityTable.RowData activityBasicInfo = specificDocument.GetActivityBasicInfo(item.actid);
			bool flag = activityBasicInfo == null;
			if (flag)
			{
				this.m_showString = null;
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("id is error,{0}", item.actid), null, null, null, null, null);
			}
			else
			{
				this.m_showString = string.Format(XSingleton<XStringTable>.singleton.GetString("WeddingLoverLivenessRecord"), item.name, activityBasicInfo.name, activityBasicInfo.value);
			}
		}

		private string m_showString = "";

		private string m_showTimeStr = "";

		private string m_name;

		private uint m_time;
	}
}
