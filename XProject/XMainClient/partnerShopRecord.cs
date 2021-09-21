using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C69 RID: 3177
	internal class partnerShopRecord
	{
		// Token: 0x0600B3DD RID: 46045 RVA: 0x00230EE4 File Offset: 0x0022F0E4
		public partnerShopRecord(PartnerShopRecordItem item)
		{
			this.m_roleId = item.roleid;
			this.m_row = XBagDocument.GetItemConf((int)item.itemid);
			bool flag = this.m_row == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("can not find this item,itemid = " + item.itemid.ToString(), null, null, null, null, null);
			}
			this.m_count = item.itemcount;
			this.m_name = XTitleDocument.GetTitleWithFormat(item.titleid, item.name);
			this.m_time = item.time;
			this.m_timeStr = XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)item.time, XStringDefineProxy.GetString("TimeFormate"), true);
		}

		// Token: 0x170031D5 RID: 12757
		// (get) Token: 0x0600B3DE RID: 46046 RVA: 0x00230F9C File Offset: 0x0022F19C
		public ulong RoleId
		{
			get
			{
				return this.m_roleId;
			}
		}

		// Token: 0x170031D6 RID: 12758
		// (get) Token: 0x0600B3DF RID: 46047 RVA: 0x00230FB4 File Offset: 0x0022F1B4
		public string PlayerName
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x170031D7 RID: 12759
		// (get) Token: 0x0600B3E0 RID: 46048 RVA: 0x00230FCC File Offset: 0x0022F1CC
		public string ItemName
		{
			get
			{
				return this.m_row.ItemName[0];
			}
		}

		// Token: 0x170031D8 RID: 12760
		// (get) Token: 0x0600B3E1 RID: 46049 RVA: 0x00230FEC File Offset: 0x0022F1EC
		public string TimeStr
		{
			get
			{
				return this.m_timeStr;
			}
		}

		// Token: 0x170031D9 RID: 12761
		// (get) Token: 0x0600B3E2 RID: 46050 RVA: 0x00231004 File Offset: 0x0022F204
		public uint BuyCount
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x040045B6 RID: 17846
		private ulong m_roleId;

		// Token: 0x040045B7 RID: 17847
		private ItemList.RowData m_row;

		// Token: 0x040045B8 RID: 17848
		private uint m_count;

		// Token: 0x040045B9 RID: 17849
		private uint m_time;

		// Token: 0x040045BA RID: 17850
		private string m_name;

		// Token: 0x040045BB RID: 17851
		private string m_timeStr;
	}
}
