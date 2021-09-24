using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPKInvitationDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPKInvitationDocument.uuID;
			}
		}

		public uint InvitationCount
		{
			get
			{
				return this.m_InvitationCount;
			}
			set
			{
				this.m_InvitationCount = value;
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_PK, true);
			}
		}

		public void ReqAllPKInvitation()
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_REQ_LIST;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		public void SendPKInvitation(ulong roleID)
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_INV_ONE;
			rpcC2M_InvFightReqAll.oArg.roleid = roleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		public void AcceptInvitation(ulong inviteID)
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_ACCEPT_ONE;
			rpcC2M_InvFightReqAll.oArg.invid = inviteID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		public void RejectInvitation(ulong inviteID)
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_REFUSH_ONE;
			rpcC2M_InvFightReqAll.oArg.invid = inviteID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		public void IgnoreAllInvitation()
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_IGNORE_ALL;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		public void AskInvitePKAgain()
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PK_AGAIN_SEND"), "fece00");
			PtcC2G_InvfightAgainReqC2G proto = new PtcC2G_InvfightAgainReqC2G();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		public void OnGetPKInfo(InvFightArg oArg, InvFightRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVFIGHT_INV_TIME_OVER;
				if (flag2)
				{
					this.AllInvitation.Clear();
					this.InvitationCount = 0U;
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				switch (oArg.reqtype)
				{
				case InvFightReqType.IFRT_INV_ONE:
				{
					bool flag3 = oArg.iscrossSpecified && oArg.iscross;
					if (flag3)
					{
						bool isPlatFriendOnlineSpecified = oRes.isPlatFriendOnlineSpecified;
						if (isPlatFriendOnlineSpecified)
						{
							bool isPlatFriendOnline = oRes.isPlatFriendOnline;
							if (isPlatFriendOnline)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PLAT_FRIEND_PK_ONLINE"), "fece00");
							}
							else
							{
								bool accountSpecified = oArg.accountSpecified;
								if (accountSpecified)
								{
									DlgBase<XFriendsView, XFriendsBehaviour>.singleton.NoticeFriendShare(oArg.account, XFriendsView.ShareType.PK);
								}
							}
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PK_SEND_INVITATION"), "fece00");
					}
					break;
				}
				case InvFightReqType.IFRT_REFUSH_ONE:
					this.RemoveInvitation(oArg.invid);
					break;
				case InvFightReqType.IFRT_IGNORE_ALL:
					this.AllInvitation.Clear();
					this.InvitationCount = 0U;
					DlgBase<XPKInvitationView, XPKInvitationBehaviour>.singleton.RefreshList();
					break;
				case InvFightReqType.IFRT_REQ_LIST:
					this.AllInvitation = oRes.roles;
					DlgBase<XPKInvitationView, XPKInvitationBehaviour>.singleton.StartTimer();
					DlgBase<XPKInvitationView, XPKInvitationBehaviour>.singleton.RefreshList();
					break;
				case InvFightReqType.IFRT_ACCEPT_ONE:
					this.RemoveInvitation(oArg.invid);
					break;
				}
			}
		}

		private void RemoveInvitation(ulong inviteID)
		{
			bool flag = false;
			for (int i = 0; i < this.AllInvitation.Count; i++)
			{
				bool flag2 = this.AllInvitation[i].invID == inviteID;
				if (flag2)
				{
					flag = true;
					this.AllInvitation.RemoveAt(i);
					break;
				}
			}
			bool flag3 = flag;
			if (flag3)
			{
				uint invitationCount = this.InvitationCount;
				this.InvitationCount = invitationCount - 1U;
			}
			DlgBase<XPKInvitationView, XPKInvitationBehaviour>.singleton.RefreshList();
		}

		public void PKInvitationNotify(PtcM2C_InvFightNotify roPtc)
		{
			bool flag = roPtc.Data.ntftype == InvFightNotifyType.IFNT_REFUSE_ME;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PK_INVITATION_REJECT", new object[]
				{
					roPtc.Data.name
				}), "fece00");
			}
			else
			{
				bool flag2 = roPtc.Data.ntftype == InvFightNotifyType.IFNT_INVITE_ME;
				if (flag2)
				{
					this.InvitationCount = roPtc.Data.count;
				}
			}
		}

		public void EnterFightScene(PtcG2C_InvFightBefEnterSceneNtf roPtc)
		{
			this.PKInfoList.Clear();
			for (int i = 0; i < roPtc.Data.roles.Count; i++)
			{
				RoleSmallInfo roleSmallInfo = new RoleSmallInfo();
				roleSmallInfo.roleID = roPtc.Data.roles[i].roleID;
				roleSmallInfo.roleName = roPtc.Data.roles[i].roleName;
				roleSmallInfo.roleLevel = roPtc.Data.roles[i].roleLevel;
				roleSmallInfo.roleProfession = roPtc.Data.roles[i].roleProfession;
				bool flag = roleSmallInfo.roleID != XSingleton<XAttributeMgr>.singleton.XPlayerData.EntityID;
				if (flag)
				{
					this.PKInfoList.Add(roleSmallInfo);
				}
				else
				{
					this.PKInfoList.Insert(0, roleSmallInfo);
				}
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PKInvitationDocument");

		public List<InvFightRoleBrief> AllInvitation = new List<InvFightRoleBrief>();

		public List<RoleSmallInfo> PKInfoList = new List<RoleSmallInfo>();

		private uint m_InvitationCount;
	}
}
