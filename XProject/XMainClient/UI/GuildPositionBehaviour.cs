using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildPositionBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Memu/template");
			this.m_MenuPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, true);
			this.m_backSprite = (base.transform.FindChild("Memu/back").GetComponent("XUISprite") as IXUISprite);
			this.m_memuSprite = (base.transform.FindChild("Memu").GetComponent("XUISprite") as IXUISprite);
		}

		public XUIPool m_MenuPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUISprite m_backSprite;

		public IXUISprite m_memuSprite;
	}
}
