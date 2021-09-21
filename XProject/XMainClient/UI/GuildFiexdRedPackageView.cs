using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001757 RID: 5975
	internal class GuildFiexdRedPackageView : DlgBase<GuildFiexdRedPackageView, GuildFiexdRedPackageBehaviour>
	{
		// Token: 0x170037FB RID: 14331
		// (get) Token: 0x0600F6CB RID: 63179 RVA: 0x00380BA4 File Offset: 0x0037EDA4
		public override string fileName
		{
			get
			{
				return "Guild/GuildFiexdRedPacketDlg";
			}
		}

		// Token: 0x170037FC RID: 14332
		// (get) Token: 0x0600F6CC RID: 63180 RVA: 0x00380BBC File Offset: 0x0037EDBC
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SevenActivity);
			}
		}

		// Token: 0x170037FD RID: 14333
		// (get) Token: 0x0600F6CD RID: 63181 RVA: 0x00380BD8 File Offset: 0x0037EDD8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037FE RID: 14334
		// (get) Token: 0x0600F6CE RID: 63182 RVA: 0x00380BEC File Offset: 0x0037EDEC
		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170037FF RID: 14335
		// (get) Token: 0x0600F6CF RID: 63183 RVA: 0x00380C00 File Offset: 0x0037EE00
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F6D0 RID: 63184 RVA: 0x00380C13 File Offset: 0x0037EE13
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		// Token: 0x0600F6D1 RID: 63185 RVA: 0x00380C4C File Offset: 0x0037EE4C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
			base.uiBehaviour.m_HelpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickHelp));
		}

		// Token: 0x0600F6D2 RID: 63186 RVA: 0x00380C9B File Offset: 0x0037EE9B
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendGuildBonusSendList();
		}

		// Token: 0x0600F6D3 RID: 63187 RVA: 0x00380CB4 File Offset: 0x0037EEB4
		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x0600F6D4 RID: 63188 RVA: 0x00380CD0 File Offset: 0x0037EED0
		private bool OnSendClick(IXUIButton btn)
		{
			this._Doc.SendGuildBonusInSend((uint)btn.ID);
			return true;
		}

		// Token: 0x0600F6D5 RID: 63189 RVA: 0x00380CF8 File Offset: 0x0037EEF8
		private bool ClickHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildBoon_FixedRedPacket);
			return true;
		}

		// Token: 0x0600F6D6 RID: 63190 RVA: 0x00380D1C File Offset: 0x0037EF1C
		public void Refresh()
		{
			int count = this._Doc.GuildBonusSendList.Count;
			base.uiBehaviour.m_WrapContent.SetContentCount(count, false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
			base.uiBehaviour.m_Empty.gameObject.SetActive(count == 0);
		}

		// Token: 0x0600F6D7 RID: 63191 RVA: 0x00380D7C File Offset: 0x0037EF7C
		private void OnWrapContentUpdate(Transform t, int index)
		{
			bool flag = index >= this._Doc.GuildBonusSendList.Count;
			if (!flag)
			{
				IXUIButton ixuibutton = t.FindChild("Go").GetComponent("XUIButton") as IXUIButton;
				IXUILabel ixuilabel = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Desc").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("Value").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				XGuildRedPackageSendBrief xguildRedPackageSendBrief = this._Doc.GuildBonusSendList[index];
				ixuilabel.SetText(xguildRedPackageSendBrief.senderName);
				ItemEnum itemid = (ItemEnum)xguildRedPackageSendBrief.itemid;
				string sprite = string.Empty;
				bool flag2 = itemid == ItemEnum.GOLD;
				if (flag2)
				{
					sprite = "l_red_jinbi_01";
				}
				else
				{
					bool flag3 = itemid == ItemEnum.DRAGON_COIN;
					if (flag3)
					{
						sprite = "l_red_longbi_01";
					}
					else
					{
						sprite = "l_red_longbi_01";
					}
				}
				ixuisprite.SetSprite(sprite);
				ixuisprite.MakePixelPerfect();
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendClick));
				ixuibutton.ID = xguildRedPackageSendBrief.uid;
				ixuibutton.SetVisible(xguildRedPackageSendBrief.senderType == BonusSender.Bonus_Self);
				bool flag4 = xguildRedPackageSendBrief.bonusInfo != null;
				if (flag4)
				{
					ixuilabel2.SetText(xguildRedPackageSendBrief.bonusInfo.GuildBonusName);
					ixuilabelSymbol.InputText = XLabelSymbolHelper.FormatCostWithIcon((int)xguildRedPackageSendBrief.bonusInfo.GuildBonusReward[1], (ItemEnum)xguildRedPackageSendBrief.bonusInfo.GuildBonusReward[0]);
				}
				else
				{
					ixuilabel2.SetText(string.Empty);
					ixuilabelSymbol.InputText = string.Empty;
				}
			}
		}

		// Token: 0x04006B43 RID: 27459
		private XGuildRedPacketDocument _Doc;
	}
}
