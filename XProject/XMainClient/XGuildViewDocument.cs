using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A7A RID: 2682
	internal class XGuildViewDocument : XDocComponent
	{
		// Token: 0x17002F8F RID: 12175
		// (get) Token: 0x0600A338 RID: 41784 RVA: 0x001BE59C File Offset: 0x001BC79C
		public override uint ID
		{
			get
			{
				return XGuildViewDocument.uuID;
			}
		}

		// Token: 0x17002F90 RID: 12176
		// (get) Token: 0x0600A339 RID: 41785 RVA: 0x001BE5B3 File Offset: 0x001BC7B3
		// (set) Token: 0x0600A33A RID: 41786 RVA: 0x001BE5BB File Offset: 0x001BC7BB
		public XGuildViewView GuildViewView { get; set; }

		// Token: 0x17002F91 RID: 12177
		// (get) Token: 0x0600A33B RID: 41787 RVA: 0x001BE5C4 File Offset: 0x001BC7C4
		public List<XGuildMemberBasicInfo> MemberList
		{
			get
			{
				return this.m_MemberList;
			}
		}

		// Token: 0x17002F92 RID: 12178
		// (get) Token: 0x0600A33C RID: 41788 RVA: 0x001BE5DC File Offset: 0x001BC7DC
		public XGuildBasicData BasicData
		{
			get
			{
				return this.m_BasicData;
			}
		}

		// Token: 0x17002F93 RID: 12179
		// (get) Token: 0x0600A33D RID: 41789 RVA: 0x001BE5F4 File Offset: 0x001BC7F4
		public GuildApproveSetting ApproveSetting
		{
			get
			{
				return this._ApproveSetting;
			}
		}

		// Token: 0x0600A33F RID: 41791 RVA: 0x001BE624 File Offset: 0x001BC824
		public void View(XGuildBasicData basicData)
		{
			this.m_BasicData = basicData;
			this.ReqInfo(basicData.uid);
			bool flag = !DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x0600A340 RID: 41792 RVA: 0x001BE664 File Offset: 0x001BC864
		public void View(ulong id)
		{
			this.m_BasicData.uid = id;
			this.ReqInfo(this.m_BasicData.uid);
			bool flag = !DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x0600A341 RID: 41793 RVA: 0x001BE6B0 File Offset: 0x001BC8B0
		public void ReqInfo(ulong uid)
		{
			RpcC2M_AskGuildBriefInfo rpcC2M_AskGuildBriefInfo = new RpcC2M_AskGuildBriefInfo();
			rpcC2M_AskGuildBriefInfo.oArg.guildid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AskGuildBriefInfo);
			RpcC2M_AskGuildMembers rpcC2M_AskGuildMembers = new RpcC2M_AskGuildMembers();
			rpcC2M_AskGuildMembers.oArg.guildid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AskGuildMembers);
		}

		// Token: 0x0600A342 RID: 41794 RVA: 0x001BE6FC File Offset: 0x001BC8FC
		public void OnGuildBrief(GuildBriefRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this.m_BasicData.Init(oRes);
				this.ApproveSetting.autoApprove = (oRes.needApproval == 0);
				this.ApproveSetting.PPT = (int)oRes.recuritppt;
				bool flag2 = this.GuildViewView != null && this.GuildViewView.IsVisible();
				if (flag2)
				{
					this.GuildViewView.RefreshBasicInfo();
				}
			}
		}

		// Token: 0x0600A343 RID: 41795 RVA: 0x001BE78C File Offset: 0x001BC98C
		public void onGetMemberList(GuildMemberRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				int num = oRes.members.Count - this.m_MemberList.Count;
				for (int i = 0; i < num; i++)
				{
					XGuildMemberBasicInfo item = new XGuildMemberBasicInfo();
					this.m_MemberList.Add(item);
				}
				bool flag2 = num < 0;
				if (flag2)
				{
					this.m_MemberList.RemoveRange(this.m_MemberList.Count + num, -num);
				}
				for (int j = 0; j < oRes.members.Count; j++)
				{
					XGuildMemberBasicInfo xguildMemberBasicInfo = this.m_MemberList[j];
					GuildMemberData guildMemberData = oRes.members[j];
					xguildMemberBasicInfo.uid = guildMemberData.roleid;
					xguildMemberBasicInfo.name = guildMemberData.name;
					xguildMemberBasicInfo.position = (GuildPosition)guildMemberData.position;
					xguildMemberBasicInfo.profession = XFastEnumIntEqualityComparer<RoleType>.ToInt(guildMemberData.profession);
					xguildMemberBasicInfo.level = guildMemberData.level;
					xguildMemberBasicInfo.ppt = guildMemberData.ppt;
					xguildMemberBasicInfo.time = (int)guildMemberData.lastlogin;
				}
				bool flag3 = this.GuildViewView != null && this.GuildViewView.IsVisible();
				if (flag3)
				{
					this.GuildViewView.RefreshMembers();
				}
			}
		}

		// Token: 0x0600A344 RID: 41796 RVA: 0x001BE900 File Offset: 0x001BCB00
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildViewView != null && this.GuildViewView.IsVisible();
			if (flag)
			{
				this.ReqInfo(this.m_BasicData.uid);
			}
		}

		// Token: 0x0600A345 RID: 41797 RVA: 0x001BE93C File Offset: 0x001BCB3C
		public static void OnGuildHyperLinkClick(string param)
		{
			ulong id = ulong.Parse(param);
			XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
			specificDocument.View(id);
		}

		// Token: 0x04003AF4 RID: 15092
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildViewDocument");

		// Token: 0x04003AF6 RID: 15094
		private List<XGuildMemberBasicInfo> m_MemberList = new List<XGuildMemberBasicInfo>();

		// Token: 0x04003AF7 RID: 15095
		private XGuildBasicData m_BasicData = new XGuildBasicData();

		// Token: 0x04003AF8 RID: 15096
		private GuildApproveSetting _ApproveSetting = new GuildApproveSetting();
	}
}
