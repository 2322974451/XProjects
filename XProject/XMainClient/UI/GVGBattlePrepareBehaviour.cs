using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GVGBattlePrepareBehaviour : DlgBehaviourBase
	{

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

		protected internal GameObject mBlueView;

		protected internal IXUISlider mBlueCourageBar;

		protected internal IXUISlider mRedCourageBar;

		protected internal GameObject BlueInspireTween = null;

		protected internal GameObject RedInspireTween = null;

		protected internal GameObject mUp;

		protected internal GameObject mDown;

		protected internal IXUISprite mUpSprite;

		protected internal IXUISprite mDownSprite;

		protected internal GameObject mUpTips;

		protected internal GameObject mDownTips;

		protected internal GameObject mGoPrepare = null;

		protected internal GameObject mGoBattle = null;

		protected internal GameObject mGoBg = null;

		protected internal IGVGBattleMember mBluePanel;

		protected internal GuildArenaInspireCD mInspireCD;

		protected internal GameObject mEncourageButton;

		protected internal GameObject mEncourageButtonBg;

		protected internal Transform mCombatInfo;

		protected internal GameObject mCombatScore;

		protected internal IXUILabel mLeftTime;

		protected internal IXUILabel mRoundLabel;

		protected internal GameObject mBlueCourage;

		protected internal GameObject mRedCourage;

		protected internal GuildArenaBattleDuelInfo mBattleDuelInfo;

		protected internal Transform mBattleSkillTransform;

		protected internal IXUISprite mLetmedieUpSpr;

		protected internal IXUISprite mLetmedieDownSpr;

		protected internal IXUISprite mEncourageSpr;

		protected internal IXUISprite mHelpSpr;

		protected internal IXUISprite mLeftCloseSpr;
	}
}
