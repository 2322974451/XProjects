using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200173F RID: 5951
	internal class XTeamLeagueBattlePrepareBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F613 RID: 62995 RVA: 0x0037B770 File Offset: 0x00379970
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

		// Token: 0x04006AB5 RID: 27317
		public IXUISprite m_UpBtn;

		// Token: 0x04006AB6 RID: 27318
		public IXUISprite m_DownBtn;

		// Token: 0x04006AB7 RID: 27319
		public GameObject m_ListView;

		// Token: 0x04006AB8 RID: 27320
		public Transform m_BlueView;

		// Token: 0x04006AB9 RID: 27321
		public Transform m_RedView;

		// Token: 0x04006ABA RID: 27322
		public GameObject m_Info;

		// Token: 0x04006ABB RID: 27323
		public Transform m_BlueInfo;

		// Token: 0x04006ABC RID: 27324
		public Transform m_RedInfo;

		// Token: 0x04006ABD RID: 27325
		public IXUILabel m_LeftTimeTip;

		// Token: 0x04006ABE RID: 27326
		public IXUISprite m_BlueViewSwitch;

		// Token: 0x04006ABF RID: 27327
		public IXUISprite m_RedViewSwitch;

		// Token: 0x04006AC0 RID: 27328
		public XUIPool[] m_MemberPool = new XUIPool[2];

		// Token: 0x04006AC1 RID: 27329
		public IXUIList[] m_MemberList = new IXUIList[2];

		// Token: 0x04006AC2 RID: 27330
		public IXUITweenTool m_BlueViewTween;

		// Token: 0x04006AC3 RID: 27331
		public IXUITweenTool m_RedViewTween;

		// Token: 0x04006AC4 RID: 27332
		public IXUITweenTool m_UpDownTween;

		// Token: 0x04006AC5 RID: 27333
		public IXUILabel m_TimeCount;
	}
}
