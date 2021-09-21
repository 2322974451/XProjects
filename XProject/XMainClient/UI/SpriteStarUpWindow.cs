using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200185B RID: 6235
	internal class SpriteStarUpWindow : DlgHandlerBase
	{
		// Token: 0x17003989 RID: 14729
		// (get) Token: 0x060103B7 RID: 66487 RVA: 0x003EADA8 File Offset: 0x003E8FA8
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteStarUpWindow";
			}
		}

		// Token: 0x060103B8 RID: 66488 RVA: 0x003EADC0 File Offset: 0x003E8FC0
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this._SpriteAvatarHandler, base.PanelObject.transform.Find("AvatarHandlerParent"), true, this);
			Transform transform = base.PanelObject.transform.Find("Property/Label/TplCurrent");
			this.m_CurrAttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			transform = base.PanelObject.transform.Find("Property/Label/TplLast");
			this.m_LastAttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_StarUpBtn = (base.PanelObject.transform.Find("StarUpBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_StarUpText = (this.m_StarUpBtn.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
			this.m_Cost = (base.PanelObject.transform.Find("Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Close = (base.PanelObject.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_CurrSkill = base.PanelObject.transform.Find("Skill/SkillIconPos1/SkillTpl").gameObject;
			this.m_EffectParent = base.PanelObject.transform.Find("EffectParent");
			for (int i = 0; i < 4; i++)
			{
				this._lockList.Add(true);
			}
			this.m_LastEmpty = base.PanelObject.transform.Find("Property/Label/LastEmpty").gameObject;
			this.m_Progress = (base.PanelObject.transform.Find("Process/Slider").GetComponent("XUIProgress") as IXUIProgress);
			this.m_ProgressValue = (base.PanelObject.transform.Find("Process/ProcessValue").GetComponent("XUILabel") as IXUILabel);
			this.m_HelpBtn = (base.PanelObject.transform.Find("Process/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_HelpTips = base.PanelObject.transform.Find("Process/Content").gameObject;
			this.m_HelpTips.SetActive(false);
			this.m_RebornBtn = (base.PanelObject.transform.Find("RebornBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_TrainFx = base.PanelObject.transform.Find("Bg/Bg/P/Fx").gameObject;
			this.m_TrainFx.SetActive(false);
			this.m_MaxFx = base.PanelObject.transform.Find("Process/Slider/Overlay/UI_SpriteStarUpWindow_Clip03").gameObject;
			this._lockCost = XSingleton<XGlobalConfig>.singleton.GetSequence4List("SpriteTrainCost", false);
			this._lockMaxNum = XSingleton<XGlobalConfig>.singleton.GetInt("SpriteTrainNoToChooseMaxNum");
		}

		// Token: 0x060103B9 RID: 66489 RVA: 0x003EB0E4 File Offset: 0x003E92E4
		protected override void OnShow()
		{
			base.OnShow();
			this.LastAttrList.Clear();
			this.LastValueList.Clear();
			for (int i = 0; i < this._lockList.Count; i++)
			{
				this._lockList[i] = true;
			}
			this._SpriteAvatarHandler.SetVisible(true);
			this._SpriteAvatarHandler.SetSpriteInfoByIndex(DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.CurrentClick, 0, false, true);
			this.SetInfo(DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.CurrentClick);
		}

		// Token: 0x060103BA RID: 66490 RVA: 0x003EB17C File Offset: 0x003E937C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_StarUpBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnStarUpBtnClick));
			this.m_RebornBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRebornBtnClick));
			this.m_HelpBtn.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnHelpBtnPress));
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x060103BB RID: 66491 RVA: 0x003EB1F4 File Offset: 0x003E93F4
		protected override void OnHide()
		{
			base.OnHide();
			this.m_TrainFx.SetActive(false);
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.SetAvatar();
			bool flag = this._fxFirework != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fxFirework, true);
				this._fxFirework = null;
			}
			this._SpriteAvatarHandler.SetVisible(false);
		}

		// Token: 0x060103BC RID: 66492 RVA: 0x003EB25C File Offset: 0x003E945C
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this._SpriteAvatarHandler);
			bool flag = this._fxFirework != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fxFirework, true);
				this._fxFirework = null;
			}
			base.OnUnload();
		}

		// Token: 0x060103BD RID: 66493 RVA: 0x003EB2A8 File Offset: 0x003E94A8
		public void OnServerReturn(SpriteType type)
		{
			this.SetInfo(this.CurrentClick);
			this.SetAvatar();
			bool flag = type == SpriteType.Sprite_Evolution;
			if (flag)
			{
				this.ShowStarUpSuccessEffect();
			}
			bool flag2 = type == SpriteType.Sprite_Train;
			if (flag2)
			{
				this.m_TrainFx.SetActive(false);
				this.m_TrainFx.SetActive(true);
			}
		}

		// Token: 0x060103BE RID: 66494 RVA: 0x003EB2FE File Offset: 0x003E94FE
		public void SetAvatar()
		{
			this._SpriteAvatarHandler.SetSpriteInfoByIndex(this.CurrentClick, 0, false, true);
		}

		// Token: 0x060103BF RID: 66495 RVA: 0x003EB318 File Offset: 0x003E9518
		private void SetInfo(int index)
		{
			this.CurrentClick = index;
			SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(this._doc.SpriteList[index].SpriteID);
			SpriteInfo spriteInfo = this._doc.SpriteList[index];
			SpriteEvolution.RowData rowData = null;
			bool flag = spriteInfo.EvolutionLevel >= XSpriteSystemDocument.MAXSTARLEVEL[(int)this._doc.GetSpriteQuality(index)];
			bool flag2 = !flag;
			if (flag2)
			{
				rowData = this._doc.GetStarUpData(bySpriteID.SpriteQuality, spriteInfo.EvolutionLevel);
			}
			bool flag3 = rowData != null;
			if (flag3)
			{
				this._currProcess = spriteInfo.TrainExp;
				this._needProcess = rowData.TrainExp[1];
			}
			else
			{
				this._currProcess = 1U;
				this._needProcess = 1U;
			}
			this.m_MaxFx.SetActive(this._currProcess >= this._needProcess);
			this.m_Cost.SetVisible(this._currProcess < this._needProcess);
			this.m_StarUpBtn.SetGrey(!flag && ((this._currProcess < this._needProcess && this.CostEnough(rowData, bySpriteID)) || (this._currProcess >= this._needProcess && this.CanStarUp(rowData))));
			this.m_RebornBtn.SetEnabled(this._currProcess != 0U || spriteInfo.EvolutionLevel > 0U);
			this.m_StarUpText.SetText(XStringDefineProxy.GetString((this._currProcess < this._needProcess) ? "SpriteTrainText" : "SpriteStarUpText"));
			bool flag4 = !flag;
			if (flag4)
			{
				string arg = string.Format("{0}X{1}", XLabelSymbolHelper.FormatSmallIcon((int)rowData.EvolutionCost[0]), rowData.EvolutionCost[1]);
				bool flag5 = this._lockCost[(int)(bySpriteID.SpriteQuality - 1U), this.GetUnLockNum() + 1] != 0;
				if (flag5)
				{
					arg = string.Format("{0} {1}X{2}", arg, XLabelSymbolHelper.FormatSmallIcon(this._lockCost[(int)(bySpriteID.SpriteQuality - 1U), 0]), this._lockCost[(int)(bySpriteID.SpriteQuality - 1U), this.GetUnLockNum() + 1]);
				}
				this.m_Cost.InputText = string.Format(XStringDefineProxy.GetString("SpriteCostText"), arg);
			}
			else
			{
				this.m_Cost.InputText = XStringDefineProxy.GetString("SpriteStarMaxTips");
			}
			this.SetSkillIcon(this.m_CurrSkill, spriteInfo.SkillID, true, spriteInfo.EvolutionLevel);
			bool flag6 = flag;
			if (flag6)
			{
				this.m_ProgressValue.SetText(XStringDefineProxy.GetString("SpriteStarMaxTips"));
				this.m_Progress.value = 1f;
			}
			else
			{
				this.m_ProgressValue.SetText(string.Format("{0}/{1}", this._currProcess, this._needProcess));
				this.m_Progress.value = this._currProcess * 1f / this._needProcess;
			}
			this.m_LastAttrPool.ReturnAll(false);
			bool flag7 = this.LastAttrList.Count == 0;
			Vector3 tplPos;
			float num;
			if (flag7)
			{
				this.m_LastEmpty.SetActive(true);
			}
			else
			{
				this.m_LastEmpty.SetActive(false);
				tplPos = this.m_LastAttrPool.TplPos;
				num = tplPos.y + ((float)this.LastAttrList.Count - 1f) / 2f * (float)this.m_LastAttrPool.TplHeight;
				for (int i = 0; i < this.LastAttrList.Count; i++)
				{
					GameObject gameObject = this.m_LastAttrPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(tplPos.x, num - (float)(i * this.m_LastAttrPool.TplHeight));
					IXUILabel ixuilabel = gameObject.transform.Find("Attr").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(this.GetAttrName((uint)this.LastAttrList[i]));
					IXUILabel ixuilabel2 = gameObject.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(this.LastValueList[i].ToString());
				}
			}
			this.m_CurrAttrPool.ReturnAll(false);
			tplPos = this.m_CurrAttrPool.TplPos;
			num = tplPos.y + ((float)spriteInfo.AttrID.Count - 2f) / 2f * (float)this.m_CurrAttrPool.TplHeight;
			Dictionary<uint, uint> dictionary = new Dictionary<uint, uint>();
			for (int j = 0; j < spriteInfo.ThisLevelEvoAttrID.Count; j++)
			{
				dictionary[spriteInfo.ThisLevelEvoAttrID[j]] = (uint)spriteInfo.ThisLevelEvoAttrValue[j];
			}
			int num2 = 0;
			for (int k = 0; k < spriteInfo.AttrID.Count; k++)
			{
				bool flag8 = k == 1;
				if (!flag8)
				{
					GameObject gameObject2 = this.m_CurrAttrPool.FetchGameObject(false);
					gameObject2.transform.localPosition = new Vector3(tplPos.x, num - (float)(num2 * this.m_CurrAttrPool.TplHeight));
					IXUISprite ixuisprite = gameObject2.transform.Find("Locker").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((long)num2);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLockClick));
					GameObject gameObject3 = gameObject2.transform.Find("Locker/Locked").gameObject;
					gameObject3.SetActive(this._lockList[num2]);
					IXUILabel ixuilabel3 = gameObject2.transform.Find("Attr").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(this.GetAttrName(spriteInfo.AttrID[k]));
					IXUILabel ixuilabel4 = gameObject2.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
					uint num3 = 0U;
					dictionary.TryGetValue(spriteInfo.AttrID[k], out num3);
					ixuilabel4.SetText(num3.ToString());
					num2++;
				}
			}
		}

		// Token: 0x060103C0 RID: 66496 RVA: 0x003EB98C File Offset: 0x003E9B8C
		private void OnLockClick(IXUISprite iSp)
		{
			bool flag = this._lockList[(int)iSp.ID] && this.GetUnLockNum() >= this._lockMaxNum;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteStarUpLockMaxTips"), "fece00");
			}
			else
			{
				this._lockList[(int)iSp.ID] = !this._lockList[(int)iSp.ID];
				GameObject gameObject = iSp.gameObject.transform.Find("Locked").gameObject;
				gameObject.SetActive(this._lockList[(int)iSp.ID]);
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString(this._lockList[(int)iSp.ID] ? "SpriteStarUpLock" : "SpriteStarUpUnLock"), "fece00");
				SpriteInfo spriteInfo = this._doc.SpriteList[this.CurrentClick];
				bool flag2 = spriteInfo.EvolutionLevel < XSpriteSystemDocument.MAXSTARLEVEL[(int)this._doc.GetSpriteQuality(this.CurrentClick)];
				if (flag2)
				{
					SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(this._doc.SpriteList[this.CurrentClick].SpriteID);
					SpriteEvolution.RowData starUpData = this._doc.GetStarUpData(bySpriteID.SpriteQuality, this._doc.SpriteList[this.CurrentClick].EvolutionLevel);
					string arg = string.Format("{0}X{1}", XLabelSymbolHelper.FormatSmallIcon((int)starUpData.EvolutionCost[0]), starUpData.EvolutionCost[1]);
					bool flag3 = this._lockCost[(int)(bySpriteID.SpriteQuality - 1U), this.GetUnLockNum() + 1] != 0;
					if (flag3)
					{
						arg = string.Format("{0} {1}X{2}", arg, XLabelSymbolHelper.FormatSmallIcon(this._lockCost[(int)(bySpriteID.SpriteQuality - 1U), 0]), this._lockCost[(int)(bySpriteID.SpriteQuality - 1U), this.GetUnLockNum() + 1]);
					}
					this.m_Cost.InputText = string.Format(XStringDefineProxy.GetString("SpriteCostText"), arg);
				}
			}
		}

		// Token: 0x060103C1 RID: 66497 RVA: 0x003EBBD4 File Offset: 0x003E9DD4
		private bool CanStarUp(SpriteEvolution.RowData cost)
		{
			bool flag = cost == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Get SpriteEvolution cost data error.", null, null, null, null, null);
			}
			bool flag2 = this._doc.SpriteList[this.CurrentClick].Level < (uint)cost.LevelLimit;
			return !flag2;
		}

		// Token: 0x060103C2 RID: 66498 RVA: 0x003EBC30 File Offset: 0x003E9E30
		private bool CostEnough(SpriteEvolution.RowData cost, SpriteTable.RowData data)
		{
			bool flag = cost == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Get SpriteEvolution cost data error.", null, null, null, null, null);
			}
			bool flag2 = XBagDocument.BagDoc.GetItemCount((int)cost.EvolutionCost[0]) < (ulong)cost.EvolutionCost[1];
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				bool flag3 = XBagDocument.BagDoc.GetItemCount(this._lockCost[(int)(data.SpriteQuality - 1U), 0]) < (ulong)this._lockCost[(int)(data.SpriteQuality - 1U), this.GetUnLockNum() + 1];
				result = !flag3;
			}
			return result;
		}

		// Token: 0x060103C3 RID: 66499 RVA: 0x003EBCD4 File Offset: 0x003E9ED4
		private void SetSkillIcon(GameObject go, uint skillID, bool mainSkill = false, uint evolutionLevel = 0U)
		{
			IXUISprite ixuisprite = go.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.FindChild("Zhu").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite2 = go.transform.FindChild("Frame").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)evolutionLevel;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSkillIconClicked));
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteSkill.RowData spriteSkillData = specificDocument.GetSpriteSkillData((short)skillID, mainSkill, evolutionLevel);
			bool flag = spriteSkillData != null;
			if (flag)
			{
				ixuisprite.SetSprite(spriteSkillData.Icon);
			}
			ixuilabel.SetVisible(mainSkill);
			ixuisprite2.SetVisible(!mainSkill);
			bool flag2 = !mainSkill;
			if (flag2)
			{
				ixuisprite2.SetSprite(string.Format("kuang_zq0{0}", spriteSkillData.SkillQuality));
			}
			ixuilabel2.SetText(string.Format("[b]Lv.{0}[-]", evolutionLevel + 1U));
			ixuilabel2.SetVisible(mainSkill);
		}

		// Token: 0x060103C4 RID: 66500 RVA: 0x003EBE10 File Offset: 0x003EA010
		private void OnSkillIconClicked(IXUISprite obj)
		{
			SpriteInfo spriteInfo = this._doc.SpriteList[this.CurrentClick];
			uint level = (uint)obj.ID;
			DlgBase<XSpriteSkillTipDlg, XSpriteSkillTipBehaviour>.singleton.ItemSelector.Select(obj);
			DlgBase<XSpriteSkillTipDlg, XSpriteSkillTipBehaviour>.singleton.ShowSpriteSkill(spriteInfo.SkillID, true, level);
		}

		// Token: 0x060103C5 RID: 66501 RVA: 0x003EBE64 File Offset: 0x003EA064
		private int GetUnLockNum()
		{
			int num = 0;
			for (int i = 0; i < this._lockList.Count; i++)
			{
				bool flag = !this._lockList[i];
				if (flag)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060103C6 RID: 66502 RVA: 0x003EBEAC File Offset: 0x003EA0AC
		public void OnStarUpBtnClick(IXUISprite btn)
		{
			bool flag = this._doc.SpriteList[this.CurrentClick].EvolutionLevel >= XSpriteSystemDocument.MAXSTARLEVEL[(int)this._doc.GetSpriteQuality(this.CurrentClick)];
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteStarMaxTips"), "fece00");
			}
			else
			{
				SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(this._doc.SpriteList[this.CurrentClick].SpriteID);
				SpriteEvolution.RowData starUpData = this._doc.GetStarUpData(bySpriteID.SpriteQuality, this._doc.SpriteList[this.CurrentClick].EvolutionLevel);
				SpriteInfo spriteInfo = this._doc.SpriteList[this.CurrentClick];
				bool flag2 = this._currProcess < this._needProcess;
				if (flag2)
				{
					bool flag3 = !this.CostEnough(starUpData, bySpriteID);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_CHANGEPRO_ITEMLIMIT"), "fece00");
					}
					else
					{
						int num = 0;
						List<uint> list = new List<uint>();
						string text = "";
						for (int i = 0; i < spriteInfo.AttrID.Count; i++)
						{
							bool flag4 = i == 1;
							if (!flag4)
							{
								bool flag5 = !this._lockList[num];
								if (flag5)
								{
									list.Add(spriteInfo.AttrID[i]);
									text = string.Format("{0} {1}", text, this.GetAttrName(spriteInfo.AttrID[i]));
								}
								num++;
							}
						}
						bool flag6 = list.Count == 0 || DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_SPRITE_TRAIN);
						if (flag6)
						{
							XSingleton<XDebug>.singleton.AddLog("Train!", null, null, null, null, null, XDebugColor.XDebug_None);
							this._doc.QueryTrain(this.CurrentClick, list);
						}
						else
						{
							string format = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SpriteTrainCostTipe"));
							ItemList.RowData itemConf = XBagDocument.GetItemConf(this._lockCost[(int)(bySpriteID.SpriteQuality - 1U), 0]);
							string label = string.Format(format, this._lockCost[(int)(bySpriteID.SpriteQuality - 1U), this.GetUnLockNum() + 1], itemConf.ItemName[0], text);
							string @string = XStringDefineProxy.GetString("COMMON_OK");
							string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
							XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.OnTrainSure), null, false, XTempTipDefine.OD_SPRITE_TRAIN, 50);
						}
					}
				}
				else
				{
					bool flag7 = this._doc.SpriteList[this.CurrentClick].Level < (uint)starUpData.LevelLimit;
					if (flag7)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("SpriteStarUpLevelTips", new object[]
						{
							starUpData.LevelLimit
						}), new object[0]), "fece00");
					}
					else
					{
						string label2 = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SpriteStarUpSure"));
						string string3 = XStringDefineProxy.GetString("COMMON_OK");
						string string4 = XStringDefineProxy.GetString("COMMON_CANCEL");
						XSingleton<UiUtility>.singleton.ShowModalDialog(label2, string3, string4, new ButtonClickEventHandler(this.OnStarUpSure));
					}
				}
			}
		}

		// Token: 0x060103C7 RID: 66503 RVA: 0x003EC210 File Offset: 0x003EA410
		private bool OnStarUpSure(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XDebug>.singleton.AddLog("StarUp!", null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.QueryStarUp(this.CurrentClick);
			return true;
		}

		// Token: 0x060103C8 RID: 66504 RVA: 0x003EC258 File Offset: 0x003EA458
		private bool OnTrainSure(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			SpriteInfo spriteInfo = this._doc.SpriteList[this.CurrentClick];
			int num = 0;
			List<uint> list = new List<uint>();
			for (int i = 0; i < spriteInfo.AttrID.Count; i++)
			{
				bool flag = i == 1;
				if (!flag)
				{
					bool flag2 = !this._lockList[num];
					if (flag2)
					{
						list.Add(spriteInfo.AttrID[i]);
					}
					num++;
				}
			}
			XSingleton<XDebug>.singleton.AddLog("Train!", null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.QueryTrain(this.CurrentClick, list);
			return true;
		}

		// Token: 0x060103C9 RID: 66505 RVA: 0x003EC318 File Offset: 0x003EA518
		private void OnRebornBtnClick(IXUISprite iSp)
		{
			bool flag = this.CurrentClick >= this._doc.SpriteList.Count;
			if (!flag)
			{
				bool flag2 = this._doc.SpriteList[this.CurrentClick].TrainExp == 0U;
				if (flag2)
				{
					string message = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SpriteRebornToZeroTips"));
					XSingleton<UiUtility>.singleton.ShowModalDialog(message, new ButtonClickEventHandler(this.OnRebornToZeroSure));
				}
				else
				{
					SpriteTable.RowData bySpriteID = this._doc._SpriteTable.GetBySpriteID(this._doc.SpriteList[this.CurrentClick].SpriteID);
					SpriteEvolution.RowData starUpData = this._doc.GetStarUpData(bySpriteID.SpriteQuality, this._doc.SpriteList[this.CurrentClick].EvolutionLevel);
					string format = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SpriteRebornTips"));
					string text = string.Format("{0}{1}", XLabelSymbolHelper.FormatSmallIcon((int)starUpData.ResetTrainCost[0, 0]), starUpData.ResetTrainCost[0, 1]);
					string text2 = string.Format("{0}{1}", XLabelSymbolHelper.FormatSmallIcon((int)starUpData.ResetTrainCost[1, 0]), starUpData.ResetTrainCost[1, 1]);
					string text3 = string.Format(format, text, text2);
					string @string = XStringDefineProxy.GetString("SpriteRebornText");
					DlgBase<ModalDlg2, ModalDlg2Behaviour>.singleton.InitShow(text3, new ButtonClickEventHandler(this.OnRebornSure1), new ButtonClickEventHandler(this.OnRebornSure2), text, text2, @string, @string);
				}
			}
		}

		// Token: 0x060103CA RID: 66506 RVA: 0x003EC4BC File Offset: 0x003EA6BC
		private bool OnRebornSure1(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("ResetTrain1!", null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.QueryResetTrain(this.CurrentClick, SpriteType.Sprite_ResetTrain, 0U);
			return true;
		}

		// Token: 0x060103CB RID: 66507 RVA: 0x003EC4FC File Offset: 0x003EA6FC
		private bool OnRebornSure2(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("ResetTrain2!", null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.QueryResetTrain(this.CurrentClick, SpriteType.Sprite_ResetTrain, 1U);
			return true;
		}

		// Token: 0x060103CC RID: 66508 RVA: 0x003EC53C File Offset: 0x003EA73C
		private bool OnRebornToZeroSure(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XDebug>.singleton.AddLog("Rebirth!", null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.QueryResetTrain(this.CurrentClick, SpriteType.Sprite_Rebirth, 0U);
			return true;
		}

		// Token: 0x060103CD RID: 66509 RVA: 0x003EC588 File Offset: 0x003EA788
		private void OnHelpBtnPress(IXUIButton btn, bool state)
		{
			bool flag = this.m_HelpTips.activeInHierarchy != state;
			if (flag)
			{
				this.m_HelpTips.SetActive(state);
			}
		}

		// Token: 0x060103CE RID: 66510 RVA: 0x003EC5B8 File Offset: 0x003EA7B8
		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x060103CF RID: 66511 RVA: 0x003EC5D4 File Offset: 0x003EA7D4
		public void ShowStarUpSuccessEffect()
		{
			bool flag = this._fxFirework != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fxFirework, true);
			}
			this._fxFirework = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_jl_level", this.m_EffectParent, Vector3.zero, Vector3.one, 1f, false, 3f, true);
		}

		// Token: 0x060103D0 RID: 66512 RVA: 0x003EC634 File Offset: 0x003EA834
		private string GetAttrName(uint AttrID)
		{
			bool flag = AttrID == 11U;
			string @string;
			if (flag)
			{
				@string = XStringDefineProxy.GetString("SpriteStarUpAttr");
			}
			else
			{
				string key = string.Format("Sprite_{0}", (XAttributeDefine)AttrID);
				@string = XStringDefineProxy.GetString(key);
			}
			return @string;
		}

		// Token: 0x04007486 RID: 29830
		private XSpriteSystemDocument _doc;

		// Token: 0x04007487 RID: 29831
		public XUIPool m_CurrAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007488 RID: 29832
		public XUIPool m_LastAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007489 RID: 29833
		public XSpriteAvatarHandler _SpriteAvatarHandler;

		// Token: 0x0400748A RID: 29834
		public IXUISprite m_StarUpBtn;

		// Token: 0x0400748B RID: 29835
		public IXUILabel m_StarUpText;

		// Token: 0x0400748C RID: 29836
		public IXUILabelSymbol m_Cost;

		// Token: 0x0400748D RID: 29837
		public IXUIButton m_Close;

		// Token: 0x0400748E RID: 29838
		public GameObject m_CurrSkill;

		// Token: 0x0400748F RID: 29839
		private Transform m_EffectParent;

		// Token: 0x04007490 RID: 29840
		private XFx _fxFirework;

		// Token: 0x04007491 RID: 29841
		public int CurrentClick;

		// Token: 0x04007492 RID: 29842
		public List<int> LastAttrList = new List<int>();

		// Token: 0x04007493 RID: 29843
		public List<int> LastValueList = new List<int>();

		// Token: 0x04007494 RID: 29844
		private List<bool> _lockList = new List<bool>();

		// Token: 0x04007495 RID: 29845
		private SeqList<int> _lockCost;

		// Token: 0x04007496 RID: 29846
		private int _lockMaxNum;

		// Token: 0x04007497 RID: 29847
		private GameObject m_LastEmpty;

		// Token: 0x04007498 RID: 29848
		private IXUIProgress m_Progress;

		// Token: 0x04007499 RID: 29849
		private IXUILabel m_ProgressValue;

		// Token: 0x0400749A RID: 29850
		private IXUIButton m_HelpBtn;

		// Token: 0x0400749B RID: 29851
		private GameObject m_HelpTips;

		// Token: 0x0400749C RID: 29852
		public IXUISprite m_RebornBtn;

		// Token: 0x0400749D RID: 29853
		private GameObject m_TrainFx;

		// Token: 0x0400749E RID: 29854
		private GameObject m_MaxFx;

		// Token: 0x0400749F RID: 29855
		private uint _currProcess;

		// Token: 0x040074A0 RID: 29856
		private uint _needProcess;
	}
}
