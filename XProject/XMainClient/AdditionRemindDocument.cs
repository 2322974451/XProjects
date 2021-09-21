// Decompiled with JetBrains decompiler
// Type: XMainClient.AdditionRemindDocument
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

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
    internal class AdditionRemindDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(AdditionRemindDocument));
        private bool is3G = false;
        private static bool is_3g_tip = false;
        private string cacheString = (string)null;
        private int uploadtime = 0;
        public uint loginday = 10;
        public bool gm_is_3g = false;
        public int FREQUENCY = 0;
        public int LOGINTIME = 0;
        private float lasttime = 10f;

        public override uint ID => AdditionRemindDocument.uuID;

        protected override void OnReconnected(XReconnectedEventArgs arg)
        {
        }

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this.is3G = Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork;
        }

        public override void Update(float fDeltaT)
        {
            base.Update(fDeltaT);
            if ((double)Time.time - (double)this.lasttime <= 5.0)
                return;
            this.Free3GTimer();
            this.lasttime = Time.time;
        }

        public void OnRecieveAdditionTip(string msg)
        {
            this.cacheString = msg;
            if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                return;
            this.ShowAddtionUI();
        }

        public void Free3GTimer()
        {
            if (this.LOGINTIME <= 0)
                this.LOGINTIME = XSingleton<XGlobalConfig>.singleton.GetInt("Free3GTime");
            if (this.FREQUENCY <= 0)
                this.FREQUENCY = XSingleton<XGlobalConfig>.singleton.GetInt("Free3GDay");
            if ((double)Time.time <= (double)this.LOGINTIME || !this.is3G && !this.gm_is_3g || AdditionRemindDocument.is_3g_tip || (long)this.loginday < (long)this.FREQUENCY || XSingleton<XLoginDocument>.singleton.freeflow || DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible() || XSingleton<XTutorialMgr>.singleton.InTutorial || !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                return;
            this.UpdateFreeState();
            AdditionRemindDocument.is_3g_tip = true;
            XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("REM_3G"), XStringDefineProxy.GetString("REM_BUY"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.Show3GFreeUI));
        }

        public void SetFreeflowTime(uint time) => this.loginday = ((uint)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds - time) / 3600U;

        private void UpdateFreeState()
        {
            PtcC2G_UpdateFreeflowHintInfo freeflowHintInfo = new PtcC2G_UpdateFreeflowHintInfo();
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            freeflowHintInfo.Data.hint_time = (uint)timeSpan.TotalSeconds;
            XSingleton<XClientNetwork>.singleton.Send((Protocol)freeflowHintInfo);
        }

        private bool Show3GFreeUI(IXUIButton button)
        {
            this.Open3GWebPage();
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        public void Open3GWebPage()
        {
            int num = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ ? 2 : 1;
            string CipherText = XSingleton<XGlobalConfig>.singleton.GetValue("SignalKey");
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary["url"] = string.Format(XSingleton<XGlobalConfig>.singleton.GetValue("SignalFreeUrl"), (object)XSingleton<XLoginDocument>.singleton.OpenID, (object)num, (object)XSingleton<XUpdater.XUpdater>.singleton.XPlatform.UserMd5(XSingleton<XLoginDocument>.singleton.OpenID + (object)num + (object)XSingleton<UiUtility>.singleton.GetTimeStamp() + "1231_LongZhiGuApp" + XSingleton<UiUtility>.singleton.Decrypt(CipherText)).ToLower(), (object)XSingleton<UiUtility>.singleton.GetTimeStamp(), (object)"1231_LongZhiGuApp", (object)XSingleton<XLoginDocument>.singleton.TokenCache);
            dictionary["screendir"] = "SENSOR";
            if (Application.isEditor)
                Application.OpenURL(dictionary["url"]);
            else
                XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize((object)dictionary));
        }

        public void ShowAddtionUI()
        {
            if (XSingleton<XTutorialMgr>.singleton.InTutorial)
                return;
            if (!string.IsNullOrEmpty(this.cacheString))
                XSingleton<UiUtility>.singleton.ShowModalDialog(this.cacheString, XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
            this.cacheString = (string)null;
        }

        public override void OnEnterSceneFinally()
        {
            base.OnEnterSceneFinally();
            if (XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall)
                return;
            this.ShowAddtionUI();
            if (this.uploadtime < 1)
                this.OnUploadUrl();
        }

        public override void OnDetachFromHost()
        {
            this.uploadtime = 0;
            base.OnDetachFromHost();
        }

        public void OnUploadUrl()
        {
            if (XSingleton<PDatabase>.singleton.playerInfo == null)
                return;
            ++this.uploadtime;
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_PicUrlNtf()
            {
                Data = {
          url = (XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ ? XSingleton<PDatabase>.singleton.playerInfo.data.pictureMiddle : XSingleton<PDatabase>.singleton.playerInfo.data.pictureLarge)
        }
            });
        }
    }
}
