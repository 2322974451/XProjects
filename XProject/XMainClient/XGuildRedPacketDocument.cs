using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A7B RID: 2683
	internal class XGuildRedPacketDocument : XDocComponent, ILogSource
	{
		// Token: 0x17002F94 RID: 12180
		// (get) Token: 0x0600A347 RID: 41799 RVA: 0x001BE990 File Offset: 0x001BCB90
		public override uint ID
		{
			get
			{
				return XGuildRedPacketDocument.uuID;
			}
		}

		// Token: 0x17002F95 RID: 12181
		// (get) Token: 0x0600A348 RID: 41800 RVA: 0x001BE9A7 File Offset: 0x001BCBA7
		// (set) Token: 0x0600A349 RID: 41801 RVA: 0x001BE9AF File Offset: 0x001BCBAF
		public XGuildRedPacketView GuildRedPacketView { get; set; }

		// Token: 0x17002F96 RID: 12182
		// (get) Token: 0x0600A34A RID: 41802 RVA: 0x001BE9B8 File Offset: 0x001BCBB8
		public List<XGuildRedPacketBrief> PacketList
		{
			get
			{
				return this.m_PacketList;
			}
		}

		// Token: 0x17002F97 RID: 12183
		// (get) Token: 0x0600A34B RID: 41803 RVA: 0x001BE9D0 File Offset: 0x001BCBD0
		public XGuildRedPacketDetail PacketDetail
		{
			get
			{
				return this.m_PacketDetail;
			}
		}

		// Token: 0x17002F98 RID: 12184
		// (get) Token: 0x0600A34C RID: 41804 RVA: 0x001BE9E8 File Offset: 0x001BCBE8
		public XGuildCheckInBonusInfo GuildBonus
		{
			get
			{
				return this.m_guildBonus;
			}
		}

		// Token: 0x17002F99 RID: 12185
		// (get) Token: 0x0600A34D RID: 41805 RVA: 0x001BEA00 File Offset: 0x001BCC00
		public List<XGuildRedPackageSendBrief> GuildBonusSendList
		{
			get
			{
				return this.m_GuildBonusSendBriefList;
			}
		}

		// Token: 0x17002F9A RID: 12186
		// (get) Token: 0x0600A34E RID: 41806 RVA: 0x001BEA18 File Offset: 0x001BCC18
		// (set) Token: 0x0600A34F RID: 41807 RVA: 0x001BEA30 File Offset: 0x001BCC30
		public bool bHasAvailableRedPacket
		{
			get
			{
				return this._bHasAvailableRedPacket;
			}
			set
			{
				this._bHasAvailableRedPacket = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildRedPacket, true);
				bool flag = DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.RefreshRedPoint();
				}
			}
		}

		// Token: 0x17002F9B RID: 12187
		// (get) Token: 0x0600A350 RID: 41808 RVA: 0x001BEA6C File Offset: 0x001BCC6C
		// (set) Token: 0x0600A351 RID: 41809 RVA: 0x001BEA84 File Offset: 0x001BCC84
		public bool bHasAvailableFixedRedPoint
		{
			get
			{
				return this._bHasAvailableFixedRedPoint;
			}
			set
			{
				this._bHasAvailableFixedRedPoint = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildBoon_FixedRedPacket, true);
				bool flag = DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.RefreshRedPoint();
				}
			}
		}

		// Token: 0x0600A352 RID: 41810 RVA: 0x001BEAC4 File Offset: 0x001BCCC4
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this._showIconTimer > (double)fDeltaT;
			if (flag)
			{
				this._showIconTimer -= (double)fDeltaT;
				bool flag2 = this._showIconTimer <= 0.0;
				if (flag2)
				{
					this._showIconTimer = 0.0;
					this.bHasShowIconRedPacket = 0;
				}
			}
			bool flag3 = this.m_guildBonus == null;
			if (!flag3)
			{
				this.m_guildBonus.timeofday += (double)fDeltaT;
				bool flag4 = this.m_guildBonus.leftAskBonusTime > 0.0;
				if (flag4)
				{
					this.m_guildBonus.leftAskBonusTime -= (double)fDeltaT;
				}
				else
				{
					this.m_guildBonus.leftAskBonusTime = 0.0;
				}
			}
		}

		// Token: 0x17002F9C RID: 12188
		// (get) Token: 0x0600A353 RID: 41811 RVA: 0x001BEB94 File Offset: 0x001BCD94
		// (set) Token: 0x0600A354 RID: 41812 RVA: 0x001BEBAC File Offset: 0x001BCDAC
		public int bHasShowIconRedPacket
		{
			get
			{
				return this._bHasShowIconRedPacket;
			}
			set
			{
				bool flag = this._bHasShowIconRedPacket != value;
				if (flag)
				{
					this._bHasShowIconRedPacket = value;
					this._showIconTimer = (double)((this._bHasShowIconRedPacket > 0) ? 300 : 0);
					SceneType sceneType = XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
					bool flag2 = sceneType == SceneType.SCENE_HALL || sceneType == SceneType.SCENE_GUILD_HALL;
					if (flag2)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildBoon_RedPacket, true);
					}
				}
			}
		}

		// Token: 0x0600A355 RID: 41813 RVA: 0x001BEC23 File Offset: 0x001BCE23
		private void OnShowIconTimer(object o)
		{
			this.bHasShowIconRedPacket = 0;
		}

		// Token: 0x0600A356 RID: 41814 RVA: 0x001BEC30 File Offset: 0x001BCE30
		public bool CheckLeader(ulong uid)
		{
			return this.m_PacketDetail.leaderID == uid;
		}

		// Token: 0x0600A357 RID: 41815 RVA: 0x001BEC50 File Offset: 0x001BCE50
		public bool CheckLuckest(ulong uid)
		{
			return this.m_PacketDetail.luckestID == uid;
		}

		// Token: 0x0600A358 RID: 41816 RVA: 0x001BEC70 File Offset: 0x001BCE70
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildRedPacketDocument.AsyncLoader.AddTask("Table/GuildBonus", XGuildRedPacketDocument.m_BonusReader, false);
			XGuildRedPacketDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A359 RID: 41817 RVA: 0x001BEC98 File Offset: 0x001BCE98
		public static GuildBonusTable.RowData GetRedPacketConfig(uint id)
		{
			for (int i = 0; i < XGuildRedPacketDocument.m_BonusReader.Table.Length; i++)
			{
				bool flag = XGuildRedPacketDocument.m_BonusReader.Table[i].GuildBonusID == id;
				if (flag)
				{
					return XGuildRedPacketDocument.m_BonusReader.Table[i];
				}
			}
			return null;
		}

		// Token: 0x0600A35A RID: 41818 RVA: 0x001BECEF File Offset: 0x001BCEEF
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._bHasAvailableRedPacket = false;
			this._bHasShowIconRedPacket = 0;
		}

		// Token: 0x0600A35B RID: 41819 RVA: 0x001BED08 File Offset: 0x001BCF08
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
		}

		// Token: 0x0600A35C RID: 41820 RVA: 0x001BED28 File Offset: 0x001BCF28
		protected bool OnInGuildStateChanged(XEventArgs args)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = args as XInGuildStateChangedEventArgs;
			bool flag = !xinGuildStateChangedEventArgs.bIsEnter;
			if (flag)
			{
				this.bHasAvailableRedPacket = false;
			}
			return true;
		}

		// Token: 0x0600A35D RID: 41821 RVA: 0x001BED5C File Offset: 0x001BCF5C
		public List<ILogData> GetLogList()
		{
			return this.m_PacketDetail.logList;
		}

		// Token: 0x0600A35E RID: 41822 RVA: 0x001BED7C File Offset: 0x001BCF7C
		public void CheckAvailableRedPackets()
		{
			bool bHasAvailableRedPacket = false;
			for (int i = 0; i < this.m_PacketList.Count; i++)
			{
				bool flag = this.m_PacketList[i].fetchState == FetchState.FS_CAN_FETCH;
				if (flag)
				{
					bHasAvailableRedPacket = true;
					break;
				}
			}
			this.bHasAvailableRedPacket = bHasAvailableRedPacket;
		}

		// Token: 0x0600A35F RID: 41823 RVA: 0x001BEDD0 File Offset: 0x001BCFD0
		public void GetGuildCheckInBonusInfo()
		{
			RpcC2G_GuildCheckInBonusInfo rpc = new RpcC2G_GuildCheckInBonusInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A360 RID: 41824 RVA: 0x001BEDF0 File Offset: 0x001BCFF0
		public void OnGuildCheckInBonusInfo(GuildCheckInBonusInfoRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				this.m_guildBonus.isCheckIn = oRes.isCheckedIn;
				this.m_guildBonus.guildMemberNum = oRes.guildMemberNum;
				this.m_guildBonus.checkInNumber = oRes.checkInNum;
				this.m_guildBonus.onLineNum = oRes.onlineNum;
				this.m_guildBonus.leftAskBonusTime = (double)oRes.leftAskBonusTime;
				this.m_guildBonus.timeofday = (double)oRes.timeofday;
				this.m_guildBonus.SetBonusBrief(oRes.checkInBonusInfo);
				bool flag2 = DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.RefreshSignInfo();
				}
			}
		}

		// Token: 0x0600A361 RID: 41825 RVA: 0x001BEEBC File Offset: 0x001BD0BC
		public void GetSendGuildBonus()
		{
			RpcC2G_SendGuildBonus rpc = new RpcC2G_SendGuildBonus();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A362 RID: 41826 RVA: 0x001BEEDC File Offset: 0x001BD0DC
		public void OnSendGuildBonus(SendGuildBonusRes sRes)
		{
			bool flag = sRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(sRes.errorcode, "fece00");
			}
			else
			{
				XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
				specificDocument.SendOpenSysInvitation(XSysDefine.XSys_GuildBoon_RedPacket, new ulong[0]);
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("INVITATION_SENT_NOTIFICATION"), "fece00");
				this.GetGuildCheckInBonusInfo();
			}
		}

		// Token: 0x0600A363 RID: 41827 RVA: 0x001BEF50 File Offset: 0x001BD150
		public void SendGuildBonusSendList()
		{
			RpcC2M_GetGuildBonusSendList rpc = new RpcC2M_GetGuildBonusSendList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A364 RID: 41828 RVA: 0x001BEF70 File Offset: 0x001BD170
		public void ReceiveGuildBonusSendList(GetGuildBonusSendListRes res)
		{
			bool flag = res.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(res.error);
			}
			else
			{
				this.m_GuildBonusSendBriefList.Clear();
				int i = 0;
				int count = res.sendList.Count;
				while (i < count)
				{
					XGuildRedPackageSendBrief xguildRedPackageSendBrief = new XGuildRedPackageSendBrief();
					xguildRedPackageSendBrief.SendData(res.sendList[i]);
					this.m_GuildBonusSendBriefList.Add(xguildRedPackageSendBrief);
					i++;
				}
				this.m_GuildBonusSendBriefList.Sort();
				this.UpdateSelfSend();
				bool flag2 = DlgBase<GuildFiexdRedPackageView, GuildFiexdRedPackageBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<GuildFiexdRedPackageView, GuildFiexdRedPackageBehaviour>.singleton.Refresh();
				}
			}
		}

		// Token: 0x0600A365 RID: 41829 RVA: 0x001BF024 File Offset: 0x001BD224
		public void SendGuildBonusInSend(uint bonusID)
		{
			RpcC2M_SendGuildBonusInSendList rpcC2M_SendGuildBonusInSendList = new RpcC2M_SendGuildBonusInSendList();
			rpcC2M_SendGuildBonusInSendList.oArg.bonusID = bonusID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_SendGuildBonusInSendList);
		}

		// Token: 0x0600A366 RID: 41830 RVA: 0x001BF054 File Offset: 0x001BD254
		public void ReceiveGuildBonusInSend(SendGuildBonusInSendListArg arg, SendGuildBonusInSendListRes res)
		{
			bool flag = res.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(res.error);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("INVITATION_SENT_NOTIFICATION"), "fece00");
				bool flag2 = false;
				int i = 0;
				int count = this.m_GuildBonusSendBriefList.Count;
				while (i < count)
				{
					bool flag3 = this.m_GuildBonusSendBriefList[i].uid == (ulong)arg.bonusID;
					if (flag3)
					{
						flag2 = true;
						this.m_GuildBonusSendBriefList.RemoveAt(i);
						break;
					}
					i++;
				}
				this.UpdateSelfSend();
				this.ReqFetch(arg.bonusID);
				bool flag4 = flag2 && DlgBase<GuildFiexdRedPackageView, GuildFiexdRedPackageBehaviour>.singleton.IsVisible();
				if (flag4)
				{
					DlgBase<GuildFiexdRedPackageView, GuildFiexdRedPackageBehaviour>.singleton.Refresh();
				}
			}
		}

		// Token: 0x0600A367 RID: 41831 RVA: 0x001BF12C File Offset: 0x001BD32C
		private void UpdateSelfSend()
		{
			bool bHasAvailableFixedRedPoint = false;
			int i = 0;
			int count = this.m_GuildBonusSendBriefList.Count;
			while (i < count)
			{
				bool flag = this.m_GuildBonusSendBriefList[i].senderType == BonusSender.Bonus_Self;
				if (flag)
				{
					bHasAvailableFixedRedPoint = true;
					break;
				}
				i++;
			}
			this.bHasAvailableFixedRedPoint = bHasAvailableFixedRedPoint;
		}

		// Token: 0x0600A368 RID: 41832 RVA: 0x001BF184 File Offset: 0x001BD384
		public void ReqList()
		{
			RpcC2G_GetGuildBonusList rpc = new RpcC2G_GetGuildBonusList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A369 RID: 41833 RVA: 0x001BF1A4 File Offset: 0x001BD3A4
		public void OnGetList(GetGuildBonusListResult oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				int num = oRes.bonusList.Count - this.m_PacketList.Count;
				for (int i = 0; i < num; i++)
				{
					this.m_PacketList.Add(new XGuildRedPacketBrief());
				}
				bool flag2 = num < 0;
				if (flag2)
				{
					this.m_PacketList.RemoveRange(this.m_PacketList.Count + num, -num);
				}
				for (int j = 0; j < this.m_PacketList.Count; j++)
				{
					this.m_PacketList[j].SetData(oRes.bonusList[j]);
				}
				this.m_PacketList.Sort();
				this.CheckAvailableRedPackets();
				bool flag3 = this.GuildRedPacketView != null && this.GuildRedPacketView.IsVisible();
				if (flag3)
				{
					this.GuildRedPacketView.Refresh(true);
				}
			}
		}

		// Token: 0x0600A36A RID: 41834 RVA: 0x001BF2C0 File Offset: 0x001BD4C0
		public void ReqDetail(uint uid)
		{
			bool flag = uid == 0U;
			if (!flag)
			{
				RpcC2G_GetGuildBonusDetailInfo rpcC2G_GetGuildBonusDetailInfo = new RpcC2G_GetGuildBonusDetailInfo();
				rpcC2G_GetGuildBonusDetailInfo.oArg.bonusID = uid;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetGuildBonusDetailInfo);
			}
		}

		// Token: 0x0600A36B RID: 41835 RVA: 0x001BF2F8 File Offset: 0x001BD4F8
		public void OnGetDetail(GetGuildBonusDetailInfoResult oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				bool flag2 = oRes.bonusInfo == null;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					XSingleton<XDebug>.singleton.AddErrorLog("RedPackage bonus is null", oRes.leaderID.ToString(), null, null, null, null);
				}
				else
				{
					this.m_PacketDetail.brif.SetData(oRes.bonusInfo);
					this.m_PacketDetail.brif.typeid = oRes.bonusContentType;
					this.m_PacketDetail.itemTotalCount = (int)oRes.bonusNum;
					this.m_PacketDetail.content = oRes.content;
					this.m_PacketDetail.leaderID = oRes.leaderID;
					this.m_PacketDetail.luckestID = oRes.luckestID;
					this.m_PacketDetail.canThank = oRes.canThank;
					this.m_PacketDetail.getCount = oRes.getBonusRoleList.Count;
					int num = oRes.getBonusRoleList.Count - this.m_PacketDetail.logList.Count;
					for (int i = 0; i < num; i++)
					{
						this.m_PacketDetail.logList.Add(new XGuildRedPacketLog());
					}
					bool flag3 = num < 0;
					if (flag3)
					{
						this.m_PacketDetail.logList.RemoveRange(this.m_PacketDetail.logList.Count + num, -num);
					}
					uint num2 = 0U;
					for (int j = 0; j < this.m_PacketDetail.logList.Count; j++)
					{
						XGuildRedPacketLog xguildRedPacketLog = this.m_PacketDetail.logList[j] as XGuildRedPacketLog;
						xguildRedPacketLog.SetData(oRes.getBonusRoleList[j]);
						num2 += oRes.getBonusRoleList[j].getNum;
						xguildRedPacketLog.itemid = this.m_PacketDetail.brif.itemid;
					}
					this.m_PacketDetail.getTotalCount = num2;
					this.m_PacketDetail.logList.Sort();
					bool flag4 = DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>.singleton.IsVisible();
					if (flag4)
					{
						DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>.singleton.Refresh();
					}
				}
			}
		}

		// Token: 0x0600A36C RID: 41836 RVA: 0x001BF54C File Offset: 0x001BD74C
		public void SetCanThank(bool thank = false)
		{
			this.m_PacketDetail.canThank = thank;
			bool flag = DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>.singleton.Refresh();
			}
		}

		// Token: 0x0600A36D RID: 41837 RVA: 0x001BF580 File Offset: 0x001BD780
		public void ReqFetch(uint uid)
		{
			RpcC2G_GetGuildBonusReward rpcC2G_GetGuildBonusReward = new RpcC2G_GetGuildBonusReward();
			rpcC2G_GetGuildBonusReward.oArg.bonusID = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetGuildBonusReward);
		}

		// Token: 0x0600A36E RID: 41838 RVA: 0x001BF5B0 File Offset: 0x001BD7B0
		public void OnFetch(GetGuildBonusRewardArg oArg, GetGuildBonusRewardResult oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				bool flag2 = this.GuildRedPacketView != null && this.GuildRedPacketView.IsVisible();
				if (flag2)
				{
					this.GuildRedPacketView.ShowResult(null);
				}
			}
			else
			{
				XGuildRedPacketBrief xguildRedPacketBrief = null;
				for (int i = 0; i < this.m_PacketList.Count; i++)
				{
					bool flag3 = this.m_PacketList[i].uid == (ulong)oArg.bonusID;
					if (flag3)
					{
						xguildRedPacketBrief = this.m_PacketList[i];
						xguildRedPacketBrief.fetchState = FetchState.FS_ALREADY_FETCH;
						xguildRedPacketBrief.fetchedCount += 1U;
						break;
					}
				}
				this.CheckAvailableRedPackets();
				DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>.singleton.ShowEffect(true, oArg.bonusID);
				bool flag4 = this.GuildRedPacketView != null && this.GuildRedPacketView.IsVisible();
				if (flag4)
				{
					this.ReqList();
					this.GuildRedPacketView.Refresh(false);
					this.GuildRedPacketView.ShowResult(xguildRedPacketBrief);
				}
			}
		}

		// Token: 0x0600A36F RID: 41839 RVA: 0x001BF6D0 File Offset: 0x001BD8D0
		public void SendGuildBonuesLeft()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("SendGuildBonuesLeft", null, null, null, null, null);
			RpcC2G_GetGuildBonusLeft rpc = new RpcC2G_GetGuildBonusLeft();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A370 RID: 41840 RVA: 0x001BF708 File Offset: 0x001BD908
		public void ReceiveGuildBonusLeft(GetGuildBonusLeftRes res)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ReceiveGuildBonusLeft", null, null, null, null, null);
			bool flag = res.errorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorCode, "fece00");
			}
			else
			{
				this.m_bonusBriefInfos.Clear();
				this.m_bonusBriefInfos.AddRange(res.bonusInfos);
				this.bHasShowIconRedPacket = this.m_bonusBriefInfos.Count;
			}
		}

		// Token: 0x0600A371 RID: 41841 RVA: 0x001BF784 File Offset: 0x001BD984
		public void ReqGetLast()
		{
			uint num = 0U;
			bool flag = this.m_bonusBriefInfos.Count > 0;
			if (flag)
			{
				int sendTime = this.m_bonusBriefInfos[0].sendTime;
				num = this.m_bonusBriefInfos[0].bonusID;
				int i = 1;
				int count = this.m_bonusBriefInfos.Count;
				while (i < count)
				{
					bool flag2 = this.m_bonusBriefInfos[i].sendTime > sendTime;
					if (flag2)
					{
						sendTime = this.m_bonusBriefInfos[i].sendTime;
						num = this.m_bonusBriefInfos[i].bonusID;
					}
					i++;
				}
			}
			bool flag3 = num > 0U;
			if (flag3)
			{
				this.ReqFetch(num);
				this.ReceiveGuildBonusGetAll(num);
			}
		}

		// Token: 0x0600A372 RID: 41842 RVA: 0x001BF850 File Offset: 0x001BDA50
		public void ReceiveGuildBonusGetAll(uint bonusID)
		{
			bool flag = false;
			int i = 0;
			int count = this.m_bonusBriefInfos.Count;
			while (i < count)
			{
				bool flag2 = this.m_bonusBriefInfos[i].bonusID == bonusID;
				if (flag2)
				{
					flag = true;
					this.m_bonusBriefInfos.RemoveAt(i);
					break;
				}
				i++;
			}
			bool flag3 = flag;
			if (flag3)
			{
				this.bHasShowIconRedPacket = this.m_bonusBriefInfos.Count;
			}
		}

		// Token: 0x0600A373 RID: 41843 RVA: 0x001BF8C4 File Offset: 0x001BDAC4
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildRedPacketView != null && this.GuildRedPacketView.IsVisible();
			if (flag)
			{
				this.ReqList();
			}
			bool flag2 = DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				this.GetGuildCheckInBonusInfo();
			}
			bool flag3 = DlgBase<GuildFiexdRedPackageView, GuildFiexdRedPackageBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				this.SendGuildBonusSendList();
			}
		}

		// Token: 0x04003AF9 RID: 15097
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildRedPacketDocument");

		// Token: 0x04003AFA RID: 15098
		private static GuildBonusTable m_BonusReader = new GuildBonusTable();

		// Token: 0x04003AFB RID: 15099
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003AFD RID: 15101
		private List<XGuildRedPacketBrief> m_PacketList = new List<XGuildRedPacketBrief>();

		// Token: 0x04003AFE RID: 15102
		private List<GuildBonusBriefInfo> m_bonusBriefInfos = new List<GuildBonusBriefInfo>();

		// Token: 0x04003AFF RID: 15103
		private XGuildRedPacketDetail m_PacketDetail = new XGuildRedPacketDetail();

		// Token: 0x04003B00 RID: 15104
		private XGuildCheckInBonusInfo m_guildBonus = new XGuildCheckInBonusInfo();

		// Token: 0x04003B01 RID: 15105
		private List<XGuildRedPackageSendBrief> m_GuildBonusSendBriefList = new List<XGuildRedPackageSendBrief>();

		// Token: 0x04003B02 RID: 15106
		private bool _bHasAvailableRedPacket = false;

		// Token: 0x04003B03 RID: 15107
		private bool _bHasAvailableFixedRedPoint = false;

		// Token: 0x04003B04 RID: 15108
		private int _bHasShowIconRedPacket = 0;

		// Token: 0x04003B05 RID: 15109
		private double _showIconTimer = 0.0;
	}
}
