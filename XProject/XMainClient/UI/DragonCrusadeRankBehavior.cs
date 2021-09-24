using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class DragonCrusadeRankBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.mClosedBtn = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_scroll_view = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_EmptyHint = base.transform.Find("ScrollView/EmptyRank").gameObject;
		}

		public IXUIScrollView m_scroll_view;

		public IXUIButton mClosedBtn = null;

		public GameObject m_EmptyHint;
	}
}
