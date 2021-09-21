using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BE9 RID: 3049
	internal class XFlowerRankHandler : DlgHandlerBase
	{
		// Token: 0x170030A5 RID: 12453
		// (get) Token: 0x0600AD97 RID: 44439 RVA: 0x00203E78 File Offset: 0x00202078
		protected override string FileName
		{
			get
			{
				return "GameSystem/FlowerRankHandler";
			}
		}

		// Token: 0x0600AD98 RID: 44440 RVA: 0x00203E90 File Offset: 0x00202090
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
			this._doc.View = this;
			Transform tabTpl = base.PanelObject.transform.FindChild("TabList/Panel/TabTpl");
			this.m_TabControl.SetTabTpl(tabTpl);
			this.m_RankScrollView = (base.PanelObject.transform.FindChild("Rank/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_AwardScrollView = (base.PanelObject.transform.FindChild("RewardPanel/Reward/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_NoRankTip = base.PanelObject.transform.FindChild("Empty/NA");
			this.m_NoRankTip.gameObject.SetActive(false);
			this.m_NoRankTipLabel = (this.m_NoRankTip.FindChild("tip").GetComponent("XUILabel") as IXUILabel);
			this.m_YesterdayReward = (base.PanelObject.transform.FindChild("BtnYesterdayReward").GetComponent("XUIButton") as IXUIButton);
			this.m_YesterdayRewardClose = (base.PanelObject.transform.FindChild("RewardPanel/Reward/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_NormalRankContent = (base.PanelObject.transform.FindChild("Rank/Panel/NormalList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_NormalRankContent.InitContent();
			this.m_ActivityRankContetn = (base.PanelObject.transform.FindChild("Rank/Panel/ActiveList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ActivityRankContetn.InitContent();
			this.m_MyRankFrameNormal = base.PanelObject.transform.FindChild("Rank/MyRankFrame/NormalList/Tpl").gameObject;
			this.m_MyRankFrameNormal.gameObject.SetActive(false);
			this.m_MyRankFrameActivity = base.PanelObject.transform.FindChild("Rank/MyRankFrame/ActiveList/Tpl").gameObject;
			this.m_MyRankFrameActivity.gameObject.SetActive(false);
			this.m_CharacterInfoFrame = base.PanelObject.transform.FindChild("Rank/CharacterInfoFrame").gameObject;
			this.m_CharName = (this.m_CharacterInfoFrame.transform.FindChild("TitleFrame/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_CharName.SetText("");
			this.m_CharProfession = (this.m_CharacterInfoFrame.transform.FindChild("TitleFrame/ProfIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_CharGulid = (this.m_CharacterInfoFrame.transform.FindChild("TitleFrame/GulidIcon").GetComponent("XUISprite") as IXUISprite);
			this.m_CharGulid.SetSprite("");
			this.m_CharGulidName = (this.m_CharacterInfoFrame.transform.FindChild("TitleFrame/Guild").GetComponent("XUILabel") as IXUILabel);
			this.m_CharGulidName.SetText("");
			this.m_PlayerSnapshot = (this.m_CharacterInfoFrame.transform.FindChild("CharacterFrame/Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_Designation = (this.m_CharacterInfoFrame.transform.FindChild("CharacterFrame/Designation").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation);
			this.m_Designation.gameObject.SetActive(false);
			this.m_AwardContent = (base.PanelObject.transform.FindChild("RewardPanel/Reward/Panel/RewardList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			Transform tabTpl2 = base.PanelObject.transform.FindChild("Log/TabList/Panel/TabTpl");
			this.m_FlowerTabControl.SetTabTpl(tabTpl2);
			this.m_MyFlowersPanel = (base.PanelObject.transform.FindChild("Log").GetComponent("XUISprite") as IXUISprite);
			this.m_MyFlowersPanel.gameObject.SetActive(false);
			this.m_MyFlowersSendTitle = (base.PanelObject.transform.FindChild("Log/SendTitle").GetComponent("XUILabel") as IXUILabel);
			this.m_MyFlowersReceiveTitle = (base.PanelObject.transform.FindChild("Log/ReceiveTitle").GetComponent("XUILabel") as IXUILabel);
			IXUILabel ixuilabel = base.PanelObject.transform.FindChild("Log/ReceiveTitle/Value").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText("");
			this.m_MyFlowersReceiveTitle.gameObject.SetActive(false);
			for (int i = 0; i < 3; i++)
			{
				IXUILabel ixuilabel2 = base.PanelObject.transform.Find(string.Format("Log/Flower/{0}", i + 1)).GetComponent("XUILabel") as IXUILabel;
				this.m_DicFlowerCount.Add((ulong)((long)(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_RED_ROSE) + i)), ixuilabel2);
				ixuilabel2.SetText("");
			}
			string[] array = new string[]
			{
				"SendPanel",
				"ReceivePanel"
			};
			string[] array2 = new string[]
			{
				"SendList",
				"ReceiveList"
			};
			for (int j = 0; j < array2.Length; j++)
			{
				this.m_MyFlowersScrollView[j] = (base.PanelObject.transform.FindChild(string.Format("Log/{0}", array[j])).GetComponent("XUIScrollView") as IXUIScrollView);
				this.m_MyFlowerLogContent[j] = (base.PanelObject.transform.FindChild(string.Format("Log/{0}/{1}", array[j], array2[j])).GetComponent("XUIWrapContent") as IXUIWrapContent);
				this.m_MyFlowerLogContent[j].InitContent();
				this.m_MyFlowerLogContent[j].gameObject.SetActive(false);
			}
			this.m_YesterdayRewardPanel = base.PanelObject.transform.FindChild("RewardPanel");
			this.m_YesterdayRewardPanel.gameObject.SetActive(false);
			this.m_CommonTip = (base.PanelObject.transform.FindChild("Rank/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekTip1 = (base.PanelObject.transform.FindChild("Rank/WeekTip1").GetComponent("XUILabel") as IXUILabel);
			this.m_WeekTip2 = (base.PanelObject.transform.FindChild("Rank/WeekTip2").GetComponent("XUILabel") as IXUILabel);
			this.m_ActivityTip = (base.PanelObject.transform.FindChild("Rank/WeekTip3").GetComponent("XUILabel") as IXUILabel);
			this.m_ActivityRewardPreviewBtn = (base.PanelObject.transform.FindChild("Rank/MyRankFrame/ActiveList/Tpl/BtnMy").GetComponent("XUIButton") as IXUIButton);
			this.m_ActivityGetRewardBtn = (base.PanelObject.transform.FindChild("Rank/MyRankFrame/ActiveList/Tpl/BtnGet").GetComponent("XUIButton") as IXUIButton);
			this.m_FlowerLogBtn = (base.PanelObject.transform.FindChild("Rank/MyRankFrame/NormalList/Tpl/BtnMy").GetComponent("XUIButton") as IXUIButton);
			this.m_ActivityRewardPreviewPanel = base.PanelObject.transform.FindChild("ActiveRewardPanel");
			this.m_ActivityRewardPreviewPanel.gameObject.SetActive(false);
			this.m_ActivityRewardPreviewClose = (base.PanelObject.transform.FindChild("ActiveRewardPanel/Reward/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ActivityRewardContent = (base.PanelObject.transform.FindChild("ActiveRewardPanel/Reward/Panel/RewardList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ActivityRewardScrollview = (base.PanelObject.transform.FindChild("ActiveRewardPanel/Reward/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ActivityRewardTip = (base.PanelObject.transform.FindChild("ActiveRewardPanel/T").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600AD99 RID: 44441 RVA: 0x002046B0 File Offset: 0x002028B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_NormalRankContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnRankWrapContentItemUpdated));
			this.m_ActivityRankContetn.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnRankWrapContentItemUpdated));
			this.m_MyFlowersPanel.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLogPanelClosed));
			this.m_MyFlowerLogContent[0].RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnMyFlowersSendLogWrapContentItemUpdated));
			this.m_MyFlowerLogContent[1].RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnMyFlowersReceivedLogWrapContentItemUpdated));
			this.m_FlowerLogBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMyFlowerClicked));
			this.m_AwardContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnAwardWrapContentItemUpdated));
			this.m_YesterdayReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnYesterdayRewardClicked));
			this.m_YesterdayRewardClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnYesterdayRewardClose));
			this.m_ActivityRewardPreviewBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnActivityRewardPreviewClicked));
			this.m_ActivityGetRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnActivityRewardGetClicked));
			this.m_ActivityRewardPreviewClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnActivityRewardCloseClicked));
			this.m_ActivityRewardContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnActivityRewardWrapContentItemUpdated));
		}

		// Token: 0x0600AD9A RID: 44442 RVA: 0x00204804 File Offset: 0x00202A04
		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("XFlowerRankView", 1);
			this.m_CommonTip.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_TIP4"));
			this.m_WeekTip1.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_TIP1"));
			this.m_WeekTip2.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_TIP2"));
			this.m_NoRankTipLabel.SetText(XStringDefineProxy.GetString("FLOWER_NO_RANK_TIP"));
			this.m_ActivityTip.SetText(XStringDefineProxy.GetString("FLOWER_ACTIVITY_TIP5", new object[]
			{
				XSingleton<XGlobalConfig>.singleton.GetInt("FlowerActivityAward")
			}));
			this.m_ActivityRewardTip.SetText(XStringDefineProxy.GetString("FLOWER_NO_RANK_TIP6"));
			this.ShowRank();
		}

		// Token: 0x0600AD9B RID: 44443 RVA: 0x002048DD File Offset: 0x00202ADD
		public void ShowRank()
		{
			this._tabs = this.m_TabControl.SetupTabs(this.DefaultTab, new XUITabControl.UITabControlCallback(this.OnTabSelectionChanged), true, 1f);
			this.ShowDefaultTabUI(this.DefaultTab);
			this.RefreshRedPoint();
		}

		// Token: 0x0600AD9C RID: 44444 RVA: 0x0020491D File Offset: 0x00202B1D
		protected override void OnHide()
		{
			base.Return3DAvatarPool();
			base.OnHide();
			this._PlayerDummy = null;
			this.DefaultTab = XSysDefine.XSys_Flower_Rank_Today;
			this.ClearPreTabTextures();
		}

		// Token: 0x0600AD9D RID: 44445 RVA: 0x00204947 File Offset: 0x00202B47
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("XFlowerRankView", 1);
			XSingleton<X3DAvatarMgr>.singleton.EnableCommonDummy(this._PlayerDummy, this.m_PlayerSnapshot, true);
		}

		// Token: 0x0600AD9E RID: 44446 RVA: 0x00204976 File Offset: 0x00202B76
		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this._PlayerDummy = null;
			this._doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600AD9F RID: 44447 RVA: 0x0020499B File Offset: 0x00202B9B
		private void ShowDefaultTabUI(XSysDefine sys)
		{
			this.OnTabSelectionChanged((ulong)((long)sys));
		}

		// Token: 0x0600ADA0 RID: 44448 RVA: 0x002049A8 File Offset: 0x00202BA8
		public void RefreshRedPoint()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				for (int i = 0; i < this._tabs.Length; i++)
				{
					bool flag2 = this._tabs[i] != null;
					if (flag2)
					{
						this._tabs[i].gameObject.transform.FindChild("RedPoint").gameObject.SetActive(false);
					}
				}
				bool flag3 = this._tabs.Length > 1 && this._tabs[1] != null;
				if (flag3)
				{
					this._tabs[1].gameObject.transform.FindChild("RedPoint").gameObject.SetActive(this._doc.CanGetAward);
				}
				bool flag4 = this._tabs.Length > 4 && this._tabs[4] != null;
				if (flag4)
				{
					this._tabs[4].gameObject.transform.FindChild("RedPoint").gameObject.SetActive(this._doc.CanGetActivityAward);
				}
				bool flag5 = this._doc.currentSelectRankTab == XRankType.FlowerYesterdayRank;
				if (flag5)
				{
					this.m_YesterdayReward.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(this._doc.CanGetAward);
				}
				bool flag6 = this._doc.currentSelectRankTab == XRankType.FlowerActivityRank;
				if (flag6)
				{
					this.m_ActivityGetRewardBtn.SetVisible(this._doc.CanGetActivityAward);
				}
			}
		}

		// Token: 0x0600ADA1 RID: 44449 RVA: 0x00204B30 File Offset: 0x00202D30
		public void ClearPreTabTextures()
		{
			foreach (KeyValuePair<GameObject, IXUITexture> keyValuePair in this._WrapTextureList)
			{
				IXUITexture value = keyValuePair.Value;
				value.ID = 0UL;
				value.SetRuntimeTex(null, true);
			}
			this._WrapTextureList.Clear();
		}

		// Token: 0x0600ADA2 RID: 44450 RVA: 0x00204BA8 File Offset: 0x00202DA8
		public void OnTabSelectionChanged(ulong id)
		{
			this.ClearPreTabTextures();
			this.FillCharacterInfoFrame(this.emptyUA);
			XSysDefine xsysDefine = (XSysDefine)id;
			switch (xsysDefine)
			{
			case XSysDefine.XSys_Flower_Rank_Today:
				this._doc.currentSelectRankTab = XRankType.FlowerTodayRank;
				goto IL_CE;
			case XSysDefine.XSys_Flower_Rank_Yesterday:
				this._doc.currentSelectRankTab = XRankType.FlowerYesterdayRank;
				this.RefreshRedPoint();
				goto IL_CE;
			case XSysDefine.XSys_Flower_Rank_History:
				this._doc.currentSelectRankTab = XRankType.FlowerHistoryRank;
				goto IL_CE;
			case XSysDefine.XSys_Flower_Rank_Week:
				this._doc.currentSelectRankTab = XRankType.FlowerWeekRank;
				goto IL_CE;
			case XSysDefine.XSys_Flower_Rank_Activity:
				this._doc.currentSelectRankTab = XRankType.FlowerActivityRank;
				this.RefreshRedPoint();
				goto IL_CE;
			}
			XSingleton<XDebug>.singleton.AddErrorLog("Invalid system id: ", xsysDefine.ToString(), null, null, null, null);
			IL_CE:
			this.m_SendRoleID = 0UL;
			this.ShowTabUI();
			this._doc.ReqRankList(this._doc.currentSelectRankTab);
		}

		// Token: 0x0600ADA3 RID: 44451 RVA: 0x00204CAC File Offset: 0x00202EAC
		private void OnRankWrapContentItemUpdated(Transform t, int index)
		{
			XRankType currentSelectRankTab = this._doc.currentSelectRankTab;
			this.rankDataList = this._doc.GetRankList(currentSelectRankTab);
			bool flag = this.rankDataList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", currentSelectRankTab.ToString(), null, null, null, null);
			}
			else
			{
				bool flag2 = index >= this.rankDataList.rankList.Count || index < 0;
				if (!flag2)
				{
					IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
					ixuisprite.ID = (ulong)((long)index);
					ixuilabel.ID = (ulong)((long)index);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRankItemClicked));
					this.SetWrapRankItem(t.gameObject, this.rankDataList.rankList[index], index);
					this.RankListToggleSelection(t.gameObject, (ulong)this._doc.currentSelectIndex == (ulong)((long)index));
					bool flag3 = (ulong)this._doc.currentSelectIndex == (ulong)((long)index);
					if (flag3)
					{
						this.m_LastSelect = t.gameObject;
					}
				}
			}
		}

		// Token: 0x0600ADA4 RID: 44452 RVA: 0x00204DE4 File Offset: 0x00202FE4
		private void OnActivityRewardWrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index >= this._doc.GetActivityAwardCount() + 1;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index >= rankDataList.rankList.Count", null, null, null, null, null);
			}
			else
			{
				this.SetActivityAwardItem(t.gameObject, index);
			}
		}

		// Token: 0x0600ADA5 RID: 44453 RVA: 0x00204E30 File Offset: 0x00203030
		private void SetActivityAwardItem(GameObject go, int rankIndex)
		{
			IXUILabel ixuilabel = go.transform.FindChild("T1").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
			string[] array = new string[]
			{
				"N1",
				"N2",
				"N3"
			};
			bool flag = rankIndex < 3;
			bool flag2;
			if (flag)
			{
				ixuisprite.SetSprite(array[rankIndex]);
				ixuisprite.SetVisible(true);
				ixuilabel2.SetVisible(false);
				ixuilabel.SetVisible(false);
				flag2 = true;
			}
			else
			{
				bool flag3 = rankIndex < this._doc.GetActivityAwardCount();
				if (flag3)
				{
					ixuisprite.SetVisible(false);
					ixuilabel2.SetText("No." + (rankIndex + 1));
					ixuilabel2.SetVisible(true);
					ixuilabel.SetVisible(false);
					flag2 = true;
				}
				else
				{
					ixuisprite.SetVisible(false);
					ixuilabel2.SetVisible(false);
					ixuilabel.SetVisible(true);
					flag2 = false;
				}
			}
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < 4; i++)
			{
				list.Add(go.transform.FindChild(string.Format("Item{0}", i)));
				list[i].gameObject.SetActive(false);
			}
			bool flag4 = flag2;
			if (flag4)
			{
				SeqListRef<int> activityAwardInfo = this._doc.GetActivityAwardInfo(rankIndex);
				for (int j = 0; j < activityAwardInfo.Count; j++)
				{
					bool flag5 = j < list.Count;
					if (flag5)
					{
						list[j].gameObject.SetActive(true);
						this.SetAwardInfo(list[j], activityAwardInfo[j, 0], activityAwardInfo[j, 1]);
					}
				}
			}
			else
			{
				SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("FlowerActivityAwardList", false);
				for (int k = 0; k < (int)sequenceList.Count; k++)
				{
					bool flag6 = k < list.Count;
					if (flag6)
					{
						list[k].gameObject.SetActive(true);
						this.SetAwardInfo(list[k], sequenceList[k, 0], sequenceList[k, 1]);
					}
				}
			}
		}

		// Token: 0x0600ADA6 RID: 44454 RVA: 0x002050B8 File Offset: 0x002032B8
		private void SetAwardInfo(Transform t, int itemID, int itemCount)
		{
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(t.gameObject, itemID, itemCount, false);
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)itemID);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		// Token: 0x0600ADA7 RID: 44455 RVA: 0x0020511C File Offset: 0x0020331C
		private void OnAwardWrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index >= this._doc.AwardListInfo.listCount;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index >= rankDataList.rankList.Count", null, null, null, null, null);
			}
			else
			{
				this.SetAwardItem(t.gameObject, index);
			}
		}

		// Token: 0x0600ADA8 RID: 44456 RVA: 0x0020516C File Offset: 0x0020336C
		private void SetAwardItem(GameObject go, int rankIndex)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
			string[] array = new string[]
			{
				"N1",
				"N2",
				"N3"
			};
			bool flag = rankIndex < 3;
			if (flag)
			{
				ixuisprite.SetSprite(array[rankIndex]);
				ixuisprite.SetVisible(true);
				ixuilabel.SetVisible(false);
			}
			else
			{
				ixuisprite.SetVisible(false);
				ixuilabel.SetText("No." + (rankIndex + 1));
				ixuilabel.SetVisible(true);
			}
			IXUIButton ixuibutton = go.transform.FindChild("Btn").GetComponent("XUIButton") as IXUIButton;
			bool flag2 = rankIndex == this._doc.AwardListInfo.selfIndex && this._doc.AwardListInfo.canGetAward;
			ixuibutton.SetEnable(flag2, false);
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetAwardBtnClicked));
			bool sysRedPointState = XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(XSysDefine.XSys_FlowerRank);
			ixuibutton.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(flag2 && sysRedPointState);
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < 4; i++)
			{
				list.Add(go.transform.FindChild(string.Format("Item{0}", i)));
				list[i].gameObject.SetActive(false);
			}
			uint num = 0U;
			SeqListRef<int> awardInfo = this._doc.GetAwardInfo(rankIndex, out num, true);
			bool flag3 = awardInfo.Count == 0;
			if (!flag3)
			{
				IXUISpriteAnimation ixuispriteAnimation = go.transform.FindChild("ChImage").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
				ixuispriteAnimation.gameObject.SetActive(num > 0U);
				XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
				DesignationTable.RowData byID = specificDocument._DesignationTable.GetByID((int)num);
				bool flag4 = byID != null;
				if (flag4)
				{
					ixuispriteAnimation.SetFrameRate(16);
					ixuispriteAnimation.SetNamePrefix(byID.Effect);
					IXUISprite ixuisprite2 = go.transform.FindChild("ChImage").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.MakePixelPerfect();
				}
				for (int j = 0; j < awardInfo.Count; j++)
				{
					bool flag5 = j < list.Count;
					if (flag5)
					{
						list[j].gameObject.SetActive(true);
						this.SetAwardInfo(list[j], awardInfo[j, 0], awardInfo[j, 1]);
					}
				}
			}
		}

		// Token: 0x0600ADA9 RID: 44457 RVA: 0x00205450 File Offset: 0x00203650
		private void OnRankItemClicked(IXUISprite sp)
		{
			bool flag = this.m_LastSelect != null;
			if (flag)
			{
				this.RankListToggleSelection(this.m_LastSelect, false);
			}
			this.RankListToggleSelection(sp.gameObject, true);
			this.m_LastSelect = sp.gameObject;
			this._doc.SelectItem((uint)sp.ID, false);
		}

		// Token: 0x0600ADAA RID: 44458 RVA: 0x002054AC File Offset: 0x002036AC
		private bool OnGetAwardBtnClicked(IXUIButton sp)
		{
			this._doc.ReqAward();
			return true;
		}

		// Token: 0x0600ADAB RID: 44459 RVA: 0x002054CC File Offset: 0x002036CC
		private void RankListToggleSelection(GameObject go, bool bSelect)
		{
			IXUISprite ixuisprite = go.transform.FindChild("SelectBg").GetComponent("XUISprite") as IXUISprite;
			bool flag = ixuisprite != null;
			if (flag)
			{
				if (bSelect)
				{
					ixuisprite.SetAlpha(1f);
				}
				else
				{
					ixuisprite.SetAlpha(0f);
				}
			}
		}

		// Token: 0x0600ADAC RID: 44460 RVA: 0x00205523 File Offset: 0x00203723
		public void UpdateCharacterInfo(GetUnitAppearanceRes oRes)
		{
			this.FillCharacterInfoFrame(oRes.UnitAppearance);
		}

		// Token: 0x0600ADAD RID: 44461 RVA: 0x00205534 File Offset: 0x00203734
		private void FillCharacterInfoFrame(UnitAppearance data)
		{
			this.m_CharName.SetText(data.unitName);
			this.m_CharProfession.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)data.unitType));
			bool flag = data.uID > 0UL;
			if (flag)
			{
				this._PlayerDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, data, this.m_PlayerSnapshot, this._PlayerDummy);
			}
			else
			{
				XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this._PlayerDummy);
				this._PlayerDummy = null;
			}
		}

		// Token: 0x0600ADAE RID: 44462 RVA: 0x002055C8 File Offset: 0x002037C8
		private void ShowTabUI()
		{
			this.m_CharGulidName.SetText("");
			this.m_CharGulid.SetSprite("");
			this.m_NormalRankContent.gameObject.SetActive(this._doc.currentSelectRankTab != XRankType.FlowerActivityRank);
			this.m_ActivityRankContetn.gameObject.SetActive(this._doc.currentSelectRankTab == XRankType.FlowerActivityRank);
			this.m_MyRankFrameNormal.gameObject.SetActive(this._doc.currentSelectRankTab != XRankType.FlowerActivityRank);
			this.m_MyRankFrameActivity.gameObject.SetActive(this._doc.currentSelectRankTab == XRankType.FlowerActivityRank);
			bool flag = this._doc.currentSelectRankTab != XRankType.FlowerActivityRank;
			if (flag)
			{
				this.m_ActivityRankContetn.SetContentCount(0, false);
			}
			bool flag2 = this._doc.currentSelectRankTab == XRankType.FlowerActivityRank;
			if (flag2)
			{
				this.m_NormalRankContent.SetContentCount(0, false);
			}
			this.m_YesterdayReward.gameObject.SetActive(this._doc.currentSelectRankTab == XRankType.FlowerYesterdayRank);
			this.m_WeekTip1.gameObject.SetActive(this._doc.currentSelectRankTab == XRankType.FlowerWeekRank);
			this.m_WeekTip2.gameObject.SetActive(this._doc.currentSelectRankTab == XRankType.FlowerWeekRank);
			this.m_CommonTip.gameObject.SetActive(this._doc.currentSelectRankTab != XRankType.FlowerWeekRank && this._doc.currentSelectRankTab != XRankType.FlowerActivityRank);
			this.m_ActivityTip.gameObject.SetActive(this._doc.currentSelectRankTab == XRankType.FlowerActivityRank);
			this.m_Designation.gameObject.SetActive(false);
		}

		// Token: 0x0600ADAF RID: 44463 RVA: 0x0020578A File Offset: 0x0020398A
		public void RefreshAwardInfo()
		{
			this.m_AwardContent.SetContentCount(this._doc.AwardListInfo.listCount, false);
			this.m_AwardScrollView.ResetPosition();
		}

		// Token: 0x0600ADB0 RID: 44464 RVA: 0x002057B8 File Offset: 0x002039B8
		public void ReReqRank()
		{
			bool flag = !base.IsVisible() || this._doc == null;
			if (!flag)
			{
				this._doc.ReqRankList(this._doc.currentSelectRankTab);
			}
		}

		// Token: 0x0600ADB1 RID: 44465 RVA: 0x002057F8 File Offset: 0x002039F8
		public void RefreshRankWindow()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.ShowTabUI();
				this.m_MyRankFrameNormal.SetActive(this._doc.currentSelectRankTab != XRankType.FlowerActivityRank);
				this.m_MyRankFrameActivity.SetActive(this._doc.currentSelectRankTab == XRankType.FlowerActivityRank);
				XBaseRankList rankList = this._doc.GetRankList(this._doc.currentSelectRankTab);
				bool flag2 = rankList == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", this._doc.currentSelectRankTab.ToString(), null, null, null, null);
				}
				else
				{
					this.m_NoRankTip.gameObject.SetActive(rankList.rankList.Count == 0);
					GameObject go = (this._doc.currentSelectRankTab == XRankType.FlowerActivityRank) ? this.m_MyRankFrameActivity : this.m_MyRankFrameNormal;
					IXUIWrapContent ixuiwrapContent = (this._doc.currentSelectRankTab == XRankType.FlowerActivityRank) ? this.m_ActivityRankContetn : this.m_NormalRankContent;
					ixuiwrapContent.SetContentCount(rankList.rankList.Count, false);
					this.SetMyRankFrame(go, rankList.GetLatestMyRankInfo());
					this.m_RankScrollView.ResetPosition();
					bool flag3 = this.m_LastSelect != null;
					if (flag3)
					{
						this.RankListToggleSelection(this.m_LastSelect, false);
					}
					uint index = 0U;
					for (int i = 0; i < rankList.rankList.Count; i++)
					{
						bool flag4 = this.m_SendRoleID == rankList.rankList[i].id;
						if (flag4)
						{
							bool flag5 = rankList.rankList.Count > 3;
							if (flag5)
							{
								float position = (rankList.rankList.Count == 1) ? 0f : ((float)i / (float)(rankList.rankList.Count - 1));
								this.m_RankScrollView.SetPosition(position);
							}
							index = (uint)i;
							break;
						}
					}
					bool flag6 = rankList.rankList.Count > 0;
					if (flag6)
					{
						this._doc.SelectItem(index, true);
					}
				}
			}
		}

		// Token: 0x0600ADB2 RID: 44466 RVA: 0x00205A14 File Offset: 0x00203C14
		public void RefreshCharacterInfo(XBaseRankInfo info, uint index)
		{
			this.m_CharGulidName.SetText(info.guildname);
			bool flag = info.guildname == "";
			if (flag)
			{
				this.m_CharGulid.SetSprite("");
			}
			else
			{
				this.m_CharGulid.SetSprite(XGuildDocument.GetPortraitName((int)info.guildicon));
			}
			this.m_Designation.gameObject.SetActive(false);
			bool flag2 = this._doc.currentSelectRankTab == XRankType.FlowerYesterdayRank || this._doc.currentSelectRankTab == XRankType.FlowerHistoryRank;
			if (flag2)
			{
				uint key = 0U;
				bool flag3 = this._doc.GetAwardInfo((int)index, out key, this._doc.currentSelectRankTab == XRankType.FlowerYesterdayRank).Count > 0;
				if (flag3)
				{
					XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
					DesignationTable.RowData byID = specificDocument._DesignationTable.GetByID((int)key);
					this.m_Designation.SetFrameRate(16);
					this.m_Designation.SetNamePrefix(byID.Effect);
					IXUISprite ixuisprite = this.m_Designation.gameObject.transform.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.MakePixelPerfect();
					this.m_Designation.gameObject.SetActive(true);
				}
			}
		}

		// Token: 0x0600ADB3 RID: 44467 RVA: 0x00205B58 File Offset: 0x00203D58
		public void RefreshRankContent()
		{
			IXUIWrapContent ixuiwrapContent = (this._doc.currentSelectRankTab == XRankType.FlowerActivityRank) ? this.m_ActivityRankContetn : this.m_NormalRankContent;
			ixuiwrapContent.RefreshAllVisibleContents();
		}

		// Token: 0x0600ADB4 RID: 44468 RVA: 0x00205B8C File Offset: 0x00203D8C
		private void SetWrapRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				this.SetRank(go, XRankDocument.INVALID_RANK);
			}
			else
			{
				IXUISprite ixuisprite = go.transform.FindChild("headboard/head").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)index);
				IXUITexture value = go.transform.Find("headboard/platHead").GetComponent("XUITexture") as IXUITexture;
				IXUIButton ixuibutton = go.transform.FindChild("BtnSend").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendFlowerClicked));
				bool flag2 = this._doc.currentSelectRankTab == XRankType.FlowerActivityRank;
				if (flag2)
				{
					ixuibutton.SetVisible(!this._doc.IsActivityShowTime());
				}
				else
				{
					ixuibutton.SetVisible(true);
				}
				this.SetBaseRankItem(go, info, index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRankItemRoleClicked));
				this._WrapTextureList[go] = value;
			}
		}

		// Token: 0x0600ADB5 RID: 44469 RVA: 0x00205CCC File Offset: 0x00203ECC
		private void SetBaseRankItem(GameObject go, XBaseRankInfo info, int index)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("headboard/head").GetComponent("XUISprite") as IXUISprite;
			IXUITexture texture = go.transform.Find("headboard/platHead").GetComponent("XUITexture") as IXUITexture;
			IXUISprite spr = go.transform.FindChild("headboard/head/AvatarFrame").GetComponent("XUISprite") as IXUISprite;
			XSingleton<UiUtility>.singleton.ParseHeadIcon(info.setid, spr);
			string text = "";
			bool flag = info == null;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				this.SetRank(go, XRankDocument.INVALID_RANK);
			}
			else
			{
				this.SetDesignation(ixuilabel.gameObject.transform, info.name, 0U);
				this.SetRank(go, info.rank);
				bool flag2 = this._doc.currentSelectRankTab == XRankType.FlowerYesterdayRank || this._doc.currentSelectRankTab == XRankType.FlowerHistoryRank;
				if (flag2)
				{
					uint desID = 0U;
					bool flag3 = this._doc.GetAwardInfo(index, out desID, this._doc.currentSelectRankTab == XRankType.FlowerYesterdayRank).Count != 0;
					if (flag3)
					{
						Transform go2 = go.transform.FindChild("Name");
						this.SetDesignation(go2, info.name, desID);
					}
				}
				bool flag4 = this._doc.currentSelectRankTab == XRankType.FlowerActivityRank;
				if (flag4)
				{
					IXUILabel ixuilabel3 = go.transform.Find("Guild").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite2 = go.transform.FindChild("Guild/icon").GetComponent("XUISprite") as IXUISprite;
					XFlowerRankActivityInfo xflowerRankActivityInfo = info as XFlowerRankActivityInfo;
					bool flag5 = xflowerRankActivityInfo != null;
					if (flag5)
					{
						ixuilabel2.SetText(this.FormatFlowerCount(xflowerRankActivityInfo.flowerCount));
						ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)xflowerRankActivityInfo.profession));
						text = xflowerRankActivityInfo.headPicUrl;
						ixuilabel3.SetText(xflowerRankActivityInfo.guildname);
						ixuisprite2.SetSprite(XGuildDocument.GetPortraitName((int)xflowerRankActivityInfo.guildicon));
						ixuilabel3.SetVisible(xflowerRankActivityInfo.guildname != "");
						ixuisprite2.SetVisible(xflowerRankActivityInfo.guildname != "");
					}
				}
				else
				{
					XFlowerRankNormalInfo xflowerRankNormalInfo = info as XFlowerRankNormalInfo;
					bool flag6 = xflowerRankNormalInfo != null;
					if (flag6)
					{
						IXUILabel ixuilabel4 = go.transform.FindChild("Flower/1").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel5 = go.transform.FindChild("Flower/2").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel6 = go.transform.FindChild("Flower/3").GetComponent("XUILabel") as IXUILabel;
						uint count = 0U;
						uint count2 = 0U;
						uint count3 = 0U;
						xflowerRankNormalInfo.receivedFlowers.TryGetValue((ulong)((long)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_RED_ROSE)), out count);
						xflowerRankNormalInfo.receivedFlowers.TryGetValue((ulong)((long)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_WHITE_ROSE)), out count2);
						xflowerRankNormalInfo.receivedFlowers.TryGetValue((ulong)((long)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_BLUE_ENCHANTRESS)), out count3);
						ixuilabel4.SetText(this.FormatFlowerCount(count));
						ixuilabel5.SetText(this.FormatFlowerCount(count2));
						ixuilabel6.SetText(this.FormatFlowerCount(count3));
						ixuilabel2.SetText(this.FormatFlowerCount(xflowerRankNormalInfo.flowerCount));
						ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)xflowerRankNormalInfo.profession));
						text = xflowerRankNormalInfo.headPicUrl;
					}
				}
				XSingleton<XUICacheImage>.singleton.Load((text != "") ? text : string.Empty, texture, DlgBase<XRankView, XRankBehaviour>.singleton.uiBehaviour);
			}
		}

		// Token: 0x0600ADB6 RID: 44470 RVA: 0x002060C8 File Offset: 0x002042C8
		private void SetMyRankFrame(GameObject go, XBaseRankInfo info)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("headboard/viplevel").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("headboard/head").GetComponent("XUISprite") as IXUISprite;
			IXUITexture ixuitexture = go.transform.Find("headboard/platHead").GetComponent("XUITexture") as IXUITexture;
			IXUILabel ixuilabel3 = go.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
			bool flag = info == null || info.name == "";
			if (flag)
			{
				go.SetActive(false);
			}
			else
			{
				GameObject gameObject = go.transform.FindChild("OutOfRange").gameObject;
				gameObject.SetActive(info.rank == XFlowerRankDocument.INVALID_RANK);
				go.SetActive(true);
				ixuilabel2.gameObject.SetActive(false);
				bool flag2 = this._doc.currentSelectRankTab == XRankType.FlowerActivityRank;
				if (flag2)
				{
					XFlowerRankActivityInfo xflowerRankActivityInfo = info as XFlowerRankActivityInfo;
					bool flag3 = xflowerRankActivityInfo != null;
					if (flag3)
					{
						xflowerRankActivityInfo.profession = (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
						xflowerRankActivityInfo.headPicUrl = ((XSingleton<PDatabase>.singleton.playerInfo != null) ? XSingleton<PDatabase>.singleton.playerInfo.data.pictureLarge : "");
					}
				}
				else
				{
					XFlowerRankNormalInfo xflowerRankNormalInfo = info as XFlowerRankNormalInfo;
					bool flag4 = xflowerRankNormalInfo != null;
					if (flag4)
					{
						xflowerRankNormalInfo.profession = (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
						xflowerRankNormalInfo.headPicUrl = ((XSingleton<PDatabase>.singleton.playerInfo != null) ? XSingleton<PDatabase>.singleton.playerInfo.data.pictureLarge : "");
					}
				}
				this.SetBaseRankItem(go, info, (int)info.rank);
			}
		}

		// Token: 0x0600ADB7 RID: 44471 RVA: 0x002062C8 File Offset: 0x002044C8
		private void SetDesignation(Transform go, string name, uint desID)
		{
			IXUILabelSymbol ixuilabelSymbol = go.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
			DesignationTable.RowData byID = specificDocument._DesignationTable.GetByID((int)desID);
			string inputText = name;
			bool flag = byID != null;
			if (flag)
			{
				bool flag2 = byID.Effect != "";
				if (flag2)
				{
					inputText = string.Format("{0}{1}", XLabelSymbolHelper.FormatDesignation(byID.Atlas, byID.Effect, 16), name);
				}
				else
				{
					inputText = string.Format("{0}{1}{2}", XSingleton<XGlobalConfig>.singleton.GetValue("XUILabelSymbolDesignationColor"), byID.Designation, name);
				}
			}
			ixuilabelSymbol.InputText = inputText;
		}

		// Token: 0x0600ADB8 RID: 44472 RVA: 0x00206374 File Offset: 0x00204574
		private string FormatFlowerCount(uint count)
		{
			bool flag = count >= 100000000U;
			string result;
			if (flag)
			{
				count /= 100000000U;
				string text = string.Format("{0}{1}", count, XStringDefineProxy.GetString("NumberSeparator1"));
				result = text;
			}
			else
			{
				bool flag2 = count >= 100000U;
				if (flag2)
				{
					count /= 10000U;
					string text2 = string.Format("{0}{1}", count, XStringDefineProxy.GetString("NumberSeparator0"));
					result = text2;
				}
				else
				{
					result = count.ToString();
				}
			}
			return result;
		}

		// Token: 0x0600ADB9 RID: 44473 RVA: 0x00206400 File Offset: 0x00204600
		private void SetRank(GameObject go, uint rankIndex)
		{
			IXUILabel ixuilabel = go.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
			bool flag = rankIndex == XRankDocument.INVALID_RANK;
			if (flag)
			{
				ixuilabel.SetVisible(false);
				ixuisprite.SetVisible(false);
			}
			else
			{
				string[] array = new string[]
				{
					"N1",
					"N2",
					"N3"
				};
				bool flag2 = rankIndex < 3U;
				if (flag2)
				{
					ixuisprite.SetSprite(array[(int)rankIndex]);
					ixuisprite.SetVisible(true);
					ixuilabel.SetVisible(false);
				}
				else
				{
					ixuisprite.SetVisible(false);
					ixuilabel.SetText("No." + (rankIndex + 1U));
					ixuilabel.SetVisible(true);
				}
			}
		}

		// Token: 0x0600ADBA RID: 44474 RVA: 0x002064E0 File Offset: 0x002046E0
		private bool OnSendFlowerClicked(IXUIButton btn)
		{
			int num = (int)btn.ID;
			bool flag = num < this.rankDataList.rankList.Count;
			if (flag)
			{
				bool flag2 = this.rankDataList.rankList[num].id == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					this.m_SendRoleID = 0UL;
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FLOWER_SEND_ERR_SELF"), "fece00");
					return true;
				}
				this.m_SendRoleID = this.rankDataList.rankList[num].id;
				DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.ShowBoard(this.rankDataList.rankList[num].id, this.rankDataList.rankList[num].name);
			}
			return true;
		}

		// Token: 0x0600ADBB RID: 44475 RVA: 0x002065BC File Offset: 0x002047BC
		private bool OnMyFlowerClicked(IXUIButton btn)
		{
			this.m_MyFlowersPanel.gameObject.SetActive(true);
			this._doc.ReqMyFlowersInfo();
			this.m_FlowerTabControl.SetupTabs(XSysDefine.XSys_Flower_Log, new XUITabControl.UITabControlCallback(this.OnFlowerTabSelectionChanged), true, 1f);
			return true;
		}

		// Token: 0x0600ADBC RID: 44476 RVA: 0x00206610 File Offset: 0x00204810
		private bool OnActivityRewardPreviewClicked(IXUIButton btn)
		{
			this.m_ActivityRewardPreviewPanel.gameObject.SetActive(true);
			this.m_ActivityRewardContent.SetContentCount(this._doc.GetActivityAwardCount() + 1, false);
			this.m_ActivityRewardScrollview.ResetPosition();
			return true;
		}

		// Token: 0x0600ADBD RID: 44477 RVA: 0x0020665C File Offset: 0x0020485C
		private bool OnActivityRewardCloseClicked(IXUIButton btn)
		{
			this.m_ActivityRewardPreviewPanel.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600ADBE RID: 44478 RVA: 0x00206684 File Offset: 0x00204884
		private bool OnActivityRewardGetClicked(IXUIButton btn)
		{
			XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
			specificDocument.GetFlowerActivityReward();
			return true;
		}

		// Token: 0x0600ADBF RID: 44479 RVA: 0x002066AC File Offset: 0x002048AC
		private void OnFlowerTabSelectionChanged(ulong id)
		{
			XSysDefine myFlowersTab = (XSysDefine)id;
			this._myFlowersTab = myFlowersTab;
			bool flag = this._doc.FlowerPageData == null;
			if (!flag)
			{
				this.RefreshMyFlowersPage();
			}
		}

		// Token: 0x0600ADC0 RID: 44480 RVA: 0x002066E0 File Offset: 0x002048E0
		private void OnLogPanelClosed(IXUISprite spr)
		{
			this.m_MyFlowersPanel.gameObject.SetActive(false);
		}

		// Token: 0x0600ADC1 RID: 44481 RVA: 0x002066F8 File Offset: 0x002048F8
		private void OnRankItemRoleClicked(IXUISprite iSp)
		{
			this._doc.SelectItem((uint)iSp.ID, false);
			XRankType currentSelectRankTab = this._doc.currentSelectRankTab;
			XBaseRankList rankList = this._doc.GetRankList(currentSelectRankTab);
			bool flag = (int)iSp.ID < rankList.rankList.Count;
			if (flag)
			{
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(rankList.rankList[(int)iSp.ID].id, false);
			}
		}

		// Token: 0x0600ADC2 RID: 44482 RVA: 0x0020676C File Offset: 0x0020496C
		private void OnRankItemRoleClicked(IXUITexture iSp)
		{
			this._doc.SelectItem((uint)iSp.ID, false);
			XRankType currentSelectRankTab = this._doc.currentSelectRankTab;
			XBaseRankList rankList = this._doc.GetRankList(currentSelectRankTab);
			bool flag = (int)iSp.ID < rankList.rankList.Count;
			if (flag)
			{
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(rankList.rankList[(int)iSp.ID].id, false);
			}
		}

		// Token: 0x0600ADC3 RID: 44483 RVA: 0x002067E0 File Offset: 0x002049E0
		public void RefreshMyFlowersPage()
		{
			IXUIWrapContent ixuiwrapContent = null;
			List<MapIntItem> list = null;
			int num = 0;
			XSysDefine myFlowersTab = this._myFlowersTab;
			if (myFlowersTab != XSysDefine.XSys_Flower_Log_Send)
			{
				if (myFlowersTab == XSysDefine.XSys_Flower_Log_Receive)
				{
					this.m_MyFlowersSendTitle.gameObject.SetActive(false);
					this.m_MyFlowersReceiveTitle.gameObject.SetActive(true);
					this.m_MyFlowerLogContent[0].gameObject.SetActive(false);
					this.m_MyFlowerLogContent[1].gameObject.SetActive(true);
					ixuiwrapContent = this.m_MyFlowerLogContent[1];
					list = this._doc.FlowerPageData.receiveFlowersTotal;
					List<ReceiveRoleFlowerInfo2Client> receiveRank = this._doc.FlowerPageData.receiveRank;
					num = receiveRank.Count;
				}
			}
			else
			{
				this.m_MyFlowersSendTitle.gameObject.SetActive(true);
				this.m_MyFlowersReceiveTitle.gameObject.SetActive(false);
				this.m_MyFlowerLogContent[0].gameObject.SetActive(true);
				this.m_MyFlowerLogContent[1].gameObject.SetActive(false);
				ixuiwrapContent = this.m_MyFlowerLogContent[0];
				list = this._doc.FlowerPageData.sendFlowersTotal;
				List<FlowerInfo2Client> sendLog = this._doc.FlowerPageData.sendLog;
				num = sendLog.Count;
			}
			foreach (KeyValuePair<ulong, IXUILabel> keyValuePair in this.m_DicFlowerCount)
			{
				keyValuePair.Value.SetText("0");
			}
			uint num2 = 0U;
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = this.m_DicFlowerCount.ContainsKey(list[i].key);
				if (flag)
				{
					this.m_DicFlowerCount[list[i].key].SetText(this.FormatFlowerCount(list[i].value));
				}
				num2 += XFlowerRankDocument.GetFlowerCharmPoint(list[i].key) * list[i].value;
			}
			bool flag2 = this._myFlowersTab == XSysDefine.XSys_Flower_Log_Receive;
			if (flag2)
			{
				IXUILabel ixuilabel = this.m_MyFlowersReceiveTitle.gameObject.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this.FormatFlowerCount(num2));
			}
			ixuiwrapContent.SetContentCount(num, false);
			this.m_MyFlowersScrollView[0].ResetPosition();
			this.m_MyFlowersScrollView[1].ResetPosition();
		}

		// Token: 0x0600ADC4 RID: 44484 RVA: 0x00206A84 File Offset: 0x00204C84
		private void OnMyFlowersSendLogWrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index >= this._doc.FlowerPageData.sendLog.Count || index < 0;
			if (!flag)
			{
				FlowerInfo2Client flowerInfo2Client = this._doc.FlowerPageData.sendLog[this._doc.FlowerPageData.sendLog.Count - 1 - index];
				IXUISprite ixuisprite = t.FindChild("1/Flower").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("1").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("T").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(flowerInfo2Client.roleName);
				ixuilabel2.SetText(this.FormatFlowerCount(flowerInfo2Client.count));
				ixuisprite.SetSprite(string.Format("icon-{0}", flowerInfo2Client.itemID));
				uint count = flowerInfo2Client.count * XFlowerRankDocument.GetFlowerCharmPoint((ulong)flowerInfo2Client.itemID);
				ixuilabel3.SetText(string.Format(XStringDefineProxy.GetString("FLOWER_SEND_LOG"), this.FormatFlowerCount(count)));
			}
		}

		// Token: 0x0600ADC5 RID: 44485 RVA: 0x00206BCC File Offset: 0x00204DCC
		private void OnMyFlowersReceivedLogWrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index >= this._doc.FlowerPageData.receiveRank.Count || index < 0;
			if (!flag)
			{
				ReceiveRoleFlowerInfo2Client receiveRoleFlowerInfo2Client = this._doc.FlowerPageData.receiveRank[index];
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(receiveRoleFlowerInfo2Client.roleName);
				Dictionary<ulong, IXUILabel> dictionary = new Dictionary<ulong, IXUILabel>();
				for (int i = 0; i < 3; i++)
				{
					IXUILabel ixuilabel2 = t.Find(string.Format("Flower/{0}", i + 1)).GetComponent("XUILabel") as IXUILabel;
					dictionary.Add((ulong)((long)(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FLOWER_RED_ROSE) + i)), ixuilabel2);
					ixuilabel2.SetText("0");
				}
				for (int j = 0; j < receiveRoleFlowerInfo2Client.flowers.Count; j++)
				{
					MapIntItem mapIntItem = receiveRoleFlowerInfo2Client.flowers[j];
					bool flag2 = dictionary.ContainsKey(mapIntItem.key);
					if (flag2)
					{
						dictionary[mapIntItem.key].SetText(this.FormatFlowerCount(mapIntItem.value));
					}
				}
			}
		}

		// Token: 0x0600ADC6 RID: 44486 RVA: 0x00206D14 File Offset: 0x00204F14
		private bool OnYesterdayRewardClicked(IXUIButton btn)
		{
			this._doc.ReqAwardList();
			this.m_YesterdayRewardPanel.gameObject.SetActive(true);
			return true;
		}

		// Token: 0x0600ADC7 RID: 44487 RVA: 0x00206D48 File Offset: 0x00204F48
		private bool OnYesterdayRewardClose(IXUIButton btn)
		{
			this.m_YesterdayRewardPanel.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0400417B RID: 16763
		public XUITabControl m_TabControl = new XUITabControl();

		// Token: 0x0400417C RID: 16764
		public XUITabControl m_FlowerTabControl = new XUITabControl();

		// Token: 0x0400417D RID: 16765
		public IXUIWrapContent m_NormalRankContent = null;

		// Token: 0x0400417E RID: 16766
		public IXUIWrapContent m_ActivityRankContetn = null;

		// Token: 0x0400417F RID: 16767
		public GameObject m_MyRankFrameNormal = null;

		// Token: 0x04004180 RID: 16768
		public GameObject m_MyRankFrameActivity = null;

		// Token: 0x04004181 RID: 16769
		private GameObject m_LastSelect;

		// Token: 0x04004182 RID: 16770
		public IXUIWrapContent m_AwardContent = null;

		// Token: 0x04004183 RID: 16771
		public Transform m_YesterdayRewardPanel;

		// Token: 0x04004184 RID: 16772
		public GameObject m_CharacterInfoFrame;

		// Token: 0x04004185 RID: 16773
		public IXUILabel m_CharName;

		// Token: 0x04004186 RID: 16774
		public IXUISprite m_CharProfession;

		// Token: 0x04004187 RID: 16775
		public IXUISprite m_CharGulid;

		// Token: 0x04004188 RID: 16776
		public IXUILabel m_CharGulidName;

		// Token: 0x04004189 RID: 16777
		public IXUISpriteAnimation m_Designation;

		// Token: 0x0400418A RID: 16778
		public IXUIScrollView m_RankScrollView;

		// Token: 0x0400418B RID: 16779
		public IXUIScrollView m_AwardScrollView;

		// Token: 0x0400418C RID: 16780
		public Transform m_NoRankTip;

		// Token: 0x0400418D RID: 16781
		public IXUILabel m_NoRankTipLabel;

		// Token: 0x0400418E RID: 16782
		public IXUIButton m_YesterdayReward;

		// Token: 0x0400418F RID: 16783
		public IXUIButton m_YesterdayRewardClose;

		// Token: 0x04004190 RID: 16784
		public Dictionary<ulong, IXUILabel> m_DicFlowerCount = new Dictionary<ulong, IXUILabel>();

		// Token: 0x04004191 RID: 16785
		public IXUIWrapContent[] m_MyFlowerLogContent = new IXUIWrapContent[2];

		// Token: 0x04004192 RID: 16786
		public IXUISprite m_MyFlowersPanel = null;

		// Token: 0x04004193 RID: 16787
		public IXUILabel m_MyFlowersSendTitle;

		// Token: 0x04004194 RID: 16788
		public IXUILabel m_MyFlowersReceiveTitle;

		// Token: 0x04004195 RID: 16789
		public IXUIScrollView[] m_MyFlowersScrollView = new IXUIScrollView[2];

		// Token: 0x04004196 RID: 16790
		public IUIDummy m_PlayerSnapshot = null;

		// Token: 0x04004197 RID: 16791
		public IXUILabel m_CommonTip;

		// Token: 0x04004198 RID: 16792
		public IXUILabel m_WeekTip1;

		// Token: 0x04004199 RID: 16793
		public IXUILabel m_WeekTip2;

		// Token: 0x0400419A RID: 16794
		public IXUILabel m_ActivityTip;

		// Token: 0x0400419B RID: 16795
		public IXUILabel m_ActivityRewardTip;

		// Token: 0x0400419C RID: 16796
		private XFlowerRankDocument _doc = null;

		// Token: 0x0400419D RID: 16797
		private XDummy _PlayerDummy = null;

		// Token: 0x0400419E RID: 16798
		private XSysDefine _myFlowersTab = XSysDefine.XSys_Flower_Log_Send;

		// Token: 0x0400419F RID: 16799
		private XBaseRankList rankDataList = null;

		// Token: 0x040041A0 RID: 16800
		private IXUICheckBox[] _tabs;

		// Token: 0x040041A1 RID: 16801
		public XSysDefine DefaultTab = XSysDefine.XSys_Flower_Rank_Today;

		// Token: 0x040041A2 RID: 16802
		private UnitAppearance emptyUA = new UnitAppearance();

		// Token: 0x040041A3 RID: 16803
		public Dictionary<GameObject, IXUITexture> _WrapTextureList = new Dictionary<GameObject, IXUITexture>();

		// Token: 0x040041A4 RID: 16804
		public IXUIButton m_ActivityRewardPreviewBtn;

		// Token: 0x040041A5 RID: 16805
		public IXUIButton m_ActivityGetRewardBtn;

		// Token: 0x040041A6 RID: 16806
		public IXUIButton m_FlowerLogBtn;

		// Token: 0x040041A7 RID: 16807
		public Transform m_ActivityRewardPreviewPanel;

		// Token: 0x040041A8 RID: 16808
		public IXUIButton m_ActivityRewardPreviewClose;

		// Token: 0x040041A9 RID: 16809
		public IXUIWrapContent m_ActivityRewardContent;

		// Token: 0x040041AA RID: 16810
		public IXUIScrollView m_ActivityRewardScrollview;

		// Token: 0x040041AB RID: 16811
		private ulong m_SendRoleID = 0UL;
	}
}
