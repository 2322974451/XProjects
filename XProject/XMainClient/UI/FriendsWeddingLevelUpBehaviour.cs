using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class FriendsWeddingLevelUpBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_LevelTip = (base.transform.Find("open/Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_GetBtn = (base.transform.Find("open/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_ItemDesc = base.transform.Find("open/desc").gameObject;
			this.m_Skill = base.transform.Find("open/Skill").gameObject;
			this.m_SkillName = (base.transform.Find("open/Skill/tmp/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillIcon = (base.transform.Find("open/Skill/tmp/SkillIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_Item = base.transform.Find("open/items").gameObject;
			this.m_ItemName = (base.transform.Find("open/items/tmp/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_ItemIconTran = base.transform.Find("open/items/tmp");
		}

		public IXUILabel m_LevelTip;

		public IXUIButton m_GetBtn;

		public GameObject m_ItemDesc;

		public IXUILabel m_SkillName;

		public IXUISprite m_SkillIcon;

		public GameObject m_Skill;

		public IXUILabel m_ItemName;

		public Transform m_ItemIconTran;

		public GameObject m_Item;
	}
}
