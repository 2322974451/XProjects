// Decompiled with JetBrains decompiler
// Type: XMainClient.XScreenShotMgr
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System;
using System.Collections;
using System.IO;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XScreenShotMgr : XSingleton<XScreenShotMgr>
    {
        private string _file_name;
        private string _file_path;
        private string _share_type;
        private int _check_count = 0;
        private int _max_check_count = 50;
        private bool _is_sharing = false;
        private IXIFlyMgr _ifly_mgr = (IXIFlyMgr)null;
        private uint _check_token = 0;
        private uint _share_token = 0;
        private int _share_count = 0;
        private bool _share_doing = false;
        private string _logo_local_path;
        private int _share_index = 1;
        private WWW _downloader = (WWW)null;
        private bool _share_session = false;
        private ShareTagType _tag = ShareTagType.Invite_Tag;
        private string _url = (string)null;
        private object[] _params;
        private ScreenShotCallback _share_callback = (ScreenShotCallback)null;

        public string FilePath => this._file_path;

        public string FileName => this._file_name;

        public override bool Init()
        {
            if (this._ifly_mgr == null)
                this._ifly_mgr = XUpdater.XUpdater.XGameRoot.GetComponent("XIFlyMgr") as IXIFlyMgr;
            this._logo_local_path = Application.persistentDataPath + "/sharelogo";
            this.ClearOldPic();
            return true;
        }

        public override void Uninit() => base.Uninit();

        private void CheckScreenShotPic(object obj)
        {
            if (this._ifly_mgr == null)
                return;
            if (File.Exists(this._file_path))
            {
                this._is_sharing = false;
                if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ)
                    this._ifly_mgr.ScreenShotQQShare(this._file_path, this._share_type);
                else
                    this._ifly_mgr.ScreenShotWeChatShare(this._file_path, this._share_type);
                DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(false, true);
            }
            else if (this._check_count >= this._max_check_count)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Share failed");
            }
            else
            {
                this._check_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.CheckScreenShotPic), (object)null);
                ++this._check_count;
            }
        }

        public void CaptureScreenshot(object obj)
        {
            XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Photo, DragonShareType.None);
            this._file_name = string.Format("{0}{1}{2}_{3}{4}{5}.png", (object)DateTime.Now.Year.ToString().PadLeft(2, '0'), (object)DateTime.Now.Month.ToString().PadLeft(2, '0'), (object)DateTime.Now.Day.ToString().PadLeft(2, '0'), (object)DateTime.Now.Hour.ToString().PadLeft(2, '0'), (object)DateTime.Now.Minute.ToString().PadLeft(2, '0'), (object)DateTime.Now.Second.ToString().PadLeft(2, '0'));
            this._file_path = Application.persistentDataPath + "/" + this._file_name;
            XSingleton<XDebug>.singleton.AddLog("Take a screen shot: ", this._file_path);
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    Application.CaptureScreenshot(this._file_name, 0);
                    break;
                default:
                    Application.CaptureScreenshot(this._file_path, 0);
                    break;
            }
        }

        public void ShareScreen(bool issession)
        {
            this._share_type = !issession ? (XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ ? "Timeline" : "QZone") : "Session";
            if (this._is_sharing)
                return;
            this._check_count = 0;
            this.CheckScreenShotPic((object)null);
        }

        public string PartCaptureScreen(Rect rect, string accountType, string scene)
        {
            this._share_type = scene;
            XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.Pandora);
            XSingleton<XChatIFlyMgr>.singleton.IFLYMGR.GetMonoBehavior().StartCoroutine(this.CaptureByCamera(rect, accountType));
            return this._file_path;
        }

        private IEnumerator CaptureByCamera(Rect rect, string accountType)
        {
            yield return (object)new WaitForEndOfFrame();
            Texture2D texture = new Texture2D((int)rect.width, (int)rect.height);
            texture.ReadPixels(rect, 0, 0);
            texture.Apply();
            try
            {
                byte[] bytes = texture.EncodeToPNG();
                object[] objArray = new object[6];
                objArray[0] = (object)DateTime.Now.Year.ToString().PadLeft(2, '0');
                DateTime now = DateTime.Now;
                objArray[1] = (object)now.Month.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                objArray[2] = (object)now.Day.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                int num = now.Hour;
                objArray[3] = (object)num.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                num = now.Minute;
                objArray[4] = (object)num.ToString().PadLeft(2, '0');
                now = DateTime.Now;
                num = now.Second;
                objArray[5] = (object)num.ToString().PadLeft(2, '0');
                this._file_name = string.Format("{0}{1}{2}_{3}{4}{5}.png", objArray);
                this._file_path = Application.persistentDataPath + "/" + this._file_name;
                File.WriteAllBytes(this._file_path, bytes);
                bytes = (byte[])null;
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("part capture failed " + ex.Message);
            }
            if (File.Exists(this._file_path))
            {
                if (accountType == "qq")
                    this._ifly_mgr.ScreenShotQQShare(this._file_path, this._share_type);
                else
                    this._ifly_mgr.ScreenShotWeChatShare(this._file_path, this._share_type);
            }
        }

        private void ClearOldPic()
        {
            string persistentDataPath = Application.persistentDataPath;
            if (!Directory.Exists(persistentDataPath))
                return;
            FileInfo[] files = new DirectoryInfo(persistentDataPath).GetFiles();
            if (files != null)
            {
                for (int index = 0; index < files.Length; ++index)
                {
                    if (!(files[index].Name.Substring(files[index].Name.LastIndexOf(".") + 1) != "png"))
                        files[index].Delete();
                }
            }
        }

        public void SaveScreenshotPic(string filepath) => this._ifly_mgr.ScreenShotSave(filepath);

        public void RefreshPhotoView(string fullpath) => this._ifly_mgr.RefreshAndroidPhotoView(fullpath);

        public void StartExternalScreenShotView(ScreenShotCallback callback)
        {
            if (this._share_doing)
                return;
            this._share_callback = callback;
            this.CaptureScreenshot((object)null);
            this._share_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(this.ExternalReadyShare), (object)null);
        }

        private void ExternalReadyShare(object obj)
        {
            if (!File.Exists(XSingleton<XScreenShotMgr>.singleton.FilePath))
            {
                ++this._share_count;
                if (this._share_count > 30)
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip("Failed", "fece00");
                    this._share_doing = false;
                }
                else
                    this._share_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.ExternalReadyShare), (object)null);
            }
            else
            {
                XSingleton<XDebug>.singleton.AddLog("The screen file path: ", XSingleton<XScreenShotMgr>.singleton.FilePath);
                XSingleton<XDebug>.singleton.AddLog("File exist: ", File.Exists(XSingleton<XScreenShotMgr>.singleton.FilePath).ToString());
                switch (Application.platform)
                {
                    case RuntimePlatform.IPhonePlayer:
                    case RuntimePlatform.Android:
                        byte[] data = File.ReadAllBytes(XSingleton<XScreenShotMgr>.singleton.FilePath);
                        Texture2D texture2D = new Texture2D(2, 2);
                        bool flag = texture2D.LoadImage(data);
                        XSingleton<XDebug>.singleton.AddLog("Use file load");
                        if (flag)
                        {
                            int width = texture2D.width;
                            int height = texture2D.height;
                            XSingleton<XDebug>.singleton.AddLog("The width: ", width.ToString(), ", height: ", height.ToString());
                            if (width <= 600 && this._share_callback != null)
                                this._share_callback(false);
                            else
                                this.DoShareAction();
                            UnityEngine.Object.DestroyImmediate((UnityEngine.Object)texture2D, true);
                        }
                        else if (!flag && this._share_callback != null)
                            this._share_callback(false);
                        this._share_doing = false;
                        break;
                }
            }
        }

        private void DoShareAction() => this.ShareScreen(false);

        private IEnumerator StartDownloadLogo(string path)
        {
            XSingleton<XDebug>.singleton.AddLog(nameof(StartDownloadLogo));
            this._downloader = new WWW(path);
            yield return (object)this._downloader;
            while (!this._downloader.isDone)
                yield return (object)this._downloader;
            XSingleton<XDebug>.singleton.AddLog("Will do share, local icon: ", this._logo_local_path);
            XSingleton<XDebug>.singleton.AddLog("IsDone: ", this._downloader.isDone.ToString(), ", error: ", this._downloader.error);
            if (this._downloader.isDone && string.IsNullOrEmpty(this._downloader.error))
            {
                byte[] bs = this._downloader.bytes;
                if (bs != null)
                {
                    try
                    {
                        File.WriteAllBytes(this._logo_local_path, bs);
                    }
                    catch (Exception ex)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog("write file local failed!", ex.Message);
                    }
                    XSingleton<XDebug>.singleton.AddLog("Is icon exsit: ", File.Exists(this._logo_local_path).ToString());
                    if (File.Exists(this._logo_local_path))
                        this.DownLoadCallback();
                }
                bs = (byte[])null;
            }
            this._downloader.Dispose();
            this._downloader = (WWW)null;
        }

        private void DownLoadCallback()
        {
            if (this._ifly_mgr == null)
                return;
            ShareTable.RowData shareInfoById = XScreenShotShareDocument.GetShareInfoById(this._share_index);
            string[] strArray = shareInfoById.Link.Split('|');
            XSingleton<XDebug>.singleton.AddLog("Links: ", shareInfoById.Link);
            if (XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ)
            {
                string url = this._url;
                if (string.IsNullOrEmpty(url))
                    url = string.Format(strArray[0], this._params);
                this._ifly_mgr.ShareQZoneLink(shareInfoById.Title, shareInfoById.Desc, url, this._logo_local_path, this._share_session);
            }
            else
            {
                if (XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_WeChat)
                    return;
                string url = this._url;
                if (string.IsNullOrEmpty(url))
                    url = string.Format(strArray.Length > 1 ? strArray[1] : strArray[0], this._params);
                if (this._tag == ShareTagType.Invite_Tag)
                    this._ifly_mgr.ShareWechatLink(shareInfoById.Title, this._logo_local_path, url, this._share_session);
                else if (this._tag == ShareTagType.GiftBag_Tag)
                    this._ifly_mgr.ShareWechatLinkWithMediaTag(shareInfoById.Title, this._logo_local_path, url, this._share_session, "MSG_GIFT_PACKS_FD");
            }
        }

        public void DoShareWithLink(
          int shareindex,
          bool issession = false,
          ShareTagType tag = ShareTagType.Invite_Tag,
          string url = null,
          params object[] args)
        {
            this.SendStatisticToServer(ShareOpType.Share, DragonShareType.ActivityShare);
            ShareTable.RowData shareInfoById = XScreenShotShareDocument.GetShareInfoById(shareindex);
            XSingleton<XDebug>.singleton.AddLog("Will doshare with link");
            if (shareInfoById == null)
                return;
            this._share_index = shareindex;
            this._share_session = issession;
            this._tag = tag;
            this._params = args;
            this._url = url;
            if (File.Exists(this._logo_local_path))
                File.Delete(this._logo_local_path);
            XSingleton<XDebug>.singleton.AddLog("Icon: ", shareInfoById.Icon);
            XSingleton<XChatIFlyMgr>.singleton.IFLYMGR.GetMonoBehavior().StartCoroutine(this.StartDownloadLogo(shareInfoById.Icon));
        }

        public void SendStatisticToServer(ShareOpType op, DragonShareType type) => XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_ShareReport()
        {
            Data = {
        type = (int) type,
        op = (int) type
      }
        });
    }
}
