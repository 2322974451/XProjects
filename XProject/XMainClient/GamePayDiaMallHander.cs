// Decompiled with JetBrains decompiler
// Type: XMainClient.GamePayDiaMallHander
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using MiniJSON;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
    internal class GamePayDiaMallHander : DlgHandlerBase
    {
        public GameObject VIPFrame;
        public GameObject RechargeFrame;
        public IXUILabel m_NextVipTip;
        public IXUILabel m_CurrVipLevel;
        public IXUILabel m_NextVipLevel;
        public Transform m_NextVip;
        public IXUILabel m_VipProgressValue;
        public IXUIProgress m_VipProgress;
        public IXUIButton m_SwitchBtn;
        public IXUILabel m_SwitchLabel;
        public GameObject m_SwitchRedPoint;
        public IXUIList m_RechargeItemList;
        public IXUIScrollView m_RechargeScrollView;
        public XUIPool m_RechargeDiamondPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        public IXUIButton _CustomerService;
        public IXUIButton _wifiBtn;
        public XUIPool m_TabTool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        public IXUIScrollView m_TabScrollView;
        public XUIPool m_DescPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
        public IXUISprite m_GetBtn;
        public IXUILabel m_GetBtnLabel;
        public GameObject m_GetBtnRedPoint;
        public IXUILabel m_ViewLevel;
        private List<XFx> m_EffectCache = new List<XFx>();
        private XRechargeDocument _Doc;
        public int CurrentClick = 0;
        private List<GameObject> _redPointList = new List<GameObject>();

        public uint VipLevel => 0;

        protected override void Init()
        {
            this._Doc = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
            this._Doc.RechargeView = this;
            this.m_NextVipTip = this.transform.Find("Bg/UpView/Tip").GetComponent("XUILabel") as IXUILabel;
            this.m_CurrVipLevel = this.transform.Find("Bg/UpView/vipicon1/Level1").GetComponent("XUILabel") as IXUILabel;
            this.m_NextVipLevel = this.transform.Find("Bg/UpView/vipicon2/Level2").GetComponent("XUILabel") as IXUILabel;
            this.m_NextVip = this.transform.Find("Bg/UpView/vipicon2");
            this.m_VipProgressValue = this.transform.Find("Bg/UpView/Progress").GetComponent("XUILabel") as IXUILabel;
            this.m_VipProgress = this.transform.Find("Bg/UpView/ProgressBar").GetComponent("XUIProgress") as IXUIProgress;
            this.m_SwitchBtn = this.transform.Find("Bg/UpView/SwitchBtn").GetComponent("XUIButton") as IXUIButton;
            this.m_SwitchLabel = this.transform.Find("Bg/UpView/SwitchBtn/Label").GetComponent("XUILabel") as IXUILabel;
            this.m_SwitchRedPoint = this.m_SwitchBtn.gameObject.transform.Find("RedPoint").gameObject;
            this.m_RechargeScrollView = this.transform.Find("Bg/RechargeFrame/Scroll View").GetComponent("XUIScrollView") as IXUIScrollView;
            this.m_RechargeItemList = this.transform.Find("Bg/RechargeFrame/Scroll View/Grid").GetComponent("XUIList") as IXUIList;
            Transform transform1 = this.transform.Find("Bg/RechargeFrame/Scroll View/Grid/TplCard");
            if ((Object)transform1 != (Object)null)
                transform1.gameObject.SetActive(false);
            Transform transform2 = this.transform.Find("Bg/RechargeFrame/Scroll View/Grid/TplDiamond");
            this.m_RechargeDiamondPool.SetupPool(transform2.parent.parent.gameObject, transform2.gameObject, 8U, false);
            Transform transform3 = this.transform.Find("Bg/VipFrame/Tabs/Tpl");
            this.m_TabTool.SetupPool(transform3.parent.gameObject, transform3.gameObject, 10U, false);
            this.m_TabScrollView = this.transform.Find("Bg/VipFrame/Tabs").GetComponent("XUIScrollView") as IXUIScrollView;
            Transform transform4 = this.transform.Find("Bg/VipFrame/RightView/DescScrollView/Tpl");
            this.m_DescPool.SetupPool(transform4.parent.gameObject, transform4.gameObject, 10U, false);
            Transform transform5 = this.transform.Find("Bg/VipFrame/RightView/Item/Tpl");
            this.m_ItemPool.SetupPool(transform5.parent.gameObject, transform5.gameObject, 8U, false);
            this.m_GetBtn = this.transform.Find("Bg/VipFrame/RightView/GetBtn").GetComponent("XUISprite") as IXUISprite;
            this.m_GetBtnLabel = this.m_GetBtn.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
            this.m_GetBtnRedPoint = this.m_GetBtn.gameObject.transform.Find("RedPoint").gameObject;
            this.m_ViewLevel = this.transform.Find("Bg/VipFrame/RightView/Name/Level").GetComponent("XUILabel") as IXUILabel;
            this.VIPFrame = this.transform.Find("Bg/VipFrame").gameObject;
            this.RechargeFrame = this.transform.Find("Bg/RechargeFrame").gameObject;
            this._CustomerService = this.transform.FindChild("CustomerService").GetComponent("XUIButton") as IXUIButton;
            this._wifiBtn = this.transform.FindChild("wifi").GetComponent("XUIButton") as IXUIButton;
        }

        public override void RegisterEvent()
        {
            this.m_SwitchBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSwitchBtnClick));
            this.m_GetBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGetGiftBtnClick));
            this._CustomerService.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCustomClick));
            this._wifiBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWifiClick));
        }

        protected override void OnShow()
        {
            base.OnShow();
            this._wifiBtn.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_3GFree));
            this.SetVipProgressInfo(this._Doc.VipLevel);
            this.m_RechargeScrollView.ResetPosition();
            this._Doc.ReqPayAllInfo();
            this.SetSwitchState();
        }

        public void SetSwitchState()
        {
            this.VIPFrame.SetActive(this._Doc.isVIPShow);
            this.RechargeFrame.SetActive(!this._Doc.isVIPShow);
            if (this._Doc.isVIPShow)
                this.m_SwitchLabel.SetText(XStringDefineProxy.GetString("RechargeBtnText"));
            else
                this.m_SwitchLabel.SetText(XStringDefineProxy.GetString("VIPBtnText"));
            this.m_SwitchRedPoint.SetActive(!this._Doc.isVIPShow && this._Doc.CalVipRedPoint());
            this.RefreshVIP();
            this.RefreshDatas();
        }

        protected override void OnHide()
        {
            this._Doc.isVIPShow = false;
            XSingleton<UiUtility>.singleton.DestroyTextureInActivePool(this.m_RechargeDiamondPool, "Icon");
            for (int index = 0; index < this.m_EffectCache.Count; ++index)
                XSingleton<XFxMgr>.singleton.DestroyFx(this.m_EffectCache[index]);
            this.m_EffectCache.Clear();
        }

        public void SetVipProgressInfo(uint currVipLevel)
        {
            this.m_CurrVipLevel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_VIP_LEVEL"), (object)currVipLevel));
            this.m_NextVipTip.SetText(this._Doc.IsMaxVip(currVipLevel) ? XSingleton<XStringTable>.singleton.GetString("PAY_VIP_MAX_TIP") : string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_NEXT_VIP_TIP"), (object)this._Doc.LackMoneyToNextVipLevel(currVipLevel), (object)(uint)((int)currVipLevel + 1)));
            this.m_NextVipLevel.SetText(this._Doc.IsMaxVip(currVipLevel) ? "" : string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_VIP_LEVEL"), (object)(uint)((int)currVipLevel + 1)));
            this.m_NextVip.gameObject.SetActive(!this._Doc.IsMaxVip(currVipLevel));
            float num1 = this._Doc.TotalPay - (float)this._Doc.GetVipRMB(currVipLevel);
            uint num2 = this._Doc.GetVipRMB(currVipLevel + 1U) - this._Doc.GetVipRMB(currVipLevel);
            this.m_VipProgress.value = num2 == 0U ? 0.0f : (this._Doc.IsMaxVip(currVipLevel) ? 1f : num1 / (float)num2);
            this.m_VipProgressValue.SetText(string.Format("{0}/{1}", (object)num1, (object)num2));
            this.m_VipProgressValue.gameObject.SetActive(!this._Doc.IsMaxVip(currVipLevel));
        }

        public void RefreshDatas()
        {
            if (this._Doc.isVIPShow)
                return;
            this.m_RechargeDiamondPool.FakeReturnAll();
            for (int index = 0; index < XRechargeDocument.PayTable.Table.Length; ++index)
            {
                GameObject gameObject = this.m_RechargeDiamondPool.FetchGameObject();
                gameObject.transform.parent = this.m_RechargeItemList.gameObject.transform;
                gameObject.transform.localScale = Vector3.one;
                IXUIButton component = gameObject.transform.GetComponent("XUIButton") as IXUIButton;
                component.ID = (ulong)index;
                component.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPayItemClick));
                this.RefreshDiamondItem(gameObject, XRechargeDocument.PayTable.Table[index]);
            }
            this.m_RechargeItemList.Refresh();
            this.m_RechargeDiamondPool.ActualReturnAll();
        }

        private bool OnCustomClick(IXUIButton btn)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    dictionary["url"] = XSingleton<XGlobalConfig>.singleton.GetValue("CustomerServiceRechargeApple");
                    dictionary["screendir"] = "SENSOR";
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                    break;
                case RuntimePlatform.Android:
                    dictionary["url"] = XSingleton<XGlobalConfig>.singleton.GetValue("CustomerServiceRechargeAndroid");
                    dictionary["screendir"] = "SENSOR";
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                    break;
                default:
                    XSingleton<XDebug>.singleton.AddGreenLog("CustomerService-Mall");
                    break;
            }
            return true;
        }

        private bool OnWifiClick(IXUIButton btn)
        {
            XDocuments.GetSpecificDocument<AdditionRemindDocument>(AdditionRemindDocument.uuID).Open3GWebPage();
            return true;
        }

        private bool OnPayCardClick(IXUIButton btn)
        {
            int id = (int)btn.ID;
            List<PayCardTable.RowData> payCardList = this._Doc.GetPayCardList();
            if (id < payCardList.Count)
            {
                XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
                if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.Android)
                    specificDocument.SDKSubscribe(payCardList[id].Price, 1, payCardList[id].ServiceCode, payCardList[id].Name, payCardList[id].ParamID, PayParamType.PAY_PARAM_CARD);
                else if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.IOS)
                {
                    int buyNum = payCardList[id].Type == 1 ? 7 : 30;
                    specificDocument.SDKSubscribe(payCardList[id].Price, buyNum, payCardList[id].ServiceCode, payCardList[id].Name, payCardList[id].ParamID, PayParamType.PAY_PARAM_CARD);
                }
            }
            return true;
        }

        private bool OnPayItemClick(IXUIButton btn)
        {
            int id = (int)btn.ID;
            if (id < XRechargeDocument.PayTable.Table.Length)
            {
                PayListTable.RowData rowData = XRechargeDocument.PayTable.Table[id];
                XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID).SDKRecharge(rowData.Price, rowData.ParamID, PayParamType.PAY_PARAM_LIST);
            }
            return true;
        }

        public void RefreshDiamondItem(GameObject item, PayListTable.RowData data)
        {
            IXUISprite component1 = item.transform.Find("Recommend").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component2 = item.transform.Find("FirstDouble").GetComponent("XUISprite") as IXUISprite;
            IXUISprite component3 = item.transform.Find("FirstHalf").GetComponent("XUISprite") as IXUISprite;
            IXUILabel component4 = item.transform.Find("Price").GetComponent("XUILabel") as IXUILabel;
            IXUILabel component5 = item.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
            IXUILabel component6 = item.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel;
            (item.transform.Find("Icon").GetComponent("XUITexture") as IXUITexture).SetTexturePath(data.Icon);
            if (data.Effect != "")
            {
                Transform parent = item.transform.Find("Icon");
                this.m_EffectCache.Add(XSingleton<XFxMgr>.singleton.CreateUIFx(data.Effect, parent));
            }
            if (data.Effect2 != "")
                this.m_EffectCache.Add(XSingleton<XFxMgr>.singleton.CreateUIFx(data.Effect2, item.transform));
            component1.SetAlpha(0.0f);
            component4.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_UNIT"), (object)(float)((double)data.Price / 100.0)));
            component5.SetText(data.Name);
            component2.SetAlpha(0.0f);
            component3.SetAlpha(0.0f);
            component6.SetVisible(false);
            PayMarketingInfo payMarketingInfo;
            if (!XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID).FirstPayMarketingInfo.TryGetValue(data.Diamond, out payMarketingInfo))
                return;
            if (payMarketingInfo.sendCount == data.Diamond)
                component2.SetAlpha(1f);
            else if (payMarketingInfo.sendCount == data.Diamond / 2)
            {
                component3.SetAlpha(1f);
            }
            else
            {
                component6.SetVisible(payMarketingInfo.sendCount > 0);
                component6.SetText(payMarketingInfo.sendCount.ToString());
            }
        }

        public bool OnSwitchBtnClick(IXUIButton sp)
        {
            this._Doc.isVIPShow = !this._Doc.isVIPShow;
            this.SetSwitchState();
            return true;
        }

        public void OnGetGiftBtnClick(IXUISprite btn)
        {
            if (this._Doc.IsGiftGet[this.CurrentClick] == VIPGiftState.UNABLE || this._Doc.IsGiftGet[this.CurrentClick] == VIPGiftState.GET)
            {
                if (this._Doc.IsGiftGet[this.CurrentClick] == VIPGiftState.UNABLE)
                    XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("VIPGiftGetUnableTips"), (object)this.CurrentClick), "fece00");
                else
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("VIPGiftGetGetTips"), "fece00");
            }
            else
                this._Doc.SendGetVIPGiftQuery(this.CurrentClick);
        }

        public void RefreshVIP()
        {
            if (!this._Doc.isVIPShow)
                return;
            this.CurrentClick = (int)this._Doc.VipLevel;
            for (int index = 0; index < this._Doc.IsGiftGet.Count; ++index)
            {
                if (this._Doc.IsGiftGet[index] == VIPGiftState.UNGET)
                {
                    this.CurrentClick = index;
                    break;
                }
            }
            this.RefreshVIPTabs();
            this.RefreshVIPView();
        }

        private void RefreshVIPTabs()
        {
            this.m_TabTool.ReturnAll();
            List<GameObject> gameObjectList = new List<GameObject>();
            this._redPointList.Clear();
            IXUIPanel component1 = this.m_TabTool._tpl.transform.parent.GetComponent("XUIPanel") as IXUIPanel;
            int num = this.CurrentClick;
            bool flag = false;
            if ((double)(this.m_TabTool.TplHeight * (this._Doc.IsGiftGet.Count - this.CurrentClick)) < (double)component1.ClipRange.w)
            {
                num = 0;
                flag = true;
            }
            IXUICheckBox xuiCheckBox = (IXUICheckBox)null;
            for (int index = 0; index < this._Doc.IsGiftGet.Count; ++index)
            {
                GameObject gameObject1 = this.m_TabTool.FetchGameObject();
                gameObject1.transform.localPosition = new Vector3(this.m_TabTool.TplPos.x, this.m_TabTool.TplPos.y - (float)(this.m_TabTool.TplHeight * (index - num)), 0.0f);
                if (!flag && index < this.CurrentClick)
                {
                    gameObject1.SetActive(false);
                    gameObjectList.Add(gameObject1);
                }
              (gameObject1.transform.Find("Text/T").GetComponent("XUILabel") as IXUILabel).SetText(string.Format(XStringDefineProxy.GetString("VIPTabsShow"), (object)index));
                GameObject gameObject2 = gameObject1.transform.Find("RedPoint").gameObject;
                this._redPointList.Add(gameObject2);
                gameObject2.SetActive(this._Doc.IsGiftGet[index] == VIPGiftState.UNGET);
                IXUICheckBox component2 = gameObject1.GetComponent("XUICheckBox") as IXUICheckBox;
                component2.ID = (ulong)index;
                component2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabsClick));
                if (index == this.CurrentClick)
                    xuiCheckBox = component2;
            }
            this.m_TabScrollView.ResetPosition();
            if (flag)
            {
                if ((uint)this.CurrentClick > 0U)
                    this.m_TabScrollView.SetPosition(1f);
            }
            else
            {
                for (int index = 0; index < gameObjectList.Count; ++index)
                    gameObjectList[index].SetActive(true);
            }
            if (xuiCheckBox == null)
                return;
            xuiCheckBox.bChecked = true;
        }

        private void RefreshVIPView()
        {
            this.m_ViewLevel.SetText(this.CurrentClick.ToString());
            VIPTable.RowData byVip = this._Doc.VIPReader.GetByVIP(this.CurrentClick);
            this.RefreshGiftState(this.CurrentClick);
            this.m_DescPool.ReturnAll();
            if (byVip.VIPTips != null)
            {
                for (int index = 0; index < byVip.VIPTips.Length; ++index)
                {
                    GameObject gameObject = this.m_DescPool.FetchGameObject();
                    Vector3 tplPos = this.m_DescPool.TplPos;
                    gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(this.m_DescPool.TplHeight * index), 0.0f);
                    (gameObject.GetComponent("XUILabel") as IXUILabel).SetText(byVip.VIPTips[index]);
                }
            }
            this.m_ItemPool.ReturnAll();
            List<DropList.RowData> dropList = new List<DropList.RowData>();
            List<ChestList.RowData> chestList;
            if (!XBagDocument.TryGetChestListConf(byVip.ItemID, out chestList))
                return;
            int index1 = 0;
            for (int count1 = chestList.Count; index1 < count1; ++index1)
            {
                ChestList.RowData rowData = chestList[index1];
                if (XBagDocument.IsProfMatchedFeable((uint)rowData.Profession, XItemDrawerParam.DefaultProfession) && XBagDocument.TryGetDropConf(rowData.DropID, ref dropList))
                {
                    int index2 = 0;
                    for (int count2 = dropList.Count; index2 < count2; ++index2)
                    {
                        ItemList.RowData itemConf = XBagDocument.GetItemConf(dropList[index2].ItemID);
                        GameObject go = this.m_ItemPool.FetchGameObject();
                        Vector3 tplPos = this.m_ItemPool.TplPos;
                        go.transform.localPosition = new Vector3(tplPos.x + (float)(this.m_ItemPool.TplWidth * index2), tplPos.y, 0.0f);
                        XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(go, itemConf, dropList[index2].ItemCount);
                        XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(go, dropList[index2].ItemID);
                    }
                }
            }
        }

        public void RefreshGiftState(int level)
        {
            if (this._Doc.IsGiftGet.Count == 0)
                return;
            this.SetGetBtnState(this._Doc.IsGiftGet[this.CurrentClick] == VIPGiftState.UNGET);
            if (this._Doc.IsGiftGet[this.CurrentClick] == VIPGiftState.GET)
                this.m_GetBtnLabel.SetText(XStringDefineProxy.GetString("SRS_FETCHED"));
            else if ((long)this._Doc.VipLevel >= (long)level)
                this.m_GetBtnLabel.SetText(XStringDefineProxy.GetString("SRS_FETCH"));
            else
                this.m_GetBtnLabel.SetText(string.Format(XStringDefineProxy.GetString("VIPGiftGetBtnUnableTips"), (object)level));
            this._redPointList[level].SetActive(this._Doc.IsGiftGet[level] == VIPGiftState.UNGET);
        }

        private void SetGetBtnState(bool state)
        {
            this.m_GetBtnRedPoint.SetActive(state);
            this.m_GetBtn.SetGrey(state);
        }

        public bool OnTabsClick(IXUICheckBox iSp)
        {
            if (!iSp.bChecked)
                return true;
            this.CurrentClick = (int)iSp.ID;
            this.RefreshVIPView();
            return true;
        }
    }
}
