using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SpectateBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BroadcastCamera = (base.transform.Find("Bg/camera").GetComponent("XUIButton") as IXUIButton);
			this.m_SpectateFrame = base.transform.Find("Bg/SpectateFrame").gameObject;
			this.m_MyLiveRecordFrame = base.transform.Find("Bg/MyLiveRecordFrame").gameObject;
			Transform transform = base.transform.FindChild("Bg/Tabs/TabTpl");
			this.m_tabControl.SetTabTpl(transform);
			transform = this.m_SpectateFrame.transform.Find("Tabs/tabTpl");
			this.m_SpectateTabs.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			transform = this.m_SpectateFrame.transform.Find("Right/View/itemTpl");
			this.m_SpectateLivePool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_RefreshBtn = (this.m_SpectateFrame.transform.Find("Right/Refresh").GetComponent("XUIButton") as IXUIButton);
			this.m_PreviousBtn = (this.m_SpectateFrame.transform.Find("Right/Previous").GetComponent("XUISprite") as IXUISprite);
			this.m_NextBtn = (this.m_SpectateFrame.transform.Find("Right/Next").GetComponent("XUISprite") as IXUISprite);
			this.m_PageNum = (this.m_SpectateFrame.transform.Find("Right/Page").GetComponent("XUILabel") as IXUILabel);
			this.m_EmptyTips = this.m_SpectateFrame.transform.Find("Right/Empty").gameObject;
			this.m_PKTips = (this.m_SpectateFrame.transform.Find("Right/PKTips").GetComponent("XUILabel") as IXUILabel);
			this.m_MyLiveUpView = this.m_MyLiveRecordFrame.transform.Find("UpView").gameObject;
			this.m_MyLiveDownView = this.m_MyLiveRecordFrame.transform.Find("DownView").gameObject;
			transform = this.m_MyLiveRecordFrame.transform.Find("DownView/itemTpl");
			this.m_MyLivePool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_SettingBtn = (base.transform.Find("Bg/BtnSetting").GetComponent("XUIButton") as IXUIButton);
			this.m_SettingCloseBtn = (base.transform.Find("Bg/Setting/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_VisText = base.transform.Find("Bg/BtnSetting/StatusAllow").gameObject;
			this.m_UnVisText = base.transform.Find("Bg/BtnSetting/StatusDeny").gameObject;
			this.m_SettingFrame = base.transform.Find("Bg/Setting").gameObject;
			this.m_SettingDesc = (base.transform.Find("Bg/Setting/Describe").GetComponent("XUILabel") as IXUILabel);
			this.m_SettingAllow = (base.transform.Find("Bg/Setting/BtnAllow").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_SettingDeny = (base.transform.Find("Bg/Setting/BtnDeny").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_SettingSureBtn = (base.transform.Find("Bg/Setting/Ok").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Close;

		public IXUIButton m_RefreshBtn;

		public IXUISprite m_PreviousBtn;

		public IXUIButton m_BroadcastCamera;

		public IXUISprite m_NextBtn;

		public IXUILabel m_PageNum;

		public GameObject m_EmptyTips;

		public IXUILabel m_PKTips;

		public GameObject m_MyLiveUpView;

		public GameObject m_MyLiveDownView;

		public XUIPool m_SpectateLivePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_MyLivePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_SpectateTabs = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUITabControl m_tabControl = new XUITabControl();

		public GameObject m_SpectateFrame;

		public GameObject m_MyLiveRecordFrame;

		public GameObject m_VisText;

		public GameObject m_UnVisText;

		public GameObject m_SettingFrame;

		public IXUIButton m_SettingBtn;

		public IXUIButton m_SettingCloseBtn;

		public IXUILabel m_SettingDesc;

		public IXUICheckBox m_SettingAllow;

		public IXUICheckBox m_SettingDeny;

		public IXUIButton m_SettingSureBtn;
	}
}
