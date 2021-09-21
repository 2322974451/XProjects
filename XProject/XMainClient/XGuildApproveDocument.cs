using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A76 RID: 2678
	internal class XGuildApproveDocument : XDocComponent
	{
		// Token: 0x17002F7C RID: 12156
		// (get) Token: 0x0600A2E1 RID: 41697 RVA: 0x001BCBD8 File Offset: 0x001BADD8
		public override uint ID
		{
			get
			{
				return XGuildApproveDocument.uuID;
			}
		}

		// Token: 0x17002F7D RID: 12157
		// (get) Token: 0x0600A2E2 RID: 41698 RVA: 0x001BCBEF File Offset: 0x001BADEF
		// (set) Token: 0x0600A2E3 RID: 41699 RVA: 0x001BCBF7 File Offset: 0x001BADF7
		public XGuildApproveView GuildApproveView { get; set; }

		// Token: 0x17002F7E RID: 12158
		// (get) Token: 0x0600A2E4 RID: 41700 RVA: 0x001BCC00 File Offset: 0x001BAE00
		public List<XGuildApplyInfo> ApproveList
		{
			get
			{
				return this.m_ApproveList;
			}
		}

		// Token: 0x17002F7F RID: 12159
		// (get) Token: 0x0600A2E5 RID: 41701 RVA: 0x001BCC18 File Offset: 0x001BAE18
		public GuildApproveSetting ApproveSetting
		{
			get
			{
				return this._ApproveSetting;
			}
		}

		// Token: 0x0600A2E7 RID: 41703 RVA: 0x001BCC48 File Offset: 0x001BAE48
		public void ReqApproveList()
		{
			RpcC2M_FetchGuildApp rpc = new RpcC2M_FetchGuildApp();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A2E8 RID: 41704 RVA: 0x001BCC68 File Offset: 0x001BAE68
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

		// Token: 0x0600A2E9 RID: 41705 RVA: 0x001BCDE8 File Offset: 0x001BAFE8
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

		// Token: 0x0600A2EA RID: 41706 RVA: 0x001BCE58 File Offset: 0x001BB058
		public void ReqRejectAll()
		{
			RpcC2M_GuildApprovalNew rpcC2M_GuildApprovalNew = new RpcC2M_GuildApprovalNew();
			rpcC2M_GuildApprovalNew.oArg.type = 2;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildApprovalNew);
		}

		// Token: 0x0600A2EB RID: 41707 RVA: 0x001BCE88 File Offset: 0x001BB088
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

		// Token: 0x0600A2EC RID: 41708 RVA: 0x001BCF98 File Offset: 0x001BB198
		public void ReqSetApprove(GuildApproveSetting setting)
		{
			RpcC2M_ChangeGuildSettingNew rpcC2M_ChangeGuildSettingNew = new RpcC2M_ChangeGuildSettingNew();
			rpcC2M_ChangeGuildSettingNew.oArg.needapproval = (setting.autoApprove ? 0 : 1);
			rpcC2M_ChangeGuildSettingNew.oArg.powerpoint = setting.PPT;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeGuildSettingNew);
		}

		// Token: 0x0600A2ED RID: 41709 RVA: 0x001BCFE4 File Offset: 0x001BB1E4
		public void OnSetApprove(GuildApproveSetting setting)
		{
			this._ApproveSetting = setting;
			bool flag = this.GuildApproveView != null && this.GuildApproveView.IsVisible();
			if (flag)
			{
				this.GuildApproveView.RefreshSetting();
			}
		}

		// Token: 0x0600A2EE RID: 41710 RVA: 0x001BD021 File Offset: 0x001BB221
		public void OnGuildBrief(GuildBriefRes oRes)
		{
			this._ApproveSetting.autoApprove = (oRes.needApproval == 0);
			this._ApproveSetting.PPT = (int)oRes.recuritppt;
		}

		// Token: 0x0600A2EF RID: 41711 RVA: 0x001BD04C File Offset: 0x001BB24C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildApproveView != null && this.GuildApproveView.IsVisible();
			if (flag)
			{
				this.ReqApproveList();
			}
		}

		// Token: 0x04003AD8 RID: 15064
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildApproveDocument");

		// Token: 0x04003ADA RID: 15066
		private List<XGuildApplyInfo> m_ApproveList = new List<XGuildApplyInfo>();

		// Token: 0x04003ADB RID: 15067
		private GuildApproveSetting _ApproveSetting = new GuildApproveSetting();
	}
}
