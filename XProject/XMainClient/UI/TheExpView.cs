using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001712 RID: 5906
	internal class TheExpView : DlgBase<TheExpView, TheExpBehaviour>
	{
		// Token: 0x17003798 RID: 14232
		// (get) Token: 0x0600F3CE RID: 62414 RVA: 0x00367CD0 File Offset: 0x00365ED0
		public override string fileName
		{
			get
			{
				return "GameSystem/TheExpDlg";
			}
		}

		// Token: 0x17003799 RID: 14233
		// (get) Token: 0x0600F3CF RID: 62415 RVA: 0x00367CE8 File Offset: 0x00365EE8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700379A RID: 14234
		// (get) Token: 0x0600F3D0 RID: 62416 RVA: 0x00367CFC File Offset: 0x00365EFC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700379B RID: 14235
		// (get) Token: 0x0600F3D1 RID: 62417 RVA: 0x00367D10 File Offset: 0x00365F10
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700379C RID: 14236
		// (get) Token: 0x0600F3D2 RID: 62418 RVA: 0x00367D24 File Offset: 0x00365F24
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700379D RID: 14237
		// (get) Token: 0x0600F3D3 RID: 62419 RVA: 0x00367D38 File Offset: 0x00365F38
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F3D4 RID: 62420 RVA: 0x00367D4C File Offset: 0x00365F4C
		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument);
			this._teamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this._LevelDoc = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
			this._NestDoc = XDocuments.GetSpecificDocument<XNestDocument>(XNestDocument.uuID);
			this._sweepDoc = XDocuments.GetSpecificDocument<XSweepDocument>(XSweepDocument.uuID);
			this.m_Catergory = -1;
			this.m_SpecialExpID = -1;
			this.m_TabCheckboxs = null;
			this.m_PPTEnoughColor = XSingleton<XGlobalConfig>.singleton.GetValue("PPTEnoughColor");
			this.m_PPTNotEnoughColor = XSingleton<XGlobalConfig>.singleton.GetValue("PPTNotEnoughColor");
			base.uiBehaviour.m_rewardBtn.gameObject.SetActive(false);
			base.uiBehaviour.m_rankBtn.gameObject.SetActive(false);
			DlgHandlerBase.EnsureCreate<NestStarRewardHandler>(ref this._nestStarRewardHandler, base.uiBehaviour.m_parent, false, this);
		}

		// Token: 0x1700379E RID: 14238
		// (get) Token: 0x0600F3D5 RID: 62421 RVA: 0x00367E40 File Offset: 0x00366040
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x0600F3D6 RID: 62422 RVA: 0x00367E54 File Offset: 0x00366054
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_AddCount.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnAddFatigueClick));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_rewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnClickPreviewRewardBtn));
			base.uiBehaviour.m_rankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnClickRankBtn));
			base.uiBehaviour.m_quanMinSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._onClickQuanMinSpr));
		}

		// Token: 0x0600F3D7 RID: 62423 RVA: 0x00367F10 File Offset: 0x00366110
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_Nest);
			return true;
		}

		// Token: 0x0600F3D8 RID: 62424 RVA: 0x00367F34 File Offset: 0x00366134
		protected override void OnUnload()
		{
			this._doc = null;
			this._teamDoc = null;
			this.m_TabCheckboxs = null;
			bool flag = this._nestStarRewardHandler != null;
			if (flag)
			{
				DlgHandlerBase.EnsureUnload<NestStarRewardHandler>(ref this._nestStarRewardHandler);
				this._nestStarRewardHandler = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600F3D9 RID: 62425 RVA: 0x00367F80 File Offset: 0x00366180
		public void ShowView(int expid = -1)
		{
			base.Load();
			this.m_SpecialExpID = expid;
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			this._RefreshTabs();
		}

		// Token: 0x0600F3DA RID: 62426 RVA: 0x00367FBC File Offset: 0x003661BC
		public void ShowViewByExpID(int expID)
		{
			base.Load();
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			this.m_SpecialExpID = expID;
			this._RefreshTabs();
		}

		// Token: 0x0600F3DB RID: 62427 RVA: 0x00367FF8 File Offset: 0x003661F8
		private string _GetSubCategoryName(int SubCategory)
		{
			return string.Format("TeamSubCategory{0}{1}", XFastEnumIntEqualityComparer<TeamLevelType>.ToInt(TeamLevelType.TeamLevelNest), SubCategory);
		}

		// Token: 0x0600F3DC RID: 62428 RVA: 0x00368028 File Offset: 0x00366228
		private void _RefreshTabs()
		{
			HashSet<int> hashSet = new HashSet<int>();
			int num = -1;
			NestListTable.RowData byNestID = XNestDocument.NestListData.GetByNestID(this.m_SpecialExpID);
			bool flag = byNestID != null;
			if (flag)
			{
				num = byNestID.Type;
			}
			this.m_FirstOpenExpCache.Clear();
			for (int i = 0; i < XNestDocument.NestListData.Table.Length; i++)
			{
				NestListTable.RowData rowData = XNestDocument.NestListData.Table[i];
				bool flag2 = hashSet.Contains(rowData.Type);
				if (!flag2)
				{
					ExpeditionTable.RowData expeditionDataByID = this._doc.GetExpeditionDataByID(rowData.NestID);
					bool flag3 = expeditionDataByID == null;
					if (!flag3)
					{
						bool flag4 = this._doc.TeamCategoryMgr.IsExpOpened(expeditionDataByID);
						if (flag4)
						{
							hashSet.Add(rowData.Type);
						}
						else
						{
							ExpeditionTable.RowData rowData2;
							bool flag5 = this.m_FirstOpenExpCache.TryGetValue(rowData.Type, out rowData2);
							if (flag5)
							{
								bool flag6 = rowData2.RequiredLevel > expeditionDataByID.RequiredLevel;
								if (flag6)
								{
									this.m_FirstOpenExpCache[rowData.Type] = expeditionDataByID;
								}
							}
							else
							{
								this.m_FirstOpenExpCache.Add(rowData.Type, expeditionDataByID);
							}
						}
					}
				}
			}
			this.m_IDCache.Clear();
			this.m_NameCache.Clear();
			int num2 = 0;
			bool flag7 = false;
			for (int j = 0; j < XNestDocument.NestTypeData.Table.Length; j++)
			{
				NestTypeTable.RowData rowData3 = XNestDocument.NestTypeData.Table[j];
				bool flag8 = !flag7 && hashSet.Contains(rowData3.TypeID);
				if (flag8)
				{
					bool flag9 = rowData3.TypeID == num;
					if (flag9)
					{
						num2 = j;
						flag7 = true;
					}
					num2 = Mathf.Max(j, num2);
				}
				this.m_IDCache.Add(rowData3.TypeID);
				this.m_NameCache.Add(rowData3.TypeName);
			}
			int select = -1;
			bool flag10 = num2 < this.m_IDCache.Count;
			if (flag10)
			{
				select = this.m_IDCache[num2];
			}
			this.m_TabCheckboxs = base.uiBehaviour.m_tabcontrol.SetupTabs(this.m_IDCache, this.m_NameCache, new XUITabControl.UITabControlCallback(this._UITabControlCallback), false, 1f, select, false);
			for (int k = 0; k < this.m_TabCheckboxs.Length; k++)
			{
				IXUICheckBox ixuicheckBox = this.m_TabCheckboxs[k];
				IXUISprite ixuisprite = ixuicheckBox.gameObject.transform.parent.Find("Lock").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = ixuicheckBox.gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				NestTypeTable.RowData byTypeID = XNestDocument.NestTypeData.GetByTypeID((int)ixuicheckBox.ID);
				bool flag11 = byTypeID == null;
				if (!flag11)
				{
					ixuisprite2.SetSprite(byTypeID.TypeIcon);
					bool flag12 = !hashSet.Contains((int)ixuicheckBox.ID);
					if (flag12)
					{
						ixuisprite.SetVisible(true);
						int key = (int)ixuicheckBox.ID;
						ExpeditionTable.RowData rowData4;
						this.m_FirstOpenExpCache.TryGetValue(key, out rowData4);
						bool flag13 = rowData4 != null;
						if (flag13)
						{
							ixuisprite.ID = (ulong)((long)rowData4.DNExpeditionID);
						}
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnLockClicked));
						ixuicheckBox.SetEnable(false);
					}
					else
					{
						ixuisprite.SetVisible(false);
						ixuicheckBox.SetEnable(true);
					}
				}
			}
		}

		// Token: 0x0600F3DD RID: 62429 RVA: 0x003683C0 File Offset: 0x003665C0
		private void _OnLockClicked(IXUISprite iSp)
		{
			ExpeditionTable.RowData expeditionDataByID = this._doc.GetExpeditionDataByID((int)iSp.ID);
			NestListTable.RowData byNestID = XNestDocument.NestListData.GetByNestID((int)iSp.ID);
			bool flag = expeditionDataByID == null;
			if (!flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
				{
					expeditionDataByID.RequiredLevel
				}) + XStringDefineProxy.GetString(this._GetSubCategoryName(byNestID.Type)), "fece00");
			}
		}

		// Token: 0x0600F3DE RID: 62430 RVA: 0x00368444 File Offset: 0x00366644
		private void _UITabControlCallback(ulong id)
		{
			int num = (int)id;
			NestTypeTable.RowData byTypeID = XNestDocument.NestTypeData.GetByTypeID(num);
			bool flag = byTypeID == null;
			if (!flag)
			{
				this.m_Catergory = num;
				base.uiBehaviour.m_NestBg.SetTexturePath(byTypeID.TypeBg);
				bool flag2 = byTypeID.TypeBgTransform == null || byTypeID.TypeBgTransform.Length != 3;
				if (flag2)
				{
					base.uiBehaviour.m_NestBg.gameObject.transform.localPosition = Vector3.zero;
				}
				else
				{
					base.uiBehaviour.m_NestBg.gameObject.transform.localPosition = new Vector3(byTypeID.TypeBgTransform[0], byTypeID.TypeBgTransform[1], byTypeID.TypeBgTransform[2]);
				}
				this._RefreshDiffs();
			}
		}

		// Token: 0x0600F3DF RID: 62431 RVA: 0x0036850C File Offset: 0x0036670C
		private void _RefreshDiffs()
		{
			for (int i = 1; i < base.uiBehaviour.m_DiffList.Count; i++)
			{
				base.uiBehaviour.m_DiffList[i].SetActive(false);
			}
			NestListTable.RowData rowData = null;
			ExpeditionTable.RowData rowData2 = null;
			int starNestId = this._NestDoc.GetStarNestId(this.m_Catergory);
			int j = 0;
			while (j < XNestDocument.NestListData.Table.Length)
			{
				NestListTable.RowData rowData3 = XNestDocument.NestListData.Table[j];
				bool flag = rowData3.Type == this.m_Catergory;
				if (flag)
				{
					bool flag2 = rowData3.Difficulty >= base.uiBehaviour.m_DiffList.Count || rowData3.Difficulty <= 0;
					if (!flag2)
					{
						ExpeditionTable.RowData expeditionDataByID = this._doc.GetExpeditionDataByID(rowData3.NestID);
						bool flag3 = expeditionDataByID != null && expeditionDataByID.CostCountType == 0;
						if (flag3)
						{
							bool flag4 = starNestId != 0 && rowData3.NestID != starNestId;
							if (flag4)
							{
								bool flag5 = expeditionDataByID.Stars[0] != 1U;
								if (flag5)
								{
									goto IL_1DB;
								}
							}
						}
						GameObject gameObject = base.uiBehaviour.m_DiffList[rowData3.Difficulty];
						gameObject.SetActive(true);
						bool flag6 = this._SetDiff(gameObject, rowData3.Difficulty, rowData3);
						bool flag7 = flag6;
						if (flag7)
						{
							bool flag8 = rowData3.NestID == this.m_SpecialExpID;
							if (flag8)
							{
								rowData = rowData3;
								rowData2 = expeditionDataByID;
							}
							else
							{
								bool flag9 = rowData == null || (rowData.NestID != this.m_SpecialExpID && (rowData.Difficulty < rowData3.Difficulty || (rowData.Difficulty == rowData3.Difficulty && rowData2.Stars[0] < expeditionDataByID.Stars[0])));
								if (flag9)
								{
									rowData2 = expeditionDataByID;
									rowData = rowData3;
								}
							}
						}
					}
				}
				IL_1DB:
				j++;
				continue;
				goto IL_1DB;
			}
			bool flag10 = rowData == null;
			if (flag10)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("This category has no diffs that can be selected, " + this.m_Catergory.ToString(), null, null, null, null, null);
			}
			else
			{
				this._TrySelectDiff(rowData);
			}
		}

		// Token: 0x0600F3E0 RID: 62432 RVA: 0x00368750 File Offset: 0x00366950
		private bool _SetDiff(GameObject go, int index, NestListTable.RowData rowData)
		{
			IXUISprite ixuisprite = go.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)rowData.NestID);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnDiffClicked));
			GameObject gameObject = go.transform.Find("Lock").gameObject;
			SceneRefuseReason sceneRefuseReason = this._LevelDoc.CanLevelOpen(this._doc.GetSceneIDByExpID(rowData.NestID));
			gameObject.SetActive(sceneRefuseReason != SceneRefuseReason.Admit);
			return sceneRefuseReason == SceneRefuseReason.Admit;
		}

		// Token: 0x0600F3E1 RID: 62433 RVA: 0x003687DC File Offset: 0x003669DC
		private void _OnDiffClicked(IXUISprite iSp)
		{
			NestListTable.RowData byNestID = XNestDocument.NestListData.GetByNestID((int)iSp.ID);
			this._TrySelectDiff(byNestID);
		}

		// Token: 0x0600F3E2 RID: 62434 RVA: 0x00368804 File Offset: 0x00366A04
		private void _TrySelectDiff(NestListTable.RowData rowData)
		{
			bool flag = rowData == null;
			if (!flag)
			{
				uint sceneIDByExpID = this._doc.GetSceneIDByExpID(rowData.NestID);
				SceneRefuseReason sceneRefuseReason = this._LevelDoc.CanLevelOpen(sceneIDByExpID);
				bool flag2 = sceneRefuseReason == SceneRefuseReason.Admit;
				if (flag2)
				{
					this.m_SpecialExpID = -1;
					this._SelectDiff(rowData.Difficulty);
					this.OnComboBoxChange(rowData);
				}
				else
				{
					SceneRefuseReason sceneRefuseReason2 = sceneRefuseReason;
					if (sceneRefuseReason2 != SceneRefuseReason.PreScene_Notfinish)
					{
						if (sceneRefuseReason2 == SceneRefuseReason.Level_NotEnough)
						{
							SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneIDByExpID);
							bool flag3 = sceneData != null;
							if (flag3)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL", new object[]
								{
									sceneData.RequiredLevel
								}), "fece00");
							}
						}
					}
					else
					{
						SceneTable.RowData sceneData2 = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneIDByExpID);
						bool flag4 = sceneData2 != null;
						if (flag4)
						{
							int unFinishedPreSceneID = this._LevelDoc.GetUnFinishedPreSceneID(sceneData2);
							int expIDBySceneID = this._doc.GetExpIDBySceneID((uint)unFinishedPreSceneID);
							ExpeditionTable.RowData expeditionDataByID = this._doc.GetExpeditionDataByID(expIDBySceneID);
							bool flag5 = expeditionDataByID != null;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("LEVEL_REQUIRE_PRELEVEL", new object[]
								{
									XExpeditionDocument.GetFullName(expeditionDataByID)
								}), "fece00");
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F3E3 RID: 62435 RVA: 0x00368954 File Offset: 0x00366B54
		private void _SelectDiff(int index)
		{
			for (int i = 1; i < base.uiBehaviour.m_DiffSelectList.Count; i++)
			{
				base.uiBehaviour.m_DiffSelectList[i].SetActive(i == index);
			}
		}

		// Token: 0x0600F3E4 RID: 62436 RVA: 0x003689A0 File Offset: 0x00366BA0
		private void OnComboBoxChange(NestListTable.RowData nestListData)
		{
			this.m_Difficulty = nestListData.Difficulty;
			ExpeditionTable.RowData expeditionDataByID = this._doc.GetExpeditionDataByID(nestListData.NestID);
			bool flag = expeditionDataByID == null;
			if (!flag)
			{
				base.uiBehaviour.m_rewardBtn.ID = (ulong)((long)nestListData.Type);
				base.uiBehaviour.m_rankBtn.ID = (ulong)((long)nestListData.Type);
				base.uiBehaviour.m_rewardBtn.gameObject.SetActive(expeditionDataByID.CostCountType == 0);
				base.uiBehaviour.m_rankBtn.gameObject.SetActive(expeditionDataByID.CostCountType == 0);
				bool flag2 = expeditionDataByID.Stars[0] == 0U;
				if (flag2)
				{
					base.uiBehaviour.m_starImageGo.SetActive(false);
				}
				else
				{
					base.uiBehaviour.m_starImageGo.SetActive(true);
					base.uiBehaviour.m_starLab.SetText(expeditionDataByID.Stars[0].ToString());
				}
				base.uiBehaviour.m_NestName.SetText(expeditionDataByID.DNExpeditionName);
				base.uiBehaviour.m_NestMember.SetText(expeditionDataByID.PlayerNumber.ToString());
				base.uiBehaviour.m_NestPPT.SetText(string.Format("[{0}]{1}[-]", (expeditionDataByID.DisplayPPT <= XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic)) ? this.m_PPTEnoughColor : this.m_PPTNotEnoughColor, expeditionDataByID.DisplayPPT.ToString()));
				base.uiBehaviour.m_NestLevel.SetText(expeditionDataByID.RequiredLevel.ToString());
				base.uiBehaviour.m_NestEquipText.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("NEST_DIFFICULTY_EQUIP_TEXT_", (this.m_Catergory * 10 + this.m_Difficulty).ToString())));
				base.uiBehaviour.m_RewardPool.ReturnAll(false);
				base.uiBehaviour.m_quanMinSpr.gameObject.SetActive(this.m_Difficulty != 4);
				base.uiBehaviour.m_LeftCountGo.SetActive(this.m_Difficulty != 4);
				base.uiBehaviour.m_MyPPT.gameObject.SetActive(this.m_Difficulty == 4);
				base.uiBehaviour.m_NestPPT.gameObject.SetActive(this.m_Difficulty == 4);
				Vector3 tplPos = base.uiBehaviour.m_RewardPool.TplPos;
				bool flag3 = expeditionDataByID.ViewableDropList != null;
				if (flag3)
				{
					for (int i = 0; i < expeditionDataByID.ViewableDropList.Length; i++)
					{
						GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
						gameObject.transform.parent = base.uiBehaviour.m_RewardPool._tpl.transform.parent;
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)expeditionDataByID.ViewableDropList[i], 0, false);
						gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(base.uiBehaviour.m_RewardPool.TplWidth * i), tplPos.y);
						IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)expeditionDataByID.ViewableDropList[i];
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
					}
				}
				bool bEnable = this._doc.TeamCategoryMgr.IsExpOpened(expeditionDataByID);
				base.uiBehaviour.m_GoBattle.SetEnable(bEnable, false);
				base.uiBehaviour.m_GoBattle.ID = (ulong)((long)expeditionDataByID.DNExpeditionID);
				base.uiBehaviour.m_GoBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEnterClicked));
				base.uiBehaviour.m_SweepButton.ID = (ulong)((long)expeditionDataByID.DNExpeditionID);
				base.uiBehaviour.m_SweepButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSweepButtonClicked));
				this.SetupSweepCost(expeditionDataByID);
				base.uiBehaviour.m_Fatigue.SetVisible(false);
				uint sceneIDByExpID = this._doc.GetSceneIDByExpID(expeditionDataByID.DNExpeditionID);
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneIDByExpID);
				bool flag4 = sceneData != null;
				if (flag4)
				{
					bool flag5 = sceneData.FatigueCost.Count > 0;
					if (flag5)
					{
						for (int j = 0; j < sceneData.FatigueCost.Count; j++)
						{
							int num = sceneData.FatigueCost[j, 0];
							bool flag6 = num == 6;
							if (flag6)
							{
								base.uiBehaviour.m_Fatigue.SetVisible(true);
								base.uiBehaviour.m_Fatigue.SetText(sceneData.FatigueCost[j, 1].ToString());
								break;
							}
						}
					}
				}
				base.uiBehaviour.m_LeftCountGo.SetActive(expeditionDataByID.CostCountType != 0);
				base.uiBehaviour.m_Free.SetActive(expeditionDataByID.CostCountType == 0);
				base.uiBehaviour.m_FirstPassDropGo.SetActive(expeditionDataByID.CostCountType == 0);
				base.uiBehaviour.m_NormalDropGo.SetActive(expeditionDataByID.CostCountType != 0);
			}
		}

		// Token: 0x0600F3E5 RID: 62437 RVA: 0x00368F0C File Offset: 0x0036710C
		private void SetupSweepCost(ExpeditionTable.RowData expData)
		{
			uint sceneIDByExpID = this._doc.GetSceneIDByExpID(expData.DNExpeditionID);
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneIDByExpID);
			bool flag = sceneData.SweepTicket != null && sceneData.SweepTicket.Length != 0;
			if (flag)
			{
				base.uiBehaviour.m_SweepButton.SetVisible(true);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_SweepCostItem, (int)sceneData.SweepTicket[0], 0, false);
				base.uiBehaviour.m_SweepCostItemNum.SetText("x1");
				IXUISprite ixuisprite = base.uiBehaviour.m_SweepCostItem.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)sceneData.SweepTicket[0];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			else
			{
				base.uiBehaviour.m_SweepButton.SetVisible(false);
			}
		}

		// Token: 0x0600F3E6 RID: 62438 RVA: 0x0036900B File Offset: 0x0036720B
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshLeftCount();
		}

		// Token: 0x0600F3E7 RID: 62439 RVA: 0x0036901C File Offset: 0x0036721C
		protected override void OnShow()
		{
			base.OnShow();
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			base.uiBehaviour.m_MyPPT.SetText(((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic)).ToString());
			this.RefreshLeftCount();
		}

		// Token: 0x0600F3E8 RID: 62440 RVA: 0x00369080 File Offset: 0x00367280
		protected override void OnHide()
		{
			bool flag = this._nestStarRewardHandler != null;
			if (flag)
			{
				this._nestStarRewardHandler.SetVisible(false);
			}
			base.uiBehaviour.m_NestBg.SetTexturePath("");
			this.m_SpecialExpID = -1;
			base.OnHide();
		}

		// Token: 0x0600F3E9 RID: 62441 RVA: 0x003690CC File Offset: 0x003672CC
		private void OnClickLockedDificulty(IXUISprite spr)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NEST_DIFFICULTY_LOCK_MSG"), "fece00");
		}

		// Token: 0x0600F3EA RID: 62442 RVA: 0x003690EC File Offset: 0x003672EC
		public void RefreshLeftCount()
		{
			int dayCount = this._doc.GetDayCount(TeamLevelType.TeamLevelNest, null);
			int dayMaxCount = this._doc.GetDayMaxCount(TeamLevelType.TeamLevelNest, null);
			this._SetSpirit(dayCount, dayMaxCount);
		}

		// Token: 0x0600F3EB RID: 62443 RVA: 0x0036911F File Offset: 0x0036731F
		private void _SetSpirit(int cur, int total)
		{
			base.uiBehaviour.m_LeftCount.SetText(string.Format("{0}/{1}", cur, total));
		}

		// Token: 0x0600F3EC RID: 62444 RVA: 0x0036914C File Offset: 0x0036734C
		private bool _OnAddFatigueClick(IXUIButton sp)
		{
			DlgBase<XBuyCountView, XBuyCountBehaviour>.singleton.ActiveShow(TeamLevelType.TeamLevelNest);
			return true;
		}

		// Token: 0x0600F3ED RID: 62445 RVA: 0x0036916C File Offset: 0x0036736C
		protected bool OnCloseClicked(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F3EE RID: 62446 RVA: 0x00369188 File Offset: 0x00367388
		private bool OnSweepButtonClicked(IXUIButton button)
		{
			this._sweepDoc.TrySweepQuery(0U, (uint)button.ID, 1U);
			return true;
		}

		// Token: 0x0600F3EF RID: 62447 RVA: 0x003691B0 File Offset: 0x003673B0
		private bool _OnEnterClicked(IXUIButton go)
		{
			ExpeditionTable.RowData expeditionDataByID = this._doc.GetExpeditionDataByID((int)go.ID);
			float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SceneGotoPower"));
			bool flag = XSingleton<PPTCheckMgr>.singleton.CheckMyPPT(Mathf.FloorToInt(expeditionDataByID.DisplayPPT * num));
			if (flag)
			{
				this._OnRealEnter((int)go.ID);
			}
			else
			{
				XSingleton<PPTCheckMgr>.singleton.ShowPPTNotEnoughDlg(go.ID, new ButtonClickEventHandler(this._OnRealEnterClicked));
			}
			return true;
		}

		// Token: 0x0600F3F0 RID: 62448 RVA: 0x0036923C File Offset: 0x0036743C
		private bool _OnRealEnterClicked(IXUIButton go)
		{
			this._OnRealEnter((int)go.ID);
			return true;
		}

		// Token: 0x0600F3F1 RID: 62449 RVA: 0x00369260 File Offset: 0x00367460
		private bool _OnClickPreviewRewardBtn(IXUIButton go)
		{
			bool flag = go == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._NestDoc.NestType = (uint)go.ID;
				bool flag2 = this._nestStarRewardHandler != null;
				if (flag2)
				{
					this._nestStarRewardHandler.SetVisible(true);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600F3F2 RID: 62450 RVA: 0x003692AC File Offset: 0x003674AC
		private bool _OnClickRankBtn(IXUIButton go)
		{
			FirstPassDocument.Doc.SetCurDataByNestType((int)go.ID);
			DlgBase<FirstPassRankView, FitstpassRankBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x0600F3F3 RID: 62451 RVA: 0x003692DE File Offset: 0x003674DE
		private void _onClickQuanMinSpr(IXUISprite spr)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Nest_QuanMin);
		}

		// Token: 0x0600F3F4 RID: 62452 RVA: 0x003692F4 File Offset: 0x003674F4
		private void _OnRealEnter(int id)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(id);
		}

		// Token: 0x0600F3F5 RID: 62453 RVA: 0x00369318 File Offset: 0x00367518
		private void _OnItemClicked(IXUISprite iSp)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)iSp.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, iSp, false, 0U);
		}

		// Token: 0x040068B8 RID: 26808
		private XExpeditionDocument _doc;

		// Token: 0x040068B9 RID: 26809
		private XTeamDocument _teamDoc;

		// Token: 0x040068BA RID: 26810
		private XLevelDocument _LevelDoc;

		// Token: 0x040068BB RID: 26811
		private XNestDocument _NestDoc;

		// Token: 0x040068BC RID: 26812
		private XSweepDocument _sweepDoc = null;

		// Token: 0x040068BD RID: 26813
		private NestStarRewardHandler _nestStarRewardHandler;

		// Token: 0x040068BE RID: 26814
		private int m_Catergory;

		// Token: 0x040068BF RID: 26815
		private int m_Difficulty;

		// Token: 0x040068C0 RID: 26816
		private int m_SpecialExpID = -1;

		// Token: 0x040068C1 RID: 26817
		private IXUICheckBox[] m_TabCheckboxs;

		// Token: 0x040068C2 RID: 26818
		private Dictionary<int, ExpeditionTable.RowData> m_FirstOpenExpCache = new Dictionary<int, ExpeditionTable.RowData>();

		// Token: 0x040068C3 RID: 26819
		private List<int> m_IDCache = new List<int>();

		// Token: 0x040068C4 RID: 26820
		private List<string> m_NameCache = new List<string>();

		// Token: 0x040068C5 RID: 26821
		private string m_PPTEnoughColor;

		// Token: 0x040068C6 RID: 26822
		private string m_PPTNotEnoughColor;
	}
}
