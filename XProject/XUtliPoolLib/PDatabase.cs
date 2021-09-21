// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.PDatabase
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using MiniJSON;
using System.Collections.Generic;

namespace XUtliPoolLib
{
    public class PDatabase : XSingleton<PDatabase>
    {
        public PlayerInfo playerInfo;
        public FriendInfo friendsInfo;
        public WXGroupInfo wxGroupInfo;
        public ShareCallBackType shareCallbackType = ShareCallBackType.Normal;
        public WXGroupCallBackType wxGroupCallbackType = WXGroupCallBackType.Guild;

        public void HandleExData(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]HandleExData msg" + msg);
            switch (this.GetApiId(msg))
            {
                case 1:
                    this.SerialPlayerInfo(msg);
                    break;
                case 2:
                    this.SerialFriendsInfo(msg);
                    break;
                case 6:
                    this.SerialGuildGroupResult(msg);
                    break;
                case 7:
                    this.SerialGuildGroupInfo(msg);
                    break;
                case 8:
                    this.SerialGuildGroupResult(msg);
                    break;
                case 9:
                    this.SerialShareResult(msg);
                    break;
                case 12:
                    this.SerialHandleReplay(msg);
                    break;
                case 16:
                    this.SerialQQVipPayInfo(msg);
                    break;
                case 17:
                    this.SerialPaySubscribeInfo(msg);
                    break;
                case 18:
                    this.SerialMarketingInfo(msg);
                    break;
                case 19:
                    this.SerialGameCenterLaunch(msg);
                    break;
                case 20:
                    this.SerialHandle3DTouch(msg);
                    break;
                case 21:
                    this.SerialHandleScreenLock(msg);
                    break;
                case 22:
                    this.SerialBuyGoodsInfo(msg);
                    break;
                case 23:
                    this.SerialPandoraSDKBuyGoodsInfo(msg);
                    break;
            }
        }

        private int GetApiId(string msg)
        {
            Dictionary<string, object> dictionary = Json.Deserialize(msg) as Dictionary<string, object>;
            int result = 1;
            int.TryParse(dictionary["apiId"].ToString(), out result);
            return result;
        }

        public void SerialPlayerInfo(string msg) => this.playerInfo = XSingleton<PUtil>.singleton.Deserialize<PlayerInfo>(msg);

        public void SerialFriendsInfo(string msg)
        {
            this.friendsInfo = XSingleton<PUtil>.singleton.Deserialize<FriendInfo>(msg);
            IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
            if (uiUtility == null)
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialFriendsInfo entrance == null");
            else
                uiUtility.OnGetPlatFriendsInfo();
        }

