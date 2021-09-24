using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class YorozuyaHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_photoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickYorozuyPhotoBtn));
			this.m_rideBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickYorozuyRideBtn));
			this.m_sceneTransformBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenTransUi));
			this.m_exitBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickExit));
			this.m_SwitchSight = new XSwitchSight(new ButtonClickEventHandler(this.OnViewClick), this.m_25dBtn, this.m_3dBtn, null);
		}

		protected override string FileName
		{
			get
			{
				return "Hall/YorozuyaHandler";
			}
		}

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

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
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

		private bool OnClickYorozuyPhotoBtn(IXUIButton btn)
		{
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.ShowMainView();
			return true;
		}

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

		private bool OpenTransUi(IXUIButton btn)
		{
			DlgBase<YorozuyaDlg, YorozuyaBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		private bool OnViewClick(IXUIButton btn)
		{
			this.SetView((XOperationMode)btn.ID);
			return true;
		}

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

		private IXUIButton m_photoBtn;

		private IXUIButton m_rideBtn;

		private IXUIButton m_sceneTransformBtn;

		private IXUIButton m_exitBtn;

		private IXUIButton m_3dBtn;

		private IXUIButton m_25dBtn;

		private XSwitchSight m_SwitchSight;
	}
}
