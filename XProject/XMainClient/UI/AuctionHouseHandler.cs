using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AuctionHouseHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Auction/AuctionHouseFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<AuctionHouseDocument>(AuctionHouseDocument.uuID);
			this.TYPEMAX = XSingleton<XGlobalConfig>.singleton.GetInt("AuctHouseTypeMax");
			this.PERADDPRICE = (float)XSingleton<XGlobalConfig>.singleton.GetInt("GuildAuctUpRate") / 100f + 1f;
			this.WaitStartString = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("AuctionHouseWaitStart"));
			this.m_ResultWindow = base.PanelObject.transform.Find("ResultWindow").gameObject;
			this.m_ResultWindow.SetActive(false);
			this.m_ResultTitle = (this.m_ResultWindow.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_ResultCloseBtn = (this.m_ResultWindow.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ResultScrollView = (this.m_ResultWindow.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ResultWrapContent = (this.m_ResultScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			Transform transform = this.m_ResultWrapContent.gameObject.transform.Find("Tpl");
			this.m_ResultPool.SetupPool(transform.parent.gameObject, transform.gameObject, 16U, false);
			this.m_ResultBtn = (base.PanelObject.transform.Find("Result").GetComponent("XUIButton") as IXUIButton);
			this.m_ResultLabel = (this.m_ResultBtn.gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel);
			this.m_Table = (base.PanelObject.transform.Find("TypeList/Table").GetComponent("XUITable") as IXUITable);
			transform = base.PanelObject.transform.Find("TypeList/Table/LevelOneTpl");
			this.m_LevelOnePool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			transform = base.PanelObject.transform.Find("TypeList/Table/LevelTwoTpl");
			this.m_LevelTwoPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_ItemScrollView = (base.PanelObject.transform.Find("Right/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ItemListWrapContent = (this.m_ItemScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_NoneItem = base.PanelObject.transform.Find("None").gameObject;
			this.m_MySpoil = (base.PanelObject.transform.Find("MySpoil").GetComponent("XUILabel") as IXUILabel);
			this.m_NoSpoil = (base.PanelObject.transform.Find("NoSpoil").GetComponent("XUILabel") as IXUILabel);
			this.SetupLevelOneTypeList();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ResultCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnResultCloseBtnClick));
			this.m_ResultBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnResultBtnClick));
			this.m_ItemListWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.ItemWrapListUpdated));
			this.m_ItemListWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.ItemWrapListInit));
			this.m_ResultWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.ResultWrapListUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshGuildTabs = true;
			this.OnTypeCheckBoxClick(this.m_GeneraliSp);
			this.m_TweenToggle = !this.m_TweenToggle;
			IXUICheckBox ixuicheckBox = this.m_GeneraliSp.gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.bChecked = true;
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Auction, false);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Auction, true);
			DlgBase<AuctionView, AuctionBehaviour>.singleton.SetGuildAuctionRedPointState(false);
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._reqToken);
			base.OnHide();
		}

		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._reqToken);
			base.OnUnload();
		}

		public override void RefreshData()
		{
			switch (this._doc.DataState)
			{
			case GuildAuctReqType.GART_ACT_TYPE:
			case GuildAuctReqType.GART_ITEM_TYPE:
			{
				this._signTime = this.GetNowTime();
				this.RefreshItemList(this._doc.ResetScrollView);
				bool refreshGuildTabs = this.RefreshGuildTabs;
				if (refreshGuildTabs)
				{
					this.RefreshGuildTabs = false;
					this.SetupLevelTwoTypeList();
					bool flag = !this.m_TweenToggle;
					if (flag)
					{
						this.m_TweenToggle = !this.m_TweenToggle;
						this.m_SwitchTween.PlayTween(true, -1f);
					}
				}
				bool flag2 = this._doc.LastReq != 0 && this._doc.LastReq < 100;
				if (flag2)
				{
					bool flag3 = this._doc.MySpoils == uint.MaxValue;
					if (flag3)
					{
						this.m_NoSpoil.SetVisible(true);
						this.m_MySpoil.SetVisible(false);
						this.m_NoSpoil.SetText(XStringDefineProxy.GetString("AuctionHouseNoSpoil"));
					}
					else
					{
						this.m_MySpoil.SetVisible(true);
						this.m_NoSpoil.SetVisible(false);
						this.m_MySpoil.SetText(this._doc.MySpoils.ToString());
					}
				}
				else
				{
					this.m_MySpoil.SetVisible(false);
					this.m_NoSpoil.SetVisible(false);
				}
				XSingleton<XTimerMgr>.singleton.KillTimer(this._reqToken);
				bool flag4 = this._doc.ReqTime != -1;
				if (flag4)
				{
					this._reqToken = XSingleton<XTimerMgr>.singleton.SetTimer((float)this._doc.ReqTime, new XTimerMgr.ElapsedEventHandler(this.ForceQueryLastClick), null);
				}
				break;
			}
			case GuildAuctReqType.GART_BUY_AUCT:
			case GuildAuctReqType.GART_BUY_NOW:
			{
				bool flag5 = this._doc.MySpoils == uint.MaxValue;
				if (flag5)
				{
					this.m_NoSpoil.SetText(XStringDefineProxy.GetString("AuctionHouseNoSpoil"));
				}
				else
				{
					this.m_MySpoil.SetText(this._doc.MySpoils.ToString());
				}
				this.RefreshItemList(false);
				break;
			}
			case GuildAuctReqType.GART_AUCT_GUILD_HISTORY:
			case GuildAuctReqType.GART_AUCT_WORLD_HISTORY:
				this.RefreshHistoryList();
				break;
			}
		}

		private bool OnResultCloseBtnClick(IXUIButton btn)
		{
			this.m_ResultWindow.SetActive(false);
			return true;
		}

		private bool OnResultBtnClick(IXUIButton btn)
		{
			this.m_ResultWrapContent.SetContentCount(0, false);
			this.m_ResultWindow.SetActive(true);
			this._doc.QueryAuctionHistory(this._lastClickTabSprite.ID < 100UL);
			return true;
		}

		private void SetupLevelOneTypeList()
		{
			this.m_LevelOnePool.ReturnAll(false);
			this.m_parentTypeTs.Clear();
			for (int i = 0; i < 2; i++)
			{
				GameObject gameObject = this.m_LevelOnePool.FetchGameObject(false);
				this.m_parentTypeTs.Add(gameObject.transform);
				IXUILabel ixuilabel = gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Selected/Label").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = gameObject.transform.Find("Switch").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)((long)i * 100L);
				string @string = XStringDefineProxy.GetString(string.Format("AuctionHouseTitle{0}", i + 1));
				ixuilabel.SetText(@string);
				ixuilabel2.SetText(@string);
				ixuisprite.SetAlpha(0f);
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTypeCheckBoxClick));
				bool flag = i == 0;
				if (flag)
				{
					this.m_GeneraliSp = ixuisprite2;
					this.m_SwitchTween = (gameObject.GetComponent("XUIPlayTween") as IXUITweenTool);
				}
			}
			this.SetupLevelTwoTypeList();
		}

		private void SetupLevelTwoTypeList()
		{
			for (int i = 0; i < this.m_parentTypeTs.Count; i++)
			{
				IXUISprite ixuisprite = this.m_parentTypeTs[i].Find("Switch").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetAlpha(0f);
			}
			this.m_LevelTwoPool.ReturnAll(true);
			for (int j = 0; j < this._doc.GuildActID.Count; j++)
			{
				GameObject gameObject = this.m_LevelTwoPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Selected/Label").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)((long)this._doc.GuildActID[j]);
				string @string = XStringDefineProxy.GetString(string.Format("AuctionHouseAct{0}", this._doc.GuildActID[j]));
				ixuilabel.SetText(@string);
				ixuilabel2.SetText(@string);
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTypeCheckBoxClick));
				Transform transform = this.m_parentTypeTs[0].Find("ChildList");
				IXUISprite ixuisprite3 = this.m_parentTypeTs[0].Find("Switch").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.SetAlpha(1f);
				gameObject.transform.parent = transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3(0f, -((float)transform.childCount - 0.5f) * (float)ixuisprite2.spriteHeight, 0f);
			}
			for (int k = 1; k <= this.TYPEMAX; k++)
			{
				GameObject gameObject2 = this.m_LevelTwoPool.FetchGameObject(false);
				IXUILabel ixuilabel3 = gameObject2.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = gameObject2.transform.Find("Selected/Label").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite4 = gameObject2.GetComponent("XUISprite") as IXUISprite;
				ixuisprite4.ID = (ulong)(100L + (long)k);
				string string2 = XStringDefineProxy.GetString(string.Format("AuctionHouseType{0}", k));
				ixuilabel3.SetText(string2);
				ixuilabel4.SetText(string2);
				ixuisprite4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTypeCheckBoxClick));
				Transform transform2 = this.m_parentTypeTs[1].Find("ChildList");
				IXUISprite ixuisprite5 = this.m_parentTypeTs[1].Find("Switch").GetComponent("XUISprite") as IXUISprite;
				ixuisprite5.SetAlpha(1f);
				gameObject2.transform.parent = transform2;
				gameObject2.transform.localScale = Vector3.one;
				gameObject2.transform.localPosition = new Vector3(0f, -((float)transform2.childCount - 0.5f) * (float)ixuisprite4.spriteHeight, 0f);
			}
			this.m_Table.Reposition();
		}

		private void OnTypeCheckBoxClick(IXUISprite isp)
		{
			bool flag = isp.ID == 0UL;
			if (flag)
			{
				this.m_TweenToggle = !this.m_TweenToggle;
			}
			string @string = XStringDefineProxy.GetString((isp.ID < 100UL) ? "AuctionHouseGuildResult" : "AuctionHouseWorldResult");
			this.m_ResultTitle.SetText(@string);
			this.m_ResultLabel.SetText(@string);
			bool flag2 = !this.RefreshGuildTabs && this._lastClickTabSprite != null && this._lastClickTabSprite.ID == isp.ID;
			if (!flag2)
			{
				this._lastClickTabSprite = isp;
				this._doc.LastReq = (int)isp.ID;
				this._doc.ResetScrollView = true;
				bool flag3 = isp.ID < 100UL;
				if (flag3)
				{
					this._doc.QueryGuildTypeList((int)isp.ID);
				}
				else
				{
					this._doc.QueryWorldTypeList((int)isp.ID - 100);
				}
			}
		}

		private void RefreshItemList(bool resetScrollPos = true)
		{
			this._doc.ResetScrollView = false;
			for (int i = 0; i < AuctionHouseHandler.MAXSHOWITEM; i++)
			{
				this._leftTime[i] = -1;
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			this._timeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.RefreshLeftTime), null);
			this.m_NoneItem.SetActive(this._doc.ItemList.Count == 0);
			this.m_ItemListWrapContent.SetContentCount(this._doc.ItemList.Count, false);
			if (resetScrollPos)
			{
				this.m_ItemScrollView.SetPosition(0f);
			}
		}

		private void ItemWrapListInit(Transform t, int i)
		{
			this._timeLabel[i] = (t.Find("Time").GetComponent("XUILabel") as IXUILabel);
		}

		private void ItemWrapListUpdated(Transform t, int i)
		{
			bool flag = i < 0 || i >= this._doc.ItemList.Count;
			if (!flag)
			{
				GameObject gameObject = t.Find("ItemTpl").gameObject;
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.ItemList[i].itemid);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf, 0, false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject, (int)this._doc.ItemList[i].itemid);
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(itemConf.ItemName[0]);
				int num = this._doc.PublicityTime - this._doc.GuildSaleTime + (int)this._doc.ItemList[i].lefttime;
				bool flag2 = num > 0 && this._doc.LastReq < 100;
				bool flag3 = this._doc.ItemList[i].lefttime == 0U;
				if (flag3)
				{
					this._timeLabel[i % AuctionHouseHandler.MAXSHOWITEM].SetText(XStringDefineProxy.GetString("AuctionHouseTimeOut"));
					this._leftTime[i % AuctionHouseHandler.MAXSHOWITEM] = 0;
				}
				else
				{
					bool flag4 = flag2;
					if (flag4)
					{
						this._timeLabel[i % AuctionHouseHandler.MAXSHOWITEM].SetText(string.Format(this.WaitStartString, XSingleton<UiUtility>.singleton.TimeFormatString(num, 2, 3, 4, false, true)));
						this._leftTime[i % AuctionHouseHandler.MAXSHOWITEM] = num;
						this._gsq[i % AuctionHouseHandler.MAXSHOWITEM] = true;
					}
					else
					{
						int totalSecond = (int)(this._doc.ItemList[i].lefttime - (uint)((int)(this.GetNowTime() - this._signTime)));
						this._timeLabel[i % AuctionHouseHandler.MAXSHOWITEM].SetText(XSingleton<UiUtility>.singleton.TimeFormatString(totalSecond, 2, 3, 4, false, true));
						this._leftTime[i % AuctionHouseHandler.MAXSHOWITEM] = (int)this._doc.ItemList[i].lefttime;
						this._gsq[i % AuctionHouseHandler.MAXSHOWITEM] = false;
					}
				}
				IXUILabel ixuilabel2 = t.Find("AuctionPrice").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(this._doc.ItemList[i].curauctprice.ToString());
				IXUILabel ixuilabel3 = t.Find("BuyPrice").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText(this._doc.ItemList[i].maxprice.ToString());
				IXUIButton ixuibutton = t.Find("AuctionBtn").GetComponent("XUIButton") as IXUIButton;
				IXUILabel ixuilabel4 = ixuibutton.gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
				bool flag5 = this._doc.ItemList[i].auctroleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag5)
				{
					ixuibutton.SetEnable(false, false);
					ixuilabel4.SetText(XStringDefineProxy.GetString("AuctionHouseAucType1"));
				}
				else
				{
					ixuilabel4.SetText(XStringDefineProxy.GetString("AuctionHouseAucType3"));
					bool flag6 = flag2 || this._doc.ItemList[i].curauctprice * this.PERADDPRICE >= this._doc.ItemList[i].maxprice;
					if (flag6)
					{
						ixuibutton.SetEnable(false, false);
					}
					else
					{
						ixuibutton.SetEnable(true, false);
						ixuibutton.ID = (ulong)((long)i);
						ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAuctionBtnClick));
					}
				}
				IXUIButton ixuibutton2 = t.Find("BuyBtn").GetComponent("XUIButton") as IXUIButton;
				bool flag7 = flag2;
				if (flag7)
				{
					ixuibutton2.SetEnable(false, false);
				}
				else
				{
					ixuibutton2.SetEnable(true, false);
					ixuibutton2.ID = (ulong)((long)i);
					ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClick));
				}
			}
		}

		private bool OnAuctionBtnClick(IXUIButton btn)
		{
			int index = (int)btn.ID;
			this._signUid = this._doc.ItemList[index].uid;
			this._signPrice = this._doc.ItemList[index].curauctprice;
			this._signActType = this._doc.ItemList[index].acttype;
			string arg = string.Format("{0}{1}", (int)(this._doc.ItemList[index].curauctprice * this.PERADDPRICE + 0.001f), XLabelSymbolHelper.FormatSmallIcon(7));
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.ItemList[index].itemid);
			string label = XSingleton<UiUtility>.singleton.ReplaceReturn(string.Format(XStringDefineProxy.GetString("AuctionHouseTips1"), arg, itemConf.ItemName[0]));
			string @string = XStringDefineProxy.GetString("COMMON_OK");
			string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.OnAuctionSure));
			return true;
		}

		private bool OnBuyBtnClick(IXUIButton btn)
		{
			int index = (int)btn.ID;
			this._signUid = this._doc.ItemList[index].uid;
			this._signActType = this._doc.ItemList[index].acttype;
			this._signMaxPrice = this._doc.ItemList[index].maxprice;
			string arg = string.Format("{0}{1}", this._doc.ItemList[index].maxprice, XLabelSymbolHelper.FormatSmallIcon(7));
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.ItemList[index].itemid);
			string label = XSingleton<UiUtility>.singleton.ReplaceReturn(string.Format(XStringDefineProxy.GetString("AuctionHouseTips2"), arg, itemConf.ItemName[0]));
			string @string = XStringDefineProxy.GetString("COMMON_OK");
			string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.OnBuySure));
			return true;
		}

		private bool OnAuctionSure(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			ulong usr = (ulong)(this._signPrice * this.PERADDPRICE + 0.001f);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN));
			bool flag = specificDocument.TryDragonCoinFull(usr, itemCount);
			if (flag)
			{
				this._doc.QueryAuctionItem(this._signUid, this._signPrice, this._signActType);
			}
			return true;
		}

		private bool OnBuySure(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			ulong usr = (ulong)this._signMaxPrice;
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN));
			bool flag = specificDocument.TryDragonCoinFull(usr, itemCount);
			if (flag)
			{
				this._doc.QueryBuyItem(this._signUid, this._signActType);
			}
			return true;
		}

		private void RefreshHistoryList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = !this.m_ResultWindow.activeInHierarchy;
				if (!flag2)
				{
					this.m_ResultScrollView.SetPosition(0f);
					this.m_ResultWrapContent.SetContentCount(this._doc.HistoryList.Count, false);
				}
			}
		}

		private void ResultWrapListUpdated(Transform t, int i)
		{
			IXUILabel ixuilabel = t.Find("ActName").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString(string.Format("AuctionHouseAct{0}", this._doc.HistoryList[i].acttype)));
			IXUILabel ixuilabel2 = t.Find("Date").GetComponent("XUILabel") as IXUILabel;
			string text = XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._doc.HistoryList[i].saletime, XStringDefineProxy.GetString("AuctionHouseHistoryTime"), true);
			ixuilabel2.SetText(text);
			IXUILabel ixuilabel3 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.HistoryList[i].itemid);
			ixuilabel3.SetText(itemConf.ItemName[0]);
			IXUILabelSymbol ixuilabelSymbol = t.Find("Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			bool flag = this._doc.HistoryList[i].auctresult == GuildAuctResultType.GA_RESULT_TO_WORLD;
			if (flag)
			{
				ixuilabelSymbol.InputText = XStringDefineProxy.GetString("AuctionHouseAucType4");
			}
			else
			{
				string @string = XStringDefineProxy.GetString(string.Format("AuctionHouseAucType{0}", XFastEnumIntEqualityComparer<GuildAuctResultType>.ToInt(this._doc.HistoryList[i].auctresult) + 1));
				ixuilabelSymbol.InputText = string.Format("{0}{1} {2}", this._doc.HistoryList[i].saleprice, XLabelSymbolHelper.FormatSmallIcon(7), @string);
			}
			GameObject gameObject = t.Find("Bg").gameObject;
			gameObject.SetActive(i % 2 == 0);
		}

		private void ForceQueryLastClick(object o = null)
		{
			this._doc.QueryRefreshUI();
		}

		private void RefreshLeftTime(object o = null)
		{
			for (int i = 0; i < AuctionHouseHandler.MAXSHOWITEM; i++)
			{
				bool flag = this._leftTime[i] >= 0;
				if (flag)
				{
					int num = this._leftTime[i] - (int)(this.GetNowTime() - this._signTime);
					bool flag2 = num < 0;
					if (flag2)
					{
						this._leftTime[i] = -1;
						num = 0;
					}
					bool flag3 = num == 0;
					if (flag3)
					{
						bool flag4 = this._gsq[i];
						if (flag4)
						{
							this._timeLabel[i].SetText(XStringDefineProxy.GetString("AuctionHouseWaitTimeOut"));
						}
						else
						{
							this._timeLabel[i].SetText(XStringDefineProxy.GetString("AuctionHouseTimeOut"));
						}
					}
					else
					{
						bool flag5 = this._gsq[i];
						if (flag5)
						{
							this._timeLabel[i].SetText(string.Format(this.WaitStartString, XSingleton<UiUtility>.singleton.TimeFormatString(num, 2, 3, 4, false, true)));
						}
						else
						{
							this._timeLabel[i].SetText(XSingleton<UiUtility>.singleton.TimeFormatString(num, 2, 3, 4, false, true));
						}
					}
				}
			}
			this._timeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.RefreshLeftTime), null);
		}

		private double GetNowTime()
		{
			return (double)(DateTime.Now.Ticks / 10000000L);
		}

		private AuctionHouseDocument _doc;

		private GameObject m_ResultWindow;

		private IXUILabel m_ResultTitle;

		private IXUIButton m_ResultCloseBtn;

		private IXUIScrollView m_ResultScrollView;

		private IXUIWrapContent m_ResultWrapContent;

		private XUIPool m_ResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton m_ResultBtn;

		private IXUILabel m_ResultLabel;

		private XUIPool m_LevelOnePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_LevelTwoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIScrollView m_ItemScrollView;

		private IXUIWrapContent m_ItemListWrapContent;

		private GameObject m_NoneItem;

		private IXUITable m_Table;

		private IXUILabel m_MySpoil;

		private IXUILabel m_NoSpoil;

		private List<Transform> m_parentTypeTs = new List<Transform>();

		private uint _timeToken;

		private uint _reqToken;

		private IXUILabel[] _timeLabel = new IXUILabel[8];

		private int[] _leftTime = new int[8];

		private bool[] _gsq = new bool[8];

		private IXUISprite _lastClickTabSprite;

		private double _signTime;

		private ulong _signUid;

		private uint _signPrice;

		private uint _signMaxPrice;

		private int _signActType;

		private static readonly int MAXSHOWITEM = 8;

		private int TYPEMAX;

		private float PERADDPRICE;

		private bool RefreshGuildTabs = false;

		private IXUISprite m_GeneraliSp;

		private IXUITweenTool m_SwitchTween;

		private bool m_TweenToggle = false;

		private string WaitStartString;
	}
}
