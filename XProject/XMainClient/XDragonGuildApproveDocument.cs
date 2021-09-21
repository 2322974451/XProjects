using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008FE RID: 2302
	internal class XDragonGuildApproveDocument : XDocComponent
	{
		// Token: 0x17002B3E RID: 11070
		// (get) Token: 0x06008B27 RID: 35623 RVA: 0x001291CC File Offset: 0x001273CC
		public override uint ID
		{
			get
			{
				return XDragonGuildApproveDocument.uuID;
			}
		}

		// Token: 0x17002B3F RID: 11071
		// (get) Token: 0x06008B28 RID: 35624 RVA: 0x001291E3 File Offset: 0x001273E3
		// (set) Token: 0x06008B29 RID: 35625 RVA: 0x001291EB File Offset: 0x001273EB
		public XDragonGuildApproveDlg DragonGuildApproveView { get; set; }

		// Token: 0x17002B40 RID: 11072
		// (get) Token: 0x06008B2A RID: 35626 RVA: 0x001291F4 File Offset: 0x001273F4
		public List<XDragonGuildMember> ApproveList
		{
			get
			{
				return this.m_ApproveList;
			}
		}

		// Token: 0x17002B41 RID: 11073
		// (get) Token: 0x06008B2B RID: 35627 RVA: 0x0012920C File Offset: 0x0012740C
		public DragonGuildApproveSetting ApproveSetting
		{
			get
			{
				return this._ApproveSetting;
			}
		}

		// Token: 0x06008B2C RID: 35628 RVA: 0x00129224 File Offset: 0x00127424
		public void ReqApproveList()
		{
			RpcC2M_FetchDGApps rpc = new RpcC2M_FetchDGApps();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008B2D RID: 35629 RVA: 0x00129244 File Offset: 0x00127444
		public void OnGetApproveList(FetchDGAppRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				int num = oRes.roleid.Count - this.m_ApproveList.Count;
				bool flag2 = num > 0;
				if (flag2)
				{
					for (int i = 0; i < num; i++)
					{
						XDragonGuildMember item = new XDragonGuildMember();
						this.m_ApproveList.Add(item);
					}
				}
				else
				{
					this.m_ApproveList.RemoveRange(this.m_ApproveList.Count + num, -num);
				}
				for (int j = 0; j < oRes.roleid.Count; j++)
				{
					XDragonGuildMember xdragonGuildMember = this.m_ApproveList[j];
					xdragonGuildMember.uid = oRes.roleid[j];
					xdragonGuildMember.name = oRes.rolename[j];
					xdragonGuildMember.level = oRes.level[j];
					xdragonGuildMember.time = (int)oRes.time[j];
					xdragonGuildMember.ppt = oRes.ppt[j];
					xdragonGuildMember.profession = XFastEnumIntEqualityComparer<RoleType>.ToInt(oRes.profession[j]);
				}
				bool flag3 = this.DragonGuildApproveView != null && this.DragonGuildApproveView.IsVisible();
				if (flag3)
				{
					this.DragonGuildApproveView.RefreshList(true);
				}
			}
		}

		// Token: 0x06008B2E RID: 35630 RVA: 0x001293C4 File Offset: 0x001275C4
		public void ReqApprove(bool bApprove, int index)
		{
			bool flag = index < 0 || index >= this.m_ApproveList.Count;
			if (!flag)
			{
				RpcC2M_DragonGuildApproval rpcC2M_DragonGuildApproval = new RpcC2M_DragonGuildApproval();
				rpcC2M_DragonGuildApproval.oArg.roleid = this.m_ApproveList[index].uid;
				rpcC2M_DragonGuildApproval.oArg.type = (bApprove ? 0U : 1U);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DragonGuildApproval);
			}
		}

		// Token: 0x06008B2F RID: 35631 RVA: 0x00129434 File Offset: 0x00127634
		public void ReqRejectAll()
		{
			RpcC2M_DragonGuildApproval rpcC2M_DragonGuildApproval = new RpcC2M_DragonGuildApproval();
			rpcC2M_DragonGuildApproval.oArg.type = 2U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DragonGuildApproval);
		}

		// Token: 0x06008B30 RID: 35632 RVA: 0x00129464 File Offset: 0x00127664
		public void OnApprove(DragonGuildApprovalArg oArg, DragonGuildApprovalRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				bool flag2 = oArg.type == 2U;
				if (flag2)
				{
					this.m_ApproveList.Clear();
				}
				else
				{
					for (int i = 0; i < this.m_ApproveList.Count; i++)
					{
						bool flag3 = this.m_ApproveList[i].uid == oArg.roleid;
						if (flag3)
						{
							this.m_ApproveList.RemoveAt(i);
							bool flag4 = oArg.type == 0U;
							if (flag4)
							{
								XDragonGuildDocument.Doc.BaseData.memberCount += 1U;
							}
							break;
						}
					}
				}
				bool flag5 = this.DragonGuildApproveView == null || !this.DragonGuildApproveView.IsVisible();
				if (!flag5)
				{
					this.DragonGuildApproveView.RefreshMember();
					this.DragonGuildApproveView.RefreshList(oArg.type == 2U);
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshDragonGuildPage();
				}
			}
		}

		// Token: 0x06008B31 RID: 35633 RVA: 0x00129574 File Offset: 0x00127774
		public void ReqSetApprove(DragonGuildApproveSetting setting)
		{
			RpcC2M_ChangeDragonGuildSetting rpcC2M_ChangeDragonGuildSetting = new RpcC2M_ChangeDragonGuildSetting();
			rpcC2M_ChangeDragonGuildSetting.oArg.needapproval = (setting.autoApprove ? 0U : 1U);
			rpcC2M_ChangeDragonGuildSetting.oArg.powerpoint = setting.PPT;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeDragonGuildSetting);
		}

		// Token: 0x06008B32 RID: 35634 RVA: 0x001295C0 File Offset: 0x001277C0
		public void OnSetApprove(DragonGuildApproveSetting setting)
		{
			this._ApproveSetting = setting;
			bool flag = this.DragonGuildApproveView != null && this.DragonGuildApproveView.IsVisible();
			if (flag)
			{
				this.DragonGuildApproveView.RefreshSetting();
			}
		}

		// Token: 0x06008B33 RID: 35635 RVA: 0x00129600 File Offset: 0x00127800
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.DragonGuildApproveView != null && this.DragonGuildApproveView.IsVisible();
			if (flag)
			{
				this.ReqApproveList();
			}
		}

		// Token: 0x04002C7C RID: 11388
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonGuildApproveDocument");

		// Token: 0x04002C7E RID: 11390
		private List<XDragonGuildMember> m_ApproveList = new List<XDragonGuildMember>();

		// Token: 0x04002C7F RID: 11391
		private DragonGuildApproveSetting _ApproveSetting = new DragonGuildApproveSetting();
	}
}
