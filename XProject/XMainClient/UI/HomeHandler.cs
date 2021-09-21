using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200178B RID: 6027
	internal class HomeHandler : DlgHandlerBase
	{
		// Token: 0x0600F8A5 RID: 63653 RVA: 0x0038E2AC File Offset: 0x0038C4AC
		protected override void Init()
		{
			this.m_exitHomeBtn = (base.PanelObject.transform.FindChild("ExitHome").GetComponent("XUIButton") as IXUIButton);
			this.m_plantingBtn = (base.PanelObject.transform.FindChild("Planting").GetComponent("XUIButton") as IXUIButton);
			this.m_fishingBtn = (base.PanelObject.transform.FindChild("Fishing").GetComponent("XUIButton") as IXUIButton);
			this.m_3dBtn = (base.PanelObject.transform.FindChild("3d2.5d/3d").GetComponent("XUIButton") as IXUIButton);
			this.m_25dBtn = (base.PanelObject.transform.FindChild("3d2.5d/2.5d").GetComponent("XUIButton") as IXUIButton);
			this.m_nameLab = (base.PanelObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_redDotGo = base.PanelObject.transform.FindChild("Planting/RedPoint").gameObject;
			List<float> floatList = XSingleton<XGlobalConfig>.singleton.GetFloatList("PlantPosition");
			bool flag = floatList.Count >= 3;
			if (flag)
			{
				this.m_plantPos = new Vector3(floatList[0], floatList[1], floatList[2]);
			}
			floatList = XSingleton<XGlobalConfig>.singleton.GetFloatList("FishingPosition");
			bool flag2 = floatList.Count >= 3;
			if (flag2)
			{
				this.m_fishingPos = new Vector3(floatList[0], floatList[1], floatList[2]);
			}
			base.Init();
		}

		// Token: 0x0600F8A6 RID: 63654 RVA: 0x0038E460 File Offset: 0x0038C660
		public override void RegisterEvent()
		{
			this.m_exitHomeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickExitHome));
			this.m_plantingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickPlanting));
			this.m_fishingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickFishing));
			this.m_SwitchSight = new XSwitchSight(new ButtonClickEventHandler(this.OnViewClick), this.m_25dBtn, this.m_3dBtn, null);
			base.RegisterEvent();
		}

		// Token: 0x1700383E RID: 14398
		// (get) Token: 0x0600F8A7 RID: 63655 RVA: 0x0038E4E4 File Offset: 0x0038C6E4
		protected override string FileName
		{
			get
			{
				return "Home/HomeHandler";
			}
		}

		// Token: 0x0600F8A8 RID: 63656 RVA: 0x0038E4FC File Offset: 0x0038C6FC
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPlantRedDot();
			this.m_nameLab.SetText(string.Format(XStringDefineProxy.GetString("HomeName"), HomePlantDocument.Doc.HomeOwnerName));
			bool flag = XSingleton<XOperationData>.singleton.OperationMode == XOperationMode.X3D_Free;
			if (flag)
			{
				XSingleton<XOperationData>.singleton.OperationMode = XOperationMode.X3D;
			}
			this.SetView(XSingleton<XOperationData>.singleton.OperationMode);
		}

		// Token: 0x0600F8A9 RID: 63657 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F8AA RID: 63658 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F8AB RID: 63659 RVA: 0x0038E56C File Offset: 0x0038C76C
		private bool OnClickExitHome(IXUIButton btn)
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			bool flag = sceneType != SceneType.SCENE_FAMILYGARDEN;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				HomeMainDocument.Doc.ReqLeaveHome();
				result = true;
			}
			return result;
		}

		// Token: 0x0600F8AC RID: 63660 RVA: 0x0038E5A8 File Offset: 0x0038C7A8
		private bool OnClickPlanting(IXUIButton btn)
		{
			this.GoTargetPoint(this.m_plantPos);
			return true;
		}

		// Token: 0x0600F8AD RID: 63661 RVA: 0x0038E5C8 File Offset: 0x0038C7C8
		private bool OnClickFishing(IXUIButton btn)
		{
			this.GoTargetPoint(this.m_fishingPos);
			return true;
		}

		// Token: 0x0600F8AE RID: 63662 RVA: 0x0038E5E8 File Offset: 0x0038C7E8
		private void GoTargetPoint(Vector3 v3)
		{
			XSingleton<XInput>.singleton.LastNpc = null;
			XNavigationEventArgs @event = XEventPool<XNavigationEventArgs>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			@event.Dest = v3;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600F8AF RID: 63663 RVA: 0x0038E62C File Offset: 0x0038C82C
		private bool OnViewClick(IXUIButton btn)
		{
			this.SetView((XOperationMode)btn.ID);
			return true;
		}

		// Token: 0x0600F8B0 RID: 63664 RVA: 0x0038E650 File Offset: 0x0038C850
		public void SetView(XOperationMode mode)
		{
			if (mode != XOperationMode.X25D)
			{
				if (mode == XOperationMode.X3D)
				{
					this.m_3dBtn.gameObject.SetActive(true);
					this.m_25dBtn.gameObject.SetActive(false);
				}
			}
			else
			{
				this.m_3dBtn.gameObject.SetActive(false);
				this.m_25dBtn.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600F8B1 RID: 63665 RVA: 0x0038E6BC File Offset: 0x0038C8BC
		public void EnableBackToMainCity(bool allow)
		{
			base.transform.gameObject.SetActive(allow);
		}

		// Token: 0x0600F8B2 RID: 63666 RVA: 0x0038E6D4 File Offset: 0x0038C8D4
		public void RefreshPlantRedDot()
		{
			bool flag = this.m_redDotGo != null;
			if (flag)
			{
				this.m_redDotGo.SetActive(HomePlantDocument.Doc.HadRedDot);
			}
		}

		// Token: 0x04006C7F RID: 27775
		private GameObject m_redDotGo;

		// Token: 0x04006C80 RID: 27776
		private IXUIButton m_exitHomeBtn;

		// Token: 0x04006C81 RID: 27777
		private IXUIButton m_plantingBtn;

		// Token: 0x04006C82 RID: 27778
		private IXUIButton m_fishingBtn;

		// Token: 0x04006C83 RID: 27779
		private IXUIButton m_3dBtn;

		// Token: 0x04006C84 RID: 27780
		private IXUIButton m_25dBtn;

		// Token: 0x04006C85 RID: 27781
		private IXUILabel m_nameLab;

		// Token: 0x04006C86 RID: 27782
		private Vector3 m_plantPos = Vector3.zero;

		// Token: 0x04006C87 RID: 27783
		private Vector3 m_fishingPos = Vector3.zero;

		// Token: 0x04006C88 RID: 27784
		private XSwitchSight m_SwitchSight;
	}
}
