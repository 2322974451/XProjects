using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D0A RID: 3338
	internal class SpectateLevelRewardBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600BA83 RID: 47747 RVA: 0x002616DC File Offset: 0x0025F8DC
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

		// Token: 0x04004AD7 RID: 19159
		private static uint maxPlayerNum = 4U;

		// Token: 0x04004AD8 RID: 19160
		private static uint maxMessageNum = 8U;

		// Token: 0x04004AD9 RID: 19161
		public int MemberHeight;

		// Token: 0x04004ADA RID: 19162
		public int MemberStartY;

		// Token: 0x04004ADB RID: 19163
		public IXUISprite m_BackToMainCityBtn;

		// Token: 0x04004ADC RID: 19164
		public IXUILabel m_WatchNum;

		// Token: 0x04004ADD RID: 19165
		public IXUISprite m_GoOnBtn;

		// Token: 0x04004ADE RID: 19166
		public IXUILabel m_GoOnBtnText;

		// Token: 0x04004ADF RID: 19167
		public IXUILabel m_CommendNum;

		// Token: 0x04004AE0 RID: 19168
		public XUIPool m_TitlePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004AE1 RID: 19169
		public XUIPool m_MemberPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004AE2 RID: 19170
		public XUIPool m_DetailPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004AE3 RID: 19171
		public XUIPool m_SplitPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004AE4 RID: 19172
		public XUIPool m_LabelPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004AE5 RID: 19173
		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004AE6 RID: 19174
		public XUIPool m_WinLosePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004AE7 RID: 19175
		public GameObject m_MVP;

		// Token: 0x04004AE8 RID: 19176
		public Transform m_TitleParent;

		// Token: 0x04004AE9 RID: 19177
		public Transform m_MemberParent;
	}
}
