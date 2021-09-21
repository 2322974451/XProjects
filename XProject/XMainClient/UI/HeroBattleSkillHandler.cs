using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001798 RID: 6040
	internal class HeroBattleSkillHandler : DlgHandlerBase
	{
		// Token: 0x1700384F RID: 14415
		// (get) Token: 0x0600F959 RID: 63833 RVA: 0x00393E30 File Offset: 0x00392030
		protected override string FileName
		{
			get
			{
				return "GameSystem/HeroBattleSkill";
			}
		}

		// Token: 0x0600F95A RID: 63834 RVA: 0x00393E48 File Offset: 0x00392048
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

		// Token: 0x0600F95B RID: 63835 RVA: 0x003942EC File Offset: 0x003924EC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			this.m_PlayBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPlayBtnClick));
			this.m_OKBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKBtnClick));
			this.m_BuyBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClick));
		}

		// Token: 0x0600F95C RID: 63836 RVA: 0x00394364 File Offset: 0x00392564
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

		// Token: 0x0600F95D RID: 63837 RVA: 0x00394444 File Offset: 0x00392644
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

		// Token: 0x0600F95E RID: 63838 RVA: 0x00394518 File Offset: 0x00392718
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

		// Token: 0x0600F95F RID: 63839 RVA: 0x003945DC File Offset: 0x003927DC
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

		// Token: 0x0600F960 RID: 63840 RVA: 0x00394650 File Offset: 0x00392850
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

		// Token: 0x0600F961 RID: 63841 RVA: 0x00394698 File Offset: 0x00392898
		private void OnPlayBtnClick(IXUISprite iSp)
		{
			this.SetPlayBtnState(false);
			XSingleton<XSkillPreViewMgr>.singleton.ShowSkill(this._doc.Dummy, this._currSkill, this._doc.CurrentEntityStatisticsID[this.HandlerType]);
		}

		// Token: 0x0600F962 RID: 63842 RVA: 0x003946D4 File Offset: 0x003928D4
		private bool OnOKBtnClick(IXUIButton btn)
		{
			this._doc.QuerySelectBattleHero();
			return true;
		}

		// Token: 0x0600F963 RID: 63843 RVA: 0x003946F4 File Offset: 0x003928F4
		public bool OnSureUseExperienceTicket(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.QueryUseExperienceTicket();
			return true;
		}

		// Token: 0x0600F964 RID: 63844 RVA: 0x00394720 File Offset: 0x00392920
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

		// Token: 0x0600F965 RID: 63845 RVA: 0x003948B4 File Offset: 0x00392AB4
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

		// Token: 0x0600F966 RID: 63846 RVA: 0x00394B50 File Offset: 0x00392D50
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

		// Token: 0x0600F967 RID: 63847 RVA: 0x00394D0C File Offset: 0x00392F0C
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

		// Token: 0x0600F968 RID: 63848 RVA: 0x00394F1C File Offset: 0x0039311C
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

		// Token: 0x0600F969 RID: 63849 RVA: 0x00394FB8 File Offset: 0x003931B8
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

		// Token: 0x0600F96A RID: 63850 RVA: 0x0039521C File Offset: 0x0039341C
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

		// Token: 0x0600F96B RID: 63851 RVA: 0x003954FC File Offset: 0x003936FC
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

		// Token: 0x0600F96C RID: 63852 RVA: 0x003955C4 File Offset: 0x003937C4
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

		// Token: 0x0600F96D RID: 63853 RVA: 0x003955FC File Offset: 0x003937FC
		private bool OnBuyBtnClick(IXUIButton btn)
		{
			this._doc.QueryBuyHero(this._doc.CurrentSelect);
			return true;
		}

		// Token: 0x0600F96E RID: 63854 RVA: 0x00395628 File Offset: 0x00393828
		private void SetupSkillInfo()
		{
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this._currSkill, 0U, this._doc.CurrentEntityStatisticsID[this.HandlerType]);
			this.m_SkillName.SetText(skillConfig.ScriptName);
			this.m_SkillDesc.SetText(skillConfig.CurrentLevelDescription);
			this.SetPlayBtnState(true);
			XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this._doc.Dummy);
			XSingleton<XSkillPreViewMgr>.singleton.SkillShowBegin(this._doc.Dummy, this._doc.BlackHouseCamera);
		}

		// Token: 0x0600F96F RID: 63855 RVA: 0x003956C0 File Offset: 0x003938C0
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

		// Token: 0x0600F970 RID: 63856 RVA: 0x003957D8 File Offset: 0x003939D8
		private void SetBuyBtnPrice(IXUIButton btn)
		{
			OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(this._doc.CurrentSelect);
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)byHeroID.Price[0]);
			IXUISprite ixuisprite = btn.gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = itemConf.ItemIcon1[0];
			IXUILabel ixuilabel = btn.gameObject.transform.Find("Cost").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(byHeroID.Price[1].ToString());
		}

		// Token: 0x0600F971 RID: 63857 RVA: 0x0039588C File Offset: 0x00393A8C
		public void SetUVRectangle()
		{
			Rect rect = this._doc.BlackHouseCamera.rect;
			rect.y = (rect.y * 338f + 1f) / 338f;
			rect.height = (rect.height * 338f - 2f) / 338f;
			this.m_Snapshot.SetUVRect(rect);
		}

		// Token: 0x0600F972 RID: 63858 RVA: 0x003958FA File Offset: 0x00393AFA
		public void SetPlayBtnState(bool state)
		{
			this.m_PlayBtn.transform.localPosition = (state ? Vector3.zero : XGameUI.Far_Far_Away);
		}

		// Token: 0x0600F973 RID: 63859 RVA: 0x0039591D File Offset: 0x00393B1D
		public void SetCountDown(float time, bool isChooseHero)
		{
			this.m_CountDownTips.SetText(XStringDefineProxy.GetString(isChooseHero ? "HeroBattleSelectHeroTips" : "HeroBattleChangeHeroTips"));
			this._OnCountDown = true;
			this._CountDownTime = Time.realtimeSinceStartup + time;
		}

		// Token: 0x0600F974 RID: 63860 RVA: 0x00395954 File Offset: 0x00393B54
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

		// Token: 0x04006CEC RID: 27884
		private XHeroBattleSkillDocument _doc = null;

		// Token: 0x04006CED RID: 27885
		private XHeroBattleDocument _heroDoc = null;

		// Token: 0x04006CEE RID: 27886
		public GameObject m_ShowFrame;

		// Token: 0x04006CEF RID: 27887
		public IXUIButton m_BuyBtn;

		// Token: 0x04006CF0 RID: 27888
		private IXUIButton m_OKBtn;

		// Token: 0x04006CF1 RID: 27889
		private IXUISprite m_PlayBtn;

		// Token: 0x04006CF2 RID: 27890
		private IXUIButton m_CloseBtn;

		// Token: 0x04006CF3 RID: 27891
		public IXUILabel m_HeroName;

		// Token: 0x04006CF4 RID: 27892
		private IXUILabel m_SkillName;

		// Token: 0x04006CF5 RID: 27893
		private IXUILabel m_SkillDesc;

		// Token: 0x04006CF6 RID: 27894
		private GameObject m_Back;

		// Token: 0x04006CF7 RID: 27895
		private XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006CF8 RID: 27896
		private XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006CF9 RID: 27897
		private IXUIPanel m_Panel;

		// Token: 0x04006CFA RID: 27898
		private bool _isBattleScene;

		// Token: 0x04006CFB RID: 27899
		public RenderTexture skillPreView;

		// Token: 0x04006CFC RID: 27900
		public IXUITexture m_Snapshot;

		// Token: 0x04006CFD RID: 27901
		public IXUISprite LastSelectSprite;

		// Token: 0x04006CFE RID: 27902
		private uint _currSkill;

		// Token: 0x04006CFF RID: 27903
		private bool _OnCountDown;

		// Token: 0x04006D00 RID: 27904
		private float _CountDownTime;

		// Token: 0x04006D01 RID: 27905
		private IXUILabel m_CountDown;

		// Token: 0x04006D02 RID: 27906
		private IXUILabel m_CountDownTips;

		// Token: 0x04006D03 RID: 27907
		private bool _showRefresh;

		// Token: 0x04006D04 RID: 27908
		private bool _battleFirstClick;

		// Token: 0x04006D05 RID: 27909
		private IXUISprite m_BoxC;

		// Token: 0x04006D06 RID: 27910
		private Transform _FxTs;

		// Token: 0x04006D07 RID: 27911
		private XFx _Fx;

		// Token: 0x04006D08 RID: 27912
		public IXUIButton OtherViewBuyBtn = null;

		// Token: 0x04006D09 RID: 27913
		public int HandlerType;

		// Token: 0x04006D0A RID: 27914
		public HeroBattleTeamHandler m_HeroBattleTeamHandler;
	}
}
