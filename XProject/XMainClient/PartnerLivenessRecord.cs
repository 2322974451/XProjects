using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C68 RID: 3176
	public class PartnerLivenessRecord : LoopItemData
	{
		// Token: 0x0600B3D7 RID: 46039 RVA: 0x00230D90 File Offset: 0x0022EF90
		public PartnerLivenessRecord(PartnerLivenessItem item)
		{
			this.SetString(item);
			this.m_time = item.time;
			this.m_name = item.name;
			this.m_showTimeStr = XSingleton<UiUtility>.singleton.TimeAgoFormatString((int)item.time);
		}

		// Token: 0x170031D1 RID: 12753
		// (get) Token: 0x0600B3D8 RID: 46040 RVA: 0x00230DF4 File Offset: 0x0022EFF4
		public string ShowString
		{
			get
			{
				return this.m_showString;
			}
		}

		// Token: 0x170031D2 RID: 12754
		// (get) Token: 0x0600B3D9 RID: 46041 RVA: 0x00230E0C File Offset: 0x0022F00C
		public string ShowTimeStr
		{
			get
			{
				return this.m_showTimeStr;
			}
		}

		// Token: 0x170031D3 RID: 12755
		// (get) Token: 0x0600B3DA RID: 46042 RVA: 0x00230E24 File Offset: 0x0022F024
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x170031D4 RID: 12756
		// (get) Token: 0x0600B3DB RID: 46043 RVA: 0x00230E3C File Offset: 0x0022F03C
		public uint Time
		{
			get
			{
				return this.m_time;
			}
		}

		// Token: 0x0600B3DC RID: 46044 RVA: 0x00230E54 File Offset: 0x0022F054
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

		// Token: 0x040045B2 RID: 17842
		private string m_showString = "";

		// Token: 0x040045B3 RID: 17843
		private string m_showTimeStr = "";

		// Token: 0x040045B4 RID: 17844
		private string m_name;

		// Token: 0x040045B5 RID: 17845
		private uint m_time;
	}
}
