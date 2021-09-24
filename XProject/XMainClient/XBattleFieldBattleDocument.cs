using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBattleFieldBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XBattleFieldBattleDocument.uuID;
			}
		}

		public static XBattleFieldBattleDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XBattleFieldBattleDocument.uuID) as XBattleFieldBattleDocument;
			}
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BATTLEFIELD_FIGHT;
			if (flag)
			{
				this.ReqBattleInfo();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

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

		public void ReqRankData()
		{
			RpcC2G_BattleFieldRankReq rpc = new RpcC2G_BattleFieldRankReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SetRankData(BattleFieldRankArg oArg, BattleFieldRankRes oRes)
		{
			bool flag = this.battleHandler != null && this.battleHandler.PanelObject != null && this.battleHandler.IsVisible();
			if (flag)
			{
				this.battleHandler.RefreshRank(oRes.ranks);
			}
		}

		public void SetReviveTime(PtcG2C_BattleFieldReliveNtf roPtc)
		{
			bool flag = this.battleHandler == null;
			if (!flag)
			{
				this.battleHandler.SetReviveTime(roPtc.Data.time);
			}
		}

		public void ReqBattleInfo()
		{
			RpcC2G_BattleFieldRoleAgainstReq rpc = new RpcC2G_BattleFieldRoleAgainstReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SetBattleInfo(BattleFieldRoleAgainst oRes)
		{
			this.userIdToRole.Clear();
			for (int i = 0; i < oRes.roles.Count; i++)
			{
				this.userIdToRole[oRes.roles[i].roleid] = oRes.roles[i].name;
			}
		}

		public void SetTime(PtcG2C_BFFightTimeNtf roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && roPtc.Data.time > 0U;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(roPtc.Data.time, -1);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBattleFieldBattleDocument");

		public XBetterDictionary<ulong, string> userIdToRole = new XBetterDictionary<ulong, string>(0);

		public BattleFieldBattleHandler battleHandler = null;

		public static readonly int BATTLE_SHOW_RANK = 5;
	}
}
