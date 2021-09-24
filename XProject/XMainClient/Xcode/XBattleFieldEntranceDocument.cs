using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBattleFieldEntranceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XBattleFieldEntranceDocument.uuID;
			}
		}

		public static XBattleFieldEntranceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XBattleFieldEntranceDocument.uuID) as XBattleFieldEntranceDocument;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XBattleFieldEntranceDocument.AsyncLoader.AddTask("Table/BattleFieldPointReward", XBattleFieldEntranceDocument._PointRewardTable, false);
			XBattleFieldEntranceDocument.AsyncLoader.Execute(callback);
		}

		public List<BattleFieldPointReward.RowData> GetPointRewardList()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			this.CurPointRewardList.Clear();
			for (int i = 0; i < XBattleFieldEntranceDocument._PointRewardTable.Table.Length; i++)
			{
				bool flag = (long)XBattleFieldEntranceDocument._PointRewardTable.Table[i].levelrange[0] <= (long)((ulong)level) && (ulong)level <= (ulong)((long)XBattleFieldEntranceDocument._PointRewardTable.Table[i].levelrange[1]);
				if (flag)
				{
					this.CurPointRewardList.Add(XBattleFieldEntranceDocument._PointRewardTable.Table[i]);
				}
			}
			return this.CurPointRewardList;
		}

		public BattleFieldPointReward.RowData GetCurPointRewardList(uint id)
		{
			for (int i = 0; i < XBattleFieldEntranceDocument._PointRewardTable.Table.Length; i++)
			{
				bool flag = XBattleFieldEntranceDocument._PointRewardTable.Table[i].id == id;
				if (flag)
				{
					return XBattleFieldEntranceDocument._PointRewardTable.Table[i];
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("BattleFieldPointReward.RowData No Find id:" + id, null, null, null, null, null);
			return null;
		}

		public void ReqPointRewardInfo()
		{
			RpcC2G_BattleFieldAwardNumReq rpc = new RpcC2G_BattleFieldAwardNumReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SetPointRewardRemainCount(BattleFieldAwardNumRes oRes)
		{
			this.CurPointRewardGetCount.Clear();
			for (int i = 0; i < oRes.award.Count; i++)
			{
				this.CurPointRewardGetCount[oRes.award[i].id] = oRes.award[i].count;
			}
			bool flag = DlgBase<BattleFieldEntranceView, BattleFieldEntranceBehaviour>.singleton._PointRewardHandler != null && DlgBase<BattleFieldEntranceView, BattleFieldEntranceBehaviour>.singleton._PointRewardHandler.Sys == XSysDefine.XSys_Battlefield;
			if (flag)
			{
				DlgBase<BattleFieldEntranceView, BattleFieldEntranceBehaviour>.singleton._PointRewardHandler.RefreshList(true);
			}
		}

		public uint GetPointRewardGetCount(uint id)
		{
			for (int i = 0; i < this.CurPointRewardGetCount.BufferKeys.Count; i++)
			{
				bool flag = this.CurPointRewardGetCount.BufferKeys[i] == id;
				if (flag)
				{
					return this.CurPointRewardGetCount.BufferValues[i];
				}
			}
			return 0U;
		}

		public void ReqJoin()
		{
			RpcC2M_EnterBattleReadyScene rpc = new RpcC2M_EnterBattleReadyScene();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Battlefield, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBattleFieldEntranceDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static BattleFieldPointReward _PointRewardTable = new BattleFieldPointReward();

		private List<BattleFieldPointReward.RowData> CurPointRewardList = new List<BattleFieldPointReward.RowData>();

		private XBetterDictionary<uint, uint> CurPointRewardGetCount = new XBetterDictionary<uint, uint>(0);

		public bool MainInterfaceState = false;
	}
}
