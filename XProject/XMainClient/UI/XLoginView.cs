// Decompiled with JetBrains decompiler
// Type: XMainClient.UI.XLoginView
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using MiniJSON;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class XLoginView : DlgBase<XLoginView, LoginWindowBehaviour>
    {
        private XLoginDocument _doc = (XLoginDocument)null;

        public override string fileName => "SelectChar/LoginDlg";

        public override int layer => 1;

        protected override void Init()
        {
            this._doc = XSingleton<XLoginDocument>.singleton;
            this._doc.View = this;
        }

        protected override void OnShow()
        {
            base.OnShow();
            this.SetVersion("v" + XSingleton<XUpdater.XUpdater>.singleton.Version);
            this.uiBehaviour.m_Login.SetVisible(!this._doc.IsPublish());
            this.uiBehaviour.m_Account.SetVisible(!this._doc.IsPublish());
            this.uiBehaviour.m_Password.SetVisible(!this._doc.IsPublish());
            int num1 = 4;
            float x = 0.0f;
            float y = this.uiBehaviour.m_GuestLogin.gameObject.transform.localPosition.y;
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                num1 |= 1;
                x -= (float)(this.uiBehaviour.m_GuestLogin.spriteWidth / 2 + 10);
            }
            if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckWeChatInstalled() || Application.platform != RuntimePlatform.IPhonePlayer)
            {
                num1 |= 2;
                x -= (float)(this.uiBehaviour.m_GuestLogin.spriteWidth / 2 + 10);
            }
            if ((num1 & 1) > 0)
            {
                this.uiBehaviour.m_GuestLogin.gameObject.transform.localPosition = new Vector3(x, y);
                x += (float)(this.uiBehaviour.m_GuestLogin.spriteWidth + 10);
            }
            else
                this.uiBehaviour.m_GuestLogin.SetVisible(false);
            if ((num1 & 2) > 0)
            {
                this.uiBehaviour.m_WXLogin.gameObject.transform.localPosition = new Vector3(x, y);
                x += (float)(this.uiBehaviour.m_WXLogin.spriteWidth + 10);
            }
            else
                this.uiBehaviour.m_WXLogin.SetVisible(false);
            if ((num1 & 4) > 0)
            {
                this.uiBehaviour.m_QQLogin.gameObject.transform.localPosition = new Vector3(x, y);
                float num2 = x + (float)(this.uiBehaviour.m_QQLogin.spriteWidth + 10);
            }
            else
                this.uiBehaviour.m_QQLogin.SetVisible(false);
        }

        public override void RegisterEvent()
        {
            this.uiBehaviour.m_Login.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAccountInfoEnterClick));
            this.uiBehaviour.m_QQLogin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQQLoginButtonClick));
            this.uiBehaviour.m_WXLogin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWXLoginButtonClick));
            this.uiBehaviour.m_GuestLogin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGuestButtonClick));
            this.uiBehaviour.m_Notice.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnNoticeClicked));
            this.uiBehaviour.m_CG.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCGClicked));
            this.uiBehaviour.m_CustomerService.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCustomerServiceClicked));
            this.uiBehaviour.m_EnterToSelectChar.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterToSelectCharClicked));
            this.uiBehaviour.m_ReturnToLogin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnToLoginClicked));
            this.uiBehaviour.m_ServerListButton.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectServerClick));
            this.uiBehaviour.m_CloseServerList.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnServerListCloseClicked));
            this.uiBehaviour.m_LeaveQueue.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLeaveQueueClicked));
            this.uiBehaviour.m_FriendWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.FriendWrapContentUpdated));
        }

        public void RefreshAccount()
        {
            this.uiBehaviour.m_Account.SetText(this._doc.Account ?? "");
            this.uiBehaviour.m_Password.SetText(this._doc.Password ?? "");
        }

        private bool OnAccountInfoEnterClick(IXUIButton button)
        {
            if (this._doc.CheckLoginBlockTime())
                this._doc.Authorization(XAuthorizationChannel.XAuthorization_Internal, true, account: this.uiBehaviour.m_Account.GetText(), pwd: this.uiBehaviour.m_Password.GetText());
            else
                XSingleton<UiUtility>.singleton.ShowLoginTip(XStringDefineProxy.GetString("LOGIN_TOO_FREQUENT"));
            return true;
        }

        private bool OnQQLoginButtonClick(IXUIButton go)
        {
            if (this._doc.CheckLoginBlockTime())
                this._doc.Authorization(XAuthorizationChannel.XAuthorization_QQ, true);
            else
                XSingleton<UiUtility>.singleton.ShowLoginTip(XStringDefineProxy.GetString("LOGIN_TOO_FREQUENT"));
            return true;
        }

        private bool OnWXLoginButtonClick(IXUIButton go)
        {
            if (this._doc.CheckLoginBlockTime())
                this._doc.Authorization(XAuthorizationChannel.XAuthorization_WeChat, true);
            else
                XSingleton<UiUtility>.singleton.ShowLoginTip(XStringDefineProxy.GetString("LOGIN_TOO_FREQUENT"));
            return true;
        }

        private bool OnGuestButtonClick(IXUIButton go)
        {
            if (this._doc.CheckLoginBlockTime())
                this._doc.Authorization(XAuthorizationChannel.XAuthorization_Guest, true);
            else
                XSingleton<UiUtility>.singleton.ShowLoginTip(XStringDefineProxy.GetString("LOGIN_TOO_FREQUENT"));
            return true;
        }

        private bool OnNoticeClicked(IXUIButton go)
        {
            XSingleton<UiUtility>.singleton.ShowAfterLoginAnnouncement(this._doc.Announcement);
            return true;
        }

        private bool OnCGClicked(IXUIButton button)
        {
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(XSingleton<XUpdater.XUpdater>.singleton.PlayCG), (object)null);
            return true;
        }

        private bool OnCustomerServiceClicked(IXUIButton go)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    dictionary["url"] = XSingleton<XGlobalConfig>.singleton.GetValue("CustomerServiceLoginApple");
                    dictionary["screendir"] = "SENSOR";
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                    break;
                case RuntimePlatform.Android:
                    dictionary["url"] = XSingleton<XGlobalConfig>.singleton.GetValue("CustomerServiceLoginAndroid");
                    dictionary["screendir"] = "SENSOR";
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
                    break;
                default:
                    XSingleton<XDebug>.singleton.AddGreenLog("CustomerService-Login");
                    break;
            }
            return true;
        }

        private bool OnEnterToSelectCharClicked(IXUIButton go)
        {
            if (string.IsNullOrEmpty(XSingleton<XClientNetwork>.singleton.XLoginToken))
                XSingleton<XLoginDocument>.singleton.AutoAuthorization(false);
            else
                XSingleton<XLoginDocument>.singleton.Login();
            return true;
        }

        private bool OnReturnToLoginClicked(IXUIButton go)
        {
            this._doc.AuthorizationSignOut();
            return true;
        }

        private void OnServerListCloseClicked(IXUISprite sp) => this.uiBehaviour.m_ServerList.gameObject.SetActive(false);

        private bool OnLeaveQueueClicked(IXUIButton button)
        {
            this.uiBehaviour.m_QueueFrame.SetActive(false);
            this._doc.CancelQueue();
            return true;
        }

        public void TweenAlpha(bool bForward) => this.uiBehaviour.m_Tween.PlayTween(bForward);

        public void SetVersion(string version)
        {
            if (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.IsTestMode())
                this.uiBehaviour.m_Version.SetText(version + "Test");
            else
                this.uiBehaviour.m_Version.SetText(version);
        }

        public void ShowLogin()
        {
            this.uiBehaviour.m_normalFrame.SetActive(true);
            this.uiBehaviour.m_ServerListFrame.SetActive(false);
            this.uiBehaviour.m_QueueFrame.SetActive(false);
            this.RefreshAccount();
        }

        public void ShowSelectServer()
        {
            this.uiBehaviour.m_normalFrame.SetActive(false);
            this.uiBehaviour.m_ServerListFrame.SetActive(true);
            this.uiBehaviour.m_ServerList.gameObject.SetActive(false);
            this.uiBehaviour.m_QueueFrame.SetActive(false);
        }

        public void ShowQueue()
        {
            this.uiBehaviour.m_normalFrame.SetActive(false);
            this.uiBehaviour.m_ServerListFrame.SetActive(false);
            this.uiBehaviour.m_QueueFrame.SetActive(true);
            this.uiBehaviour.m_QueueTip.SetText("");
        }

        public void RefreshQueueState()
        {
            if (!this.uiBehaviour.m_QueueFrame.activeSelf)
                return;
            this.uiBehaviour.m_QueueTip.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("WAIT_FOR_SERVER_QUEUE")), (object)XSingleton<XClientNetwork>.singleton.Server, (object)this._doc.RoleCountInQueue, (object)XSingleton<UiUtility>.singleton.TimeAccFormatString((int)this._doc.LeftTimeInQueue, 3)));
        }

        public void OnShowServerList()
        {
            this.uiBehaviour.m_ServerPool.ReturnAll();
            this.uiBehaviour.m_ServerList.gameObject.SetActive(true);
            this.SetupAreaServerList();
        }

        private void OnSelectServerClick(IXUISprite sp) => this.OnShowServerList();

        public void SetCurrentServer() => this.uiBehaviour.m_CurrentServer.SetText(XSingleton<XClientNetwork>.singleton.Server);

        private void SetupAreaServerList()
        {
            this.uiBehaviour.m_AreaPool.ReturnAll();
            Vector3 localPosition = this.uiBehaviour.m_AreaPool._tpl.transform.localPosition;
            int tplHeight = this.uiBehaviour.m_AreaPool.TplHeight;
            IXUICheckBox xuiCheckBox = (IXUICheckBox)null;
            string str = XSingleton<XStringTable>.singleton.GetString("BACK_SERVERS");
            bool flag = XSingleton<XLoginDocument>.singleton.BackFlowServerList.Count > 0;
            for (int index = 0; index < this._doc.ZoneList.Count; ++index)
            {
                GameObject gameObject = this.uiBehaviour.m_AreaPool.FetchGameObject();
                gameObject.name = "Area" + (object)index;
                gameObject.transform.localPosition = localPosition + new Vector3(0.0f, (float)(-index * tplHeight));
                IXUILabel component = gameObject.GetComponent("XUILabel") as IXUILabel;
                (gameObject.transform.Find("Selected/Label").GetComponent("XUILabel") as IXUILabel).SetText(this._doc.ZoneList[index]);
                component.SetText(this._doc.ZoneList[index]);
                component.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnAreaClicked));
                string zone = this._doc.ZoneList[index];
                if (flag && zone == str)
                {
                    flag = true;
                    this.ShowAreaServers(this._doc.ZoneList[index]);
                    xuiCheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
                }
                if (index == 2 && !flag)
                {
                    this.ShowAreaServers(this._doc.ZoneList[index]);
                    xuiCheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
                }
            }
            if (xuiCheckBox == null)
                return;
            xuiCheckBox.bChecked = true;
        }

        private void ShowAreaServers(string zone)
        {
            if (zone == XStringDefineProxy.GetString("FRIENDS_SERVERS"))
            {
                this.uiBehaviour.m_FriendFrame.gameObject.SetActive(true);
                this.uiBehaviour.m_ServerFrame.gameObject.SetActive(false);
                this.uiBehaviour.m_FriendWrapContent.SetContentCount(this._doc.FriendOpenid.Count, true);
                this.uiBehaviour.m_FriendScrollView.ResetPosition();
            }
            else
            {
                this.uiBehaviour.m_FriendFrame.gameObject.SetActive(false);
                this.uiBehaviour.m_ServerFrame.gameObject.SetActive(true);
                this.uiBehaviour.m_FriendWrapContent.SetContentCount(0, true);
            }
            this.uiBehaviour.m_ServerPool.ReturnAll();
            Vector3 localPosition = this.uiBehaviour.m_ServerPool._tpl.transform.localPosition;
            int tplHeight = this.uiBehaviour.m_ServerPool.TplHeight;
            int tplWidth = this.uiBehaviour.m_ServerPool.TplWidth;
            List<int> intList = this._doc.ServerCategory[zone];
            int num1 = 0;
            for (int index = intList.Count - 1; index >= 0; --index)
            {
                ServerInfo serverData = this._doc.GetServerData(intList[index]);
                if (serverData != null && (XSingleton<XGame>.singleton.IsGMAccount || serverData.StateTxt != 6))
                {
                    Transform transform = this.uiBehaviour.m_ServerPool.FetchGameObject(true).transform;
                    transform.name = "Server" + (object)intList[index];
                    int num2 = num1 / 2;
                    int num3 = num1 % 2;
                    ++num1;
                    transform.localPosition = localPosition + new Vector3((float)(num3 * tplWidth), (float)(-num2 * tplHeight));
                    IXUISprite component1 = transform.GetComponent("XUISprite") as IXUISprite;
                    IXUILabel component2 = transform.FindChild("Bg/Name").GetComponent("XUILabel") as IXUILabel;
                    component1.ID = (ulong)intList[index];
                    component2.SetText(serverData.ServerName);
                    component1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnServerClicked));
                    (transform.FindChild("Bg/Status").GetComponent("XUISprite") as IXUISprite).SetSprite(this._ServerStateString((ServerStateEnum)serverData.State));
                    this._SetServerStateLabel(transform.gameObject, serverData.StateTxt);
                    IXUILabel component3 = transform.Find("Bg/Level").GetComponent("XUILabel") as IXUILabel;
                    component3.Alpha = serverData.Level == 0U ? 0.0f : 1f;
                    component3.SetText(string.Format("Lv.{0}", (object)serverData.Level));
                }
            }
            this.uiBehaviour.m_ServerScrollView.ResetPosition();
        }

        private void FriendWrapContentUpdated(Transform t, int index)
        {
            if (index < 0 || index >= this._doc.FriendOpenid.Count)
            {
                t.gameObject.SetActive(false);
            }
            else
            {
                FriendServerInfo friendServerInfo = (FriendServerInfo)null;
                if (!this._doc.FriendServerDic.TryGetValue(this._doc.FriendOpenid[index], out friendServerInfo))
                    return;
                ServerInfo serverData = this._doc.GetServerData(this._doc.FriendServerDic[this._doc.FriendOpenid[index]].info.serverid);
                if (serverData == null)
                    return;
                IXUISprite component1 = t.GetComponent("XUISprite") as IXUISprite;
                IXUILabel component2 = t.FindChild("Bg/Name").GetComponent("XUILabel") as IXUILabel;
                component1.ID = (ulong)friendServerInfo.info.serverid;
                component2.SetText(serverData.ServerName);
                component1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnServerClicked));
                (t.FindChild("Bg/Status").GetComponent("XUISprite") as IXUISprite).SetSprite(this._ServerStateString((ServerStateEnum)serverData.State));
                this._SetServerStateLabel(t.gameObject, serverData.StateTxt);
                IXUILabel component3 = t.Find("Bg/Level").GetComponent("XUILabel") as IXUILabel;
                component3.Alpha = friendServerInfo.info.level == 0 ? 0.0f : 1f;
                component3.SetText(string.Format("Lv.{0}", (object)friendServerInfo.info.level));
                (t.Find("Bg/GameName").GetComponent("XUILabel") as IXUILabel).SetText(friendServerInfo.info.rolename);
                (t.Find("Bg/IMName").GetComponent("XUILabel") as IXUILabel).SetText(friendServerInfo.account);
                IXUITexture component4 = t.Find("Bg/Icon").GetComponent("XUITexture") as IXUITexture;
                component4.SetVisible(true);
                component4.SetTexturePath("");
                XSingleton<XUICacheImage>.singleton.Load(friendServerInfo.icon, component4, (MonoBehaviour)this.uiBehaviour);
            }
        }

        private void OnAreaClicked(IXUILabel sp) => this.ShowAreaServers(sp.GetText());

        private void OnServerClicked(IXUISprite sp)
        {
            this.uiBehaviour.m_ServerList.gameObject.SetActive(false);
            this._doc.OnServerChanged((int)sp.ID);
        }

        private Color _ServerStateColor(ServerStateEnum state)
        {
            switch (state)
            {
                case ServerStateEnum.TIMEOUT:
                    return new Color(1f, 1f, 1f, 1f);
                case ServerStateEnum.EMPTY:
                    return new Color(0.1254902f, 0.8784314f, 0.1607843f, 1f);
                case ServerStateEnum.NORMAL:
                    return new Color(0.9960784f, 0.7254902f, 0.0f, 1f);
                case ServerStateEnum.FULL:
                    return new Color(0.8784314f, 0.2862745f, 0.1254902f, 1f);
                default:
                    return new Color(1f, 1f, 1f, 1f);
            }
        }

        private string _ServerStateString(ServerStateEnum state)
        {
            switch (state)
            {
                case ServerStateEnum.TIMEOUT:
                    return "fwq_0";
                case ServerStateEnum.EMPTY:
                    return "fwq_1";
                case ServerStateEnum.NORMAL:
                    return "fwq_2";
                case ServerStateEnum.FULL:
                    return "fwq_3";
                default:
                    return "fwq_0";
            }
        }

        private void _SetServerStateLabel(GameObject go, int state)
        {
            int num = XFastEnumIntEqualityComparer<ServerFlagEnum>.ToInt(ServerFlagEnum.MAX);
            for (int index = 0; index < num; ++index)
            {
                Transform transform = go.transform.Find(string.Format("Bg/State{0}", (object)index));
                if ((Object)transform != (Object)null)
                    transform.gameObject.SetActive(state == index);
            }
        }
    }
}
