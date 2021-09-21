using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000A42 RID: 2626
	internal class RecruitListHandler : DlgHandlerBase
	{
		// Token: 0x06009F9B RID: 40859 RVA: 0x001A75D0 File Offset: 0x001A57D0
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

		// Token: 0x06009F9C RID: 40860 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void RefreshRedPoint()
		{
		}

		// Token: 0x06009F9D RID: 40861 RVA: 0x001A76E8 File Offset: 0x001A58E8
		protected virtual List<GroupMember> GetMemberList()
		{
			return null;
		}

		// Token: 0x06009F9E RID: 40862 RVA: 0x001A76FB File Offset: 0x001A58FB
		protected override void OnShow()
		{
			base.OnShow();
			this.m_response = true;
			this.OnReSelect();
			this.RefreshInfo();
			this.RefreshRedPoint();
		}

		// Token: 0x06009F9F RID: 40863 RVA: 0x001A7721 File Offset: 0x001A5921
		protected void RefreshInfo()
		{
			this.SetInfo(this.m_info);
		}

		// Token: 0x06009FA0 RID: 40864 RVA: 0x001A7734 File Offset: 0x001A5934
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

		// Token: 0x06009FA1 RID: 40865 RVA: 0x001A7778 File Offset: 0x001A5978
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

		// Token: 0x06009FA2 RID: 40866 RVA: 0x001A7818 File Offset: 0x001A5A18
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

		// Token: 0x06009FA3 RID: 40867 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetupOtherInfo(Transform t, GroupMember member)
		{
		}

		// Token: 0x06009FA4 RID: 40868 RVA: 0x001A787A File Offset: 0x001A5A7A
		protected virtual void OnTitleChange()
		{
			this.RefreshData();
		}

		// Token: 0x06009FA5 RID: 40869 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnReSelect()
		{
		}

		// Token: 0x06009FA6 RID: 40870 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetInfo(IXUILabel label)
		{
		}

		// Token: 0x040038F9 RID: 14585
		protected GroupChatDocument _doc;

		// Token: 0x040038FA RID: 14586
		protected RecruitTitleBar m_titleBar;

		// Token: 0x040038FB RID: 14587
		protected Transform m_empty;

		// Token: 0x040038FC RID: 14588
		protected IXUILabel m_info;

		// Token: 0x040038FD RID: 14589
		private IXUIScrollView _MemberList;

		// Token: 0x040038FE RID: 14590
		private IXUIWrapContent _MemberWrapContent;

		// Token: 0x040038FF RID: 14591
		private GroupMemberDisplay _memberDisplay;

		// Token: 0x04003900 RID: 14592
		private bool m_response = false;
	}
}
