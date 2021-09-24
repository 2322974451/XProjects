using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XChatApolloMgr : XSingleton<XChatApolloMgr>
	{

		public bool IsRecording
		{
			get
			{
				return this._is_recording;
			}
		}

		public bool IsInRecordingState
		{
			get
			{
				return this._is_recording || this._prepare_record_time > 0U;
			}
		}

		public void InitApolloEngine()
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			int num = xapolloManager.InitApolloEngine(XChatDocument.m_ApolloIPtable[0], XChatDocument.m_ApolloIPtable[1], XChatDocument.m_ApolloIPtable[2], XChatDocument.m_ApolloIPtable[3], XChatDocument.m_ApolloKey, XChatDocument.m_ApolloKey.Length);
			bool flag = num == 0;
			if (flag)
			{
				this._engine_inited = true;
			}
		}

		public void StartRecord(VoiceUsage usage = VoiceUsage.CHAT, EndRecordCallBack callback = null)
		{
			bool flag = !this._engine_inited;
			if (!flag)
			{
				XSingleton<XDebug>.singleton.AddLog("Start apollo record", null, null, null, null, null, XDebugColor.XDebug_None);
				bool isBroadcast = DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.isBroadcast;
				if (isBroadcast)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_VOICE_BROAD"), "fece00");
				}
				else
				{
					XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
					bool flag2 = specificDocument.isHosting();
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FM_VOICE_RADIO"), "fece00");
					}
					else
					{
						bool is_uploading = this._is_uploading;
						if (is_uploading)
						{
							bool flag3 = Time.realtimeSinceStartup - this._uploading_start <= 5f;
							if (flag3)
							{
								return;
							}
							this._is_uploading = false;
						}
						XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
						this.SetBackMusicOn(false);
						this.setRadioOn(false);
						DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>.singleton.SetVisible(true, true);
						this._callback = callback;
						this._usage = usage;
						this._record_start = Time.realtimeSinceStartup;
						this._prepare_record_time = XSingleton<XTimerMgr>.singleton.SetTimer(0.15f, new XTimerMgr.ElapsedEventHandler(this.DoStartRecord), null);
					}
				}
			}
		}

		private void DoStartRecord(object obj)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			int num = xapolloManager.SetApolloMode(2);
			XSingleton<XDebug>.singleton.AddLog("Will Do start apollo record, setmode2 res: ", num.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			this._record_filename = string.Format("{0:D2}{1:D2}{2:D2}.sound", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
			int num2 = xapolloManager.StartRecord(this._record_filename);
			bool flag = num2 != 0;
			if (flag)
			{
				xapolloManager.SetApolloMode(0);
			}
			else
			{
				this._is_recording = true;
				this._prepare_record_time = 0U;
				this._record_timer = XSingleton<XTimerMgr>.singleton.SetTimer(10.5f, new XTimerMgr.ElapsedEventHandler(this.RecordTimeOut), null);
				this._mic_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.RefreshMicLevel), null);
			}
		}

		private void RefreshMicLevel(object obj)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			int micLevel = xapolloManager.GetMicLevel();
			DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>.singleton.OnSetVolume((uint)(micLevel * 7 / 65535));
			this._mic_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.RefreshMicLevel), null);
		}

		private void RecordTimeOut(object obj)
		{
			bool flag = !this._is_recording;
			if (!flag)
			{
				this.StopRecord(false);
				bool flag2 = this._callback != null;
				if (flag2)
				{
					this._callback();
				}
			}
		}

		public void StopRecord(bool cancel)
		{
			XSingleton<XDebug>.singleton.AddLog("Will stop record", null, null, null, null, null, XDebugColor.XDebug_None);
			DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>.singleton.SetNormalHide(true);
			DlgBase<XChatVoiceStatusView, XChatVoiceStatusBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._mic_timer);
			this._mic_timer = 0U;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._prepare_record_time);
			this._prepare_record_time = 0U;
			this.SetBackMusicOn(true);
			this.setRadioOn(true);
			bool flag = !this._is_recording;
			if (!flag)
			{
				this._is_recording = false;
				this._record_length = Time.realtimeSinceStartup - this._record_start;
				XSingleton<XDebug>.singleton.AddLog("Will stop record, length:", this._record_length.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				bool flag2 = this._record_length <= XChatApolloMgr.MIN_RECORD_LENGTH;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_RECORD_TOO_SHORT"), "fece00");
					this._is_uploading = true;
					this.CancelRecord(null);
				}
				else
				{
					bool flag3 = this._record_timer > 0U;
					if (flag3)
					{
						XSingleton<XTimerMgr>.singleton.KillTimer(this._record_timer);
						this._record_timer = 0U;
					}
					bool flag4 = !cancel;
					if (flag4)
					{
						this._stop_record_count = 0;
						this._is_uploading = true;
						this.StopRecordProc(null);
					}
					else
					{
						this._stop_record_count = 0;
						this.CancelRecord(null);
					}
				}
			}
		}

		private void StopRecordProc(object obj)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			int num = xapolloManager.StopApolloRecord();
			XSingleton<XDebug>.singleton.AddLog("Will stop record", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = num != 0;
			if (flag)
			{
				this._stop_record_count = this._stop_record_count;
				bool flag2 = this._stop_record_count > 10;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("Stop record failed", null, null, null, null, null, XDebugColor.XDebug_None);
					this._is_uploading = false;
					xapolloManager.SetApolloMode(0);
				}
				else
				{
					this._stop_record_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.StopRecordProc), null);
				}
			}
			else
			{
				this.UploadRecordFile(this._record_filename);
			}
		}

		private void CancelRecord(object obj)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			int num = xapolloManager.StopApolloRecord();
			XSingleton<XDebug>.singleton.AddLog("Will Cancel record", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = num != 0;
			if (flag)
			{
				this._stop_record_count = this._stop_record_count;
				bool flag2 = this._stop_record_count > 10;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("Cancel record failed", null, null, null, null, null, XDebugColor.XDebug_None);
					this._is_uploading = false;
				}
				else
				{
					this._stop_record_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.CancelRecord), null);
				}
			}
			else
			{
				this._is_uploading = false;
			}
		}

		private int UploadRecordFile(string filename)
		{
			XSingleton<XDebug>.singleton.AddLog("Will apollo upload", null, null, null, null, null, XDebugColor.XDebug_None);
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			bool flag = !File.Exists(Application.persistentDataPath + "/" + filename);
			int result;
			if (flag)
			{
				this._is_uploading = false;
				result = -1;
			}
			else
			{
				int num = xapolloManager.UploadRecordFile(filename);
				this._upload_wait_time = 0;
				XSingleton<XDebug>.singleton.AddLog("UploadRecord file error: ", num.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				this.GetFileID(null);
				result = 0;
			}
			return result;
		}

		private void GetFileID(object obj)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			int apolloUploadStatus = xapolloManager.GetApolloUploadStatus();
			bool flag = apolloUploadStatus == 0;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("Upload success", null, null, null, null, null, XDebugColor.XDebug_None);
				this._file_id = xapolloManager.GetFileID();
				bool flag2 = !string.IsNullOrEmpty(this._file_id);
				if (flag2)
				{
					this._record_length = Time.realtimeSinceStartup - this._record_start;
					this._record_length = ((this._record_length > 10f) ? 10f : this._record_length);
					XSingleton<XDebug>.singleton.AddLog("Record StopTime: ", Time.time.ToString(), null, null, null, null, XDebugColor.XDebug_None);
					bool flag3 = this._record_length <= XChatApolloMgr.MIN_RECORD_LENGTH;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_RECORD_TOO_SHORT"), "fece00");
					}
					else
					{
						this.GetAudioText(this._file_id);
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("GetFileId failed", null, null, null, null, null, XDebugColor.XDebug_None);
					xapolloManager.SetApolloMode(0);
				}
			}
			else
			{
				bool flag4 = apolloUploadStatus == 11;
				if (flag4)
				{
					XSingleton<XDebug>.singleton.AddLog("Upload http busy", null, null, null, null, null, XDebugColor.XDebug_None);
					this._upload_wait_time++;
					bool flag5 = this._upload_wait_time >= 20;
					if (flag5)
					{
						XSingleton<XDebug>.singleton.AddLog("Upload http failed, times top", null, null, null, null, null, XDebugColor.XDebug_None);
						this._is_uploading = false;
					}
					else
					{
						this._upload_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.GetFileID), null);
					}
				}
				else
				{
					this._is_uploading = false;
					XSingleton<XDebug>.singleton.AddLog("GetFileId error", null, null, null, null, null, XDebugColor.XDebug_None);
					xapolloManager.SetApolloMode(0);
				}
			}
		}

		public void GetAudioText(string fileid)
		{
			RpcC2A_AudioText rpcC2A_AudioText = new RpcC2A_AudioText();
			rpcC2A_AudioText.oArg.file_id = fileid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2A_AudioText);
		}

		public void OnGotAudioTextError(AudioTextRes res)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			bool flag = xapolloManager != null;
			if (flag)
			{
				xapolloManager.SetApolloMode(0);
			}
		}

		public void OnGotAudioText(AudioTextRes res)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			this._audio_text = res.file_text;
			xapolloManager.SetApolloMode(0);
			this.StartUpLoadMp3();
		}

		public void StartUpLoadMp3()
		{
			XSingleton<XDebug>.singleton.AddLog("Will start upload mp3, txt:", this._audio_text);
			RpcC2T_UpLoadAudioToGate upLoadAudioToGate = new RpcC2T_UpLoadAudioToGate();
			string path = Application.persistentDataPath + "/" + this._record_filename;
			if (!File.Exists(path))
			{
				this._is_uploading = false;
			}
			else
			{
				switch (Application.platform)
				{
					case RuntimePlatform.IPhonePlayer:
					case RuntimePlatform.Android:
						upLoadAudioToGate.oArg.audio = File.ReadAllBytes(path);
						upLoadAudioToGate.oArg.text = Encoding.UTF8.GetBytes(this._audio_text);
						upLoadAudioToGate.oArg.srctype = 1U;
						XSingleton<XDebug>.singleton.AddLog("The audio length: ", upLoadAudioToGate.oArg.audio.Length.ToString());
						XSingleton<XClientNetwork>.singleton.Send((Rpc)upLoadAudioToGate);
						break;
					default:
						path = Application.persistentDataPath + "/record.sound";
						goto case RuntimePlatform.IPhonePlayer;
				}
			}
		}

		public void UpLoadAudioRes(UpLoadAudioRes res)
		{
			uint num = (uint)(this._record_length * 1000f) + 1U;
			XSingleton<XDebug>.singleton.AddLog("Will upload res mp3, usage: ", null, null, null, null, null, XDebugColor.XDebug_None);
			this._is_uploading = false;
			bool flag = this._usage == VoiceUsage.CHAT;
			if (flag)
			{
				XSingleton<XChatIFlyMgr>.singleton.LocalAudio[res.audiodownuid] = Application.persistentDataPath + "/" + this._record_filename;
				this.lastAudoRes = res;
				bool flag2 = DlgBase<XChatView, XChatBehaviour>.singleton.CheckWorldSendMsg(true, null, ChatChannelType.DEFAULT);
				if (flag2)
				{
					bool flag3 = num >= 9000U && this._audio_text.Length <= (int)(num / 2000U);
					if (!flag3)
					{
						XSingleton<XDebug>.singleton.AddLog("Will Do send world chat", null, null, null, null, null, XDebugColor.XDebug_None);
						DlgBase<XChatView, XChatBehaviour>.singleton.SendVoiceChat(this._audio_text, DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType, res.audiodownuid, num * 1f);
					}
				}
			}
			else
			{
				bool flag4 = this._usage == VoiceUsage.ANSWER;
				if (flag4)
				{
					XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
					XSingleton<XDebug>.singleton.AddLog("Will Do send answer chat", null, null, null, null, null, XDebugColor.XDebug_None);
					specificDocument.SendAnswer(this._audio_text, res.audiodownuid, num);
				}
				else
				{
					bool flag5 = this._usage == VoiceUsage.FLOWER_REPLY;
					if (flag5)
					{
						XSingleton<XChatIFlyMgr>.singleton.LocalAudio[res.audiodownuid] = Application.persistentDataPath + "/" + this._record_filename;
						this.lastAudoRes = res;
						DlgBase<XChatView, XChatBehaviour>.singleton.SendVoiceChat(this._audio_text, ChatChannelType.Friends, res.audiodownuid, num * 1f);
					}
					else
					{
						bool flag6 = this._usage == VoiceUsage.MENTORHIP;
						if (flag6)
						{
							XSingleton<XChatIFlyMgr>.singleton.LocalAudio[res.audiodownuid] = Application.persistentDataPath + "/" + this._record_filename;
							this.lastAudoRes = res;
						}
						else
						{
							bool flag7 = this._usage == VoiceUsage.GUILDCOLLECT;
							if (flag7)
							{
								XExchangeItemDocument specificDocument2 = XDocuments.GetSpecificDocument<XExchangeItemDocument>(XExchangeItemDocument.uuID);
								XSingleton<XDebug>.singleton.AddLog("Will Do send voice chat in guild collect", null, null, null, null, null, XDebugColor.XDebug_None);
								specificDocument2.SendChat(this._audio_text, res.audiodownuid, num);
							}
						}
					}
				}
			}
		}

		private void DoSendVoiceMsg(string fileid)
		{
			uint num = (uint)(this._record_length * 1000f) + 1U;
			XSingleton<XDebug>.singleton.AddLog("Will DoSendVoiceMsg ", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		private void setRadioOn(bool on)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			bool flag = specificDocument != null;
			if (flag)
			{
				specificDocument.MuteSounds(!on);
			}
		}

		public void SetBackMusicOn(bool on)
		{
			XAudioOperationArgs @event = XEventPool<XAudioOperationArgs>.GetEvent();
			@event.IsAudioOn = on;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public void StartPlayVoice(string filepath)
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			if (!File.Exists(filepath))
			{
				XSingleton<XDebug>.singleton.AddLog("Start Play Voice, File not exist: ", filepath);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Will play file: ", filepath);
				switch (Application.platform)
				{
					case RuntimePlatform.IPhonePlayer:
					case RuntimePlatform.Android:
						xapolloManager.StartPlayVoice(filepath);
						break;
					default:
						if (File.Exists(filepath))
						{
							xapolloManager.StartPlayVoice(filepath);
							break;
						}
						xapolloManager.StartPlayVoice(Application.persistentDataPath + "/record.sound");
						break;
				}
			}
		}

		public void StopPlayVoice()
		{
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			xapolloManager.StopPlayVoice();
		}

		public void ResendLastWorldChat()
		{
			uint num = (this._record_length >= 1f) ? ((uint)this._record_length) : 1U;
			bool flag = this.lastAudoRes != null;
			if (flag)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SendVoiceChat(this._audio_text, DlgBase<XChatView, XChatBehaviour>.singleton.activeChannelType, this.lastAudoRes.audiodownuid, num * 1f);
			}
		}

		private EndRecordCallBack _callback = null;

		private VoiceUsage _usage = VoiceUsage.CHAT;

		private bool _engine_inited = false;

		private uint _prepare_record_time = 0U;

		private uint _record_timer = 0U;

		private uint _mic_timer = 0U;

		private bool _is_recording = false;

		private float _record_start = 0f;

		private float _record_length = 0f;

		private bool _is_uploading = false;

		private float _uploading_start = 0f;

		private string _record_filename = "";

		private string _audio_text = "";

		private uint _upload_timer = 0U;

		private uint _stop_record_timer = 0U;

		private int _stop_record_count = 0;

		private int _upload_wait_time = 0;

		private string _file_id = "";

		private static readonly float MIN_RECORD_LENGTH = 0.3f;

		private UpLoadAudioRes lastAudoRes;

		private Dictionary<ulong, string> _local_audio = new Dictionary<ulong, string>();
	}
}
