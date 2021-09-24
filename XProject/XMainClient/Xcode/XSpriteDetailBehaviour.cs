using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XSpriteDetailBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_AvatarRoot = base.transform.Find("Bg/AvatarRoot");
			this.m_AttrFrameRoot = base.transform.Find("Bg/AttrFrameRoot");
		}

		public IXUIButton m_Close;

		public Transform m_AvatarRoot;

		public Transform m_AttrFrameRoot;
	}
}
