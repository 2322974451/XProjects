using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSkillStudyHandle : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
			this.m_SkillIcon = (base.PanelObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_SkillName = (base.PanelObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrentSkillLevel = (base.PanelObject.transform.FindChild("CurrentLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_NextSkillLevel = (base.PanelObject.transform.FindChild("CurrentLevel/NextLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_MaxSlillLevel = (base.PanelObject.transform.FindChild("MaxLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrentSkillAttr = (base.PanelObject.transform.FindChild("CurrentAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_NextSkillAttr = (base.PanelObject.transform.FindChild("CurrentAttr/NextAttr").GetComponent("XUILabel") as IXUILabel);
			this.m_UseGuildExp = (base.PanelObject.transform.FindChild("UseExp").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrentGuildExp = (base.PanelObject.transform.FindChild("CostRed").GetComponent("XUILabel") as IXUILabel);
			this.m_StudyButton = (base.PanelObject.transform.FindChild("Study").GetComponent("XUIButton") as IXUIButton);
			this.m_maskSprite = (base.PanelObject.transform.FindChild("Mask").GetComponent("XUISprite") as IXUISprite);
			this.m_costProgress = (base.PanelObject.transform.FindChild("CostRed/CostProgress").GetComponent("XUISlider") as IXUISlider);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_maskSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
			this.m_StudyButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStudyClick));
		}

		protected override string FileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildBuffLevelupPanel";
			}
		}

		public void ShowEffectDetailInfo()
		{
			XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_qianghua_03", this.m_SkillIcon.gameObject.transform, Vector3.zero, Vector3.one, 1f, true, 1f, true);
			this.SetDetailInfo();
		}

		public void SetDetailInfo()
		{
			uint currentSkillID = this._Doc.CurrentSkillID;
			uint skillMaxLevel = this._Doc.GetSkillMaxLevel(currentSkillID);
			uint level = this._Doc.GuildDoc.Level;
			GuildSkillTable.RowData guildSkill = this._Doc.GetGuildSkill(currentSkillID, skillMaxLevel);
			GuildSkillTable.RowData guildSkill2 = this._Doc.GetGuildSkill(currentSkillID, skillMaxLevel + 1U);
			this.m_SkillIcon.SetSprite(guildSkill.icon, guildSkill.atlas, false);
			this.m_SkillName.SetText(guildSkill.name);
			this.m_CurrentSkillLevel.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("XAttr_Level"), skillMaxLevel));
			this.m_NextSkillLevel.SetText((skillMaxLevel + 1U).ToString());
			this.m_CurrentSkillAttr.SetText(string.Format(guildSkill.currentLevelDescription, guildSkill.attribute[0, 1]));
			this.m_NextSkillAttr.SetText(guildSkill2.attribute[0, 1].ToString());
			uint num = XGuildDocument.GuildConfig.GetTotalStudyCount((int)guildSkill.glevel, (int)level) + this._Doc.GetGuildSkillInitLevel(guildSkill.skillid);
			this.m_MaxSlillLevel.SetText(XStringDefineProxy.GetString("GUILD_SKILL_MAX_UP_VALUE", new object[]
			{
				num
			}));
			this.m_UseGuildExp.SetText(guildSkill2.rexp.ToString());
			this.SetGuildExp(this._Doc.GuildDoc.CurrentTotalExp, this._Doc.LastGuildExp);
			uint maxLevel = XGuildDocument.GuildConfig.MaxLevel;
			bool flag = skillMaxLevel < num;
			if (flag)
			{
				int rexp = (int)guildSkill2.rexp;
				bool flag2 = this._Doc.LastGuildExp < rexp;
				if (flag2)
				{
					this.m_StudyButton.SetGrey(false);
				}
				else
				{
					this.m_StudyButton.SetGrey(true);
				}
			}
			else
			{
				this.m_StudyButton.SetGrey(false);
			}
			this.m_onSend = true;
		}

		private void SetGuildExp(uint totalExp, int curExp)
		{
			this.m_CurrentGuildExp.SetText(string.Format("{0}/{1}", curExp, totalExp));
			float value = (totalExp > 0U) ? ((float)curExp / totalExp) : 0f;
			this.m_costProgress.Value = value;
		}

		private void OnCloseClick(IXUISprite sprite)
		{
			base.SetVisible(false);
		}

		private bool OnStudyClick(IXUIButton btn)
		{
			bool flag = !this.m_onSend;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint maxLevel = XGuildDocument.GuildConfig.MaxLevel;
				uint level = this._Doc.GuildDoc.Level;
				uint skillMaxLevel = this._Doc.GetSkillMaxLevel(this._Doc.CurrentSkillID);
				GuildSkillTable.RowData guildSkill = this._Doc.GetGuildSkill(this._Doc.CurrentSkillID, skillMaxLevel + 1U);
				uint num = XGuildDocument.GuildConfig.GetTotalStudyCount((int)guildSkill.glevel, (int)level) + this._Doc.GetGuildSkillInitLevel(guildSkill.skillid);
				bool flag2 = skillMaxLevel < num;
				if (flag2)
				{
					int rexp = (int)guildSkill.rexp;
					bool flag3 = this._Doc.LastGuildExp < rexp;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_SKILL_UNDER_EXP"), "fece00");
					}
					else
					{
						this._Doc.GetStudyGuildSkill(this._Doc.CurrentSkillID);
						this.m_onSend = false;
					}
				}
				else
				{
					bool flag4 = maxLevel == level;
					if (flag4)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_SKILL_MAX_ALLMAX"), "fece00");
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_SKILL_MAX_CURMAX"), "fece00");
					}
				}
				result = true;
			}
			return result;
		}

		private IXUISprite m_SkillIcon;

		private IXUILabel m_SkillName;

		private IXUILabel m_CurrentSkillLevel;

		private IXUILabel m_NextSkillLevel;

		private IXUILabel m_CurrentSkillAttr;

		private IXUILabel m_NextSkillAttr;

		private IXUILabel m_MaxSlillLevel;

		private IXUILabel m_UseGuildExp;

		private IXUILabel m_CurrentGuildExp;

		private IXUIButton m_StudyButton;

		private IXUISprite m_maskSprite;

		private IXUISlider m_costProgress;

		private XGuildSkillDocument _Doc = null;

		private bool m_onSend = false;
	}
}
