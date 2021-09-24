using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	public class CreateChatGroupBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/p/T");
			this.m_Label = (transform.GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = base.transform.FindChild("Bg/ok");
			this.m_OKButton = (transform2.GetComponent("XUIButton") as IXUIButton);
			Transform transform3 = base.transform.FindChild("Bg/Close");
			this.m_sprClose = (transform3.GetComponent("XUISprite") as IXUISprite);
		}

		public IXUILabel m_Label = null;

		public IXUIButton m_OKButton = null;

		public IXUISprite m_sprClose = null;
	}
}
