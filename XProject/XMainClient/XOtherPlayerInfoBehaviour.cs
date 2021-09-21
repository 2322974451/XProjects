using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E2C RID: 3628
	internal class XOtherPlayerInfoBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C2FB RID: 49915 RVA: 0x0029FB44 File Offset: 0x0029DD44
		private void Awake()
		{
			this.m_InfoPanel = (base.transform.FindChild("Bg/InfoPanel").GetComponent("XUISprite") as IXUISprite);
			this.m_MenuPanel = (base.transform.FindChild("Bg/MenuPanel").GetComponent("XUISprite") as IXUISprite);
			this.m_MenuBack = (base.transform.FindChild("Bg/MenuPanel/back").GetComponent("XUISprite") as IXUISprite);
			this.m_MenuTip = (base.transform.FindChild("Bg/MenuPanel/CloseTip").GetComponent("XUISprite") as IXUISprite);
			this.m_MenuPool.SetupPool(base.transform.FindChild("Bg/MenuPanel").gameObject, base.transform.FindChild("Bg/MenuPanel/template").gameObject, 10U, false);
			this.m_MenuPlayerName = (base.transform.FindChild("Bg/MenuPanel/PlayerName").GetComponent("XUILabel") as IXUILabel);
			this.m_EquipLayer = (base.transform.FindChild("Bg/InfoPanel/EquipLayer").GetComponent("XUISprite") as IXUISprite);
			this.m_AvatarLayer = (base.transform.FindChild("Bg/InfoPanel/AvatarLayer").GetComponent("XUISprite") as IXUISprite);
			this.m_EmblemLayer = (base.transform.FindChild("Bg/InfoPanel/WenzhangLayer").GetComponent("XUISprite") as IXUISprite);
			this.m_GuildLayer = (base.transform.FindChild("Bg/InfoPanel/GuildLayer").GetComponent("XUISprite") as IXUISprite);
			this.m_PetLayer = (base.transform.FindChild("Bg/InfoPanel/PetLayer").GetComponent("XUISprite") as IXUISprite);
			this.m_SpriteLayer = (base.transform.FindChild("Bg/InfoPanel/SpriteLayer").GetComponent("XUISprite") as IXUISprite);
			this.m_SkillLayer = (base.transform.FindChild("Bg/InfoPanel/Skill").GetComponent("XUISprite") as IXUISprite);
			this.m_InfoPlayerName = (base.transform.FindChild("Bg/InfoPanel/name").GetComponent("XUILabel") as IXUILabel);
			this.m_artifactLayer = (base.transform.FindChild("Bg/InfoPanel/ArtifactLayer").GetComponent("XUISprite") as IXUISprite);
			this.m_FunctionBtns.SetupPool(base.transform.FindChild("Bg/InfoPanel").gameObject, base.transform.FindChild("Bg/InfoPanel/template").gameObject, 4U, false);
			this.m_EmblemPool.SetupPool(base.transform.FindChild("Bg/InfoPanel/WenzhangLayer/Emblems").gameObject, base.transform.FindChild("Bg/InfoPanel/WenzhangLayer/Emblems/EmblemTpl").gameObject, XOtherPlayerInfoBehaviour.Emblem_Slot_Count, false);
			int num = 0;
			Transform transform;
			while ((long)num < (long)((ulong)XOtherPlayerInfoBehaviour.Emblem_Slot_Count))
			{
				transform = base.transform.FindChild("Bg/InfoPanel/WenzhangLayer/Emblems/Emblem" + num);
				GameObject gameObject = this.m_EmblemPool.FetchGameObject(false);
				this.m_EmblemBg[num] = gameObject;
				gameObject.transform.localPosition = transform.localPosition;
				this.m_EmblemSlots[num] = (gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
				this.m_EmblemSlotCovers[num] = (gameObject.transform.FindChild("Cover").GetComponent("XUISprite") as IXUISprite);
				this.m_EmblemSlotCovers[num].ID = (ulong)((long)num);
				num++;
			}
			transform = base.transform.FindChild("Bg/InfoPanel/ArtifactLayer/Artifacts");
			this.m_ArtifactPool.SetupPool(transform.gameObject, transform.transform.Find("Tpl").gameObject, (uint)XBagDocument.ArtifactMax, false);
			for (int i = 0; i < XBagDocument.ArtifactMax; i++)
			{
				this.m_artifactGo[i] = this.m_ArtifactPool.FetchGameObject(false);
				GameObject gameObject2 = transform.FindChild("Artifact" + i).gameObject;
				this.m_artifactGo[i].transform.localScale = Vector3.one;
				this.m_artifactGo[i].transform.localPosition = gameObject2.transform.localPosition;
			}
			this.m_GuildLogo = (base.transform.FindChild("Bg/InfoPanel/GuildLayer/logo").GetComponent("XUISprite") as IXUISprite);
			this.m_GuildName = (base.transform.FindChild("Bg/InfoPanel/GuildLayer/guildname").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildMasterName = (base.transform.FindChild("Bg/InfoPanel/GuildLayer/guildinfo1/mastername").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildLevel = (base.transform.FindChild("Bg/InfoPanel/GuildLayer/guildinfo1/guildlevel").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildNumber = (base.transform.FindChild("Bg/InfoPanel/GuildLayer/guildinfo1/guildmember").GetComponent("XUILabel") as IXUILabel);
			this.m_GuildContent = (base.transform.FindChild("Bg/InfoPanel/GuildLayer/guildinfo2/content").GetComponent("XUILabel") as IXUILabel);
			this.m_PetInfo = this.m_PetLayer.gameObject.transform.FindChild("PetInfo");
			this.m_PetEmpty = this.m_PetLayer.gameObject.transform.FindChild("Empty");
			this.m_PetSkillFrame = this.m_PetInfo.gameObject.transform.FindChild("SkillFrame");
			Transform transform2 = this.m_PetInfo.gameObject.transform.Find("Attribute/AttributeTpl/Star/StarTpl");
			this.m_StarPool.SetupPool(null, transform2.gameObject, XPetMainView.STAR_MAX, false);
			int num2 = 0;
			while ((long)num2 < (long)((ulong)XPetMainView.STAR_MAX))
			{
				GameObject gameObject = this.m_StarPool.FetchGameObject(false);
				gameObject.name = string.Format("Star{0}", num2);
				num2++;
			}
			Transform transform3 = this.m_PetInfo.gameObject.transform.Find("Attribute/AttributeTpl");
			this.m_AttributePool.SetupPool(null, transform3.gameObject, XPetMainView.ATTRIBUTE_NUM_MAX, false);
			this.m_SpeedUp = (this.m_PetInfo.gameObject.transform.Find("SpeedUp").GetComponent("XUILabel") as IXUILabel);
			this.m_PetPPT = (this.m_PetInfo.gameObject.transform.Find("PowerPoint").GetComponent("XUILabel") as IXUILabel);
			this.m_PetName = (this.m_PetInfo.gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_PetLevel = (this.m_PetInfo.gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_PetSex = (this.m_PetInfo.gameObject.transform.Find("Sex").GetComponent("XUISprite") as IXUISprite);
			Transform transform4 = this.m_SkillLayer.gameObject.transform.Find("Tabs/Tpl");
			this.m_SkillTabs.SetupPool(transform4.parent.gameObject, transform4.gameObject, 3U, false);
			transform4 = this.m_SkillLayer.gameObject.transform.Find("SkillTree/Skill/SkillTpl");
			this.m_Skills.SetupPool(transform4.parent.gameObject, transform4.gameObject, 16U, false);
			transform4 = this.m_SkillLayer.gameObject.transform.Find("SkillTree/Arrow/ArrowTpl");
			this.m_SkillArrow.SetupPool(transform4.parent.gameObject, transform4.gameObject, 16U, false);
			this.m_SkillScrollView = (this.m_SkillLayer.gameObject.transform.Find("SkillTree").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_EquipSnapshot = (this.m_EquipLayer.gameObject.transform.Find("CharacterInfoFrame/CharacterFrame/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_AvatarSnapshot = (this.m_AvatarLayer.gameObject.transform.Find("CharacterInfoFrame/CharacterFrame/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_PetSnapshot = (this.m_PetInfo.gameObject.transform.Find("Snapshot").GetComponent("UIDummy") as IUIDummy);
		}

		// Token: 0x040053CA RID: 21450
		public static readonly uint FUNCTION_NUM = 3U;

		// Token: 0x040053CB RID: 21451
		public static readonly uint Emblem_Slot_Count = 16U;

		// Token: 0x040053CC RID: 21452
		public XUIPool m_FunctionBtns = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053CD RID: 21453
		public XUIPool m_EmblemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053CE RID: 21454
		public XUIPool m_MenuPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053CF RID: 21455
		private XUIPool m_ArtifactPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053D0 RID: 21456
		public GameObject[] m_artifactGo = new GameObject[XBagDocument.ArtifactMax];

		// Token: 0x040053D1 RID: 21457
		public IXUISprite m_InfoPanel;

		// Token: 0x040053D2 RID: 21458
		public IXUISprite m_MenuPanel;

		// Token: 0x040053D3 RID: 21459
		public IXUISprite m_MenuBack;

		// Token: 0x040053D4 RID: 21460
		public IXUISprite m_MenuTip;

		// Token: 0x040053D5 RID: 21461
		public IXUILabel m_MenuPlayerName;

		// Token: 0x040053D6 RID: 21462
		public IXUILabel m_InfoPlayerName;

		// Token: 0x040053D7 RID: 21463
		public IXUISprite m_EquipLayer;

		// Token: 0x040053D8 RID: 21464
		public IXUISprite m_AvatarLayer;

		// Token: 0x040053D9 RID: 21465
		public IXUISprite m_EmblemLayer;

		// Token: 0x040053DA RID: 21466
		public IXUISprite m_GuildLayer;

		// Token: 0x040053DB RID: 21467
		public IXUISprite m_PetLayer;

		// Token: 0x040053DC RID: 21468
		public IXUISprite m_SpriteLayer;

		// Token: 0x040053DD RID: 21469
		public IXUISprite m_SkillLayer;

		// Token: 0x040053DE RID: 21470
		public IXUISprite m_artifactLayer;

		// Token: 0x040053DF RID: 21471
		public IXUISprite m_GuildLogo;

		// Token: 0x040053E0 RID: 21472
		public IXUILabel m_GuildName;

		// Token: 0x040053E1 RID: 21473
		public IXUILabel m_GuildMasterName;

		// Token: 0x040053E2 RID: 21474
		public IXUILabel m_GuildLevel;

		// Token: 0x040053E3 RID: 21475
		public IXUILabel m_GuildNumber;

		// Token: 0x040053E4 RID: 21476
		public IXUILabel m_GuildContent;

		// Token: 0x040053E5 RID: 21477
		public Transform m_PetInfo;

		// Token: 0x040053E6 RID: 21478
		public Transform m_PetEmpty;

		// Token: 0x040053E7 RID: 21479
		public Transform m_PetSkillFrame;

		// Token: 0x040053E8 RID: 21480
		public XUIPool m_AttributePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053E9 RID: 21481
		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053EA RID: 21482
		public IXUILabel m_SpeedUp;

		// Token: 0x040053EB RID: 21483
		public IXUILabel m_PetPPT;

		// Token: 0x040053EC RID: 21484
		public IXUILabel m_PetName;

		// Token: 0x040053ED RID: 21485
		public IXUILabel m_PetLevel;

		// Token: 0x040053EE RID: 21486
		public IXUISprite m_PetSex;

		// Token: 0x040053EF RID: 21487
		public XUIPool m_SkillTabs = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053F0 RID: 21488
		public XUIPool m_Skills = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053F1 RID: 21489
		public XUIPool m_SkillArrow = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040053F2 RID: 21490
		public IXUIScrollView m_SkillScrollView;

		// Token: 0x040053F3 RID: 21491
		public GameObject[] m_EmblemBg = new GameObject[XOtherPlayerInfoBehaviour.Emblem_Slot_Count];

		// Token: 0x040053F4 RID: 21492
		public IXUISprite[] m_EmblemSlots = new IXUISprite[XOtherPlayerInfoBehaviour.Emblem_Slot_Count];

		// Token: 0x040053F5 RID: 21493
		public IXUISprite[] m_EmblemSlotCovers = new IXUISprite[XOtherPlayerInfoBehaviour.Emblem_Slot_Count];

		// Token: 0x040053F6 RID: 21494
		public IUIDummy m_EquipSnapshot;

		// Token: 0x040053F7 RID: 21495
		public IUIDummy m_AvatarSnapshot;

		// Token: 0x040053F8 RID: 21496
		public IUIDummy m_PetSnapshot;

		// Token: 0x040053F9 RID: 21497
		public IUIDummy m_CurrentSnapshot;
	}
}
