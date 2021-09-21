// Decompiled with JetBrains decompiler
// Type: XMainClient.XChatIFlyMgr
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XChatIFlyMgr : XSingleton<XChatIFlyMgr>
    {
        private static readonly float MIN_RECORD_LENGTH = 0.3f;
        private static readonly float AUDIO_TIME_OUT = 10f;
        private static int CLEAR_AUDIO_COUNT = 20;
        private IXIFlyMgr _ifly_mgr = (IXIFlyMgr)null;
        private string audiotxt = "";
        private VoiceUsage _usage = VoiceUsage.CHAT;
        private string _upload_file = "";
        private float _record_start = 0.0f;
        private float _record_length = 0.0f;
        private string cachePath = "";
        private ChatChannelType _channel_type = ChatChannelType.DEFAULT;
        private ChatInfo _download_audio = (ChatInfo)null;
        private uint _auto_play_timer = 0;
        private uint _record_timer = 0;
        private uint _translate_timer = 0;
        private uint _prepare_record_time = 0;
        private bool _is_recording = false;
        private bool _enable_auto_play = false;
        private EndRecordCallBack _callback = (EndRecordCallBack)null;
        private float _try_trans_start_time = 0.0f;
        private uint _txt_length_limit;
        private uint _windows_audio_token;
        private bool[] _auto_play_enable_channel = new bool[XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.ChannelNum)];
        private List<ChatInfo> m_lAutoPlayAudioList;
        private Dictionary<ulong, string> _local_audio = new Dictionary<ulong, string>();
        private List<ChatInfo> _auto_play_list = new List<ChatInfo>();
        private int MAX_DELETE_CNT = 100;
        private UpLoadAudioRes lastAudoRes;
        private static ulong lastFileID = 0;

        public bool IsAutoPlayEnable => this._enable_auto_play;

        public IXIFlyMgr IFLYMGR => this._ifly_mgr;

        public Dictionary<ulong, string> LocalAudio => this._local_audio;

        public List<ChatInfo> AutoPlayAudioList
        {
            get
            {
                if (this.m_lAutoPlayAudioList == null)
                    this.m_lAutoPlayAudioList = new List<ChatInfo>();
                return this.m_lAutoPlayAudioList;
            }
            set => this.m_lAutoPlayAudioList = value;
        }

        public XChatIFlyMgr()
        {
            for (int index = 0; index < XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.ChannelNum); ++index)
                this._auto_play_enable_channel[index] = index != XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.Group);
        }

        public void InitFlyMgr()
        {
            if (this._ifly_mgr == null)
                this._ifly_mgr = XUpdater.XUpdater.XGameRoot.GetComponent("XIFlyMgr") as IXIFlyMgr;
            if (this._ifly_mgr != null)
            {
                this._ifly_mgr.SetCallback(new System.Action<string>(this.RecoganizeCallback));
                this._ifly_mgr.SetVoiceCallback(new System.Action<string>(this.VoiceVolumeCallback));
            }
            this._txt_length_limit = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID).GetRawData(ChatChannelType.World).length / 3U;
        }

        public bool NeedClear()
        {
            try
            {
                string audioCachePath = this.GetAudioCachePath();
                if (Directory.Exists(audioCachePath))
                {
                    FileInfo[] files = new DirectoryInfo(audioCachePath).GetFiles();
                    if (files != null && files.Length > XChatIFlyMgr.CLEAR_AUDIO_COUNT)
                        return true;
                }
                string persistentDataPath = Application.persistentDataPath;
                if (Directory.Exists(persistentDataPath))
                {
                    FileInfo[] files = new DirectoryInfo(persistentDataPath).GetFiles();
                    if (files != null && files.Length > XChatIFlyMgr.CLEAR_AUDIO_COUNT)
                        return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public void ClearAudioCache()
        {
            string audioCachePath = this.GetAudioCachePath();
            if (Directory.Exists(audioCachePath))
            {
                FileInfo[] files = new DirectoryInfo(audioCachePath).GetFiles();
                if (files != null)
                {
                    int num = Mathf.Min(this.MAX_DELETE_CNT, files.Length);
                    for (int index = 0; index < num; ++index)
                    {
                        string extension = files[index].Extension;
                        if (extension.Equals(".mp3") || extension.Equals(".sound"))
                        {
                            XSingleton<XDebug>.singleton.AddLog("delete: ", files[index].Name, " ext: ", extension);
                            try
                            {
                                this.RemoveLocalAudio(files[index].Name);
                                File.Delete(files[index].FullName);
                            }
                            catch
                            {
                                XSingleton<XDebug>.singleton.AddErrorLog("Delete file error, ", files[index].FullName);
                            }
                        }
                    }
                }
            }
            string persistentDataPath = Application.persistentDataPath;
            if (!Directory.Exists(persistentDataPath))
                return;
            FileInfo[] files1 = new DirectoryInfo(persistentDataPath).GetFiles();
            if (files1 != null)
            {
                int num = Mathf.Min(this.MAX_DELETE_CNT, files1.Length);
                for (int index = 0; index < num; ++index)
                {
                    string extension = files1[index].Extension;
                    if (extension.Equals(".mp3") || extension.Equals(".sound"))
                    {
                        XSingleton<XDebug>.singleton.AddLog("delete: ", files1[index].Name, " ext: ", extension);
                        try
                        {
                            this.RemoveLocalAudio(files1[index].Name);
                            File.Delete(files1[index].FullName);
                        }
                        catch
                        {
                            XSingleton<XDebug>.singleton.AddErrorLog("Delete apollo file error, ", files1[index].FullName);
                        }
                    }
                }
            }
        }

        private void RemoveLocalAudio(string name)
        {
            ulong result = 0;
            ulong.TryParse(name, out result);
            if (!this._local_audio.ContainsKey(result))
                return;
            this._local_audio.Remove(result);
        }

        public void RemoveOldRecordFile()
        {
            string audioCachePath = this.GetAudioCachePath();
            if (!Directory.Exists(audioCachePath))
                return;
            FileInfo[] files = new DirectoryInfo(audioCachePath).GetFiles();
            if (files != null)
            {
                for (int index = 0; index < files.Length; ++index)
                {
                    if (!(files[index].Name.Substring(files[index].Name.LastIndexOf(".") + 1) != "pcm"))
                    {
                        try
                        {
                            files[index].Delete();
                            break;
                        }
                        catch
                        {
                            XSingleton<XDebug>.singleton.AddLog("Delete file failed: ", files[index].Name);
                            break;
                        }
                    }
                }
            }
        }

        public void GenerateAudioFiles(int num)
        {
            string audioCachePath = this.GetAudioCachePath();
            if (Directory.Exists(audioCachePath))
            {
                FileInfo[] files = new DirectoryInfo(audioCachePath).GetFiles();
                if (files != null)
                {
                    for (int index1 = 0; index1 < files.Length; ++index1)
                    {
                        if (files[index1].Name.Substring(files[index1].Name.LastIndexOf(".") + 1) == "mp3")
                        {
                            for (int index2 = 0; index2 < num; ++index2)
                            {
                                string str = audioCachePath + "/" + index2.ToString() + ".mp3";
                                if (!File.Exists(str))
                                    File.Copy(files[index1].FullName, str);
                            }
                            break;
                        }
                    }
                }
            }
            string persistentDataPath = Application.persistentDataPath;
            if (!Directory.Exists(persistentDataPath))
                return;
            FileInfo[] files1 = new DirectoryInfo(persistentDataPath).GetFiles();
            if (files1 != null)
            {
                for (int index3 = 0; index3 < files1.Length; ++index3)
                {
                    if (files1[index3].Name.Substring(files1[index3].Name.LastIndexOf(".") + 1) == "sound")
                    {
                        for (int index4 = 0; index4 < num; ++index4)
                        {
                            string str = persistentDataPath + "/" + index4.ToString() + ".sound";
                            if (!File.Exists(str))
                                File.Copy(files1[index3].FullName, str);
                        }
                        break;
                    }
                }
            }
        }

        public bool IsIFlyListening() => this._ifly_mgr != null && this._ifly_mgr.IsIFlyListening();

        public bool IsRecording() => this._is_recording;

        public void EnableAutoPlay(bool enable)
        {
            XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
            if (((specificDocument == null ? 0 : (specificDocument.roomState == XRadioDocument.BigRoomState.InRoom ? 1 : 0)) & (enable ? 1 : 0)) != 0)
                return;
            XSingleton<XDebug>.singleton.AddLog("Enable auto play: ", enable.ToString());
            this._enable_auto_play = enable;
        }

        public void SetBackMusicOn(bool on)
        {
            XAudioOperationArgs xaudioOperationArgs = XEventPool<XAudioOperationArgs>.GetEvent();
            xaudioOperationArgs.IsAudioOn = on;
            xaudioOperationArgs.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xaudioOperationArgs);
        }

        public void SetChannelAutoPlay(ChatChannelType type, bool auto)
        {
            if (XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(type) >= this._auto_play_enable_channel.Length)
                return;
            this._auto_play_enable_channel[XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(type)] = auto;
        }

        public bool IsChannelAutoPlayEnable(ChatChannelType type) => XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(type) < this._auto_play_enable_channel.Length && this._auto_play_enable_channel[XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(type)];

        private void setRadioOn(bool on) => XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID)?.MuteSounds(!on);

        public void StartRecord(VoiceUsage usage = VoiceUsage.CHAT, EndRecordCallBack callback = null)
        {
            if (this._ifly_mgr == null || !this._ifly_mgr.IsInited())
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CHAT_INIT_FAILED"), "fece00");
            else if (DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.isBroadcast)
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_VOICE_BROAD"), "fece00");
            else if (XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID).isHosting())
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_VOICE_RADIO"), "fece00");
            }
            else
            {
                this.StopAutoPlay();
                this._ifly_mgr.Cancel();
                this.SetBackMusicOn(false);
                this.setRadioOn(false);
                this.RemoveOldRecordFile();
                XSingleton<XTimerMgr>.singleton.KillTimer(this._translate_timer);
                this._translate_timer = 0U;
                DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>.singleton.SetVisible(true, true);
                this._usage = usage;
                this._callback = callback;
                XSingleton<XDebug>.singleton.AddLog("Record StartTime: ", Time.time.ToString());
                switch (Application.platform)
                {
                    case RuntimePlatform.IPhonePlayer:
                    case RuntimePlatform.Android:
                        this.audiotxt = "";
                        break;
                    default:
                        this.audiotxt = DateTime.Now.ToString();
                        this._windows_audio_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(this.RefreshWindowsVoice), (object)null);
                        break;
                }
                if (usage == VoiceUsage.CHAT)
                    this._prepare_record_time = XSingleton<XTimerMgr>.singleton.SetTimer(0.15f, new XTimerMgr.ElapsedEventHandler(this.DoStartRecord), (object)null);
                else
                    this.DoStartRecord((object)null);
            }
        }

        private void DoStartRecord(object obj)
        {
            this._is_recording = true;
            this._record_start = Time.realtimeSinceStartup;
            if (this._ifly_mgr != null)
            {
                try
                {
                    this._ifly_mgr.StartRecord();
                }
                catch
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("IFly Start record error");
                }
            }
            this._record_timer = XSingleton<XTimerMgr>.singleton.SetTimer(10.5f, new XTimerMgr.ElapsedEventHandler(this.RecordTimeOut), (object)null);
        }

        private void RefreshWindowsVoice(object obj)
        {
            DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>.singleton.OnSetVolume((uint)XSingleton<XCommon>.singleton.RandomInt(0, 7));
            this._windows_audio_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(this.RefreshWindowsVoice), (object)null);
        }

        public void RecoganizeCallback(string txt)
        {
            if ((long)this.audiotxt.Length > (long)this._txt_length_limit)
                return;
            if ((long)(this.audiotxt.Length + txt.Length) <= (long)this._txt_length_limit)
                this.audiotxt += txt;
            else if ((int)this._txt_length_limit - (this.audiotxt.Length + 1) > 0)
                this.audiotxt += txt.Substring(0, (int)this._txt_length_limit - (this.audiotxt.Length + 1));
        }

        public void VoiceVolumeCallback(string volume)
        {
            uint result = 0;
            uint.TryParse(volume, out result);
            DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>.singleton.OnSetVolume((uint)((int)result * 7 + 3) / 25U);
        }

        public void StopRecord(bool cancel)
        {
            if (this._ifly_mgr == null || !this._ifly_mgr.IsInited())
                return;
            DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>.singleton.SetVisible(false, true);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._windows_audio_token);
            if (this._prepare_record_time > 0U)
            {
                XSingleton<XTimerMgr>.singleton.KillTimer(this._prepare_record_time);
                this._prepare_record_time = 0U;
            }
            this.SetBackMusicOn(true);
            this.setRadioOn(true);
            if (!this._is_recording)
                return;
            if (this._record_timer > 0U)
            {
                XSingleton<XTimerMgr>.singleton.KillTimer(this._record_timer);
                this._record_timer = 0U;
            }
            if (!cancel)
            {
                this._ifly_mgr.StopRecord();
                this._record_length = Time.realtimeSinceStartup - this._record_start;
                this._record_length = (double)this._record_length > 10.0 ? 10f : this._record_length;
                XSingleton<XDebug>.singleton.AddLog("Record StopTime: ", Time.time.ToString());
                if ((double)this._record_length <= (double)XChatIFlyMgr.MIN_RECORD_LENGTH)
                {
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_RECORD_TOO_SHORT"), "fece00");
                }
                else
                {
                    DateTime now = DateTime.Now;
                    // ISSUE: variable of a boxed type
                    var hour = (ValueType)now.Hour;
                    now = DateTime.Now;
                    // ISSUE: variable of a boxed type
                    var minute = (ValueType)now.Minute;
                    now = DateTime.Now;
                    // ISSUE: variable of a boxed type
                    var second = (ValueType)now.Second;
                    this._translate_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.DelayTransMp3), (object)string.Format("{0:D2}{1:D2}{2:D2}", (object)hour, (object)minute, (object)second));
                    this._try_trans_start_time = Time.time;
                }
            }
            this._is_recording = false;
        }

        private void RecordTimeOut(object obj)
        {
            if (!this._is_recording)
                return;
            this.StopRecord(false);
            if (this._callback == null)
                return;
            this._callback();
        }

        public void DelayTransMp3(object obj)
        {
            string destFileName = obj as string;
            if ((double)Time.time - (double)this._try_trans_start_time >= 0.300000011920929)
                this.StartTransMp3(destFileName);
            else if (this._ifly_mgr != null && (this._ifly_mgr.IsIFlyListening() || !this._ifly_mgr.IsRecordFileExist()))
                this._translate_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.DelayTransMp3), (object)destFileName);
            else
                this.StartTransMp3(destFileName);
        }

        public void StartTransMp3(string destFileName)
        {
            string filePath = "";
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    if (this._ifly_mgr != null)
                    {
                        if (!this._ifly_mgr.IsRecordFileExist())
                        {
                            XSingleton<XDebug>.singleton.AddErrorLog("Record busy, can't record");
                            return;
                        }
                        filePath = this._ifly_mgr.StartTransMp3(destFileName);
                        break;
                    }
                    break;
                default:
                    filePath = "Assets/Editor/Mp3Sample/sample.mp3";
                    break;
            }
            this.StartUpLoadMp3(filePath);
        }

        public void StartUpLoadMp3(string filePath)
        {
            XSingleton<XDebug>.singleton.AddLog("Will start upload mp3, txt:", this.audiotxt);
            RpcC2T_UpLoadAudioToGate upLoadAudioToGate = new RpcC2T_UpLoadAudioToGate();
            upLoadAudioToGate.oArg.audio = File.ReadAllBytes(filePath);
            upLoadAudioToGate.oArg.text = Encoding.UTF8.GetBytes(this.audiotxt);
            upLoadAudioToGate.oArg.srctype = 0U;
            this._upload_file = filePath;
            XSingleton<XDebug>.singleton.AddLog("The audio length: ", upLoadAudioToGate.oArg.audio.Length.ToString());
            XSingleton<XClientNetwork>.singleton.Send((Rpc)upLoadAudioToGate);
        }

        public void UpLoadMp3Res(UpLoadAudioRes res)
        {
            uint audioTime = (uint)((double)this._record_length * 1000.0) + 1U;
            XSingleton<XDebug>.singleton.AddLog("Will upload res mp3, usage: ");
            if (this._usage == VoiceUsage.CHAT)
            {
                this._local_audio[res.audiodownuid] = this._upload_file;
                this.lastAudoRes = res;
                if (!DlgBase<XChatView, XChatBehaviour>.singleton.CheckWorldSendMsg(true) || audioTime >= 9000U && this.audiotxt.Length <= (int)(audioTime / 2000U))
                    return;
                XSingleton<XDebug>.singleton.AddLog("Will Do send world chat");
                DlgBase<XChatView, XChatBehaviour>.singleton.SendVoiceChat(this.audiotxt, DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType, res.audiodownuid, (float)audioTime * 1f);
            }
            else if (this._usage == VoiceUsage.ANSWER)
            {
                XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
                XSingleton<XDebug>.singleton.AddLog("Will Do send answer chat");
                specificDocument.SendAnswer(this.audiotxt, res.audiodownuid, audioTime);
            }
            else if (this._usage == VoiceUsage.FLOWER_REPLY)
            {
                this._local_audio[res.audiodownuid] = this._upload_file;
                this.lastAudoRes = res;
                DlgBase<XChatView, XChatBehaviour>.singleton.SendVoiceChat(this.audiotxt, ChatChannelType.Friends, res.audiodownuid, (float)audioTime * 1f);
            }
            else if (this._usage == VoiceUsage.MENTORHIP)
            {
                this._local_audio[res.audiodownuid] = this._upload_file;
                this.lastAudoRes = res;
            }
            else
            {
                if (this._usage != VoiceUsage.GUILDCOLLECT)
                    return;
                XExchangeItemDocument specificDocument = XDocuments.GetSpecificDocument<XExchangeItemDocument>(XExchangeItemDocument.uuID);
                XSingleton<XDebug>.singleton.AddLog("Will Do send voice chat in guild collect");
                specificDocument.SendChat(this.audiotxt, res.audiodownuid, audioTime);
            }
        }

        public void ResendLastWorldChat()
        {
            if (XChatDocument.UseApollo)
            {
                XSingleton<XChatApolloMgr>.singleton.ResendLastWorldChat();
            }
            else
            {
                uint num = (double)this._record_length >= 1.0 ? (uint)this._record_length : 1U;
                if (this.lastAudoRes != null)
                    DlgBase<XChatView, XChatBehaviour>.singleton.SendVoiceChat(this.audiotxt, DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType, this.lastAudoRes.audiodownuid, (float)num * 1f);
            }
        }

        public void DownloadMp3(ChatInfo info)
        {
            XSingleton<XDebug>.singleton.AddLog("Will Download mp3");
            this._download_audio = info;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2A_GetAudioListReq()
            {
                oArg = {
          audioUidList = {
            info.mAudioId
          }
        }
            });
        }

        public void DownloadMp3Res(GetAudioListRes res)
        {
            if (res.dataList == null || res.dataList.Count == 0)
            {
                XSingleton<XDebug>.singleton.AddLog("Download res error");
                this.DoStartAutoPlay((object)null);
            }
            else
            {
                AudioBrief data = res.dataList[0];
                string audioCachePath1 = this.GetAudioCachePath();
                ulong audioUid = data.audioUid;
                string str1 = audioUid.ToString();
                string str2 = audioCachePath1 + "/" + str1 + ".mp3";
                if (this._download_audio.mChannelId != ChatChannelType.DEFAULT)
                {
                    string audioCachePath2 = this.GetAudioCachePath();
                    audioUid = data.audioUid;
                    string str3 = audioUid.ToString();
                    str2 = audioCachePath2 + "/" + str3 + ".sound";
                }
                File.WriteAllBytes(str2, data.audio);
                this._local_audio[this._download_audio.mAudioId] = str2;
                XSingleton<XDebug>.singleton.AddLog("Download OK, will start play mp3, audiotime: ", this._download_audio.mAudioTime.ToString());
                this.StartPlayMp3(str2, this._download_audio.mAudioTime, this._download_audio);
                this.ChatShowInfo(this._download_audio);
            }
        }

        public void DownLoadMp3Error() => this.DoStartAutoPlay((object)null);

        public void StartPlayMp3(string filepath, uint audiotime, ChatInfo info)
        {
            IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
            xapolloManager.SetApolloMode(2);
            XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
            int num = XSingleton<XGlobalConfig>.singleton.GetInt("SetSpeakerVolume");
            xapolloManager.SetMusicVolum((int)((double)num * (double)specificDocument.voiceVolme));
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    if (File.Exists(filepath))
                    {
                        try
                        {
                            XSingleton<XChatApolloMgr>.singleton.StartPlayVoice(filepath);
                            break;
                        }
                        catch (Exception ex)
                        {
                            XSingleton<XDebug>.singleton.AddLog("StartPlayMp3, Find play exception, ", ex.ToString());
                            break;
                        }
                    }
                    else
                    {
                        XSingleton<XDebug>.singleton.AddLog("File not found, ", filepath);
                        XSingleton<XTimerMgr>.singleton.KillTimer(this._auto_play_timer);
                        this._auto_play_timer = XSingleton<XTimerMgr>.singleton.SetGlobalTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.DoStartAutoPlay), (object)null);
                        return;
                    }
                default:
                    XSingleton<XChatApolloMgr>.singleton.StartPlayVoice(filepath);
                    break;
            }
            XSingleton<XTimerMgr>.singleton.KillTimer(this._auto_play_timer);
            if (audiotime <= 1000U)
                audiotime = 1000U;
            this._auto_play_timer = XSingleton<XTimerMgr>.singleton.SetGlobalTimer((float)((double)(audiotime + 10U) * 1.0 / 1000.0), new XTimerMgr.ElapsedEventHandler(this.DoStartAutoPlay), (object)null);
            XSingleton<XDebug>.singleton.AddLog("Will start time autoplay, time: ", audiotime.ToString());
            this.DeleteAudio(info.mAudioId);
        }

        public void DoStartPlayChatInfo(ChatInfo info)
        {
            this.StopAutoPlay();
            this.StartPlayInfo(info);
        }

        public void StartPlayInfo(ChatInfo info)
        {
            if (this._is_recording)
                XSingleton<XDebug>.singleton.AddLog("StartPlayInfo, isrecord will return");
            else if (this._local_audio.ContainsKey(info.mAudioId) && File.Exists(this._local_audio[info.mAudioId]))
            {
                this.ChatShowInfo(info);
                this.StartPlayMp3(this._local_audio[info.mAudioId], info.mAudioTime, info);
            }
            else
                this.DownloadMp3(info);
        }

        private void DeleteAudio(ulong audioid)
        {
            if (XChatIFlyMgr.lastFileID == 0UL || (long)XChatIFlyMgr.lastFileID == (long)audioid)
            {
                XChatIFlyMgr.lastFileID = audioid;
            }
            else
            {
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    this.DeleteFile(Application.temporaryCachePath + "/" + (object)XChatIFlyMgr.lastFileID + ".mp3");
                    this.DeleteFile(Application.temporaryCachePath + "/" + (object)XChatIFlyMgr.lastFileID + ".sound");
                }
                else
                {
                    this.DeleteFile(Application.persistentDataPath + "/" + (object)XChatIFlyMgr.lastFileID + ".sound");
                    this.DeleteFile(Application.persistentDataPath + "/" + (object)XChatIFlyMgr.lastFileID + ".mp3");
                }
                XChatIFlyMgr.lastFileID = audioid;
            }
        }

        private void DeleteFile(string path)
        {
            XSingleton<XDebug>.singleton.AddLog("delete: ", path);
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                    return;
                File.Delete(path);
            }
            catch
            {
                XSingleton<XDebug>.singleton.AddWarningLog("delete fail" + path);
            }
        }

        public void StartPlayAudioId(ulong audioid) => this.StartPlayInfo(new ChatInfo()
        {
            mAudioId = audioid,
            mChannelId = ChatChannelType.DEFAULT
        });

        public void ClearPlayList() => this._auto_play_list.Clear();

        public void DoStartAutoPlay(object obj)
        {
            if (this._enable_auto_play)
            {
                this.StartAutoPlay();
            }
            else
            {
                XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.SetApolloMode(0);
                this.SetBackMusicOn(true);
                this.setRadioOn(true);
                this._auto_play_timer = 0U;
            }
        }

        public void StartAutoPlay(bool rank = true, bool clearTimeout = true)
        {
            if (clearTimeout)
                this.ClearTimeOutInfo();
            if (rank)
                this.RankAutoPlayList();
            XSingleton<XDebug>.singleton.AddLog("StartAutoPlay, num:", this._auto_play_list.Count.ToString());
            if (this._auto_play_list.Count == 0)
            {
                XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.SetApolloMode(0);
                this.SetBackMusicOn(true);
                this.setRadioOn(true);
                XSingleton<XDebug>.singleton.AddLog("StartAutoplay setback music on");
                this._auto_play_timer = 0U;
            }
            else
            {
                XSingleton<XDebug>.singleton.AddLog("StartAutoplay setback music off");
                this.SetBackMusicOn(false);
                this.setRadioOn(false);
                if (this._auto_play_list.Count <= 0)
                    return;
                this.StartPlayInfo(this._auto_play_list[0]);
                this._auto_play_list.RemoveAt(0);
            }
        }

        public void StopAutoPlay()
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._auto_play_timer);
            this._auto_play_timer = 0U;
            XSingleton<XChatApolloMgr>.singleton.StopPlayVoice();
        }

        public void InsertAutoPlayList(ChatInfo info, bool clearTimeOut = true)
        {
            this._auto_play_list.Insert(0, info);
            this.StopAutoPlay();
            XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.SetApolloMode(2);
            try
            {
                this.StartAutoPlay(false, clearTimeOut);
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddLog("InsertAutoPlayList exception, ", ex.ToString());
            }
        }

        public bool AddAutoPlayList(ChatInfo info)
        {
            if (!XSingleton<XClientNetwork>.singleton.IsWifiEnable() && this.IsChannelAutoPlayEnable(ChatChannelType.ZeroChannel) || !this.IsChannelAutoPlayEnable(info.mChannelId) || this._channel_type != ChatChannelType.DEFAULT && info.mChannelId != this._channel_type || XSingleton<XScene>.singleton.SceneID == 100U || XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < 10U && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible())
                return false;
            this._auto_play_list.Add(info);
            if (this._auto_play_timer == 0U && this._enable_auto_play && !this.IsRecording())
                this.StartAutoPlay();
            return true;
        }

        public void RankAutoPlayList()
        {
        }

        private void ChatShowInfo(ChatInfo info)
        {
            if (info.isAudioPlayed || info.mChannelId == ChatChannelType.DEFAULT)
                return;
            info.isAudioPlayed = true;
            XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID).ReceiveChatInfo(info);
        }

        public void ClearTimeOutInfo()
        {
            List<ChatInfo> chatInfoList = new List<ChatInfo>();
            for (int index = 0; index < this._auto_play_list.Count; ++index)
            {
                if ((DateTime.Now - this._auto_play_list[index].mTime).TotalSeconds <= (double)XChatIFlyMgr.AUDIO_TIME_OUT)
                    chatInfoList.Add(this._auto_play_list[index]);
                else
                    this.ChatShowInfo(this._auto_play_list[index]);
            }
            this._auto_play_list = chatInfoList;
        }

        public void SetAutoPlayChannel(ChatChannelType type)
        {
            if (type != ChatChannelType.DEFAULT)
            {
                List<ChatInfo> chatInfoList = new List<ChatInfo>();
                for (int index = 0; index < this._auto_play_list.Count; ++index)
                {
                    if (this._auto_play_list[index].mChannelId == type)
                        chatInfoList.Add(this._auto_play_list[index]);
                    else
                        this.ChatShowInfo(this._auto_play_list[index]);
                }
                this._auto_play_list = chatInfoList;
            }
            this._channel_type = type;
        }

        private string GetString(string path) => string.IsNullOrEmpty(path) ? path : path.Replace('\\', '/');

        public string GetAudioCachePath()
        {
            if (string.IsNullOrEmpty(this.cachePath))
            {
                switch (Application.platform)
                {
                    case RuntimePlatform.IPhonePlayer:
                        this.cachePath = Application.temporaryCachePath;
                        break;
                    case RuntimePlatform.Android:
                        this.cachePath = Application.persistentDataPath;
                        break;
                    default:
                        this.cachePath = Application.persistentDataPath;
                        break;
                }
            }
            return this.cachePath;
        }

        public void OnOpenWebView()
        {
            if (this._ifly_mgr == null)
                return;
            this._ifly_mgr.OnOpenWebView();
        }

        public void OnCloseWebView()
        {
            if (this._ifly_mgr == null)
                return;
            this._ifly_mgr.OnCloseWebView();
        }

        public void OnWebViewScreenLock(bool islock)
        {
            XSingleton<XDebug>.singleton.AddLog("Webview islock: ", islock.ToString());
            if (this._ifly_mgr == null)
                return;
            this._ifly_mgr.OnScreenLock(islock);
        }

        public void OnEvalWebViewJs(string script)
        {
            if (this._ifly_mgr == null)
                return;
            this._ifly_mgr.OnEvalJsScript(script);
        }

        public void OnRefreshWebViewShow(bool show)
        {
            if (this._ifly_mgr == null)
                return;
            this._ifly_mgr.RefershWebViewShow(show);
        }

        public void RefreshWebViewConfig()
        {
            if (XSingleton<XEntityMgr>.singleton.Player == null || int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HideWebView")) == 1 || this._ifly_mgr == null)
                return;
            int platform = 0;
            switch (XSingleton<XLoginDocument>.singleton.Channel)
            {
                case XAuthorizationChannel.XAuthorization_QQ:
                    platform = 0;
                    break;
                case XAuthorizationChannel.XAuthorization_WeChat:
                    platform = 1;
                    break;
            }
            this._ifly_mgr.OnInitWebViewInfo(platform, XSingleton<XLoginDocument>.singleton.OpenID, XSingleton<XClientNetwork>.singleton.ServerID.ToString(), XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.RoleID.ToString(), XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
        }
    }
}
