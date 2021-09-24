using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class TitleDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Promote = (base.transform.FindChild("Bg/Promote").GetComponent("XUIButton") as IXUIButton);
			this.m_redPoint = (base.transform.FindChild("Bg/Promote/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_ScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ItemTpl = base.transform.FindChild("Bg/ScrollView/ItemTpl").gameObject;
			this.m_point = base.transform.FindChild("Bg/Point").gameObject;
			this.m_ItemTpl.gameObject.SetActive(false);
			this.m_MaxTitle = base.transform.FindChild("Bg/MaxTitle").gameObject;
			this.m_CurrentTitle.Init(base.transform.FindChild("Bg/Current"));
			this.m_NextTitle.Init(base.transform.FindChild("Bg/Next"));
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIButton m_Promote;

		public IXUIScrollView m_ScrollView;

		public GameObject m_ItemTpl;

		public GameObject m_point;

		public GameObject m_MaxTitle;

		public IXUISprite m_redPoint;

		public TitleDisplay m_CurrentTitle = new TitleDisplay();

		public TitleDisplay m_NextTitle = new TitleDisplay();
	}
}
