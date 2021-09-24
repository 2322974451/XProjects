using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildGrowthLabView : DlgBase<XGuildGrowthLabView, XGuildGrowthLabBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildGrowthLabDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
			this._guildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this._skillDoc = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
		}

		private bool OnClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			return false;
		}

		private void OnPointClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(35, null);
		}

		private bool OnHelpBtnClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildGrowthLab);
			return true;
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildGrowthLab);
			}
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.HelpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClick));
			base.uiBehaviour.LevelUpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLevelUpBtnClick));
			base.uiBehaviour.m_PointClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPointClick));
		}

		protected override void OnShow()
		{
			this._currSelectID = -1;
			this.RefreshList(false);
		}

		private bool OnCheckBoxClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._currSelectID = (int)icb.ID;
				this.RefreshDetail();
				result = true;
			}
			return result;
		}

		private bool OnLevelUpBtnClick(IXUIButton btn)
		{
			uint skillID = XGuildSkillDocument.GuildSkillIDs[this._currSelectID];
			uint skillMaxLevel = this._skillDoc.GetSkillMaxLevel(skillID);
			GuildSkillTable.RowData guildSkill = this._skillDoc.GetGuildSkill(skillID, skillMaxLevel + 1U);
			bool flag = guildSkill == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this._guildDoc.Level < guildSkill.glevel;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("GuildGrowthHallGuildLevelNeedShow"), guildSkill.glevel), "fece00");
					result = false;
				}
				else
				{
					bool flag3 = !this._doc.LevelUpEnable;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GuildGrowthAuthorityFail"), "fece00");
						result = false;
					}
					else
					{
						this._skillDoc.GetStudyGuildSkill(XGuildSkillDocument.GuildSkillIDs[this._currSelectID]);
						result = true;
					}
				}
			}
			return result;
		}

		public void RefreshList(bool forceRefreshDetail = false)
		{
			base.uiBehaviour.BuffItemPool.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.BuffItemPool.TplPos;
			int num = 0;
			IXUICheckBox ixuicheckBox = null;
			List<uint> guildSkillIDs = XGuildSkillDocument.GuildSkillIDs;
			for (int i = 0; i < guildSkillIDs.Count; i++)
			{
				uint skillMaxLevel = this._skillDoc.GetSkillMaxLevel(guildSkillIDs[i]);
				GuildSkillTable.RowData rowData;
				bool flag = !this._skillDoc.TryGetGuildSkill(guildSkillIDs[i], skillMaxLevel, out rowData);
				if (flag)
				{
					return;
				}
				bool flag2 = rowData.needtype == 1U;
				if (!flag2)
				{
					GameObject gameObject = base.uiBehaviour.BuffItemPool.FetchGameObject(false);
					gameObject.transform.localPosition = tplPos + new Vector3((float)(num % 2 * base.uiBehaviour.BuffItemPool.TplWidth), (float)(-(float)(num / 2) * base.uiBehaviour.BuffItemPool.TplHeight));
					IXUILabel ixuilabel = gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = gameObject.transform.Find("Attr").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					IXUICheckBox ixuicheckBox2 = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckBoxClick));
					ixuicheckBox2.ID = (ulong)i;
					bool flag3 = i == this._currSelectID || this._currSelectID == -1;
					if (flag3)
					{
						ixuicheckBox = ixuicheckBox2;
						this._currSelectID = i;
					}
					ixuilabel.SetText(string.Format("{0}/{1}", skillMaxLevel.ToString(), this._skillDoc.GetLabSkillMaxLevel(guildSkillIDs[i])));
					ixuilabel2.SetText(rowData.name);
					ixuilabel3.SetText(string.Format(rowData.currentLevelDescription, rowData.attribute[0, 1]));
					ixuisprite.SetSprite(rowData.icon, rowData.atlas, false);
					num++;
				}
			}
			bool flag4 = ixuicheckBox != null;
			if (flag4)
			{
				ixuicheckBox.bChecked = true;
			}
			base.uiBehaviour.m_PointLeft.SetText(this._doc.TechnologyPoint.ToString());
			if (forceRefreshDetail)
			{
				this.RefreshDetail();
				return;
			}
		}

		public void RefreshDetail()
		{
			uint skillID = XGuildSkillDocument.GuildSkillIDs[this._currSelectID];
			uint skillMaxLevel = this._skillDoc.GetSkillMaxLevel(skillID);
			uint labSkillMaxLevel = this._skillDoc.GetLabSkillMaxLevel(skillID);
			GuildSkillTable.RowData guildSkill = this._skillDoc.GetGuildSkill(skillID, skillMaxLevel);
			GuildSkillTable.RowData guildSkill2 = this._skillDoc.GetGuildSkill(skillID, skillMaxLevel + 1U);
			bool flag = skillMaxLevel == labSkillMaxLevel;
			base.uiBehaviour.m_DetailBuffIcon.SetSprite(guildSkill.icon, guildSkill.atlas, false);
			base.uiBehaviour.m_DetailBuffName.SetText(guildSkill.name);
			base.uiBehaviour.m_DetailMaxLevel.SetText(labSkillMaxLevel.ToString());
			bool flag2 = flag;
			if (flag2)
			{
				base.uiBehaviour.m_DetailCurrLevel.SetVisible(false);
				base.uiBehaviour.m_DetailCurrKeepCost.SetVisible(false);
				base.uiBehaviour.m_DetailCost.InputText = "0";
				base.uiBehaviour.LevelUpBtn.SetEnable(false, false);
				base.uiBehaviour.LevelUpText.SetText(XStringDefineProxy.GetString("GuildGrowthHallMaxLevel"));
			}
			else
			{
				base.uiBehaviour.m_DetailCurrLevel.SetVisible(true);
				base.uiBehaviour.m_DetailCurrKeepCost.SetVisible(true);
				base.uiBehaviour.m_DetailCurrLevel.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("GuildGrowthHallLevel"), skillMaxLevel));
				base.uiBehaviour.m_DetailNextLevel.SetText((skillMaxLevel + 1U).ToString());
				base.uiBehaviour.m_DetailCurrKeepCost.SetText(string.Format("{0} {1}", guildSkill.name, guildSkill.attribute[0, 1]));
				base.uiBehaviour.m_DetailNextKeepCost.SetText(guildSkill2.attribute[0, 1].ToString());
				base.uiBehaviour.m_DetailCost.InputText = string.Format("{0}{1}{2}", (this._doc.TechnologyPoint >= guildSkill2.rexp) ? "" : "[e60012]", XLabelSymbolHelper.FormatSmallIcon(35), guildSkill2.rexp);
				base.uiBehaviour.LevelUpBtn.SetEnable(true, false);
				base.uiBehaviour.LevelUpBtn.SetGrey(this._guildDoc.Level >= guildSkill2.glevel);
				base.uiBehaviour.LevelUpText.SetText(XStringDefineProxy.GetString((this._guildDoc.Level >= guildSkill2.glevel) ? "GuildGrowthLabLevelUp" : "GuildGrowthHallGuildLevelNeed"));
			}
		}

		private XGuildGrowthDocument _doc;

		private XGuildDocument _guildDoc;

		private XGuildSkillDocument _skillDoc = null;

		private int _currSelectID = 0;
	}
}
