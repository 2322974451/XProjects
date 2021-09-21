using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018EB RID: 6379
	public class XWelfareYyMallHandler : DlgHandlerBase
	{
		// Token: 0x17003A82 RID: 14978
		// (get) Token: 0x060109DB RID: 68059 RVA: 0x0041ABA4 File Offset: 0x00418DA4
		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/YyMallHandler";
			}
		}

		// Token: 0x060109DC RID: 68060 RVA: 0x0041ABBB File Offset: 0x00418DBB
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x060109DD RID: 68061 RVA: 0x0041ABCC File Offset: 0x00418DCC
		protected override void OnShow()
		{
			base.OnShow();
			XWelfareDocument.Doc.RefreshYYMallRedPoint();
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.ReqGoodsList(XSysDefine.XSys_Welfare_YyMall);
			bool flag = this._refreshTaskEffect != null;
			if (flag)
			{
				this._refreshTaskEffect.SetActive(false);
			}
		}

		// Token: 0x060109DE RID: 68062 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x060109DF RID: 68063 RVA: 0x0041AC1D File Offset: 0x00418E1D
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshScorllViewContent();
			this.RefreshBtnState();
			this.RefreshPrivilegeCount();
		}

		// Token: 0x060109E0 RID: 68064 RVA: 0x0041AC3C File Offset: 0x00418E3C
		public override void OnUnload()
		{
			bool flag = this._refreshTaskEffect != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._refreshTaskEffect, true);
			}
			DlgHandlerBase.EnsureUnload<XYYMallCategoryHandler>(ref this._XYYMallCategoryHandler);
			base.OnUnload();
		}

		// Token: 0x060109E1 RID: 68065 RVA: 0x0041AC7C File Offset: 0x00418E7C
		public void PlayRefreshEffect()
		{
			bool flag = this._refreshTaskEffect != null;
			if (flag)
			{
				this._refreshTaskEffect.SetActive(true);
				this._refreshTaskEffect.Play(this._effectPanel, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		// Token: 0x060109E2 RID: 68066 RVA: 0x0041ACCC File Offset: 0x00418ECC
		private void RefreshPrivilegeCount()
		{
			int privilegeFreeRefreshCount = XWelfareDocument.Doc.GetPrivilegeFreeRefreshCount(MemberPrivilege.KingdomPrivilege_Adventurer);
			int num = XWelfareDocument.Doc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer) ? Math.Max(0, privilegeFreeRefreshCount - XWelfareDocument.Doc.PayMemberPrivilege.usedRefreshShopCount) : privilegeFreeRefreshCount;
			this._privilegeFreeLabel.SetText(num + "/" + privilegeFreeRefreshCount);
			this._courtPrivilege.SetGrey(XWelfareDocument.Doc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court));
			this._extraRefresh.SetGrey(XWelfareDocument.Doc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer));
		}

		// Token: 0x060109E3 RID: 68067 RVA: 0x0041AD60 File Offset: 0x00418F60
		private void RefreshBtnState()
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			ShopTypeTable.RowData shopTypeData = specificDocument.GetShopTypeData(XSysDefine.XSys_Welfare_YyMall);
			uint rereshCount = specificDocument.RereshCount;
			this._refreshBtn.SetEnable(true, false);
			bool flag = shopTypeData != null;
			if (flag)
			{
				SeqRef<uint> refreshCount = shopTypeData.RefreshCount;
				SeqListRef<uint> refreshCost = shopTypeData.RefreshCost;
				bool flag2 = rereshCount >= refreshCount[0] + refreshCount[1];
				if (flag2)
				{
					this._freeNumLabel.gameObject.SetActive(false);
					this._dragonCoinLabel.gameObject.SetActive(false);
					this._noneTimesTrans.gameObject.SetActive(true);
					this._refreshBtn.SetEnable(false, false);
				}
				else
				{
					bool flag3 = rereshCount >= refreshCount[0];
					if (flag3)
					{
						this._freeNumLabel.gameObject.SetActive(false);
						this._dragonCoinLabel.gameObject.SetActive(true);
						this._noneTimesTrans.gameObject.SetActive(false);
						int index = (int)Mathf.Min(new float[]
						{
							rereshCount - refreshCount[0],
							refreshCount[1] - 1U,
							(float)(refreshCost.Count - 1)
						});
						int itemID = (int)refreshCost[index, 0];
						ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
						bool flag4 = itemConf != null;
						if (flag4)
						{
							this._itemSprite.SetSprite(itemConf.ItemIcon1[0]);
						}
						this._dragonCoinLabel.SetText(refreshCost[index, 1].ToString());
					}
					else
					{
						this._freeNumLabel.gameObject.SetActive(true);
						this._dragonCoinLabel.gameObject.SetActive(false);
						this._noneTimesTrans.gameObject.SetActive(false);
						this._freeNumLabel.SetText(refreshCount[0] - rereshCount + "/" + refreshCount[0]);
					}
				}
			}
		}

		// Token: 0x060109E4 RID: 68068 RVA: 0x0041AF68 File Offset: 0x00419168
		private void RefreshScorllViewContent()
		{
			this._shopItemPool.ReturnAll(false);
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			List<XNormalShopGoods> goodsList = specificDocument.GoodsList;
			for (int i = 0; i < goodsList.Count; i++)
			{
				XNormalShopGoods xnormalShopGoods = goodsList[i];
				ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)xnormalShopGoods.item.uid);
				bool flag = dataById != null;
				if (flag)
				{
					float num = 0f;
					GameObject gameObject = this._shopItemPool.FetchGameObject(false);
					IXUISprite ixuisprite = gameObject.transform.Find("UnCompleted").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.gameObject.SetActive(false);
					bool flag2 = i == 4 || i == 9;
					if (flag2)
					{
						num = 15f;
						bool flag3 = !XWelfareDocument.Doc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
						if (flag3)
						{
							ixuisprite.gameObject.SetActive(true);
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenCourtPriviege));
						}
					}
					gameObject.transform.localPosition = this._shopItemPool.TplPos + new Vector3((float)(i % 5 * this._shopItemPool.TplWidth) + num, (float)(-(float)i / 5 * this._shopItemPool.TplHeight), 0f);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject.transform.Find("Item").gameObject, xnormalShopGoods.item.itemID, (int)dataById.ItemOverlap, false);
					IXUISprite ixuisprite2 = gameObject.transform.Find("Item/Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)((long)xnormalShopGoods.item.itemID);
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
					IXUIButton ixuibutton = gameObject.transform.Find("BtnBuy").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)((long)i);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyShopItem));
					IXUISprite ixuisprite3 = gameObject.transform.FindChild("BtnBuy/MoneyCost/Icon").GetComponent("XUISprite") as IXUISprite;
					string itemSmallIcon = XBagDocument.GetItemSmallIcon(xnormalShopGoods.priceType, 0U);
					ixuisprite3.SetSprite(itemSmallIcon);
					Transform transform = gameObject.transform.Find("buyed2");
					transform.gameObject.SetActive(dataById.IsPrecious);
					GameObject gameObject2 = gameObject.transform.Find("discount").gameObject;
					gameObject2.SetActive(dataById.Benefit[1] > 0U && dataById.Benefit[1] != 100U);
					IXUILabel ixuilabel = gameObject.transform.Find("discount/t").GetComponent("XUILabel") as IXUILabel;
					float num2 = dataById.Benefit[1] / 10f;
					ixuilabel.SetText(num2.ToString());
					IXUILabel ixuilabel2 = gameObject.transform.FindChild("BtnBuy/MoneyCost").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(Mathf.FloorToInt((float)xnormalShopGoods.priceValue * num2 / 10f).ToString());
					GameObject gameObject3 = gameObject.transform.FindChild("buyed").gameObject;
					uint dailyCountCondition = (uint)dataById.DailyCountCondition;
					int weekCountCondition = (int)dataById.WeekCountCondition;
					int num3 = 0;
					bool flag4 = dataById.CountCondition > 0U;
					if (flag4)
					{
						num3 = xnormalShopGoods.totalSoldNum;
					}
					else
					{
						bool flag5 = dailyCountCondition > 0U;
						if (flag5)
						{
							num3 = xnormalShopGoods.soldNum;
						}
						else
						{
							bool flag6 = weekCountCondition != 0;
							if (flag6)
							{
								num3 = (int)xnormalShopGoods.weeklyBuyCount;
							}
						}
					}
					int countCondition = (int)dataById.CountCondition;
					bool flag7 = dailyCountCondition == 0U && countCondition == 0 && weekCountCondition == 0;
					if (flag7)
					{
						ixuibutton.SetEnable(true, false);
					}
					else
					{
						bool flag8 = countCondition != 0;
						if (flag8)
						{
							bool flag9 = num3 >= countCondition;
							if (flag9)
							{
								ixuibutton.SetEnable(false, false);
								gameObject3.SetActive(true);
							}
							else
							{
								ixuibutton.SetEnable(true, false);
								gameObject3.SetActive(false);
							}
						}
						else
						{
							bool flag10 = dailyCountCondition != 0U && (long)num3 >= (long)((ulong)dailyCountCondition);
							if (flag10)
							{
								ixuibutton.SetEnable(false, false);
								gameObject3.SetActive(true);
							}
							else
							{
								bool flag11 = weekCountCondition != 0 && num3 >= weekCountCondition;
								if (flag11)
								{
									ixuibutton.SetEnable(false, false);
									gameObject3.SetActive(false);
								}
								else
								{
									ixuibutton.SetEnable(true, false);
									gameObject3.SetActive(false);
								}
							}
						}
					}
				}
			}
			this._scrollView.ResetPosition();
		}

		// Token: 0x060109E5 RID: 68069 RVA: 0x0041B428 File Offset: 0x00419628
		private void OnOpenAdventurerPriviege(IXUISprite uiSprite)
		{
			bool flag = !XWelfareDocument.Doc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Adventurer);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("KingdomPrivilege_Adventurer2Unlock"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OpenAdventurePriviege));
			}
		}

		// Token: 0x060109E6 RID: 68070 RVA: 0x0041B480 File Offset: 0x00419680
		private bool OpenAdventurePriviege(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer, 0UL);
			return true;
		}

		// Token: 0x060109E7 RID: 68071 RVA: 0x0041B4B0 File Offset: 0x004196B0
		private void OnOpenCourtPriviege(IXUISprite uiSprite)
		{
			bool flag = !XWelfareDocument.Doc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("KingdomPrivilege_Court2Unlock"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OpenCourtPriviege));
			}
		}

		// Token: 0x060109E8 RID: 68072 RVA: 0x0041B508 File Offset: 0x00419708
		private bool OpenCourtPriviege(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Welfare_KingdomPrivilege_Court, 0UL);
			return true;
		}

		// Token: 0x060109E9 RID: 68073 RVA: 0x0041B538 File Offset: 0x00419738
		private void OnClickItemIcon(IXUISprite spr)
		{
			bool flag = spr.ID > 0UL;
			if (flag)
			{
				XItem mainItem = XBagDocument.MakeXItem((int)spr.ID, false);
				XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, false, 0U);
			}
		}

		// Token: 0x060109EA RID: 68074 RVA: 0x0041B574 File Offset: 0x00419774
		private bool OnBuyShopItem(IXUIButton button)
		{
			int index = (int)button.ID;
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.ReqBuy(index);
			return true;
		}

		// Token: 0x060109EB RID: 68075 RVA: 0x0041B5A4 File Offset: 0x004197A4
		private void InitProperties()
		{
			Transform transform = base.transform.Find("ShopItemList");
			GameObject gameObject = transform.Find("ShopItemTpl").gameObject;
			this._shopItemPool.SetupPool(transform.gameObject, gameObject, 8U, false);
			this._scrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			this._refreshBtn = (base.transform.Find("BtnRefresh").GetComponent("XUIButton") as IXUIButton);
			this._refreshBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshShopList));
			this._detailBtn = (base.transform.Find("Detail").GetComponent("XUIButton") as IXUIButton);
			this._detailBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickOnDetail));
			this._freeNumLabel = (base.transform.Find("BtnRefresh/FreeNum").GetComponent("XUILabel") as IXUILabel);
			this._privilegeFreeLabel = (base.transform.Find("ExtraRefresh/Count").GetComponent("XUILabel") as IXUILabel);
			this._dragonCoinLabel = (base.transform.Find("BtnRefresh/DragonCoinNum").GetComponent("XUILabel") as IXUILabel);
			this._noneTimesTrans = base.transform.Find("BtnRefresh/NoneTimes");
			this._itemSprite = (base.transform.Find("BtnRefresh/DragonCoinNum/p").GetComponent("XUISprite") as IXUISprite);
			this._effectPanel = base.transform.Find("Effect");
			this._refreshTaskEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_YyMallHandler_Clip01", null, true);
			this._refreshTaskEffect.SetActive(false);
			this._courtPrivilege = (base.transform.Find("Privilege").GetComponent("XUISprite") as IXUISprite);
			this._courtPrivilege.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenCourtPriviege));
			this._extraRefresh = (base.transform.Find("ExtraRefresh").GetComponent("XUISprite") as IXUISprite);
			this._extraRefresh.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenAdventurerPriviege));
			DlgHandlerBase.EnsureCreate<XYYMallCategoryHandler>(ref this._XYYMallCategoryHandler, base.transform, false, this);
		}

		// Token: 0x060109EC RID: 68076 RVA: 0x0041B7EC File Offset: 0x004199EC
		private bool OnClickOnDetail(IXUIButton button)
		{
			bool flag = this._XYYMallCategoryHandler != null;
			if (flag)
			{
				this._XYYMallCategoryHandler.SetVisible(true);
			}
			return true;
		}

		// Token: 0x060109ED RID: 68077 RVA: 0x0041B81C File Offset: 0x00419A1C
		private bool OnRefreshShopList(IXUIButton button)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			bool flag = specificDocument.CanBuyPreciousShopItem();
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("YYMallPreciousTip"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.DoRefreshShop));
			}
			else
			{
				this.DoRefreshShop(null);
			}
			return true;
		}

		// Token: 0x060109EE RID: 68078 RVA: 0x0041B888 File Offset: 0x00419A88
		private bool DoRefreshShop(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			bool flag = !specificDocument.IsMoneyOrItemEnough((int)this.GetMoneyId(), (int)this.GetRefreshCost());
			bool result;
			if (flag)
			{
				specificDocument.ProcessItemOrMoneyNotEnough((int)this.GetMoneyId());
				result = false;
			}
			else
			{
				RpcC2G_QueryShopItem rpcC2G_QueryShopItem = new RpcC2G_QueryShopItem();
				rpcC2G_QueryShopItem.oArg.isrefresh = true;
				rpcC2G_QueryShopItem.oArg.type = specificDocument.GetShopId(XSysDefine.XSys_Welfare_YyMall);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QueryShopItem);
				this.PlayRefreshEffect();
				result = true;
			}
			return result;
		}

		// Token: 0x060109EF RID: 68079 RVA: 0x0041B91C File Offset: 0x00419B1C
		private uint GetRefreshCost()
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			ShopTypeTable.RowData shopTypeData = specificDocument.GetShopTypeData(XSysDefine.XSys_Welfare_YyMall);
			bool flag = shopTypeData == null;
			uint result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("ShopTypeTable not find this systenId = {0}", XSysDefine.XSys_Welfare_YyMall), null, null, null, null, null);
				result = 0U;
			}
			else
			{
				uint num = 0U;
				uint rereshCount = specificDocument.RereshCount;
				SeqRef<uint> refreshCount = shopTypeData.RefreshCount;
				SeqListRef<uint> refreshCost = shopTypeData.RefreshCost;
				bool flag2 = rereshCount >= refreshCount[0];
				if (flag2)
				{
					int index = (int)Mathf.Min(rereshCount - refreshCount[0], (float)(refreshCost.count - 1));
					num = refreshCost[index, 1];
				}
				result = num;
			}
			return result;
		}

		// Token: 0x060109F0 RID: 68080 RVA: 0x0041B9D4 File Offset: 0x00419BD4
		private uint GetMoneyId()
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			ShopTypeTable.RowData shopTypeData = specificDocument.GetShopTypeData(XSysDefine.XSys_Welfare_YyMall);
			bool flag = shopTypeData == null;
			uint result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("ShopTypeTable not find this systenId = {0}", XSysDefine.XSys_Welfare_YyMall), null, null, null, null, null);
				result = 0U;
			}
			else
			{
				uint rereshCount = specificDocument.RereshCount;
				uint num = 0U;
				SeqRef<uint> refreshCount = shopTypeData.RefreshCount;
				SeqListRef<uint> refreshCost = shopTypeData.RefreshCost;
				bool flag2 = rereshCount >= refreshCount[0];
				if (flag2)
				{
					int num2 = (int)Mathf.Min(rereshCount - refreshCount[0], refreshCount[1] - 1U);
					bool flag3 = num2 >= refreshCost.Count;
					if (flag3)
					{
						num2 = refreshCost.Count - 1;
					}
					num = refreshCost[num2, 0];
				}
				result = num;
			}
			return result;
		}

		// Token: 0x040078D8 RID: 30936
		private const int colNum = 5;

		// Token: 0x040078D9 RID: 30937
		private IXUIButton _refreshBtn;

		// Token: 0x040078DA RID: 30938
		private IXUIButton _detailBtn;

		// Token: 0x040078DB RID: 30939
		private IXUIScrollView _scrollView;

		// Token: 0x040078DC RID: 30940
		private IXUILabel _freeNumLabel;

		// Token: 0x040078DD RID: 30941
		private IXUILabel _privilegeFreeLabel;

		// Token: 0x040078DE RID: 30942
		private IXUILabel _dragonCoinLabel;

		// Token: 0x040078DF RID: 30943
		private IXUISprite _itemSprite;

		// Token: 0x040078E0 RID: 30944
		private Transform _noneTimesTrans;

		// Token: 0x040078E1 RID: 30945
		protected XUIPool _shopItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040078E2 RID: 30946
		private XFx _refreshTaskEffect;

		// Token: 0x040078E3 RID: 30947
		private Transform _effectPanel;

		// Token: 0x040078E4 RID: 30948
		private IXUISprite _extraRefresh;

		// Token: 0x040078E5 RID: 30949
		private IXUISprite _courtPrivilege;

		// Token: 0x040078E6 RID: 30950
		private XYYMallCategoryHandler _XYYMallCategoryHandler;
	}
}
