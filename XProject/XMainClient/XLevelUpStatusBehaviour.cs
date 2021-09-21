using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E48 RID: 3656
	internal class XLevelUpStatusBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C445 RID: 50245 RVA: 0x002ACCBC File Offset: 0x002AAEBC
		private void Awake()
		{
			this.m_AttrFrame = base.transform.Find("Bg/AttrFrame").gameObject;
			this.m_FishFrame = base.transform.Find("Bg/FishFrame").gameObject;
			Transform transform = this.m_AttrFrame.transform.FindChild("AttrTpl");
			this.m_AttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_iPlayTween = (base.transform.FindChild("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_NewSkillFrame = this.m_AttrFrame.transform.FindChild("NewSkillFrame");
			this.m_sprSkillBg = (this.m_AttrFrame.transform.Find("p").GetComponent("XUISprite") as IXUISprite);
			transform = this.m_NewSkillFrame.FindChild("SkillTpl");
			this.m_SkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_lblSkillPoint = (this.m_AttrFrame.transform.Find("SkillPoint/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_lblCurrLevel = (this.m_AttrFrame.transform.Find("CurLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_tweenLevel = (this.m_AttrFrame.transform.Find("CurLevel").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_PreFishingLevel = (this.m_FishFrame.transform.Find("PreLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_CurFishingLevel = (this.m_FishFrame.transform.Find("CurLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_FishingTitle = (this.m_FishFrame.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_objWing = base.transform.Find("UI_level").gameObject;
			this.m_lblLevel = (base.transform.Find("UI_level/LevelNum").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0400554C RID: 21836
		public XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400554D RID: 21837
		public IXUITweenTool m_iPlayTween;

		// Token: 0x0400554E RID: 21838
		public IXUIButton m_Close;

		// Token: 0x0400554F RID: 21839
		public Transform m_NewSkillFrame;

		// Token: 0x04005550 RID: 21840
		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005551 RID: 21841
		public IXUISprite m_sprSkillBg;

		// Token: 0x04005552 RID: 21842
		public IXUILabel m_PreFishingLevel;

		// Token: 0x04005553 RID: 21843
		public IXUILabel m_CurFishingLevel;

		// Token: 0x04005554 RID: 21844
		public IXUILabel m_FishingTitle;

		// Token: 0x04005555 RID: 21845
		public GameObject m_AttrFrame;

		// Token: 0x04005556 RID: 21846
		public GameObject m_FishFrame;

		// Token: 0x04005557 RID: 21847
		public GameObject m_objWing;

		// Token: 0x04005558 RID: 21848
		public IXUILabel m_lblLevel;

		// Token: 0x04005559 RID: 21849
		public IXUILabel m_lblSkillPoint;

		// Token: 0x0400555A RID: 21850
		public IXUILabel m_lblCurrLevel;

		// Token: 0x0400555B RID: 21851
		public IXUITweenTool m_tweenLevel;
	}
}
