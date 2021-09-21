using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D08 RID: 3336
	internal class SpectateBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600BA76 RID: 47734 RVA: 0x00260BE8 File Offset: 0x0025EDE8
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

		// Token: 0x04004AB2 RID: 19122
		public IXUIButton m_Close;

		// Token: 0x04004AB3 RID: 19123
		public IXUIButton m_RefreshBtn;

		// Token: 0x04004AB4 RID: 19124
		public IXUISprite m_PreviousBtn;

		// Token: 0x04004AB5 RID: 19125
		public IXUIButton m_BroadcastCamera;

		// Token: 0x04004AB6 RID: 19126
		public IXUISprite m_NextBtn;

		// Token: 0x04004AB7 RID: 19127
		public IXUILabel m_PageNum;

		// Token: 0x04004AB8 RID: 19128
		public GameObject m_EmptyTips;

		// Token: 0x04004AB9 RID: 19129
		public IXUILabel m_PKTips;

		// Token: 0x04004ABA RID: 19130
		public GameObject m_MyLiveUpView;

		// Token: 0x04004ABB RID: 19131
		public GameObject m_MyLiveDownView;

		// Token: 0x04004ABC RID: 19132
		public XUIPool m_SpectateLivePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004ABD RID: 19133
		public XUIPool m_MyLivePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004ABE RID: 19134
		public XUIPool m_SpectateTabs = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004ABF RID: 19135
		public XUITabControl m_tabControl = new XUITabControl();

		// Token: 0x04004AC0 RID: 19136
		public GameObject m_SpectateFrame;

		// Token: 0x04004AC1 RID: 19137
		public GameObject m_MyLiveRecordFrame;

		// Token: 0x04004AC2 RID: 19138
		public GameObject m_VisText;

		// Token: 0x04004AC3 RID: 19139
		public GameObject m_UnVisText;

		// Token: 0x04004AC4 RID: 19140
		public GameObject m_SettingFrame;

		// Token: 0x04004AC5 RID: 19141
		public IXUIButton m_SettingBtn;

		// Token: 0x04004AC6 RID: 19142
		public IXUIButton m_SettingCloseBtn;

		// Token: 0x04004AC7 RID: 19143
		public IXUILabel m_SettingDesc;

		// Token: 0x04004AC8 RID: 19144
		public IXUICheckBox m_SettingAllow;

		// Token: 0x04004AC9 RID: 19145
		public IXUICheckBox m_SettingDeny;

		// Token: 0x04004ACA RID: 19146
		public IXUIButton m_SettingSureBtn;
	}
}
