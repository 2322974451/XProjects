using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XApolloDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XApolloDocument.uuID;
			}
		}

		private JoinRoomReply voipRoomInfo { get; set; }

		public override void OnAttachToHost(XObject host)
		{
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public bool IsRealVoice
		{
			get
			{
				this.doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
				return this.doc != null && this.doc.GetBattleRaw().real > 0;
			}
		}

		public bool IsRealtimeVoiceOn
		{
			get
			{
				IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
				return this.mJoinRoomSucc && xapolloManager.openMusic;
			}
		}

		public int TimeOut
		{
			get
			{
				bool flag = this._timeout == 0;
				if (flag)
				{
					this._timeout = XSingleton<XGlobalConfig>.singleton.GetInt("SetApolloTimeout");
				}
				return this._timeout;
			}
		}

		public override void OnDetachFromHost()
		{
			this.QuitRoom();
			base.OnDetachFromHost();
		}

		public bool JoinRoomSucc
		{
			get
			{
				return this.mJoinRoomSucc;
			}
		}

		public bool IsWaittingJoinRoom
		{
			get
			{
				return this.startLoop && !this.mJoinRoomSucc;
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.startLoop;
			if (flag)
			{
				this.acc_time += fDeltaT;
				this.all_time += fDeltaT;
				bool flag2 = this.all_time > (float)this.TimeOut && !this.JoinRoomSucc;
				if (flag2)
				{
					this.startLoop = false;
					this.mJoinRoomSucc = false;
					XSingleton<XDebug>.singleton.AddGreenLog("join room timeout, Apollo error!", null, null, null, null, null);
					bool flag3 = !XSingleton<XUpdater.XUpdater>.singleton.EditorMode;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("VOICE_APOLLO_FAIL"), "fece00");
					}
				}
				bool flag4 = this.acc_time > 0.4f;
				if (flag4)
				{
					bool flag5 = !this.mJoinRoomSucc;
					if (flag5)
					{
						IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
						bool joinRoomResult = xapolloManager.GetJoinRoomResult();
						if (joinRoomResult)
						{
							this.mJoinRoomSucc = true;
							XYuyinView yuyinHandler = DlgBase<BattleMain, BattleMainBehaviour>.singleton._yuyinHandler;
							bool flag6 = yuyinHandler != null;
							if (flag6)
							{
								yuyinHandler.SetSpeak(false);
								xapolloManager.openMusic = false;
								yuyinHandler.SetMusic(true);
								XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
								int @int = XSingleton<XGlobalConfig>.singleton.GetInt("SetSpeakerVolume");
								xapolloManager.SetMusicVolum((int)((float)@int * specificDocument.voiceVolme));
							}
							this.RefreshState(this.roomRoles.ToArray(), this.roomStates.ToArray());
						}
					}
					this.acc_time = 0f;
				}
			}
		}

		private void HideState()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.HideVoice();
				}
				XSceneDamageRankDocument specificDocument = XDocuments.GetSpecificDocument<XSceneDamageRankDocument>(XSceneDamageRankDocument.uuID);
				bool flag3 = specificDocument != null;
				if (flag3)
				{
					specificDocument.RankHandler.HideVoice();
				}
			}
		}

		public void RequestJoinRoom()
		{
			bool isRealVoice = this.IsRealVoice;
			if (isRealVoice)
			{
				XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(false);
				XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
				PtcC2G_JoinRoom proto = new PtcC2G_JoinRoom();
				XSingleton<XClientNetwork>.singleton.Send(proto);
			}
			else
			{
				this.HideState();
			}
		}

		public void JoinRoom(JoinRoomReply data)
		{
			XSingleton<XDebug>.singleton.AddLog("url1:", data.url1, " url2:", data.url2, " url3:", data.url3, XDebugColor.XDebug_None);
			XSingleton<XDebug>.singleton.AddLog("roomid:", data.roomID.ToString(), " roomkey: ", data.roomKey.ToString(), " member: ", data.memberID.ToString(), XDebugColor.XDebug_None);
			this.voipRoomInfo = data;
			this.mJoinRoomSucc = false;
			this.acc_time = 0f;
			this.all_time = 0f;
			this.startLoop = true;
			IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
			xapolloManager.SetRealtimeMode();
			bool flag = !string.IsNullOrEmpty(data.url1);
			if (flag)
			{
				data.url1 = "udp://" + data.url1;
			}
			bool flag2 = !string.IsNullOrEmpty(data.url2);
			if (flag2)
			{
				data.url2 = "udp://" + data.url2;
			}
			bool flag3 = !string.IsNullOrEmpty(data.url3);
			if (flag3)
			{
				data.url3 = "udp://" + data.url3;
			}
			xapolloManager.JoinRoom(data.url1, data.url2, data.url3, data.roomID, data.roomKey, (short)data.memberID);
		}

		public void QuitRoom()
		{
			this.RecoverySound();
			XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(true);
			bool flag = this.voipRoomInfo != null;
			if (flag)
			{
				XSingleton<XUpdater.XUpdater>.singleton.XApolloManager.QuitRoom(this.voipRoomInfo.roomID, (short)this.voipRoomInfo.memberID);
				PtcC2G_QuitRoom ptcC2G_QuitRoom = new PtcC2G_QuitRoom();
				ptcC2G_QuitRoom.Data.roomID = this.voipRoomInfo.roomID;
				ptcC2G_QuitRoom.Data.memberID = this.voipRoomInfo.memberID;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_QuitRoom);
				this.startLoop = false;
				this.mJoinRoomSucc = false;
				this.voipRoomInfo = null;
			}
		}

		public void OnMembersInfoChange(List<VoipRoomMember> _server)
		{
			this.roomRoles.Clear();
			this.roomStates.Clear();
			for (int i = 0; i < _server.Count; i++)
			{
				this.roomRoles.Add(_server[i].roleID);
				this.roomStates.Add((int)_server[i].state);
			}
			this.RefreshState(this.roomRoles.ToArray(), this.roomStates.ToArray());
		}

		public void RefreshState(ulong[] roleids, int[] states)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool isRealVoice = this.IsRealVoice;
				if (isRealVoice)
				{
					bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
					if (flag2)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.RefreshVoice(roleids, states);
					}
					XSceneDamageRankDocument specificDocument = XDocuments.GetSpecificDocument<XSceneDamageRankDocument>(XSceneDamageRankDocument.uuID);
					bool flag3 = specificDocument != null;
					if (flag3)
					{
						specificDocument.RankHandler.RefreshVoice(roleids, states);
					}
				}
			}
		}

		public void SendStateServer(uint state)
		{
			PtcC2G_SetVoipMemberState ptcC2G_SetVoipMemberState = new PtcC2G_SetVoipMemberState();
			ptcC2G_SetVoipMemberState.Data.nstate = state;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_SetVoipMemberState);
		}

		public void PlayGameSound(bool on)
		{
			bool flag = !on;
			if (flag)
			{
				this.MuteSound();
			}
			else
			{
				this.RecoverySound();
			}
		}

		public void MuteSound()
		{
			bool flag = this.muteVol >= 100f;
			if (flag)
			{
				this.muteVol = (float)XSingleton<XGlobalConfig>.singleton.GetInt("SetMusicVol") / 100f;
			}
			this.currVol = this.muteVol;
			XSingleton<XAudioMgr>.singleton.SetMainBusVolume(this.currVol);
		}

		public void RecoverySound()
		{
			this.currVol = 1f;
			XSingleton<XAudioMgr>.singleton.SetMainBusVolume(this.currVol);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XApolloDocument");

		private List<ulong> roomRoles = new List<ulong>();

		private List<int> roomStates = new List<int>();

		private bool mJoinRoomSucc = false;

		private XChatDocument doc;

		private int _timeout = 0;

		private bool startLoop = false;

		private float acc_time = 0f;

		private float all_time = 0f;

		private float currVol = 1f;

		private float muteVol = 100f;
	}
}
