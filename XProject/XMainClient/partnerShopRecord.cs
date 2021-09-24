using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class partnerShopRecord
	{

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

		public ulong RoleId
		{
			get
			{
				return this.m_roleId;
			}
		}

		public string PlayerName
		{
			get
			{
				return this.m_name;
			}
		}

		public string ItemName
		{
			get
			{
				return this.m_row.ItemName[0];
			}
		}

		public string TimeStr
		{
			get
			{
				return this.m_timeStr;
			}
		}

		public uint BuyCount
		{
			get
			{
				return this.m_count;
			}
		}

		private ulong m_roleId;

		private ItemList.RowData m_row;

		private uint m_count;

		private uint m_time;

		private string m_name;

		private string m_timeStr;
	}
}
