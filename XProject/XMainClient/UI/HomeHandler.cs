using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HomeHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			this.m_exitHomeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickExitHome));
			this.m_plantingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickPlanting));
			this.m_fishingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickFishing));
			this.m_SwitchSight = new XSwitchSight(new ButtonClickEventHandler(this.OnViewClick), this.m_25dBtn, this.m_3dBtn, null);
			base.RegisterEvent();
		}

		protected override string FileName
		{
			get
			{
				return "Home/HomeHandler";
			}
		}

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

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

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

		private bool OnClickPlanting(IXUIButton btn)
		{
			this.GoTargetPoint(this.m_plantPos);
			return true;
		}

		private bool OnClickFishing(IXUIButton btn)
		{
			this.GoTargetPoint(this.m_fishingPos);
			return true;
		}

		private void GoTargetPoint(Vector3 v3)
		{
			XSingleton<XInput>.singleton.LastNpc = null;
			XNavigationEventArgs @event = XEventPool<XNavigationEventArgs>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			@event.Dest = v3;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		private bool OnViewClick(IXUIButton btn)
		{
			this.SetView((XOperationMode)btn.ID);
			return true;
		}

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

		public void EnableBackToMainCity(bool allow)
		{
			base.transform.gameObject.SetActive(allow);
		}

		public void RefreshPlantRedDot()
		{
			bool flag = this.m_redDotGo != null;
			if (flag)
			{
				this.m_redDotGo.SetActive(HomePlantDocument.Doc.HadRedDot);
			}
		}

		private GameObject m_redDotGo;

		private IXUIButton m_exitHomeBtn;

		private IXUIButton m_plantingBtn;

		private IXUIButton m_fishingBtn;

		private IXUIButton m_3dBtn;

		private IXUIButton m_25dBtn;

		private IXUILabel m_nameLab;

		private Vector3 m_plantPos = Vector3.zero;

		private Vector3 m_fishingPos = Vector3.zero;

		private XSwitchSight m_SwitchSight;
	}
}
