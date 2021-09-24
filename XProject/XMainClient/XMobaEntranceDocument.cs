using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMobaEntranceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XMobaEntranceDocument.uuID;
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XMobaEntranceDocument.AsyncLoader.AddTask("Table/MobaWeekReward", XMobaEntranceDocument._MobaWeekReward, false);
			XMobaEntranceDocument.AsyncLoader.Execute(callback);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ReqMobaUIInfo();
			}
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
			if (flag)
			{
				this.ReqMobaUIInfo();
			}
		}

		public void ReqMobaUIInfo()
		{
			RpcC2M_GetMobaBattleInfo rpc = new RpcC2M_GetMobaBattleInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqMobaGetReward()
		{
			RpcC2M_GetMobaBattleWeekReward rpc = new RpcC2M_GetMobaBattleWeekReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void ReqMobaRecordTotal()
		{
			RpcC2M_GetMobaBattleBriefRecord rpc = new RpcC2M_GetMobaBattleBriefRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void ReqMobaRecordRound(uint roundID)
		{
			RpcC2M_GetMobaBattleGameRecord rpcC2M_GetMobaBattleGameRecord = new RpcC2M_GetMobaBattleGameRecord();
			rpcC2M_GetMobaBattleGameRecord.oArg.tag = roundID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetMobaBattleGameRecord);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MobaEntranceDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static MobaWeekReward _MobaWeekReward = new MobaWeekReward();

		public List<XMobaEntranceDocument.XMobaRecordTotal> RecordTotalList = new List<XMobaEntranceDocument.XMobaRecordTotal>();

		public uint WinThisWeek = 0U;

		public XMobaEntranceDocument.MobaRewardState RewardState = XMobaEntranceDocument.MobaRewardState.CanNotGet;

		public uint GetRewardStage = 0U;

		public uint MatchTotalCount = 0U;

		public uint WinCount = 0U;

		public uint LoseCount = 0U;

		public struct XMobaRecordTotal
		{

			public uint roundID;

			public uint heroID;

			public bool isWin;

			public bool isMVP;

			public bool isLoseMVP;

			public bool isEscape;

			public uint date;
		}

		public struct XMobaRecordRound
		{

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

			public uint roundID;

			public uint date;

			public uint time;

			public bool isteam1win;

			public List<XMobaEntranceDocument.XMobaRecordDetailOne> team1;

			public List<XMobaEntranceDocument.XMobaRecordDetailOne> team2;

			public ulong mvpid;

			public ulong losemvpid;

			public ulong damagemaxid;

			public ulong behitdamagemaxid;
		}

		public struct XMobaRecordDetailOne
		{

			public uint heroID;

			public XLevelRewardDocument.PVPRoleInfo data;
		}

		public enum MobaRewardState
		{

			CanNotGet,

			CanGet,

			GetEnd
		}
	}
}
