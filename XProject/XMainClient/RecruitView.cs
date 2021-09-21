using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A41 RID: 2625
	internal class RecruitView : DlgBase<RecruitView, RecruitBehaviour>
	{
		// Token: 0x17002EDE RID: 11998
		// (get) Token: 0x06009F8A RID: 40842 RVA: 0x001A71DC File Offset: 0x001A53DC
		public override string fileName
		{
			get
			{
				return "Team/RecruitDlg";
			}
		}

		// Token: 0x06009F8B RID: 40843 RVA: 0x001A71F4 File Offset: 0x001A53F4
		public void RefreshRedPoint()
		{
			base.uiBehaviour._recruitRed.SetActive(this._doc.bShowMotion);
			bool flag = this._groupHandler != null && this._groupHandler.IsVisible();
			if (flag)
			{
				this._groupHandler.RefreshRedPoint();
			}
			bool flag2 = this._memberHandler != null && this._memberHandler.IsVisible();
			if (flag2)
			{
				this._memberHandler.RefreshRedPoint();
			}
		}

		// Token: 0x17002EDF RID: 11999
		// (get) Token: 0x06009F8C RID: 40844 RVA: 0x001A726C File Offset: 0x001A546C
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06009F8D RID: 40845 RVA: 0x001A7280 File Offset: 0x001A5480
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			this._groupHandler = DlgHandlerBase.EnsureCreate<RecruitGroupHandle>(ref this._groupHandler, base.uiBehaviour.m_group.gameObject, this, false);
			this._memberHandler = DlgHandlerBase.EnsureCreate<RecruitMemberHandler>(ref this._memberHandler, base.uiBehaviour.m_member.gameObject, this, false);
		}

		// Token: 0x06009F8E RID: 40846 RVA: 0x001A72EB File Offset: 0x001A54EB
		protected override void OnHide()
		{
			base.uiBehaviour._ToggleMember.bChecked = false;
			base.uiBehaviour._ToggleTeam.bChecked = false;
			base.OnHide();
		}

		// Token: 0x06009F8F RID: 40847 RVA: 0x001A7319 File Offset: 0x001A5519
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<RecruitGroupHandle>(ref this._groupHandler);
			DlgHandlerBase.EnsureUnload<RecruitMemberHandler>(ref this._memberHandler);
			base.OnUnload();
		}

		// Token: 0x06009F90 RID: 40848 RVA: 0x001A733B File Offset: 0x001A553B
		protected override void OnShow()
		{
			base.OnShow();
			this.OnSelectWhenShow();
			this.RefreshRedPoint();
			this.Refresh();
		}

		// Token: 0x06009F91 RID: 40849 RVA: 0x001A735C File Offset: 0x001A555C
		public void ReSelect()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				RecruitToggle curToggle = this._curToggle;
				if (curToggle != RecruitToggle.ToggleTeam)
				{
					if (curToggle == RecruitToggle.ToggleMember)
					{
						bool flag2 = this._memberHandler.IsVisible();
						if (flag2)
						{
							this._memberHandler.OnReSelect();
						}
					}
				}
				else
				{
					bool flag3 = this._groupHandler.IsVisible();
					if (flag3)
					{
						this._groupHandler.OnReSelect();
					}
				}
			}
		}

		// Token: 0x06009F92 RID: 40850 RVA: 0x001A73C8 File Offset: 0x001A55C8
		private void OnSelectWhenShow()
		{
			RecruitToggle curToggle = this._curToggle;
			if (curToggle != RecruitToggle.ToggleTeam)
			{
				if (curToggle == RecruitToggle.ToggleMember)
				{
					base.uiBehaviour._ToggleMember.bChecked = true;
				}
			}
			else
			{
				base.uiBehaviour._ToggleTeam.bChecked = true;
			}
			this.OnSelectVisible();
		}

		// Token: 0x06009F93 RID: 40851 RVA: 0x001A7418 File Offset: 0x001A5618
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour._BtnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour._ToggleMember.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnToggleChange));
			base.uiBehaviour._ToggleTeam.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnToggleChange));
			base.uiBehaviour._Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClick));
		}

		// Token: 0x06009F94 RID: 40852 RVA: 0x001A74A4 File Offset: 0x001A56A4
		private bool OnHelpClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GroupRecruit);
			return true;
		}

		// Token: 0x06009F95 RID: 40853 RVA: 0x001A74C8 File Offset: 0x001A56C8
		public void Refresh()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				RecruitToggle curToggle = this._curToggle;
				if (curToggle != RecruitToggle.ToggleTeam)
				{
					if (curToggle == RecruitToggle.ToggleMember)
					{
						bool flag2 = this._memberHandler.IsVisible();
						if (flag2)
						{
							this._memberHandler.RefreshData();
						}
					}
				}
				else
				{
					bool flag3 = this._groupHandler.IsVisible();
					if (flag3)
					{
						this._groupHandler.RefreshData();
					}
				}
			}
		}

		// Token: 0x06009F96 RID: 40854 RVA: 0x001A7531 File Offset: 0x001A5731
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x06009F97 RID: 40855 RVA: 0x001A753C File Offset: 0x001A573C
		private bool OnToggleChange(IXUICheckBox checkbox)
		{
			bool flag = !checkbox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._curToggle = (RecruitToggle)checkbox.ID;
				this.OnSelectVisible();
				result = false;
			}
			return result;
		}

		// Token: 0x06009F98 RID: 40856 RVA: 0x001A7574 File Offset: 0x001A5774
		private void OnSelectVisible()
		{
			this._memberHandler.SetVisible(this._curToggle == RecruitToggle.ToggleMember);
			this._groupHandler.SetVisible(this._curToggle == RecruitToggle.ToggleTeam);
		}

		// Token: 0x06009F99 RID: 40857 RVA: 0x001A75A4 File Offset: 0x001A57A4
		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x040038F5 RID: 14581
		private GroupChatDocument _doc;

		// Token: 0x040038F6 RID: 14582
		private RecruitToggle _curToggle = RecruitToggle.ToggleTeam;

		// Token: 0x040038F7 RID: 14583
		private RecruitGroupHandle _groupHandler;

		// Token: 0x040038F8 RID: 14584
		private RecruitMemberHandler _memberHandler;
	}
}
