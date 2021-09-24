using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildApproveDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildApproveDocument.uuID;
			}
		}

		public XGuildApproveView GuildApproveView { get; set; }

		public List<XGuildApplyInfo> ApproveList
		{
			get
			{
				return this.m_ApproveList;
			}
		}

		public GuildApproveSetting ApproveSetting
		{
			get
			{
				return this._ApproveSetting;
			}
		}

		public void ReqApproveList()
		{
			RpcC2M_FetchGuildApp rpc = new RpcC2M_FetchGuildApp();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetApproveList(FetchGAPPRes oRes)
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
						XGuildApplyInfo item = new XGuildApplyInfo();
						this.m_ApproveList.Add(item);
					}
				}
				else
				{
					this.m_ApproveList.RemoveRange(this.m_ApproveList.Count + num, -num);
				}
				for (int j = 0; j < oRes.roleid.Count; j++)
				{
					XGuildApplyInfo xguildApplyInfo = this.m_ApproveList[j];
					xguildApplyInfo.uid = oRes.roleid[j];
					xguildApplyInfo.name = oRes.rolename[j];
					xguildApplyInfo.level = oRes.level[j];
					xguildApplyInfo.time = (int)oRes.time[j];
					xguildApplyInfo.ppt = oRes.ppt[j];
					xguildApplyInfo.profession = XFastEnumIntEqualityComparer<RoleType>.ToInt(oRes.profession[j]);
				}
				bool flag3 = this.GuildApproveView != null && this.GuildApproveView.IsVisible();
				if (flag3)
				{
					this.GuildApproveView.RefreshList(true);
				}
			}
		}

		public void ReqApprove(bool bApprove, int index)
		{
			bool flag = index < 0 || index >= this.m_ApproveList.Count;
			if (!flag)
			{
				RpcC2M_GuildApprovalNew rpcC2M_GuildApprovalNew = new RpcC2M_GuildApprovalNew();
				rpcC2M_GuildApprovalNew.oArg.roleid = this.m_ApproveList[index].uid;
				rpcC2M_GuildApprovalNew.oArg.type = (bApprove ? 0 : 1);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildApprovalNew);
			}
		}

		public void ReqRejectAll()
		{
			RpcC2M_GuildApprovalNew rpcC2M_GuildApprovalNew = new RpcC2M_GuildApprovalNew();
			rpcC2M_GuildApprovalNew.oArg.type = 2;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildApprovalNew);
		}

		public void OnApprove(GuildApprovalArg oArg, GuildApprovalRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				bool flag2 = oArg.type == 2;
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
							XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
							bool flag4 = oArg.type == 0;
							if (flag4)
							{
								specificDocument.BasicData.memberCount += 1U;
							}
							break;
						}
					}
				}
				bool flag5 = this.GuildApproveView == null || !this.GuildApproveView.IsVisible();
				if (!flag5)
				{
					this.GuildApproveView.RefreshMember();
					this.GuildApproveView.RefreshList(oArg.type == 2);
				}
			}
		}

		public void ReqSetApprove(GuildApproveSetting setting)
		{
			RpcC2M_ChangeGuildSettingNew rpcC2M_ChangeGuildSettingNew = new RpcC2M_ChangeGuildSettingNew();
			rpcC2M_ChangeGuildSettingNew.oArg.needapproval = (setting.autoApprove ? 0 : 1);
			rpcC2M_ChangeGuildSettingNew.oArg.powerpoint = setting.PPT;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeGuildSettingNew);
		}

		public void OnSetApprove(GuildApproveSetting setting)
		{
			this._ApproveSetting = setting;
			bool flag = this.GuildApproveView != null && this.GuildApproveView.IsVisible();
			if (flag)
			{
				this.GuildApproveView.RefreshSetting();
			}
		}

		public void OnGuildBrief(GuildBriefRes oRes)
		{
			this._ApproveSetting.autoApprove = (oRes.needApproval == 0);
			this._ApproveSetting.PPT = (int)oRes.recuritppt;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildApproveView != null && this.GuildApproveView.IsVisible();
			if (flag)
			{
				this.ReqApproveList();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildApproveDocument");

		private List<XGuildApplyInfo> m_ApproveList = new List<XGuildApplyInfo>();

		private GuildApproveSetting _ApproveSetting = new GuildApproveSetting();
	}
}
