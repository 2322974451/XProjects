using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HeroAttrDlg : DlgBase<HeroAttrDlg, HeroAttrBehaviour>
	{

		public override bool autoload
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
				return "Battle/HeroAttrDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			for (int i = 0; i < 3; i++)
			{
				base.uiBehaviour.m_Tab[i].ID = (ulong)((long)i);
				base.uiBehaviour.m_Tab[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public void ShowByType(SceneType type, uint heroID)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			if (!flag)
			{
				bool flag2 = heroID == 0U;
				if (!flag2)
				{
					this._type = type;
					this.SetVisible(true, true);
					base.uiBehaviour.m_Tab[0].ForceSetFlag(true);
					base.uiBehaviour.m_Tab[1].ForceSetFlag(false);
					base.uiBehaviour.m_Tab[2].ForceSetFlag(false);
					this.SetHeroFrameState(true);
				}
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		public uint GetHeroID()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				bool flag2 = !XEntity.ValideEntity(XSingleton<XEntityMgr>.singleton.Player.Transformer);
				if (flag2)
				{
					result = 0U;
				}
				else
				{
					uint typeID = XSingleton<XEntityMgr>.singleton.Player.Transformer.TypeID;
					int num = (this._type == SceneType.SCENE_HEROBATTLE) ? 0 : 2;
					for (int i = 0; i < this._doc.OverWatchReader.Table.Length; i++)
					{
						bool flag3 = this._doc.OverWatchReader.Table[i].StatisticsID[num] == typeID;
						if (flag3)
						{
							return this._doc.OverWatchReader.Table[i].HeroID;
						}
					}
					result = 0U;
				}
			}
			return result;
		}

		private bool OnTabClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.SetHeroFrameState(icb.ID == 0UL);
				this.SetSkillFrameState(icb.ID == 1UL);
				this.SetGamePlayState(icb.ID == 2UL);
				result = true;
			}
			return result;
		}

		private void SetHeroFrameState(bool state)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			if (!flag)
			{
				base.uiBehaviour.m_HeroFrame.SetActive(state);
				if (state)
				{
					uint heroID = this.GetHeroID();
					bool flag2 = heroID == 0U;
					if (flag2)
					{
						this.SetVisible(false, true);
						XSingleton<XDebug>.singleton.AddLog("Show HeroAttrDlg by HeroID = 0 Error.", null, null, null, null, null, XDebugColor.XDebug_None);
					}
					else
					{
						OverWatchTable.RowData byHeroID = this._doc.OverWatchReader.GetByHeroID(heroID);
						base.uiBehaviour.m_HeroIcon.SetSprite(byHeroID.Icon, byHeroID.IconAtlas, false);
						base.uiBehaviour.m_HeroName.SetText(byHeroID.Name);
						base.uiBehaviour.m_HeroSmallTips.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn((this._type == SceneType.SCENE_HEROBATTLE) ? byHeroID.HeroUseTips : byHeroID.MobaUseTips));
						base.uiBehaviour.m_DescScrollView.SetPosition(0f);
						base.uiBehaviour.m_AttrPool.ReturnAll(false);
						List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("HeroAttrShow");
						for (int i = 0; i < intList.Count; i++)
						{
							GameObject gameObject = base.uiBehaviour.m_AttrPool.FetchGameObject(false);
							gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_AttrPool.TplPos.x + (float)(base.uiBehaviour.m_AttrPool.TplWidth * (i % 2)), base.uiBehaviour.m_AttrPool.TplPos.y - (float)(base.uiBehaviour.m_AttrPool.TplHeight * (i / 2)));
							IXUILabel ixuilabel = gameObject.transform.Find("Attr").GetComponent("XUILabel") as IXUILabel;
							IXUILabel ixuilabel2 = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
							ixuilabel2.SetText(string.Format("{0}:", XStringDefineProxy.GetString(string.Format("HeroAttr_{0}", intList[i]))));
							ixuilabel.SetText(((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr((XAttributeDefine)intList[i])).ToString());
						}
					}
				}
			}
		}

		private void SetSkillFrameState(bool state)
		{
			base.uiBehaviour.m_SkillFrame.SetActive(state);
			if (state)
			{
				uint heroID = this.GetHeroID();
				bool flag = heroID == 0U;
				if (flag)
				{
					this.SetVisible(false, true);
					XSingleton<XDebug>.singleton.AddLog("Show HeroAttrDlg by HeroID = 0 Error.", null, null, null, null, null, XDebugColor.XDebug_None);
				}
				else
				{
					OverWatchTable.RowData byHeroID = this._doc.OverWatchReader.GetByHeroID(heroID);
					uint num = byHeroID.StatisticsID[(this._type == SceneType.SCENE_HEROBATTLE) ? 0 : 2];
					uint presentID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(num).PresentID;
					XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID);
					int num2 = (this._type == SceneType.SCENE_HEROBATTLE) ? 5 : 4;
					List<uint> list = new List<uint>();
					int num3 = 0;
					while (list.Count < num2 && num3 < byPresentID.OtherSkills.Length)
					{
						bool flag2 = string.IsNullOrEmpty(byPresentID.OtherSkills[num3]) || byPresentID.OtherSkills[num3] == "E";
						if (!flag2)
						{
							list.Add(XSingleton<XSkillEffectMgr>.singleton.GetSkillID(byPresentID.OtherSkills[num3], num));
						}
						num3++;
					}
					base.uiBehaviour.m_SkillPool.ReturnAll(false);
					for (int i = 0; i < list.Count; i++)
					{
						uint num4 = 0U;
						bool flag3 = this._type == SceneType.SCENE_MOBA;
						if (flag3)
						{
							XBattleSkillDocument.SkillLevelDict.TryGetValue(list[i], out num4);
						}
						SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(list[i], num4, XSingleton<XEntityMgr>.singleton.Player.SkillCasterTypeID);
						GameObject gameObject = base.uiBehaviour.m_SkillPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_SkillPool.TplPos.x + (float)(i * base.uiBehaviour.m_SkillPool.TplWidth), base.uiBehaviour.m_SkillPool.TplPos.y);
						IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
						IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel2 = gameObject.transform.Find("CD").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel3 = gameObject.transform.Find("MP").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel4 = gameObject.transform.Find("Desc").GetComponent("XUILabel") as IXUILabel;
						ixuisprite.SetSprite(skillConfig.Icon, skillConfig.Atlas, false);
						ixuilabel.SetText(skillConfig.ScriptName);
						bool flag4 = this._type == SceneType.SCENE_MOBA && num4 == 0U;
						if (flag4)
						{
							ixuilabel3.SetText(XStringDefineProxy.GetString("NOT_LEARN"));
							ixuilabel2.SetText(XStringDefineProxy.GetString("NOT_LEARN"));
						}
						else
						{
							ixuilabel3.SetText((skillConfig.CostMP[0] + skillConfig.CostMP[1] * num4).ToString());
							bool flag5 = XSingleton<XEntityMgr>.singleton.Player != null && XEntity.ValideEntity(XSingleton<XEntityMgr>.singleton.Player.Transformer);
							string text;
							if (flag5)
							{
								text = string.Format("{0}s", Math.Round((double)XSkillMgr.GetCD(XSingleton<XEntityMgr>.singleton.Player.Transformer, skillConfig.SkillScript, num4) + 0.01, 1));
							}
							else
							{
								text = "0s";
							}
							ixuilabel2.SetText(text);
						}
						ixuilabel4.SetText(skillConfig.CurrentLevelDescription);
						bool flag6 = i == list.Count - 1;
						if (flag6)
						{
							gameObject.transform.Find("line").gameObject.SetActive(false);
						}
					}
					base.uiBehaviour.m_ScrollView.SetPosition(0f);
				}
			}
		}

		private void SetGamePlayState(bool state)
		{
			base.uiBehaviour.m_GamePlayFrame.SetActive(state);
			if (state)
			{
				base.uiBehaviour.m_GamePlayTips.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString(string.Format("HeroGamePlay_{0}", XFastEnumIntEqualityComparer<SceneType>.ToInt(this._type)))));
				base.uiBehaviour.m_GamePlayScrollView.SetPosition(0f);
			}
		}

		private XHeroBattleDocument _doc;

		private SceneType _type;
	}
}
