using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOtherPlayerInfoBehaviour : DlgBehaviourBase
	{

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

		public static readonly uint FUNCTION_NUM = 3U;

		public static readonly uint Emblem_Slot_Count = 16U;

		public XUIPool m_FunctionBtns = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_EmblemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_MenuPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_ArtifactPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject[] m_artifactGo = new GameObject[XBagDocument.ArtifactMax];

		public IXUISprite m_InfoPanel;

		public IXUISprite m_MenuPanel;

		public IXUISprite m_MenuBack;

		public IXUISprite m_MenuTip;

		public IXUILabel m_MenuPlayerName;

		public IXUILabel m_InfoPlayerName;

		public IXUISprite m_EquipLayer;

		public IXUISprite m_AvatarLayer;

		public IXUISprite m_EmblemLayer;

		public IXUISprite m_GuildLayer;

		public IXUISprite m_PetLayer;

		public IXUISprite m_SpriteLayer;

		public IXUISprite m_SkillLayer;

		public IXUISprite m_artifactLayer;

		public IXUISprite m_GuildLogo;

		public IXUILabel m_GuildName;

		public IXUILabel m_GuildMasterName;

		public IXUILabel m_GuildLevel;

		public IXUILabel m_GuildNumber;

		public IXUILabel m_GuildContent;

		public Transform m_PetInfo;

		public Transform m_PetEmpty;

		public Transform m_PetSkillFrame;

		public XUIPool m_AttributePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_SpeedUp;

		public IXUILabel m_PetPPT;

		public IXUILabel m_PetName;

		public IXUILabel m_PetLevel;

		public IXUISprite m_PetSex;

		public XUIPool m_SkillTabs = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_Skills = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_SkillArrow = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_SkillScrollView;

		public GameObject[] m_EmblemBg = new GameObject[XOtherPlayerInfoBehaviour.Emblem_Slot_Count];

		public IXUISprite[] m_EmblemSlots = new IXUISprite[XOtherPlayerInfoBehaviour.Emblem_Slot_Count];

		public IXUISprite[] m_EmblemSlotCovers = new IXUISprite[XOtherPlayerInfoBehaviour.Emblem_Slot_Count];

		public IUIDummy m_EquipSnapshot;

		public IUIDummy m_AvatarSnapshot;

		public IUIDummy m_PetSnapshot;

		public IUIDummy m_CurrentSnapshot;
	}
}
