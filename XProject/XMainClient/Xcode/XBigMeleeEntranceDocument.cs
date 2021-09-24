using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBigMeleeEntranceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XBigMeleeEntranceDocument.uuID;
			}
		}

		public static XBigMeleeEntranceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XBigMeleeEntranceDocument.uuID) as XBigMeleeEntranceDocument;
			}
		}

		public XBigMeleeRankList RankList
		{
			get
			{
				return XRankDocument.Doc.BigMeleeRankList;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XBigMeleeEntranceDocument.AsyncLoader.AddTask("Table/BigMeleePointReward", XBigMeleeEntranceDocument._PointRewardTable, false);
			XBigMeleeEntranceDocument.AsyncLoader.AddTask("Table/BigMeleeRankReward", XBigMeleeEntranceDocument._RankRewardTable, false);
			XBigMeleeEntranceDocument.AsyncLoader.Execute(callback);
		}

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

		public void ReqJoin()
		{
			RpcC2M_EnterBMReadyScene rpc = new RpcC2M_EnterBMReadyScene();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_BigMelee, true);
		}

		public void SetMainInterfaceBtnStateEnd(bool state)
		{
			this.MainInterfaceStateEnd = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_BigMeleeEnd, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBigMeleeEntranceDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static BigMeleePointReward _PointRewardTable = new BigMeleePointReward();

		private static BigMeleeRankReward _RankRewardTable = new BigMeleeRankReward();

		public BigMeleeRankHandler RankHandler = null;

		private List<BigMeleePointReward.RowData> CurPointRewardList = new List<BigMeleePointReward.RowData>();

		private List<BigMeleeRankReward.RowData> CurRankRewardList = new List<BigMeleeRankReward.RowData>();

		public bool isFight = false;

		public int GroupID = 0;

		public static readonly int MAX_RANK = 100;

		public bool MainInterfaceState = false;

		public bool MainInterfaceStateEnd = false;
	}
}
