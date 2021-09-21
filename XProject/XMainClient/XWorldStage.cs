using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EED RID: 3821
	internal class XWorldStage : XConcreteStage
	{
		// Token: 0x0600CADF RID: 51935 RVA: 0x002E0967 File Offset: 0x002DEB67
		public XWorldStage() : base(EXStage.World)
		{
		}

		// Token: 0x0600CAE0 RID: 51936 RVA: 0x002E0974 File Offset: 0x002DEB74
		protected override void InstallCamera()
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraSoloComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraVAdjustComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraIntellectiveFollow.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraWallComponent.uuID);
			base.InstallCamera();
		}

		// Token: 0x0600CAE1 RID: 51937 RVA: 0x002E09F1 File Offset: 0x002DEBF1
		public override void OnEnterStage(EXStage eOld)
		{
			base.OnEnterStage(eOld);
		}

		// Token: 0x0600CAE2 RID: 51938 RVA: 0x002E09FC File Offset: 0x002DEBFC
		public override void OnLeaveStage(EXStage eNew)
		{
			base.OnLeaveStage(eNew);
		}

		// Token: 0x0600CAE3 RID: 51939 RVA: 0x002E0A08 File Offset: 0x002DEC08
		public override void OnEnterScene(uint sceneid, bool transfer)
		{
			base.OnEnterScene(sceneid, transfer);
			XSingleton<XGameUI>.singleton.m_uiTool.SetRootPanelUpdateFreq(3);
			XSingleton<XGameUI>.singleton.LoadWorldUI(this._eStage);
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisible(true, true);
			}
			bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisible(true, true);
			}
			XSingleton<XAIGeneralMgr>.singleton.InitAIMgr();
		}

		// Token: 0x0600CAE4 RID: 51940 RVA: 0x002E0A84 File Offset: 0x002DEC84
		public override void OnLeaveScene(bool transfer)
		{
			XSingleton<XLevelSpawnMgr>.singleton.OnLeaveScene();
			XSingleton<XLevelDoodadMgr>.singleton.OnLeaveScene();
			XSingleton<XLevelStatistics>.singleton.OnLeaveScene();
			XSingleton<XBulletMgr>.singleton.OnLeaveScene();
			XSingleton<XGameUI>.singleton.UnloadWorldUI();
			base.OnLeaveScene(transfer);
		}
	}
}
