using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000943 RID: 2371
	internal class XApolloDocument : XDocComponent
	{
		// Token: 0x17002C1E RID: 11294
		// (get) Token: 0x06008F4E RID: 36686 RVA: 0x001412FC File Offset: 0x0013F4FC
		public override uint ID
		{
			get
			{
				return XApolloDocument.uuID;
			}
		}

		// Token: 0x17002C1F RID: 11295
		// (get) Token: 0x06008F4F RID: 36687 RVA: 0x00141313 File Offset: 0x0013F513
		// (set) Token: 0x06008F50 RID: 36688 RVA: 0x0014131B File Offset: 0x0013F51B
		private JoinRoomReply voipRoomInfo { get; set; }

		// Token: 0x06008F51 RID: 36689 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnAttachToHost(XObject host)
		{
		}

		// Token: 0x06008F52 RID: 36690 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x17002C20 RID: 11296
		// (get) Token: 0x06008F53 RID: 36691 RVA: 0x00141324 File Offset: 0x0013F524
		public bool IsRealVoice
		{
			get
			{
				this.doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
				return this.doc != null && this.doc.GetBattleRaw().real > 0;
			}
		}

		// Token: 0x17002C21 RID: 11297
		// (get) Token: 0x06008F54 RID: 36692 RVA: 0x00141364 File Offset: 0x0013F564
		public bool IsRealtimeVoiceOn
		{
			get
			{
				IApolloManager xapolloManager = XSingleton<XUpdater.XUpdater>.singleton.XApolloManager;
				return this.mJoinRoomSucc && xapolloManager.openMusic;
			}
		}

		// Token: 0x17002C22 RID: 11298
		// (get) Token: 0x06008F55 RID: 36693 RVA: 0x00141394 File Offset: 0x0013F594
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

		// Token: 0x06008F56 RID: 36694 RVA: 0x001413CE File Offset: 0x0013F5CE
		public override void OnDetachFromHost()
		{
			this.QuitRoom();
			base.OnDetachFromHost();
		}

		// Token: 0x17002C23 RID: 11299
		// (get) Token: 0x06008F57 RID: 36695 RVA: 0x001413E0 File Offset: 0x0013F5E0
		public bool JoinRoomSucc
		{
			get
			{
				return this.mJoinRoomSucc;
			}
		}

		// Token: 0x17002C24 RID: 11300
		// (get) Token: 0x06008F58 RID: 36696 RVA: 0x001413F8 File Offset: 0x0013F5F8
		public bool IsWaittingJoinRoom
		{
			get
			{
				return this.startLoop && !this.mJoinRoomSucc;
			}
		}

		// Token: 0x06008F59 RID: 36697 RVA: 0x00141420 File Offset: 0x0013F620
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

		// Token: 0x06008F5A RID: 36698 RVA: 0x001415B4 File Offset: 0x0013F7B4
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

		// Token: 0x06008F5B RID: 36699 RVA: 0x00141614 File Offset: 0x0013F814
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

		// Token: 0x06008F5C RID: 36700 RVA: 0x00141664 File Offset: 0x0013F864
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

		// Token: 0x06008F5D RID: 36701 RVA: 0x001417D0 File Offset: 0x0013F9D0
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

		// Token: 0x06008F5E RID: 36702 RVA: 0x00141880 File Offset: 0x0013FA80
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

		// Token: 0x06008F5F RID: 36703 RVA: 0x0014190C File Offset: 0x0013FB0C
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

		// Token: 0x06008F60 RID: 36704 RVA: 0x0014198C File Offset: 0x0013FB8C
		public void SendStateServer(uint state)
		{
			PtcC2G_SetVoipMemberState ptcC2G_SetVoipMemberState = new PtcC2G_SetVoipMemberState();
			ptcC2G_SetVoipMemberState.Data.nstate = state;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_SetVoipMemberState);
		}

		// Token: 0x06008F61 RID: 36705 RVA: 0x001419BC File Offset: 0x0013FBBC
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

		// Token: 0x06008F62 RID: 36706 RVA: 0x001419E4 File Offset: 0x0013FBE4
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

		// Token: 0x06008F63 RID: 36707 RVA: 0x00141A3F File Offset: 0x0013FC3F
		public void RecoverySound()
		{
			this.currVol = 1f;
			XSingleton<XAudioMgr>.singleton.SetMainBusVolume(this.currVol);
		}

		// Token: 0x04002F10 RID: 12048
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XApolloDocument");

		// Token: 0x04002F11 RID: 12049
		private List<ulong> roomRoles = new List<ulong>();

		// Token: 0x04002F12 RID: 12050
		private List<int> roomStates = new List<int>();

		// Token: 0x04002F14 RID: 12052
		private bool mJoinRoomSucc = false;

		// Token: 0x04002F15 RID: 12053
		private XChatDocument doc;

		// Token: 0x04002F16 RID: 12054
		private int _timeout = 0;

		// Token: 0x04002F17 RID: 12055
		private bool startLoop = false;

		// Token: 0x04002F18 RID: 12056
		private float acc_time = 0f;

		// Token: 0x04002F19 RID: 12057
		private float all_time = 0f;

		// Token: 0x04002F1A RID: 12058
		private float currVol = 1f;

		// Token: 0x04002F1B RID: 12059
		private float muteVol = 100f;
	}
}
