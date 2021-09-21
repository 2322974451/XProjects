using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E28 RID: 3624
	internal class XChatVoiceManager : XSingleton<XChatVoiceManager>
	{
		// Token: 0x0600C2A7 RID: 49831 RVA: 0x0029E2DC File Offset: 0x0029C4DC
		public void Init(string name, ulong uid, string serverid, string serverwild, string guildwild)
		{
			XSingleton<XDebug>.singleton.AddLog("Will Init Speech", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XDebug>.singleton.AddLog("Will Sign out", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XChatVoiceManager>.singleton.AddMeeageNotify();
			XSingleton<XDebug>.singleton.AddLog("Will Login Speech", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x0600C2A8 RID: 49832 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void UnInit()
		{
		}

		// Token: 0x0600C2A9 RID: 49833 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void AddMeeageNotify()
		{
		}

		// Token: 0x0600C2AA RID: 49834 RVA: 0x0029E338 File Offset: 0x0029C538
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

		// Token: 0x0600C2AB RID: 49835 RVA: 0x0029E3B4 File Offset: 0x0029C5B4
		public void OnAddTeamChannel(object obj)
		{
			this.AddVoiceChannel(ChatChannelType.Team);
		}

		// Token: 0x0600C2AC RID: 49836 RVA: 0x0029E3C0 File Offset: 0x0029C5C0
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

		// Token: 0x0600C2AD RID: 49837 RVA: 0x0029E498 File Offset: 0x0029C698
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

		// Token: 0x0600C2AE RID: 49838 RVA: 0x0029E5F0 File Offset: 0x0029C7F0
		private void OnPlayAudioRecordBack(uint result)
		{
			bool flag = result > 0U;
			if (flag)
			{
			}
			this.IsPlaying = false;
			XSingleton<XTimerMgr>.singleton.SetTimer(0.3f, new XTimerMgr.ElapsedEventHandler(this.ContinuePlayAudio), null);
		}

		// Token: 0x0600C2AF RID: 49839 RVA: 0x0029E62D File Offset: 0x0029C82D
		public void ContinuePlayAudio(object obj)
		{
			this.StartAutoPlay();
		}

		// Token: 0x17003425 RID: 13349
		// (get) Token: 0x0600C2B0 RID: 49840 RVA: 0x0029E638 File Offset: 0x0029C838
		// (set) Token: 0x0600C2B1 RID: 49841 RVA: 0x0029E650 File Offset: 0x0029C850
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

		// Token: 0x17003426 RID: 13350
		// (get) Token: 0x0600C2B2 RID: 49842 RVA: 0x0029E65C File Offset: 0x0029C85C
		// (set) Token: 0x0600C2B3 RID: 49843 RVA: 0x0029E674 File Offset: 0x0029C874
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

		// Token: 0x17003427 RID: 13351
		// (get) Token: 0x0600C2B4 RID: 49844 RVA: 0x0029E680 File Offset: 0x0029C880
		// (set) Token: 0x0600C2B5 RID: 49845 RVA: 0x0029E698 File Offset: 0x0029C898
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

		// Token: 0x17003428 RID: 13352
		// (get) Token: 0x0600C2B6 RID: 49846 RVA: 0x0029E6A4 File Offset: 0x0029C8A4
		// (set) Token: 0x0600C2B7 RID: 49847 RVA: 0x0029E6BC File Offset: 0x0029C8BC
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

		// Token: 0x17003429 RID: 13353
		// (get) Token: 0x0600C2B8 RID: 49848 RVA: 0x0029E6C8 File Offset: 0x0029C8C8
		// (set) Token: 0x0600C2B9 RID: 49849 RVA: 0x0029E6E0 File Offset: 0x0029C8E0
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

		// Token: 0x1700342A RID: 13354
		// (get) Token: 0x0600C2BA RID: 49850 RVA: 0x0029E6EC File Offset: 0x0029C8EC
		// (set) Token: 0x0600C2BB RID: 49851 RVA: 0x0029E704 File Offset: 0x0029C904
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

		// Token: 0x1700342B RID: 13355
		// (get) Token: 0x0600C2BC RID: 49852 RVA: 0x0029E710 File Offset: 0x0029C910
		// (set) Token: 0x0600C2BD RID: 49853 RVA: 0x0029E728 File Offset: 0x0029C928
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

		// Token: 0x1700342C RID: 13356
		// (get) Token: 0x0600C2BE RID: 49854 RVA: 0x0029E734 File Offset: 0x0029C934
		// (set) Token: 0x0600C2BF RID: 49855 RVA: 0x0029E74C File Offset: 0x0029C94C
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

		// Token: 0x1700342D RID: 13357
		// (get) Token: 0x0600C2C0 RID: 49856 RVA: 0x0029E758 File Offset: 0x0029C958
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

		// Token: 0x1700342E RID: 13358
		// (get) Token: 0x0600C2C1 RID: 49857 RVA: 0x0029E788 File Offset: 0x0029C988
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

		// Token: 0x1700342F RID: 13359
		// (get) Token: 0x0600C2C2 RID: 49858 RVA: 0x0029E7B8 File Offset: 0x0029C9B8
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

		// Token: 0x17003430 RID: 13360
		// (get) Token: 0x0600C2C3 RID: 49859 RVA: 0x0029E7E8 File Offset: 0x0029C9E8
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

		// Token: 0x0600C2C4 RID: 49860 RVA: 0x0029E818 File Offset: 0x0029CA18
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

		// Token: 0x0600C2C5 RID: 49861 RVA: 0x0029E8E8 File Offset: 0x0029CAE8
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

		// Token: 0x0600C2C6 RID: 49862 RVA: 0x0029E944 File Offset: 0x0029CB44
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

		// Token: 0x0600C2C7 RID: 49863 RVA: 0x0029EAB0 File Offset: 0x0029CCB0
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

		// Token: 0x0600C2C8 RID: 49864 RVA: 0x0029EB14 File Offset: 0x0029CD14
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

		// Token: 0x0600C2C9 RID: 49865 RVA: 0x0029EB74 File Offset: 0x0029CD74
		private void SendPrivateVoice(ChatVoiceInfo voice, int yuYinId, ulong sendId)
		{
			bool flag = voice == null || string.IsNullOrEmpty(voice.filePath);
			if (!flag)
			{
				string text = string.Format("{0}_{1}", sendId, voice.sendProf);
			}
		}

		// Token: 0x0600C2CA RID: 49866 RVA: 0x0029EBB0 File Offset: 0x0029CDB0
		private void SendPrivateVoiceCallBack(int result)
		{
			bool flag = result != 0;
			if (flag)
			{
				this.SendVoiceResult(false);
			}
		}

		// Token: 0x0600C2CB RID: 49867 RVA: 0x0029EBD0 File Offset: 0x0029CDD0
		public void SendChannelVoice(ChatVoiceInfo voice, ulong sendId)
		{
			bool flag = voice == null || string.IsNullOrEmpty(voice.filePath);
			if (!flag)
			{
				string text = string.Format("{0}_{1}", sendId, voice.sendProf);
			}
		}

		// Token: 0x0600C2CC RID: 49868 RVA: 0x0029EC0C File Offset: 0x0029CE0C
		private void SendChannelVoiceCallBack(int result)
		{
			bool flag = result != 0;
			if (flag)
			{
				this.SendVoiceResult(false);
			}
		}

		// Token: 0x0600C2CD RID: 49869 RVA: 0x0029EC2C File Offset: 0x0029CE2C
		private void SendVoiceResult(bool result)
		{
			bool flag = !result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_SEND_VOICE_ERR"), "fece00");
			}
		}

		// Token: 0x0600C2CE RID: 49870 RVA: 0x0029EC5C File Offset: 0x0029CE5C
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

		// Token: 0x0600C2CF RID: 49871 RVA: 0x0029ECA0 File Offset: 0x0029CEA0
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

		// Token: 0x0600C2D0 RID: 49872 RVA: 0x0029ED20 File Offset: 0x0029CF20
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

		// Token: 0x0600C2D1 RID: 49873 RVA: 0x0029ED77 File Offset: 0x0029CF77
		public void OnStartVoiceCD()
		{
			this.CurrVoiceCD = 0;
			this.TimeVoiceCD();
		}

		// Token: 0x0600C2D2 RID: 49874 RVA: 0x0029ED8C File Offset: 0x0029CF8C
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

		// Token: 0x0600C2D3 RID: 49875 RVA: 0x0029EE30 File Offset: 0x0029D030
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

		// Token: 0x0600C2D4 RID: 49876 RVA: 0x0029EFC0 File Offset: 0x0029D1C0
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

		// Token: 0x0600C2D5 RID: 49877 RVA: 0x0029F064 File Offset: 0x0029D264
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

		// Token: 0x0600C2D6 RID: 49878 RVA: 0x0029F10C File Offset: 0x0029D30C
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

		// Token: 0x0600C2D7 RID: 49879 RVA: 0x0029F16C File Offset: 0x0029D36C
		public void CheckCurrChannel(ChatChannelType channel)
		{
			bool flag = !this.ChatChannelDic.ContainsKey((int)channel);
			if (flag)
			{
				this.AddVoiceChannel(channel);
			}
		}

		// Token: 0x0600C2D8 RID: 49880 RVA: 0x0029F198 File Offset: 0x0029D398
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

		// Token: 0x0600C2D9 RID: 49881 RVA: 0x0029F1F8 File Offset: 0x0029D3F8
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

		// Token: 0x0600C2DA RID: 49882 RVA: 0x0029F258 File Offset: 0x0029D458
		public void RemoveVoiceChannel(ChatChannelType channel)
		{
			bool flag = this.ChatChannelDic.ContainsKey((int)channel);
			if (flag)
			{
				this.ChatChannelDic.Remove((int)channel);
			}
		}

		// Token: 0x0600C2DB RID: 49883 RVA: 0x0029F285 File Offset: 0x0029D485
		public void RemoveAllChannelExceptWorld()
		{
			this.RemoveVoiceChannel(ChatChannelType.World);
			this.RemoveVoiceChannel(ChatChannelType.Guild);
			this.RemoveVoiceChannel(ChatChannelType.Friends);
		}

		// Token: 0x0600C2DC RID: 49884 RVA: 0x0029F2A0 File Offset: 0x0029D4A0
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

		// Token: 0x0600C2DD RID: 49885 RVA: 0x0029F3A4 File Offset: 0x0029D5A4
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

		// Token: 0x0600C2DE RID: 49886 RVA: 0x0029F3D0 File Offset: 0x0029D5D0
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

		// Token: 0x0600C2DF RID: 49887 RVA: 0x0029F40C File Offset: 0x0029D60C
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

		// Token: 0x0600C2E0 RID: 49888 RVA: 0x0029F440 File Offset: 0x0029D640
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

		// Token: 0x0600C2E1 RID: 49889 RVA: 0x0029F4A4 File Offset: 0x0029D6A4
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

		// Token: 0x0600C2E2 RID: 49890 RVA: 0x0029F524 File Offset: 0x0029D724
		private void HideTimeCountDown()
		{
			bool flag = this.OnTimeCountDown != null;
			if (flag)
			{
				this.OnTimeCountDown(-1);
			}
		}

		// Token: 0x0600C2E3 RID: 49891 RVA: 0x0029F54C File Offset: 0x0029D74C
		private void ClearRecordData()
		{
			this.IsRecording = false;
			this.HideTimeCountDown();
			this.CurrRecordTime = 0;
		}

		// Token: 0x0600C2E4 RID: 49892 RVA: 0x0029F568 File Offset: 0x0029D768
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

		// Token: 0x0600C2E5 RID: 49893 RVA: 0x0029F5C0 File Offset: 0x0029D7C0
		private ulong GetIndexId(string str)
		{
			ulong result = 0UL;
			ulong.TryParse(str.Split(new char[]
			{
				'_'
			})[0], out result);
			return result;
		}

		// Token: 0x0600C2E6 RID: 49894 RVA: 0x0029F5F4 File Offset: 0x0029D7F4
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

		// Token: 0x0600C2E7 RID: 49895 RVA: 0x0029F630 File Offset: 0x0029D830
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

		// Token: 0x0600C2E8 RID: 49896 RVA: 0x0029F670 File Offset: 0x0029D870
		private string GetSpriteName(string str)
		{
			string[] array = str.Split(new char[]
			{
				'_'
			});
			return array[0];
		}

		// Token: 0x0600C2E9 RID: 49897 RVA: 0x0029F698 File Offset: 0x0029D898
		public bool IsVoiceCD()
		{
			bool flag = this.CurrVoiceCD == 0;
			return !flag;
		}

		// Token: 0x0600C2EA RID: 49898 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void StartAutoPlayCallBack(int time)
		{
		}

		// Token: 0x0600C2EB RID: 49899 RVA: 0x0029F6BC File Offset: 0x0029D8BC
		private void StopAutoPlayCallBack()
		{
			XAudioOperationArgs @event = XEventPool<XAudioOperationArgs>.GetEvent();
			@event.IsAudioOn = true;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x17003431 RID: 13361
		// (get) Token: 0x0600C2EC RID: 49900 RVA: 0x0029F6F4 File Offset: 0x0029D8F4
		// (set) Token: 0x0600C2ED RID: 49901 RVA: 0x0029F70C File Offset: 0x0029D90C
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

		// Token: 0x17003432 RID: 13362
		// (get) Token: 0x0600C2EE RID: 49902 RVA: 0x0029F718 File Offset: 0x0029D918
		// (set) Token: 0x0600C2EF RID: 49903 RVA: 0x0029F748 File Offset: 0x0029D948
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

		// Token: 0x0600C2F0 RID: 49904 RVA: 0x0029F754 File Offset: 0x0029D954
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

		// Token: 0x0600C2F1 RID: 49905 RVA: 0x0029F7EA File Offset: 0x0029D9EA
		public void ClearAutoPlayList()
		{
			this.StopPlayAudioRecord();
			this.AutoPlayAudioList.Clear();
		}

		// Token: 0x0600C2F2 RID: 49906 RVA: 0x0029F800 File Offset: 0x0029DA00
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

		// Token: 0x0600C2F3 RID: 49907 RVA: 0x0029F8F4 File Offset: 0x0029DAF4
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

		// Token: 0x0600C2F4 RID: 49908 RVA: 0x0029F9B0 File Offset: 0x0029DBB0
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

		// Token: 0x04005392 RID: 21394
		public XChatVoiceManager.VoidDelegate OnTimeCountDown = null;

		// Token: 0x04005393 RID: 21395
		public XChatVoiceManager.VoidDelegate OnVoiceCD = null;

		// Token: 0x04005394 RID: 21396
		public XChatVoiceManager.ChatVoiceDelegate OnStopAudioRecord = null;

		// Token: 0x04005395 RID: 21397
		public XChatVoiceManager.ChatTextRecognize OnRefreshTextRecoginze = null;

		// Token: 0x04005396 RID: 21398
		private uint mSenderUserId = 0U;

		// Token: 0x04005397 RID: 21399
		private float mLastSendTime = 0f;

		// Token: 0x04005398 RID: 21400
		private uint mPublicSenderUserId = 0U;

		// Token: 0x04005399 RID: 21401
		private float mPublicLastSendTime = 0f;

		// Token: 0x0400539A RID: 21402
		public static int VOICE_MAX_TIME = 10;

		// Token: 0x0400539B RID: 21403
		public static int VOICE_MIN_TIME = 100;

		// Token: 0x0400539C RID: 21404
		public static int VOICE_CHAT_CD = 5;

		// Token: 0x0400539D RID: 21405
		private int m_iCurrRecordTime = 0;

		// Token: 0x0400539E RID: 21406
		private int m_iCurrVoiceCD = 0;

		// Token: 0x0400539F RID: 21407
		private bool m_bCancelRecord = false;

		// Token: 0x040053A0 RID: 21408
		private bool m_bIsRecording = false;

		// Token: 0x040053A1 RID: 21409
		private bool m_bIsPlaying = false;

		// Token: 0x040053A2 RID: 21410
		private bool m_bIsLoginSuccess = false;

		// Token: 0x040053A3 RID: 21411
		private bool m_bIsTextRecognize = true;

		// Token: 0x040053A4 RID: 21412
		private ChatInfo m_cCurrAutoPlayingVoice;

		// Token: 0x040053A5 RID: 21413
		private Dictionary<string, ChatVoiceInfo> m_dChatVoiceDic;

		// Token: 0x040053A6 RID: 21414
		private Dictionary<string, int> m_dChatYuYinIdDic;

		// Token: 0x040053A7 RID: 21415
		private Dictionary<string, ChatVoicePrivateInfo> m_dChatVoicePriDic;

		// Token: 0x040053A8 RID: 21416
		private Dictionary<int, string> m_dChatChannelDic;

		// Token: 0x040053A9 RID: 21417
		private ChatVoiceInfo lastWorldInfo;

		// Token: 0x040053AA RID: 21418
		private string lastFilePath;

		// Token: 0x040053AB RID: 21419
		private bool m_bIsTextRecognizeTimeOut = false;

		// Token: 0x040053AC RID: 21420
		private int m_iMaxTextRecognizeTime = 60;

		// Token: 0x040053AD RID: 21421
		private int m_iCurrTextRecognizeTime = 0;

		// Token: 0x040053AE RID: 21422
		private ChatTextRecognizeInfo m_cTextRecognize;

		// Token: 0x040053AF RID: 21423
		private List<ChatTextRecognizeInfo> m_lTextRecognizeList = new List<ChatTextRecognizeInfo>();

		// Token: 0x040053B0 RID: 21424
		private string m_sCurrRecoginzeVoice;

		// Token: 0x040053B1 RID: 21425
		private string m_sWildCard = "world";

		// Token: 0x040053B2 RID: 21426
		private bool m_bIsAutoPlay = true;

		// Token: 0x040053B3 RID: 21427
		private List<ChatInfo> m_lAutoPlayAudioList;

		// Token: 0x020019C9 RID: 6601
		// (Invoke) Token: 0x06011089 RID: 69769
		public delegate void VoidDelegate(int time);

		// Token: 0x020019CA RID: 6602
		// (Invoke) Token: 0x0601108D RID: 69773
		public delegate void ChatVoiceDelegate(ChatInfo voice);

		// Token: 0x020019CB RID: 6603
		// (Invoke) Token: 0x06011091 RID: 69777
		public delegate void ChatTextRecognize(ChatInfo info);
	}
}
