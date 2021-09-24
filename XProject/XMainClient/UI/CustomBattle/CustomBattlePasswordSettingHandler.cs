using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI.CustomBattle
{

	internal class CustomBattlePasswordSettingHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/PasswordSettingFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._ok = (base.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this._cancel = (base.transform.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
			this._password = (base.transform.Find("Password").GetComponent("XUIInput") as IXUIInput);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._ok.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKButtonClicked));
			this._cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelButtonClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.passwordForJoin = this._doc.passwordForJoin;
			this._doc.passwordForJoin = false;
			this.RefreshData();
		}

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

		private XCustomBattleDocument _doc = null;

		private IXUIButton _ok;

		private IXUIButton _cancel;

		private IXUIInput _password;

		private bool passwordForJoin = false;
	}
}
