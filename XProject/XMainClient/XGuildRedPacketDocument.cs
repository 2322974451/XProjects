using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildRedPacketDocument : XDocComponent, ILogSource
	{

		public override uint ID
		{
			get
			{
				return XGuildRedPacketDocument.uuID;
			}
		}

		public XGuildRedPacketView GuildRedPacketView { get; set; }

		public List<XGuildRedPacketBrief> PacketList
		{
			get
			{
				return this.m_PacketList;
			}
		}

		public XGuildRedPacketDetail PacketDetail
		{
			get
			{
				return this.m_PacketDetail;
			}
		}

		public XGuildCheckInBonusInfo GuildBonus
		{
			get
			{
				return this.m_guildBonus;
			}
		}

		public List<XGuildRedPackageSendBrief> GuildBonusSendList
		{
			get
			{
				return this.m_GuildBonusSendBriefList;
			}
		}

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

		private void OnShowIconTimer(object o)
		{
			this.bHasShowIconRedPacket = 0;
		}

		public bool CheckLeader(ulong uid)
		{
			return this.m_PacketDetail.leaderID == uid;
		}

		public bool CheckLuckest(ulong uid)
		{
			return this.m_PacketDetail.luckestID == uid;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildRedPacketDocument.AsyncLoader.AddTask("Table/GuildBonus", XGuildRedPacketDocument.m_BonusReader, false);
			XGuildRedPacketDocument.AsyncLoader.Execute(callback);
		}

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

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._bHasAvailableRedPacket = false;
			this._bHasShowIconRedPacket = 0;
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
		}

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

		public List<ILogData> GetLogList()
		{
			return this.m_PacketDetail.logList;
		}

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

		public void GetGuildCheckInBonusInfo()
		{
			RpcC2G_GuildCheckInBonusInfo rpc = new RpcC2G_GuildCheckInBonusInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void GetSendGuildBonus()
		{
			RpcC2G_SendGuildBonus rpc = new RpcC2G_SendGuildBonus();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendGuildBonusSendList()
		{
			RpcC2M_GetGuildBonusSendList rpc = new RpcC2M_GetGuildBonusSendList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendGuildBonusInSend(uint bonusID)
		{
			RpcC2M_SendGuildBonusInSendList rpcC2M_SendGuildBonusInSendList = new RpcC2M_SendGuildBonusInSendList();
			rpcC2M_SendGuildBonusInSendList.oArg.bonusID = bonusID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_SendGuildBonusInSendList);
		}

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

		public void ReqList()
		{
			RpcC2G_GetGuildBonusList rpc = new RpcC2G_GetGuildBonusList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SetCanThank(bool thank = false)
		{
			this.m_PacketDetail.canThank = thank;
			bool flag = DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>.singleton.Refresh();
			}
		}

		public void ReqFetch(uint uid)
		{
			RpcC2G_GetGuildBonusReward rpcC2G_GetGuildBonusReward = new RpcC2G_GetGuildBonusReward();
			rpcC2G_GetGuildBonusReward.oArg.bonusID = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetGuildBonusReward);
		}

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

		public void SendGuildBonuesLeft()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("SendGuildBonuesLeft", null, null, null, null, null);
			RpcC2G_GetGuildBonusLeft rpc = new RpcC2G_GetGuildBonusLeft();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildRedPacketDocument");

		private static GuildBonusTable m_BonusReader = new GuildBonusTable();

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private List<XGuildRedPacketBrief> m_PacketList = new List<XGuildRedPacketBrief>();

		private List<GuildBonusBriefInfo> m_bonusBriefInfos = new List<GuildBonusBriefInfo>();

		private XGuildRedPacketDetail m_PacketDetail = new XGuildRedPacketDetail();

		private XGuildCheckInBonusInfo m_guildBonus = new XGuildCheckInBonusInfo();

		private List<XGuildRedPackageSendBrief> m_GuildBonusSendBriefList = new List<XGuildRedPackageSendBrief>();

		private bool _bHasAvailableRedPacket = false;

		private bool _bHasAvailableFixedRedPoint = false;

		private int _bHasShowIconRedPacket = 0;

		private double _showIconTimer = 0.0;
	}
}
