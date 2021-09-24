using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class RecruitListHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			this.m_titleBar = DlgHandlerBase.EnsureCreate<RecruitTitleBar>(ref this.m_titleBar, base.transform.Find("Title").gameObject, this, true);
			this.m_titleBar.RegisterTitleChange(new RecruitTitleChange(this.OnTitleChange));
			this.m_titleBar.RegisterTitleReSelect(new RecruitTitleReSelect(this.OnReSelect));
			this._MemberList = (base.transform.Find("MemberList").GetComponent("XUIScrollView") as IXUIScrollView);
			this._MemberWrapContent = (base.transform.Find("MemberList/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._MemberWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContent));
			this.m_empty = base.transform.Find("Empty");
			this.m_info = (base.transform.Find("Info/Info/Time").GetComponent("XUILabel") as IXUILabel);
		}

		public virtual void RefreshRedPoint()
		{
		}

		protected virtual List<GroupMember> GetMemberList()
		{
			return null;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_response = true;
			this.OnReSelect();
			this.RefreshInfo();
			this.RefreshRedPoint();
		}

		protected void RefreshInfo()
		{
			this.SetInfo(this.m_info);
		}

		public override void OnUnload()
		{
			bool flag = this._memberDisplay != null;
			if (flag)
			{
				this._memberDisplay.Release();
				this._memberDisplay = null;
			}
			DlgHandlerBase.EnsureUnload<RecruitTitleBar>(ref this.m_titleBar);
			base.OnUnload();
		}

		public override void RefreshData()
		{
			this.RefreshInfo();
			List<GroupMember> memberList = this.GetMemberList();
			bool flag = memberList == null || memberList.Count == 0;
			if (flag)
			{
				this.m_empty.gameObject.SetActive(true);
				this._MemberWrapContent.SetContentCount(0, false);
			}
			else
			{
				this.m_empty.gameObject.SetActive(false);
				this._MemberWrapContent.SetContentCount(memberList.Count, false);
			}
			bool response = this.m_response;
			if (response)
			{
				this.m_response = false;
				this._MemberList.ResetPosition();
			}
			base.RefreshData();
		}

		protected virtual void OnWrapContent(Transform t, int index)
		{
			List<GroupMember> memberList = this.GetMemberList();
			bool flag = memberList == null;
			if (!flag)
			{
				bool flag2 = this._memberDisplay == null;
				if (flag2)
				{
					this._memberDisplay = new GroupMemberDisplay();
				}
				GroupMember member = memberList[index];
				this._memberDisplay.Init(t);
				this._memberDisplay.Setup(member);
				this.SetupOtherInfo(t, member);
			}
		}

		protected virtual void SetupOtherInfo(Transform t, GroupMember member)
		{
		}

		protected virtual void OnTitleChange()
		{
			this.RefreshData();
		}

		public virtual void OnReSelect()
		{
		}

		protected virtual void SetInfo(IXUILabel label)
		{
		}

		protected GroupChatDocument _doc;

		protected RecruitTitleBar m_titleBar;

		protected Transform m_empty;

		protected IXUILabel m_info;

		private IXUIScrollView _MemberList;

		private IXUIWrapContent _MemberWrapContent;

		private GroupMemberDisplay _memberDisplay;

		private bool m_response = false;
	}
}
