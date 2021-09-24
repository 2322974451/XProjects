using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ChatEmotionBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_sprEmotion = (base.transform.Find("Emotion").GetComponent("XUISprite") as IXUISprite);
			this.m_sprP = (base.transform.Find("P").GetComponent("XUISprite") as IXUISprite);
			this.m_objEmotionTpl = base.transform.Find("Emotion/template").gameObject;
			this.m_ChatEmotionPool.SetupPool(this.m_sprEmotion.gameObject, this.m_objEmotionTpl, 24U, false);
		}

		public IXUISprite m_sprEmotion;

		public IXUISprite m_sprP;

		public GameObject m_objEmotionTpl;

		public XUIPool m_ChatEmotionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
