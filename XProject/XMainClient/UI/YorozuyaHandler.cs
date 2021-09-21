using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001791 RID: 6033
	internal class YorozuyaHandler : DlgHandlerBase
	{
		// Token: 0x0600F90D RID: 63757 RVA: 0x003916C8 File Offset: 0x0038F8C8
		protected override void Init()
		{
			base.Init();
			this.m_photoBtn = (base.PanelObject.transform.Find("Photo").GetComponent("XUIButton") as IXUIButton);
			this.m_rideBtn = (base.PanelObject.transform.Find("Ride").GetComponent("XUIButton") as IXUIButton);
			this.m_sceneTransformBtn = (base.PanelObject.transform.Find("SceneTransform").GetComponent("XUIButton") as IXUIButton);
			this.m_exitBtn = (base.PanelObject.transform.Find("Exit").GetComponent("XUIButton") as IXUIButton);
			this.m_3dBtn = (base.PanelObject.transform.FindChild("3d2.5d/3d").GetComponent("XUIButton") as IXUIButton);
			this.m_25dBtn = (base.PanelObject.transform.FindChild("3d2.5d/2.5d").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0600F90E RID: 63758 RVA: 0x003917DC File Offset: 0x0038F9DC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_photoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickYorozuyPhotoBtn));
			this.m_rideBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickYorozuyRideBtn));
			this.m_sceneTransformBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenTransUi));
			this.m_exitBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickExit));
			this.m_SwitchSight = new XSwitchSight(new ButtonClickEventHandler(this.OnViewClick), this.m_25dBtn, this.m_3dBtn, null);
		}

		// Token: 0x17003846 RID: 14406
		// (get) Token: 0x0600F90F RID: 63759 RVA: 0x00391878 File Offset: 0x0038FA78
		protected override string FileName
		{
			get
			{
				return "Hall/YorozuyaHandler";
			}
		}

		// Token: 0x0600F910 RID: 63760 RVA: 0x00391890 File Offset: 0x0038FA90
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = XSingleton<XOperationData>.singleton.OperationMode == XOperationMode.X3D_Free;
			if (flag)
			{
				XSingleton<XOperationData>.singleton.OperationMode = XOperationMode.X3D;
			}
			this.SetView(XSingleton<XOperationData>.singleton.OperationMode);
		}

		// Token: 0x0600F911 RID: 63761 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F912 RID: 63762 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F913 RID: 63763 RVA: 0x003918D4 File Offset: 0x0038FAD4
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

		// Token: 0x0600F914 RID: 63764 RVA: 0x00391940 File Offset: 0x0038FB40
		private bool OnClickYorozuyPhotoBtn(IXUIButton btn)
		{
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.ShowMainView();
			return true;
		}

		// Token: 0x0600F915 RID: 63765 RVA: 0x0039196C File Offset: 0x0038FB6C
		private bool OnClickYorozuyRideBtn(IXUIButton btn)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.state.type == OutLookStateType.OutLook_RidePetCopilot;
			if (flag)
			{
				specificDocument.OnReqOffPetPairRide();
			}
			else
			{
				bool flag2 = specificDocument.Pets.Count == 0;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PET_NONE"), "fece00");
				}
				else
				{
					specificDocument.ReqRecentMount();
				}
			}
			return true;
		}

		// Token: 0x0600F916 RID: 63766 RVA: 0x003919EC File Offset: 0x0038FBEC
		private bool OpenTransUi(IXUIButton btn)
		{
			DlgBase<YorozuyaDlg, YorozuyaBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x0600F917 RID: 63767 RVA: 0x00391A0C File Offset: 0x0038FC0C
		private bool OnViewClick(IXUIButton btn)
		{
			this.SetView((XOperationMode)btn.ID);
			return true;
		}

		// Token: 0x0600F918 RID: 63768 RVA: 0x00391A30 File Offset: 0x0038FC30
		private bool OnClickExit(IXUIButton btn)
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			bool flag = sceneType != SceneType.SCENE_LEISURE;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<XScene>.singleton.ReqLeaveScene();
				result = true;
			}
			return result;
		}

		// Token: 0x04006CC8 RID: 27848
		private IXUIButton m_photoBtn;

		// Token: 0x04006CC9 RID: 27849
		private IXUIButton m_rideBtn;

		// Token: 0x04006CCA RID: 27850
		private IXUIButton m_sceneTransformBtn;

		// Token: 0x04006CCB RID: 27851
		private IXUIButton m_exitBtn;

		// Token: 0x04006CCC RID: 27852
		private IXUIButton m_3dBtn;

		// Token: 0x04006CCD RID: 27853
		private IXUIButton m_25dBtn;

		// Token: 0x04006CCE RID: 27854
		private XSwitchSight m_SwitchSight;
	}
}
