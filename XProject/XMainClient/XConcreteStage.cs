using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D9E RID: 3486
	internal abstract class XConcreteStage : XStage
	{
		// Token: 0x0600BD89 RID: 48521 RVA: 0x002762E1 File Offset: 0x002744E1
		public XConcreteStage(EXStage eStage) : base(eStage)
		{
		}

		// Token: 0x0600BD8A RID: 48522 RVA: 0x002762EC File Offset: 0x002744EC
		public override void OnEnterStage(EXStage eOld)
		{
			base.OnEnterStage(eOld);
		}

		// Token: 0x0600BD8B RID: 48523 RVA: 0x002762F8 File Offset: 0x002744F8
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

		// Token: 0x0600BD8C RID: 48524 RVA: 0x00276340 File Offset: 0x00274540
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

		// Token: 0x0600BD8D RID: 48525 RVA: 0x002763D4 File Offset: 0x002745D4
		protected virtual void InstallCamera()
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraActionComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraCollisonComponent.uuID);
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraShakeComponent.uuID);
			XSingleton<XScene>.singleton.GameCamera.Target = XSingleton<XEntityMgr>.singleton.Player;
		}

		// Token: 0x0600BD8E RID: 48526 RVA: 0x0027644C File Offset: 0x0027464C
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

		// Token: 0x0600BD8F RID: 48527 RVA: 0x002764C8 File Offset: 0x002746C8
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
