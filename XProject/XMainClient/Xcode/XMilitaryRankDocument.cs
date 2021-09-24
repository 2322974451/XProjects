using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMilitaryRankDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XMilitaryRankDocument.uuID;
			}
		}

		public MilitaryRankByExploit MilitaryReader
		{
			get
			{
				return XMilitaryRankDocument._militaryReader;
			}
		}

		public MilitaryRankReward MilitarySeasonReader
		{
			get
			{
				return XMilitaryRankDocument._militarySeasonReader;
			}
		}

		public List<MilitaryRankData> RankList
		{
			get
			{
				return this._rankList;
			}
		}

		public MilitaryRankData MyData
		{
			get
			{
				return this._myData;
			}
		}

		public static string GetMilitaryRankWithFormat(uint level, string name = "", bool space = false)
		{
			MilitaryRankByExploit.RowData byMilitaryRank = XMilitaryRankDocument._militaryReader.GetByMilitaryRank(level);
			bool flag = byMilitaryRank != null;
			string result;
			if (flag)
			{
				if (space)
				{
					name = XSingleton<XCommon>.singleton.StringCombine(" ", name);
				}
				result = XSingleton<XCommon>.singleton.StringCombine(XLabelSymbolHelper.FormatImage(XMilitaryRankDocument.MILITARY_ATLAS, byMilitaryRank.Icon), name);
			}
			else
			{
				result = name;
			}
			return result;
		}

		public static string GetMilitaryIcon(uint level)
		{
			MilitaryRankByExploit.RowData byMilitaryRank = XMilitaryRankDocument._militaryReader.GetByMilitaryRank(level);
			bool flag = byMilitaryRank != null;
			string result;
			if (flag)
			{
				result = byMilitaryRank.Icon;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public void SetMyMilitaryRecord(MilitaryRecord data)
		{
			bool flag = false;
			bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null && XSingleton<XAttributeMgr>.singleton.XPlayerData.MilitaryRank != data.military_rank;
			if (flag2)
			{
				flag = true;
				XSingleton<XAttributeMgr>.singleton.XPlayerData.MilitaryRank = data.military_rank;
			}
			this.MyMilitaryRecord.military_rank = data.military_rank;
			this.MyMilitaryRecord.military_rank_his = data.military_rank_his;
			this.MyMilitaryRecord.military_exploit = data.military_exploit;
			this.MyMilitaryRecord.military_exploit_his = data.military_exploit_his;
			bool flag3 = flag;
			if (flag3)
			{
				XTitleInfoChange @event = XEventPool<XTitleInfoChange>.GetEvent();
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XMilitaryRankDocument.AsyncLoader.AddTask("Table/MilitaryRankByExploit", XMilitaryRankDocument._militaryReader, false);
			XMilitaryRankDocument.AsyncLoader.AddTask("Table/MilitaryRankReward", XMilitaryRankDocument._militarySeasonReader, false);
			XMilitaryRankDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.RankShowRange = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MilitaryRankShowRange"));
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
		}

		public void QueryRankInfo()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.MilitaryRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		public void OnGetRankInfo(ClientQueryRankListRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				this._rankList.Clear();
				for (int i = 0; i < oRes.RankList.RankData.Count; i++)
				{
					this._rankList.Add(this.TurnRankData2MilitaryData(oRes.RankList.RankData[i], (uint)i));
				}
				this._myData = this.TurnRankData2MilitaryData(oRes.RoleRankData, oRes.RoleRankData.Rank);
				bool flag2 = DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.Refresh();
				}
			}
		}

		private MilitaryRankData TurnRankData2MilitaryData(RankData data, uint rank)
		{
			return new MilitaryRankData
			{
				rank = rank,
				MilitaryLevel = data.military_info.military_rank,
				name = data.RoleName,
				MilitaryPoint = data.military_info.military_exploit
			};
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MilitaryRankDocument");

		private static readonly string MILITARY_ATLAS = "common/Billboard";

		public int RankShowRange;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static MilitaryRankByExploit _militaryReader = new MilitaryRankByExploit();

		private static MilitaryRankReward _militarySeasonReader = new MilitaryRankReward();

		private List<MilitaryRankData> _rankList = new List<MilitaryRankData>();

		private MilitaryRankData _myData = new MilitaryRankData();

		public MilitaryRecord MyMilitaryRecord = new MilitaryRecord();
	}
}
