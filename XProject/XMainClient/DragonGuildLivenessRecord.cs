using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000902 RID: 2306
	public class DragonGuildLivenessRecord : LoopItemData
	{
		// Token: 0x06008B8B RID: 35723 RVA: 0x0012B458 File Offset: 0x00129658
		public DragonGuildLivenessRecord(PartnerLivenessItem item)
		{
			this.SetString(item);
			this.m_time = item.time;
			this.m_name = item.name;
			this.m_showTimeStr = XSingleton<UiUtility>.singleton.TimeAgoFormatString((int)item.time);
		}

		// Token: 0x17002B54 RID: 11092
		// (get) Token: 0x06008B8C RID: 35724 RVA: 0x0012B4BC File Offset: 0x001296BC
		public string ShowString
		{
			get
			{
				return this.m_showString;
			}
		}

		// Token: 0x17002B55 RID: 11093
		// (get) Token: 0x06008B8D RID: 35725 RVA: 0x0012B4D4 File Offset: 0x001296D4
		public string ShowTimeStr
		{
			get
			{
				return this.m_showTimeStr;
			}
		}

		// Token: 0x17002B56 RID: 11094
		// (get) Token: 0x06008B8E RID: 35726 RVA: 0x0012B4EC File Offset: 0x001296EC
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x17002B57 RID: 11095
		// (get) Token: 0x06008B8F RID: 35727 RVA: 0x0012B504 File Offset: 0x00129704
		public uint Time
		{
			get
			{
				return this.m_time;
			}
		}

		// Token: 0x06008B90 RID: 35728 RVA: 0x0012B51C File Offset: 0x0012971C
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
				this.m_showString = string.Format(XSingleton<XStringTable>.singleton.GetString("PartnerLivenessRecord"), item.name, activityBasicInfo.name, activityBasicInfo.value);
			}
		}

		// Token: 0x04002C9F RID: 11423
		private string m_showString = "";

		// Token: 0x04002CA0 RID: 11424
		private string m_showTimeStr = "";

		// Token: 0x04002CA1 RID: 11425
		private string m_name;

		// Token: 0x04002CA2 RID: 11426
		private uint m_time;
	}
}
