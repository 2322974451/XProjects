using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020016E9 RID: 5865
	internal class GVGBattlePrepareBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F1F7 RID: 61943 RVA: 0x003594DC File Offset: 0x003576DC
		protected virtual void Awake()
		{
			this.mGoBg = base.transform.FindChild("Bg").gameObject;
			this.mGoPrepare = base.transform.FindChild("Prepare").gameObject;
			this.mGoBattle = base.transform.FindChild("Battle").gameObject;
			this.mCombatInfo = base.transform.FindChild("Battle/Info");
			this.mCombatScore = base.transform.FindChild("Battle/Score").gameObject;
			this.mBlueView = base.transform.FindChild("Bg/LeftView").gameObject;
			this.mBlueCourage = base.transform.FindChild("Battle/Encourage/Blue").gameObject;
			this.mRedCourage = base.transform.FindChild("Battle/Encourage/Red").gameObject;
			this.mBlueCourageBar = (base.transform.FindChild("Battle/Encourage/Blue/Bar").GetComponent("XUISlider") as IXUISlider);
			this.mRedCourageBar = (base.transform.FindChild("Battle/Encourage/Red/Bar").GetComponent("XUISlider") as IXUISlider);
			this.mUp = base.transform.FindChild("Bg/LetmedieUp").gameObject;
			this.mUpSprite = (this.mUp.GetComponent("XUISprite") as IXUISprite);
			this.mDown = base.transform.FindChild("Bg/LetmedieDown").gameObject;
			this.mDownSprite = (this.mDown.GetComponent("XUISprite") as IXUISprite);
			this.BlueInspireTween = base.transform.Find("Battle/Encourage/Blue/Time").gameObject;
			this.RedInspireTween = base.transform.Find("Battle/Encourage/Red/Time").gameObject;
			this.mEncourageButton = base.transform.FindChild("Battle/GuildMember/Encourage").gameObject;
			this.mEncourageButtonBg = base.transform.FindChild("Battle/Encourage/Bg1").gameObject;
			this.mLeftTime = (base.transform.FindChild("LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.mRoundLabel = (base.transform.FindChild("GuildAreanStage").GetComponent("XUILabel") as IXUILabel);
			this.mBattleSkillTransform = base.transform.FindChild("KillInfo");
			this.mLetmedieUpSpr = (this.mGoBg.transform.FindChild("LetmedieUp").GetComponent("XUISprite") as IXUISprite);
			this.mLetmedieDownSpr = (this.mGoBg.transform.FindChild("LetmedieDown").GetComponent("XUISprite") as IXUISprite);
			this.mUpTips = base.transform.FindChild("Bg/LetmedieUpBg").gameObject;
			this.mDownTips = base.transform.FindChild("Bg/LetmedieDownBg").gameObject;
			this.mEncourageSpr = (base.transform.FindChild("Battle/GuildMember/Encourage").GetComponent("XUISprite") as IXUISprite);
			this.mHelpSpr = (base.transform.FindChild("Prepare/Help").GetComponent("XUISprite") as IXUISprite);
			this.mLeftCloseSpr = (this.mGoBg.transform.FindChild("LeftView/close").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04006781 RID: 26497
		protected internal GameObject mBlueView;

		// Token: 0x04006782 RID: 26498
		protected internal IXUISlider mBlueCourageBar;

		// Token: 0x04006783 RID: 26499
		protected internal IXUISlider mRedCourageBar;

		// Token: 0x04006784 RID: 26500
		protected internal GameObject BlueInspireTween = null;

		// Token: 0x04006785 RID: 26501
		protected internal GameObject RedInspireTween = null;

		// Token: 0x04006786 RID: 26502
		protected internal GameObject mUp;

		// Token: 0x04006787 RID: 26503
		protected internal GameObject mDown;

		// Token: 0x04006788 RID: 26504
		protected internal IXUISprite mUpSprite;

		// Token: 0x04006789 RID: 26505
		protected internal IXUISprite mDownSprite;

		// Token: 0x0400678A RID: 26506
		protected internal GameObject mUpTips;

		// Token: 0x0400678B RID: 26507
		protected internal GameObject mDownTips;

		// Token: 0x0400678C RID: 26508
		protected internal GameObject mGoPrepare = null;

		// Token: 0x0400678D RID: 26509
		protected internal GameObject mGoBattle = null;

		// Token: 0x0400678E RID: 26510
		protected internal GameObject mGoBg = null;

		// Token: 0x0400678F RID: 26511
		protected internal IGVGBattleMember mBluePanel;

		// Token: 0x04006790 RID: 26512
		protected internal GuildArenaInspireCD mInspireCD;

		// Token: 0x04006791 RID: 26513
		protected internal GameObject mEncourageButton;

		// Token: 0x04006792 RID: 26514
		protected internal GameObject mEncourageButtonBg;

		// Token: 0x04006793 RID: 26515
		protected internal Transform mCombatInfo;

		// Token: 0x04006794 RID: 26516
		protected internal GameObject mCombatScore;

		// Token: 0x04006795 RID: 26517
		protected internal IXUILabel mLeftTime;

		// Token: 0x04006796 RID: 26518
		protected internal IXUILabel mRoundLabel;

		// Token: 0x04006797 RID: 26519
		protected internal GameObject mBlueCourage;

		// Token: 0x04006798 RID: 26520
		protected internal GameObject mRedCourage;

		// Token: 0x04006799 RID: 26521
		protected internal GuildArenaBattleDuelInfo mBattleDuelInfo;

		// Token: 0x0400679A RID: 26522
		protected internal Transform mBattleSkillTransform;

		// Token: 0x0400679B RID: 26523
		protected internal IXUISprite mLetmedieUpSpr;

		// Token: 0x0400679C RID: 26524
		protected internal IXUISprite mLetmedieDownSpr;

		// Token: 0x0400679D RID: 26525
		protected internal IXUISprite mEncourageSpr;

		// Token: 0x0400679E RID: 26526
		protected internal IXUISprite mHelpSpr;

		// Token: 0x0400679F RID: 26527
		protected internal IXUISprite mLeftCloseSpr;
	}
}
