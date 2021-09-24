using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ChatAssistBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_btnEmotion = (base.transform.Find("Tabs/SmallTab_emo").GetComponent("XUIButton") as IXUIButton);
			this.m_btnHistory = (base.transform.Find("Tabs/SmallTab_his").GetComponent("XUIButton") as IXUIButton);
			this.m_objEmotionTpl = base.transform.Find("ChatEmotion/template").gameObject;
			this.m_sprBg = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_loophistoryView = (base.transform.FindChild("ChatHistory/loopscroll").GetComponent("LoopScrollView") as ILoopScrollView);
			this.m_objEmotion = base.transform.Find("ChatEmotion").gameObject;
			this.m_objHistory = base.transform.Find("ChatHistory").gameObject;
			this.m_ChatEmotionPool.SetupPool(this.m_objEmotion, this.m_objEmotionTpl, 24U, false);
		}

		public IXUIButton m_btnEmotion;

		public IXUIButton m_btnHistory;

		public GameObject m_objEmotionTpl;

		public XUIPool m_ChatEmotionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUISprite m_sprBg;

		public ILoopScrollView m_loophistoryView;

		public GameObject m_objEmotion;

		public GameObject m_objHistory;
	}
}
