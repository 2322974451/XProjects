using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C09 RID: 3081
	internal class XGuildDonateView : DlgBase<XGuildDonateView, XGuildDonateBehavior>
	{
		// Token: 0x170030DE RID: 12510
		// (get) Token: 0x0600AF02 RID: 44802 RVA: 0x0021101C File Offset: 0x0020F21C
		public override string fileName
		{
			get
			{
				return "Guild/GuildDonation";
			}
		}

		// Token: 0x170030DF RID: 12511
		// (get) Token: 0x0600AF03 RID: 44803 RVA: 0x00211034 File Offset: 0x0020F234
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030E0 RID: 12512
		// (get) Token: 0x0600AF04 RID: 44804 RVA: 0x00211048 File Offset: 0x0020F248
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030E1 RID: 12513
		// (get) Token: 0x0600AF05 RID: 44805 RVA: 0x0021105C File Offset: 0x0020F25C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AF06 RID: 44806 RVA: 0x0021106F File Offset: 0x0020F26F
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600AF07 RID: 44807 RVA: 0x00211079 File Offset: 0x0020F279
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600AF08 RID: 44808 RVA: 0x00211083 File Offset: 0x0020F283
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x170030E2 RID: 12514
		// (get) Token: 0x0600AF09 RID: 44809 RVA: 0x00211090 File Offset: 0x0020F290
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AF0A RID: 44810 RVA: 0x002110A3 File Offset: 0x0020F2A3
		protected override void Init()
		{
			base.Init();
			this._growthDoc = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
			this.InitProperties();
		}

		// Token: 0x0600AF0B RID: 44811 RVA: 0x002110C4 File Offset: 0x0020F2C4
		protected override void OnHide()
		{
			this.toSelectID = 0U;
			this.DonateType = GuildDonateType.DailyDonate;
			base.OnHide();
		}

		// Token: 0x0600AF0C RID: 44812 RVA: 0x002110DC File Offset: 0x0020F2DC
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.RankRoot.gameObject.SetActive(false);
			base.uiBehaviour.RankBtn.gameObject.SetActive(true);
			XGuildDonateDocument.Doc.SendGetDonateBaseInfo();
			base.uiBehaviour.TodayTab.ForceSetFlag(true);
			base.uiBehaviour.dailyTab.ForceSetFlag(this.DonateType == GuildDonateType.DailyDonate);
			base.uiBehaviour.WeeklyTab.ForceSetFlag(this.DonateType == GuildDonateType.WeeklyDonate);
			base.uiBehaviour.GrowthTab.ForceSetFlag(this.DonateType == GuildDonateType.GrowthDonate);
			bool flag = this.DonateType == GuildDonateType.GrowthDonate;
			if (flag)
			{
				this.OnSelectGrowthDonation(base.uiBehaviour.GrowthTab);
			}
			this.UpdateDonationWrapContent();
		}

		// Token: 0x0600AF0D RID: 44813 RVA: 0x002111B0 File Offset: 0x0020F3B0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600AF0E RID: 44814 RVA: 0x002111BC File Offset: 0x0020F3BC
		private void InitProperties()
		{
			base.uiBehaviour.RankRoot.gameObject.SetActive(true);
			base.uiBehaviour.DonationContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DonateItemUpdate));
			base.uiBehaviour.RankContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DonateRankItemUpdate));
			base.uiBehaviour.HistoryTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.SelectedHistoryTab));
			base.uiBehaviour.TodayTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.SelectedTodayTab));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickCloseBtn));
			base.uiBehaviour.dailyTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectDailyDonation));
			base.uiBehaviour.WeeklyTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectWeeklyDonation));
			base.uiBehaviour.GrowthTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectGrowthDonation));
			base.uiBehaviour.RankCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseRankView));
			base.uiBehaviour.RankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowRankView));
			base.uiBehaviour.m_GrowthRecordBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGrowthListBtnClick));
			base.uiBehaviour.m_GrowthRecordCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGrowthListCloseBtnClick));
		}

		// Token: 0x0600AF0F RID: 44815 RVA: 0x00211340 File Offset: 0x0020F540
		private bool OnGrowthListBtnClick(IXUIButton btn)
		{
			this.ShowGrowthList();
			return true;
		}

		// Token: 0x0600AF10 RID: 44816 RVA: 0x0021135C File Offset: 0x0020F55C
		private bool OnGrowthListCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_GrowthRecordList.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600AF11 RID: 44817 RVA: 0x00211388 File Offset: 0x0020F588
		private bool OnShowRankView(IXUIButton button)
		{
			base.uiBehaviour.RankRoot.gameObject.SetActive(true);
			this.UpdateRankContent();
			return true;
		}

		// Token: 0x0600AF12 RID: 44818 RVA: 0x002113BC File Offset: 0x0020F5BC
		private bool OnCloseRankView(IXUIButton button)
		{
			base.uiBehaviour.RankRoot.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600AF13 RID: 44819 RVA: 0x002113E8 File Offset: 0x0020F5E8
		private bool OnSelectWeeklyDonation(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				this.DonateType = GuildDonateType.WeeklyDonate;
				base.uiBehaviour.RankBtn.gameObject.SetActive(false);
				base.uiBehaviour.m_DonateFrame.gameObject.SetActive(true);
				base.uiBehaviour.m_GrowthFrame.gameObject.SetActive(false);
				this.UpdateDonationWrapContent();
			}
			return true;
		}

		// Token: 0x0600AF14 RID: 44820 RVA: 0x0021145C File Offset: 0x0020F65C
		private bool OnSelectDailyDonation(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				this.DonateType = GuildDonateType.DailyDonate;
				base.uiBehaviour.RankBtn.gameObject.SetActive(true);
				base.uiBehaviour.m_DonateFrame.gameObject.SetActive(true);
				base.uiBehaviour.m_GrowthFrame.gameObject.SetActive(false);
				this.UpdateDonationWrapContent();
			}
			return true;
		}

		// Token: 0x0600AF15 RID: 44821 RVA: 0x002114D0 File Offset: 0x0020F6D0
		private bool OnSelectGrowthDonation(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				this.DonateType = GuildDonateType.GrowthDonate;
				base.uiBehaviour.RankBtn.gameObject.SetActive(false);
				base.uiBehaviour.m_DonateFrame.gameObject.SetActive(false);
				base.uiBehaviour.m_GrowthFrame.gameObject.SetActive(true);
				this.SetupGrowthDonate();
				this._growthDoc.QueryGrowthRecordList();
			}
			return true;
		}

		// Token: 0x0600AF16 RID: 44822 RVA: 0x00211550 File Offset: 0x0020F750
		private bool OnclickCloseBtn(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AF17 RID: 44823 RVA: 0x0021156C File Offset: 0x0020F76C
		private bool SelectedTodayTab(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				this._rankType = DonateRankType.TodayRank;
				this.UpdateRankContent();
			}
			return true;
		}

		// Token: 0x0600AF18 RID: 44824 RVA: 0x00211599 File Offset: 0x0020F799
		private void UpdateRankContent()
		{
			this.UpdateRankWrapContent();
			this.UpdateMyRank();
		}

		// Token: 0x0600AF19 RID: 44825 RVA: 0x002115AC File Offset: 0x0020F7AC
		private bool SelectedHistoryTab(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				this._rankType = DonateRankType.HistoryRank;
				this.UpdateRankContent();
			}
			return true;
		}

		// Token: 0x0600AF1A RID: 44826 RVA: 0x002115DC File Offset: 0x0020F7DC
		private void DonateRankItemUpdate(Transform itemTransform, int index)
		{
			GuildDonateRankInfo rankInfoByIndex = XGuildDonateDocument.Doc.GetRankInfoByIndex(index, this._rankType);
			bool flag = rankInfoByIndex != null;
			if (flag)
			{
				IXUILabel ixuilabel = itemTransform.Find("Win").GetComponent("XUILabel") as IXUILabel;
				bool flag2 = this._rankType == DonateRankType.HistoryRank;
				if (flag2)
				{
					ixuilabel.SetText(rankInfoByIndex.totalCount.ToString());
				}
				else
				{
					ixuilabel.SetText(rankInfoByIndex.todayCount.ToString());
				}
				IXUILabel ixuilabel2 = itemTransform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(rankInfoByIndex.roleName);
				IXUISprite ixuisprite = itemTransform.Find("Rank").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel3 = itemTransform.Find("Rank3").GetComponent("XUILabel") as IXUILabel;
				bool flag3 = index < 3;
				if (flag3)
				{
					ixuilabel3.gameObject.SetActive(false);
					ixuisprite.gameObject.SetActive(true);
					ixuisprite.SetSprite(ixuisprite.spriteName.Substring(0, ixuisprite.spriteName.Length - 1) + (index + 1));
				}
				else
				{
					ixuisprite.gameObject.SetActive(false);
					ixuilabel3.gameObject.SetActive(true);
					ixuilabel3.SetText((index + 1).ToString());
				}
			}
		}

		// Token: 0x0600AF1B RID: 44827 RVA: 0x00211748 File Offset: 0x0020F948
		private void DonateItemUpdate(Transform itemTransform, int index)
		{
			GuildDonateItemInfo donateItemInfoByIndex = XGuildDonateDocument.Doc.GetDonateItemInfoByIndex(this.DonateType, index);
			Transform transform = itemTransform.Find("MemberTpl");
			bool flag = donateItemInfoByIndex != null;
			if (flag)
			{
				IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
				bool flag2 = donateItemInfoByIndex.id == this.toSelectID;
				if (flag2)
				{
					ixuicheckBox.ForceSetFlag(true);
				}
				else
				{
					ixuicheckBox.ForceSetFlag(false);
				}
				transform.gameObject.SetActive(true);
				itemTransform.gameObject.SetActive(true);
				Transform transform2 = itemTransform.Find("MemberTpl/Item");
				bool flag3 = donateItemInfoByIndex.itemType > 0U;
				ulong num;
				if (flag3)
				{
					DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(donateItemInfoByIndex.taskID);
					num = (ulong)((dailyTaskTableInfoByID == null) ? 0U : dailyTaskTableInfoByID.BQ[0, 0]);
				}
				else
				{
					num = (ulong)donateItemInfoByIndex.itemID;
				}
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform2.gameObject, (int)num, 1, false);
				IXUISprite ixuisprite = transform2.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
				IXUILabel ixuilabel = itemTransform.Find("MemberTpl/Contribution").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(donateItemInfoByIndex.getCount + "/" + donateItemInfoByIndex.needCount);
				IXUILabel ixuilabel2 = itemTransform.Find("MemberTpl/Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(donateItemInfoByIndex.name);
				IXUILabel ixuilabel3 = itemTransform.Find("MemberTpl/Owned/Num").GetComponent("XUILabel") as IXUILabel;
				bool flag4 = donateItemInfoByIndex.itemType > 0U;
				ulong num2;
				if (flag4)
				{
					num2 = (ulong)((long)XBagDocument.BagDoc.GetItemsByTypeAndQuality(1UL << (int)donateItemInfoByIndex.itemType, (ItemQuality)donateItemInfoByIndex.itemQuality).Count);
				}
				else
				{
					num2 = XBagDocument.BagDoc.GetItemCount((int)donateItemInfoByIndex.itemID);
				}
				ixuilabel3.SetText(num2.ToString());
				Transform transform3 = itemTransform.Find("MemberTpl/Complete");
				IXUIButton ixuibutton = itemTransform.Find("MemberTpl/Do").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)donateItemInfoByIndex.id;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickDonateBtn));
				ixuibutton.gameObject.SetActive(true);
				transform3.gameObject.SetActive(false);
				ixuibutton.gameObject.SetActive(true);
				bool flag5 = donateItemInfoByIndex.roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag5)
				{
					ixuibutton.gameObject.SetActive(false);
				}
				else
				{
					bool flag6 = donateItemInfoByIndex.getCount >= donateItemInfoByIndex.needCount;
					if (flag6)
					{
						ixuibutton.gameObject.SetActive(false);
						transform3.gameObject.SetActive(true);
					}
					else
					{
						ixuibutton.SetEnable(true, false);
					}
				}
			}
			else
			{
				transform.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600AF1C RID: 44828 RVA: 0x001AE886 File Offset: 0x001ACA86
		private void OnClickItemIcon(IXUISprite uiSprite)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)uiSprite.ID, null);
		}

		// Token: 0x0600AF1D RID: 44829 RVA: 0x00211A60 File Offset: 0x0020FC60
		private bool OnclickDonateBtn(IXUIButton button)
		{
			GuildDonateItemInfo donationItemInfoWithTypeID = XGuildDonateDocument.Doc.GetDonationItemInfoWithTypeID(this.DonateType, (uint)button.ID);
			uint canDonateMaxNum = XGuildDonateDocument.Doc.GetCanDonateMaxNum();
			bool flag = donationItemInfoWithTypeID != null;
			if (flag)
			{
				bool flag2 = donationItemInfoWithTypeID.itemType > 0U;
				ulong num;
				if (flag2)
				{
					num = (ulong)((long)XBagDocument.BagDoc.GetItemsByTypeAndQuality(1UL << (int)donationItemInfoWithTypeID.itemType, (ItemQuality)donationItemInfoWithTypeID.itemQuality).Count);
				}
				else
				{
					num = XBagDocument.BagDoc.GetItemCount((int)donationItemInfoWithTypeID.itemID);
				}
				bool flag3 = num == 0UL;
				if (flag3)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DonateItemLess"), "fece00");
				}
				else
				{
					bool flag4 = canDonateMaxNum == 0U;
					if (flag4)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DonateReachedMax"), "fece00");
					}
					else
					{
						this._curDonateID = donationItemInfoWithTypeID.id;
						uint max = (uint)Mathf.Min(new float[]
						{
							(uint)num,
							donationItemInfoWithTypeID.needCount - donationItemInfoWithTypeID.getCount,
							canDonateMaxNum
						});
						bool flag5 = donationItemInfoWithTypeID.itemType > 0U;
						if (flag5)
						{
							DlgBase<XShowSameQualityItemsView, XShowSameQualityItemsBehavior>.singleton.ShowView(new XShowSameQualityItemsView.SelectItemsHandler(this.OnSelectQualityItem), (ItemType)donationItemInfoWithTypeID.itemType, (ItemQuality)donationItemInfoWithTypeID.itemQuality, XStringDefineProxy.GetString("WeelyCommitTip"), (int)donationItemInfoWithTypeID.needCount, (int)donationItemInfoWithTypeID.getCount);
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSettingNumberDialog(donationItemInfoWithTypeID.itemID, XSingleton<XStringTable>.singleton.GetString("ItemDonate"), 1U, max, 1U, new ModalSettingNumberDlg.GetInputNumber(this.GetItemNumer), 50);
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600AF1E RID: 44830 RVA: 0x00211C08 File Offset: 0x0020FE08
		private void OnSelectQualityItem(List<ulong> itemList)
		{
			bool flag = itemList.Count > 0;
			if (flag)
			{
				XGuildDonateDocument.Doc.SendDonateMemberItem(this._curDonateID, (uint)itemList.Count, itemList);
			}
		}

		// Token: 0x0600AF1F RID: 44831 RVA: 0x00211C40 File Offset: 0x0020FE40
		private void GetItemNumer(uint number)
		{
			bool flag = number > 0U;
			if (flag)
			{
				XGuildDonateDocument.Doc.SendDonateMemberItem(this._curDonateID, number, null);
			}
		}

		// Token: 0x0600AF20 RID: 44832 RVA: 0x00211C6C File Offset: 0x0020FE6C
		private void UpdateMyRank()
		{
			int myRankIndex = XGuildDonateDocument.Doc.GetMyRankIndex(this._rankType);
			bool flag = myRankIndex >= 0;
			if (flag)
			{
				base.uiBehaviour.MyRankItem.gameObject.SetActive(true);
				this.DonateRankItemUpdate(base.uiBehaviour.MyRankItem, myRankIndex);
			}
			else
			{
				base.uiBehaviour.MyRankItem.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600AF21 RID: 44833 RVA: 0x00211CE0 File Offset: 0x0020FEE0
		public void RefreshUI(GuildDonateType type)
		{
			bool flag = this.DonateType == type;
			if (flag)
			{
				this.UpdateRankWrapContent();
			}
		}

		// Token: 0x0600AF22 RID: 44834 RVA: 0x00211D04 File Offset: 0x0020FF04
		public void RefreshCurDonateTypeUI()
		{
			this.UpdateDonationWrapContent();
		}

		// Token: 0x0600AF23 RID: 44835 RVA: 0x00211D10 File Offset: 0x0020FF10
		private void UpdateRankWrapContent()
		{
			int rankContentCount = XGuildDonateDocument.Doc.GetRankContentCount(this._rankType);
			XGuildDonateDocument.Doc.SortRankListWithRankType(this._rankType);
			base.uiBehaviour.LeftScrollView.ResetPosition();
			base.uiBehaviour.RankContent.SetContentCount(rankContentCount, false);
			bool flag = rankContentCount > 0;
			if (flag)
			{
				base.uiBehaviour.EmptyRank.gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.EmptyRank.gameObject.SetActive(true);
			}
			this.UpdateDonationWrapContent();
		}

		// Token: 0x0600AF24 RID: 44836 RVA: 0x00211DA8 File Offset: 0x0020FFA8
		private void UpdateDonationWrapContent()
		{
			int donationListCount = XGuildDonateDocument.Doc.GetDonationListCount(this.DonateType);
			base.uiBehaviour.DonationContent.SetContentCount(donationListCount, false);
			base.uiBehaviour.RightScrollView.ResetPosition();
		}

		// Token: 0x0600AF25 RID: 44837 RVA: 0x00211DEB File Offset: 0x0020FFEB
		public void SetupGrowthDonate()
		{
			this._growthDoc.QueryGrowthRecordList();
			base.uiBehaviour.m_GrowthRecordList.gameObject.SetActive(false);
			this.RefreshGrowthDonateTimes();
			this._growthDoc.QueryBuildRank();
			this.Refresh();
		}

		// Token: 0x0600AF26 RID: 44838 RVA: 0x00211E2C File Offset: 0x0021002C
		public void Refresh()
		{
			bool flag = !base.uiBehaviour.m_GrowthFrame.gameObject.activeInHierarchy;
			if (!flag)
			{
				base.uiBehaviour.m_GrowthDonatePool.ReturnAll(false);
				Vector3 tplPos = base.uiBehaviour.m_GrowthDonatePool.TplPos;
				for (int i = 0; i < this._growthDoc.GuildZiCaiTableReader.Table.Length; i++)
				{
					GuildZiCai.RowData rowData = this._growthDoc.GuildZiCaiTableReader.Table[i];
					GameObject gameObject = base.uiBehaviour.m_GrowthDonatePool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(base.uiBehaviour.m_GrowthDonatePool.TplWidth * i), tplPos.y);
					GameObject gameObject2 = gameObject.transform.Find("Item").gameObject;
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)rowData.itemid);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, itemConf, 0, false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject2, (int)rowData.itemid);
					IXUILabel ixuilabel = gameObject2.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetVisible(true);
					ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)rowData.itemid);
					ixuilabel.SetText(string.Format("{0}{1}[ffffff]/1", (itemCount != 0UL) ? "" : "[e60012]", itemCount));
					IXUIButton ixuibutton = gameObject.transform.Find("Do").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)rowData.itemid;
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDoBtnClick));
					Transform transform = gameObject.transform.Find("box");
					transform.gameObject.SetActive(i == this._growthDoc.GuildZiCaiTableReader.Table.Length - 1);
					this.SetReward(gameObject.transform.Find("Private"), rowData.rolerewards);
					this.SetReward(gameObject.transform.Find("Guild"), rowData.guildrewards);
					IXUILabel ixuilabel2 = gameObject.transform.Find("label").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(rowData.ShowTips));
				}
			}
		}

		// Token: 0x0600AF27 RID: 44839 RVA: 0x002120AC File Offset: 0x002102AC
		public bool OnDoBtnClick(IXUIButton btn)
		{
			this._growthDoc.QueryGuildGrowthDonate((uint)btn.ID);
			return true;
		}

		// Token: 0x0600AF28 RID: 44840 RVA: 0x002120D4 File Offset: 0x002102D4
		public void SetReward(Transform t, SeqListRef<uint> list)
		{
			bool flag = list.Count == 0;
			if (!flag)
			{
				IXUILabel ixuilabel = t.Find("t0").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.Find("t0/icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel2 = t.Find("t1").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = t.Find("t1/icon").GetComponent("XUISprite") as IXUISprite;
				ixuilabel.SetText(list[0, 1].ToString());
				ixuisprite.spriteName = XBagDocument.GetItemSmallIcon((int)list[0, 0], 0U);
				bool flag2 = list.Count <= 1;
				if (flag2)
				{
					ixuilabel2.SetVisible(false);
					ixuisprite2.SetVisible(false);
				}
				else
				{
					ixuilabel2.SetVisible(true);
					ixuisprite2.SetVisible(true);
					ixuilabel2.SetText(list[1, 1].ToString());
					ixuisprite2.spriteName = XBagDocument.GetItemSmallIcon((int)list[1, 0], 0U);
				}
			}
		}

		// Token: 0x0600AF29 RID: 44841 RVA: 0x002121FA File Offset: 0x002103FA
		public void ShowGrowthList()
		{
			base.uiBehaviour.m_GrowthRecordList.gameObject.SetActive(true);
			this.RefreshDonateList();
		}

		// Token: 0x0600AF2A RID: 44842 RVA: 0x0021221C File Offset: 0x0021041C
		public void RefreshDonateList()
		{
			base.uiBehaviour.m_GrowthRecordEmpty.gameObject.SetActive(this._growthDoc.RecordList.Count == 0);
			base.uiBehaviour.m_GrowthRecordPool.ReturnAll(false);
			int machineTimeFrom = XSingleton<UiUtility>.singleton.GetMachineTimeFrom1970();
			for (int i = 0; i < this._growthDoc.RecordList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_GrowthRecordPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_GrowthRecordPool.TplPos.x, base.uiBehaviour.m_GrowthRecordPool.TplPos.y - (float)(base.uiBehaviour.m_GrowthRecordPool.TplHeight * i));
				IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Time").GetComponent("XUILabel") as IXUILabel;
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._growthDoc.RecordList[i].ItemID);
				ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("GuildGrowthRecord"), this._growthDoc.RecordList[i].Name, itemConf.ItemName[0]));
				int num = machineTimeFrom - (int)this._growthDoc.RecordList[i].Time;
				ixuilabel2.SetText(XSingleton<UiUtility>.singleton.TimeAgoFormatString((num > 0) ? num : 60));
			}
		}

		// Token: 0x0600AF2B RID: 44843 RVA: 0x002123C4 File Offset: 0x002105C4
		public void CheckRecordRefresh()
		{
			bool activeInHierarchy = base.uiBehaviour.m_GrowthRecordList.gameObject.activeInHierarchy;
			if (activeInHierarchy)
			{
				this.RefreshDonateList();
			}
		}

		// Token: 0x0600AF2C RID: 44844 RVA: 0x002123F4 File Offset: 0x002105F4
		public void RefreshGrowthDonateTimes()
		{
			bool flag = !base.uiBehaviour.m_GrowthFrame.gameObject.activeInHierarchy;
			if (!flag)
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GuildJZDonateMaxCount");
				base.uiBehaviour.m_GrowthWeekTimes.SetText(string.Format("{0}/{1}", this._growthDoc.WeekDonateTimes, @int));
			}
		}

		// Token: 0x040042AF RID: 17071
		private XGuildGrowthDocument _growthDoc;

		// Token: 0x040042B0 RID: 17072
		private DonateRankType _rankType = DonateRankType.TodayRank;

		// Token: 0x040042B1 RID: 17073
		public GuildDonateType DonateType = GuildDonateType.DailyDonate;

		// Token: 0x040042B2 RID: 17074
		public uint _curDonateID = 0U;

		// Token: 0x040042B3 RID: 17075
		public uint toSelectID = 0U;
	}
}
