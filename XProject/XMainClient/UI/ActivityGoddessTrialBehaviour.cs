using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ActivityGoddessTrialBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg");
			this.m_closedBtn = (transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_goBattleBtn = (transform.FindChild("GoBattle").GetComponent("XUIButton") as IXUIButton);
			this.m_getBtn = (transform.FindChild("GetRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_shopBtn = (transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_canJoinTimeslab = (transform.FindChild("times").GetComponent("XUILabel") as IXUILabel);
			this.m_NeedTimesLab = (transform.FindChild("Reward/NeedTimes").GetComponent("XUILabel") as IXUILabel);
			this.m_noTimesGo = transform.FindChild("NoJoinTimesTips").gameObject;
			this.m_hadGetGo = transform.FindChild("HadGet").gameObject;
			transform = transform.FindChild("Reward/Item");
			this.m_ItemPool.SetupPool(transform.gameObject, transform.FindChild("Item").gameObject, 2U, true);
			this.m_canJoinTimeslab.SetText("");
			this.m_NeedTimesLab.SetText("");
		}

		public IXUILabel m_canJoinTimeslab;

		public IXUILabel m_NeedTimesLab;

		public IXUIButton m_goBattleBtn;

		public IXUIButton m_closedBtn;

		public IXUIButton m_getBtn;

		public IXUIButton m_shopBtn;

		public IXUIButton m_Help;

		public GameObject m_noTimesGo;

		public GameObject m_hadGetGo;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
