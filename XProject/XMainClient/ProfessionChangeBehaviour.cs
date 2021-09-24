using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ProfessionChangeBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/Tabs/Tpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.transform.Find("Bg/Right/Star/Tpl");
			this.m_StarPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.transform.Find("Bg/Right");
			this.m_ProfName = (transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_ProfIcon = (transform.Find("Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_Texture = (transform.Find("Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_Desc = (transform.Find("Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_TryProfBtn = (transform.Find("TryProfBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_ChangeProfBtn = (transform.Find("ChangeProfBtn").GetComponent("XUIButton") as IXUIButton);
			transform = base.transform.Find("Bg/TipsWindow");
			this.m_TipsWindow = transform.gameObject;
			this.m_TipsClose = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_TipsType = (transform.Find("TypeTips").GetComponent("XUILabel") as IXUILabel);
			this.m_TipsDesc = (transform.Find("Text/Desc/T").GetComponent("XUILabel") as IXUILabel);
			this.m_TextScrollView = (transform.Find("Text/Desc").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_TipsUse = (transform.Find("Use/T").GetComponent("XUILabel") as IXUILabel);
			this.m_GetPathBtn = (transform.Find("GetPath").GetComponent("XUISprite") as IXUISprite);
			this.m_OKBtn = (transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_Close;

		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_ProfName;

		public IXUISprite m_ProfIcon;

		public IXUITexture m_Texture;

		public IXUILabel m_Desc;

		public IXUIButton m_TryProfBtn;

		public IXUIButton m_ChangeProfBtn;

		public GameObject m_TipsWindow;

		public IXUIButton m_TipsClose;

		public IXUILabel m_TipsType;

		public IXUILabel m_TipsDesc;

		public IXUIScrollView m_TextScrollView;

		public IXUILabel m_TipsUse;

		public IXUISprite m_GetPathBtn;

		public IXUIButton m_OKBtn;
	}
}