        public void SerialGuildGroupResult(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupResult msg" + msg);
            WXGroupResult wxGroupResult = XSingleton<PUtil>.singleton.Deserialize<WXGroupResult>(msg);
            if (wxGroupResult == null)
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupResult wxGroupResult == null");
            }
            else
            {
                IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
                if (uiUtility == null)
                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupResult entrance == null");
                else
                    uiUtility.OnWXGroupResult(wxGroupResult.apiId.ToString(), wxGroupResult.data.flag, wxGroupResult.data.errorCode, this.wxGroupCallbackType);
            }
        }

        public void SerialGuildGroupInfo(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupInfo msg" + msg);
            this.wxGroupInfo = XSingleton<PUtil>.singleton.Deserialize<WXGroupInfo>(msg);
            if (this.wxGroupInfo == null)
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupInfo wxGroupInfo == null");
            }
            else
            {
                IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
                if (uiUtility == null)
                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGuildGroupInfo entrance == null");
                else
                    uiUtility.RefreshWXGroupBtn(this.wxGroupCallbackType);
            }
        }

        public void SerialShareResult(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialShareResult msg" + msg);
            if (!(Json.Deserialize(msg) is Dictionary<string, object> dictionary))
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialShareResult dict == null");
            }
            else
            {
                object obj = (object)null;
                if (dictionary.TryGetValue("data", out obj))
                    XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"))?.NoticeShareResult(obj.ToString(), this.shareCallbackType);
                this.shareCallbackType = ShareCallBackType.Normal;
            }
        }

        public void SerialQQVipPayInfo(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialQQVipPayInfo msg" + msg);
            if (!(Json.Deserialize(msg) is Dictionary<string, object> dictionary))
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialQQVipPayInfo dict == null");
            }
            else
            {
                IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
                object obj1;
                object obj2;
                if (!dictionary.TryGetValue("data", out obj1) || !(obj1 as Dictionary<string, object>).TryGetValue("flag", out obj2) || uiUtility == null)
                    return;
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialQQVipPayInfo result =" + obj2.ToString());
                uiUtility.OnQQVipPayCallback(obj2.ToString());
            }
        }

        private void SerialGameCenterLaunch(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGameCenterLaunch msg" + msg);
            if (!(Json.Deserialize(msg) is Dictionary<string, object> dictionary1))
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialGameCenterLaunch dict == null");
            }
            else
            {
                IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
                object obj1;
                if (!dictionary1.TryGetValue("data", out obj1) || uiUtility == null)
                    return;
                Dictionary<string, object> dictionary = obj1 as Dictionary<string, object>;
                object obj2 = (object)null;
                if (dictionary != null && dictionary.TryGetValue("wakeup_platform", out obj2))
                {
                    XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] platform: " + obj2.ToString());
                    if ((long)obj2 == 1L)
                    {
                        XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] platform == 1");
                        object obj3 = (object)null;
                        if (dictionary.TryGetValue("wakeup_wx_extInfo", out obj3) && obj3.ToString() == "WX_GameCenter")
                        {
                            uiUtility.OnGameCenterWakeUp(3);
                            XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] StartUpType.StartUp_WX");
                        }
                    }
                    else if ((long)obj2 == 2L)
                    {
                        XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] platform == 2");
                        object obj4 = (object)null;
                        if (dictionary.TryGetValue("wakeup_qq_extInfo", out obj4) && obj4.ToString() == "sq_gamecenter")
                        {
                            uiUtility.OnGameCenterWakeUp(2);
                            XSingleton<XDebug>.singleton.AddLog("[SerialGameCenterLaunch] StartUpType.StartUp_QQ");
                        }
                    }
                }
            }
        }

        private void SerialHandle3DTouch(string msg) => XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"))?.SerialHandle3DTouch(msg);

        private void SerialHandleScreenLock(string msg) => XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"))?.SerialHandleScreenLock(msg);

        private void SerialMarketingInfo(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo msg" + msg);
            if (!(Json.Deserialize(msg) is Dictionary<string, object> dictionary3))
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo dict == null");
            }
            else
            {
                IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
                object obj1;
                if (!dictionary3.TryGetValue("data", out obj1) || uiUtility == null)
                    return;
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo data");
                object obj2;
                if (obj1 is Dictionary<string, object> dictionary4 && dictionary4.TryGetValue("flag", out obj2))
                {
                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo flag");
                    object obj3;
                    if (obj2.ToString() == "Success" && dictionary4 != null && dictionary4.TryGetValue("mpinfo", out obj3))
                    {
                        XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo mpinfo");
                        if (obj3 is List<object> objectList6)
                        {
                            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo array != null");
                            List<PayMarketingInfo> listInfo = new List<PayMarketingInfo>();
                            for (int index = 0; index < objectList6.Count; ++index)
                            {
                                Dictionary<string, object> dictionary = objectList6[index] as Dictionary<string, object>;
                                PayMarketingInfo payMarketingInfo = new PayMarketingInfo();
                                object obj4;
                                if (dictionary != null && dictionary.TryGetValue("num", out obj4))
                                {
                                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo num = " + obj4.ToString());
                                    payMarketingInfo.diamondCount = int.Parse(obj4.ToString());
                                }
                                object obj5;
                                if (dictionary != null && dictionary.TryGetValue("send_num", out obj5))
                                {
                                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo send_num = " + obj5.ToString());
                                    payMarketingInfo.sendCount = int.Parse(obj5.ToString());
                                }
                                object obj6;
                                if (dictionary != null && dictionary.TryGetValue("send_ext", out obj6))
                                {
                                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialMarketingInfo send_ext = " + obj6.ToString());
                                    payMarketingInfo.sendExt = obj6.ToString();
                                }
                                listInfo.Add(payMarketingInfo);
                            }
                            uiUtility.OnPayMarketingInfo(listInfo);
                        }
                    }
                }
            }
        }

        private void SerialPaySubscribeInfo(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialPaySubscribeInfo msg" + msg);
            if (!(Json.Deserialize(msg) is Dictionary<string, object> dictionary2))
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialPaySubscribeInfo dict == null");
            }
            else
            {
                IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
                object obj1;
                object obj2;
                if (dictionary2.TryGetValue("data", out obj1) && obj1 is Dictionary<string, object> dictionary3 && dictionary3.TryGetValue("flag", out obj2) && uiUtility != null)
                {
                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialPaySubscribeInfo result =" + obj2.ToString());
                    uiUtility.OnPayCallback(obj2.ToString());
                }
                else
                    uiUtility?.OnPayCallback("Failure");
            }
        }

        private void SerialBuyGoodsInfo(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialBuyGoodsInfo msg" + msg);
            if (!(Json.Deserialize(msg) is Dictionary<string, object> dictionary2))
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialBuyGoodsInfo dict == null");
            }
            else
            {
                IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
                object obj1;
                object obj2;
                if (dictionary2.TryGetValue("data", out obj1) && obj1 is Dictionary<string, object> dictionary3 && dictionary3.TryGetValue("flag", out obj2) && uiUtility != null)
                {
                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialBuyGoodsInfo result =" + obj2.ToString());
                    uiUtility.OnPayCallback(obj2.ToString());
                }
                else
                    uiUtility?.OnPayCallback("Failure");
            }
        }

        private void SerialPandoraSDKBuyGoodsInfo(string msg)
        {
            XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialPandoraSDKBuyGoodsInfo msg" + msg);
            if (!(Json.Deserialize(msg) is Dictionary<string, object> dictionary2))
            {
                XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialPandoraSDKBuyGoodsInfo dict == null");
            }
            else
            {
                IUiUtility uiUtility = XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"));
                object obj1;
                object obj2;
                if (dictionary2.TryGetValue("data", out obj1) && obj1 is Dictionary<string, object> dictionary3 && dictionary3.TryGetValue("flag", out obj2) && uiUtility != null)
                {
                    XSingleton<XDebug>.singleton.AddLog("[PDatabase]SerialBuyGoodsInfo result =" + obj2.ToString());
                    uiUtility.OnPayCallback(obj2.ToString());
                }
                else
                    uiUtility?.OnPayCallback("Failure");
            }
        }

        private void SerialHandleReplay(string msg) => XSingleton<XInterfaceMgr>.singleton.GetInterface<IUiUtility>(XSingleton<XCommon>.singleton.XHash("IUiUtility"))?.OnReplayStart();
    }
}
