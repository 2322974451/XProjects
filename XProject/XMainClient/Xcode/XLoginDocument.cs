

using KKSG;
using MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XLoginDocument : XSingleton<XLoginDocument>
    {
        private static readonly byte _seed = 148;
        private static readonly float _delay_notice_threshold = 0.5f;
        private static readonly float _max_delay_notice_threshold = 10f;
        private static readonly float _max_notice_threshold = 5f;
        private XAuthorizationChannel _channel = XAuthorizationChannel.XAuthorization_Max;
        private XLoginView _view = (XLoginView)null;
        private PlatNotice _announcement = (PlatNotice)null;
        private bool _sdk_sign_out = false;
        private bool _after_login_announcement = false;
        private bool _notification = false;
        private bool _authorized = false;
        private bool _auto_authorization = false;
        private string _account = (string)null;
        private string _pwd = (string)null;
        private string __openid = (string)null;
        private uint _login_zoneid = 0;
        private bool _freeflow;
        private int _cctype;
        private string _token_cache = (string)null;
        private bool _fetch_delay = false;
        private bool _fetching_token = false;
        private float _last_fetch_at = 0.0f;
        private bool _authorized_from_login_stage = false;
        private bool _login_delay = false;
        private bool _logining = false;
        private float _last_login_at = 0.0f;
        private bool _in_server_queue = false;
        private float enterWorldTime = 0.0f;
        private List<string> _zone_list = new List<string>();
        private Dictionary<string, List<int>> _server_category = new Dictionary<string, List<int>>();
        private Dictionary<int, ServerInfo> _server_dic = new Dictionary<int, ServerInfo>();
        private List<ServerInfo> _backFlowServerList = new List<ServerInfo>();
        public Dictionary<string, FriendServerInfo> FriendServerDic = new Dictionary<string, FriendServerInfo>();
        public List<string> FriendOpenid = new List<string>();
        private uint _role_count_inqueue = 0;
        private uint _left_time_inqueue = 0;
        private LoginReconnectInfo _login_reconnect_info = (LoginReconnectInfo)null;
        private uint _query_queue_token = 0;
        private float[] lastLoginTime = new float[2];
        private StartUpType _LaunchTypeServer = StartUpType.StartUp_Normal;

        public XLoginView View
        {
            get => this._view;
            set => this._view = value;
        }

        public PlatNotice Announcement => this._announcement;

        public bool SDKSignOut
        {
            get => this._sdk_sign_out;
            set => this._sdk_sign_out = value;
        }

        private string _openid
        {
            get => this.__openid;
            set
            {
                this.__openid = value;
                XFileLog.OpenID = value;
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SetApmUserID(value);
            }
        }

        public uint LoginZoneID => this._login_zoneid;

        public bool freeflow => this._freeflow;

        public int cctype => this._cctype;

        private float FetchingElapsed => Time.realtimeSinceStartup - this._last_fetch_at;

        private float LoginingElapsed => Time.realtimeSinceStartup - this._last_login_at;

        public string Account => this._account;

        public string Password => this._pwd;

        public string OpenID => this._openid;

        public XAuthorizationChannel Channel => this._channel;

        public string TokenCache => this._token_cache;

        public bool FetchTokenDelay => this._fetch_delay;

        public bool LoginDelay => this._login_delay;

        public bool Authorized => this._authorized;

        public List<string> ZoneList => this._zone_list;

        public Dictionary<string, List<int>> ServerCategory => this._server_category;

        public uint RoleCountInQueue => this._role_count_inqueue;

        public uint LeftTimeInQueue => this._left_time_inqueue;

        public List<ServerInfo> BackFlowServerList => this._backFlowServerList;

        private void ResetAccoutInfo()
        {
            this._sdk_sign_out = false;
            this._account = (string)null;
            this._pwd = (string)null;
            this._openid = (string)null;
            this._token_cache = (string)null;
        }

        public void SetChannelByWakeUp()
        {
            switch (this.GetWakeUpType())
            {
                case StartUpType.StartUp_QQ:
                    this._channel = XAuthorizationChannel.XAuthorization_QQ;
                    break;
                case StartUpType.StartUp_WX:
                    this._channel = XAuthorizationChannel.XAuthorization_WeChat;
                    break;
            }
        }

        private void SetChannelByLaunchType()
        {
            switch (this.GetLaunchType())
            {
                case StartUpType.StartUp_QQ:
                    this._channel = XAuthorizationChannel.XAuthorization_QQ;
                    break;
                case StartUpType.StartUp_WX:
                    this._channel = XAuthorizationChannel.XAuthorization_WeChat;
                    break;
            }
        }

        public void LoadAccount()
        {
            string path = Application.persistentDataPath + "/account.txt";
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                path = Application.dataPath + "/account.txt";
            if (!File.Exists(path))
            {
                this.SetChannelByLaunchType();
            }
            else
            {
                string[] strArray = this.XCryptography(File.ReadAllBytes(path)).Split((char[])null);
                int result = 0;
                if (int.TryParse(strArray[0], out result) && result > 0 && result < XFastEnumIntEqualityComparer<XAuthorizationChannel>.ToInt(XAuthorizationChannel.XAuthorization_Max))
                {
                    this._channel = (XAuthorizationChannel)result;
                    this.SetChannelByLaunchType();
                    switch (this._channel)
                    {
                        case XAuthorizationChannel.XAuthorization_Internal:
                            if (strArray.Length != 3)
                                break;
                            this._account = strArray[1];
                            this._pwd = strArray[2];
                            break;
                    }
                }
                else
                    this.SetChannelByLaunchType();
            }
        }

        public void DelAccount()
        {
            string path = Application.persistentDataPath + "/account.txt";
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                path = Application.dataPath + "/account.txt";
            try
            {
                if (!File.Exists(path))
                    return;
                File.Delete(path);
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Delete account file failed " + ex.Message);
            }
        }

        public void AutoAuthorization(bool fromLoginStage) => this.Authorization(this._channel, fromLoginStage, true, this._account, this._pwd);

        public bool CheckLoginBlockTime() => (double)Time.time - (double)this.lastLoginTime[1] > (double)XSingleton<XGlobalConfig>.singleton.LoginBlockTime;

        public void Authorization(
          XAuthorizationChannel channel,
          bool fromLoginStage,
          bool auto = false,
          string account = null,
          string pwd = null)
        {
            this.lastLoginTime[1] = this.lastLoginTime[0];
            this.lastLoginTime[0] = Time.time;
            this.SetBlockUIVisable(true);
            this._authorized = false;
            this._auto_authorization = auto;
            this._authorized_from_login_stage = fromLoginStage;
            this._fetching_token = true;
            this._last_fetch_at = Time.realtimeSinceStartup;
            switch (channel)
            {
                case XAuthorizationChannel.XAuthorization_Internal:
                    this._channel = channel;
                    this.InternalAuthorization(account, pwd);
                    break;
                case XAuthorizationChannel.XAuthorization_SD:
                    this._channel = channel;
                    this.PlatformAuthorization();
                    break;
                case XAuthorizationChannel.XAuthorization_QQ:
                    this._channel = channel;
                    this.QQAuthorization(auto);
                    break;
                case XAuthorizationChannel.XAuthorization_WeChat:
                    this._channel = channel;
                    this.WeChatAuthorization(auto);
                    break;
                case XAuthorizationChannel.XAuthorization_Guest:
                    this._channel = channel;
                    this.GuestAuthorization(auto);
                    break;
                default:
                    this._fetching_token = false;
                    break;
            }
        }

        public void ShowAfterLoginAnnouncement()
        {
            if (this._after_login_announcement)
                return;
            XSingleton<UiUtility>.singleton.ShowAfterLoginAnnouncement(this._announcement);
            this._after_login_announcement = true;
        }

        public void OnError(string notify)
        {
            XSingleton<XPandoraSDKDocument>.singleton.PandoraLogout();
            this._fetching_token = false;
            this._authorized = false;
            this._logining = false;
            this._in_server_queue = false;
            if (this._channel != XAuthorizationChannel.XAuthorization_Internal && this._channel != XAuthorizationChannel.XAuthorization_Max)
                this.ResetAccoutInfo();
            if (!string.IsNullOrEmpty(notify))
                XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), (object)notify));
            this.FromBegining();
        }

        public void OnError()
        {
            this._fetching_token = false;
            this._authorized = false;
            this._logining = false;
            this._in_server_queue = false;
        }

        public void FromBegining()
        {
            XSingleton<XClientNetwork>.singleton.ClearServerInfo();
            this.SetBlockUIVisable(false);
            if (this._authorized_from_login_stage)
                XSingleton<XLoginDocument>.singleton.ShowLoginUI();
            else
                this.BackToBegin();
            this._after_login_announcement = false;
            this._authorized_from_login_stage = false;
        }

        public void FromLogining()
        {
            this.SetBlockUIVisable(false);
            if (this._authorized_from_login_stage)
                XSingleton<XLoginDocument>.singleton.ShowLoginSelectServerUI();
            else
                this.BackToLogin();
            this._authorized_from_login_stage = false;
        }

        public void RefreshAccessToken(string token)
        {
            this._token_cache = token;
            XSingleton<XDebug>.singleton.AddLog("AccessToken : ", this._token_cache);
        }

        public void OnAuthorization(
          string account,
          string pwd,
          string openid,
          XAuthorizationChannel channel)
        {
            this._fetching_token = false;
            this._account = account;
            this._pwd = pwd;
            this._openid = openid;
            this._channel = channel;
            this._token_cache = account;
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(openid))
            {
                this.OnAuthorizedFailed();
            }
            else
            {
                switch (channel)
                {
                    case XAuthorizationChannel.XAuthorization_Internal:
                        XSingleton<XClientNetwork>.singleton.Authorization(LoginType.LOGIN_PASSWORD, account, pwd, openid);
                        break;
                    case XAuthorizationChannel.XAuthorization_SD:
                        XSingleton<XClientNetwork>.singleton.Authorization(LoginType.LOGIN_SNDA_PF, account, pwd, openid);
                        break;
                    case XAuthorizationChannel.XAuthorization_QQ:
                        XSingleton<XClientNetwork>.singleton.Authorization(LoginType.LOGIN_QQ_PF, account, pwd, openid);
                        break;
                    case XAuthorizationChannel.XAuthorization_WeChat:
                        XSingleton<XClientNetwork>.singleton.Authorization(LoginType.LGOIN_WECHAT_PF, account, pwd, openid);
                        break;
                    case XAuthorizationChannel.XAuthorization_Guest:
                        XSingleton<XClientNetwork>.singleton.Authorization(LoginType.LOGIN_IOS_GUEST, account, pwd, openid);
                        break;
                }
            }
        }

        public void OnAuthorizationSignOut(string msg)
        {
            if (this._channel == XAuthorizationChannel.XAuthorization_Max)
                return;
            this._sdk_sign_out = true;
            if (!XStage.IsConcreteStage(XSingleton<XGame>.singleton.CurrentStage.Stage))
            {
                if (string.IsNullOrEmpty(msg))
                    this._authorized = false;
                else
                    XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), (object)msg));
                this.FromBegining();
            }
            else
            {
                XSingleton<XDebug>.singleton.AddLog("OnAuthorizationSignOut " + msg);
                XSingleton<XClientNetwork>.singleton.Close();
                if (XSingleton<XScene>.singleton.SceneReady)
                    XSingleton<UiUtility>.singleton.OnFatalErrorClosed(ErrorCode.ERR_AUTH_TOKEN_INVALID);
                else
                    XSingleton<XScene>.singleton.Error = ErrorCode.ERR_AUTH_TOKEN_INVALID;
            }
            this._channel = XAuthorizationChannel.XAuthorization_Max;
        }

        public void AuthorizationSignOut()
        {
            if (this._channel == XAuthorizationChannel.XAuthorization_Max)
                return;
            this._authorized = false;
            if (this._channel != XAuthorizationChannel.XAuthorization_Internal && this._channel != XAuthorizationChannel.XAuthorization_Max)
            {
                this.ResetAccoutInfo();
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.LogOut();
            }
            this.DelAccount();
            XSingleton<XPandoraSDKDocument>.singleton.PandoraLogout();
            this._channel = XAuthorizationChannel.XAuthorization_Max;
            this.FromBegining();
        }

        public void OnAuthorized(string identification)
        {
            if (this._channel == XAuthorizationChannel.XAuthorization_SD)
                this._account = string.Format("{0} ({1})", (object)identification, (object)XStringDefineProxy.GetString("SDO_TOKEN"));
            if (this._channel == XAuthorizationChannel.XAuthorization_QQ)
                this._account = identification + " (QQ)";
            if (this._channel == XAuthorizationChannel.XAuthorization_WeChat)
                this._account = string.Format("{0} ({1})", (object)identification, (object)XStringDefineProxy.GetString("WECHAT_TOKEN"));
            if (this._channel == XAuthorizationChannel.XAuthorization_Guest)
                this._account = string.Format("{0} ({1})", (object)identification, (object)XStringDefineProxy.GetString("GUEST_TOKEN"));
            if (!this._auto_authorization || this._authorized_from_login_stage)
                XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), (object)XStringDefineProxy.GetString("AUTHORIZED_SUCCESS")));
            this.SaveAccount();
            this._authorized = true;
            this.ShowLoginSelectServerUI();
            this.SetBlockUIVisable(false);
            XSingleton<XClientNetwork>.singleton.XLoginStep = XLoginStep.Login;
        }

        public void OnAuthorizedFailed()
        {
            XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), (object)XStringDefineProxy.GetString("AUTHORIZED_FAIL")));
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetSDKConfig("get_login_eflag", "");
            if (this._channel != XAuthorizationChannel.XAuthorization_Internal && this._channel != XAuthorizationChannel.XAuthorization_Max)
                this.ResetAccoutInfo();
            XSingleton<PDatabase>.singleton.playerInfo = (PlayerInfo)null;
            XSingleton<PDatabase>.singleton.friendsInfo = (FriendInfo)null;
            this._authorized = false;
            this.OnError();
            this.FromBegining();
        }

        public void OnAuthorizedConnectFailed()
        {
            if (this._channel != XAuthorizationChannel.XAuthorization_Internal && this._channel != XAuthorizationChannel.XAuthorization_Max)
                this.ResetAccoutInfo();
            XSingleton<PDatabase>.singleton.playerInfo = (PlayerInfo)null;
            XSingleton<PDatabase>.singleton.friendsInfo = (FriendInfo)null;
            XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), (object)XStringDefineProxy.GetString("AUTHORIZED_CONNECT_FAIL")));
            this._authorized = false;
            this.OnError();
            this.FromBegining();
        }

        public void OnAuthorizedTimeOut()
        {
            if (this._channel != XAuthorizationChannel.XAuthorization_Internal && this._channel != XAuthorizationChannel.XAuthorization_Max)
                this.ResetAccoutInfo();
            XSingleton<PDatabase>.singleton.playerInfo = (PlayerInfo)null;
            XSingleton<PDatabase>.singleton.friendsInfo = (FriendInfo)null;
            XSingleton<UiUtility>.singleton.ShowLoginTip(this.PlatformComment(this._channel) + " 授权验证超时");
            this._authorized = false;
            this.FromBegining();
        }

        public void Login()
        {
            this.SetBlockUIVisable(true);
            this._logining = true;
            this._last_login_at = Time.realtimeSinceStartup;
            this._in_server_queue = false;
            XSingleton<XClientNetwork>.singleton.Login();
        }

        public void OnLogin()
        {
            if (this._authorized_from_login_stage)
                this._view.TweenAlpha(true);
            XSingleton<XClientNetwork>.singleton.OnLogin();
            this._logining = false;
            this._authorized_from_login_stage = false;
            this._in_server_queue = false;
            this.SetBlockUIVisable(false);
        }

        public StartUpType GetWakeUpType()
        {
            StartUpType startUpType = StartUpType.StartUp_Normal;
            string sdkConfig = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetSDKConfig("get_wakeup_info", "");
            XSingleton<XDebug>.singleton.AddLog("[GetLaunchType] wakeupInfo:" + sdkConfig);
            if (sdkConfig == "")
                return startUpType;
            Dictionary<string, object> dictionary = Json.Deserialize(sdkConfig) as Dictionary<string, object>;
            object obj = (object)null;
            if (dictionary != null && dictionary.TryGetValue("wakeup_platform", out obj))
            {
                XSingleton<XDebug>.singleton.AddLog("[GetLaunchType] platform: " + obj.ToString());
                if ((long)obj == 1L)
                    startUpType = StartUpType.StartUp_WX;
                else if ((long)obj == 2L)
                    startUpType = StartUpType.StartUp_QQ;
            }
            return startUpType;
        }

        public StartUpType GetLaunchType()
        {
            StartUpType startUpType = StartUpType.StartUp_Normal;
            string sdkConfig = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetSDKConfig("get_wakeup_info", "");
            XSingleton<XDebug>.singleton.AddLog("[GetLaunchType] wakeupInfo:" + sdkConfig);
            if (sdkConfig == "")
                return startUpType;
            Dictionary<string, object> dictionary = Json.Deserialize(sdkConfig) as Dictionary<string, object>;
            object obj1 = (object)null;
            if (dictionary != null && dictionary.TryGetValue("wakeup_platform", out obj1))
            {
                XSingleton<XDebug>.singleton.AddLog("[GetLaunchType] platform: " + obj1.ToString());
                if ((long)obj1 == 1L)
                {
                    XSingleton<XDebug>.singleton.AddLog("[GetLaunchType] platform == 1");
                    object obj2 = (object)null;
                    if (dictionary.TryGetValue("wakeup_wx_extInfo", out obj2) && obj2.ToString() == "WX_GameCenter")
                    {
                        startUpType = StartUpType.StartUp_WX;
                        XSingleton<XDebug>.singleton.AddLog("[GetLaunchType] StartUpType.StartUp_WX");
                    }
                }
                else if ((long)obj1 == 2L)
                {
                    XSingleton<XDebug>.singleton.AddLog("[GetLaunchType] platform == 2");
                    object obj3 = (object)null;
                    if (dictionary.TryGetValue("wakeup_qq_extInfo", out obj3) && obj3.ToString() == "sq_gamecenter")
                    {
                        startUpType = StartUpType.StartUp_QQ;
                        XSingleton<XDebug>.singleton.AddLog("[GetLaunchType] StartUpType.StartUp_QQ");
                    }
                }
            }
            return startUpType;
        }

        public void SetLaunchTypeServerInfo(StartUpType type) => this._LaunchTypeServer = type;

        public StartUpType GetLaunchTypeServerInfo() => this._LaunchTypeServer;

        public void EnterToSelectChar()
        {
            XSingleton<XLoginDocument>.singleton.OnLogin();
            switch (XSingleton<XGame>.singleton.CurrentStage.Stage)
            {
                case EXStage.Login:
                    XSingleton<XGame>.singleton.CurrentStage.Play();
                    break;
                case EXStage.SelectChar:
                    (XSingleton<XGame>.singleton.CurrentStage as XSelectcharStage).ReLogined();
                    break;
            }
        }

        public void CheckQueueState(object o)
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._query_queue_token);
            this._query_queue_token = 0U;
            if (!DlgBase<XLoginView, LoginWindowBehaviour>.singleton.IsVisible() || !this._in_server_queue)
                return;
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2M_CheckQueuingReq()
            {
                Data = {
          iscancel = false
        }
            });
            this._query_queue_token = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.CheckQueueState), (object)null);
        }

        public void CancelQueue()
        {
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2M_CheckQueuingReq()
            {
                Data = {
          iscancel = true
        }
            });
            this.OnCancelServerQueue();
        }

        public void ShowServerQueue()
        {
            if (!DlgBase<XLoginView, LoginWindowBehaviour>.singleton.IsVisible())
                return;
            this._in_server_queue = true;
            DlgBase<XLoginView, LoginWindowBehaviour>.singleton.ShowQueue();
            this.CheckQueueState((object)null);
            this.SetBlockUIVisable(false);
        }

        public void WaitForServerQueue(uint roleCount, uint leftTime)
        {
            this._role_count_inqueue = roleCount;
            this._left_time_inqueue = leftTime;
            if (!DlgBase<XLoginView, LoginWindowBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XLoginView, LoginWindowBehaviour>.singleton.RefreshQueueState();
        }

        public void OnLoginFailed(string error)
        {
            XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), string.IsNullOrEmpty(error) ? (object)XStringDefineProxy.GetString("LOGIN_FAIL") : (object)error));
            this._logining = false;
            this._in_server_queue = false;
            this.FromLogining();
        }

        public void OnLoginTimeout()
        {
            XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), (object)XStringDefineProxy.GetString("LOGIN_TIMEOUT")));
            this._logining = false;
            this._in_server_queue = false;
            this.FromLogining();
        }

        public void OnLoginConnectFailed()
        {
            XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), (object)XStringDefineProxy.GetString("LOGIN_CONNECT_FAIL")));
            this._logining = false;
            this._in_server_queue = false;
            this.FromLogining();
        }

        public void OnCancelServerQueue()
        {
            XSingleton<UiUtility>.singleton.ShowLoginTip(XStringDefineProxy.GetString("CANCEL_QUEUE"));
            this._logining = false;
            this._in_server_queue = false;
            XSingleton<XClientNetwork>.singleton.Close();
            this._authorized_from_login_stage = true;
            this.FromLogining();
        }

        public void EnterWorld(int index)
        {
            if ((double)Time.time - (double)this.enterWorldTime < 2.0)
                return;
            this.enterWorldTime = Time.time;
            if (index > 0)
                XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_SelectRoleNew()
                {
                    oArg = {
            index = (index - 1)
          }
                });
            XSingleton<XClientNetwork>.singleton.XLoginToken = (string)null;
        }

        public void CreateChar(string name, RoleType type)
        {
            if ((double)Time.time - (double)this.enterWorldTime < 2.0)
                return;
            this.enterWorldTime = Time.time;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_CreateRoleNew()
            {
                oArg = {
          name = name,
          type = type
        }
            });
            this.SetBlockUIVisable(true);
        }

        public void OnEnterWorldFailed(string error)
        {
            this.BackToLogin();
            XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), string.IsNullOrEmpty(error) ? (object)XStringDefineProxy.GetString("ENTER_WORLD_FAIL") : (object)error));
        }

        public void OnEnterWorldTimeOut()
        {
            this.BackToLogin();
            XSingleton<UiUtility>.singleton.ShowLoginTip(string.Format("{0} {1}", (object)this.PlatformComment(this._channel), (object)XStringDefineProxy.GetString("ENTER_WORLD_TIMEOUT")));
        }

        public void EnableSDONotify()
        {
            if (!this._notification)
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ResgiterSDONotification(XSingleton<XClientNetwork>.singleton.ServerID, XSingleton<XEntityMgr>.singleton.Player.Name);
            this._notification = true;
        }

        private void BackToBegin()
        {
            if (XSingleton<XClientNetwork>.singleton.XLoginStep == XLoginStep.Begin)
                return;
            XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Clear();
            XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.SelectedSlot = 0;
            XSingleton<XClientNetwork>.singleton.XLoginStep = XLoginStep.Begin;
            XSingleton<XGame>.singleton.SwitchTo(EXStage.Login, 3U);
        }

        private void BackToLogin()
        {
            if (XSingleton<XClientNetwork>.singleton.XLoginStep == XLoginStep.Login)
                return;
            XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Clear();
            XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.SelectedSlot = 0;
            XSingleton<XClientNetwork>.singleton.XLoginStep = XLoginStep.Login;
            XSingleton<XGame>.singleton.SwitchTo(EXStage.Login, 3U);
        }

        private void SaveAccount()
        {
            int num = XFastEnumIntEqualityComparer<XAuthorizationChannel>.ToInt(this._channel);
            string str = Application.persistentDataPath + "/account.txt";
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                str = Application.dataPath + "/account.txt";
            try
            {
                File.WriteAllBytes(str, this.XCryptography(string.Format("{0}\n{1}\n{2}", (object)num, (object)this._account, (object)this._pwd)));
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SetNoBackupFlag(str);
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Save account file error ", ex.Message);
            }
        }

        private void PlatformAuthorization() => XSingleton<XUpdater.XUpdater>.singleton.XPlatform.OnPlatformLogin();

        private void QQAuthorization(bool auto) => XSingleton<XUpdater.XUpdater>.singleton.XPlatform.OnQQLogin();

        private void WeChatAuthorization(bool auto) => XSingleton<XUpdater.XUpdater>.singleton.XPlatform.OnWeChatLogin();

        private void GuestAuthorization(bool auto) => XSingleton<XUpdater.XUpdater>.singleton.XPlatform.OnGuestLogin();

        private void InternalAuthorization(string account, string pwd) => this.OnAuthorization(account, pwd, account, XAuthorizationChannel.XAuthorization_Internal);

        public void Update()
        {
            this._fetch_delay = false;
            this._login_delay = false;
            if (this._fetching_token)
            {
                if ((double)this.FetchingElapsed > (double)XLoginDocument._delay_notice_threshold)
                    this._fetch_delay = true;
                if ((double)this.FetchingElapsed > (double)XLoginDocument._max_delay_notice_threshold)
                {
                    this._fetching_token = false;
                    this._fetch_delay = false;
                    this.SetBlockUIVisable(false);
                }
            }
            if (!this._logining || this._in_server_queue || (double)this.LoginingElapsed <= (double)XLoginDocument._delay_notice_threshold)
                return;
            if ((double)this.LoginingElapsed > (double)XLoginDocument._max_notice_threshold)
            {
                XSingleton<XClientNetwork>.singleton.Close();
                this.OnLoginTimeout();
            }
            else
                this._login_delay = true;
        }

        private string PlatformComment(XAuthorizationChannel channel)
        {
            switch (channel)
            {
                case XAuthorizationChannel.XAuthorization_Internal:
                    return "";
                case XAuthorizationChannel.XAuthorization_SD:
                    return XStringDefineProxy.GetString("SDO_TOKEN");
                case XAuthorizationChannel.XAuthorization_QQ:
                    return "QQ";
                case XAuthorizationChannel.XAuthorization_WeChat:
                    return XStringDefineProxy.GetString("WECHAT_TOKEN");
                case XAuthorizationChannel.XAuthorization_Guest:
                    return XStringDefineProxy.GetString("GUEST_TOKEN");
                default:
                    return "";
            }
        }

        private byte[] XCryptography(string content)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            for (int index = 0; index < bytes.Length; ++index)
                bytes[index] = (byte)((uint)bytes[index] ^ (uint)XLoginDocument._seed);
            return bytes;
        }

        private string XCryptography(byte[] content)
        {
            for (int index = 0; index < content.Length; ++index)
                content[index] = (byte)((uint)content[index] ^ (uint)XLoginDocument._seed);
            return Encoding.UTF8.GetString(content);
        }

        public bool IsPublish() => XSingleton<XUpdater.XUpdater>.singleton.XPlatform.IsPublish();

        public void SetBlockUIVisable(bool state)
        {
            if (DlgBase<XLoginView, LoginWindowBehaviour>.singleton.IsVisible())
                DlgBase<XLoginView, LoginWindowBehaviour>.singleton.uiBehaviour.m_BlockWindow.gameObject.SetActive(state);
            if (!DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.uiBehaviour.m_block.gameObject.SetActive(state);
        }

        public void ShowLoginUI()
        {
            if (!DlgBase<XLoginView, LoginWindowBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XLoginView, LoginWindowBehaviour>.singleton.ShowLogin();
        }

        public void ShowLoginSelectServerUI()
        {
            if (!DlgBase<XLoginView, LoginWindowBehaviour>.singleton.IsVisible())
                return;
            if (string.IsNullOrEmpty(XSingleton<XClientNetwork>.singleton.XLoginToken))
                XSingleton<XLoginDocument>.singleton.AutoAuthorization(false);
            this.ShowAfterLoginAnnouncement();
            DlgBase<XLoginView, LoginWindowBehaviour>.singleton.ShowSelectServer();
            DlgBase<XLoginView, LoginWindowBehaviour>.singleton.SetCurrentServer();
        }

        public void ShowSelectCharGerenalUI()
        {
            if (!DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.ShowSelectCharGerenal();
        }

        public void ShowSelectCharSelectedUI(string name, int level)
        {
            if (!DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.ShowSelectCharSelected(name, level);
        }

        public void ShowSelectCharCreatedUI()
        {
            if (!DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.IsVisible())
                return;
            DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.ShowSelectCharCreated();
        }

        public void SetLoginZoneID(uint loginZoneId) => this._login_zoneid = loginZoneId;

        public void SetAnnouncement(PlatNotice announcement) => this._announcement = announcement;

        public void SetFreeflow(bool _free, int _type)
        {
            this._freeflow = _free;
            this._cctype = _type;
        }

        public void SetGateIPTable(
          List<SelfServerData> myServersList,
          byte[] bytes,
          List<LoginGateData> serverList)
        {
            this._server_dic.Clear();
            this._server_category.Clear();
            this._zone_list.Clear();
            this.BackFlowServerList.Clear();
            for (int index1 = serverList.Count - 1; index1 >= 0; --index1)
            {
                LoginGateData server = serverList[index1];
                if (server.isbackflow)
                {
                    bool flag = true;
                    for (int index2 = 0; index2 < this.BackFlowServerList.Count; ++index2)
                    {
                        if (this.BackFlowServerList[index2].ServerID == server.serverid)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                        this.BackFlowServerList.Add(this.CreateServerInfoData(server.serverid, server.servername, server.zonename, server.ip, (uint)server.port, (int)server.state, (int)server.flag, server.backflowlevel));
                    serverList.RemoveAt(index1);
                }
            }
            string key1 = XSingleton<XStringTable>.singleton.GetString("MYSELF_SERVERS");
            this._server_category.Add(key1, new List<int>());
            this._zone_list.Add(key1);
            string key2 = XSingleton<XStringTable>.singleton.GetString("BACK_SERVERS");
            if (this.BackFlowServerList.Count > 0)
            {
                this._zone_list.Add(key2);
                this._server_category.Add(key2, new List<int>());
            }
            string key3 = XSingleton<XStringTable>.singleton.GetString("FRIENDS_SERVERS");
            this._server_category.Add(key3, new List<int>());
            this._zone_list.Add(key3);
            if (myServersList.Count == 0)
                XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("TRUE_NAME_TIP"), XStringDefineProxy.GetString("COMMON_OK"));
            for (int index3 = 0; index3 < myServersList.Count; ++index3)
            {
                this._server_category[key1].Add(myServersList[index3].servers.serverid);
                if (!this._server_dic.ContainsKey(myServersList[index3].servers.serverid))
                {
                    new List<string>()
          {
            string.Format("{0}:{1}", (object) myServersList[index3].servers.ip, (object) myServersList[index3].servers.port)
          };
                    this._server_dic.Add(myServersList[index3].servers.serverid, this.CreateServerInfoData(myServersList[index3].servers.serverid, myServersList[index3].servers.servername, myServersList[index3].servers.zonename, myServersList[index3].servers.ip, (uint)myServersList[index3].servers.port, (int)myServersList[index3].servers.state, (int)myServersList[index3].servers.flag, myServersList[index3].level));
                }
                for (int index4 = 0; index4 < this._backFlowServerList.Count; ++index4)
                {
                    if (this._backFlowServerList[index4].ServerID == myServersList[index3].servers.serverid)
                        this._backFlowServerList[index4].Level = myServersList[index3].level;
                }
            }
            for (int index = 0; index < serverList.Count; ++index)
            {
                if (!this._server_category.ContainsKey(serverList[index].zonename))
                {
                    this._server_category.Add(serverList[index].zonename, new List<int>());
                    this._zone_list.Add(serverList[index].zonename);
                }
                this._server_category[serverList[index].zonename].Add(serverList[index].serverid);
                if (!this._server_dic.ContainsKey(serverList[index].serverid))
                    this._server_dic.Add(serverList[index].serverid, this.CreateServerInfoData(serverList[index].serverid, serverList[index].servername, serverList[index].zonename, serverList[index].ip, (uint)serverList[index].port, (int)serverList[index].state, (int)serverList[index].flag, 0U));
            }
            for (int index = 0; index < this.BackFlowServerList.Count; ++index)
            {
                this._server_category[key2].Add(this.BackFlowServerList[index].ServerID);
                if (!this._server_dic.ContainsKey(this.BackFlowServerList[index].ServerID))
                    this._server_dic.Add(this.BackFlowServerList[index].ServerID, this.BackFlowServerList[index]);
            }
        }

        public void SetFriendServerList(List<PlatFriendServer> friendList)
        {
            this.FriendServerDic.Clear();
            this.FriendOpenid.Clear();
            for (int index = 0; index < friendList.Count; ++index)
            {
                ServerInfo serverData = this.GetServerData(friendList[index].serverid);
                if (serverData != null && (XSingleton<XGame>.singleton.IsGMAccount || serverData.StateTxt != 6))
                {
                    this.FriendServerDic[friendList[index].openid] = new FriendServerInfo()
                    {
                        info = friendList[index],
                        account = "",
                        icon = ""
                    };
                    this.FriendOpenid.Add(friendList[index].openid);
                }
            }
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("QueryFriends", "");
        }

        public void SetFriendServerIcon()
        {
            for (int index = 0; index < XSingleton<PDatabase>.singleton.friendsInfo.data.Length; ++index)
            {
                if (this.FriendServerDic.ContainsKey(XSingleton<PDatabase>.singleton.friendsInfo.data[index].openId))
                {
                    this.FriendServerDic[XSingleton<PDatabase>.singleton.friendsInfo.data[index].openId].account = XSingleton<PDatabase>.singleton.friendsInfo.data[index].nickName;
                    this.FriendServerDic[XSingleton<PDatabase>.singleton.friendsInfo.data[index].openId].icon = XSingleton<PDatabase>.singleton.friendsInfo.data[index].pictureLarge;
                }
            }
        }

        public ServerInfo CreateServerInfoData(
          int serverID,
          string serverName,
          string zoneName,
          string ip,
          uint port,
          int state,
          int stateTxt,
          uint level)
        {
            return new ServerInfo()
            {
                ServerID = serverID,
                ServerName = serverName,
                ZoneName = zoneName,
                Ip = ip,
                Port = port,
                State = state,
                StateTxt = stateTxt,
                Level = level
            };
        }

        public ServerInfo GetServerData(int id)
        {
            ServerInfo serverInfo;
            return this._server_dic.TryGetValue(id, out serverInfo) ? serverInfo : (ServerInfo)null;
        }

        public void OnServerChanged(int id)
        {
            ServerInfo serverData = this.GetServerData(id);
            if (serverData == null || !XSingleton<XClientNetwork>.singleton.OnServerChanged(serverData))
                return;
            this._view.SetCurrentServer();
        }

        public bool OnLoginForbidClick(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            this.BackToLogin();
            return true;
        }

        public void SetLoginReconnect(LoginReconnectInfo info) => this._login_reconnect_info = info;

        public void ShowLoginReconnect()
        {
            if (this._login_reconnect_info == null || this._login_reconnect_info.scenetemplateid == 0U)
                return;
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._login_reconnect_info.scenetemplateid);
            XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("LOGIN_RECONNECT_TIP", sceneData != null ? (object)sceneData.Comment : (object)""), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnStartLoginReconnectClicked), new ButtonClickEventHandler(this.OnCancelLoginReconnectClicked));
        }

        private bool OnStartLoginReconnectClicked(IXUIButton btn)
        {
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2N_LoginReconnectReq()
            {
                oArg = {
          reconnect = true
        }
            });
            this._login_reconnect_info = (LoginReconnectInfo)null;
            this.SetBlockUIVisable(true);
            return true;
        }

        private bool OnCancelLoginReconnectClicked(IXUIButton btn)
        {
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2N_LoginReconnectReq()
            {
                oArg = {
          reconnect = false
        }
            });
            this._login_reconnect_info = (LoginReconnectInfo)null;
            this.SetBlockUIVisable(true);
            return true;
        }
    }
}
