using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ExchangeItemBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.transform.Find("Bg/Title/content").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Self/List/ItemTpl");
			this.m_MyItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 16U, false);
			this.m_ItemScrollView = (base.transform.Find("Bg/Self/List").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_MySelect = base.transform.Find("Bg/Self/MyItem/Item").gameObject;
			this.m_MyItemGo = base.transform.Find("Bg/Self/MyItem").gameObject;
			this.m_MyItemName = (base.transform.Find("Bg/Self/MyItem/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_OtherSelect = base.transform.Find("Bg/Other/OtherItem/Item").gameObject;
			this.m_OtherItemGo = base.transform.Find("Bg/Other/OtherItem").gameObject;
			this.m_OtherItemName = (base.transform.Find("Bg/Other/OtherItem/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Tips = (base.transform.Find("Bg/Self/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_MyEnsureText = (base.transform.Find("Bg/Self/OK/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_OtherEnsureText = (base.transform.Find("Bg/Other/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_EnsureBtn = (base.transform.Find("Bg/Self/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_Input = (base.transform.Find("Bg/Input").GetComponent("XUIButton") as IXUIButton);
			this.m_SpeakBtn = (base.transform.Find("Bg/Speak").GetComponent("XUIButton") as IXUIButton);
			this.m_MyVoiceBtn = (base.transform.Find("Bg/Self/chatvoice").GetComponent("XUISprite") as IXUISprite);
			this.m_MyInputGo = base.transform.Find("Bg/Self/chattext").gameObject;
			this.m_MyInputText = (base.transform.Find("Bg/Self/chattext/text/content").GetComponent("XUILabel") as IXUILabel);
			this.m_MyVoiceText = (base.transform.Find("Bg/Self/chatvoice/voice/content").GetComponent("XUILabel") as IXUILabel);
			this.m_MyVoiceAni = (base.transform.Find("Bg/Self/chatvoice/voice/sign").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation);
			this.m_OtherVoiceBtn = (base.transform.Find("Bg/Other/chatvoice").GetComponent("XUISprite") as IXUISprite);
			this.m_OtherInputGo = base.transform.Find("Bg/Other/chattext").gameObject;
			this.m_OtherInputText = (base.transform.Find("Bg/Other/chattext/text/content").GetComponent("XUILabel") as IXUILabel);
			this.m_OtherVoiceText = (base.transform.Find("Bg/Other/chatvoice/voice/content").GetComponent("XUILabel") as IXUILabel);
			this.m_OtherVoiceAni = (base.transform.Find("Bg/Other/chatvoice/voice/sign").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation);
		}

		public IXUIButton m_Close;

		public IXUILabel m_Title;

		public XUIPool m_MyItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_ItemScrollView;

		public GameObject m_MySelect;

		public GameObject m_MyItemGo;

		public IXUILabel m_MyItemName;

		public GameObject m_OtherSelect;

		public GameObject m_OtherItemGo;

		public IXUILabel m_OtherItemName;

		public IXUILabel m_Tips;

		public IXUILabel m_MyEnsureText;

		public IXUILabel m_OtherEnsureText;

		public IXUIButton m_EnsureBtn;

		public IXUIButton m_Input;

		public IXUIButton m_SpeakBtn;

		public IXUISprite m_MyVoiceBtn;

		public IXUISprite m_OtherVoiceBtn;

		public GameObject m_MyInputGo;

		public GameObject m_OtherInputGo;

		public IXUILabel m_MyInputText;

		public IXUILabel m_OtherInputText;

		public IXUILabel m_MyVoiceText;

		public IXUILabel m_OtherVoiceText;

		public IXUISpriteAnimation m_MyVoiceAni;

		public IXUISpriteAnimation m_OtherVoiceAni;
	}
}
