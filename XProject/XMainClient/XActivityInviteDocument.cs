using System;
using System.Collections.Generic;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C33 RID: 3123
	internal class XActivityInviteDocument : XDocComponent
	{
		// Token: 0x1700313A RID: 12602
		// (get) Token: 0x0600B0CE RID: 45262 RVA: 0x0021D024 File Offset: 0x0021B224
		public override uint ID
		{
			get
			{
				return XActivityInviteDocument.uuID;
			}
		}

		// Token: 0x1700313B RID: 12603
		// (get) Token: 0x0600B0CF RID: 45263 RVA: 0x0021D03C File Offset: 0x0021B23C
		public static XActivityInviteDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XActivityInviteDocument.uuID) as XActivityInviteDocument;
			}
		}

		// Token: 0x1700313C RID: 12604
		// (get) Token: 0x0600B0D0 RID: 45264 RVA: 0x0021D067 File Offset: 0x0021B267
		// (set) Token: 0x0600B0D1 RID: 45265 RVA: 0x0021D06F File Offset: 0x0021B26F
		public XActivityInviteDocument.OpType CurOpType { get; private set; }

		// Token: 0x0600B0D2 RID: 45266 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void Execute(OnLoadedCallback callback = null)
		{
		}

		// Token: 0x0600B0D3 RID: 45267 RVA: 0x0021D078 File Offset: 0x0021B278
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.MemberInfos.Add(ActivityInviteTarget.Friend, new List<InviteMemberInfo>());
			this.MemberInfos.Add(ActivityInviteTarget.Guild, new List<InviteMemberInfo>());
		}

		// Token: 0x0600B0D4 RID: 45268 RVA: 0x0021D0A8 File Offset: 0x0021B2A8
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_GuildMemberList, new XComponent.XEventHandler(this.OnGuildMemberChanged));
			base.RegisterEvent(XEventDefine.XEvent_FriendInfoChange, new XComponent.XEventHandler(this.OnFriendMemberChanged));
			base.RegisterEvent(XEventDefine.XEvent_FriendList, new XComponent.XEventHandler(this.OnFriendMemberChanged));
		}

		// Token: 0x0600B0D5 RID: 45269 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600B0D6 RID: 45270 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600B0D7 RID: 45271 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600B0D8 RID: 45272 RVA: 0x0021D0FC File Offset: 0x0021B2FC
		public bool OnGuildMemberChanged(XEventArgs args)
		{
			XGuildMemberDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
			List<XGuildMember> memberList = specificDocument.MemberList;
			bool flag = this.MemberInfos.ContainsKey(ActivityInviteTarget.Guild);
			if (flag)
			{
				this.MemberInfos[ActivityInviteTarget.Guild].Clear();
			}
			else
			{
				this.MemberInfos[ActivityInviteTarget.Guild] = new List<InviteMemberInfo>();
			}
			List<InviteMemberInfo> list = this.MemberInfos[ActivityInviteTarget.Guild];
			for (int i = 0; i < memberList.Count; i++)
			{
				XGuildMember xguildMember = memberList[i];
				bool flag2 = !xguildMember.isOnline && this.ShouldBeOnline();
				if (!flag2)
				{
					list.Add(new InviteMemberInfo
					{
						uid = xguildMember.uid,
						name = xguildMember.name,
						level = xguildMember.level,
						ppt = xguildMember.ppt,
						vip = xguildMember.vip,
						profession = (uint)xguildMember.profession
					});
				}
			}
			bool flag3 = DlgBase<XActivityInviteView, XActivityInviteBehavior>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<XActivityInviteView, XActivityInviteBehavior>.singleton.Refresh(ActivityInviteTarget.Guild);
			}
			return true;
		}

		// Token: 0x0600B0D9 RID: 45273 RVA: 0x0021D230 File Offset: 0x0021B430
		public bool OnFriendMemberChanged(XEventArgs args)
		{
			List<XFriendData> friendData = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendData();
			bool flag = this.MemberInfos.ContainsKey(ActivityInviteTarget.Friend);
			if (flag)
			{
				this.MemberInfos[ActivityInviteTarget.Friend].Clear();
			}
			else
			{
				this.MemberInfos[ActivityInviteTarget.Friend] = new List<InviteMemberInfo>();
			}
			List<InviteMemberInfo> list = this.MemberInfos[ActivityInviteTarget.Friend];
			for (int i = 0; i < friendData.Count; i++)
			{
				XFriendData xfriendData = friendData[i];
				bool flag2 = xfriendData.online == 0U && this.ShouldBeOnline();
				if (!flag2)
				{
					list.Add(new InviteMemberInfo
					{
						uid = xfriendData.roleid,
						name = xfriendData.name,
						level = xfriendData.level,
						ppt = xfriendData.powerpoint,
						vip = xfriendData.viplevel,
						guildname = xfriendData.guildname,
						profession = xfriendData.profession,
						degree = xfriendData.degreeAll
					});
				}
			}
			list.Sort(new Comparison<InviteMemberInfo>(this.SortDegree));
			bool flag3 = DlgBase<XActivityInviteView, XActivityInviteBehavior>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<XActivityInviteView, XActivityInviteBehavior>.singleton.Refresh(ActivityInviteTarget.Friend);
			}
			return true;
		}

		// Token: 0x0600B0DA RID: 45274 RVA: 0x0021D388 File Offset: 0x0021B588
		private int SortDegree(InviteMemberInfo x, InviteMemberInfo y)
		{
			return (int)(y.degree - x.degree);
		}

		// Token: 0x0600B0DB RID: 45275 RVA: 0x0021D3A8 File Offset: 0x0021B5A8
		private bool ShouldBeOnline()
		{
			XActivityInviteDocument.OpType curOpType = this.CurOpType;
			return curOpType != XActivityInviteDocument.OpType.Send && (curOpType == XActivityInviteDocument.OpType.Invite || true);
		}

		// Token: 0x0600B0DC RID: 45276 RVA: 0x0021D3D8 File Offset: 0x0021B5D8
		public void ShowActivityInviteView(int type, XActivityInviteDocument.OpType req)
		{
			this.ShowType = type;
			bool flag = this.ShowType > 0;
			if (flag)
			{
				this.CurOpType = req;
				bool flag2 = !DlgBase<XActivityInviteView, XActivityInviteBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XActivityInviteView, XActivityInviteBehavior>.singleton.SetVisibleWithAnimation(true, null);
				}
			}
		}

		// Token: 0x0600B0DD RID: 45277 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SendTargetReq()
		{
		}

		// Token: 0x0600B0DE RID: 45278 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SendTargetReqSuccess()
		{
		}

		// Token: 0x0400440B RID: 17419
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ActivityInviteDocument");

		// Token: 0x0400440D RID: 17421
		public int ShowType = -1;

		// Token: 0x0400440E RID: 17422
		public Dictionary<ActivityInviteTarget, List<InviteMemberInfo>> MemberInfos = new Dictionary<ActivityInviteTarget, List<InviteMemberInfo>>();

		// Token: 0x020019A4 RID: 6564
		public enum OpType
		{
			// Token: 0x04007F59 RID: 32601
			Send,
			// Token: 0x04007F5A RID: 32602
			Invite
		}
	}
}
