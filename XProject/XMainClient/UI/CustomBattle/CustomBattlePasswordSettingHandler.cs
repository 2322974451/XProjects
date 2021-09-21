using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI.CustomBattle
{
	// Token: 0x02001936 RID: 6454
	internal class CustomBattlePasswordSettingHandler : DlgHandlerBase
	{
		// Token: 0x17003B2C RID: 15148
		// (get) Token: 0x06010F7F RID: 69503 RVA: 0x00451484 File Offset: 0x0044F684
		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/PasswordSettingFrame";
			}
		}

		// Token: 0x06010F80 RID: 69504 RVA: 0x0045149C File Offset: 0x0044F69C
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._ok = (base.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this._cancel = (base.transform.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
			this._password = (base.transform.Find("Password").GetComponent("XUIInput") as IXUIInput);
		}

		// Token: 0x06010F81 RID: 69505 RVA: 0x00451530 File Offset: 0x0044F730
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._ok.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKButtonClicked));
			this._cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelButtonClicked));
		}

		// Token: 0x06010F82 RID: 69506 RVA: 0x0045156A File Offset: 0x0044F76A
		protected override void OnShow()
		{
			base.OnShow();
			this.passwordForJoin = this._doc.passwordForJoin;
			this._doc.passwordForJoin = false;
			this.RefreshData();
		}

		// Token: 0x06010F83 RID: 69507 RVA: 0x0045159C File Offset: 0x0044F79C
		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler.IsVisible();
			if (flag)
			{
				bool flag2 = this._doc.CustomCreateData.hasPassword && !string.IsNullOrEmpty(this._doc.CustomCreateData.password);
				if (flag2)
				{
					this._password.SetText(this._doc.CustomCreateData.password);
				}
			}
		}

		// Token: 0x06010F84 RID: 69508 RVA: 0x00451624 File Offset: 0x0044F824
		private bool OnOKButtonClicked(IXUIButton button)
		{
			bool flag = this.passwordForJoin;
			bool result;
			if (flag)
			{
				bool flag2 = this._password.GetText() == this._password.GetDefault();
				if (flag2)
				{
					this._doc.SendCustomBattleJoin(this._doc.CurrentCustomData.gameID, false, "");
				}
				else
				{
					this._doc.SendCustomBattleJoin(this._doc.CurrentCustomData.gameID, false, this._password.GetText());
				}
				base.SetVisible(false);
				result = true;
			}
			else
			{
				bool flag3 = this._password.GetText() == "" || this._password.GetText() == this._password.GetDefault();
				if (flag3)
				{
					bool flag4 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler.IsVisible();
					if (flag4)
					{
						this._doc.CustomCreateData.hasPassword = false;
						this._doc.CustomCreateData.password = "";
						DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler.SetPasswordSwitchSprite(false);
					}
				}
				else
				{
					bool flag5 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler.IsVisible();
					if (flag5)
					{
						this._doc.CustomCreateData.hasPassword = true;
						this._doc.CustomCreateData.password = this._password.GetText();
						DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler.SetPasswordSwitchSprite(true);
					}
				}
				bool flag6 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeBriefHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeBriefHandler.IsVisible();
				if (flag6)
				{
					this._doc.SendCustomBattleModifyPassword(this._doc.CurrentCustomData.gameID, this._password.GetText());
				}
				base.SetVisible(false);
				result = true;
			}
			return result;
		}

		// Token: 0x06010F85 RID: 69509 RVA: 0x00451814 File Offset: 0x0044FA14
		private bool OnCancelButtonClicked(IXUIButton button)
		{
			bool flag = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler.IsVisible();
			if (flag)
			{
				this._doc.CustomCreateData.hasPassword = false;
				this._doc.CustomCreateData.password = "";
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler.SetPasswordSwitchSprite(false);
			}
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04007D0B RID: 32011
		private XCustomBattleDocument _doc = null;

		// Token: 0x04007D0C RID: 32012
		private IXUIButton _ok;

		// Token: 0x04007D0D RID: 32013
		private IXUIButton _cancel;

		// Token: 0x04007D0E RID: 32014
		private IXUIInput _password;

		// Token: 0x04007D0F RID: 32015
		private bool passwordForJoin = false;
	}
}
