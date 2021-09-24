using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class ItemUseListDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Title/Label");
			this.m_Title = (transform.GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Bg/Close");
			this.m_Close = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg");
			this.m_Bg = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg/ScrollView");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = base.transform.Find("Bg/ScrollView/WrapContent");
			this.m_WrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		public IXUILabel m_Title = null;

		public IXUISprite m_Bg = null;

		public IXUISprite m_Close = null;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;
	}
}
