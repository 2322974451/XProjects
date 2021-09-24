using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XFlowerReplyBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_SpeakPanel = base.transform.FindChild("Bg/SpeakPanel");
			this.m_SenderName = (base.transform.FindChild("Bg/SenderName").GetComponent("XUILabel") as IXUILabel);
			this.m_SenderCount = (base.transform.FindChild("Bg/SendCount").GetComponent("XUILabel") as IXUILabel);
			this.m_FlowerName = (base.transform.FindChild("Bg/FlowerName").GetComponent("XUILabel") as IXUILabel);
			this.m_QuickThx = (base.transform.FindChild("Bg/BtnTHx").GetComponent("XUIButton") as IXUIButton);
			this.m_Voice = (base.transform.FindChild("Bg/speak").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("InputBlocker").GetComponent("XUISprite") as IXUISprite);
			this.m_ThxContent = (base.transform.FindChild("Bg/ThxContent").GetComponent("XUILabel") as IXUILabel);
			GameObject gameObject = base.transform.FindChild("Bg/Bg2").gameObject;
			GameObject gameObject2 = base.transform.FindChild("Bg/Bg2_Advance").gameObject;
			GameObject gameObject3 = base.transform.FindChild("Bg/Bg2_Elite").gameObject;
			this.m_ReplayBgList.Add(gameObject);
			this.m_ReplayBgList.Add(gameObject2);
			this.m_ReplayBgList.Add(gameObject3);
		}

		public IXUILabel m_SenderName = null;

		public IXUILabel m_SenderCount = null;

		public IXUILabel m_FlowerName = null;

		public IXUILabel m_ThxContent = null;

		public IXUISprite m_Close = null;

		public IXUIButton m_Voice = null;

		public IXUIButton m_QuickThx = null;

		public Transform m_SpeakPanel = null;

		public List<GameObject> m_ReplayBgList = new List<GameObject>();
	}
}
