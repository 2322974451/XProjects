using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CF4 RID: 3316
	internal class XGuildSkillStudyHandle : DlgHandlerBase
	{
		// Token: 0x0600B976 RID: 47478 RVA: 0x0025A9E4 File Offset: 0x00258BE4
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

		// Token: 0x0600B977 RID: 47479 RVA: 0x0025AC01 File Offset: 0x00258E01
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_maskSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
			this.m_StudyButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStudyClick));
		}

		// Token: 0x1700329C RID: 12956
		// (get) Token: 0x0600B978 RID: 47480 RVA: 0x0025AC3C File Offset: 0x00258E3C
		protected override string FileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildBuffLevelupPanel";
			}
		}

		// Token: 0x0600B979 RID: 47481 RVA: 0x0025AC54 File Offset: 0x00258E54
		public void ShowEffectDetailInfo()
		{
			XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_qianghua_03", this.m_SkillIcon.gameObject.transform, Vector3.zero, Vector3.one, 1f, true, 1f, true);
			this.SetDetailInfo();
		}

		// Token: 0x0600B97A RID: 47482 RVA: 0x0025ACA0 File Offset: 0x00258EA0
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

		// Token: 0x0600B97B RID: 47483 RVA: 0x0025AEA0 File Offset: 0x002590A0
		private void SetGuildExp(uint totalExp, int curExp)
		{
			this.m_CurrentGuildExp.SetText(string.Format("{0}/{1}", curExp, totalExp));
			float value = (totalExp > 0U) ? ((float)curExp / totalExp) : 0f;
			this.m_costProgress.Value = value;
		}

		// Token: 0x0600B97C RID: 47484 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnCloseClick(IXUISprite sprite)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600B97D RID: 47485 RVA: 0x0025AEF0 File Offset: 0x002590F0
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

		// Token: 0x04004A12 RID: 18962
		private IXUISprite m_SkillIcon;

		// Token: 0x04004A13 RID: 18963
		private IXUILabel m_SkillName;

		// Token: 0x04004A14 RID: 18964
		private IXUILabel m_CurrentSkillLevel;

		// Token: 0x04004A15 RID: 18965
		private IXUILabel m_NextSkillLevel;

		// Token: 0x04004A16 RID: 18966
		private IXUILabel m_CurrentSkillAttr;

		// Token: 0x04004A17 RID: 18967
		private IXUILabel m_NextSkillAttr;

		// Token: 0x04004A18 RID: 18968
		private IXUILabel m_MaxSlillLevel;

		// Token: 0x04004A19 RID: 18969
		private IXUILabel m_UseGuildExp;

		// Token: 0x04004A1A RID: 18970
		private IXUILabel m_CurrentGuildExp;

		// Token: 0x04004A1B RID: 18971
		private IXUIButton m_StudyButton;

		// Token: 0x04004A1C RID: 18972
		private IXUISprite m_maskSprite;

		// Token: 0x04004A1D RID: 18973
		private IXUISlider m_costProgress;

		// Token: 0x04004A1E RID: 18974
		private XGuildSkillDocument _Doc = null;

		// Token: 0x04004A1F RID: 18975
		private bool m_onSend = false;
	}
}
