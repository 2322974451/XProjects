using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQuickReplyDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XQuickReplyDocument.uuID;
			}
		}

		public QuickReplyDlg QuickReplyView { get; set; }

		public static void Execute(OnLoadedCallback callBack = null)
		{
			XQuickReplyDocument.AsyncLoader.AddTask("Table/QuickReply", XQuickReplyDocument._reader, false);
			XQuickReplyDocument.AsyncLoader.Execute(callBack);
			XQuickReplyDocument._quickReplyTables.Clear();
		}

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

		public QuickReplyTable.RowData GetRowData(int id)
		{
			return XQuickReplyDocument._reader.GetByID(id);
		}

		public List<QuickReplyTable.RowData> GetQuickReplyList(int type)
		{
			List<QuickReplyTable.RowData> result = null;
			XQuickReplyDocument._quickReplyTables.TryGetValue(type, out result);
			return result;
		}

		public void GetThanksForBonus(ulong boundsID)
		{
			RpcC2G_ThanksForBonus rpcC2G_ThanksForBonus = new RpcC2G_ThanksForBonus();
			rpcC2G_ThanksForBonus.oArg.bonusID = (uint)boundsID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ThanksForBonus);
		}

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

		public void GetAskForCheckInBonus()
		{
			RpcC2G_AskForCheckInBonus rpc = new RpcC2G_AskForCheckInBonus();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("QuickReplyDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static QuickReplyTable _reader = new QuickReplyTable();

		private static Dictionary<int, List<QuickReplyTable.RowData>> _quickReplyTables = new Dictionary<int, List<QuickReplyTable.RowData>>();
	}
}
