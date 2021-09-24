using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EndlessAbyssBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg");
			this.m_closedBtn = (transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_goBattleBtn = (transform.FindChild("GoBattle").GetComponent("XUIButton") as IXUIButton);
			this.m_shopBtn = (transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_noTimesGo = transform.FindChild("NoJoinTimesTips").gameObject;
			Transform transform2 = transform.FindChild("Reward/Item/ItemTpl");
			this.m_ItemPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 3U, false);
			this.m_canJoinTimeslab = (transform.FindChild("times").GetComponent("XUILabel") as IXUILabel);
			this.m_canJoinTimeslab.SetText("");
		}

		public IXUIButton m_closedBtn;

		public IXUIButton m_Help;

		public IXUIButton m_shopBtn;

		public IXUIButton m_goBattleBtn;

		public GameObject m_noTimesGo;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_canJoinTimeslab;
	}
}
