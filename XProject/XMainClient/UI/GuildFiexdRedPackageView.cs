using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildFiexdRedPackageView : DlgBase<GuildFiexdRedPackageView, GuildFiexdRedPackageBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildFiexdRedPacketDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SevenActivity);
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
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

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
			base.uiBehaviour.m_HelpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickHelp));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendGuildBonusSendList();
		}

		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		private bool OnSendClick(IXUIButton btn)
		{
			this._Doc.SendGuildBonusInSend((uint)btn.ID);
			return true;
		}

		private bool ClickHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildBoon_FixedRedPacket);
			return true;
		}

		public void Refresh()
		{
			int count = this._Doc.GuildBonusSendList.Count;
			base.uiBehaviour.m_WrapContent.SetContentCount(count, false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
			base.uiBehaviour.m_Empty.gameObject.SetActive(count == 0);
		}

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

		private XGuildRedPacketDocument _Doc;
	}
}
