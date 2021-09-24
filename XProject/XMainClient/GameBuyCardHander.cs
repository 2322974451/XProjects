using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GameBuyCardHander : DlgHandlerBase
	{

		private int canBuyMaxCnt
		{
			get
			{
				bool flag = this.doc == null;
				if (flag)
				{
					this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				}
				ulong itemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(9);
				ulong itemCount2 = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(7);
				ulong num = (DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.currSys == XSysDefine.XSys_GameMall_Diamond) ? itemCount : itemCount2;
				float num2 = (this.doc.currCIBShop == null) ? 3f : (this.doc.currCIBShop.row.currencycount * this.doc.currCIBShop.row.discount / 100f);
				return Mathf.Max(1, Mathf.FloorToInt(num / num2));
			}
		}

		private int rstCnt
		{
			get
			{
				bool flag = this.doc == null;
				if (flag)
				{
					this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				}
				CIBShop currCIBShop = this.doc.currCIBShop;
				bool flag2 = currCIBShop != null;
				int result;
				if (flag2)
				{
					XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
					float num = 0f;
					bool flag3 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.privilegeID == currCIBShop.sinfo.itemid && specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
					if (flag3)
					{
						num = (float)specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Commerce).BuyGreenAgateLimit / 100f;
					}
					int num2 = 0;
					PayMemberPrivilege payMemberPrivilege = specificDocument.PayMemberPrivilege;
					bool flag4 = payMemberPrivilege != null;
					if (flag4)
					{
						for (int i = 0; i < payMemberPrivilege.usedPrivilegeShop.Count; i++)
						{
							bool flag5 = (long)payMemberPrivilege.usedPrivilegeShop[i].goodsID == (long)((ulong)currCIBShop.sinfo.goodsid);
							if (flag5)
							{
								num2 = payMemberPrivilege.usedPrivilegeShop[i].usedCount;
								break;
							}
						}
					}
					uint num3 = (uint)((this.canBuyMaxCnt > 999) ? 999 : this.canBuyMaxCnt);
					bool flag6 = currCIBShop.sinfo.nlimitcount > 0U;
					if (flag6)
					{
						uint num4 = (uint)(currCIBShop.sinfo.nlimitcount + currCIBShop.row.buycount * num) - currCIBShop.sinfo.nbuycount - (uint)num2;
						num3 = ((num3 > num4) ? num4 : num3);
					}
					result = (currCIBShop.finish ? 0 : Mathf.Clamp(this.mCurrCnt, 1, (int)num3));
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			this.m_lblBuyCnt = (base.PanelObject.transform.Find("Count/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_sprBuyAdd = (base.PanelObject.transform.Find("Count/Add").GetComponent("XUISprite") as IXUISprite);
			this.m_sprBuyReduce = (base.PanelObject.transform.Find("Count/Sub").GetComponent("XUISprite") as IXUISprite);
			this.m_lblPrice = (base.PanelObject.transform.Find("price/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_btnBuy = (base.PanelObject.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this.m_btnSmallBuy = (base.PanelObject.transform.Find("OK1").GetComponent("XUIButton") as IXUIButton);
			this.m_btnPresent = (base.PanelObject.transform.Find("present").GetComponent("XUIButton") as IXUIButton);
			this.m_uiIcon = (base.PanelObject.transform.Find("price/p").GetComponent("XUISprite") as IXUISprite);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnBuy.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyClick));
			this.m_btnSmallBuy.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyClick));
			this.m_btnPresent.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPresentClick));
			this.m_sprBuyAdd.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBuyAddClick));
			this.m_sprBuyReduce.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnBuyReduceClick));
			this.m_lblBuyCnt.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnCntClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			bool flag = this.doc.currItemID != 0;
			if (flag)
			{
				this.Refresh();
			}
			bool flag2 = this.doc.currCIBShop != null && this.doc.currCIBShop.finish;
			if (flag2)
			{
				this.mCurrCnt = 0;
			}
		}

		protected override void OnHide()
		{
			this.mCurrCnt = 1;
			this.ResetInput();
			base.OnHide();
		}

		public void Refresh()
		{
			bool flag = this.doc == null;
			if (flag)
			{
				this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
			CIBShop currCIBShop = this.doc.currCIBShop;
			this.m_btnBuy.SetEnable(currCIBShop != null, false);
			bool flag2 = currCIBShop != null;
			if (flag2)
			{
				float num = (currCIBShop.row.discount == 0U) ? 1f : (currCIBShop.row.discount / 100f);
				bool flag3 = this.rstCnt > 1;
				if (flag3)
				{
					this.SaveCurrInput(this.rstCnt);
				}
				this.m_lblBuyCnt.SetText(this.rstCnt.ToString());
				float num2 = (float)((long)this.rstCnt * (long)((ulong)currCIBShop.row.currencycount)) * num;
				this.m_lblPrice.SetText(num2.ToString("0"));
				XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				uint num3 = 0U;
				bool flag4 = xplayerData != null;
				if (flag4)
				{
					num3 = xplayerData.Level;
				}
				bool flag5 = this.doc.currCIBShop.row.rmb > 0U && (long)XSingleton<XGlobalConfig>.singleton.GetInt("IBShopLevel") <= (long)((ulong)num3) && this.doc.currCIBShop.sinfo.gift && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.SYS_IBSHOP_GIFT);
				this.m_btnSmallBuy.SetVisible(flag5);
				this.m_btnPresent.SetVisible(flag5);
				this.m_btnBuy.SetVisible(!flag5);
			}
			else
			{
				bool flag6 = false;
				this.m_btnSmallBuy.SetVisible(flag6);
				this.m_btnPresent.SetVisible(flag6);
				this.m_btnBuy.SetVisible(!flag6);
				this.m_lblBuyCnt.SetText("0");
				this.m_lblPrice.SetText("0");
			}
			string strSprite;
			string strAtlas;
			XBagDocument.GetItemSmallIconAndAtlas((int)DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.item, out strSprite, out strAtlas, 0U);
			this.m_uiIcon.SetSprite(strSprite, strAtlas, false);
		}

		private bool IsEqual(float v1, float v2)
		{
			return (double)Mathf.Abs(v1 - v2) < 0.0001;
		}

		private bool OnBuyClick(IXUIButton btn)
		{
			CIBShop currCIBShop = this.doc.currCIBShop;
			bool flag = currCIBShop != null;
			if (flag)
			{
				int rstCnt = this.rstCnt;
				bool finish = currCIBShop.finish;
				if (finish)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MALL_FINISH"), "fece00");
				}
				else
				{
					bool flag2 = rstCnt > 0;
					if (flag2)
					{
						ulong itemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(9);
						ulong itemCount2 = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(7);
						float num = (currCIBShop.row.discount == 0U) ? 1f : (currCIBShop.row.discount / 100f);
						float num2 = (float)((long)this.rstCnt * (long)((ulong)currCIBShop.row.currencycount)) * num;
						bool flag3 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.currSys == XSysDefine.XSys_GameMall_Dragon;
						if (flag3)
						{
							bool flag4 = num2 <= itemCount2 || this.IsEqual(num2, itemCount2);
							if (flag4)
							{
								this.GotoBuy(currCIBShop.sinfo.goodsid, rstCnt);
							}
							else
							{
								bool flag5 = num2 <= itemCount2 + itemCount || this.IsEqual(num2, itemCount2 + itemCount);
								if (!flag5)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MALL_DRAG_LESS"), "fece00");
									return true;
								}
								DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
								DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
								int cost = (int)(num2 - itemCount2);
								string @string = XStringDefineProxy.GetString("AUCTION_DRAGON_COIN_UNFULL", new object[]
								{
									XLabelSymbolHelper.FormatCostWithIcon((int)num2, ItemEnum.DRAGON_COIN),
									XLabelSymbolHelper.FormatCostWithIcon(cost, ItemEnum.DIAMOND),
									XLabelSymbolHelper.FormatCostWithIcon(cost, ItemEnum.DRAGON_COIN)
								});
								string string2 = XStringDefineProxy.GetString(XStringDefine.COMMON_OK);
								string string3 = XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL);
								DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string2, string3);
								DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnOverOKClick), null);
							}
						}
						else
						{
							bool flag6 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.currSys == XSysDefine.XSys_GameMall_Diamond;
							if (flag6)
							{
								bool flag7 = num2 <= itemCount;
								if (!flag7)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MALL_DIA_LESS"), "fece00");
									return true;
								}
								bool flag8 = this.CheckVIP();
								if (flag8)
								{
									this.GotoBuy(currCIBShop.sinfo.goodsid, rstCnt);
								}
							}
						}
					}
				}
			}
			return true;
		}

		private bool OnPresentClick(IXUIButton btn)
		{
			XActivityInviteDocument specificDocument = XDocuments.GetSpecificDocument<XActivityInviteDocument>(XActivityInviteDocument.uuID);
			specificDocument.ShowActivityInviteView(2, XActivityInviteDocument.OpType.Send);
			return true;
		}

		private bool OnOverOKClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			CIBShop currCIBShop = this.doc.currCIBShop;
			bool flag = currCIBShop != null;
			if (flag)
			{
				ulong itemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(7);
				float num = (currCIBShop.row.discount == 0U) ? 1f : (currCIBShop.row.discount / 100f);
				float num2 = (float)((long)this.rstCnt * (long)((ulong)currCIBShop.row.currencycount)) * num;
				XPurchaseDocument specificDocument = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
				specificDocument.CommonQuickBuyRandom(ItemEnum.DRAGON_COIN, ItemEnum.DIAMOND, (uint)(num2 - itemCount));
			}
			return true;
		}

		private void GotoBuy(uint goodid, int cnt)
		{
			this.doc.SendBuyItem(goodid, (uint)cnt);
			this.mCurrCnt = 0;
			this.Refresh();
		}

		private void OnCntClick(IXUILabel lbl)
		{
			this.ResetInput();
			DlgBase<CalculatorDlg, CalculatorBehaviour>.singleton.Show(new CalculatorKeyBack(this.RefreshByCalculator), new Vector3(84f, -90f, 0f));
		}

		private void OnBuyAddClick(IXUISprite spr)
		{
			bool flag = this.doc.currCIBShop == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddWarningLog("mall item is nil", null, null, null, null, null);
			}
			else
			{
				IBShop.RowData row = this.doc.currCIBShop.row;
				int num = (int)(row.currencycount * row.discount / 100f);
				int num2 = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(9);
				int num3 = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(7);
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				float num4 = 0f;
				bool flag2 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.privilegeID == this.doc.currCIBShop.sinfo.itemid && specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
				if (flag2)
				{
					num4 = (float)specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Commerce).BuyGreenAgateLimit / 100f;
				}
				int num5 = 0;
				PayMemberPrivilege payMemberPrivilege = specificDocument.PayMemberPrivilege;
				bool flag3 = payMemberPrivilege != null;
				if (flag3)
				{
					for (int i = 0; i < payMemberPrivilege.usedPrivilegeShop.Count; i++)
					{
						bool flag4 = (long)payMemberPrivilege.usedPrivilegeShop[i].goodsID == (long)((ulong)this.doc.currCIBShop.sinfo.goodsid);
						if (flag4)
						{
							num5 = payMemberPrivilege.usedPrivilegeShop[i].usedCount;
							break;
						}
					}
				}
				bool flag5 = this.doc.currCIBShop.sinfo.nlimitcount != 0U && (float)this.rstCnt >= this.doc.currCIBShop.sinfo.nlimitcount + this.doc.currCIBShop.row.buycount * num4 - this.doc.currCIBShop.sinfo.nbuycount - (float)num5;
				if (flag5)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MALL_MAX"), "fece00");
				}
				else
				{
					bool flag6 = !this.doc.currCIBShop.finish;
					if (flag6)
					{
						bool flag7 = this.mCurrCnt < this.canBuyMaxCnt;
						if (flag7)
						{
							this.mCurrCnt++;
							this.Refresh();
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_SHOP_LACKMONEY"), "fece00");
						}
					}
				}
			}
		}

		private void OnBuyReduceClick(IXUISprite spr)
		{
			bool flag = this.mCurrCnt > 1;
			if (flag)
			{
				this.mCurrCnt--;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MALL_LESSTHAN"), "fece00");
			}
			this.Refresh();
		}

		private void RefreshByCalculator(CalculatorKey key)
		{
			bool flag = key == CalculatorKey.MAX;
			if (flag)
			{
				bool flag2 = this.doc == null;
				if (flag2)
				{
					this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				}
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				CIBShop currCIBShop = this.doc.currCIBShop;
				bool flag3 = currCIBShop == null;
				if (flag3)
				{
					return;
				}
				float num = 0f;
				bool flag4 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.privilegeID == currCIBShop.sinfo.itemid && specificDocument.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce);
				if (flag4)
				{
					num = (float)specificDocument.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Commerce).BuyGreenAgateLimit / 100f;
				}
				int num2 = 0;
				PayMemberPrivilege payMemberPrivilege = specificDocument.PayMemberPrivilege;
				bool flag5 = payMemberPrivilege != null;
				if (flag5)
				{
					for (int i = 0; i < payMemberPrivilege.usedPrivilegeShop.Count; i++)
					{
						bool flag6 = (long)payMemberPrivilege.usedPrivilegeShop[i].goodsID == (long)((ulong)currCIBShop.sinfo.goodsid);
						if (flag6)
						{
							num2 = payMemberPrivilege.usedPrivilegeShop[i].usedCount;
							break;
						}
					}
				}
				this.mCurrCnt = ((currCIBShop.sinfo.nlimitcount != 0U) ? ((int)(currCIBShop.sinfo.nlimitcount + currCIBShop.row.buycount * num - currCIBShop.sinfo.nbuycount - (float)num2)) : this.canBuyMaxCnt);
			}
			else
			{
				bool flag7 = key == CalculatorKey.DEL;
				if (flag7)
				{
					bool flag8 = this.mCurrCnt > 1;
					if (flag8)
					{
						this.mCurrCnt = this.rstCnt;
					}
					this.DelInput(this.mCurrCnt);
					this.mCurrCnt = this.GetInput();
				}
				else
				{
					bool flag9 = key == CalculatorKey.OK;
					if (flag9)
					{
						this.mCurrCnt = this.GetInput();
					}
					else
					{
						int input = XFastEnumIntEqualityComparer<CalculatorKey>.ToInt(key);
						this.SetInput(input);
						this.mCurrCnt = this.GetInput();
					}
				}
			}
			this.Refresh();
		}

		public void ResetCurrCnt()
		{
			this.mCurrCnt = 1;
		}

		private bool CheckVIP()
		{
			bool flag = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType == MallType.VIP;
			bool result;
			if (flag)
			{
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				uint vipLevel = specificDocument.VipLevel;
				XGameMallDocument specificDocument2 = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				uint viplevel = specificDocument2.currCIBShop.row.viplevel;
				bool flag2 = vipLevel >= viplevel;
				bool flag3 = !flag2;
				if (flag3)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MALL_VIP", new object[]
					{
						viplevel
					}), "fece00");
				}
				result = flag2;
			}
			else
			{
				result = true;
			}
			return result;
		}

		private void ResetInput()
		{
			for (int i = 0; i < this.inputs.Length; i++)
			{
				this.inputs[i] = -1;
			}
		}

		private int GetInput()
		{
			int num = 3;
			for (int i = 0; i < 3; i++)
			{
				bool flag = this.inputs[i] == -1;
				if (flag)
				{
					num = i;
					break;
				}
			}
			int num2 = 0;
			for (int j = 0; j < num; j++)
			{
				num2 += (int)((float)this.inputs[j] * Mathf.Pow(10f, (float)(num - j - 1)));
			}
			int num3 = Mathf.Clamp(num2, 0, 999);
			this.SaveCurrInput(num3);
			return num3;
		}

		private int DelInput(int val)
		{
			val /= 10;
			this.SaveCurrInput(val);
			return val;
		}

		private void SaveCurrInput(int val)
		{
			bool flag = val < 10;
			if (flag)
			{
				this.inputs[2] = (this.inputs[1] = -1);
				this.inputs[0] = val;
			}
			else
			{
				bool flag2 = val < 100;
				if (flag2)
				{
					this.inputs[2] = -1;
					this.inputs[1] = val % 10;
					this.inputs[0] = val / 10;
				}
				else
				{
					this.inputs[2] = val % 10;
					this.inputs[1] = val / 10 % 10;
					this.inputs[0] = val / 100;
				}
			}
		}

		private void SetInput(int inp)
		{
			for (int i = 0; i < 3; i++)
			{
				bool flag = this.inputs[i] == -1;
				if (flag)
				{
					this.inputs[i] = inp;
					break;
				}
			}
		}

		private void PrintInput(string tag)
		{
			XSingleton<XDebug>.singleton.AddLog(tag, " " + this.inputs[0], " " + this.inputs[1], " " + this.inputs[2], null, null, XDebugColor.XDebug_None);
		}

		public IXUILabel m_lblBuyCnt;

		public IXUISprite m_sprBuyAdd;

		public IXUISprite m_sprBuyReduce;

		public IXUILabel m_lblPrice;

		public IXUIButton m_btnBuy;

		public IXUIButton m_btnSmallBuy;

		public IXUIButton m_btnPresent;

		public IXUISprite m_uiIcon;

		private XGameMallDocument doc;

		private int mCurrCnt = 1;

		private int[] inputs = new int[3];
	}
}
