using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class HomePlantBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_closedSpr = (base.transform.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_handlerTra = base.transform.FindChild("Bg/SeedHandler");
		}

		public IXUISprite m_closedSpr;

		public Transform m_handlerTra;
	}
}
