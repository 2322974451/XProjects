

using KKSG;
using MiniJSON;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class GameCommunityHandler : DlgHandlerBase
    {
        private XMainInterfaceDocument _doc = (XMainInterfaceDocument)null;
        private int _bgWidthDelta;
        private bool _widthInit = false;
        public IXUISprite m_Bg;
        public Transform m_SystemParent;

        protected override string FileName => "GameSystem/GameCommunityDlg";

        protected override void Init()
        {
            base.Init();
            this._doc = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
            this.m_Bg = this.transform.Find("Bg/Bg").GetComponent("XUISprite") as IXUISprite;
            this.m_SystemParent = this.transform.Find("Bg/Sys");
            XSingleton<XChatIFlyMgr>.singleton.RefreshWebViewConfig();
        }

        protected override void OnShow()
        {
            base.OnShow();
            bool flag1 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
            int num1 = 0;
            int num2 = 0;
            for (int index = 0; index < this._doc.GameCommunityReader.Table.Length; ++index)
            {
                GameCommunityTable.RowData data = this._doc.GameCommunityReader.Table[index];
                IXUIButton component = this.m_SystemParent.Find(data.ButtonName).GetComponent("XUIButton") as IXUIButton;
                component.SetVisible(false);
                GameObject gameObject = component.gameObject.transform.Find("RedPoint").gameObject;
                if (index == 0)
                {
                    num2 = component.spriteWidth;
                    if (!this._widthInit)
                    {
                        this._widthInit = true;
                        this._bgWidthDelta = this.m_Bg.spriteWidth - num2;
                    }
                }
                if ((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (long)data.OpenLevel && XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)data.SysID) && this.LoginStateTrue(data))
                {
                    if (data.ID == 13)
                    {
                        if (this.IsSuportReplay())
                        {
                            component.SetVisible(true);
                            component.gameObject.transform.localPosition = new Vector3((float)(num1 * num2), 0.0f);
                            component.ID = (ulong)data.ID;
                            component.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSysBtnClick));
                            ++num1;
                        }
                    }
                    else if (data.ID == 12)
                    {
                        if (this.GetQuestionnaireStage() != 0)
                        {
                            component.SetVisible(true);
                            component.gameObject.transform.localPosition = new Vector3((float)(num1 * num2), 0.0f);
                            component.ID = (ulong)data.ID;
                            component.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSysBtnClick));
                            ++num1;
                            gameObject.SetActive(XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Questionnaire));
                        }
                    }
                    else if (data.ID == 14)
                    {
                        XSingleton<XDebug>.singleton.AddLog("Is show tv: ", this._doc.ShowWebView.ToString());
                        bool flag2 = SystemInfo.processorType.StartsWith("Intel");
                        int num3 = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HideWebView"));
                        bool flag3 = SystemInfo.systemMemorySize >= XSingleton<XGlobalConfig>.singleton.GetInt("WebMemory");
                        XSingleton<XDebug>.singleton.AddLog("memory: ", flag3.ToString(), " x86: ", flag2.ToString(), " hide: ", num3.ToString());
                        bool bVisible = ((!this._doc.ShowWebView || num3 == 1 ? 0 : (!flag2 ? 1 : 0)) & (flag3 ? 1 : 0)) != 0;
                        component.SetVisible(bVisible);
                        if (bVisible)
                        {
                            component.gameObject.transform.localPosition = new Vector3((float)(num1 * num2), 0.0f);
                            component.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSysBtnClick));
                            ++num1;
                            component.ID = (ulong)data.ID;
                        }
                    }
                    else if ((data.ID != 8 || XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_QQ && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ) && (data.ID != 9 || XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo() == StartUpType.StartUp_WX && XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat))
                    {
                        component.SetVisible(true);
                        component.gameObject.transform.localPosition = new Vector3((float)(num1 * num2), 0.0f);
                        component.ID = (ulong)data.ID;
                        component.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSysBtnClick));
                        ++num1;
                        gameObject.SetActive(XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock((XSysDefine)data.SysID));
                    }
                }
            }
            this.m_Bg.spriteWidth = this._bgWidthDelta + num1 * num2;
        }

        private bool OnSysBtnClick(IXUIButton btn)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            long num = (long)btn.ID - 1L;
            if ((ulong)num <= 15UL)
            {
                switch ((uint)num)
                {
                    case 0:
                        XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_CloseHintNtf()
                        {
                            Data = {
                systemid = (uint) XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GC_XinYueVIP)
              }
                        });
                        XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GC_XinYueVIP, false);
                        XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GameCommunity);
                        btn.gameObject.transform.Find("RedPoint").gameObject.SetActive(false);
                        string str1 = string.Format("{0}?game_id={1}&opencode={2}&partition_id={3}&role_id={4}", (object)XSingleton<XGlobalConfig>.singleton.GetValue("XinYueInternalURL"), (object)XSingleton<XClientNetwork>.singleton.GameId, (object)XSingleton<XClientNetwork>.singleton.OpenCode, (object)XSingleton<XClientNetwork>.singleton.ServerID, (object)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
                        XSingleton<XDebug>.singleton.AddLog("url = " + str1);
                        dictionary["url"] = str1;
                        dictionary["screendir"] = "SENSOR";
                        XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                        break;
                    case 6:
                        XSingleton<UiUtility>.singleton.OpenHtmlUrl("DeepLinkAddress");
                        break;
                    case 7:
                    case 8:
                        DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XQQWXGameCenterPrivilegeView, XQQWXGameCenterPrivilegeBehaviour>.OnAnimationOver)null);
                        break;
                    case 9:
                        string str2 = string.Format("{0}?partition={1}&roleid={2}&area={3}&algorithm={4}&version={5}&timestamp={6}&appid={7}&openid={8}&sig={9}&encode={10}", (object)XSingleton<XGlobalConfig>.singleton.GetValue("MicroCommunityURL"), (object)XSingleton<XClientNetwork>.singleton.ServerID, (object)XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, (object)XSingleton<XClientNetwork>.singleton.AreaId, (object)"v2", (object)XSingleton<XUpdater.XUpdater>.singleton.Version, (object)XSingleton<UiUtility>.singleton.GetTimeStamp(), (object)XSingleton<XClientNetwork>.singleton.AppId, (object)XSingleton<XLoginDocument>.singleton.OpenID, (object)XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetMD5(string.Format("{0}{1}", (object)XSingleton<XClientNetwork>.singleton.MSDKKey, (object)XSingleton<UiUtility>.singleton.GetTimeStamp())), (object)"2");
                        XSingleton<XDebug>.singleton.AddLog("url = " + str2);
                        dictionary["url"] = str2;
                        dictionary["screendir"] = "SENSOR";
                        XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                        break;
                    case 10:
                        XSingleton<UiUtility>.singleton.OpenHtmlUrl("HordeInsideAddress");
                        break;
                    case 11:
                        XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_CancelRedDotReq()
                        {
                            Data = {
                systemid = (uint) XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Questionnaire)
              }
                        });
                        XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Questionnaire, false);
                        XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GameCommunity);
                        btn.gameObject.transform.Find("RedPoint").gameObject.SetActive(false);
                        int questionnaireStage = this.GetQuestionnaireStage();
                        dictionary["url"] = XSingleton<XGlobalConfig>.singleton.GetValue(string.Format("QuestionnaireUrl{0}", (object)questionnaireStage));
                        dictionary["screendir"] = "SENSOR";
                        XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                        break;
                    case 12:
                        this.OnReplayClick(btn);
                        break;
                    case 13:
                        DlgBase<WebView, WebViewBehaviour>.singleton.SetVisible(true, true);
                        break;
                    case 14:
                        XSingleton<UiUtility>.singleton.CloseSysAndNoticeServer((uint)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GC_XiaoYueGuanJia));
                        btn.gameObject.transform.Find("RedPoint").gameObject.SetActive(false);
                        string str3 = Application.platform == RuntimePlatform.Android ? "1" : "0";
                        string str4 = string.Format("{0}?game_id={1}&opencode={2}&sig={3}&timestamp={4}&role_id={5}&partition_id={6}&plat_id={7}", (object)XSingleton<XGlobalConfig>.singleton.GetValue("XiaoYueUrl"), (object)XSingleton<XGlobalConfig>.singleton.GetValue("XiaoYueGameID"), (object)XSingleton<XClientNetwork>.singleton.OpenCode, (object)XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetMD5(string.Format("{0}{1}", (object)XSingleton<XClientNetwork>.singleton.MSDKKey, (object)XSingleton<UiUtility>.singleton.GetTimeStamp())), (object)XSingleton<UiUtility>.singleton.GetTimeStamp(), (object)XSingleton<UiUtility>.singleton.GetRoleId(), (object)XSingleton<XClientNetwork>.singleton.ServerID, (object)str3);
                        XSingleton<XDebug>.singleton.AddLog("url = " + str4);
                        dictionary["url"] = str4;
                        dictionary["screendir"] = "SENSOR";
                        XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                        break;
                    case 15:
                        XSingleton<UiUtility>.singleton.OpenHtmlUrl("LibaozhongxinUrl");
                        break;
                }
            }
            return true;
        }

        private bool LoginStateTrue(GameCommunityTable.RowData data)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
                return true;
            switch (XSingleton<XLoginDocument>.singleton.Channel)
            {
                case XAuthorizationChannel.XAuthorization_QQ:
                    return data.QQ;
                case XAuthorizationChannel.XAuthorization_WeChat:
                    return data.WX;
                case XAuthorizationChannel.XAuthorization_Guest:
                    return data.YK;
                default:
                    return false;
            }
        }

        public bool IsSuportReplay() => Application.platform == RuntimePlatform.IPhonePlayer && !this.isIpadMode() && XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("is_screen_record_available", "");

        private bool isIpadMode() => false;

        private bool OnReplayClick(IXUIButton btn)
        {
            if (DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.isPlaying || DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.isReadyPlaying)
            {
                XSingleton<XDebug>.singleton.AddLog("Close Replay..");
                DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.OnStopClick((IXUIButton)null);
            }
            else if (DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.isBroadcast)
            {
                XSingleton<XDebug>.singleton.AddLog("replay isBroadcasting");
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Replay_IsBroadcasting"), "fece00");
            }
            else
            {
                bool flag = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("is_broadcasting", "");
                XSingleton<XDebug>.singleton.AddLog("open: ", flag.ToString());
                if (!flag)
                    DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.OpenRepaly();
                else if (Application.platform == RuntimePlatform.WindowsEditor)
                    DlgBase<ReplaykitDlg, ReplayBehaviour>.singleton.Show(true);
            }
            return true;
        }

        private int GetQuestionnaireStage()
        {
            uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
            SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("QuestionnaireLevel", true);
            for (int index = 0; index < (int)sequenceList.Count; ++index)
            {
                if ((long)level >= (long)sequenceList[index, 0] && (long)level <= (long)sequenceList[index, 1])
                    return index + 1;
            }
            return 0;
        }
    }
}
