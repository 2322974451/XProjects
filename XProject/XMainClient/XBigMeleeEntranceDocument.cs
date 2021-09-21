using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200096E RID: 2414
	internal class XBigMeleeEntranceDocument : XDocComponent
	{
		// Token: 0x17002C69 RID: 11369
		// (get) Token: 0x06009175 RID: 37237 RVA: 0x0014D8C4 File Offset: 0x0014BAC4
		public override uint ID
		{
			get
			{
				return XBigMeleeEntranceDocument.uuID;
			}
		}

		// Token: 0x17002C6A RID: 11370
		// (get) Token: 0x06009176 RID: 37238 RVA: 0x0014D8DC File Offset: 0x0014BADC
		public static XBigMeleeEntranceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XBigMeleeEntranceDocument.uuID) as XBigMeleeEntranceDocument;
			}
		}

		// Token: 0x17002C6B RID: 11371
		// (get) Token: 0x06009177 RID: 37239 RVA: 0x0014D908 File Offset: 0x0014BB08
		public XBigMeleeRankList RankList
		{
			get
			{
				return XRankDocument.Doc.BigMeleeRankList;
			}
		}

		// Token: 0x06009178 RID: 37240 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06009179 RID: 37241 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnEnterSceneFinally()
		{
		}

		// Token: 0x0600917A RID: 37242 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600917B RID: 37243 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600917C RID: 37244 RVA: 0x0014D924 File Offset: 0x0014BB24
		public static void Execute(OnLoadedCallback callback = null)
		{
			XBigMeleeEntranceDocument.AsyncLoader.AddTask("Table/BigMeleePointReward", XBigMeleeEntranceDocument._PointRewardTable, false);
			XBigMeleeEntranceDocument.AsyncLoader.AddTask("Table/BigMeleeRankReward", XBigMeleeEntranceDocument._RankRewardTable, false);
			XBigMeleeEntranceDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600917D RID: 37245 RVA: 0x0014D960 File Offset: 0x0014BB60
		public List<BigMeleePointReward.RowData> GetPointRewardList()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			this.CurPointRewardList.Clear();
			for (int i = 0; i < XBigMeleeEntranceDocument._PointRewardTable.Table.Length; i++)
			{
				bool flag = (long)XBigMeleeEntranceDocument._PointRewardTable.Table[i].levelrange[0] <= (long)((ulong)level) && (ulong)level <= (ulong)((long)XBigMeleeEntranceDocument._PointRewardTable.Table[i].levelrange[1]);
				if (flag)
				{
					this.CurPointRewardList.Add(XBigMeleeEntranceDocument._PointRewardTable.Table[i]);
				}
			}
			return this.CurPointRewardList;
		}

		// Token: 0x0600917E RID: 37246 RVA: 0x0014DA10 File Offset: 0x0014BC10
		public List<BigMeleeRankReward.RowData> GetRankRewardList()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			this.CurRankRewardList.Clear();
			for (int i = 0; i < XBigMeleeEntranceDocument._RankRewardTable.Table.Length; i++)
			{
				bool flag = (long)XBigMeleeEntranceDocument._RankRewardTable.Table[i].levelrange[0] <= (long)((ulong)level) && (ulong)level <= (ulong)((long)XBigMeleeEntranceDocument._RankRewardTable.Table[i].levelrange[1]);
				if (flag)
				{
					this.CurRankRewardList.Add(XBigMeleeEntranceDocument._RankRewardTable.Table[i]);
				}
			}
			return this.CurRankRewardList;
		}

		// Token: 0x0600917F RID: 37247 RVA: 0x0014DAC0 File Offset: 0x0014BCC0
		public void ReqJoin()
		{
			RpcC2M_EnterBMReadyScene rpc = new RpcC2M_EnterBMReadyScene();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009180 RID: 37248 RVA: 0x0014DAE0 File Offset: 0x0014BCE0
		public void ReqRankData(int count = 0)
		{
			bool flag = count == 0;
			if (flag)
			{
				count = XBigMeleeEntranceDocument.MAX_RANK;
			}
			RpcC2M_QueryBigMeleeRank rpcC2M_QueryBigMeleeRank = new RpcC2M_QueryBigMeleeRank();
			rpcC2M_QueryBigMeleeRank.oArg.count = count;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_QueryBigMeleeRank);
		}

		// Token: 0x06009181 RID: 37249 RVA: 0x0014DB1C File Offset: 0x0014BD1C
		public void SetRankData(QueryMayhemRankArg oArg, QueryMayhemRankRes oRes)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("BigMeleeRank.Count:" + oRes.rank.Count, null, null, null, null, null);
			XRankDocument.ProcessRankListData(oRes.rank, this.RankList);
			this.RankList.myRankInfo = this.RankList.CreateNewInfo();
			this.isFight = oRes.infight;
			this.GroupID = (int)(oRes.gamezoneid + 1U);
			XBigMeleeRankInfo xbigMeleeRankInfo = this.RankList.myRankInfo as XBigMeleeRankInfo;
			bool flag = oRes.selfinfo != null;
			if (flag)
			{
				xbigMeleeRankInfo.ProcessData(oRes.selfinfo);
			}
			else
			{
				xbigMeleeRankInfo.InitMyData();
			}
			bool flag2 = oRes.selfrank > 0;
			if (flag2)
			{
				xbigMeleeRankInfo.rank = (uint)(oRes.selfrank - 1);
			}
			else
			{
				xbigMeleeRankInfo.rank = XRankDocument.INVALID_RANK;
			}
			bool flag3 = this.RankHandler != null && this.RankHandler.PanelObject != null && this.RankHandler.IsVisible();
			if (flag3)
			{
				this.RankHandler.RefreshList(false);
				bool flag4 = !this.RankHandler.IsRank;
				if (flag4)
				{
					this.RankHandler.SetCongratulate();
				}
				XSingleton<XDebug>.singleton.AddGreenLog("isFight:" + this.isFight.ToString(), null, null, null, null, null);
			}
			bool flag5 = DlgBase<XRankView, XRankBehaviour>.singleton.IsVisible();
			if (flag5)
			{
				XRankDocument.Doc.currentSelectRankList = XRankType.BigMeleeRank;
				DlgBase<XRankView, XRankBehaviour>.singleton.RefreshRankWindow();
			}
		}

		// Token: 0x06009182 RID: 37250 RVA: 0x0014DC9C File Offset: 0x0014BE9C
		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_BigMelee, true);
		}

		// Token: 0x06009183 RID: 37251 RVA: 0x0014DCB7 File Offset: 0x0014BEB7
		public void SetMainInterfaceBtnStateEnd(bool state)
		{
			this.MainInterfaceStateEnd = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_BigMeleeEnd, true);
		}

		// Token: 0x04003059 RID: 12377
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBigMeleeEntranceDocument");

		// Token: 0x0400305A RID: 12378
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400305B RID: 12379
		private static BigMeleePointReward _PointRewardTable = new BigMeleePointReward();

		// Token: 0x0400305C RID: 12380
		private static BigMeleeRankReward _RankRewardTable = new BigMeleeRankReward();

		// Token: 0x0400305D RID: 12381
		public BigMeleeRankHandler RankHandler = null;

		// Token: 0x0400305E RID: 12382
		private List<BigMeleePointReward.RowData> CurPointRewardList = new List<BigMeleePointReward.RowData>();

		// Token: 0x0400305F RID: 12383
		private List<BigMeleeRankReward.RowData> CurRankRewardList = new List<BigMeleeRankReward.RowData>();

		// Token: 0x04003060 RID: 12384
		public bool isFight = false;

		// Token: 0x04003061 RID: 12385
		public int GroupID = 0;

		// Token: 0x04003062 RID: 12386
		public static readonly int MAX_RANK = 100;

		// Token: 0x04003063 RID: 12387
		public bool MainInterfaceState = false;

		// Token: 0x04003064 RID: 12388
		public bool MainInterfaceStateEnd = false;
	}
}
