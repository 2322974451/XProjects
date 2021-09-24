using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RenameDlg : DlgBase<RenameDlg, RenameBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ReNameDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public void ShowRenameSystem(XRenameDocument.RenameType type)
		{
			this.curType = type;
			this.SetVisibleWithAnimation(true, null);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			this.SwitchRenameShow();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickClose));
			base.uiBehaviour.mOk.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickSure));
		}

		private void ClickClose(IXUISprite sprite)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		private bool ClickSure(IXUIButton btn)
		{
			this.mTargetName = base.uiBehaviour.mInputText.GetText();
			bool flag = string.IsNullOrEmpty(this.mTargetName) || this.mTargetName.Contains(" ");
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenameInputNullString"), "fece00");
				result = false;
			}
			else
			{
				string @string = XStringDefineProxy.GetString("RenameInputDefault");
				bool flag2 = this.mTargetName.Equals(@string);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenameInputInputName"), "fece00");
					result = false;
				}
				else
				{
					bool flag3 = this.mTargetName.Length > 8;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenamePlayerSizeErr"), "fece00");
						result = false;
					}
					else
					{
						switch (this.curType)
						{
						case XRenameDocument.RenameType.GUILD_NAME_VOLUME:
							this.SureGuildRenameVolume();
							break;
						case XRenameDocument.RenameType.PLAYER_NAME_VOLUME:
							this.SurePlayerRenameVolume();
							break;
						case XRenameDocument.RenameType.PLAYER_NAME_COST:
							this.SurePlayerRenameCost();
							break;
						case XRenameDocument.RenameType.DRAGON_GUILD_NAME_VOLUME:
							this.SureDragonGuildRenameVolume();
							break;
						}
						result = true;
					}
				}
			}
			return result;
		}

		private void SureDragonGuildRenameVolume()
		{
			XDragonGuildDocument doc = XDragonGuildDocument.Doc;
			bool flag = doc.IsInDragonGuild();
			if (flag)
			{
				bool flag2 = doc.Position > DragonGuildPosition.DGPOS_LEADER;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_DG_NO_PERMISSION"), "fece00");
				}
				else
				{
					this._Doc.SendDragonGuildRenameVolume(this.mTargetName);
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_DG_NOT_IN_GUILD"), "fece00");
			}
		}

		private void SureGuildRenameVolume()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool bInGuild = specificDocument.bInGuild;
			if (bInGuild)
			{
				bool flag = specificDocument.Position > GuildPosition.GPOS_LEADER;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_GUILD_NO_PERMISSION"), "fece00");
				}
				else
				{
					this._Doc.SendGuildRenameVolume(this.mTargetName);
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WORLDBOSS_NO_GUILD"), "fece00");
			}
		}

		private void SurePlayerRenameVolume()
		{
			this._Doc.SendPlayerConstRename(this.mTargetName, true);
		}

		private void SurePlayerRenameCost()
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			bool flag = (ulong)level < (ulong)((long)XSingleton<XGlobalConfig>.singleton.GetInt("RenamePlayerFreeCost"));
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RenamePlayerLevelLow"), "fece00");
			}
			else
			{
				string label = (this._Doc.renameTimes < 1U) ? XStringDefineProxy.GetString("RenamePlayerSureChange", new object[]
				{
					this.mTargetName
				}) : XStringDefineProxy.GetString("RenamePlayerSureCost", new object[]
				{
					this._Doc.GetRenameCost(this._Doc.renameTimes)
				});
				XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnSurePlayerRename));
			}
		}

		private bool OnSurePlayerRename(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._Doc.SendPlayerConstRename(this.mTargetName, false);
			return true;
		}

		private void SwitchRenameShow()
		{
			switch (this.curType)
			{
			case XRenameDocument.RenameType.GUILD_NAME_VOLUME:
				this.ShowGuildRenameVolume();
				break;
			case XRenameDocument.RenameType.PLAYER_NAME_VOLUME:
				this.ShowPlayerRenameVolume();
				break;
			case XRenameDocument.RenameType.PLAYER_NAME_COST:
				this.ShowPlayerRenameCost();
				break;
			case XRenameDocument.RenameType.DRAGON_GUILD_NAME_VOLUME:
				this.ShowDragonGuildRenameVolume();
				break;
			}
		}

		private void ShowPlayerRenameCost()
		{
			base.uiBehaviour.mInput.SetText(string.Empty);
			base.uiBehaviour.mInputText.SetText(XStringDefineProxy.GetString("RenameInputDefault"));
			base.uiBehaviour.mTitle.SetText(XStringDefineProxy.GetString("RenamePlayerTitle"));
			bool flag = this._Doc.renameTimes < 1U;
			if (flag)
			{
				base.uiBehaviour.mMessage.SetText(XStringDefineProxy.GetString("RenamePlayerFreeCost", new object[]
				{
					XSingleton<XGlobalConfig>.singleton.GetValue("RenamePlayerFreeCost")
				}));
			}
			else
			{
				base.uiBehaviour.mMessage.SetText(XStringDefineProxy.GetString("RenamePlayerCost", new object[]
				{
					this._Doc.GetRenameCost(this._Doc.renameTimes)
				}));
			}
		}

		private void ShowPlayerRenameVolume()
		{
			base.uiBehaviour.mInput.SetText(string.Empty);
			base.uiBehaviour.mInputText.SetText(XStringDefineProxy.GetString("RenameInputDefault"));
			base.uiBehaviour.mTitle.SetText(XStringDefineProxy.GetString("RenamePlayerTitle"));
			base.uiBehaviour.mMessage.SetText(string.Empty);
		}

		private void ShowGuildRenameVolume()
		{
			base.uiBehaviour.mInput.SetText(string.Empty);
			base.uiBehaviour.mInputText.SetText(XStringDefineProxy.GetString("RenameInputDefault"));
			base.uiBehaviour.mTitle.SetText(XStringDefineProxy.GetString("RenameGuildTitle"));
			base.uiBehaviour.mMessage.SetText(string.Empty);
		}

		private void ShowDragonGuildRenameVolume()
		{
			base.uiBehaviour.mInput.SetText(string.Empty);
			base.uiBehaviour.mInputText.SetText(XStringDefineProxy.GetString("RenameInputDefault"));
			base.uiBehaviour.mTitle.SetText(XStringDefineProxy.GetString("RenameDragonGuildTitle"));
			base.uiBehaviour.mMessage.SetText(string.Empty);
		}

		private XRenameDocument _Doc;

		private string mTargetName = string.Empty;

		private XRenameDocument.RenameType curType = XRenameDocument.RenameType.PLAYER_NAME_COST;
	}
}
