using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildMineMainDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildMineMainDocument.uuID;
			}
		}

		public GuildMineMainView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = this.IsNeedShowMainUI && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				XGuildMineEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
				bool mainInterfaceState = specificDocument.MainInterfaceState;
				if (mainInterfaceState)
				{
					specificDocument.ReqEnterMine();
				}
				this.IsNeedShowMainUI = false;
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_LeaveTeam, new XComponent.XEventHandler(this.OnLeaveTeam));
			base.RegisterEvent(XEventDefine.XEvent_TeamMemberCountChanged, new XComponent.XEventHandler(this.OnTeamMemberCountChanged));
		}

		public bool OnLeaveTeam(XEventArgs args)
		{
			this.ClearUI();
			return true;
		}

		public bool OnTeamMemberCountChanged(XEventArgs args)
		{
			bool flag = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshMemberTips();
			}
			return true;
		}

		public void ClearUI()
		{
			DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossMine.Clear();
			DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossMineBuff.Clear();
			DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CanPlayNewFindAnim = true;
			DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CurExploreLeftTime = 0f;
			DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.ExploreTimeMax = 0U;
			bool flag = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshBoss();
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshExploreTime();
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshButton();
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildMineMainDocument.AsyncLoader.AddTask("Table/GuildMineralBattle", XGuildMineMainDocument._GuildMineralBattleTable, false);
			XGuildMineMainDocument.AsyncLoader.AddTask("Table/GuildMineralBufflist", XGuildMineMainDocument._GuildMineralBufflistTable, false);
			XGuildMineMainDocument.AsyncLoader.Execute(callback);
		}

		public static GuildMineralBattle.RowData GetMineData(uint mineID)
		{
			return XGuildMineMainDocument._GuildMineralBattleTable.GetByID(mineID);
		}

		public static GuildMineralBufflist.RowData GetMineBuffData(uint BuffID)
		{
			return XGuildMineMainDocument._GuildMineralBufflistTable.GetByBuffID(BuffID);
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XGuildMineEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
				specificDocument.ReqEnterMine();
			}
		}

		internal List<ResRankInfo> ResRankInfoList
		{
			get
			{
				return this._resRankInfoList;
			}
			set
			{
				this._resRankInfoList = value;
			}
		}

		public void ReqExplore(bool iscancel)
		{
			RpcC2M_ResWarExplore rpcC2M_ResWarExplore = new RpcC2M_ResWarExplore();
			rpcC2M_ResWarExplore.oArg.iscancel = iscancel;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ResWarExplore);
		}

		public void ReqChallenge(int mineIndex)
		{
			RpcC2M_StartResWarPVE rpcC2M_StartResWarPVE = new RpcC2M_StartResWarPVE();
			rpcC2M_StartResWarPVE.oArg.mine = (uint)mineIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_StartResWarPVE);
		}

		public void ReqResWarRank()
		{
			RpcC2M_QueryResWarRoleRank rpc = new RpcC2M_QueryResWarRoleRank();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SetAllInfo(QueryResWarArg arg, QueryResWarRes res)
		{
			bool flag = res.data == null || XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (!flag)
			{
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				XGuildResContentionBuffDocument.Doc.OnGetBuffAllInfo(res.data);
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				ResWarGuildBrief data = res.data;
				bool flag2 = data.mineid.Count == this.View.BossMine.Count && data.mineid.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < data.mineid.Count; i++)
					{
						bool flag3 = data.mineid[i] != this.View.BossMine[i];
						if (flag3)
						{
							this.View.CanPlayNewFindAnim = true;
							break;
						}
					}
				}
				else
				{
					this.View.CanPlayNewFindAnim = true;
				}
				bool flag4 = data.mineid.Count != data.buffid.Count;
				if (flag4)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
					{
						"GuildMine mineid.Count!=buffid.Count: ",
						data.mineid.Count,
						"!=",
						data.buffid.Count
					}), null, null, null, null, null);
				}
				this.View.BossMine.Clear();
				this.View.BossMineBuff.Clear();
				for (int j = 0; j < data.mineid.Count; j++)
				{
					bool flag5 = (long)j == (long)((ulong)XGuildMineMainDocument.BOSS_NUM_MAX);
					if (flag5)
					{
						break;
					}
					this.View.BossMine.Add(data.mineid[j]);
				}
				for (int k = 0; k < data.buffid.Count; k++)
				{
					bool flag6 = (long)k == (long)((ulong)XGuildMineMainDocument.BOSS_NUM_MAX);
					if (flag6)
					{
						break;
					}
					this.View.BossMineBuff.Add(data.buffid[k]);
				}
				bool cdSpecified = data.cdSpecified;
				if (cdSpecified)
				{
					this.View.CurExploreLeftTime = res.data.cd;
				}
				else
				{
					this.View.CurExploreLeftTime = 0f;
				}
				bool totalcdSpecified = data.totalcdSpecified;
				if (totalcdSpecified)
				{
					this.View.ExploreTimeMax = res.data.totalcd;
				}
				else
				{
					this.View.ExploreTimeMax = 0U;
				}
				bool timecoutdownSpecified = data.timecoutdownSpecified;
				if (timecoutdownSpecified)
				{
					this.View.CurActivityLeftTime = data.timecoutdown;
				}
				else
				{
					this.View.CurActivityLeftTime = 0f;
				}
				bool timetypeSpecified = data.timetypeSpecified;
				if (timetypeSpecified)
				{
					this.View.ActivityStatus = (GuildMineActivityStatus)data.timetype;
				}
				else
				{
					this.View.ActivityStatus = GuildMineActivityStatus.None;
				}
				this.View.RefreshUI();
				XSingleton<XDebug>.singleton.AddGreenLog("Open:" + this.View.CurExploreLeftTime.ToString(), null, null, null, null, null);
			}
		}

		public void SetNewInfo(PtcM2C_ResWarGuildBriefNtf roPtc)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			ResWarGuildBrief data = roPtc.Data;
			bool flag = data.guildid == specificDocument.UID;
			if (flag)
			{
				bool flag2 = data.mineid.Count != data.buffid.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
					{
						"GuildMine mineid.Count!=buffid.Count: ",
						data.mineid.Count,
						"!=",
						data.buffid.Count
					}), null, null, null, null, null);
				}
				bool flag3 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossMine.Count == 0 && data.mineid.Count != 0;
				if (flag3)
				{
					for (int i = 0; i < data.mineid.Count; i++)
					{
						bool flag4 = (long)i == (long)((ulong)XGuildMineMainDocument.BOSS_NUM_MAX);
						if (flag4)
						{
							break;
						}
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossMine.Add(data.mineid[i]);
					}
					for (int j = 0; j < data.buffid.Count; j++)
					{
						bool flag5 = (long)j == (long)((ulong)XGuildMineMainDocument.BOSS_NUM_MAX);
						if (flag5)
						{
							break;
						}
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossMineBuff.Add(data.buffid[j]);
					}
					bool flag6 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
					if (flag6)
					{
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshBoss();
					}
				}
				else
				{
					bool flag7 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossMine.Count != 0 && data.mineid.Count == 0;
					if (flag7)
					{
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossMine.Clear();
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.BossMineBuff.Clear();
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CanPlayNewFindAnim = true;
						bool flag8 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
						if (flag8)
						{
							DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshBoss();
						}
					}
				}
				bool cdSpecified = data.cdSpecified;
				if (cdSpecified)
				{
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CurExploreLeftTime = data.cd;
				}
				else
				{
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CurExploreLeftTime = 0f;
				}
				bool totalcdSpecified = data.totalcdSpecified;
				if (totalcdSpecified)
				{
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.ExploreTimeMax = data.totalcd;
				}
				else
				{
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.ExploreTimeMax = 0U;
				}
				bool flag9 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
				if (flag9)
				{
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshExploreTime();
				}
				bool flag10 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
				if (flag10)
				{
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshButton();
				}
				bool timetypeSpecified = data.timetypeSpecified;
				if (timetypeSpecified)
				{
					bool timecoutdownSpecified = data.timecoutdownSpecified;
					if (timecoutdownSpecified)
					{
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CurActivityLeftTime = data.timecoutdown;
					}
					else
					{
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CurActivityLeftTime = 0f;
					}
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.ActivityStatus = (GuildMineActivityStatus)data.timetype;
					bool flag11 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
					if (flag11)
					{
						DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshActivityTime();
					}
				}
				XSingleton<XDebug>.singleton.AddGreenLog("Refresh:" + DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CurExploreLeftTime.ToString(), null, null, null, null, null);
			}
		}

		public void ActivityStatusChange(PtcM2C_ResWarTimeNtf roPtc)
		{
			DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CurActivityLeftTime = roPtc.Data.nTime;
			DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.ActivityStatus = GuildMineActivityStatus.Start;
			bool flag = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshActivityTime();
			}
		}

		public void OnGetRankInfo(ResWarRoleRankRes oRes)
		{
			this._resRankInfoList.Clear();
			for (int i = 0; i < oRes.data.Count; i++)
			{
				ResWarRoleRank resWarRoleRank = oRes.data[i];
				this._resRankInfoList.Add(new ResRankInfo
				{
					guildName = resWarRoleRank.guildname,
					roleID = resWarRoleRank.roleid,
					roleName = resWarRoleRank.rolename,
					donateValue = resWarRoleRank.res
				});
			}
			bool flag = this.GuildResRankHanler != null && this.GuildResRankHanler.IsVisible();
			if (flag)
			{
				this.GuildResRankHanler.RefreshUI();
			}
		}

		public void TeamLeaderOperate(PtcM2C_ResWarStateNtf roPtc)
		{
			bool flag = roPtc.Data.state == ResWarState.ResWarExploreState;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_EXPLORE_LEADER_START"), "fece00");
			}
			bool flag2 = roPtc.Data.state == ResWarState.ResWarCancelState;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_EXPLORE_LEADER_CANCEL"), "fece00");
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildMineMainDocument");

		private GuildMineMainView _view = null;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static GuildMineralBattle _GuildMineralBattleTable = new GuildMineralBattle();

		private static GuildMineralBufflist _GuildMineralBufflistTable = new GuildMineralBufflist();

		public GuildMineRankHandler GuildResRankHanler;

		public static readonly uint GUILD_NUM_MAX = 3U;

		public static readonly uint BOSS_NUM_MAX = 4U;

		public static readonly uint MINE_NUM_MAX = 5U;

		public bool IsNeedShowMainUI = false;

		private List<ResRankInfo> _resRankInfoList = new List<ResRankInfo>();
	}
}
