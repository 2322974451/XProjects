using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000903 RID: 2307
	internal class DragonGuildShopRecord
	{
		// Token: 0x06008B91 RID: 35729 RVA: 0x0012B5AC File Offset: 0x001297AC
		public DragonGuildShopRecord(DragonGuildShopRecordItem item)
		{
			this.m_roleId = item.roleid;
			this.m_row = XBagDocument.GetItemConf((int)item.itemid);
			bool flag = this.m_row == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("can not find this item,itemid = " + item.itemid.ToString(), null, null, null, null, null);
			}
			this.m_count = item.itemcount;
			this.m_name = XTitleDocument.GetTitleWithFormat(item.titleId, item.name);
			this.m_time = item.time;
			this.m_timeStr = XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)item.time, XStringDefineProxy.GetString("TimeFormate"), true);
		}

		// Token: 0x17002B58 RID: 11096
		// (get) Token: 0x06008B92 RID: 35730 RVA: 0x0012B664 File Offset: 0x00129864
		public ulong RoleId
		{
			get
			{
				return this.m_roleId;
			}
		}

		// Token: 0x17002B59 RID: 11097
		// (get) Token: 0x06008B93 RID: 35731 RVA: 0x0012B67C File Offset: 0x0012987C
		public string PlayerName
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x17002B5A RID: 11098
		// (get) Token: 0x06008B94 RID: 35732 RVA: 0x0012B694 File Offset: 0x00129894
		public string ItemName
		{
			get
			{
				return this.m_row.ItemName[0];
			}
		}

		// Token: 0x17002B5B RID: 11099
		// (get) Token: 0x06008B95 RID: 35733 RVA: 0x0012B6B4 File Offset: 0x001298B4
		public string TimeStr
		{
			get
			{
				return this.m_timeStr;
			}
		}

		// Token: 0x17002B5C RID: 11100
		// (get) Token: 0x06008B96 RID: 35734 RVA: 0x0012B6CC File Offset: 0x001298CC
		public uint BuyCount
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x04002CA3 RID: 11427
		private ulong m_roleId;

		// Token: 0x04002CA4 RID: 11428
		private ItemList.RowData m_row;

		// Token: 0x04002CA5 RID: 11429
		private uint m_count;

		// Token: 0x04002CA6 RID: 11430
		private uint m_time;

		// Token: 0x04002CA7 RID: 11431
		private string m_name;

		// Token: 0x04002CA8 RID: 11432
		private string m_timeStr;
	}
}
