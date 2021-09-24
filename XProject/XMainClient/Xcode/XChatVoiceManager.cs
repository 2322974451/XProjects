using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XChatVoiceManager : XSingleton<XChatVoiceManager>
	{

		public void Init(string name, ulong uid, string serverid, string serverwild, string guildwild)
		{
			XSingleton<XDebug>.singleton.AddLog("Will Init Speech", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XDebug>.singleton.AddLog("Will Sign out", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XChatVoiceManager>.singleton.AddMeeageNotify();
			XSingleton<XDebug>.singleton.AddLog("Will Login Speech", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		public void UnInit()
		{
		}

		public void AddMeeageNotify()
		{
		}

		private void OnLoginBack(int result, int userId, string thirdUseName, string msg)
		{
			bool flag = result == 0;
			if (flag)
			{
				this.IsLoginSuccess = true;
				this.AddSpriteYuYinId(thirdUseName, userId);
				this.AddVoiceChannelWild(ChatChannelType.World);
				this.AddVoiceChannelWild(ChatChannelType.Guild);
				XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.OnAddTeamChannel), null);
			}
			else
			{
				this.IsLoginSuccess = false;
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_LOGIN_AUDIO_FAILED"), "fece00");
			}
		}

		public void OnAddTeamChannel(object obj)
		{
			this.AddVoiceChannel(ChatChannelType.Team);
		}

		private void OnPrivateNotify(int userID, int audioTime, int type, string name, string data, string attach, string ext)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			bool flag = this.mSenderUserId == (uint)userID && realtimeSinceStartup - this.mLastSendTime <= 2f;
			if (!flag)
			{
				this.mSenderUserId = (uint)userID;
				this.mLastSendTime = realtimeSinceStartup;
				ChatVoiceInfo chatVoiceInfo = new ChatVoiceInfo();
				chatVoiceInfo.sendIndexId = this.GetIndexId(ext);
				chatVoiceInfo.sendProf = this.GetProfIndex(ext);
				chatVoiceInfo.sendName = this.GetSpriteName(name);
				chatVoiceInfo.sendUserId = userID;
				chatVoiceInfo.voiceTime = audioTime;
				chatVoiceInfo.type = type;
				bool flag2 = type == 2;
				if (flag2)
				{
					chatVoiceInfo.txt = data;
				}
				else
				{
					chatVoiceInfo.url = data;
					chatVoiceInfo.txt = attach;
				}
				chatVoiceInfo.isLocalPath = false;
				chatVoiceInfo.channel = ChatChannelType.Friends;
				chatVoiceInfo.isTextRecognize = true;
				DlgBase<XChatView, XChatBehaviour>.singleton.ShowOtherChatVoiceInfo(chatVoiceInfo);
			}
		}

		private void OnChannelNotify(uint userId, uint messageType, uint voiceDuration, string ext1, string nickname, string wildcard, string messageBody, string attach)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			XSingleton<XDebug>.singleton.AddLog("The time :", realtimeSinceStartup.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = this.mPublicSenderUserId == userId && realtimeSinceStartup - this.mPublicLastSendTime <= 2f;
			if (!flag)
			{
				this.mPublicSenderUserId = userId;
				this.mPublicLastSendTime = realtimeSinceStartup;
				ChatVoiceInfo chatVoiceInfo = new ChatVoiceInfo();
				chatVoiceInfo.sendIndexId = this.GetIndexId(ext1);
				chatVoiceInfo.sendProf = this.GetProfIndex(ext1);
				chatVoiceInfo.sendName = this.GetSpriteName(nickname);
				chatVoiceInfo.sendUserId = (int)userId;
				bool flag2 = wildcard.Contains("world");
				if (flag2)
				{
					chatVoiceInfo.channel = ChatChannelType.World;
				}
				else
				{
					bool flag3 = wildcard.Contains("guild");
					if (flag3)
					{
						chatVoiceInfo.channel = ChatChannelType.Guild;
					}
					else
					{
						bool flag4 = wildcard.Contains("team");
						if (flag4)
						{
							chatVoiceInfo.channel = ChatChannelType.Team;
						}
					}
				}
				chatVoiceInfo.wildCard = wildcard;
				chatVoiceInfo.type = (int)messageType;
				chatVoiceInfo.voiceTime = (int)voiceDuration;
				chatVoiceInfo.txt = attach;
				chatVoiceInfo.url = messageBody;
				chatVoiceInfo.isLocalPath = false;
				chatVoiceInfo.isTextRecognize = true;
				DlgBase<XChatView, XChatBehaviour>.singleton.ShowOtherChatVoiceInfo(chatVoiceInfo);
				bool flag5 = chatVoiceInfo.channel == ChatChannelType.Team;
				if (flag5)
				{
					bool flag6 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag6)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowBattleVoice(chatVoiceInfo);
					}
				}
			}
		}

		private void OnPlayAudioRecordBack(uint result)
		{
			bool flag = result > 0U;
			if (flag)
			{
			}
			this.IsPlaying = false;
			XSingleton<XTimerMgr>.singleton.SetTimer(0.3f, new XTimerMgr.ElapsedEventHandler(this.ContinuePlayAudio), null);
		}

		public void ContinuePlayAudio(object obj)
		{
			this.StartAutoPlay();
		}

		public int CurrRecordTime
		{
			get
			{
				return this.m_iCurrRecordTime;
			}
			set
			{
				this.m_iCurrRecordTime = value;
			}
		}

		public int CurrVoiceCD
		{
			get
			{
				return this.m_iCurrVoiceCD;
			}
			set
			{
				this.m_iCurrVoiceCD = value;
			}
		}

		public bool CancelRecord
		{
			get
			{
				return this.m_bCancelRecord;
			}
			set
			{
				this.m_bCancelRecord = value;
			}
		}

		public bool IsRecording
		{
			get
			{
				return this.m_bIsRecording;
			}
			set
			{
				this.m_bIsRecording = value;
			}
		}

		public bool IsPlaying
		{
			get
			{
				return this.m_bIsPlaying;
			}
			set
			{
				this.m_bIsPlaying = value;
			}
		}

		public bool IsLoginSuccess
		{
			get
			{
				return this.m_bIsLoginSuccess;
			}
			set
			{
				this.m_bIsLoginSuccess = value;
			}
		}

		public bool IsTextRecognize
		{
			get
			{
				return this.m_bIsTextRecognize;
			}
			set
			{
				this.m_bIsTextRecognize = value;
			}
		}

		public ChatInfo CurrAutoPlayingVoice
		{
			get
			{
				return this.m_cCurrAutoPlayingVoice;
			}
			set
			{
				this.m_cCurrAutoPlayingVoice = value;
			}
		}

		public Dictionary<string, ChatVoiceInfo> ChatVoceDic
		{
			get
			{
				bool flag = this.m_dChatVoiceDic == null;
				if (flag)
				{
					this.m_dChatVoiceDic = new Dictionary<string, ChatVoiceInfo>();
				}
				return this.m_dChatVoiceDic;
			}
		}

		public Dictionary<string, int> ChatYuYinIdDic
		{
			get
			{
				bool flag = this.m_dChatYuYinIdDic == null;
				if (flag)
				{
					this.m_dChatYuYinIdDic = new Dictionary<string, int>();
				}
				return this.m_dChatYuYinIdDic;
			}
		}

		public Dictionary<string, ChatVoicePrivateInfo> ChatVoicePriDic
		{
			get
			{
				bool flag = this.m_dChatVoicePriDic == null;
				if (flag)
				{
					this.m_dChatVoicePriDic = new Dictionary<string, ChatVoicePrivateInfo>();
				}
				return this.m_dChatVoicePriDic;
			}
		}

		public Dictionary<int, string> ChatChannelDic
		{
			get
			{
				bool flag = this.m_dChatChannelDic == null;
				if (flag)
				{
					this.m_dChatChannelDic = new Dictionary<int, string>();
				}
				return this.m_dChatChannelDic;
			}
		}

		public void StartAudioRecord()
		{
			bool flag = !this.IsLoginSuccess;
			if (flag)
			{
				string name = XSingleton<XEntityMgr>.singleton.Player.Name;
				ulong roleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				string text = ((uint)XSingleton<XClientNetwork>.singleton.Server.GetHashCode()).ToString();
				string channelWildCard = XSingleton<XChatVoiceManager>.singleton.GetChannelWildCard(XSingleton<XEntityMgr>.singleton.Player, ChatChannelType.World);
				string channelWildCard2 = XSingleton<XChatVoiceManager>.singleton.GetChannelWildCard(XSingleton<XEntityMgr>.singleton.Player, ChatChannelType.Guild);
			}
			else
			{
				this.IsRecording = true;
				this.CancelRecord = false;
				this.StopPlayAudioRecord();
				XAudioOperationArgs @event = XEventPool<XAudioOperationArgs>.GetEvent();
				@event.IsAudioOn = false;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this.TimeCountDown();
			}
		}

		public void StopAudioRecord(bool cancel = false)
		{
			bool isRecording = this.IsRecording;
			if (isRecording)
			{
				this.IsRecording = false;
				this.CancelRecord = cancel;
				XAudioOperationArgs @event = XEventPool<XAudioOperationArgs>.GetEvent();
				@event.IsAudioOn = true;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this.ClearRecordData();
			}
		}

		private void OnAudioRecordStop(int time, string filePath)
		{
			bool cancelRecord = this.CancelRecord;
			if (!cancelRecord)
			{
				bool flag = time < XChatVoiceManager.VOICE_MIN_TIME;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_RECORD_TOO_SHORT"), "fece00");
				}
				else
				{
					ChatVoiceInfo chatVoiceInfo = new ChatVoiceInfo();
					XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
					chatVoiceInfo.sendIndexId = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					chatVoiceInfo.sendUserId = this.GetSpriteYuYinId(player.Name + "_" + player.EngineObject.Name);
					chatVoiceInfo.sendProf = ((int)player.PlayerAttributes.Profession).ToString();
					chatVoiceInfo.sendName = player.Name;
					chatVoiceInfo.voiceTime = Mathf.CeilToInt((float)time * 0.001f);
					bool flag2 = chatVoiceInfo.voiceTime > XChatVoiceManager.VOICE_MAX_TIME;
					if (flag2)
					{
						chatVoiceInfo.voiceTime = XChatVoiceManager.VOICE_MAX_TIME;
					}
					chatVoiceInfo.filePath = filePath;
					chatVoiceInfo.isLocalPath = true;
					chatVoiceInfo.txt = "      ";
					bool flag3 = DlgBase<XChatView, XChatBehaviour>.singleton.CheckWorldSendMsg(true, null, ChatChannelType.DEFAULT);
					if (flag3)
					{
						this.ChatVoceDic.Add(filePath, chatVoiceInfo);
						ChatInfo chatInfo = new ChatInfo();
						chatInfo.voice = chatVoiceInfo;
						bool flag4 = this.OnStopAudioRecord != null;
						if (flag4)
						{
							this.OnStopAudioRecord(chatInfo);
						}
					}
					else
					{
						this.lastWorldInfo = chatVoiceInfo;
						this.lastFilePath = filePath;
					}
				}
			}
		}

		public void DispacherOnbuySucc()
		{
			bool flag = this.lastWorldInfo != null;
			if (flag)
			{
				this.ChatVoceDic.Add(this.lastFilePath, this.lastWorldInfo);
				ChatInfo chatInfo = new ChatInfo();
				chatInfo.voice = this.lastWorldInfo;
				bool flag2 = this.OnStopAudioRecord != null;
				if (flag2)
				{
					this.OnStopAudioRecord(chatInfo);
				}
			}
		}

		public void SendPrivateVoiceInfo(ChatVoiceInfo voice, string name, ulong sendId)
		{
			int spriteYuYinId = this.GetSpriteYuYinId(name);
			bool flag = spriteYuYinId != -1 && spriteYuYinId != 0;
			if (flag)
			{
				voice.acceptUserId = spriteYuYinId;
				voice.sendIndexId = sendId;
				DlgBase<XChatView, XChatBehaviour>.singleton.ShowMyChatVoiceInfo(voice);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_NOT_ACTIVE_AUDIO"), "fece00");
			}
		}

		private void SendPrivateVoice(ChatVoiceInfo voice, int yuYinId, ulong sendId)
		{
			bool flag = voice == null || string.IsNullOrEmpty(voice.filePath);
			if (!flag)
			{
				string text = string.Format("{0}_{1}", sendId, voice.sendProf);
			}
		}

		private void SendPrivateVoiceCallBack(int result)
		{
			bool flag = result != 0;
			if (flag)
			{
				this.SendVoiceResult(false);
			}
		}

		public void SendChannelVoice(ChatVoiceInfo voice, ulong sendId)
		{
			bool flag = voice == null || string.IsNullOrEmpty(voice.filePath);
			if (!flag)
			{
				string text = string.Format("{0}_{1}", sendId, voice.sendProf);
			}
		}

		private void SendChannelVoiceCallBack(int result)
		{
			bool flag = result != 0;
			if (flag)
			{
				this.SendVoiceResult(false);
			}
		}

		private void SendVoiceResult(bool result)
		{
			bool flag = !result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_SEND_VOICE_ERR"), "fece00");
			}
		}

		public void PlayAudioRecord(ChatVoiceInfo voice)
		{
			bool flag = voice != null;
			if (flag)
			{
				bool isLocalPath = voice.isLocalPath;
				if (isLocalPath)
				{
					this.PlayAudioRecord(voice.filePath, null);
				}
				else
				{
					this.PlayAudioRecord(null, voice.url);
				}
			}
		}

		public void PlayAudioRecord(string filePath, string url)
		{
			this.StopPlayAudioRecord();
			this.CheckAutoPlay(filePath, url);
			bool flag = false;
			XAudioOperationArgs @event = XEventPool<XAudioOperationArgs>.GetEvent();
			@event.IsAudioOn = false;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this.IsPlaying = flag;
			bool flag2 = !flag;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_BROADCAST_ERR"), "fece00");
				this.StartAutoPlay();
			}
		}

		public void StopPlayAudioRecord()
		{
			this.IsAutoPlay = false;
			this.IsPlaying = false;
			this.CurrAutoPlayingVoice = null;
			this.StopAutoPlayCallBack();
			XAudioOperationArgs @event = XEventPool<XAudioOperationArgs>.GetEvent();
			@event.IsAudioOn = true;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public void OnStartVoiceCD()
		{
			this.CurrVoiceCD = 0;
			this.TimeVoiceCD();
		}

		public void StartTextRecognize(ChatInfo info, ChatItemInfo cii, ChatTextRecognizeInfo textRecognize = null)
		{
			bool flag = (info != null && info.voice != null && cii != null) || textRecognize != null;
			if (flag)
			{
				info.voice.isTextRecognize = true;
				bool flag2 = this.m_cTextRecognize == null || textRecognize != null;
				if (flag2)
				{
					this.m_bIsTextRecognizeTimeOut = false;
					bool flag3 = textRecognize == null;
					if (flag3)
					{
						this.m_cTextRecognize = new ChatTextRecognizeInfo(info, cii);
					}
					else
					{
						this.m_cTextRecognize = textRecognize;
					}
					this.m_sCurrRecoginzeVoice = DateTime.Now.ToFileTime().ToString();
				}
				else
				{
					this.m_lTextRecognizeList.Add(new ChatTextRecognizeInfo(info, cii));
				}
			}
		}

		private void OnTextRecognizeCallBack(int result, string text, string ext)
		{
			bool flag = this.m_bIsTextRecognizeTimeOut || !string.Equals(ext, this.m_sCurrRecoginzeVoice);
			if (!flag)
			{
				bool flag2 = this.m_cTextRecognize.chatInfo == null || this.m_cTextRecognize.chatInfo.voice == null;
				if (!flag2)
				{
					bool flag3 = result == 0;
					if (flag3)
					{
						bool flag4 = this.m_cTextRecognize != null;
						if (flag4)
						{
							this.m_cTextRecognize.chatInfo.voice.txt = text;
							this.m_cTextRecognize.chatInfo.mContent = text;
							bool flag5 = DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
							if (flag5)
							{
								this.m_cTextRecognize.chatInfo.SetAudioText(text);
							}
							bool flag6 = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
							if (flag6)
							{
								XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
							}
						}
					}
					else
					{
						bool flag7 = this.m_cTextRecognize != null;
						if (flag7)
						{
							this.m_cTextRecognize.chatInfo.voice.txt = "      ";
							bool flag8 = DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
							if (flag8)
							{
								this.m_cTextRecognize.chatInfo.SetAudioText("      ");
							}
							bool flag9 = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
							if (flag9)
							{
								XVoiceQADocument specificDocument2 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
							}
						}
					}
					bool flag10 = this.OnRefreshTextRecoginze != null && this.m_cTextRecognize != null;
					if (flag10)
					{
						this.OnRefreshTextRecoginze(this.m_cTextRecognize.chatInfo);
					}
					this.OnSendTextRecognize();
					this.ClearTextRecognizeTime();
				}
			}
		}

		private void OnTextRecognizeTime()
		{
			bool flag = this.m_iCurrTextRecognizeTime >= this.m_iMaxTextRecognizeTime;
			if (flag)
			{
				this.m_bIsTextRecognizeTimeOut = true;
				bool flag2 = this.m_cTextRecognize != null;
				if (flag2)
				{
					this.m_cTextRecognize.chatInfo.voice.txt = XStringDefineProxy.GetString("CHAT_RECG_TIMEOUT");
				}
				bool flag3 = this.OnRefreshTextRecoginze != null && this.m_cTextRecognize != null;
				if (flag3)
				{
					this.OnRefreshTextRecoginze(this.m_cTextRecognize.chatInfo);
				}
				this.ClearTextRecognizeTime();
			}
			else
			{
				this.m_iCurrTextRecognizeTime++;
			}
		}

		private void OnSendTextRecognize()
		{
			bool flag = this.m_cTextRecognize != null;
			if (flag)
			{
				ChatVoiceInfo voice = this.m_cTextRecognize.chatInfo.voice;
				bool flag2 = voice.channel == ChatChannelType.Friends;
				if (flag2)
				{
					this.SendPrivateVoice(voice, voice.acceptUserId, voice.sendIndexId);
				}
				else
				{
					this.SendChannelVoice(voice, voice.sendIndexId);
					bool flag3 = this.m_cTextRecognize.chatInfo.mChannelId == ChatChannelType.Team;
					if (flag3)
					{
						bool flag4 = voice.channel == ChatChannelType.Team && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
						if (flag4)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowBattleVoice(voice);
						}
					}
				}
			}
		}

		private void ClearTextRecognizeTime()
		{
			this.m_cTextRecognize.Clear();
			this.m_cTextRecognize = null;
			this.m_iCurrTextRecognizeTime = 0;
			this.m_bIsTextRecognizeTimeOut = false;
			bool flag = this.m_lTextRecognizeList.Count > 0;
			if (flag)
			{
				ChatTextRecognizeInfo chatTextRecognizeInfo = this.m_lTextRecognizeList[0];
				this.m_lTextRecognizeList.RemoveAt(0);
			}
		}

		public void CheckCurrChannel(ChatChannelType channel)
		{
			bool flag = !this.ChatChannelDic.ContainsKey((int)channel);
			if (flag)
			{
				this.AddVoiceChannel(channel);
			}
		}

		public void AddVoiceChannelWild(ChatChannelType channel)
		{
			string channelWildCard = this.GetChannelWildCard(XSingleton<XEntityMgr>.singleton.Player, channel);
			bool flag = channelWildCard == "";
			if (!flag)
			{
				bool flag2 = this.ChatChannelDic.ContainsKey((int)channel);
				if (flag2)
				{
					this.ChatChannelDic[(int)channel] = channelWildCard;
				}
				else
				{
					this.ChatChannelDic.Add((int)channel, channelWildCard);
				}
			}
		}

		public void AddVoiceChannel(ChatChannelType channel)
		{
			string channelWildCard = this.GetChannelWildCard(XSingleton<XEntityMgr>.singleton.Player, channel);
			bool flag = channelWildCard == "";
			if (!flag)
			{
				bool flag2 = this.ChatChannelDic.ContainsKey((int)channel);
				if (flag2)
				{
					this.ChatChannelDic[(int)channel] = channelWildCard;
				}
				else
				{
					this.ChatChannelDic.Add((int)channel, channelWildCard);
				}
			}
		}

		public void RemoveVoiceChannel(ChatChannelType channel)
		{
			bool flag = this.ChatChannelDic.ContainsKey((int)channel);
			if (flag)
			{
				this.ChatChannelDic.Remove((int)channel);
			}
		}

		public void RemoveAllChannelExceptWorld()
		{
			this.RemoveVoiceChannel(ChatChannelType.World);
			this.RemoveVoiceChannel(ChatChannelType.Guild);
			this.RemoveVoiceChannel(ChatChannelType.Friends);
		}

		public string GetChannelWildCard(XEntity data, ChatChannelType channel)
		{
			string result;
			if (channel != ChatChannelType.World)
			{
				if (channel != ChatChannelType.Guild)
				{
					if (channel != ChatChannelType.Team)
					{
						result = this.m_sWildCard;
					}
					else
					{
						XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
						bool flag = specificDocument.MyTeam != null;
						if (flag)
						{
							result = XSingleton<XClientNetwork>.singleton.ServerID.ToString() + "team" + specificDocument.MyTeam.teamBrief.teamID;
						}
						else
						{
							result = "";
						}
					}
				}
				else
				{
					XGuildDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					bool bInGuild = specificDocument2.bInGuild;
					if (bInGuild)
					{
						result = XSingleton<XClientNetwork>.singleton.ServerID.ToString() + "guild" + specificDocument2.UID.ToString();
					}
					else
					{
						result = "";
					}
				}
			}
			else
			{
				result = "world" + XSingleton<XClientNetwork>.singleton.ServerID.ToString();
			}
			return result;
		}

		public void CheckSpriteYuYinId(string name)
		{
			bool flag = string.IsNullOrEmpty(name);
			if (!flag)
			{
				bool flag2 = this.GetSpriteYuYinId(name) == -1;
				if (flag2)
				{
				}
			}
		}

		public void AddSpriteYuYinId(string name, int indexID)
		{
			bool flag = this.ChatYuYinIdDic.ContainsKey(name);
			if (flag)
			{
				this.ChatYuYinIdDic[name] = indexID;
			}
			else
			{
				this.ChatYuYinIdDic.Add(name, indexID);
			}
		}

		public int GetSpriteYuYinId(string name)
		{
			bool flag = this.ChatYuYinIdDic.ContainsKey(name);
			int result;
			if (flag)
			{
				result = this.ChatYuYinIdDic[name];
			}
			else
			{
				result = -1;
			}
			return result;
		}

		private void TimeCountDown()
		{
			bool flag = this.CurrRecordTime < XChatVoiceManager.VOICE_MAX_TIME;
			if (flag)
			{
				bool flag2 = this.OnTimeCountDown != null;
				if (flag2)
				{
					this.OnTimeCountDown(XChatVoiceManager.VOICE_MAX_TIME - this.CurrRecordTime);
				}
				int currRecordTime = this.CurrRecordTime;
				this.CurrRecordTime = currRecordTime + 1;
			}
			else
			{
				this.StopAudioRecord(false);
			}
		}

		private void TimeVoiceCD()
		{
			bool flag = this.CurrVoiceCD < XChatVoiceManager.VOICE_CHAT_CD;
			if (flag)
			{
				bool flag2 = this.OnVoiceCD != null;
				if (flag2)
				{
					this.OnVoiceCD(XChatVoiceManager.VOICE_CHAT_CD - this.CurrVoiceCD);
				}
				int currVoiceCD = this.CurrVoiceCD;
				this.CurrVoiceCD = currVoiceCD + 1;
			}
			else
			{
				this.CurrVoiceCD = 0;
				bool flag3 = this.OnVoiceCD != null;
				if (flag3)
				{
					this.OnVoiceCD(-1);
				}
			}
		}

		private void HideTimeCountDown()
		{
			bool flag = this.OnTimeCountDown != null;
			if (flag)
			{
				this.OnTimeCountDown(-1);
			}
		}

		private void ClearRecordData()
		{
			this.IsRecording = false;
			this.HideTimeCountDown();
			this.CurrRecordTime = 0;
		}

		public void CleanAudioData()
		{
			this.ClearRecordData();
			this.CurrVoiceCD = XChatVoiceManager.VOICE_CHAT_CD;
			this.TimeVoiceCD();
			this.CancelRecord = false;
			this.IsPlaying = false;
			this.ChatVoceDic.Clear();
			this.ChatVoicePriDic.Clear();
			this.ClearAutoPlayList();
		}

		private ulong GetIndexId(string str)
		{
			ulong result = 0UL;
			ulong.TryParse(str.Split(new char[]
			{
				'_'
			})[0], out result);
			return result;
		}

		private string GetProfIndex(string str)
		{
			string[] array = str.Split(new char[]
			{
				'_'
			});
			bool flag = array.Length <= 1;
			string result;
			if (flag)
			{
				result = "1";
			}
			else
			{
				result = array[1];
			}
			return result;
		}

		private ulong GetSpriteIndex(string str)
		{
			ulong result = 0UL;
			string[] array = str.Split(new char[]
			{
				'_'
			});
			bool flag = array.Length >= 2;
			if (flag)
			{
				ulong.TryParse(array[1], out result);
			}
			return result;
		}

		private string GetSpriteName(string str)
		{
			string[] array = str.Split(new char[]
			{
				'_'
			});
			return array[0];
		}

		public bool IsVoiceCD()
		{
			bool flag = this.CurrVoiceCD == 0;
			return !flag;
		}

		private void StartAutoPlayCallBack(int time)
		{
		}

		private void StopAutoPlayCallBack()
		{
			XAudioOperationArgs @event = XEventPool<XAudioOperationArgs>.GetEvent();
			@event.IsAudioOn = true;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public bool IsAutoPlay
		{
			get
			{
				return this.m_bIsAutoPlay;
			}
			set
			{
				this.m_bIsAutoPlay = value;
			}
		}

		public List<ChatInfo> AutoPlayAudioList
		{
			get
			{
				bool flag = this.m_lAutoPlayAudioList == null;
				if (flag)
				{
					this.m_lAutoPlayAudioList = new List<ChatInfo>();
				}
				return this.m_lAutoPlayAudioList;
			}
			set
			{
				this.m_lAutoPlayAudioList = value;
			}
		}

		public void AddAutoPlayList(ChatInfo info)
		{
			bool flag = info == null;
			if (!flag)
			{
				SetEffectInfo info2 = DlgBase<XChatView, XChatBehaviour>.singleton.Info;
				ChatChannelType mChannelId = info.mChannelId;
				if (mChannelId != ChatChannelType.World)
				{
					if (mChannelId != ChatChannelType.Guild)
					{
						if (mChannelId == ChatChannelType.Team)
						{
							bool flag2 = !info2.teamSpeechOnOff;
							if (flag2)
							{
								return;
							}
						}
					}
					else
					{
						bool flag3 = !info2.jiaZuSpeechOnOff;
						if (flag3)
						{
							return;
						}
					}
				}
				else
				{
					bool flag4 = !info2.worldSpeechOnOff;
					if (flag4)
					{
						return;
					}
				}
				this.AutoPlayAudioList.Add(info);
				bool flag5 = !this.IsPlaying;
				if (flag5)
				{
					this.StartAutoPlay();
				}
			}
		}

		public void ClearAutoPlayList()
		{
			this.StopPlayAudioRecord();
			this.AutoPlayAudioList.Clear();
		}

		public void StartAutoPlay()
		{
			bool flag = this.IsPlaying || this.AutoPlayAudioList.Count == 0;
			if (flag)
			{
				this.CurrAutoPlayingVoice = null;
				this.StopAutoPlayCallBack();
			}
			else
			{
				int i = 0;
				while (i < this.AutoPlayAudioList.Count)
				{
					ChatInfo chatInfo = this.AutoPlayAudioList[i];
					ChatVoiceInfo voice = chatInfo.voice;
					bool flag2 = voice != null;
					if (flag2)
					{
						this.CurrAutoPlayingVoice = chatInfo;
						bool flag3 = DlgBase<XChatView, XChatBehaviour>.singleton.IsInited && DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
						if (flag3)
						{
							DlgBase<XChatView, XChatBehaviour>.singleton.UIOP.RefreshAudioUI(chatInfo);
						}
						this.StartAutoPlayCallBack(voice.voiceTime);
						this.AutoPlayAudioList.RemoveAt(0);
						return;
					}
					this.AutoPlayAudioList.RemoveAt(0);
				}
				this.CurrAutoPlayingVoice = null;
				this.StopAutoPlayCallBack();
			}
		}

		private void CheckAutoPlay(string filePath, string url)
		{
			int num = -1;
			for (int i = 0; i < this.AutoPlayAudioList.Count; i++)
			{
				ChatInfo chatInfo = this.AutoPlayAudioList[i];
				ChatVoiceInfo voice = chatInfo.voice;
				bool flag = voice != null;
				if (flag)
				{
					bool flag2 = (!string.IsNullOrEmpty(filePath) && string.Equals(filePath, voice.filePath)) || (!string.IsNullOrEmpty(url) && string.Equals(url, voice.url));
					if (flag2)
					{
						num = i;
						this.IsAutoPlay = true;
						break;
					}
				}
			}
			bool flag3 = num >= 0;
			if (flag3)
			{
				this.AutoPlayAudioList.RemoveRange(0, num);
			}
			else
			{
				this.IsAutoPlay = false;
			}
		}

		public void OnGetYuYinId(string name, int yuYinId)
		{
			bool flag = yuYinId == -1;
			if (flag)
			{
				bool flag2 = this.ChatVoicePriDic.ContainsKey(name);
				if (flag2)
				{
					this.ChatVoicePriDic.Remove(name);
				}
			}
			else
			{
				this.AddSpriteYuYinId(name, yuYinId);
				bool flag3 = this.ChatVoicePriDic.ContainsKey(name);
				if (flag3)
				{
					ChatVoicePrivateInfo chatVoicePrivateInfo = this.ChatVoicePriDic[name];
					chatVoicePrivateInfo.voice.acceptUserId = yuYinId;
					chatVoicePrivateInfo.voice.sendIndexId = chatVoicePrivateInfo.sendId;
					this.ChatVoicePriDic.Remove(name);
					DlgBase<XChatView, XChatBehaviour>.singleton.ShowMyChatVoiceInfo(chatVoicePrivateInfo.voice);
				}
			}
		}

		public XChatVoiceManager.VoidDelegate OnTimeCountDown = null;

		public XChatVoiceManager.VoidDelegate OnVoiceCD = null;

		public XChatVoiceManager.ChatVoiceDelegate OnStopAudioRecord = null;

		public XChatVoiceManager.ChatTextRecognize OnRefreshTextRecoginze = null;

		private uint mSenderUserId = 0U;

		private float mLastSendTime = 0f;

		private uint mPublicSenderUserId = 0U;

		private float mPublicLastSendTime = 0f;

		public static int VOICE_MAX_TIME = 10;

		public static int VOICE_MIN_TIME = 100;

		public static int VOICE_CHAT_CD = 5;

		private int m_iCurrRecordTime = 0;

		private int m_iCurrVoiceCD = 0;

		private bool m_bCancelRecord = false;

		private bool m_bIsRecording = false;

		private bool m_bIsPlaying = false;

		private bool m_bIsLoginSuccess = false;

		private bool m_bIsTextRecognize = true;

		private ChatInfo m_cCurrAutoPlayingVoice;

		private Dictionary<string, ChatVoiceInfo> m_dChatVoiceDic;

		private Dictionary<string, int> m_dChatYuYinIdDic;

		private Dictionary<string, ChatVoicePrivateInfo> m_dChatVoicePriDic;

		private Dictionary<int, string> m_dChatChannelDic;

		private ChatVoiceInfo lastWorldInfo;

		private string lastFilePath;

		private bool m_bIsTextRecognizeTimeOut = false;

		private int m_iMaxTextRecognizeTime = 60;

		private int m_iCurrTextRecognizeTime = 0;

		private ChatTextRecognizeInfo m_cTextRecognize;

		private List<ChatTextRecognizeInfo> m_lTextRecognizeList = new List<ChatTextRecognizeInfo>();

		private string m_sCurrRecoginzeVoice;

		private string m_sWildCard = "world";

		private bool m_bIsAutoPlay = true;

		private List<ChatInfo> m_lAutoPlayAudioList;

		public delegate void VoidDelegate(int time);

		public delegate void ChatVoiceDelegate(ChatInfo voice);

		public delegate void ChatTextRecognize(ChatInfo info);
	}
}
