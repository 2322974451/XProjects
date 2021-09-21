using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008F4 RID: 2292
	internal class XBigMeleeBattleDocument : XDocComponent
	{
		// Token: 0x17002B21 RID: 11041
		// (get) Token: 0x06008AAB RID: 35499 RVA: 0x00126FC0 File Offset: 0x001251C0
		public override uint ID
		{
			get
			{
				return XBigMeleeBattleDocument.uuID;
			}
		}

		// Token: 0x17002B22 RID: 11042
		// (get) Token: 0x06008AAC RID: 35500 RVA: 0x00126FD8 File Offset: 0x001251D8
		public static XBigMeleeBattleDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XBigMeleeBattleDocument.uuID) as XBigMeleeBattleDocument;
			}
		}

		// Token: 0x17002B23 RID: 11043
		// (get) Token: 0x06008AAD RID: 35501 RVA: 0x00127004 File Offset: 0x00125204
		public uint Round
		{
			get
			{
				return this._Round;
			}
		}

		// Token: 0x06008AAE RID: 35502 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008AAF RID: 35503 RVA: 0x0012701C File Offset: 0x0012521C
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_FIGHT;
			if (flag)
			{
				DlgBase<BattleContiDlg, BattleContiBehaviour>.singleton.ClearRevenge();
			}
		}

		// Token: 0x06008AB0 RID: 35504 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008AB1 RID: 35505 RVA: 0x0012704C File Offset: 0x0012524C
		public void HideInfo()
		{
			bool flag = this.battleHandler != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("HideVSInfo", null, null, null, null, null);
				this.battleHandler.CloseVS(null);
			}
		}

		// Token: 0x06008AB2 RID: 35506 RVA: 0x0012708C File Offset: 0x0012528C
		public void ReceiveBattleKillInfo(PvpBattleKill battleKillInfo)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BIGMELEE_FIGHT;
			if (!flag)
			{
				GVGBattleSkill gvgbattleSkill = new GVGBattleSkill();
				gvgbattleSkill.killerID = battleKillInfo.killID;
				gvgbattleSkill.deadID = battleKillInfo.deadID;
				gvgbattleSkill.contiKillCount = battleKillInfo.contiKillCount;
				XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(gvgbattleSkill.killerID);
				XEntity entityConsiderDeath2 = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(gvgbattleSkill.deadID);
				bool flag2 = entityConsiderDeath == null || entityConsiderDeath2 == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Killer id: " + gvgbattleSkill.killerID, " Dead id: " + gvgbattleSkill.deadID, null, null, null, null);
					bool flag3 = entityConsiderDeath == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("kill_en id null", null, null, null, null, null);
					}
					bool flag4 = entityConsiderDeath2 == null;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("dead_en id null", null, null, null, null, null);
					}
				}
				else
				{
					gvgbattleSkill.killerName = entityConsiderDeath.Name;
					gvgbattleSkill.deadName = entityConsiderDeath2.Name;
					gvgbattleSkill.killerPosition = XSingleton<XEntityMgr>.singleton.IsAlly(entityConsiderDeath);
					DlgBase<BattleContiDlg, BattleContiBehaviour>.singleton.AddBattleSkill(gvgbattleSkill);
					XSingleton<XDebug>.singleton.AddGreenLog(string.Format("ReceiveBattleKillInfo:{0} --- ,{1} ,.... {2}", gvgbattleSkill.killerName, gvgbattleSkill.deadName, gvgbattleSkill.contiKillCount), null, null, null, null, null);
				}
			}
		}

		// Token: 0x06008AB3 RID: 35507 RVA: 0x001271F0 File Offset: 0x001253F0
		public void SetRankData(QueryMayhemRankArg oArg, QueryMayhemRankRes oRes)
		{
			XRankDocument.ProcessRankListData(oRes.rank, XBigMeleeEntranceDocument.Doc.RankList);
			XBigMeleeEntranceDocument.Doc.RankList.myRankInfo = XBigMeleeEntranceDocument.Doc.RankList.CreateNewInfo();
			XBigMeleeRankInfo xbigMeleeRankInfo = XBigMeleeEntranceDocument.Doc.RankList.myRankInfo as XBigMeleeRankInfo;
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
			bool flag3 = this.battleHandler != null && this.battleHandler.PanelObject != null && this.battleHandler.IsVisible();
			if (flag3)
			{
				this.battleHandler.RefreshRank();
			}
		}

		// Token: 0x06008AB4 RID: 35508 RVA: 0x001272CC File Offset: 0x001254CC
		public void SetBattleData(PtcG2C_BMRoleSceneSyncNtf roPtc)
		{
			this._Round = roPtc.Data.games;
			List<BMRoleEnter> roles = roPtc.Data.roles;
			for (int i = 0; i < roles.Count; i++)
			{
				XBigMeleeBattleDocument.RoleData roleData;
				roleData.roleID = roles[i].roleid;
				roleData.name = roles[i].name;
				roleData.point = roles[i].score;
				this.userIdToRole[roleData.roleID] = roleData;
				XBigMeleePointChange @event = XEventPool<XBigMeleePointChange>.GetEvent();
				XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(roleData.roleID);
				@event.point = roleData.point;
				@event.Firer = entityConsiderDeath;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
				{
					"roleid:",
					roleData.roleID,
					"\npoint:",
					roleData.point
				}), null, null, null, null, null);
			}
			XSingleton<XDebug>.singleton.AddGreenLog("PtcG2C_BMRoleSceneSyncNtf _Round:" + this._Round, null, null, null, null, null);
			bool flag = this.battleHandler != null;
			if (flag)
			{
				this.battleHandler.RefreshStage();
			}
		}

		// Token: 0x06008AB5 RID: 35509 RVA: 0x00127424 File Offset: 0x00125624
		public void SetBattleTime(PtcG2C_BMFightTimeNtf roPtc)
		{
			bool flag = this.battleHandler == null;
			if (!flag)
			{
				this.battleHandler.RefreshStatusTime(roPtc.Data.type, roPtc.Data.time);
				this.battleHandler.ShieldMiniMapPlayer();
			}
		}

		// Token: 0x06008AB6 RID: 35510 RVA: 0x00127470 File Offset: 0x00125670
		public void SetReviveTime(PtcG2C_BigMeleeReliveNtf roPtc)
		{
			bool flag = this.battleHandler == null;
			if (!flag)
			{
				this.battleHandler.SetReviveTime(roPtc.Data.time);
			}
		}

		// Token: 0x06008AB7 RID: 35511 RVA: 0x001274A4 File Offset: 0x001256A4
		public void SetPoint(ulong roleid, uint point)
		{
			XBigMeleeBattleDocument.RoleData value = this.userIdToRole[roleid];
			value.point = point;
			this.userIdToRole[roleid] = value;
			XBigMeleePointChange @event = XEventPool<XBigMeleePointChange>.GetEvent();
			XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(roleid);
			@event.point = point;
			@event.Firer = entityConsiderDeath;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
			{
				"roleid:",
				roleid,
				"\npoint:",
				point
			}), null, null, null, null, null);
		}

		// Token: 0x04002C2F RID: 11311
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBigMeleeBattleDocument");

		// Token: 0x04002C30 RID: 11312
		public XBetterDictionary<ulong, XBigMeleeBattleDocument.RoleData> userIdToRole = new XBetterDictionary<ulong, XBigMeleeBattleDocument.RoleData>(0);

		// Token: 0x04002C31 RID: 11313
		public BigMeleeBattleHandler battleHandler = null;

		// Token: 0x04002C32 RID: 11314
		public static readonly int BATTLE_SHOW_RANK = 5;

		// Token: 0x04002C33 RID: 11315
		private uint _Round;

		// Token: 0x02001957 RID: 6487
		public struct RoleData
		{
			// Token: 0x04007DC9 RID: 32201
			public ulong roleID;

			// Token: 0x04007DCA RID: 32202
			public string name;

			// Token: 0x04007DCB RID: 32203
			public uint point;
		}
	}
}
