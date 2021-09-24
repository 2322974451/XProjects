using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBigMeleeBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XBigMeleeBattleDocument.uuID;
			}
		}

		public static XBigMeleeBattleDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XBigMeleeBattleDocument.uuID) as XBigMeleeBattleDocument;
			}
		}

		public uint Round
		{
			get
			{
				return this._Round;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_FIGHT;
			if (flag)
			{
				DlgBase<BattleContiDlg, BattleContiBehaviour>.singleton.ClearRevenge();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void HideInfo()
		{
			bool flag = this.battleHandler != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("HideVSInfo", null, null, null, null, null);
				this.battleHandler.CloseVS(null);
			}
		}

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

		public void SetBattleTime(PtcG2C_BMFightTimeNtf roPtc)
		{
			bool flag = this.battleHandler == null;
			if (!flag)
			{
				this.battleHandler.RefreshStatusTime(roPtc.Data.type, roPtc.Data.time);
				this.battleHandler.ShieldMiniMapPlayer();
			}
		}

		public void SetReviveTime(PtcG2C_BigMeleeReliveNtf roPtc)
		{
			bool flag = this.battleHandler == null;
			if (!flag)
			{
				this.battleHandler.SetReviveTime(roPtc.Data.time);
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBigMeleeBattleDocument");

		public XBetterDictionary<ulong, XBigMeleeBattleDocument.RoleData> userIdToRole = new XBetterDictionary<ulong, XBigMeleeBattleDocument.RoleData>(0);

		public BigMeleeBattleHandler battleHandler = null;

		public static readonly int BATTLE_SHOW_RANK = 5;

		private uint _Round;

		public struct RoleData
		{

			public ulong roleID;

			public string name;

			public uint point;
		}
	}
}
