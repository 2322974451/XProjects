using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008F7 RID: 2295
	internal class XBattleFieldEntranceDocument : XDocComponent
	{
		// Token: 0x17002B25 RID: 11045
		// (get) Token: 0x06008ACE RID: 35534 RVA: 0x00127C50 File Offset: 0x00125E50
		public override uint ID
		{
			get
			{
				return XBattleFieldEntranceDocument.uuID;
			}
		}

		// Token: 0x17002B26 RID: 11046
		// (get) Token: 0x06008ACF RID: 35535 RVA: 0x00127C68 File Offset: 0x00125E68
		public static XBattleFieldEntranceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XBattleFieldEntranceDocument.uuID) as XBattleFieldEntranceDocument;
			}
		}

		// Token: 0x06008AD0 RID: 35536 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008AD1 RID: 35537 RVA: 0x00127C93 File Offset: 0x00125E93
		public static void Execute(OnLoadedCallback callback = null)
		{
			XBattleFieldEntranceDocument.AsyncLoader.AddTask("Table/BattleFieldPointReward", XBattleFieldEntranceDocument._PointRewardTable, false);
			XBattleFieldEntranceDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008AD2 RID: 35538 RVA: 0x00127CB8 File Offset: 0x00125EB8
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

		// Token: 0x06008AD3 RID: 35539 RVA: 0x00127D68 File Offset: 0x00125F68
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

		// Token: 0x06008AD4 RID: 35540 RVA: 0x00127DE0 File Offset: 0x00125FE0
		public void ReqPointRewardInfo()
		{
			RpcC2G_BattleFieldAwardNumReq rpc = new RpcC2G_BattleFieldAwardNumReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008AD5 RID: 35541 RVA: 0x00127E00 File Offset: 0x00126000
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

		// Token: 0x06008AD6 RID: 35542 RVA: 0x00127EA0 File Offset: 0x001260A0
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

		// Token: 0x06008AD7 RID: 35543 RVA: 0x00127F04 File Offset: 0x00126104
		public void ReqJoin()
		{
			RpcC2M_EnterBattleReadyScene rpc = new RpcC2M_EnterBattleReadyScene();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008AD8 RID: 35544 RVA: 0x00127F24 File Offset: 0x00126124
		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Battlefield, true);
		}

		// Token: 0x04002C41 RID: 11329
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBattleFieldEntranceDocument");

		// Token: 0x04002C42 RID: 11330
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002C43 RID: 11331
		private static BattleFieldPointReward _PointRewardTable = new BattleFieldPointReward();

		// Token: 0x04002C44 RID: 11332
		private List<BattleFieldPointReward.RowData> CurPointRewardList = new List<BattleFieldPointReward.RowData>();

		// Token: 0x04002C45 RID: 11333
		private XBetterDictionary<uint, uint> CurPointRewardGetCount = new XBetterDictionary<uint, uint>(0);

		// Token: 0x04002C46 RID: 11334
		public bool MainInterfaceState = false;
	}
}
