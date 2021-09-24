

using KKSG;
using MiniJSON;
using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XPandoraSDKDocument : XSingleton<XPandoraSDKDocument>
    {
        private bool hasLogin = false;

        public void PandoraLogin()
        {
            XSingleton<XDebug>.singleton.AddLog("XPandoraMgr try login");
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK))
                return;
            if (XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("XPandoraMgr Component missing");
            }
            else
            {
                if (XSingleton<XAttributeMgr>.singleton.XPlayerData == null)
                    return;
                int use = XSingleton<XGlobalConfig>.singleton.GetInt("PandoraSDKUseHttps");
                XSingleton<XDebug>.singleton.AddLog("XPandoraMgr https = " + (object)use);
                XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.SetUseHttps(use);
                XSingleton<XDebug>.singleton.AddGreenLog("PandoraLogin--------------------------------------------");
                string acctype = "test";
                if (XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LOGIN_QQ_PF)
                    acctype = "qq";
                else if (XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LGOIN_WECHAT_PF)
                    acctype = "wx";
                string payToken = "test";
                string payBill = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetPayBill();
                object obj;
                if (payBill != "" && Json.Deserialize(payBill) is Dictionary<string, object> dictionary2 && dictionary2.TryGetValue("pay_token", out obj))
                    payToken = obj.ToString();
                string platID = "";
                if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.Android)
                    platID = "1";
                else if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.IOS)
                    platID = "0";
                XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.PandoraLogin(XSingleton<XLoginDocument>.singleton.OpenID, acctype, XSingleton<XClientNetwork>.singleton.AreaId, XSingleton<XClientNetwork>.singleton.ServerID.ToString(), XSingleton<XClientNetwork>.singleton.AppId, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID.ToString(), XSingleton<XLoginDocument>.singleton.TokenCache, payToken, XSingleton<XUpdater.XUpdater>.singleton.Version, platID);
                this.hasLogin = true;
            }
        }

        public void PandoraLogout()
        {
            XSingleton<XDebug>.singleton.AddLog(nameof(PandoraLogout));
            if (!this.hasLogin || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return;
            XSingleton<XDebug>.singleton.AddGreenLog("PandoraLogout--------------------------------------------");
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.PandoraLogout();
            this.hasLogin = false;
        }

        public void CheckPandoraPLPanel()
        {
            XSingleton<XDebug>.singleton.AddLog("PandoraSDK CheckPandoraPLPanel");
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null || XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HALL || !this.hasLogin)
                return;
            XSingleton<XDebug>.singleton.AddGreenLog("PandoraSDK CheckPandoraPLPanel ---------------------------");
            this.ResetAllPopPLParent();
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.PopPLPanel();
        }

        public void ResetAllPopPLParent()
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null || !this.hasLogin)
                return;
            DlgBase<XPandoraSDKPopView, XPandoraSDKPopViewBehaviour>.singleton.SetVisible(true, true);
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.SetPandoraPanelParent("pop", DlgBase<XPandoraSDKPopView, XPandoraSDKPopViewBehaviour>.singleton.uiBehaviour.gameObject);
            DlgBase<XPandoraSDKPopView, XPandoraSDKPopViewBehaviour>.singleton.SetVisible(false, true);
        }

        public void NoticePandoraShareResult(string result)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return;
            XSingleton<XDebug>.singleton.AddLog("NoticePandoraShareResult result = " + result);
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.NoticePandoraShareResult(result);
        }

        public void NoticePandoraBuyGoodsResult(string result)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return;
            XSingleton<XDebug>.singleton.AddLog("NoticePandoraBuyGoodsResult result = " + result);
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.NoticePandoraBuyGoodsResult(result);
        }

        public void CloseAllPandoraPanel()
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return;
            XSingleton<XDebug>.singleton.AddLog("Pandora CloseAllPandoraPanel");
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.CloseAllPandoraPanel();
        }

        public void ClosePandoraTabPanel(string module)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return;
            XSingleton<XDebug>.singleton.AddLog("Pandora ClosePandoraTabPanel");
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.ClosePandoraTabPanel(module);
        }

        public bool IsActivityTabShow(int sysID)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return false;
            XSingleton<XDebug>.singleton.AddLog("IsActivityTabShow sysID = " + (object)sysID);
            return XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.IsActivityTabShow(sysID);
        }

        public bool IsPandoraSDKTab(XSysDefine sys, string module)
        {
            List<ActivityTabInfo> pandoraSdkTabListInfo = XSingleton<XPandoraSDKDocument>.singleton.GetPandoraSDKTabListInfo(module);
            if (pandoraSdkTabListInfo != null)
            {
                for (int index = 0; index < pandoraSdkTabListInfo.Count; ++index)
                {
                    if ((XSysDefine)pandoraSdkTabListInfo[index].sysID == sys)
                        return true;
                }
            }
            return false;
        }

        public List<ActivityTabInfo> GetPandoraSDKTabListInfo(string module)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return (List<ActivityTabInfo>)null;
            List<ActivityTabInfo> resultList = new List<ActivityTabInfo>();
            List<ActivityTabInfo> allTabInfo = XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.GetAllTabInfo();
            for (int index = 0; index < allTabInfo.Count; ++index)
            {
                if (allTabInfo[index].moduleName == module)
                {
                    XSingleton<XDebug>.singleton.AddLog("GetPandoraSDKTabInfo find moduleName = " + module);
                    resultList.Add(allTabInfo[index]);
                }
            }
            return this.SortPandoraTab(resultList);
        }

        public static int ComparePandoraSDKTab(ActivityTabInfo tab1, ActivityTabInfo tab2) => tab1.sort - tab2.sort;

        public List<ActivityTabInfo> SortPandoraTab(List<ActivityTabInfo> resultList)
        {
            List<ActivityTabInfo> activityTabInfoList = new List<ActivityTabInfo>();
            int index = 0;
            while (index < resultList.Count)
            {
                if (resultList[index].sort != 999)
                {
                    activityTabInfoList.Add(resultList[index]);
                    resultList.RemoveAt(index);
                }
                else
                    ++index;
            }
            activityTabInfoList.Sort(new Comparison<ActivityTabInfo>(XPandoraSDKDocument.ComparePandoraSDKTab));
            activityTabInfoList.AddRange((IEnumerable<ActivityTabInfo>)resultList);
            return activityTabInfoList;
        }

        public void ShowPandoraTab(int sysID, bool show, GameObject parent)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return;
            ActivityTabInfo pandoraSdkTabInfo = this.GetPandoraSDKTabInfo(sysID);
            if (pandoraSdkTabInfo == null)
                return;
            if (show)
                this.ResetAllPopPLParent();
            if (show)
                XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.SetPandoraPanelParent(pandoraSdkTabInfo.moduleName, parent);
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.PandoraDoJson(Json.Serialize((object)new Dictionary<string, string>()
            {
                ["type"] = (show ? "open" : "hide"),
                ["content"] = pandoraSdkTabInfo.activityName
            }));
        }

        public ActivityTabInfo GetPandoraSDKTabInfo(int sysID)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return (ActivityTabInfo)null;
            XSingleton<XDebug>.singleton.AddLog("GetPandoraSDKTabInfo sysID = " + (object)sysID);
            List<ActivityTabInfo> allTabInfo = XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.GetAllTabInfo();
            for (int index = 0; index < allTabInfo.Count; ++index)
            {
                if (allTabInfo[index].sysID == sysID)
                {
                    XSingleton<XDebug>.singleton.AddLog("GetPandoraSDKTabInfo find tabName = " + (object)sysID);
                    return allTabInfo[index];
                }
            }
            return (ActivityTabInfo)null;
        }

        public bool HasRedpoint(string module)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return false;
            List<ActivityTabInfo> allTabInfo = XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.GetAllTabInfo();
            for (int index = 0; index < allTabInfo.Count; ++index)
            {
                if (allTabInfo[index].moduleName == module && allTabInfo[index].tabShow && allTabInfo[index].redPointShow)
                    return true;
            }
            return false;
        }

        public void PandoraDoJson(string json)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return;
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.PandoraDoJson(json);
        }

        public void PandoraOnJsonEvent(string json)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null)
                return;
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.OnJsonPandoraEvent(json);
        }

        public void SetLastFailSceneID(uint id)
        {
            if (!XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_PandoraSDK) || XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager == null || !XSingleton<XGlobalConfig>.singleton.GetIntList("PandoraSDKCheckFailSceneType").Contains(XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XSceneMgr>.singleton.GetSceneType(id))))
                return;
            XSingleton<XUpdater.XUpdater>.singleton.XPandoraManager.PopPreLossActivity(true);
        }
    }
}
