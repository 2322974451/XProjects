using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XConcreteStage : XStage
	{

		public XConcreteStage(EXStage eStage) : base(eStage)
		{
		}

		public override void OnEnterStage(EXStage eOld)
		{
			base.OnEnterStage(eOld);
		}

		public override void OnLeaveStage(EXStage eNew)
		{
			base.OnLeaveStage(eNew);
			bool flag = eNew != EXStage.Null && !XStage.IsConcreteStage(eNew);
			if (flag)
			{
				XSingleton<XAttributeMgr>.singleton.OnLeaveStage();
				XSingleton<XGame>.singleton.Doc.Refresh();
			}
		}

		private void InitTerrain(uint sceneid)
		{
			XSingleton<XScene>.singleton.CurrentTerrain = Terrain.activeTerrain;
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneid);
			bool flag = !string.IsNullOrEmpty(sceneData.BlockFilePath);
			if (flag)
			{
				bool flag2 = !XCurrentGrid.grid.LoadFile(sceneData.BlockFilePath);
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Load Grid file: Assets\\Resources\\", sceneData.BlockFilePath, " failed!", null, null, null);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Null path of Grid file for sceneid ", sceneid.ToString(), null, null, null, null);
			}
		}

		protected virtual void InstallCamera()
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraActionComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraCollisonComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraShakeComponent.uuID);
			XSingleton<XScene>.singleton.GameCamera.Target = XSingleton<XEntityMgr>.singleton.Player;
		}

		public override void OnEnterScene(uint sceneid, bool transfer)
		{
			base.OnEnterScene(sceneid, transfer);
			XSingleton<XAttributeMgr>.singleton.ResetPlayerData();
			XSingleton<XLevelStatistics>.singleton.OnEnterScene(sceneid);
			this.InitTerrain(sceneid);
			this.InstallCamera();
			XSingleton<UIManager>.singleton.OnEnterScene();
			XSingleton<XGameUI>.singleton.LoadConcreteUI(this._eStage);
			XSingleton<XPostEffectMgr>.singleton.OnEnterScene(sceneid);
			XSingleton<XSceneMgr>.singleton.PlaceDynamicScene(sceneid);
			XSingleton<XLevelAIMgr>.singleton.InitAIData();
		}

		public override void OnLeaveScene(bool transfer)
		{
			XSingleton<XPostEffectMgr>.singleton.OnLeaveScene();
			XSingleton<XScene>.singleton.CurrentTerrain = null;
			XSingleton<XGame>.singleton.Doc.OnLeaveScene();
			XSingleton<X3DAvatarMgr>.singleton.Clean(transfer);
			base.OnLeaveScene(transfer);
		}
	}
}
