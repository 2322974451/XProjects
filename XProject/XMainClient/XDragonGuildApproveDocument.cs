using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildApproveDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDragonGuildApproveDocument.uuID;
			}
		}

		public XDragonGuildApproveDlg DragonGuildApproveView { get; set; }

		public List<XDragonGuildMember> ApproveList
		{
			get
			{
				return this.m_ApproveList;
			}
		}

		public DragonGuildApproveSetting ApproveSetting
		{
			get
			{
				return this._ApproveSetting;
			}
		}

		public void ReqApproveList()
		{
			RpcC2M_FetchDGApps rpc = new RpcC2M_FetchDGApps();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void ReqRejectAll()
		{
			RpcC2M_DragonGuildApproval rpcC2M_DragonGuildApproval = new RpcC2M_DragonGuildApproval();
			rpcC2M_DragonGuildApproval.oArg.type = 2U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DragonGuildApproval);
		}

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

		public void ReqSetApprove(DragonGuildApproveSetting setting)
		{
			RpcC2M_ChangeDragonGuildSetting rpcC2M_ChangeDragonGuildSetting = new RpcC2M_ChangeDragonGuildSetting();
			rpcC2M_ChangeDragonGuildSetting.oArg.needapproval = (setting.autoApprove ? 0U : 1U);
			rpcC2M_ChangeDragonGuildSetting.oArg.powerpoint = setting.PPT;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeDragonGuildSetting);
		}

		public void OnSetApprove(DragonGuildApproveSetting setting)
		{
			this._ApproveSetting = setting;
			bool flag = this.DragonGuildApproveView != null && this.DragonGuildApproveView.IsVisible();
			if (flag)
			{
				this.DragonGuildApproveView.RefreshSetting();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.DragonGuildApproveView != null && this.DragonGuildApproveView.IsVisible();
			if (flag)
			{
				this.ReqApproveList();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonGuildApproveDocument");

		private List<XDragonGuildMember> m_ApproveList = new List<XDragonGuildMember>();

		private DragonGuildApproveSetting _ApproveSetting = new DragonGuildApproveSetting();
	}
}
