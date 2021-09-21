using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CB8 RID: 3256
	internal class XSpriteSkillTipBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B72B RID: 46891 RVA: 0x00246898 File Offset: 0x00244A98
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Black").GetComponent("XUISprite") as IXUISprite);
			this.m_MainSkill = (base.transform.Find("Bg/Bg/ToolTipCaptian").GetComponent("XUISprite") as IXUISprite);
			this.m_MainTopFrame = (base.transform.Find("Bg/Bg/ToolTipCaptian/TopFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_MainMiddleFrame = (base.transform.Find("Bg/Bg/ToolTipCaptian/MiddleFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_MainBottomFrame = (base.transform.Find("Bg/Bg/ToolTipCaptian/BottomFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_MainSkillName = (this.m_MainSkill.gameObject.transform.Find("TopFrame/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_MainSkillType = (this.m_MainSkill.gameObject.transform.Find("TopFrame/Type").GetComponent("XUILabel") as IXUILabel);
			this.m_MainSkillLevel = (this.m_MainSkill.gameObject.transform.Find("TopFrame/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_MainIcon = (this.m_MainSkill.gameObject.transform.Find("TopFrame/ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_MainSkillDuration = (this.m_MainSkill.gameObject.transform.Find("TopFrame/Duration").GetComponent("XUILabel") as IXUILabel);
			this.m_MainDesc = (this.m_MainSkill.gameObject.transform.Find("MiddleFrame/Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCurrEffect = (this.m_MainSkill.gameObject.transform.Find("BottomFrame/CurrEffect").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSkill = (base.transform.Find("Bg/Bg/ToolTipNormal").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalTopFrame = (base.transform.Find("Bg/Bg/ToolTipNormal/TopFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalMiddleFrame = (base.transform.Find("Bg/Bg/ToolTipNormal/BottomFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalSkillName = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSkillType = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/Type").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalSkillQuality = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/Quality").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalIcon = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_NormalCurrEffect = (this.m_NormalSkill.gameObject.transform.Find("BottomFrame/Effect").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalIconQuality = (this.m_NormalSkill.gameObject.transform.Find("TopFrame/ItemTpl/Frame").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x040047D1 RID: 18385
		public IXUISprite m_Close;

		// Token: 0x040047D2 RID: 18386
		public IXUISprite m_MainSkill;

		// Token: 0x040047D3 RID: 18387
		public IXUISprite m_MainTopFrame;

		// Token: 0x040047D4 RID: 18388
		public IXUISprite m_MainMiddleFrame;

		// Token: 0x040047D5 RID: 18389
		public IXUISprite m_MainBottomFrame;

		// Token: 0x040047D6 RID: 18390
		public IXUILabel m_MainSkillName;

		// Token: 0x040047D7 RID: 18391
		public IXUILabel m_MainSkillType;

		// Token: 0x040047D8 RID: 18392
		public IXUILabel m_MainSkillLevel;

		// Token: 0x040047D9 RID: 18393
		public IXUILabel m_MainCurrEffect;

		// Token: 0x040047DA RID: 18394
		public IXUILabel m_MainDesc;

		// Token: 0x040047DB RID: 18395
		public IXUISprite m_MainIcon;

		// Token: 0x040047DC RID: 18396
		public IXUILabel m_MainSkillDuration;

		// Token: 0x040047DD RID: 18397
		public IXUISprite m_NormalSkill;

		// Token: 0x040047DE RID: 18398
		public IXUISprite m_NormalTopFrame;

		// Token: 0x040047DF RID: 18399
		public IXUISprite m_NormalMiddleFrame;

		// Token: 0x040047E0 RID: 18400
		public IXUILabel m_NormalSkillName;

		// Token: 0x040047E1 RID: 18401
		public IXUILabel m_NormalSkillType;

		// Token: 0x040047E2 RID: 18402
		public IXUILabel m_NormalSkillQuality;

		// Token: 0x040047E3 RID: 18403
		public IXUILabel m_NormalCurrEffect;

		// Token: 0x040047E4 RID: 18404
		public IXUISprite m_NormalIcon;

		// Token: 0x040047E5 RID: 18405
		public IXUISprite m_NormalIconQuality;
	}
}
