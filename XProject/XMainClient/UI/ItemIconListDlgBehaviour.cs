using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ItemIconListDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Title");
			this.m_Title = (transform.GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Close");
			this.m_Close = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg");
			this.m_Bg = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg/MinFrame");
			this.m_MinFrame = (transform.GetComponent("XUISprite") as IXUISprite);
			this.m_ItemPool.SetupPool(base.transform.FindChild("Bg/ListPanel").gameObject, base.transform.FindChild("Bg/ListPanel/ItemTpl").gameObject, 3U, false);
			this.m_BorderWidth = this.m_Bg.spriteWidth - this.m_MinFrame.spriteWidth;
			this.m_Arrow = base.transform.Find("Bg/Arrow");
			this.m_ArrowDown = base.transform.Find("Bg/ArrowDown");
			this.m_Split = (base.transform.Find("Bg/Split").GetComponent("XUISprite") as IXUISprite);
			this.m_SplitPos = base.transform.Find("Bg/Split/Sprite");
		}

		public IXUILabel m_Title = null;

		public IXUISprite m_Bg = null;

		public IXUISprite m_Close = null;

		public IXUISprite m_MinFrame = null;

		public Transform m_Arrow = null;

		public Transform m_ArrowDown = null;

		public IXUISprite m_Split = null;

		public Transform m_SplitPos = null;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public int m_BorderWidth;
	}
}
