using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008F3 RID: 2291
	internal class XBattleFieldBattleDocument : XDocComponent
	{
		// Token: 0x17002B1F RID: 11039
		// (get) Token: 0x06008A9E RID: 35486 RVA: 0x00126C60 File Offset: 0x00124E60
		public override uint ID
		{
			get
			{
				return XBattleFieldBattleDocument.uuID;
			}
		}

		// Token: 0x17002B20 RID: 11040
		// (get) Token: 0x06008A9F RID: 35487 RVA: 0x00126C78 File Offset: 0x00124E78
		public static XBattleFieldBattleDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XBattleFieldBattleDocument.uuID) as XBattleFieldBattleDocument;
			}
		}

		// Token: 0x06008AA0 RID: 35488 RVA: 0x00126CA4 File Offset: 0x00124EA4
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_FIGHT;
			if (flag)
			{
				this.ReqBattleInfo();
			}
		}

		// Token: 0x06008AA1 RID: 35489 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008AA2 RID: 35490 RVA: 0x00126CD0 File Offset: 0x00124ED0
		public void ReceiveBattleKillInfo(PvpBattleKill battleKillInfo)
		{
			GVGBattleSkill gvgbattleSkill = new GVGBattleSkill();
			gvgbattleSkill.killerID = battleKillInfo.killID;
			gvgbattleSkill.deadID = battleKillInfo.deadID;
			gvgbattleSkill.contiKillCount = battleKillInfo.contiKillCount;
			XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(gvgbattleSkill.killerID);
			XEntity entityConsiderDeath2 = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(gvgbattleSkill.deadID);
			bool flag = entityConsiderDeath == null || entityConsiderDeath2 == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Killer id: " + gvgbattleSkill.killerID, " Dead id: " + gvgbattleSkill.deadID, null, null, null, null);
				bool flag2 = entityConsiderDeath == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("kill_en id null", null, null, null, null, null);
				}
				bool flag3 = entityConsiderDeath2 == null;
				if (flag3)
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

		// Token: 0x06008AA3 RID: 35491 RVA: 0x00126E18 File Offset: 0x00125018
		public void ReqRankData()
		{
			RpcC2G_BattleFieldRankReq rpc = new RpcC2G_BattleFieldRankReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008AA4 RID: 35492 RVA: 0x00126E38 File Offset: 0x00125038
		public void SetRankData(BattleFieldRankArg oArg, BattleFieldRankRes oRes)
		{
			bool flag = this.battleHandler != null && this.battleHandler.PanelObject != null && this.battleHandler.IsVisible();
			if (flag)
			{
				this.battleHandler.RefreshRank(oRes.ranks);
			}
		}

		// Token: 0x06008AA5 RID: 35493 RVA: 0x00126E88 File Offset: 0x00125088
		public void SetReviveTime(PtcG2C_BattleFieldReliveNtf roPtc)
		{
			bool flag = this.battleHandler == null;
			if (!flag)
			{
				this.battleHandler.SetReviveTime(roPtc.Data.time);
			}
		}

		// Token: 0x06008AA6 RID: 35494 RVA: 0x00126EBC File Offset: 0x001250BC
		public void ReqBattleInfo()
		{
			RpcC2G_BattleFieldRoleAgainstReq rpc = new RpcC2G_BattleFieldRoleAgainstReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008AA7 RID: 35495 RVA: 0x00126EDC File Offset: 0x001250DC
		public void SetBattleInfo(BattleFieldRoleAgainst oRes)
		{
			this.userIdToRole.Clear();
			for (int i = 0; i < oRes.roles.Count; i++)
			{
				this.userIdToRole[oRes.roles[i].roleid] = oRes.roles[i].name;
			}
		}

		// Token: 0x06008AA8 RID: 35496 RVA: 0x00126F40 File Offset: 0x00125140
		public void SetTime(PtcG2C_BFFightTimeNtf roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && roPtc.Data.time > 0U;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(roPtc.Data.time, -1);
			}
		}

		// Token: 0x04002C2B RID: 11307
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBattleFieldBattleDocument");

		// Token: 0x04002C2C RID: 11308
		public XBetterDictionary<ulong, string> userIdToRole = new XBetterDictionary<ulong, string>(0);

		// Token: 0x04002C2D RID: 11309
		public BattleFieldBattleHandler battleHandler = null;

		// Token: 0x04002C2E RID: 11310
		public static readonly int BATTLE_SHOW_RANK = 5;
	}
}
