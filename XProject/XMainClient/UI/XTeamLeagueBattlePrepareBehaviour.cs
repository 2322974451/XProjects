using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamLeagueBattlePrepareBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_UpBtn = (base.transform.Find("Bg/UpDown/LetmedieUp").GetComponent("XUISprite") as IXUISprite);
			this.m_DownBtn = (base.transform.Find("Bg/UpDown/LetmedieDown").GetComponent("XUISprite") as IXUISprite);
			this.m_ListView = base.transform.Find("Bg").gameObject;
			this.m_BlueView = base.transform.Find("Bg/LeftView");
			this.m_RedView = base.transform.Find("Bg/RightView");
			this.m_MemberList[0] = (base.transform.Find("Bg/LeftView/MemberScrollView/List").GetComponent("XUIList") as IXUIList);
			this.m_MemberList[1] = (base.transform.Find("Bg/RightView/MemberScrollView/List").GetComponent("XUIList") as IXUIList);
			Transform transform = base.transform.Find("Bg/LeftView/MemberScrollView/List/MemberTpl");
			Transform transform2 = base.transform.Find("Bg/RightView/MemberScrollView/List/MemberTpl");
			this.m_MemberPool[0] = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_MemberPool[0].SetupPool(this.m_MemberList[0].gameObject, transform.gameObject, 4U, false);
			this.m_MemberPool[1] = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			this.m_MemberPool[1].SetupPool(this.m_MemberList[1].gameObject, transform2.gameObject, 4U, false);
			this.m_Info = base.transform.Find("Info").gameObject;
			this.m_BlueInfo = base.transform.Find("Info/Blue");
			this.m_RedInfo = base.transform.Find("Info/Red");
			this.m_LeftTimeTip = (base.transform.Find("LeftTimeTip").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeCount = (base.transform.Find("countdown").GetComponent("XUILabel") as IXUILabel);
			this.m_TimeCount.SetVisible(false);
			this.m_BlueViewSwitch = (base.transform.Find("Bg/LeftView/close").GetComponent("XUISprite") as IXUISprite);
			this.m_RedViewSwitch = (base.transform.Find("Bg/RightView/close").GetComponent("XUISprite") as IXUISprite);
			this.m_BlueViewTween = (base.transform.Find("Bg/LeftView").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_RedViewTween = (base.transform.Find("Bg/RightView").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_UpDownTween = (base.transform.Find("Bg/UpDown").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		public IXUISprite m_UpBtn;

		public IXUISprite m_DownBtn;

		public GameObject m_ListView;

		public Transform m_BlueView;

		public Transform m_RedView;

		public GameObject m_Info;

		public Transform m_BlueInfo;

		public Transform m_RedInfo;

		public IXUILabel m_LeftTimeTip;

		public IXUISprite m_BlueViewSwitch;

		public IXUISprite m_RedViewSwitch;

		public XUIPool[] m_MemberPool = new XUIPool[2];

		public IXUIList[] m_MemberList = new IXUIList[2];

		public IXUITweenTool m_BlueViewTween;

		public IXUITweenTool m_RedViewTween;

		public IXUITweenTool m_UpDownTween;

		public IXUILabel m_TimeCount;
	}
}
