using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EAD RID: 3757
	internal class XPlayerAction : IXPlayerAction, IXInterface
	{
		// Token: 0x170034F0 RID: 13552
		// (get) Token: 0x0600C828 RID: 51240 RVA: 0x002CCD2B File Offset: 0x002CAF2B
		// (set) Token: 0x0600C829 RID: 51241 RVA: 0x002CCD33 File Offset: 0x002CAF33
		public bool Deprecated { get; set; }

		// Token: 0x0600C82A RID: 51242 RVA: 0x002CCD3C File Offset: 0x002CAF3C
		public void CameraWallEnter(AnimationCurve curve, Vector3 intersection, Vector3 cornerdir, float sector, float inDegree, float outDegree, bool positive)
		{
			bool flag = sector > 0f;
			if (flag)
			{
				bool flag2 = this._component == null;
				if (flag2)
				{
					this._component = (XSingleton<XScene>.singleton.GameCamera.GetXComponent(XCameraWallComponent.uuID) as XCameraWallComponent);
				}
				this._component.Effect(curve, intersection, cornerdir, sector, inDegree, outDegree, positive);
			}
		}

		// Token: 0x0600C82B RID: 51243 RVA: 0x002CCD9C File Offset: 0x002CAF9C
		public void CameraWallExit(float angle)
		{
			bool flag = this._component == null;
			if (flag)
			{
				this._component = (XSingleton<XScene>.singleton.GameCamera.GetXComponent(XCameraWallComponent.uuID) as XCameraWallComponent);
			}
			this._component.EndEffect();
		}

		// Token: 0x0600C82C RID: 51244 RVA: 0x002CCDE4 File Offset: 0x002CAFE4
		public void CameraWallVertical(float angle)
		{
			bool flag = this._component == null;
			if (flag)
			{
				this._component = (XSingleton<XScene>.singleton.GameCamera.GetXComponent(XCameraWallComponent.uuID) as XCameraWallComponent);
			}
			this._component.VerticalEffect(angle);
		}

		// Token: 0x0600C82D RID: 51245 RVA: 0x002CCE2C File Offset: 0x002CB02C
		public void SetExternalString(string exString, bool bOnce)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				PtcC2G_AddLevelScriptExtString ptcC2G_AddLevelScriptExtString = new PtcC2G_AddLevelScriptExtString();
				ptcC2G_AddLevelScriptExtString.Data.extString = exString;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_AddLevelScriptExtString);
			}
			else
			{
				XSingleton<XLevelScriptMgr>.singleton.SetExternalString(exString, bOnce);
			}
		}

		// Token: 0x0600C82E RID: 51246 RVA: 0x002CCE7A File Offset: 0x002CB07A
		public void PlayCutScene(string cutscene)
		{
			XSingleton<XDebug>.singleton.AddErrorLog("Cutscene wall is depracated.", null, null, null, null, null);
		}

		// Token: 0x0600C82F RID: 51247 RVA: 0x002CCE94 File Offset: 0x002CB094
		public void TransferToSceneLocation(Vector3 pos, Vector3 forward)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				XOnEntityTransferEventArgs @event = XEventPool<XOnEntityTransferEventArgs>.GetEvent();
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
				for (int i = 0; i < ally.Count; i++)
				{
					bool flag = ally[i] != XSingleton<XEntityMgr>.singleton.Player;
					if (flag)
					{
						XOnEntityTransferEventArgs event2 = XEventPool<XOnEntityTransferEventArgs>.GetEvent();
						event2.Firer = ally[i];
						XSingleton<XEventMgr>.singleton.FireEvent(event2);
						bool flag2 = ally[i].MobbedBy != null && ally[i].MobbedBy.IsRole && ally[i].Attributes != null && ally[i].Attributes.RunSpeed > 0f;
						if (flag2)
						{
							bool flag3 = ally[i].Nav != null;
							if (flag3)
							{
								ally[i].Nav.Interrupt();
							}
							ally[i].CorrectMe(pos, forward, false, true);
						}
					}
				}
				XSingleton<XEntityMgr>.singleton.Player.CorrectMe(pos, forward, false, true);
			}
		}

		// Token: 0x0600C830 RID: 51248 RVA: 0x002CCFEE File Offset: 0x002CB1EE
		public void TransferToNewScene(uint sceneID)
		{
			XSingleton<XGame>.singleton.SwitchTo(XSingleton<XGame>.singleton.CurrentStage.Stage, sceneID);
		}

		// Token: 0x0600C831 RID: 51249 RVA: 0x002CD00C File Offset: 0x002CB20C
		public void GotoBattle()
		{
			bool flag = XSingleton<XChatIFlyMgr>.singleton.IsRecording();
			if (!flag)
			{
				XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
				bool flag2 = !XSingleton<XEntityMgr>.singleton.Player.IsNavigating || (XSingleton<XEntityMgr>.singleton.Player.IsNavigating && XSingleton<XInput>.singleton.LastNpc == null && specificDocument.NaviTarget == 1);
				bool flag3 = flag2 && XSingleton<XEntityMgr>.singleton.Player.Net.SyncSequence > 1U;
				if (flag3)
				{
					bool flag4 = XSingleton<UIManager>.singleton.IsUIShowed();
					if (flag4)
					{
						this.AdjustPosForDungeonEnter(null);
						specificDocument.ResetNavi();
					}
					else
					{
						bool inTutorial = XSingleton<XTutorialMgr>.singleton.InTutorial;
						if (!inTutorial)
						{
							XSingleton<XGameUI>.singleton.OnGenericClick();
							DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.SetAutoSelectScene((int)specificDocument.NaviScene, 0, 0U);
							DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.FadeShow();
							XSingleton<XEntityMgr>.singleton.Player.Nav.Interrupt();
							XSingleton<XEntityMgr>.singleton.Player.Net.ReportMoveAction(Vector3.zero, 0.0);
							XSingleton<XInput>.singleton.Freezed = true;
							XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.AdjustPosForDungeonEnter), null);
						}
					}
				}
			}
		}

		// Token: 0x0600C832 RID: 51250 RVA: 0x002CD164 File Offset: 0x002CB364
		public void GotoTerritoryBattle(int index)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("enter scene: " + index, null, null, null, null, null);
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.SendGCFEnterin(index);
		}

		// Token: 0x0600C833 RID: 51251 RVA: 0x002CD1A8 File Offset: 0x002CB3A8
		public void GotoNest()
		{
			bool flag = !XSingleton<XEntityMgr>.singleton.Player.IsNavigating || (XSingleton<XEntityMgr>.singleton.Player.IsNavigating && XSingleton<XInput>.singleton.LastNpc == null && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.IsNavigateToBattle == 2);
			bool flag2 = flag && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Activity_DragonNest);
			if (flag2)
			{
				bool flag3 = XSingleton<UIManager>.singleton.IsUIShowed();
				if (flag3)
				{
					this.AdjustPosForDungeonEnter(null);
				}
				else
				{
					XSingleton<XGameUI>.singleton.OnGenericClick();
					DlgBase<XDragonNestView, XDragonNestBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					XSingleton<XEntityMgr>.singleton.Player.Nav.Interrupt();
					XSingleton<XEntityMgr>.singleton.Player.Net.ReportMoveAction(Vector3.zero, 0.0);
					XSingleton<XInput>.singleton.Freezed = true;
					XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.AdjustPosForDungeonEnter), null);
				}
			}
		}

		// Token: 0x0600C834 RID: 51252 RVA: 0x002CD2B0 File Offset: 0x002CB4B0
		public void GotoFishing(int seatIndex, bool bFishing)
		{
			XHomeFishingDocument specificDocument = XDocuments.GetSpecificDocument<XHomeFishingDocument>(XHomeFishingDocument.uuID);
			specificDocument.SetFishingUIState(bFishing);
		}

		// Token: 0x0600C835 RID: 51253 RVA: 0x002CD2D4 File Offset: 0x002CB4D4
		public void GotoYororuya()
		{
			bool flag = !XSingleton<XEntityMgr>.singleton.Player.IsNavigating || (XSingleton<XEntityMgr>.singleton.Player.IsNavigating && XSingleton<XInput>.singleton.LastNpc == null && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.IsNavigateToBattle == 2);
			bool flag2 = flag && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Yorozuya);
			if (flag2)
			{
				bool flag3 = XSingleton<UIManager>.singleton.IsUIShowed();
				if (flag3)
				{
					this.AdjustPosForDungeonEnter(null);
				}
				else
				{
					bool inTutorial = XSingleton<XTutorialMgr>.singleton.InTutorial;
					if (!inTutorial)
					{
						XSingleton<XGameUI>.singleton.OnGenericClick();
						DlgBase<YorozuyaDlg, YorozuyaBehaviour>.singleton.SetVisible(true, true);
						XSingleton<XEntityMgr>.singleton.Player.Nav.Interrupt();
						XSingleton<XEntityMgr>.singleton.Player.Net.ReportMoveAction(Vector3.zero, 0.0);
						XSingleton<XInput>.singleton.Freezed = true;
						XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.AdjustPosForDungeonEnter), null);
					}
				}
			}
		}

		// Token: 0x170034F1 RID: 13553
		// (get) Token: 0x0600C836 RID: 51254 RVA: 0x002CD3F0 File Offset: 0x002CB5F0
		public bool IsValid
		{
			get
			{
				return XSingleton<XScene>.singleton.SceneReady && XEntity.ValideEntity(XSingleton<XEntityMgr>.singleton.Player) && !XSingleton<XEntityMgr>.singleton.Player.IsCorrectingMe;
			}
		}

		// Token: 0x0600C837 RID: 51255 RVA: 0x002CD434 File Offset: 0x002CB634
		public Vector3 PlayerPosition(bool notplayertrigger)
		{
			Vector3 position;
			if (notplayertrigger)
			{
				position = XSingleton<XScene>.singleton.Dirver.EngineObject.Position;
			}
			else
			{
				position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
			}
			return position;
		}

		// Token: 0x0600C838 RID: 51256 RVA: 0x002CD478 File Offset: 0x002CB678
		public Vector3 PlayerLastPosition(bool notplayertrigger)
		{
			return notplayertrigger ? this._last_pos_driver : this._last_pos;
		}

		// Token: 0x0600C839 RID: 51257 RVA: 0x002CD49C File Offset: 0x002CB69C
		public void RefreshPosition()
		{
			this._last_pos = (XEntity.ValideEntity(XSingleton<XEntityMgr>.singleton.Player) ? XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position : this._last_pos);
			this._last_pos_driver = ((XSingleton<XScene>.singleton.Dirver == XSingleton<XEntityMgr>.singleton.Player) ? this._last_pos : (XEntity.ValideEntity(XSingleton<XScene>.singleton.Dirver) ? XSingleton<XScene>.singleton.Dirver.EngineObject.Position : this._last_pos_driver));
		}

		// Token: 0x0600C83A RID: 51258 RVA: 0x002CD530 File Offset: 0x002CB730
		private void AdjustPosForDungeonEnter(object o)
		{
			XSingleton<XEntityMgr>.singleton.Player.Net.ReportMoveAction(XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position - XSingleton<XEntityMgr>.singleton.Player.MoveObj.Forward * 2f, 0f, false, false, true, 0f);
		}

		// Token: 0x04005865 RID: 22629
		private Vector3 _last_pos = Vector3.zero;

		// Token: 0x04005866 RID: 22630
		private Vector3 _last_pos_driver = Vector3.zero;

		// Token: 0x04005867 RID: 22631
		private XCameraWallComponent _component = null;
	}
}
