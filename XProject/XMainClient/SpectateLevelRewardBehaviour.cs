using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SpectateLevelRewardBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_BackToMainCityBtn = (base.transform.Find("Bg/BackBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_GoOnBtn = (base.transform.Find("Bg/GoonBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_GoOnBtnText = (this.m_GoOnBtn.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.m_WatchNum = (base.transform.Find("Bg/WatchNum").GetComponent("XUILabel") as IXUILabel);
			this.m_CommendNum = (base.transform.Find("Bg/CommendNum").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("AllTpl/Title");
			this.m_TitlePool.SetupPool(transform.parent.gameObject, transform.gameObject, SpectateLevelRewardBehaviour.maxMessageNum, false);
			transform = base.transform.Find("AllTpl/Member");
			IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
			this.MemberHeight = ixuisprite.spriteHeight;
			this.MemberStartY = (int)(transform.localPosition.y + 0.5f);
			this.m_MemberPool.SetupPool(transform.parent.gameObject, transform.gameObject, SpectateLevelRewardBehaviour.maxPlayerNum, false);
			transform = base.transform.Find("Panel/View");
			this.MemberStartY -= (int)(transform.localPosition.y + 0.5f);
			transform = base.transform.Find("AllTpl/Detail");
			this.m_DetailPool.SetupPool(transform.parent.gameObject, transform.gameObject, SpectateLevelRewardBehaviour.maxPlayerNum, false);
			transform = base.transform.Find("AllTpl/Split");
			this.m_SplitPool.SetupPool(transform.parent.gameObject, transform.gameObject, SpectateLevelRewardBehaviour.maxPlayerNum * SpectateLevelRewardBehaviour.maxMessageNum, false);
			transform = base.transform.Find("AllTpl/Label");
			this.m_LabelPool.SetupPool(transform.parent.gameObject, transform.gameObject, SpectateLevelRewardBehaviour.maxPlayerNum * SpectateLevelRewardBehaviour.maxMessageNum, false);
			transform = base.transform.Find("AllTpl/Star");
			this.m_StarPool.SetupPool(transform.parent.gameObject, transform.gameObject, SpectateLevelRewardBehaviour.maxPlayerNum * 3U, false);
			transform = base.transform.Find("AllTpl/WinLose");
			this.m_WinLosePool.SetupPool(transform.parent.gameObject, transform.gameObject, SpectateLevelRewardBehaviour.maxPlayerNum, false);
			this.m_MVP = base.transform.Find("AllTpl/MVP").gameObject;
			this.m_TitleParent = base.transform.Find("Panel/Title");
			this.m_MemberParent = base.transform.Find("Panel/View");
		}

		private static uint maxPlayerNum = 4U;

		private static uint maxMessageNum = 8U;

		public int MemberHeight;

		public int MemberStartY;

		public IXUISprite m_BackToMainCityBtn;

		public IXUILabel m_WatchNum;

		public IXUISprite m_GoOnBtn;

		public IXUILabel m_GoOnBtnText;

		public IXUILabel m_CommendNum;

		public XUIPool m_TitlePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_MemberPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_DetailPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_SplitPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_LabelPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_WinLosePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_MVP;

		public Transform m_TitleParent;

		public Transform m_MemberParent;
	}
}
