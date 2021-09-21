using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200184D RID: 6221
	internal class XPetMainBehaviour : DlgBehaviourBase
	{
		// Token: 0x060102A5 RID: 66213 RVA: 0x003E09F4 File Offset: 0x003DEBF4
		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Fx = base.transform.Find("Bg/Fx");
			this.m_WrapContent = (base.transform.Find("Bg/PetListPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_PetListScrollView = (base.transform.Find("Bg/PetListPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = base.transform.Find("Bg/ContentFrame");
			this.m_ContentFrame = transform.gameObject;
			this.m_ExpPrivilegeSp = (this.m_ContentFrame.transform.Find("Privilege").GetComponent("XUISprite") as IXUISprite);
			this.m_PrivilegeBg = (this.m_ContentFrame.transform.Find("Privilege/T/p").GetComponent("XUISprite") as IXUISprite);
			this.m_ExpPrivilegeLabel = (this.m_ContentFrame.transform.Find("Privilege/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Caress = (this.m_ContentFrame.transform.Find("Caress").GetComponent("XUISprite") as IXUISprite);
			this.m_Talk = this.m_ContentFrame.transform.Find("Talk");
			this.m_TalkLabel = (this.m_ContentFrame.transform.Find("Talk/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ExpBar = (transform.Find("ExpBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_Exp = (this.m_ExpBar.gameObject.transform.Find("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_ExpBarLevel = (this.m_ExpBar.gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_FeedFrame = transform.Find("FeedFrame").gameObject;
			this.m_GoGetFeed = (this.m_FeedFrame.transform.Find("ItemPanel/NoFeed/GoGetFeed").GetComponent("XUILabel") as IXUILabel);
			this.m_FeedRedPoint = this.m_FeedFrame.transform.Find("BtnFeed/RedPoint");
			transform = base.transform.Find("Bg/ContentFrame/Right");
			this.m_BtnMount = (transform.Find("BtnMount").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnMountLabel = (transform.Find("BtnMount/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnSkillLearn = (transform.Find("BtnSkillLearn").GetComponent("XUIButton") as IXUIButton);
			this.m_Sex = (transform.Find("DetailTip/Sex").GetComponent("XUISprite") as IXUISprite);
			this.m_Name = (transform.Find("DetailTip/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Level = (transform.Find("DetailTip/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_SpeedUp = (transform.Find("DetailTip/SpeedUp").GetComponent("XUILabel") as IXUILabel);
			this.m_PPT = (transform.Find("DetailTip/PPT").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillFrame = transform.Find("DetailTip/Skill").gameObject;
			Transform transform2 = transform.Find("DetailTip/Attribute/AttributeTpl");
			Transform transform3 = transform.transform.Find("DetailTip/Attribute/AttributeTpl/Star/StarTpl");
			this.m_StarPool.SetupPool(null, transform3.gameObject, XPetMainView.STAR_MAX, false);
			int num = 0;
			while ((long)num < (long)((ulong)XPetMainView.STAR_MAX))
			{
				GameObject gameObject = this.m_StarPool.FetchGameObject(false);
				gameObject.name = string.Format("Star{0}", num);
				num++;
			}
			this.m_AttributePool.SetupPool(null, transform2.gameObject, XPetMainView.ATTRIBUTE_NUM_MAX, false);
			transform = base.transform.Find("Bg/ContentFrame/LeftUp");
			this.m_Throw = (transform.Find("Throw").GetComponent("XUIButton") as IXUIButton);
			this.m_Activation = (transform.Find("Activation").GetComponent("XUIButton") as IXUIButton);
			this.m_ActivationSelected = transform.Find("Activation/Selected").gameObject;
			this.m_ActivationLabel = (transform.Find("Activation/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ExpTransfer = (transform.Find("ExpTransfer").GetComponent("XUIButton") as IXUIButton);
			this.m_TravelSet = (transform.Find("TravelSet").GetComponent("XUIButton") as IXUIButton);
			transform = base.transform.Find("Bg/ContentFrame/RightUp");
			this.m_FullDegreeBar = (transform.Find("FullDegreeBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_FullDegreeSp = (this.m_FullDegreeBar.gameObject.transform.Find("Eat").GetComponent("XUISprite") as IXUISprite);
			this.m_FullDegree = (this.m_FullDegreeBar.gameObject.transform.Find("Value").GetComponent("XUILabel") as IXUILabel);
			this.m_FullDegreeColor = (this.m_FullDegreeBar.gameObject.transform.Find("Overlay").GetComponent("XUISprite") as IXUISprite);
			this.m_FullDegreeLabel = (this.m_FullDegreeBar.gameObject.transform.Find("Tip/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_FullDegreeClose = (this.m_FullDegreeBar.gameObject.transform.Find("Tip/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_FullDegreeTip = this.m_FullDegreeBar.gameObject.transform.Find("Tip");
			this.m_MoodIcon = (transform.Find("Mood").GetComponent("XUISprite") as IXUISprite);
			this.m_MoodLevel = (transform.Find("Mood/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_MoodLabel = (transform.Find("Mood/Tip/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_MoodClose = (transform.Find("Mood/Tip/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_MoodTip = transform.Find("Mood/Tip");
			this.m_PetSnapshot = (this.m_ContentFrame.transform.Find("Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_GoGetPet = (base.transform.Find("Bg/GoGetPet").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040073A3 RID: 29603
		public Transform m_Bg;

		// Token: 0x040073A4 RID: 29604
		public IXUIButton m_Close = null;

		// Token: 0x040073A5 RID: 29605
		public IXUIButton m_Help;

		// Token: 0x040073A6 RID: 29606
		public IXUIScrollView m_PetListScrollView;

		// Token: 0x040073A7 RID: 29607
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040073A8 RID: 29608
		public IXUIProgress m_ExpBar;

		// Token: 0x040073A9 RID: 29609
		public IXUILabel m_Exp;

		// Token: 0x040073AA RID: 29610
		public IXUILabel m_ExpBarLevel;

		// Token: 0x040073AB RID: 29611
		public GameObject m_FeedFrame;

		// Token: 0x040073AC RID: 29612
		public GameObject m_SkillFrame;

		// Token: 0x040073AD RID: 29613
		public IXUIButton m_BtnMount;

		// Token: 0x040073AE RID: 29614
		public IXUIButton m_BtnSkillLearn;

		// Token: 0x040073AF RID: 29615
		public GameObject m_ContentFrame;

		// Token: 0x040073B0 RID: 29616
		public Transform m_Fx;

		// Token: 0x040073B1 RID: 29617
		public IXUILabel m_MoodLevel;

		// Token: 0x040073B2 RID: 29618
		public IXUISprite m_MoodIcon;

		// Token: 0x040073B3 RID: 29619
		public IXUIProgress m_FullDegreeBar;

		// Token: 0x040073B4 RID: 29620
		public IXUILabel m_FullDegree;

		// Token: 0x040073B5 RID: 29621
		public IXUISprite m_FullDegreeColor;

		// Token: 0x040073B6 RID: 29622
		public IXUISprite m_FullDegreeSp;

		// Token: 0x040073B7 RID: 29623
		public Transform m_FullDegreeTip;

		// Token: 0x040073B8 RID: 29624
		public Transform m_MoodTip;

		// Token: 0x040073B9 RID: 29625
		public IXUISprite m_FullDegreeClose;

		// Token: 0x040073BA RID: 29626
		public IXUISprite m_MoodClose;

		// Token: 0x040073BB RID: 29627
		public IXUIButton m_Throw;

		// Token: 0x040073BC RID: 29628
		public IXUIButton m_Activation;

		// Token: 0x040073BD RID: 29629
		public IXUIButton m_ExpTransfer;

		// Token: 0x040073BE RID: 29630
		public IXUIButton m_TravelSet;

		// Token: 0x040073BF RID: 29631
		public GameObject m_ActivationSelected;

		// Token: 0x040073C0 RID: 29632
		public IXUILabel m_ActivationLabel;

		// Token: 0x040073C1 RID: 29633
		public IXUISprite m_Sex;

		// Token: 0x040073C2 RID: 29634
		public IXUILabel m_Name;

		// Token: 0x040073C3 RID: 29635
		public IXUILabel m_Level;

		// Token: 0x040073C4 RID: 29636
		public IXUILabel m_SpeedUp;

		// Token: 0x040073C5 RID: 29637
		public IXUILabel m_PPT;

		// Token: 0x040073C6 RID: 29638
		public IXUILabel m_BtnMountLabel;

		// Token: 0x040073C7 RID: 29639
		public IXUILabel m_FullDegreeLabel;

		// Token: 0x040073C8 RID: 29640
		public IXUILabel m_MoodLabel;

		// Token: 0x040073C9 RID: 29641
		public Transform m_FeedRedPoint;

		// Token: 0x040073CA RID: 29642
		public IXUILabel m_ExpPrivilegeLabel;

		// Token: 0x040073CB RID: 29643
		public IXUISprite m_ExpPrivilegeSp;

		// Token: 0x040073CC RID: 29644
		public IXUISprite m_PrivilegeBg;

		// Token: 0x040073CD RID: 29645
		public IXUISprite m_Caress;

		// Token: 0x040073CE RID: 29646
		public Transform m_Talk;

		// Token: 0x040073CF RID: 29647
		public IXUILabel m_TalkLabel;

		// Token: 0x040073D0 RID: 29648
		public IXUILabel m_GoGetPet;

		// Token: 0x040073D1 RID: 29649
		public IXUILabel m_GoGetFeed;

		// Token: 0x040073D2 RID: 29650
		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040073D3 RID: 29651
		public XUIPool m_AttributePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040073D4 RID: 29652
		public IUIDummy m_PetSnapshot;
	}
}
