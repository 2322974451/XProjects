using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XWorldStage : XConcreteStage
	{

		public XWorldStage() : base(EXStage.World)
		{
		}

		protected override void InstallCamera()
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraSoloComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraVAdjustComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraIntellectiveFollow.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraWallComponent.uuID);
			base.InstallCamera();
		}

		public override void OnEnterStage(EXStage eOld)
		{
			base.OnEnterStage(eOld);
		}

		public override void OnLeaveStage(EXStage eNew)
		{
			base.OnLeaveStage(eNew);
		}

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
