using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSkillView : DlgBase<XGuildSkillView, XGuildSkillBehaviour>
	{

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildSkillDlg";
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this.m_studyHandlePanel = base.uiBehaviour.transform.FindChild("Bg");
			this._StudyHandle = DlgHandlerBase.EnsureCreate<XGuildSkillStudyHandle>(ref this._StudyHandle, this.m_studyHandlePanel, false, this);
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XGuildSkillStudyHandle>(ref this._StudyHandle);
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
			this._doc.SKillView = this;
			this._doc.Player = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			this._doc.BagDoc = XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID);
			this._doc.GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.GetSkillList();
			this.SetupSkillList(true, false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_LevelUp.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLevelUpClick));
			base.uiBehaviour.m_DetailUpMaxLevel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnUpMaxLevelClick));
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnUpMaxLevelClick(IXUIButton button)
		{
			this._StudyHandle.SetVisible(true);
			this._StudyHandle.SetDetailInfo();
			return false;
		}

		private bool OnLevelUpClick(IXUIButton button)
		{
			string empty = string.Empty;
			uint currentSkillID = this._doc.CurrentSkillID;
			uint curGuildSkillLevel = this._doc.GetCurGuildSkillLevel(currentSkillID);
			GuildSkillTable.RowData rowData;
			bool flag = !this._doc.TryGetGuildSkill(currentSkillID, curGuildSkillLevel, out rowData);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint skillMaxLevel = this._doc.GetSkillMaxLevel(currentSkillID);
				bool flag2 = curGuildSkillLevel < skillMaxLevel;
				if (flag2)
				{
					this._doc.SendLearnGuildSkill();
				}
				else
				{
					uint num = XGuildDocument.GuildConfig.GetTotalStudyCount((int)rowData.glevel, (int)this._doc.GuildDoc.Level) + this._doc.GetGuildSkillInitLevel(rowData.skillid);
					bool flag3 = skillMaxLevel < num;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_GUILD_SKILL_STUDY_LEVEL_DOWN"), "fece00");
					}
					else
					{
						bool flag4 = this._doc.GuildDoc.Level < XGuildDocument.GuildConfig.MaxLevel;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_GUILD_SKILL_GUILD_LEVEL_DOWN"), "fece00");
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_GUILD_SKILL_LEVEL_FULL"), "fece00");
						}
					}
				}
				result = true;
			}
			return result;
		}

		private void OnSkillClick(IXUISprite sp)
		{
			bool flag = this._doc.CurrentSkillID == (uint)sp.ID;
			if (!flag)
			{
				this._doc.CurrentSkillID = (uint)sp.ID;
				this.RefreshSkillLight();
				this.SetupDetailSkill();
			}
		}

		public void SetupSkillList(bool refresh = true, bool showEffect = false)
		{
			base.uiBehaviour.m_SkillPool.FakeReturnAll();
			this.m_showEffect = showEffect;
			List<uint> guildSkillIDs = XGuildSkillDocument.GuildSkillIDs;
			int num = base.uiBehaviour.m_SkillPool.TplWidth + 30;
			guildSkillIDs.Sort(new Comparison<uint>(XGuildSkillView.SkillSortCompare));
			int num2 = 0;
			for (int i = 0; i < guildSkillIDs.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_SkillPool.FetchGameObject(false);
				gameObject.name = string.Format("Skill{0}", ++num2);
				this.SetupSkill(gameObject, guildSkillIDs[i]);
				gameObject.transform.localPosition = base.uiBehaviour.m_SkillPool.TplPos + new Vector3((float)(i % 2 * base.uiBehaviour.m_SkillPool.TplWidth), (float)(-(float)i / 2 * base.uiBehaviour.m_SkillPool.TplHeight));
			}
			base.uiBehaviour.m_SkillPool.ActualReturnAll(false);
			if (refresh)
			{
				this._doc.CurrentSkillID = guildSkillIDs[0];
				base.uiBehaviour.m_SkillScroll.ResetPosition();
			}
			this.RefreshSkillLight();
			this.SetupDetailSkill();
			this.RefreshGuildPoint();
		}

		private void SetupSkill(GameObject go, uint skillID)
		{
			uint level = this._doc.GuildDoc.BasicData.level;
			uint curGuildSkillLevel = this._doc.GetCurGuildSkillLevel(skillID);
			GuildSkillTable.RowData rowData;
			bool flag = !this._doc.TryGetGuildSkill(skillID, curGuildSkillLevel, out rowData);
			if (!flag)
			{
				uint glevel = rowData.glevel;
				uint skillMaxLevel = this._doc.GetSkillMaxLevel(skillID);
				IXUISprite ixuisprite = go.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = go.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = go.transform.FindChild("Attr").GetComponent("XUILabel") as IXUILabel;
				Transform transform = go.transform.FindChild("Light");
				IXUISprite ixuisprite2 = go.GetComponent("XUISprite") as IXUISprite;
				Transform transform2 = go.transform.FindChild("RedPoint");
				IXUISprite ixuisprite3 = go.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel4 = go.transform.FindChild("LevelText").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = go.transform.FindChild("GuildLevel").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite4 = go.transform.FindChild("Profecssion").GetComponent("XUISprite") as IXUISprite;
				ixuilabel5.SetText(XStringDefineProxy.GetString("OPEN_AT_GUILD_LEVEL", new object[]
				{
					glevel
				}));
				bool flag2 = false;
				bool flag3 = rowData.needtype == 2U;
				if (flag3)
				{
					flag2 = true;
				}
				else
				{
					bool flag4 = rowData.profecssion != null;
					if (flag4)
					{
						int i = 0;
						int num = rowData.profecssion.Length;
						while (i < num)
						{
							bool flag5 = XBagDocument.IsProfMatched(rowData.profecssion[i]);
							if (flag5)
							{
								flag2 = true;
								break;
							}
							i++;
						}
					}
				}
				ixuisprite4.SetVisible(flag2);
				bool flag6 = flag2;
				if (flag6)
				{
					bool flag7 = rowData.needtype == 2U;
					if (flag7)
					{
						ixuisprite4.SetSprite("icon_yjs", "Social/Guild", false);
					}
					else
					{
						ixuisprite4.SetSprite("Recharge_tj", "ReCharge/ReCharge", false);
					}
				}
				bool flag8 = curGuildSkillLevel == 0U;
				if (flag8)
				{
					ixuisprite3.SetEnabled(false);
					ixuisprite.SetEnabled(false);
					ixuilabel.SetEnabled(false);
					ixuilabel2.SetEnabled(false);
					ixuilabel3.SetEnabled(false);
					ixuilabel4.SetEnabled(false);
				}
				else
				{
					ixuisprite3.SetEnabled(true);
					ixuisprite.SetEnabled(true);
					ixuilabel.SetEnabled(true);
					ixuilabel2.SetEnabled(true);
					ixuilabel3.SetEnabled(true);
					ixuilabel4.SetEnabled(true);
				}
				bool flag9 = this.m_showEffect && skillID == this._doc.CurrentSkillID;
				if (flag9)
				{
					this.m_showEffect = false;
					XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_qianghua_03", ixuisprite.gameObject.transform, Vector3.zero, Vector3.one, 1f, true, 2f, true);
				}
				bool flag10 = level < glevel;
				ixuilabel4.SetVisible(!flag10);
				ixuilabel2.SetVisible(!flag10);
				ixuilabel3.SetVisible(!flag10);
				ixuilabel5.SetVisible(flag10);
				transform.gameObject.SetActive(false);
				ixuisprite.SetSprite(rowData.icon, rowData.atlas, false);
				ixuilabel.SetText(rowData.name);
				ixuilabel2.SetText(string.Format("{0}/{1}", curGuildSkillLevel.ToString(), skillMaxLevel));
				ixuilabel3.SetText(string.Format(string.Format(rowData.currentLevelDescription, rowData.attribute[0, 1]), new object[0]));
				transform2.gameObject.SetActive(false);
				ixuisprite2.ID = (ulong)skillID;
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSkillClick));
			}
		}

		public void SetupDetailSkill()
		{
			uint currentSkillID = this._doc.CurrentSkillID;
			uint curGuildSkillLevel = this._doc.GetCurGuildSkillLevel(currentSkillID);
			uint skillMaxLevel = this._doc.GetSkillMaxLevel(currentSkillID);
			GuildSkillTable.RowData guildSkill = this._doc.GetGuildSkill(currentSkillID, curGuildSkillLevel);
			GuildSkillTable.RowData guildSkill2 = this._doc.GetGuildSkill(currentSkillID, curGuildSkillLevel + 1U);
			base.uiBehaviour.m_DetailSkillIcon.SetSprite(guildSkill.icon, guildSkill.atlas, false);
			base.uiBehaviour.m_DetailSkillName.SetText(guildSkill.name);
			base.uiBehaviour.m_DetailCurrLevel.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("XAttr_Level"), curGuildSkillLevel));
			base.uiBehaviour.m_DetailNextLevel.SetText((curGuildSkillLevel + 1U).ToString());
			base.uiBehaviour.m_DetailMaxLevel.SetText(skillMaxLevel.ToString());
			base.uiBehaviour.m_DetailCurrAttr.SetText(string.Format(guildSkill.currentLevelDescription, guildSkill.attribute[0, 1]));
			base.uiBehaviour.m_DetailNextAttr.SetText(guildSkill2.attribute[0, 1].ToString());
			base.uiBehaviour.m_RedPoint.gameObject.SetActive(false);
			string text = "";
			bool flag = false;
			bool flag2 = !flag && !this.TryCheckRedGuildLevel(guildSkill, curGuildSkillLevel, out text);
			if (flag2)
			{
				flag = true;
				base.uiBehaviour.m_DetailSkillName.SetText(guildSkill.name);
			}
			else
			{
				base.uiBehaviour.m_DetailSkillName.SetText(string.Format("{0}({1}/{2})", guildSkill.name, curGuildSkillLevel, skillMaxLevel));
			}
			bool flag3 = !flag && !this.TryCheckRoleLevel(guildSkill, curGuildSkillLevel, out text);
			if (flag3)
			{
			}
			base.uiBehaviour.m_DetailTip.SetText(text);
			bool flag4 = this._doc.GuildDoc.IHavePermission(GuildPermission.GPEM_STUDY_SKILL) && guildSkill.needtype == 1U;
			if (flag4)
			{
				base.uiBehaviour.m_DetailUpMaxLevel.SetVisible(true);
			}
			else
			{
				base.uiBehaviour.m_DetailUpMaxLevel.SetVisible(false);
			}
			string text2 = string.Empty;
			bool flag5 = curGuildSkillLevel < skillMaxLevel;
			bool flag6;
			if (flag5)
			{
				text2 = XStringDefineProxy.GetString("GUILD_SKILL_UPDATE");
				flag6 = false;
			}
			else
			{
				flag6 = true;
				uint num = XGuildDocument.GuildConfig.GetTotalStudyCount((int)guildSkill.glevel, (int)this._doc.GuildDoc.Level) + this._doc.GetGuildSkillInitLevel(currentSkillID);
				bool flag7 = skillMaxLevel < num;
				if (flag7)
				{
					text2 = XStringDefineProxy.GetString("GUILD_SKILL_STUDY_LEVEL_DOWN");
				}
				else
				{
					bool flag8 = this._doc.GuildDoc.Level < XGuildDocument.GuildConfig.MaxLevel;
					if (flag8)
					{
						text2 = XStringDefineProxy.GetString("GUILD_SKILL_GUILD_LEVEL_DOWN");
					}
					else
					{
						text2 = XStringDefineProxy.GetString("GUILD_SKILL_LEVEL_FULL");
					}
				}
			}
			base.uiBehaviour.m_LevelUpLabel.SetText(text2);
			base.uiBehaviour.m_LevelUp.SetGrey(!flag6);
			bool flag9 = this.TryCheckLevelUpCost(guildSkill, curGuildSkillLevel, out text);
			if (flag9)
			{
				base.uiBehaviour.m_DetailCost.SetVisible(false);
				base.uiBehaviour.m_DetailCostRed.SetVisible(true);
				base.uiBehaviour.m_DetailCostRed.InputText = text;
			}
			else
			{
				base.uiBehaviour.m_DetailCost.SetVisible(true);
				base.uiBehaviour.m_DetailCostRed.SetVisible(false);
				base.uiBehaviour.m_DetailCost.InputText = text;
			}
		}

		private bool TryCheckFullLevel(GuildSkillTable.RowData currData, uint skillLevel, out string strTemp)
		{
			strTemp = string.Empty;
			uint num = XGuildDocument.GuildConfig.GetTotalStudyCount((int)currData.glevel, (int)this._doc.GuildDoc.Level) + this._doc.GetGuildSkillInitLevel(currData.skillid);
			bool flag = skillLevel >= num;
			bool result;
			if (flag)
			{
				strTemp = XStringDefineProxy.GetString("GUILD_SKILL_LEVEL_FULL");
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		private bool TryCheckLevelUpCost(GuildSkillTable.RowData currData, uint skillLevel, out string strTemp)
		{
			strTemp = "";
			uint num = currData.need[0, 1];
			strTemp = string.Format("{0}{1}", XLabelSymbolHelper.FormatSmallIcon(22), num);
			return (ulong)num > (ulong)((long)((int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.GUILD_CONTRIBUTE)));
		}

		private bool TryCheckRoleLevel(GuildSkillTable.RowData currData, uint skillLevel, out string strTemp)
		{
			strTemp = "";
			bool flag = currData.roleLevel > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			bool result;
			if (flag)
			{
				strTemp = string.Format("{0}{1}: {2}\n", strTemp, XStringDefineProxy.GetString("NEED_PLAYER_LEVEL"), currData.glevel);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		private bool TryCheckRedGuildLevel(GuildSkillTable.RowData currData, uint skillLevel, out string strTemp)
		{
			uint glevel = currData.glevel;
			strTemp = "";
			bool flag = glevel > this._doc.GuildDoc.Level;
			bool result;
			if (flag)
			{
				strTemp = string.Format("{0}{1}: {2}\n", strTemp, XStringDefineProxy.GetString("NEED_GUILD_LEVEL"), glevel);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		private void RefreshSkillLight()
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			base.uiBehaviour.m_SkillPool.GetActiveList(list);
			for (int i = 0; i < list.Count; i++)
			{
				IXUISprite ixuisprite = list[i].GetComponent("XUISprite") as IXUISprite;
				bool flag = ixuisprite.ID == (ulong)this._doc.CurrentSkillID;
				if (flag)
				{
					list[i].transform.FindChild("Light").gameObject.SetActive(true);
				}
				else
				{
					list[i].transform.FindChild("Light").gameObject.SetActive(false);
				}
			}
			ListPool<GameObject>.Release(list);
		}

		private void RefreshGuildPoint()
		{
			base.uiBehaviour.m_GuildPoint.SetText(this._doc.BagDoc.VirtualItems[22].ToString());
		}

		private static int SkillSortCompare(uint skill1, uint skill2)
		{
			return skill1.CompareTo(skill2);
		}

		public XGuildSkillDocument _doc = null;

		public XGuildSkillStudyHandle _StudyHandle = null;

		private Transform m_studyHandlePanel = null;

		private bool m_showEffect = false;
	}
}
