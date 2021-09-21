using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A0B RID: 2571
	public class LoverLivenessRecord : LoopItemData
	{
		// Token: 0x06009DB7 RID: 40375 RVA: 0x0019C4E4 File Offset: 0x0019A6E4
		public LoverLivenessRecord(PartnerLivenessItem item)
		{
			this.SetString(item);
			this.m_time = item.time;
			this.m_name = item.name;
			this.m_showTimeStr = XSingleton<UiUtility>.singleton.TimeAgoFormatString((int)item.time);
		}

		// Token: 0x17002EA6 RID: 11942
		// (get) Token: 0x06009DB8 RID: 40376 RVA: 0x0019C548 File Offset: 0x0019A748
		public string ShowString
		{
			get
			{
				return this.m_showString;
			}
		}

		// Token: 0x17002EA7 RID: 11943
		// (get) Token: 0x06009DB9 RID: 40377 RVA: 0x0019C560 File Offset: 0x0019A760
		public string ShowTimeStr
		{
			get
			{
				return this.m_showTimeStr;
			}
		}

		// Token: 0x17002EA8 RID: 11944
		// (get) Token: 0x06009DBA RID: 40378 RVA: 0x0019C578 File Offset: 0x0019A778
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x17002EA9 RID: 11945
		// (get) Token: 0x06009DBB RID: 40379 RVA: 0x0019C590 File Offset: 0x0019A790
		public uint Time
		{
			get
			{
				return this.m_time;
			}
		}

		// Token: 0x06009DBC RID: 40380 RVA: 0x0019C5A8 File Offset: 0x0019A7A8
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

		// Token: 0x040037A4 RID: 14244
		private string m_showString = "";

		// Token: 0x040037A5 RID: 14245
		private string m_showTimeStr = "";

		// Token: 0x040037A6 RID: 14246
		private string m_name;

		// Token: 0x040037A7 RID: 14247
		private uint m_time;
	}
}
