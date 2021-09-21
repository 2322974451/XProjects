using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001875 RID: 6261
	internal class RenameDlg : DlgBase<RenameDlg, RenameBehaviour>
	{
		// Token: 0x170039BD RID: 14781
		// (get) Token: 0x060104B6 RID: 66742 RVA: 0x003F1410 File Offset: 0x003EF610
		public override string fileName
		{
			get
			{
				return "GameSystem/ReNameDlg";
			}
		}

		// Token: 0x170039BE RID: 14782
		// (get) Token: 0x060104B7 RID: 66743 RVA: 0x003F1428 File Offset: 0x003EF628
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x170039BF RID: 14783
		// (get) Token: 0x060104B8 RID: 66744 RVA: 0x003F143C File Offset: 0x003EF63C
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170039C0 RID: 14784
		// (get) Token: 0x060104B9 RID: 66745 RVA: 0x003F1450 File Offset: 0x003EF650
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060104BA RID: 66746 RVA: 0x003F1463 File Offset: 0x003EF663
		public void ShowRenameSystem(XRenameDocument.RenameType type)
		{
			this.curType = type;
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x060104BB RID: 66747 RVA: 0x003F1476 File Offset: 0x003EF676
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			this.SwitchRenameShow();
		}

		// Token: 0x060104BC RID: 66748 RVA: 0x003F1498 File Offset: 0x003EF698
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickClose));
			base.uiBehaviour.mOk.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickSure));
		}

		// Token: 0x060104BD RID: 66749 RVA: 0x003F14E7 File Offset: 0x003EF6E7
		private void ClickClose(IXUISprite sprite)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x060104BE RID: 66750 RVA: 0x003F14F4 File Offset: 0x003EF6F4
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

		// Token: 0x060104BF RID: 66751 RVA: 0x003F1618 File Offset: 0x003EF818
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

		// Token: 0x060104C0 RID: 66752 RVA: 0x003F1694 File Offset: 0x003EF894
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

		// Token: 0x060104C1 RID: 66753 RVA: 0x003F1712 File Offset: 0x003EF912
		private void SurePlayerRenameVolume()
		{
			this._Doc.SendPlayerConstRename(this.mTargetName, true);
		}

		// Token: 0x060104C2 RID: 66754 RVA: 0x003F1728 File Offset: 0x003EF928
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

		// Token: 0x060104C3 RID: 66755 RVA: 0x003F1804 File Offset: 0x003EFA04
		private bool OnSurePlayerRename(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._Doc.SendPlayerConstRename(this.mTargetName, false);
			return true;
		}

		// Token: 0x060104C4 RID: 66756 RVA: 0x003F1838 File Offset: 0x003EFA38
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

		// Token: 0x060104C5 RID: 66757 RVA: 0x003F188C File Offset: 0x003EFA8C
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

		// Token: 0x060104C6 RID: 66758 RVA: 0x003F196C File Offset: 0x003EFB6C
		private void ShowPlayerRenameVolume()
		{
			base.uiBehaviour.mInput.SetText(string.Empty);
			base.uiBehaviour.mInputText.SetText(XStringDefineProxy.GetString("RenameInputDefault"));
			base.uiBehaviour.mTitle.SetText(XStringDefineProxy.GetString("RenamePlayerTitle"));
			base.uiBehaviour.mMessage.SetText(string.Empty);
		}

		// Token: 0x060104C7 RID: 66759 RVA: 0x003F19DC File Offset: 0x003EFBDC
		private void ShowGuildRenameVolume()
		{
			base.uiBehaviour.mInput.SetText(string.Empty);
			base.uiBehaviour.mInputText.SetText(XStringDefineProxy.GetString("RenameInputDefault"));
			base.uiBehaviour.mTitle.SetText(XStringDefineProxy.GetString("RenameGuildTitle"));
			base.uiBehaviour.mMessage.SetText(string.Empty);
		}

		// Token: 0x060104C8 RID: 66760 RVA: 0x003F1A4C File Offset: 0x003EFC4C
		private void ShowDragonGuildRenameVolume()
		{
			base.uiBehaviour.mInput.SetText(string.Empty);
			base.uiBehaviour.mInputText.SetText(XStringDefineProxy.GetString("RenameInputDefault"));
			base.uiBehaviour.mTitle.SetText(XStringDefineProxy.GetString("RenameDragonGuildTitle"));
			base.uiBehaviour.mMessage.SetText(string.Empty);
		}

		// Token: 0x04007533 RID: 30003
		private XRenameDocument _Doc;

		// Token: 0x04007534 RID: 30004
		private string mTargetName = string.Empty;

		// Token: 0x04007535 RID: 30005
		private XRenameDocument.RenameType curType = XRenameDocument.RenameType.PLAYER_NAME_COST;
	}
}
