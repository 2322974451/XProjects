using System;
using System.Collections.Generic;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XActivityInviteDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XActivityInviteDocument.uuID;
			}
		}

		public static XActivityInviteDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XActivityInviteDocument.uuID) as XActivityInviteDocument;
			}
		}

		public XActivityInviteDocument.OpType CurOpType { get; private set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.MemberInfos.Add(ActivityInviteTarget.Friend, new List<InviteMemberInfo>());
			this.MemberInfos.Add(ActivityInviteTarget.Guild, new List<InviteMemberInfo>());
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_GuildMemberList, new XComponent.XEventHandler(this.OnGuildMemberChanged));
			base.RegisterEvent(XEventDefine.XEvent_FriendInfoChange, new XComponent.XEventHandler(this.OnFriendMemberChanged));
			base.RegisterEvent(XEventDefine.XEvent_FriendList, new XComponent.XEventHandler(this.OnFriendMemberChanged));
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		private int SortDegree(InviteMemberInfo x, InviteMemberInfo y)
		{
			return (int)(y.degree - x.degree);
		}

		private bool ShouldBeOnline()
		{
			XActivityInviteDocument.OpType curOpType = this.CurOpType;
			return curOpType != XActivityInviteDocument.OpType.Send && (curOpType == XActivityInviteDocument.OpType.Invite || true);
		}

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

		public void SendTargetReq()
		{
		}

		public void SendTargetReqSuccess()
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ActivityInviteDocument");

		public int ShowType = -1;

		public Dictionary<ActivityInviteTarget, List<InviteMemberInfo>> MemberInfos = new Dictionary<ActivityInviteTarget, List<InviteMemberInfo>>();

		public enum OpType
		{

			Send,

			Invite
		}
	}
}
