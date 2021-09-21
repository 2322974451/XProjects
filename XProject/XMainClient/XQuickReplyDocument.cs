using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009BD RID: 2493
	internal class XQuickReplyDocument : XDocComponent
	{
		// Token: 0x17002D88 RID: 11656
		// (get) Token: 0x06009720 RID: 38688 RVA: 0x0016EEA4 File Offset: 0x0016D0A4
		public override uint ID
		{
			get
			{
				return XQuickReplyDocument.uuID;
			}
		}

		// Token: 0x17002D89 RID: 11657
		// (get) Token: 0x06009721 RID: 38689 RVA: 0x0016EEBB File Offset: 0x0016D0BB
		// (set) Token: 0x06009722 RID: 38690 RVA: 0x0016EEC3 File Offset: 0x0016D0C3
		public QuickReplyDlg QuickReplyView { get; set; }

		// Token: 0x06009723 RID: 38691 RVA: 0x0016EECC File Offset: 0x0016D0CC
		public static void Execute(OnLoadedCallback callBack = null)
		{
			XQuickReplyDocument.AsyncLoader.AddTask("Table/QuickReply", XQuickReplyDocument._reader, false);
			XQuickReplyDocument.AsyncLoader.Execute(callBack);
			XQuickReplyDocument._quickReplyTables.Clear();
		}

		// Token: 0x06009724 RID: 38692 RVA: 0x0016EEFC File Offset: 0x0016D0FC
		public static void OnTableLoaded()
		{
			int i = 0;
			int num = XQuickReplyDocument._reader.Table.Length;
			while (i < num)
			{
				QuickReplyTable.RowData rowData = XQuickReplyDocument._reader.Table[i];
				List<QuickReplyTable.RowData> list;
				bool flag = !XQuickReplyDocument._quickReplyTables.TryGetValue(rowData.Type, out list);
				if (flag)
				{
					list = new List<QuickReplyTable.RowData>();
					XQuickReplyDocument._quickReplyTables.Add(rowData.Type, list);
				}
				list.Add(rowData);
				i++;
			}
		}

		// Token: 0x06009725 RID: 38693 RVA: 0x0016EF78 File Offset: 0x0016D178
		public QuickReplyTable.RowData GetRowData(int id)
		{
			return XQuickReplyDocument._reader.GetByID(id);
		}

		// Token: 0x06009726 RID: 38694 RVA: 0x0016EF98 File Offset: 0x0016D198
		public List<QuickReplyTable.RowData> GetQuickReplyList(int type)
		{
			List<QuickReplyTable.RowData> result = null;
			XQuickReplyDocument._quickReplyTables.TryGetValue(type, out result);
			return result;
		}

		// Token: 0x06009727 RID: 38695 RVA: 0x0016EFBC File Offset: 0x0016D1BC
		public void GetThanksForBonus(ulong boundsID)
		{
			RpcC2G_ThanksForBonus rpcC2G_ThanksForBonus = new RpcC2G_ThanksForBonus();
			rpcC2G_ThanksForBonus.oArg.bonusID = (uint)boundsID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ThanksForBonus);
		}

		// Token: 0x06009728 RID: 38696 RVA: 0x0016EFEC File Offset: 0x0016D1EC
		public void OnThankForBonus(ThanksForBonusArg arg, ThanksForBonusRes res)
		{
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode, "fece00");
			}
			else
			{
				XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
				specificDocument.SetCanThank(false);
			}
		}

		// Token: 0x06009729 RID: 38697 RVA: 0x0016F034 File Offset: 0x0016D234
		public void GetAskForCheckInBonus()
		{
			RpcC2G_AskForCheckInBonus rpc = new RpcC2G_AskForCheckInBonus();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600972A RID: 38698 RVA: 0x0016F054 File Offset: 0x0016D254
		public void OnAskForCheckInBonus(AskForCheckInBonusArg arg, AskForCheckInBonusRes res)
		{
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode, "fece00");
			}
			else
			{
				XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
				specificDocument.GuildBonus.leftAskBonusTime = (double)XSingleton<XGlobalConfig>.singleton.GetInt("GuildBonusAskTimeSpan");
			}
		}

		// Token: 0x0600972B RID: 38699 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003397 RID: 13207
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("QuickReplyDocument");

		// Token: 0x04003398 RID: 13208
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003399 RID: 13209
		private static QuickReplyTable _reader = new QuickReplyTable();

		// Token: 0x0400339A RID: 13210
		private static Dictionary<int, List<QuickReplyTable.RowData>> _quickReplyTables = new Dictionary<int, List<QuickReplyTable.RowData>>();
	}
}
