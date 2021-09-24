using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XQuickReplyBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_SpeakPanel = base.transform.FindChild("Bg/SpeakPanel");
			this.m_Title = (base.transform.FindChild("Bg/Title/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_Voice = (base.transform.FindChild("Bg/BtnVoice").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_WrapScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapTemp = base.transform.FindChild("Bg/ScrollView/WrapContent/Content");
			this.m_ItemPool.SetupPool(this.m_WrapTemp.parent.gameObject, this.m_WrapTemp.gameObject, 2U, false);
		}

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_WrapScrollView = null;

		public IXUIWrapContent m_WrapContent = null;

		public IXUISprite m_Close = null;

		public IXUILabel m_Title = null;

		public IXUIButton m_Voice = null;

		public Transform m_WrapTemp = null;

		public Transform m_SpeakPanel = null;
	}
}
