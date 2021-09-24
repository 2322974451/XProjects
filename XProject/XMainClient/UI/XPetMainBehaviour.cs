using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XPetMainBehaviour : DlgBehaviourBase
	{

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

		public Transform m_Bg;

		public IXUIButton m_Close = null;

		public IXUIButton m_Help;

		public IXUIScrollView m_PetListScrollView;

		public IXUIWrapContent m_WrapContent;

		public IXUIProgress m_ExpBar;

		public IXUILabel m_Exp;

		public IXUILabel m_ExpBarLevel;

		public GameObject m_FeedFrame;

		public GameObject m_SkillFrame;

		public IXUIButton m_BtnMount;

		public IXUIButton m_BtnSkillLearn;

		public GameObject m_ContentFrame;

		public Transform m_Fx;

		public IXUILabel m_MoodLevel;

		public IXUISprite m_MoodIcon;

		public IXUIProgress m_FullDegreeBar;

		public IXUILabel m_FullDegree;

		public IXUISprite m_FullDegreeColor;

		public IXUISprite m_FullDegreeSp;

		public Transform m_FullDegreeTip;

		public Transform m_MoodTip;

		public IXUISprite m_FullDegreeClose;

		public IXUISprite m_MoodClose;

		public IXUIButton m_Throw;

		public IXUIButton m_Activation;

		public IXUIButton m_ExpTransfer;

		public IXUIButton m_TravelSet;

		public GameObject m_ActivationSelected;

		public IXUILabel m_ActivationLabel;

		public IXUISprite m_Sex;

		public IXUILabel m_Name;

		public IXUILabel m_Level;

		public IXUILabel m_SpeedUp;

		public IXUILabel m_PPT;

		public IXUILabel m_BtnMountLabel;

		public IXUILabel m_FullDegreeLabel;

		public IXUILabel m_MoodLabel;

		public Transform m_FeedRedPoint;

		public IXUILabel m_ExpPrivilegeLabel;

		public IXUISprite m_ExpPrivilegeSp;

		public IXUISprite m_PrivilegeBg;

		public IXUISprite m_Caress;

		public Transform m_Talk;

		public IXUILabel m_TalkLabel;

		public IXUILabel m_GoGetPet;

		public IXUILabel m_GoGetFeed;

		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_AttributePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IUIDummy m_PetSnapshot;
	}
}
