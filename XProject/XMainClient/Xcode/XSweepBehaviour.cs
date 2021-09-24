using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSweepBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_dragBox = base.transform.FindChild("Bg/DragBox").GetComponent<BoxCollider>();
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Exp = (base.transform.FindChild("Bg/ExpBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_ExpText = (base.transform.FindChild("Bg/ExpBar/ExpLabel").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/RewardDisplay/RewardTpl/Parent/ItemTpl");
			this.m_DropPool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 8U, false);
			transform = base.transform.FindChild("Bg/RewardDisplay/RewardTpl");
			this.m_RewardPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_ScrollView = (base.transform.FindChild("Bg/RewardDisplay").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_SweepTip = (base.transform.FindChild("Bg/RewardDisplay/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_SealTip = base.transform.Find("Bg/SealTip");
		}

		public IXUIButton m_Close = null;

		public IXUIProgress m_Exp = null;

		public IXUILabel m_ExpText = null;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_ScrollView = null;

		public XUIPool m_DropPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_SweepTip;

		public Transform m_SealTip;

		public BoxCollider m_dragBox;
	}
}
