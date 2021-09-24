using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class RecruitView : DlgBase<RecruitView, RecruitBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/RecruitDlg";
			}
		}

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

		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			this._groupHandler = DlgHandlerBase.EnsureCreate<RecruitGroupHandle>(ref this._groupHandler, base.uiBehaviour.m_group.gameObject, this, false);
			this._memberHandler = DlgHandlerBase.EnsureCreate<RecruitMemberHandler>(ref this._memberHandler, base.uiBehaviour.m_member.gameObject, this, false);
		}

		protected override void OnHide()
		{
			base.uiBehaviour._ToggleMember.bChecked = false;
			base.uiBehaviour._ToggleTeam.bChecked = false;
			base.OnHide();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<RecruitGroupHandle>(ref this._groupHandler);
			DlgHandlerBase.EnsureUnload<RecruitMemberHandler>(ref this._memberHandler);
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnSelectWhenShow();
			this.RefreshRedPoint();
			this.Refresh();
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour._BtnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour._ToggleMember.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnToggleChange));
			base.uiBehaviour._ToggleTeam.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnToggleChange));
			base.uiBehaviour._Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClick));
		}

		private bool OnHelpClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GroupRecruit);
			return true;
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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

		private void OnSelectVisible()
		{
			this._memberHandler.SetVisible(this._curToggle == RecruitToggle.ToggleMember);
			this._groupHandler.SetVisible(this._curToggle == RecruitToggle.ToggleTeam);
		}

		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private GroupChatDocument _doc;

		private RecruitToggle _curToggle = RecruitToggle.ToggleTeam;

		private RecruitGroupHandle _groupHandler;

		private RecruitMemberHandler _memberHandler;
	}
}
