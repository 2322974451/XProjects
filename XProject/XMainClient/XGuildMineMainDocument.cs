using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000936 RID: 2358
	internal class XGuildMineMainDocument : XDocComponent
	{
		// Token: 0x17002BEA RID: 11242
		// (get) Token: 0x06008E5E RID: 36446 RVA: 0x0013AE2C File Offset: 0x0013902C
		public override uint ID
		{
			get
			{
				return XGuildMineMainDocument.uuID;
			}
		}

		// Token: 0x17002BEB RID: 11243
		// (get) Token: 0x06008E5F RID: 36447 RVA: 0x0013AE44 File Offset: 0x00139044
		// (set) Token: 0x06008E60 RID: 36448 RVA: 0x0013AE5C File Offset: 0x0013905C
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

		// Token: 0x06008E61 RID: 36449 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008E62 RID: 36450 RVA: 0x0013AE68 File Offset: 0x00139068
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

		// Token: 0x06008E63 RID: 36451 RVA: 0x0013AEBC File Offset: 0x001390BC
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_LeaveTeam, new XComponent.XEventHandler(this.OnLeaveTeam));
			base.RegisterEvent(XEventDefine.XEvent_TeamMemberCountChanged, new XComponent.XEventHandler(this.OnTeamMemberCountChanged));
		}

		// Token: 0x06008E64 RID: 36452 RVA: 0x0013AEF0 File Offset: 0x001390F0
		public bool OnLeaveTeam(XEventArgs args)
		{
			this.ClearUI();
			return true;
		}

		// Token: 0x06008E65 RID: 36453 RVA: 0x0013AF0C File Offset: 0x0013910C
		public bool OnTeamMemberCountChanged(XEventArgs args)
		{
			bool flag = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshMemberTips();
			}
			return true;
		}

		// Token: 0x06008E66 RID: 36454 RVA: 0x0013AF38 File Offset: 0x00139138
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

		// Token: 0x06008E67 RID: 36455 RVA: 0x0013AFBC File Offset: 0x001391BC
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildMineMainDocument.AsyncLoader.AddTask("Table/GuildMineralBattle", XGuildMineMainDocument._GuildMineralBattleTable, false);
			XGuildMineMainDocument.AsyncLoader.AddTask("Table/GuildMineralBufflist", XGuildMineMainDocument._GuildMineralBufflistTable, false);
			XGuildMineMainDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008E68 RID: 36456 RVA: 0x0013AFF8 File Offset: 0x001391F8
		public static GuildMineralBattle.RowData GetMineData(uint mineID)
		{
			return XGuildMineMainDocument._GuildMineralBattleTable.GetByID(mineID);
		}

		// Token: 0x06008E69 RID: 36457 RVA: 0x0013B018 File Offset: 0x00139218
		public static GuildMineralBufflist.RowData GetMineBuffData(uint BuffID)
		{
			return XGuildMineMainDocument._GuildMineralBufflistTable.GetByBuffID(BuffID);
		}

		// Token: 0x06008E6A RID: 36458 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x06008E6B RID: 36459 RVA: 0x0013B038 File Offset: 0x00139238
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XGuildMineEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
				specificDocument.ReqEnterMine();
			}
		}

		// Token: 0x17002BEC RID: 11244
		// (get) Token: 0x06008E6C RID: 36460 RVA: 0x0013B068 File Offset: 0x00139268
		// (set) Token: 0x06008E6D RID: 36461 RVA: 0x0013B080 File Offset: 0x00139280
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

		// Token: 0x06008E6E RID: 36462 RVA: 0x0013B08C File Offset: 0x0013928C
		public void ReqExplore(bool iscancel)
		{
			RpcC2M_ResWarExplore rpcC2M_ResWarExplore = new RpcC2M_ResWarExplore();
			rpcC2M_ResWarExplore.oArg.iscancel = iscancel;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ResWarExplore);
		}

		// Token: 0x06008E6F RID: 36463 RVA: 0x0013B0BC File Offset: 0x001392BC
		public void ReqChallenge(int mineIndex)
		{
			RpcC2M_StartResWarPVE rpcC2M_StartResWarPVE = new RpcC2M_StartResWarPVE();
			rpcC2M_StartResWarPVE.oArg.mine = (uint)mineIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_StartResWarPVE);
		}

		// Token: 0x06008E70 RID: 36464 RVA: 0x0013B0EC File Offset: 0x001392EC
		public void ReqResWarRank()
		{
			RpcC2M_QueryResWarRoleRank rpc = new RpcC2M_QueryResWarRoleRank();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008E71 RID: 36465 RVA: 0x0013B10C File Offset: 0x0013930C
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

		// Token: 0x06008E72 RID: 36466 RVA: 0x0013B444 File Offset: 0x00139644
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

		// Token: 0x06008E73 RID: 36467 RVA: 0x0013B768 File Offset: 0x00139968
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

		// Token: 0x06008E74 RID: 36468 RVA: 0x0013B7B4 File Offset: 0x001399B4
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

		// Token: 0x06008E75 RID: 36469 RVA: 0x0013B860 File Offset: 0x00139A60
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

		// Token: 0x04002E6A RID: 11882
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildMineMainDocument");

		// Token: 0x04002E6B RID: 11883
		private GuildMineMainView _view = null;

		// Token: 0x04002E6C RID: 11884
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002E6D RID: 11885
		private static GuildMineralBattle _GuildMineralBattleTable = new GuildMineralBattle();

		// Token: 0x04002E6E RID: 11886
		private static GuildMineralBufflist _GuildMineralBufflistTable = new GuildMineralBufflist();

		// Token: 0x04002E6F RID: 11887
		public GuildMineRankHandler GuildResRankHanler;

		// Token: 0x04002E70 RID: 11888
		public static readonly uint GUILD_NUM_MAX = 3U;

		// Token: 0x04002E71 RID: 11889
		public static readonly uint BOSS_NUM_MAX = 4U;

		// Token: 0x04002E72 RID: 11890
		public static readonly uint MINE_NUM_MAX = 5U;

		// Token: 0x04002E73 RID: 11891
		public bool IsNeedShowMainUI = false;

		// Token: 0x04002E74 RID: 11892
		private List<ResRankInfo> _resRankInfoList = new List<ResRankInfo>();
	}
}
