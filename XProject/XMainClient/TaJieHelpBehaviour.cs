using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class TaJieHelpBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_parentGo = base.gameObject;
			this.m_closedBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_wrapContent = (base.transform.FindChild("Bg/detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public GameObject m_parentGo;

		public IXUIButton m_closedBtn;

		public IXUIWrapContent m_wrapContent;
	}
}
