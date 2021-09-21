// Decompiled with JetBrains decompiler
// Type: XMainClient.XRechargeDocument
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using MiniJSON;
using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XRechargeDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(XRechargeDocument));
        public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();
        private static PayListTable _PayReader = new PayListTable();
        private static VIPTable _VipReader = new VIPTable();
        private static PayCardTable _PayCardReader = new PayCardTable();
        public GamePayDiaMallHander RechargeView;
        private static SeqList<int> _vipColor;
        private static readonly uint NEXTVIPLEVELSHOW = 5;
        public uint MaxVIPLevel = 0;
        public bool isVIPShow = false;
        private uint _lastVipLevel = 0;
        private List<PayBaseInfo> _payInfo;
        private List<VIPGiftState> _isGiftGet = new List<VIPGiftState>();
        private List<KKSG.PayCard> _payCard;
        private uint _vipLevel;
        private float _totalPay;
        private Dictionary<int, PayMarketingInfo> m_FirstPayMarketingInfo = new Dictionary<int, PayMarketingInfo>();
        private string m_paramID;
        private int m_Price;
        private PayParamType m_paramType;
        private XRechargeDocument.RechargeType m_CurrRechargeType = XRechargeDocument.RechargeType.None;
        private List<RpcC2M_PayNotify> m_listPaySucNotify = new List<RpcC2M_PayNotify>();
        private float m_NotifyTime = 0.0f;
        private float m_NotifyInterval = 0.0f;
        private int m_NotifyCount = 0;
        private string m_goodsParamID = "";
        private uint m_goodsPrice;
        private string m_goodsUrl;

        public override uint ID => XRechargeDocument.uuID;

        public VIPTable VIPReader => XRechargeDocument._VipReader;

        public PayCardTable PayCardReader => XRechargeDocument._PayCardReader;

        public static PayListTable PayTable => XRechargeDocument._PayReader;

        public List<PayBaseInfo> PayInfo => this._payInfo;

        public List<VIPGiftState> IsGiftGet => this._isGiftGet;

        public List<KKSG.PayCard> PayCard => this._payCard;

        public uint VipLevel => this._vipLevel;

        public float TotalPay => this._totalPay;

        public static void Execute(OnLoadedCallback callback = null)
        {
            XRechargeDocument.AsyncLoader.AddTask("Table/PayList", (CVSReader)XRechargeDocument._PayReader);
            XRechargeDocument.AsyncLoader.AddTask("Table/Vip", (CVSReader)XRechargeDocument._VipReader);
            XRechargeDocument.AsyncLoader.AddTask("Table/PayCard", (CVSReader)XRechargeDocument._PayCardReader);
            XRechargeDocument.AsyncLoader.Execute(callback);
        }

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this.MaxVIPLevel = (uint)(XRechargeDocument._VipReader.Table.Length - 1);
            if (XRechargeDocument._vipColor == null)
                XRechargeDocument._vipColor = XSingleton<XGlobalConfig>.singleton.GetSequenceList("VIPIntervalColor", false);
            this.m_listPaySucNotify.Clear();
            this.m_NotifyInterval = (float)XSingleton<XGlobalConfig>.singleton.GetInt("RechargeSucNotifyRepeatInterval");
            this.m_NotifyCount = XSingleton<XGlobalConfig>.singleton.GetInt("RechargeSucNotifyRepeatCount");
        }

        public VIPTable.RowData GetVipPermissions(uint vip)
        {
            vip = Math.Max(vip, 0U);
            vip = Math.Min(vip, this.MaxVIPLevel);
            return XRechargeDocument._VipReader.GetByVIP((int)vip);
        }

        public VIPTable.RowData GetCurrentVipPermissions() => this.GetVipPermissions(this._vipLevel);

        public void ReqPayAllInfo() => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GetPayAllInfo());

        public void OnGetPayAllInfo(GetPayAllInfoArg oArg, GetPayAllInfoRes oRes)
        {
            if (oRes.errcode != ErrorCode.ERR_SUCCESS)
                return;
            this.SetAllData(oRes.info);
        }

        private void SetAllData(PayAllInfo info)
        {
            this.SetAllPayInfoData(info);
            if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetVip();
            this.SetVIPGiftState(info.VipLevelGift);
            if (this.RechargeView == null || !this.RechargeView.IsVisible())
                return;
            this.RechargeView.SetVipProgressInfo(this.VipLevel);
            this.RechargeView.RefreshData();
            this.RechargeView.RefreshVIP();
        }

        private void SetAllPayInfoData(PayAllInfo info)
        {
            this._payInfo = info.pay;
            this._payCard = info.card;
            this._vipLevel = info.vipLevel;
            this._lastVipLevel = this._vipLevel;
            this._totalPay = (float)info.totalPay / 100f;
        }

        public void PayAllInfoNtf(PayAllInfo info) => this.SetAllData(info);

        public List<PayCardTable.RowData> GetPayCardList()
        {
            List<PayCardTable.RowData> rowDataList = new List<PayCardTable.RowData>();
            for (int index1 = 0; index1 < XRechargeDocument._PayCardReader.Table.Length; ++index1)
            {
                bool flag = false;
                if (this._payCard != null)
                {
                    for (int index2 = 0; index2 < this._payCard.Count; ++index2)
                    {
                        if ((long)XRechargeDocument._PayCardReader.Table[index1].Type == (long)this._payCard[index2].type)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                    rowDataList.Add(XRechargeDocument._PayCardReader.Table[index1]);
            }
            return rowDataList;
        }

        public uint GetVipRMB(uint vipLevel)
        {
            for (int index = 0; index < XRechargeDocument._VipReader.Table.Length; ++index)
            {
                if ((long)XRechargeDocument._VipReader.Table[index].VIP == (long)vipLevel)
                    return XRechargeDocument._VipReader.Table[index].RMB;
            }
            return 0;
        }

        public float LackMoneyToNextVipLevel(uint currVipLevel)
        {
            if (this.IsMaxVip(currVipLevel))
                return 0.0f;
            uint vipRmb = this.GetVipRMB(currVipLevel + 1U);
            return (double)vipRmb > (double)this.TotalPay ? (float)vipRmb - this.TotalPay : 0.0f;
        }

        public bool IsMaxVip(uint vipLevel)
        {
            for (int index = 0; index < XRechargeDocument._VipReader.Table.Length; ++index)
            {
                if ((long)XRechargeDocument._VipReader.Table[index].VIP > (long)vipLevel)
                    return false;
            }
            return true;
        }

        public Dictionary<int, PayMarketingInfo> FirstPayMarketingInfo => this.m_FirstPayMarketingInfo;

        public void GetPayMarketingInfo()
        {
            XSingleton<XDebug>.singleton.AddLog(nameof(GetPayMarketingInfo));
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("get_reward_info", "");
        }

        public void OnGetPayMarketingInfo(List<PayMarketingInfo> listInfo)
        {
            this.m_FirstPayMarketingInfo.Clear();
            for (int index = 0; index < listInfo.Count; ++index)
            {
                if (listInfo[index].sendExt != "")
                    this.m_FirstPayMarketingInfo[listInfo[index].diamondCount] = listInfo[index];
            }
            if (!DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.IsVisible() || DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.currSys != XSysDefine.XSys_GameMall_Pay)
                return;
            DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.RefreshDiamondPay();
        }

        public void PayParameterNtf()
        {
            string openKey;
            string pf;
            string pfKey;
            string sesstionType;
            string sesstionID;
            string offerid;
            this.GetPayBillInfo(out openKey, out pf, out pfKey, out sesstionType, out sesstionID, out offerid);
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2M_PayParameterInfoNtf()
            {
                Data = {
          openkey = openKey,
          sessionType = sesstionType,
          sessionId = sesstionID,
          pf = pf,
          pfKey = pfKey,
          appid = offerid
        }
            });
        }

        public void GetPayBillInfo(
          out string openKey,
          out string pf,
          out string pfKey,
          out string sesstionType,
          out string sesstionID,
          out string offerid)
        {
            openKey = "";
            pf = "";
            pfKey = "";
            sesstionType = "";
            sesstionID = "";
            offerid = "";
            string payBill = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetPayBill();
            if (payBill == "")
            {
                XSingleton<XDebug>.singleton.AddLog("Pay [GetPayBill] error ");
            }
            else
            {
                if (!(Json.Deserialize(payBill) is Dictionary<string, object> dictionary2))
                    return;
                object obj1;
                if (dictionary2.TryGetValue("pay_token", out obj1))
                    openKey = obj1.ToString();
                object obj2;
                if (dictionary2.TryGetValue(nameof(pf), out obj2))
                    pf = obj2.ToString();
                object obj3;
                if (dictionary2.TryGetValue("pfkey", out obj3))
                    pfKey = obj3.ToString();
                object obj4;
                if (dictionary2.TryGetValue("sessiontype", out obj4))
                    sesstionType = obj4.ToString();
                object obj5;
                if (dictionary2.TryGetValue("sessionid", out obj5))
                    sesstionID = obj5.ToString();
                object obj6;
                if (!dictionary2.TryGetValue(nameof(offerid), out obj6))
                    return;
                offerid = obj6.ToString();
            }
        }

        public void SDKRecharge(int price, string paramID, PayParamType paramType)
        {
            if (XSingleton<UiUtility>.singleton.IsWeakNetwork())
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_WEAK_NETWORK_TIP"), "fece00");
            this.m_paramID = paramID;
            this.m_paramType = paramType;
            this.m_Price = price;
            this.m_CurrRechargeType = XRechargeDocument.RechargeType.DiamondRecharge;
            XSingleton<XDebug>.singleton.AddLog("[SDKRecharge] price = " + (object)price + ", paramID" + paramID);
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Pay(price, "", paramID, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, XSingleton<XClientNetwork>.singleton.ServerID);
        }

        public void SDKSubscribe(
          int price,
          int buyNum,
          string serviceCode,
          string serviceName,
          string paramID,
          PayParamType paramType)
        {
            if (XSingleton<UiUtility>.singleton.IsWeakNetwork())
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_WEAK_NETWORK_TIP"), "fece00");
            this.m_paramID = serviceCode;
            this.m_paramType = paramType;
            this.m_Price = price;
            this.m_CurrRechargeType = XRechargeDocument.RechargeType.Subscribe;
            string json = Json.Serialize((object)new Dictionary<string, object>()
            {
                [nameof(buyNum)] = (object)buyNum,
                [nameof(serviceCode)] = (object)serviceCode,
                [nameof(serviceName)] = (object)serviceName,
                ["productId"] = (object)paramID,
                ["remark"] = (object)string.Format("aid={0}", (object)XSingleton<XGlobalConfig>.singleton.GetValue("AID")),
                ["zoneId"] = (object)string.Format("{0}_{1}", (object)XSingleton<XClientNetwork>.singleton.ServerID, (object)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID)
            });
            XSingleton<XDebug>.singleton.AddLog("[SDKSubscribe] param = " + json);
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("pay_for_subscribe", json);
        }

        public override void Update(float fDeltaT)
        {
            this.m_NotifyTime += fDeltaT;
            if ((double)this.m_NotifyTime <= (double)this.m_NotifyInterval)
                return;
            int index = 0;
            while (index < this.m_listPaySucNotify.Count)
            {
                RpcC2M_PayNotify rpcC2MPayNotify = this.m_listPaySucNotify[index];
                ++rpcC2MPayNotify.oArg.count;
                if (rpcC2MPayNotify.oArg.count > this.m_NotifyCount)
                {
                    this.m_listPaySucNotify.RemoveAt(index);
                    XSingleton<XDebug>.singleton.AddGreenLog("m_listPaySucNotify.Remove paramid = " + rpcC2MPayNotify.oArg.paramid + ", count = " + (object)rpcC2MPayNotify.oArg.count);
                }
                else
                {
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)rpcC2MPayNotify);
                    XSingleton<XDebug>.singleton.AddGreenLog("m_listPaySucNotify.Resend paramid = " + rpcC2MPayNotify.oArg.paramid + ", count = " + (object)rpcC2MPayNotify.oArg.count);
                    ++index;
                }
            }
            this.m_NotifyTime = 0.0f;
        }

        private void RemoveNotify(PayNotifyArg oArg)
        {
            for (int index = 0; index < this.m_listPaySucNotify.Count; ++index)
            {
                RpcC2M_PayNotify rpcC2MPayNotify = this.m_listPaySucNotify[index];
                if (rpcC2MPayNotify.oArg.paramid == oArg.paramid && oArg.count == 1)
                {
                    this.m_listPaySucNotify.RemoveAt(index);
                    XSingleton<XDebug>.singleton.AddGreenLog("RemoveNotify paramid = " + rpcC2MPayNotify.oArg.paramid + ", remove count = " + (object)rpcC2MPayNotify.oArg.count + ", find count = " + (object)oArg.count);
                    break;
                }
            }
        }

        public void PaySuccessNtf()
        {
            string openKey;
            string pf;
            string pfKey;
            string sesstionType;
            string sesstionID;
            string offerid;
            this.GetPayBillInfo(out openKey, out pf, out pfKey, out sesstionType, out sesstionID, out offerid);
            RpcC2M_PayNotify rpcC2MPayNotify = new RpcC2M_PayNotify();
            rpcC2MPayNotify.oArg.type = this.m_paramType;
            rpcC2MPayNotify.oArg.paramid = this.m_paramID;
            rpcC2MPayNotify.oArg.amount = this.m_Price;
            rpcC2MPayNotify.oArg.count = 1;
            rpcC2MPayNotify.oArg.data = new PayParameterInfo()
            {
                openkey = openKey,
                sessionType = sesstionType,
                sessionId = sesstionID,
                pf = pf,
                pfKey = pfKey,
                appid = offerid
            };
            XSingleton<XClientNetwork>.singleton.Send((Rpc)rpcC2MPayNotify);
            this.m_NotifyTime = 0.0f;
            if (XSingleton<XGlobalConfig>.singleton.GetInt("RechargeSucNotifyRepeat") == 1)
                this.m_listPaySucNotify.Add(rpcC2MPayNotify);
            DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(false, true);
        }

        public void OnPayNotify(PayNotifyArg oArg, PayNotifyRes oRes)
        {
            if ((uint)oRes.errcode > 0U)
                XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode);
            else
                this.RemoveNotify(oArg);
        }

        public void OnPayCallback(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("Pay [OnPayCallback] msg:" + msg);
            if (this.m_CurrRechargeType == XRechargeDocument.RechargeType.DiamondRecharge || this.m_CurrRechargeType == XRechargeDocument.RechargeType.Subscribe)
                this.OnRechargeAndSubscribeCallback(msg);
            else if (this.m_CurrRechargeType == XRechargeDocument.RechargeType.BuyGoods)
                this.OnBuyGoodsPayCallback(msg);
            else if (this.m_CurrRechargeType == XRechargeDocument.RechargeType.PandoraBuyGoods)
                this.OnPandoraBuyGoodsCallback(msg);
            XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.OnPayCallback(msg, this.m_goodsParamID);
        }

        private void OnRechargeAndSubscribeCallback(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("Pay [OnRechargeAndSubscribeCallback] msg:" + msg);
            if (msg == "true" || msg == "Success")
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_SUCCESS"), "fece00");
                this.CheckGiftBag();
                this.ResetGiftBagBtnCD();
                this.PaySuccessNtf();
                this.GetPayMarketingInfo();
            }
            else
                DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(false, true);
        }

        private void OnBuyGoodsPayCallback(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("Pay [OnBuyGoodsPayCallback] msg:" + msg);
            if (msg == "true" || msg == "Success")
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_SUCCESS_GOODS"), "fece00");
                DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(false, true);
            }
            else
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_FAIL_GOODS"), "fece00");
                this.NoticeBusyGoodsFail();
            }
        }

        private void OnPandoraBuyGoodsCallback(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("Pay [OnPandoraBuyGoodsCallback] msg:" + msg);
            if (msg == "true" || msg == "Success")
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_SUCCESS_PANDORA"), "fece00");
                XSingleton<XPandoraSDKDocument>.singleton.NoticePandoraBuyGoodsResult("success");
            }
            else
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_FAIL_PANDORA"), "fece00");
                XSingleton<XPandoraSDKDocument>.singleton.NoticePandoraBuyGoodsResult("fail");
            }
        }

        private void ResetGiftBagBtnCD()
        {
            XSingleton<XDebug>.singleton.AddLog("Pay [ResetGiftBagBtnCD]");
            if (this.m_paramType != PayParamType.PAY_PARAM_AILEEN)
                return;
            int interval = XSingleton<XGlobalConfig>.singleton.GetInt("GiftBagBtnClickInterval");
            if (interval == 0)
            {
                XSingleton<XDebug>.singleton.AddLog("Pay [ResetGiftBagBtnCD] GiftBagBtnClickInterval = 0");
            }
            else
            {
                XSingleton<XDebug>.singleton.AddLog("Pay [ResetGiftBagBtnCD] interval = " + interval.ToString());
                XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID).ResetGiftBagBtnCD(interval);
            }
        }

        private void CheckGiftBag()
        {
            XSingleton<XDebug>.singleton.AddLog("Pay [CheckGiftBag]");
            if (XSingleton<XGlobalConfig>.singleton.GetInt("HideGiftBagBtnAtOnce") == 0)
            {
                XSingleton<XDebug>.singleton.AddLog("Pay [CheckGiftBag] HideGiftBagBtnAtOnce = 0");
            }
            else
            {
                XSingleton<XDebug>.singleton.AddLog("Pay [CheckGiftBag] m_paramType = " + this.m_paramType.ToString());
                if (this.m_paramType != PayParamType.PAY_PARAM_AILEEN)
                    return;
                XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID).HideGiftBagBtn(this.m_paramID);
            }
        }

        public void SDKBuyGoods(
          uint id,
          uint goodsCount,
          ulong toRoleID,
          string text,
          string paramID,
          uint price)
        {
            XSingleton<XDebug>.singleton.AddLog("[SDKBuyGoods] id = " + (object)id + ", goodsCount = " + (object)goodsCount + ", toRoleID = " + (object)toRoleID + ",text = " + text + ", paramID = " + paramID + ", price = " + (object)price);
            if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() != XPlatformType.Standalone && !Application.isEditor)
                DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(true, true);
            if (XSingleton<UiUtility>.singleton.IsWeakNetwork())
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_WEAK_NETWORK_TIP"), "fece00");
            string openKey;
            string pf;
            string pfKey;
            string sesstionType;
            string sesstionID;
            string offerid;
            this.GetPayBillInfo(out openKey, out pf, out pfKey, out sesstionType, out sesstionID, out offerid);
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_PayFriendItem()
            {
                oArg = {
          payparam = new PayParameterInfo()
          {
            openkey = openKey,
            sessionType = sesstionType,
            sessionId = sesstionID,
            pf = pf,
            pfKey = pfKey,
            appid = offerid
          },
          goodsid = id,
          count = goodsCount,
          toroleid = toRoleID,
          text = text
        }
            });
        }

        public void OnGetBuyGoodsOrder(PayFriendItemArg oArg, PayFriendItemRes oRes)
        {
            if ((uint)oRes.ret > 0U)
            {
                DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(false, true);
                XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ret);
            }
            else
            {
                if (XSingleton<UiUtility>.singleton.IsWeakNetwork())
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PAY_WEAK_NETWORK_TIP"), "fece00");
                this.m_goodsUrl = oRes.billno;
                this.m_goodsParamID = oRes.paramid;
                this.m_goodsPrice = oRes.price;
                this.m_CurrRechargeType = XRechargeDocument.RechargeType.BuyGoods;
                string json = Json.Serialize((object)new Dictionary<string, object>()
                {
                    ["zoneId"] = (object)XSingleton<XClientNetwork>.singleton.ServerID.ToString(),
                    ["productId"] = (object)oRes.paramid,
                    ["buyNum"] = (object)oArg.count,
                    ["price"] = (object)oRes.price,
                    ["tokenUrl"] = (object)oRes.url_param,
                    ["extInfo"] = (object)oRes.billno
                });
                XSingleton<XDebug>.singleton.AddLog("[OnGetBuyGoodsOrder] param = " + json);
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("pay_for_props", json);
                DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(false, true);
            }
        }

        private void NoticeBusyGoodsFail()
        {
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2M_PayBuyGoodsFailNtf()
            {
                Data = {
          token = this.m_goodsUrl
        }
            });
            DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(false, true);
        }

        public void SDKPandoraBuyGoods(string json)
        {
            this.m_CurrRechargeType = XRechargeDocument.RechargeType.PandoraBuyGoods;
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("pay_for_pandora", json);
        }

        public void SendGetVIPGiftQuery(int level) => XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_BuyVipLevelGift()
        {
            oArg = {
        vipLevel = level
      }
        });

        public void OnGetVIPGift(int level)
        {
            this.IsGiftGet[level] = VIPGiftState.GET;
            this.CalVipRedPoint();
            if (this.RechargeView == null || !this.RechargeView.IsVisible() || !this.isVIPShow)
                return;
            this.RechargeView.RefreshGiftState(level);
        }

        public bool CalVipRedPoint()
        {
            for (int index = 0; index < this.IsGiftGet.Count; ++index)
            {
                if (this.IsGiftGet[index] == VIPGiftState.UNGET)
                    return true;
            }
            XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GameMall_Pay, false);
            XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GameMall);
            return false;
        }

        public void SetVIPGiftState(List<int> getGiftList)
        {
            this.IsGiftGet.Clear();
            uint num = this.MaxVIPLevel < this._vipLevel + XRechargeDocument.NEXTVIPLEVELSHOW ? this.MaxVIPLevel : this._vipLevel + XRechargeDocument.NEXTVIPLEVELSHOW;
            for (int index = 0; (long)index <= (long)num; ++index)
            {
                if ((long)this._vipLevel >= (long)index)
                    this.IsGiftGet.Add(VIPGiftState.UNGET);
                else
                    this.IsGiftGet.Add(VIPGiftState.UNABLE);
            }
            for (int index = 0; index < getGiftList.Count; ++index)
            {
                int getGift = getGiftList[index];
                if ((long)getGift > (long)this._vipLevel)
                    XSingleton<XDebug>.singleton.AddErrorLog("Error. viplevel = ", this._vipLevel.ToString(), "  but gift is get by level = ", getGift.ToString());
                this.IsGiftGet[getGift] = VIPGiftState.GET;
            }
        }

        public void ShowVipLevelUp() => XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(string.Format(XStringDefineProxy.GetString("VIPLevelUpTips"), (object)"{n}", (object)"{n}", (object)this._vipLevel)), XStringDefineProxy.GetString("VIPLevelUpBtnLabel"), new ButtonClickEventHandler(this.ShowCurrentVip));

        private bool ShowCurrentVip(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            this.isVIPShow = true;
            if (DlgBase<GameMallDlg, TabDlgBehaviour>.singleton._gamePayDiaMallHander != null && DlgBase<GameMallDlg, TabDlgBehaviour>.singleton._gamePayDiaMallHander.IsVisible())
            {
                this.ReqPayAllInfo();
                DlgBase<GameMallDlg, TabDlgBehaviour>.singleton._gamePayDiaMallHander.SetSwitchState();
            }
            else
                DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowPurchase(ItemEnum.DIAMOND);
            return true;
        }

        public static string GetVIPIconString(uint level) => "";

        public static string GetVIPIconNameString(uint level)
        {
            int num = 0;
            for (int index = 0; index < (int)XRechargeDocument._vipColor.Count; ++index)
            {
                if ((long)level >= (long)XRechargeDocument._vipColor[index, 0] && (long)level <= (long)XRechargeDocument._vipColor[index, 1])
                {
                    num = index + 1;
                    break;
                }
            }
            if (num == 0)
                XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Can't find vip{0} 's icon color.", (object)level));
            return XSingleton<XCommon>.singleton.StringCombine("rechar_vip0", num.ToString());
        }

        protected override void OnReconnected(XReconnectedEventArgs arg) => DlgBase<XBlockInputView, XBlockInputBehaviour>.singleton.SetVisible(false, true);

        public enum RechargeType
        {
            None,
            DiamondRecharge,
            Subscribe,
            BuyGoods,
            PandoraBuyGoods,
        }
    }
}
