using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200091A RID: 2330
	internal class XMobaEntranceDocument : XDocComponent
	{
		// Token: 0x17002B81 RID: 11137
		// (get) Token: 0x06008C85 RID: 35973 RVA: 0x00130C0C File Offset: 0x0012EE0C
		public override uint ID
		{
			get
			{
				return XMobaEntranceDocument.uuID;
			}
		}

		// Token: 0x17002B82 RID: 11138
		// (get) Token: 0x06008C86 RID: 35974 RVA: 0x00130C24 File Offset: 0x0012EE24
		public uint MatchTotalPercent
		{
			get
			{
				bool flag = this.MatchTotalCount == 0U;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					bool flag2 = this.WinCount == 0U;
					if (flag2)
					{
						result = 0U;
					}
					else
					{
						result = Math.Max(1U, 100U * this.WinCount / this.MatchTotalCount);
					}
				}
				return result;
			}
		}

		// Token: 0x06008C87 RID: 35975 RVA: 0x00130C6E File Offset: 0x0012EE6E
		public static void Execute(OnLoadedCallback callback = null)
		{
			XMobaEntranceDocument.AsyncLoader.AddTask("Table/MobaWeekReward", XMobaEntranceDocument._MobaWeekReward, false);
			XMobaEntranceDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008C88 RID: 35976 RVA: 0x00130C94 File Offset: 0x0012EE94
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ReqMobaUIInfo();
			}
		}

		// Token: 0x06008C89 RID: 35977 RVA: 0x00130CB8 File Offset: 0x0012EEB8
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
			if (flag)
			{
				this.ReqMobaUIInfo();
			}
		}

		// Token: 0x06008C8A RID: 35978 RVA: 0x00130CE0 File Offset: 0x0012EEE0
		public void ReqMobaUIInfo()
		{
			RpcC2M_GetMobaBattleInfo rpc = new RpcC2M_GetMobaBattleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008C8B RID: 35979 RVA: 0x00130D00 File Offset: 0x0012EF00
		public void ReqMobaGetReward()
		{
			RpcC2M_GetMobaBattleWeekReward rpc = new RpcC2M_GetMobaBattleWeekReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008C8C RID: 35980 RVA: 0x00130D20 File Offset: 0x0012EF20
		public void SetMobaUIInfo(GetMobaBattleInfoArg oArg, GetMobaBattleInfoRes oRes)
		{
			this.WinThisWeek = oRes.winthisweek;
			this.GetRewardStage = oRes.weekprize;
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Moba, true);
			this.RewardState = XMobaEntranceDocument.MobaRewardState.CanNotGet;
			bool getnextweekprize = oRes.getnextweekprize;
			if (getnextweekprize)
			{
				this.RewardState = XMobaEntranceDocument.MobaRewardState.CanGet;
			}
			bool flag = this.GetRewardStage == XMobaEntranceDocument._MobaWeekReward.Table[XMobaEntranceDocument._MobaWeekReward.Table.Length - 1].id;
			if (flag)
			{
				this.GetRewardStage -= 1U;
				this.RewardState = XMobaEntranceDocument.MobaRewardState.GetEnd;
			}
			bool flag2 = DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.RefreshRaward();
			}
		}

		// Token: 0x06008C8D RID: 35981 RVA: 0x00130DD0 File Offset: 0x0012EFD0
		public void SetMobaNewReward(GetMobaBattleWeekRewardArg oArg, GetMobaBattleWeekRewardRes oRes)
		{
			this.GetRewardStage = oRes.weekprize;
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Moba, true);
			this.RewardState = XMobaEntranceDocument.MobaRewardState.CanNotGet;
			bool getnextweekprize = oRes.getnextweekprize;
			if (getnextweekprize)
			{
				this.RewardState = XMobaEntranceDocument.MobaRewardState.CanGet;
			}
			bool flag = this.GetRewardStage == XMobaEntranceDocument._MobaWeekReward.Table[XMobaEntranceDocument._MobaWeekReward.Table.Length - 1].id;
			if (flag)
			{
				this.GetRewardStage -= 1U;
				this.RewardState = XMobaEntranceDocument.MobaRewardState.GetEnd;
			}
			bool flag2 = DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.RefreshRaward();
			}
		}

		// Token: 0x06008C8E RID: 35982 RVA: 0x00130E70 File Offset: 0x0012F070
		public void ReqMobaRecordTotal()
		{
			RpcC2M_GetMobaBattleBriefRecord rpc = new RpcC2M_GetMobaBattleBriefRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008C8F RID: 35983 RVA: 0x00130E90 File Offset: 0x0012F090
		public void SetMobaRecordTotal(GetMobaBattleBriefRecordArg oArg, GetMobaBattleBriefRecordRes oRes)
		{
			this.MatchTotalCount = oRes.totalnum;
			this.WinCount = oRes.winnum;
			this.LoseCount = oRes.totalnum - oRes.winnum;
			this.RecordTotalList.Clear();
			for (int i = 0; i < oRes.brief.Count; i++)
			{
				XMobaEntranceDocument.XMobaRecordTotal item = default(XMobaEntranceDocument.XMobaRecordTotal);
				item.roundID = oRes.brief[i].tag;
				item.heroID = oRes.brief[i].heroid;
				item.isWin = oRes.brief[i].iswin;
				item.isMVP = oRes.brief[i].ismvp;
				item.isLoseMVP = oRes.brief[i].islosemvp;
				item.isEscape = oRes.brief[i].isescape;
				item.date = oRes.brief[i].date;
				this.RecordTotalList.Add(item);
			}
			bool flag = DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.m_MobaBattleRecordHandler != null;
			if (flag)
			{
				DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.m_MobaBattleRecordHandler.Refresh();
			}
		}

		// Token: 0x06008C90 RID: 35984 RVA: 0x00130FD8 File Offset: 0x0012F1D8
		public void ReqMobaRecordRound(uint roundID)
		{
			RpcC2M_GetMobaBattleGameRecord rpcC2M_GetMobaBattleGameRecord = new RpcC2M_GetMobaBattleGameRecord();
			rpcC2M_GetMobaBattleGameRecord.oArg.tag = roundID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetMobaBattleGameRecord);
		}

		// Token: 0x06008C91 RID: 35985 RVA: 0x00131008 File Offset: 0x0012F208
		public void SetMobaRecordRound(GetMobaBattleGameRecordArg oArg, GetMobaBattleGameRecordRes oRes)
		{
			XMobaEntranceDocument.XMobaRecordRound data = default(XMobaEntranceDocument.XMobaRecordRound);
			bool flag = oRes.record != null;
			if (flag)
			{
				data.roundID = oRes.record.tag;
				data.date = oRes.record.date;
				data.time = oRes.record.timeSpan;
				data.isteam1win = (oRes.record.winteamid == 1U);
				data.mvpid = oRes.record.mvpid;
				data.losemvpid = oRes.record.losemvpid;
				data.damagemaxid = oRes.record.damagemaxid;
				data.behitdamagemaxid = oRes.record.behitdamagemaxid;
				data.team1 = data.SetMobaRecordDetailOne(oRes.record.team1);
				data.team2 = data.SetMobaRecordDetailOne(oRes.record.team2);
			}
			bool flag2 = DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.m_MobaBattleRecordHandler != null;
			if (flag2)
			{
				DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.m_MobaBattleRecordHandler.RefreshDetail(data);
			}
		}

		// Token: 0x04002D6B RID: 11627
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MobaEntranceDocument");

		// Token: 0x04002D6C RID: 11628
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002D6D RID: 11629
		public static MobaWeekReward _MobaWeekReward = new MobaWeekReward();

		// Token: 0x04002D6E RID: 11630
		public List<XMobaEntranceDocument.XMobaRecordTotal> RecordTotalList = new List<XMobaEntranceDocument.XMobaRecordTotal>();

		// Token: 0x04002D6F RID: 11631
		public uint WinThisWeek = 0U;

		// Token: 0x04002D70 RID: 11632
		public XMobaEntranceDocument.MobaRewardState RewardState = XMobaEntranceDocument.MobaRewardState.CanNotGet;

		// Token: 0x04002D71 RID: 11633
		public uint GetRewardStage = 0U;

		// Token: 0x04002D72 RID: 11634
		public uint MatchTotalCount = 0U;

		// Token: 0x04002D73 RID: 11635
		public uint WinCount = 0U;

		// Token: 0x04002D74 RID: 11636
		public uint LoseCount = 0U;

		// Token: 0x02001959 RID: 6489
		public struct XMobaRecordTotal
		{
			// Token: 0x04007DD0 RID: 32208
			public uint roundID;

			// Token: 0x04007DD1 RID: 32209
			public uint heroID;

			// Token: 0x04007DD2 RID: 32210
			public bool isWin;

			// Token: 0x04007DD3 RID: 32211
			public bool isMVP;

			// Token: 0x04007DD4 RID: 32212
			public bool isLoseMVP;

			// Token: 0x04007DD5 RID: 32213
			public bool isEscape;

			// Token: 0x04007DD6 RID: 32214
			public uint date;
		}

		// Token: 0x0200195A RID: 6490
		public struct XMobaRecordRound
		{
			// Token: 0x06010FEE RID: 69614 RVA: 0x00452CD8 File Offset: 0x00450ED8
			public List<XMobaEntranceDocument.XMobaRecordDetailOne> SetMobaRecordDetailOne(List<MobaBattleOneGameRole> oResData)
			{
				List<XMobaEntranceDocument.XMobaRecordDetailOne> list = new List<XMobaEntranceDocument.XMobaRecordDetailOne>(oResData.Count);
				for (int i = 0; i < oResData.Count; i++)
				{
					XMobaEntranceDocument.XMobaRecordDetailOne item = default(XMobaEntranceDocument.XMobaRecordDetailOne);
					item.heroID = oResData[i].heroid;
					item.data.uID = oResData[i].roleid;
					item.data.KillCount = (int)oResData[i].killcount;
					item.data.DeathCount = oResData[i].deathcount;
					item.data.AssitCount = oResData[i].assistcount;
					item.data.Kda = oResData[i].kda;
					item.data.MaxKillCount = (int)oResData[i].multikillcount;
					item.data.isescape = oResData[i].isescape;
					item.data.Name = oResData[i].name;
					list.Add(item);
				}
				return list;
			}

			// Token: 0x04007DD7 RID: 32215
			public uint roundID;

			// Token: 0x04007DD8 RID: 32216
			public uint date;

			// Token: 0x04007DD9 RID: 32217
			public uint time;

			// Token: 0x04007DDA RID: 32218
			public bool isteam1win;

			// Token: 0x04007DDB RID: 32219
			public List<XMobaEntranceDocument.XMobaRecordDetailOne> team1;

			// Token: 0x04007DDC RID: 32220
			public List<XMobaEntranceDocument.XMobaRecordDetailOne> team2;

			// Token: 0x04007DDD RID: 32221
			public ulong mvpid;

			// Token: 0x04007DDE RID: 32222
			public ulong losemvpid;

			// Token: 0x04007DDF RID: 32223
			public ulong damagemaxid;

			// Token: 0x04007DE0 RID: 32224
			public ulong behitdamagemaxid;
		}

		// Token: 0x0200195B RID: 6491
		public struct XMobaRecordDetailOne
		{
			// Token: 0x04007DE1 RID: 32225
			public uint heroID;

			// Token: 0x04007DE2 RID: 32226
			public XLevelRewardDocument.PVPRoleInfo data;
		}

		// Token: 0x0200195C RID: 6492
		public enum MobaRewardState
		{
			// Token: 0x04007DE4 RID: 32228
			CanNotGet,
			// Token: 0x04007DE5 RID: 32229
			CanGet,
			// Token: 0x04007DE6 RID: 32230
			GetEnd
		}
	}
}
