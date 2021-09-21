using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001758 RID: 5976
	internal class ExchangeItemBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F6D9 RID: 63193 RVA: 0x00380F54 File Offset: 0x0037F154
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

		// Token: 0x04006B44 RID: 27460
		public IXUIButton m_Close;

		// Token: 0x04006B45 RID: 27461
		public IXUILabel m_Title;

		// Token: 0x04006B46 RID: 27462
		public XUIPool m_MyItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006B47 RID: 27463
		public IXUIScrollView m_ItemScrollView;

		// Token: 0x04006B48 RID: 27464
		public GameObject m_MySelect;

		// Token: 0x04006B49 RID: 27465
		public GameObject m_MyItemGo;

		// Token: 0x04006B4A RID: 27466
		public IXUILabel m_MyItemName;

		// Token: 0x04006B4B RID: 27467
		public GameObject m_OtherSelect;

		// Token: 0x04006B4C RID: 27468
		public GameObject m_OtherItemGo;

		// Token: 0x04006B4D RID: 27469
		public IXUILabel m_OtherItemName;

		// Token: 0x04006B4E RID: 27470
		public IXUILabel m_Tips;

		// Token: 0x04006B4F RID: 27471
		public IXUILabel m_MyEnsureText;

		// Token: 0x04006B50 RID: 27472
		public IXUILabel m_OtherEnsureText;

		// Token: 0x04006B51 RID: 27473
		public IXUIButton m_EnsureBtn;

		// Token: 0x04006B52 RID: 27474
		public IXUIButton m_Input;

		// Token: 0x04006B53 RID: 27475
		public IXUIButton m_SpeakBtn;

		// Token: 0x04006B54 RID: 27476
		public IXUISprite m_MyVoiceBtn;

		// Token: 0x04006B55 RID: 27477
		public IXUISprite m_OtherVoiceBtn;

		// Token: 0x04006B56 RID: 27478
		public GameObject m_MyInputGo;

		// Token: 0x04006B57 RID: 27479
		public GameObject m_OtherInputGo;

		// Token: 0x04006B58 RID: 27480
		public IXUILabel m_MyInputText;

		// Token: 0x04006B59 RID: 27481
		public IXUILabel m_OtherInputText;

		// Token: 0x04006B5A RID: 27482
		public IXUILabel m_MyVoiceText;

		// Token: 0x04006B5B RID: 27483
		public IXUILabel m_OtherVoiceText;

		// Token: 0x04006B5C RID: 27484
		public IXUISpriteAnimation m_MyVoiceAni;

		// Token: 0x04006B5D RID: 27485
		public IXUISpriteAnimation m_OtherVoiceAni;
	}
}
