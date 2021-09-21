using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200095F RID: 2399
	internal class XPKInvitationDocument : XDocComponent
	{
		// Token: 0x17002C4B RID: 11339
		// (get) Token: 0x0600909D RID: 37021 RVA: 0x00149988 File Offset: 0x00147B88
		public override uint ID
		{
			get
			{
				return XPKInvitationDocument.uuID;
			}
		}

		// Token: 0x17002C4C RID: 11340
		// (get) Token: 0x0600909E RID: 37022 RVA: 0x001499A0 File Offset: 0x00147BA0
		// (set) Token: 0x0600909F RID: 37023 RVA: 0x001499B8 File Offset: 0x00147BB8
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

		// Token: 0x060090A0 RID: 37024 RVA: 0x001499D0 File Offset: 0x00147BD0
		public void ReqAllPKInvitation()
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_REQ_LIST;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		// Token: 0x060090A1 RID: 37025 RVA: 0x00149A00 File Offset: 0x00147C00
		public void SendPKInvitation(ulong roleID)
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_INV_ONE;
			rpcC2M_InvFightReqAll.oArg.roleid = roleID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		// Token: 0x060090A2 RID: 37026 RVA: 0x00149A3C File Offset: 0x00147C3C
		public void AcceptInvitation(ulong inviteID)
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_ACCEPT_ONE;
			rpcC2M_InvFightReqAll.oArg.invid = inviteID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		// Token: 0x060090A3 RID: 37027 RVA: 0x00149A78 File Offset: 0x00147C78
		public void RejectInvitation(ulong inviteID)
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_REFUSH_ONE;
			rpcC2M_InvFightReqAll.oArg.invid = inviteID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		// Token: 0x060090A4 RID: 37028 RVA: 0x00149AB4 File Offset: 0x00147CB4
		public void IgnoreAllInvitation()
		{
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_IGNORE_ALL;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		// Token: 0x060090A5 RID: 37029 RVA: 0x00149AE4 File Offset: 0x00147CE4
		public void AskInvitePKAgain()
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PK_AGAIN_SEND"), "fece00");
			PtcC2G_InvfightAgainReqC2G proto = new PtcC2G_InvfightAgainReqC2G();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		// Token: 0x060090A6 RID: 37030 RVA: 0x00149B24 File Offset: 0x00147D24
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

		// Token: 0x060090A7 RID: 37031 RVA: 0x00149CB8 File Offset: 0x00147EB8
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

		// Token: 0x060090A8 RID: 37032 RVA: 0x00149D34 File Offset: 0x00147F34
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

		// Token: 0x060090A9 RID: 37033 RVA: 0x00149DAC File Offset: 0x00147FAC
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

		// Token: 0x060090AA RID: 37034 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002FE2 RID: 12258
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PKInvitationDocument");

		// Token: 0x04002FE3 RID: 12259
		public List<InvFightRoleBrief> AllInvitation = new List<InvFightRoleBrief>();

		// Token: 0x04002FE4 RID: 12260
		public List<RoleSmallInfo> PKInfoList = new List<RoleSmallInfo>();

		// Token: 0x04002FE5 RID: 12261
		private uint m_InvitationCount;
	}
}
