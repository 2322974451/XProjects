using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200095E RID: 2398
	internal class XMilitaryRankDocument : XDocComponent
	{
		// Token: 0x17002C46 RID: 11334
		// (get) Token: 0x0600908A RID: 37002 RVA: 0x0014959C File Offset: 0x0014779C
		public override uint ID
		{
			get
			{
				return XMilitaryRankDocument.uuID;
			}
		}

		// Token: 0x17002C47 RID: 11335
		// (get) Token: 0x0600908B RID: 37003 RVA: 0x001495B4 File Offset: 0x001477B4
		public MilitaryRankByExploit MilitaryReader
		{
			get
			{
				return XMilitaryRankDocument._militaryReader;
			}
		}

		// Token: 0x17002C48 RID: 11336
		// (get) Token: 0x0600908C RID: 37004 RVA: 0x001495CC File Offset: 0x001477CC
		public MilitaryRankReward MilitarySeasonReader
		{
			get
			{
				return XMilitaryRankDocument._militarySeasonReader;
			}
		}

		// Token: 0x17002C49 RID: 11337
		// (get) Token: 0x0600908D RID: 37005 RVA: 0x001495E4 File Offset: 0x001477E4
		public List<MilitaryRankData> RankList
		{
			get
			{
				return this._rankList;
			}
		}

		// Token: 0x17002C4A RID: 11338
		// (get) Token: 0x0600908E RID: 37006 RVA: 0x001495FC File Offset: 0x001477FC
		public MilitaryRankData MyData
		{
			get
			{
				return this._myData;
			}
		}

		// Token: 0x0600908F RID: 37007 RVA: 0x00149614 File Offset: 0x00147814
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

		// Token: 0x06009090 RID: 37008 RVA: 0x00149674 File Offset: 0x00147874
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

		// Token: 0x06009091 RID: 37009 RVA: 0x001496A8 File Offset: 0x001478A8
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

		// Token: 0x06009092 RID: 37010 RVA: 0x00149771 File Offset: 0x00147971
		public static void Execute(OnLoadedCallback callback = null)
		{
			XMilitaryRankDocument.AsyncLoader.AddTask("Table/MilitaryRankByExploit", XMilitaryRankDocument._militaryReader, false);
			XMilitaryRankDocument.AsyncLoader.AddTask("Table/MilitaryRankReward", XMilitaryRankDocument._militarySeasonReader, false);
			XMilitaryRankDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009093 RID: 37011 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06009094 RID: 37012 RVA: 0x001497AC File Offset: 0x001479AC
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.RankShowRange = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MilitaryRankShowRange"));
		}

		// Token: 0x06009095 RID: 37013 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06009096 RID: 37014 RVA: 0x001497D1 File Offset: 0x001479D1
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
		}

		// Token: 0x06009097 RID: 37015 RVA: 0x001497DC File Offset: 0x001479DC
		public void QueryRankInfo()
		{
			RpcC2M_ClientQueryRankListNtf rpcC2M_ClientQueryRankListNtf = new RpcC2M_ClientQueryRankListNtf();
			rpcC2M_ClientQueryRankListNtf.oArg.RankType = (uint)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.MilitaryRank);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ClientQueryRankListNtf);
		}

		// Token: 0x06009098 RID: 37016 RVA: 0x00149810 File Offset: 0x00147A10
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

		// Token: 0x06009099 RID: 37017 RVA: 0x001498D0 File Offset: 0x00147AD0
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

		// Token: 0x0600909A RID: 37018 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002FD9 RID: 12249
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MilitaryRankDocument");

		// Token: 0x04002FDA RID: 12250
		private static readonly string MILITARY_ATLAS = "common/Billboard";

		// Token: 0x04002FDB RID: 12251
		public int RankShowRange;

		// Token: 0x04002FDC RID: 12252
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002FDD RID: 12253
		public static MilitaryRankByExploit _militaryReader = new MilitaryRankByExploit();

		// Token: 0x04002FDE RID: 12254
		private static MilitaryRankReward _militarySeasonReader = new MilitaryRankReward();

		// Token: 0x04002FDF RID: 12255
		private List<MilitaryRankData> _rankList = new List<MilitaryRankData>();

		// Token: 0x04002FE0 RID: 12256
		private MilitaryRankData _myData = new MilitaryRankData();

		// Token: 0x04002FE1 RID: 12257
		public MilitaryRecord MyMilitaryRecord = new MilitaryRecord();
	}
}
