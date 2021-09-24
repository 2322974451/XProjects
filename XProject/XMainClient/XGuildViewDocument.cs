using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildViewDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildViewDocument.uuID;
			}
		}

		public XGuildViewView GuildViewView { get; set; }

		public List<XGuildMemberBasicInfo> MemberList
		{
			get
			{
				return this.m_MemberList;
			}
		}

		public XGuildBasicData BasicData
		{
			get
			{
				return this.m_BasicData;
			}
		}

		public GuildApproveSetting ApproveSetting
		{
			get
			{
				return this._ApproveSetting;
			}
		}

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

		public void ReqInfo(ulong uid)
		{
			RpcC2M_AskGuildBriefInfo rpcC2M_AskGuildBriefInfo = new RpcC2M_AskGuildBriefInfo();
			rpcC2M_AskGuildBriefInfo.oArg.guildid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AskGuildBriefInfo);
			RpcC2M_AskGuildMembers rpcC2M_AskGuildMembers = new RpcC2M_AskGuildMembers();
			rpcC2M_AskGuildMembers.oArg.guildid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AskGuildMembers);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildViewView != null && this.GuildViewView.IsVisible();
			if (flag)
			{
				this.ReqInfo(this.m_BasicData.uid);
			}
		}

		public static void OnGuildHyperLinkClick(string param)
		{
			ulong id = ulong.Parse(param);
			XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
			specificDocument.View(id);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildViewDocument");

		private List<XGuildMemberBasicInfo> m_MemberList = new List<XGuildMemberBasicInfo>();

		private XGuildBasicData m_BasicData = new XGuildBasicData();

		private GuildApproveSetting _ApproveSetting = new GuildApproveSetting();
	}
}
