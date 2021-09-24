using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HeroBattleSkillHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/HeroBattleSkill";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
			this._heroDoc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			this._doc.m_HeroBattleSkillHandler = this;
			this._doc.CreateSkillBlackHouse();
			this._isBattleScene = (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall);
			this.m_CountDown = (base.PanelObject.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_CountDownTips = (this.m_CountDown.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.m_Back = base.PanelObject.transform.Find("Back").gameObject;
			Transform transform = base.PanelObject.transform.Find("ShowFrame");
			this.m_ShowFrame = transform.gameObject;
			this.m_BuyBtn = (transform.Find("BuyBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_OKBtn = (transform.Find("OKBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_PlayBtn = (transform.Find("PlayTs/Play").GetComponent("XUISprite") as IXUISprite);
			this.m_CloseBtn = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Snapshot = (transform.Find("Snapshot").GetComponent("XUITexture") as IXUITexture);
			transform = base.PanelObject.transform.Find("ShowFrame");
			this.m_HeroName = (transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillName = (transform.Find("SkillDesc/SkillName").GetComponent("XUILabel") as IXUILabel);
			this.m_SkillDesc = (transform.Find("SkillDesc/SkillDesc").GetComponent("XUILabel") as IXUILabel);
			this.m_Panel = (base.PanelObject.transform.Find("ScrollView").GetComponent("XUIPanel") as IXUIPanel);
			this._FxTs = base.PanelObject.transform.Find("FxTs");
			transform = base.PanelObject.transform.Find("ScrollView/Tpl");
			IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
			bool flag = this._isBattleScene && ixuisprite.spriteHeight * ((this._heroDoc.OverWatchReader.Table.Length + 1) / 2) > 640;
			if (flag)
			{
				transform.gameObject.transform.localPosition = new Vector3(transform.gameObject.transform.localPosition.x, transform.gameObject.transform.localPosition.y + 64f);
			}
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			transform = base.PanelObject.transform.Find("ShowFrame/ShowSkill/Tpl");
			this.m_SkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.SetupTabs();
			this._showRefresh = false;
			this._battleFirstClick = true;
			this.m_BoxC = (base.PanelObject.transform.Find("Box").GetComponent("XUISprite") as IXUISprite);
			bool isBattleScene = this._isBattleScene;
			if (isBattleScene)
			{
				this.m_Panel.ClipRange = new Vector4(0f, 0f, 300f, 640f);
				this.m_CountDown.SetVisible(true);
				this._doc.IsPreViewShow = true;
				this.m_ShowFrame.SetActive(false);
				this.m_Back.SetActive(true);
				this.m_BoxC.SetVisible(true);
				this.m_HeroBattleTeamHandler = DlgHandlerBase.EnsureCreate<HeroBattleTeamHandler>(ref this.m_HeroBattleTeamHandler, base.PanelObject.transform.Find("TeamTs"), false, null);
			}
			else
			{
				this.SetSkillPreViewState(false, 0);
				this.m_BuyBtn.SetVisible(false);
				this.m_OKBtn.SetVisible(false);
				this.m_CountDown.SetVisible(false);
				this.m_Panel.ClipRange = new Vector4(0f, -32f, 300f, 586f);
				this.m_Back.SetActive(false);
				this.m_BoxC.SetVisible(false);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			this.m_PlayBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPlayBtnClick));
			this.m_OKBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKBtnClick));
			this.m_BuyBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this.skillPreView == null;
			if (flag)
			{
				this.skillPreView = new RenderTexture(600, 338, 1, 0, 0);
				this.skillPreView.name = "SkillPreview";
				this.skillPreView.autoGenerateMips = false;
				this.skillPreView.Create();
			}
			this.m_Snapshot.SetRuntimeTex(this.skillPreView, true);
			this._doc.SetSkillPreviewTexture(this.skillPreView);
			this.SetUVRectangle();
			bool flag2 = this._showRefresh && this.LastSelectSprite != null;
			if (flag2)
			{
				this._showRefresh = false;
				this.OnTabClick(this.LastSelectSprite);
			}
			bool flag3 = this.m_HeroBattleTeamHandler != null;
			if (flag3)
			{
				this.m_HeroBattleTeamHandler.SetVisible(true);
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
			this._doc.DelDummy();
			bool flag = this._doc.BlackHouseCamera != null;
			if (flag)
			{
				this._doc.BlackHouseCamera.enabled = false;
			}
			this._doc.SetSkillPreviewTexture(null);
			bool flag2 = this._Fx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._Fx, true);
			}
			bool flag3 = this.skillPreView != null;
			if (flag3)
			{
				this.m_Snapshot.SetRuntimeTex(null, true);
				this.skillPreView.Release();
				this.skillPreView = null;
			}
			bool isBattleScene = this._isBattleScene;
			if (isBattleScene)
			{
				this._showRefresh = true;
			}
			bool flag4 = this.m_HeroBattleTeamHandler != null;
			if (flag4)
			{
				this.m_HeroBattleTeamHandler.SetVisible(false);
			}
		}

		public override void OnUnload()
		{
			this.LastSelectSprite = null;
			this._doc.m_HeroBattleSkillHandler = null;
			DlgHandlerBase.EnsureUnload<HeroBattleTeamHandler>(ref this.m_HeroBattleTeamHandler);
			this._doc.DelDummy();
			bool flag = this._doc.BlackHouseCamera != null;
			if (flag)
			{
				this._doc.BlackHouseCamera.enabled = false;
			}
			this._doc.SetSkillPreviewTexture(null);
			bool flag2 = this.skillPreView != null;
			if (flag2)
			{
				this.skillPreView.Release();
				this.skillPreView = null;
			}
			bool flag3 = this._Fx != null;
			if (flag3)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._Fx, true);
				this._Fx = null;
			}
			base.OnUnload();
		}

		public void SetFx()
		{
			bool isBattleScene = this._isBattleScene;
			if (!isBattleScene)
			{
				bool flag = this._Fx != null;
				if (flag)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._Fx, true);
				}
				this._Fx = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_yh", null, true);
				this._Fx.Play(this._FxTs, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		private bool OnCloseBtnClick(IXUIButton btn)
		{
			bool isBattleScene = this._isBattleScene;
			if (isBattleScene)
			{
				bool flag = !this._doc.AlSelectHero;
				if (flag)
				{
					return false;
				}
				base.SetVisible(false);
			}
			else
			{
				this.SetSkillPreViewState(false, 0);
			}
			return true;
		}

		private void OnPlayBtnClick(IXUISprite iSp)
		{
			this.SetPlayBtnState(false);
			XSingleton<XSkillPreViewMgr>.singleton.ShowSkill(this._doc.Dummy, this._currSkill, this._doc.CurrentEntityStatisticsID[this.HandlerType]);
		}

		private bool OnOKBtnClick(IXUIButton btn)
		{
			this._doc.QuerySelectBattleHero();
			return true;
		}

		public bool OnSureUseExperienceTicket(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.QueryUseExperienceTicket();
			return true;
		}

		public void OnExperienceClick(IXUISprite iSp)
		{
			bool flag = !this._doc.CSSH && this._doc.TAS.Contains((uint)iSp.ID);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("HeroBattleSameHeroTips"), "fece00");
			}
			bool flag2 = this._doc.AlreadyGetList.Contains((uint)iSp.ID) || this._doc.WeekFreeList.Contains((uint)iSp.ID) || this._doc.ExperienceList.Contains((uint)iSp.ID);
			if (!flag2)
			{
				uint experienceTicketID = this._heroDoc.GetExperienceTicketID((uint)iSp.ID);
				bool flag3 = experienceTicketID > 0U;
				if (flag3)
				{
					HeroBattleExperienceHero.RowData byItemID = this._heroDoc.HeroExperienceReader.GetByItemID(experienceTicketID);
					OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID((uint)iSp.ID);
					bool flag4 = byItemID == null || byHeroID == null;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("UseExperienceTicket error. itemid = ", experienceTicketID.ToString(), null, null, null, null);
					}
					else
					{
						this._doc.CurrentSelectExperienceTicketID = experienceTicketID;
						string text = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("HeroBattleExperienceQues"));
						text = string.Format(text, byHeroID.Name, byItemID.ShowTime);
						string @string = XStringDefineProxy.GetString("COMMON_OK");
						string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
						XSingleton<UiUtility>.singleton.ShowModalDialog(text, @string, string2, new ButtonClickEventHandler(this.OnSureUseExperienceTicket));
					}
				}
			}
		}

		public void OnTabClick(IXUISprite iSp)
		{
			bool flag = this._isBattleScene && this._battleFirstClick;
			if (flag)
			{
				this._battleFirstClick = false;
				this.m_ShowFrame.SetActive(true);
			}
			bool flag2 = this.LastSelectSprite != null;
			GameObject gameObject;
			if (flag2)
			{
				gameObject = this.LastSelectSprite.gameObject.transform.Find("select").gameObject;
				gameObject.SetActive(false);
			}
			this.LastSelectSprite = iSp;
			this._doc.CurrentSelect = (uint)iSp.ID;
			gameObject = iSp.gameObject.transform.Find("select").gameObject;
			gameObject.SetActive(true);
			bool isBattleScene = this._isBattleScene;
			if (isBattleScene)
			{
				bool flag3 = this._doc.AlreadyGetList.Contains(this._doc.CurrentSelect) || this._doc.WeekFreeList.Contains(this._doc.CurrentSelect) || this._doc.ExperienceList.Contains(this._doc.CurrentSelect);
				if (flag3)
				{
					this.m_OKBtn.SetVisible(true);
					bool flag4 = !this._doc.CSSH && this._doc.TAS.Contains(this._doc.CurrentSelect);
					this.m_OKBtn.SetGrey(!flag4);
					this.m_BuyBtn.SetVisible(false);
				}
				else
				{
					this.m_OKBtn.SetVisible(false);
					this.m_BuyBtn.SetVisible(true);
					this.SetBuyBtnPrice(this.m_BuyBtn);
				}
			}
			else
			{
				bool flag5 = this._doc.IsPreViewShow && !this._doc.AlreadyGetList.Contains(this._doc.CurrentSelect);
				this.m_BuyBtn.SetVisible(flag5);
				bool flag6 = flag5;
				if (flag6)
				{
					this.SetBuyBtnPrice(this.m_BuyBtn);
				}
			}
			bool flag7 = !this._isBattleScene && DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.IsVisible();
			if (flag7)
			{
				DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.RefreshSelectMsg();
			}
			bool flag8 = !this._isBattleScene && DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.IsVisible();
			if (flag8)
			{
				DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.RefreshSelectMsg();
			}
			bool activeInHierarchy = this.m_ShowFrame.activeInHierarchy;
			if (activeInHierarchy)
			{
				this.SetupPreViewInfo(0);
				XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this._doc.Dummy);
				XSingleton<XSkillPreViewMgr>.singleton.SkillShowBegin(this._doc.Dummy, this._doc.BlackHouseCamera);
			}
		}

		private int Compare(uint x, uint y)
		{
			bool flag = x == y;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = this._doc.ExperienceList.Contains(x) != this._doc.ExperienceList.Contains(y);
				if (flag2)
				{
					result = (this._doc.ExperienceList.Contains(x) ? -1 : 1);
				}
				else
				{
					bool flag3 = this._doc.WeekFreeList.Contains(x) != this._doc.WeekFreeList.Contains(y);
					if (flag3)
					{
						bool flag4 = this._doc.ExperienceList.Contains(x) && this._doc.ExperienceList.Contains(y);
						if (flag4)
						{
							result = (this._doc.WeekFreeList.Contains(x) ? 1 : -1);
						}
						else
						{
							result = (this._doc.WeekFreeList.Contains(x) ? -1 : 1);
						}
					}
					else
					{
						bool flag5 = this._doc.AlreadyGetList.Contains(x) != this._doc.AlreadyGetList.Contains(y);
						if (flag5)
						{
							bool flag6 = this._doc.ExperienceList.Contains(x) && this._doc.ExperienceList.Contains(y);
							if (flag6)
							{
								result = (this._doc.AlreadyGetList.Contains(x) ? 1 : -1);
							}
							else
							{
								result = (this._doc.AlreadyGetList.Contains(x) ? -1 : 1);
							}
						}
						else
						{
							result = this._heroDoc.OverWatchReader.GetByHeroID(x).SortID - this._heroDoc.OverWatchReader.GetByHeroID(y).SortID;
						}
					}
				}
			}
			return result;
		}

		public void SetupTabs()
		{
			this.LastSelectSprite = null;
			this._doc.SetUnSelect();
			this.m_TabPool.ReturnAll(false);
			List<uint> list = new List<uint>();
			for (int i = 0; i < this._heroDoc.OverWatchReader.Table.Length; i++)
			{
				list.Add(this._heroDoc.OverWatchReader.Table[i].HeroID);
			}
			list.Sort(new Comparison<uint>(this.Compare));
			SpriteClickEventHandler spriteClickEventHandler = new SpriteClickEventHandler(this.OnTabClick);
			spriteClickEventHandler = (SpriteClickEventHandler)Delegate.Combine(spriteClickEventHandler, new SpriteClickEventHandler(this.OnExperienceClick));
			Vector3 tplPos = this.m_TabPool.TplPos;
			for (int j = 0; j < list.Count; j++)
			{
				OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(list[j]);
				GameObject gameObject = this.m_TabPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x + (float)((j & 1) * this.m_TabPool.TplWidth), tplPos.y - (float)(j / 2 * this.m_TabPool.TplHeight));
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)byHeroID.HeroID;
				ixuisprite.RegisterSpriteClickEventHandler(spriteClickEventHandler);
				IXUISprite ixuisprite2 = gameObject.transform.Find("Bg/Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(byHeroID.Icon, byHeroID.IconAtlas, false);
				GameObject gameObject2 = gameObject.transform.Find("select").gameObject;
				gameObject2.SetActive(false);
				this.RefreshSingleTab(byHeroID, gameObject);
				bool flag = !this._isBattleScene && this._doc.CurrentSelect == this._doc.UNSELECT;
				if (flag)
				{
					this.OnTabClick(ixuisprite);
				}
			}
		}

		public void RefreshTab()
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			this.m_TabPool.GetActiveList(list);
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = list[i];
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID((uint)ixuisprite.ID);
				this.RefreshSingleTab(byHeroID, gameObject);
			}
			ListPool<GameObject>.Release(list);
			bool flag = this.LastSelectSprite != null;
			if (flag)
			{
				this.OnTabClick(this.LastSelectSprite);
			}
		}

		private void RefreshSingleTab(OverWatchTable.RowData data, GameObject go)
		{
			GameObject gameObject = go.transform.Find("Bg/Have").gameObject;
			gameObject.SetActive(this._doc.AlreadyGetList.Contains(data.HeroID));
			GameObject gameObject2 = go.transform.Find("Bg/xm").gameObject;
			gameObject2.SetActive(this._doc.WeekFreeList.Contains(data.HeroID));
			IXUISprite ixuisprite = go.transform.Find("Bg/Icon").GetComponent("XUISprite") as IXUISprite;
			bool flag = this._doc.WeekFreeList.Contains(data.HeroID) || this._doc.AlreadyGetList.Contains(data.HeroID) || this._doc.ExperienceList.Contains(data.HeroID);
			bool flag2 = !this._doc.CSSH;
			if (flag2)
			{
				flag = (flag && !this._doc.TAS.Contains(data.HeroID));
			}
			ixuisprite.SetGrey(flag);
			bool flag3 = !flag;
			if (flag3)
			{
				ixuisprite.SetAlpha(1f);
			}
			GameObject gameObject3 = go.transform.Find("Bg/Experience").gameObject;
			gameObject3.SetActive(!this._doc.AlreadyGetList.Contains(data.HeroID) && !this._doc.WeekFreeList.Contains(data.HeroID) && this._doc.ExperienceList.Contains(data.HeroID));
			GameObject gameObject4 = go.transform.Find("Bg/UseExperience").gameObject;
			gameObject4.SetActive(!this._doc.WeekFreeList.Contains(data.HeroID) && !this._doc.AlreadyGetList.Contains(data.HeroID) && !this._doc.ExperienceList.Contains(data.HeroID) && this._heroDoc.GetExperienceTicketID(data.HeroID) > 0U);
			GameObject gameObject5 = go.transform.Find("Bg/TeammateChoose").gameObject;
			gameObject5.SetActive(this._isBattleScene && !this._doc.CSSH && this._doc.TAS.Contains(data.HeroID));
		}

		private void SetupPreViewInfo(int index = 0)
		{
			this._doc.ReplaceDummy(this.HandlerType);
			OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(this._doc.CurrentSelect);
			this.m_HeroName.SetText(byHeroID.Name);
			List<uint> list = new List<uint>();
			uint presentID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._doc.CurrentEntityStatisticsID[this.HandlerType]).PresentID;
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID);
			int num = (this.HandlerType == 2) ? 4 : 5;
			int num2 = 0;
			while (list.Count < num && num2 < byPresentID.OtherSkills.Length)
			{
				bool flag = string.IsNullOrEmpty(byPresentID.OtherSkills[num2]) || byPresentID.OtherSkills[num2] == "E";
				if (!flag)
				{
					list.Add(XSingleton<XSkillEffectMgr>.singleton.GetSkillID(byPresentID.OtherSkills[num2], this._doc.CurrentEntityStatisticsID[this.HandlerType]));
				}
				num2++;
			}
			this.m_SkillPool.ReturnAll(false);
			Vector3 tplPos = this.m_SkillPool.TplPos;
			IXUICheckBox ixuicheckBox = null;
			for (int i = 0; i < list.Count; i++)
			{
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(list[i], 0U, this._doc.CurrentEntityStatisticsID[this.HandlerType]);
				GameObject gameObject = this.m_SkillPool.FetchGameObject(false);
				gameObject.name = list[i].ToString();
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * this.m_SkillPool.TplHeight));
				IXUISprite ixuisprite = gameObject.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite;
				bool flag2 = skillConfig.SkillType == 2;
				if (flag2)
				{
					ixuisprite.SetSprite("JN_dk_0");
				}
				else
				{
					ixuisprite.SetSprite("JN_dk");
				}
				IXUISprite ixuisprite2 = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(skillConfig.Icon, skillConfig.Atlas, false);
				IXUICheckBox ixuicheckBox2 = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox2.ID = (ulong)list[i];
				ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSkillPreViewClick));
				ixuicheckBox2.bChecked = false;
				bool flag3 = i == index;
				if (flag3)
				{
					this._currSkill = list[i];
					ixuicheckBox = ixuicheckBox2;
					this.SetupSkillInfo();
				}
			}
			ixuicheckBox.bChecked = true;
		}

		public List<uint> SkillInfo()
		{
			List<uint> list = new List<uint>();
			uint presentID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._doc.CurrentEntityStatisticsID[this.HandlerType]).PresentID;
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID);
			for (int i = 0; i < byPresentID.OtherSkills.Length; i++)
			{
				bool flag = string.IsNullOrEmpty(byPresentID.OtherSkills[i]) || byPresentID.OtherSkills[i] == "E";
				if (!flag)
				{
					list.Add(XSingleton<XSkillEffectMgr>.singleton.GetSkillID(byPresentID.OtherSkills[i], this._doc.CurrentEntityStatisticsID[this.HandlerType]));
				}
			}
			return list;
		}

		private bool OnSkillPreViewClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._currSkill = (uint)icb.ID;
				this.SetupSkillInfo();
				result = true;
			}
			return result;
		}

		private bool OnBuyBtnClick(IXUIButton btn)
		{
			this._doc.QueryBuyHero(this._doc.CurrentSelect);
			return true;
		}

		private void SetupSkillInfo()
		{
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this._currSkill, 0U, this._doc.CurrentEntityStatisticsID[this.HandlerType]);
			this.m_SkillName.SetText(skillConfig.ScriptName);
			this.m_SkillDesc.SetText(skillConfig.CurrentLevelDescription);
			this.SetPlayBtnState(true);
			XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this._doc.Dummy);
			XSingleton<XSkillPreViewMgr>.singleton.SkillShowBegin(this._doc.Dummy, this._doc.BlackHouseCamera);
		}

		public void SetSkillPreViewState(bool state, int index = 0)
		{
			this._doc.IsPreViewShow = state;
			this.m_ShowFrame.SetActive(state);
			bool flag = !this._isBattleScene;
			if (flag)
			{
				this.m_Back.SetActive(state);
			}
			if (state)
			{
				this.SetupPreViewInfo(index);
				if (state)
				{
					bool flag2 = this._doc.IsPreViewShow && !this._doc.AlreadyGetList.Contains(this._doc.CurrentSelect);
					this.m_BuyBtn.SetVisible(flag2);
					bool flag3 = flag2;
					if (flag3)
					{
						this.SetBuyBtnPrice(this.m_BuyBtn);
					}
				}
			}
			bool flag4 = !this._isBattleScene && this.OtherViewBuyBtn != null;
			if (flag4)
			{
				bool flag5 = !this._doc.IsPreViewShow && !this._doc.AlreadyGetList.Contains(this._doc.CurrentSelect);
				this.OtherViewBuyBtn.SetVisible(flag5);
				bool flag6 = flag5;
				if (flag6)
				{
					this.SetBuyBtnPrice(this.OtherViewBuyBtn);
				}
			}
		}

		private void SetBuyBtnPrice(IXUIButton btn)
		{
			OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(this._doc.CurrentSelect);
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)byHeroID.Price[0]);
			IXUISprite ixuisprite = btn.gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = itemConf.ItemIcon1[0];
			IXUILabel ixuilabel = btn.gameObject.transform.Find("Cost").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(byHeroID.Price[1].ToString());
		}

		public void SetUVRectangle()
		{
			Rect rect = this._doc.BlackHouseCamera.rect;
			rect.y = (rect.y * 338f + 1f) / 338f;
			rect.height = (rect.height * 338f - 2f) / 338f;
			this.m_Snapshot.SetUVRect(rect);
		}

		public void SetPlayBtnState(bool state)
		{
			this.m_PlayBtn.transform.localPosition = (state ? Vector3.zero : XGameUI.Far_Far_Away);
		}

		public void SetCountDown(float time, bool isChooseHero)
		{
			this.m_CountDownTips.SetText(XStringDefineProxy.GetString(isChooseHero ? "HeroBattleSelectHeroTips" : "HeroBattleChangeHeroTips"));
			this._OnCountDown = true;
			this._CountDownTime = Time.realtimeSinceStartup + time;
		}

		public override void OnUpdate()
		{
			bool onCountDown = this._OnCountDown;
			if (onCountDown)
			{
				int num = 0;
				bool flag = this._CountDownTime < Time.realtimeSinceStartup;
				if (flag)
				{
					this._OnCountDown = false;
				}
				else
				{
					num = (int)(this._CountDownTime - Time.realtimeSinceStartup);
				}
				this.m_CountDown.SetText(num.ToString());
			}
		}

		private XHeroBattleSkillDocument _doc = null;

		private XHeroBattleDocument _heroDoc = null;

		public GameObject m_ShowFrame;

		public IXUIButton m_BuyBtn;

		private IXUIButton m_OKBtn;

		private IXUISprite m_PlayBtn;

		private IXUIButton m_CloseBtn;

		public IXUILabel m_HeroName;

		private IXUILabel m_SkillName;

		private IXUILabel m_SkillDesc;

		private GameObject m_Back;

		private XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIPanel m_Panel;

		private bool _isBattleScene;

		public RenderTexture skillPreView;

		public IXUITexture m_Snapshot;

		public IXUISprite LastSelectSprite;

		private uint _currSkill;

		private bool _OnCountDown;

		private float _CountDownTime;

		private IXUILabel m_CountDown;

		private IXUILabel m_CountDownTips;

		private bool _showRefresh;

		private bool _battleFirstClick;

		private IXUISprite m_BoxC;

		private Transform _FxTs;

		private XFx _Fx;

		public IXUIButton OtherViewBuyBtn = null;

		public int HandlerType;

		public HeroBattleTeamHandler m_HeroBattleTeamHandler;
	}
}
