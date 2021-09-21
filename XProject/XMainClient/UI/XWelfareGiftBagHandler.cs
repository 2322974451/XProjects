using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018ED RID: 6381
	internal class XWelfareGiftBagHandler : DlgHandlerBase
	{
		// Token: 0x17003A84 RID: 14980
		// (get) Token: 0x06010A00 RID: 68096 RVA: 0x0041C030 File Offset: 0x0041A230
		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/GiftBagFrame";
			}
		}

		// Token: 0x06010A01 RID: 68097 RVA: 0x0041C048 File Offset: 0x0041A248
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.Find("ListGiftBag/Grid/Tpl/List/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			Transform transform2 = base.PanelObject.transform.Find("ListGiftBag/Grid/Tpl");
			this.m_GiftBagPool.SetupPool(transform2.parent.parent.gameObject, transform2.gameObject, 3U, false);
			this.m_GiftList = (base.PanelObject.transform.Find("ListGiftBag/Grid").GetComponent("XUIList") as IXUIList);
			this.m_LeftTime = (base.PanelObject.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTimeName = (base.PanelObject.transform.Find("LeftTimeName").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTimeName.SetText(XSingleton<XStringTable>.singleton.GetString("PAY_GIFTBAG_LEFT_TIME_TITLE"));
			this.m_GiftBoxClosed = (base.PanelObject.transform.Find("DailyGift1").GetComponent("XUISprite") as IXUISprite);
			this.m_GiftBoxOpened = (base.PanelObject.transform.Find("DailyGift2").GetComponent("XUISprite") as IXUISprite);
			this.m_DefaultBg = base.PanelObject.transform.Find("Bg0").gameObject;
			this.m_BackFlowBg = base.PanelObject.transform.Find("Bg1").gameObject;
		}

		// Token: 0x06010A02 RID: 68098 RVA: 0x0041C1F9 File Offset: 0x0041A3F9
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_GiftBoxClosed.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClosedBoxClicked));
			this.m_GiftBoxOpened.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenedBoxClicked));
		}

		// Token: 0x06010A03 RID: 68099 RVA: 0x0041C234 File Offset: 0x0041A434
		private void OnClosedBoxClicked(IXUISprite sp)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.GetLittleGiftBag();
		}

		// Token: 0x06010A04 RID: 68100 RVA: 0x0041C254 File Offset: 0x0041A454
		private void OnOpenedBoxClicked(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_GIFTBAG_GIFT_HAVE_GOT"), "fece00");
		}

		// Token: 0x06010A05 RID: 68101 RVA: 0x0041C278 File Offset: 0x0041A478
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.Xsys_Backflow);
			this.m_DefaultBg.SetActive(!flag);
			this.m_BackFlowBg.SetActive(flag);
		}

		// Token: 0x06010A06 RID: 68102 RVA: 0x0041C2BA File Offset: 0x0041A4BA
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
		}

		// Token: 0x06010A07 RID: 68103 RVA: 0x0041C2D8 File Offset: 0x0041A4D8
		public override void RefreshData()
		{
			XSingleton<XDebug>.singleton.AddLog("Pay GiftBagHandler [RefreshData]", null, null, null, null, null, XDebugColor.XDebug_None);
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			PayAileen payGiftBagInfo = specificDocument.PayGiftBagInfo;
			bool flag = payGiftBagInfo == null;
			if (!flag)
			{
				this.currLeftTime = (int)payGiftBagInfo.remainedTime;
				this.m_LeftTime.gameObject.SetActive(this.currLeftTime > 0);
				this.m_LeftTimeName.gameObject.SetActive(this.currLeftTime > 0);
				bool flag2 = this.currLeftTime > 0;
				if (flag2)
				{
					this.m_LeftTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)payGiftBagInfo.remainedTime, 3, 3, 4, false, true));
					XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
					this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
				}
				List<PayAileenInfo> aileenInfo = payGiftBagInfo.AileenInfo;
				aileenInfo.Sort(new Comparison<PayAileenInfo>(XWelfareGiftBagHandler.GiftInfoCompare));
				this.m_GiftBagPool.FakeReturnAll();
				this.m_ItemPool.FakeReturnAll();
				for (int i = 0; i < aileenInfo.Count; i++)
				{
					GameObject gameObject = this.m_GiftBagPool.FetchGameObject(false);
					gameObject.transform.parent = this.m_GiftList.gameObject.transform;
					gameObject.transform.localScale = Vector3.one;
					this.SetGiftBagInfo(gameObject, aileenInfo[i]);
				}
				this.m_GiftList.Refresh();
				this.m_GiftBagPool.ActualReturnAll(false);
				this.m_ItemPool.ActualReturnAll(false);
				this.m_GiftBoxClosed.SetVisible(specificDocument.RewardLittleGiftBag == 0U);
				this.m_GiftBoxOpened.SetVisible(specificDocument.RewardLittleGiftBag > 0U);
			}
		}

		// Token: 0x06010A08 RID: 68104 RVA: 0x0041C4B0 File Offset: 0x0041A6B0
		private static int GiftInfoCompare(PayAileenInfo info1, PayAileenInfo info2)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			PayAileenTable.RowData giftBagTableData = XWelfareDocument.GetGiftBagTableData(info1.paramID, specificDocument.PayGiftBagInfo.weekDays);
			PayAileenTable.RowData giftBagTableData2 = XWelfareDocument.GetGiftBagTableData(info2.paramID, specificDocument.PayGiftBagInfo.weekDays);
			bool flag = giftBagTableData != null && giftBagTableData2 != null;
			int result;
			if (flag)
			{
				result = giftBagTableData.Price - giftBagTableData2.Price;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06010A09 RID: 68105 RVA: 0x0041C520 File Offset: 0x0041A720
		private void LeftTimeUpdate(object o)
		{
			this.currLeftTime--;
			bool flag = this.currLeftTime < 0;
			if (flag)
			{
				this.m_LeftTime.gameObject.SetActive(false);
				this.m_LeftTimeName.gameObject.SetActive(false);
			}
			else
			{
				this.m_LeftTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(this.currLeftTime, 3, 3, 4, false, true));
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
				this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
			}
		}

		// Token: 0x06010A0A RID: 68106 RVA: 0x0041C5C4 File Offset: 0x0041A7C4
		private void SetGiftBagInfo(GameObject item, PayAileenInfo info)
		{
			XSingleton<XDebug>.singleton.AddLog("Pay GiftBagHandler [SetGiftBagInfo]", null, null, null, null, null, XDebugColor.XDebug_None);
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			PayAileenTable.RowData giftBagTableData = XWelfareDocument.GetGiftBagTableData(info.paramID, specificDocument.PayGiftBagInfo.weekDays);
			bool flag = giftBagTableData == null;
			if (!flag)
			{
				XSingleton<XDebug>.singleton.AddLog("Pay GiftBagHandler [SetGiftBagInfo] 1", null, null, null, null, null, XDebugColor.XDebug_None);
				IXUISprite ixuisprite = item.transform.Find("PayMember").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetVisible(giftBagTableData.MemberLimit > 0);
				ixuisprite.SetSprite(specificDocument.GetMemberPrivilegeIcon((MemberPrivilege)giftBagTableData.MemberLimit));
				float num = (float)giftBagTableData.Price / 100f;
				IXUILabel ixuilabel = item.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(giftBagTableData.Desc);
				IXUIList ixuilist = item.transform.Find("List").GetComponent("XUIList") as IXUIList;
				XLevelSealDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
				uint sealType = specificDocument2.GetSealType();
				int giftBagID = this.GetGiftBagID(giftBagTableData, sealType);
				ChestList.RowData chestConf = XBagDocument.GetChestConf(giftBagID);
				bool flag2 = chestConf != null;
				if (flag2)
				{
					uint[] dropID = chestConf.DropID;
					bool flag3 = dropID != null;
					if (flag3)
					{
						foreach (uint field in dropID)
						{
							int num2;
							int num3;
							CVSReader.GetRowDataListByField<DropList.RowData, int>(XBagDocument.DropTable.Table, (int)field, out num2, out num3, XBagDocument.comp);
							bool flag4 = num2 < 0;
							if (!flag4)
							{
								for (int j = num2; j <= num3; j++)
								{
									DropList.RowData rowData = XBagDocument.DropTable.Table[j];
									GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
									gameObject.transform.parent = ixuilist.gameObject.transform;
									XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, rowData.ItemID, rowData.ItemCount, true);
									IXUISprite ixuisprite2 = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
									ixuisprite2.ID = (ulong)((long)rowData.ItemID);
									ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
								}
							}
						}
					}
				}
				ixuilist.Refresh();
				IXUILabel ixuilabel2 = item.transform.Find("Btn/T").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = item.transform.Find("Owned").GetComponent("XUILabel") as IXUILabel;
				IXUIButton ixuibutton = item.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)((long)XWelfareDocument.GetGiftBagTableIndex(info.paramID));
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGiftBagBtnClicked));
				XSingleton<XDebug>.singleton.AddLog("Pay GiftBagHandler [SetGiftBagInfo]  isbuy = " + info.isBuy.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
				bool isBuy = info.isBuy;
				if (isBuy)
				{
					ixuibutton.SetVisible(false);
					ixuilabel3.SetVisible(true);
					ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("PAY_HAS_GOT"));
				}
				else
				{
					ixuibutton.SetVisible(true);
					ixuilabel3.SetVisible(false);
					ixuilabel2.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_BUY_TEX"), num));
					ixuibutton.SetEnable(true, false);
				}
			}
		}

		// Token: 0x06010A0B RID: 68107 RVA: 0x0041C970 File Offset: 0x0041AB70
		private bool OnGiftBagIconClicked(IXUIButton btn)
		{
			int itemID = (int)btn.ID;
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(itemID, null);
			return true;
		}

		// Token: 0x06010A0C RID: 68108 RVA: 0x0041C998 File Offset: 0x0041AB98
		private bool OnGiftBagBtnClicked(IXUIButton btn)
		{
			int num = (int)btn.ID;
			bool flag = num == -1 || num >= XWelfareDocument.AileenTable.Table.Length;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				PayAileenTable.RowData rowData = XWelfareDocument.AileenTable.Table[num];
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				bool flag2 = (ulong)specificDocument.VipLevel < (ulong)((long)rowData.VipLimit);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_GIFT_BAG_VIP_LIMIT"), rowData.VipLimit), "fece00");
					result = false;
				}
				else
				{
					bool flag3 = rowData.MemberLimit > 0;
					if (flag3)
					{
						bool flag4 = !specificDocument.IsOwnMemberPrivilege((MemberPrivilege)rowData.MemberLimit);
						if (flag4)
						{
							PayMemberTable.RowData memberPrivilegeConfig = specificDocument.GetMemberPrivilegeConfig((MemberPrivilege)rowData.MemberLimit);
							bool flag5 = memberPrivilegeConfig == null;
							if (flag5)
							{
								return false;
							}
							XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("PAY_GIFTBAG_PAYMEMBER_LIMIT", new object[]
							{
								memberPrivilegeConfig.Name
							}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.GoToKingdomPrivilege));
							return false;
						}
					}
					XRechargeDocument specificDocument2 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
					specificDocument2.SDKSubscribe(rowData.Price, 1, rowData.ServiceCode, rowData.Name, rowData.ParamID, PayParamType.PAY_PARAM_AILEEN);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06010A0D RID: 68109 RVA: 0x0041CB00 File Offset: 0x0041AD00
		private bool GoToKingdomPrivilege(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			bool flag = !specificDocument.IsSystemAvailable(XSysDefine.XSys_Welfare_KingdomPrivilege);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_KINGDOM_NOT_OPEN"), "fece00");
				result = true;
			}
			else
			{
				DlgBase<XWelfareView, XWelfareBehaviour>.singleton.SelectTab(XSysDefine.XSys_Welfare_KingdomPrivilege);
				result = true;
			}
			return result;
		}

		// Token: 0x06010A0E RID: 68110 RVA: 0x0041CB74 File Offset: 0x0041AD74
		private int GetGiftBagID(PayAileenTable.RowData info, uint sealType)
		{
			int[] levelSealGiftID = info.LevelSealGiftID;
			int num = (int)(sealType - 1U);
			bool flag = levelSealGiftID != null && num < levelSealGiftID.Length && num >= 0;
			int result;
			if (flag)
			{
				result = levelSealGiftID[num];
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06010A0F RID: 68111 RVA: 0x0041CBB0 File Offset: 0x0041ADB0
		public void ResetGiftBagBtnCD(int interval)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				IXUIButton ixuibutton = base.PanelObject.transform.Find("ListGiftBag/Grid/item0/Btn").GetComponent("XUIButton") as IXUIButton;
				IXUIButton ixuibutton2 = base.PanelObject.transform.Find("ListGiftBag/Grid/item1/Btn").GetComponent("XUIButton") as IXUIButton;
				IXUIButton ixuibutton3 = base.PanelObject.transform.Find("ListGiftBag/Grid/item2/Btn").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.SetUnavailableCD(interval);
				ixuibutton2.SetUnavailableCD(interval);
				ixuibutton3.SetUnavailableCD(interval);
			}
		}

		// Token: 0x040078EE RID: 30958
		private XUIPool m_GiftBagPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040078EF RID: 30959
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040078F0 RID: 30960
		private IXUIList m_GiftList;

		// Token: 0x040078F1 RID: 30961
		private IXUILabel m_LeftTime;

		// Token: 0x040078F2 RID: 30962
		private IXUILabel m_LeftTimeName;

		// Token: 0x040078F3 RID: 30963
		private int currLeftTime;

		// Token: 0x040078F4 RID: 30964
		private uint _CDToken;

		// Token: 0x040078F5 RID: 30965
		private IXUISprite m_GiftBoxClosed;

		// Token: 0x040078F6 RID: 30966
		private IXUISprite m_GiftBoxOpened;

		// Token: 0x040078F7 RID: 30967
		private GameObject m_DefaultBg;

		// Token: 0x040078F8 RID: 30968
		private GameObject m_BackFlowBg;
	}
}
