using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018AE RID: 6318
	internal class XGuildCreateView : DlgHandlerBase
	{
		// Token: 0x06010773 RID: 67443 RVA: 0x00407AF8 File Offset: 0x00405CF8
		protected override void Init()
		{
			this.m_CreatePanel = base.PanelObject.transform.FindChild("CreateMenu").gameObject;
			this.m_VipPanel = base.PanelObject.transform.FindChild("VipMenu").gameObject;
			this.m_NameInput = (base.PanelObject.transform.FindChild("CreateMenu/NameInput").GetComponent("XUIInput") as IXUIInput);
			this.m_Cost = (base.PanelObject.transform.FindChild("CreateMenu/OK/MoneyCost").GetComponent("XUILabel") as IXUILabel);
			this.m_CostNum = XSingleton<XGlobalConfig>.singleton.GetInt("GuildCreateCost");
			this.m_Cost.SetText(this.m_CostNum.ToString());
			IXUILabelSymbol ixuilabelSymbol = base.PanelObject.transform.FindChild("VipMenu/Note").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			ixuilabelSymbol.InputText = XStringDefineProxy.GetString("GUILD_CREATE_VIP_REQUIRE", new object[]
			{
				XSingleton<XGlobalConfig>.singleton.GetInt("GuildCreateVipRequirement")
			});
			this.m_Portrait = (base.PanelObject.transform.FindChild("CreateMenu/Portrait").GetComponent("XUISprite") as IXUISprite);
			this._doc = XDocuments.GetSpecificDocument<XGuildListDocument>(XGuildListDocument.uuID);
			this.m_GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this.m_PortraitIndex = XSingleton<XCommon>.singleton.RandomInt(XGuildPortraitView.PORTRAIT_COUNT);
			this.m_CreateHighlight = base.PanelObject.transform.FindChild("CreateMenu/OK/Highlight").gameObject;
			Transform transform = base.PanelObject.transform.FindChild("CreateMenu/HelpList");
			int i = 0;
			int childCount = transform.childCount;
			while (i < childCount)
			{
				Transform child = transform.GetChild(i);
				this.m_helpList.Add(child.GetComponent("XUIButton") as IXUIButton, child.name);
				Guildintroduce.RowData introduce = this.m_GuildDoc.GetIntroduce(child.name);
				bool flag = introduce != null;
				if (flag)
				{
					IXUILabel ixuilabel = child.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(introduce.Title);
				}
				i++;
			}
		}

		// Token: 0x06010774 RID: 67444 RVA: 0x00407D4C File Offset: 0x00405F4C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = base.PanelObject.transform.FindChild("VipMenu/Close").GetComponent("XUIButton") as IXUIButton;
			IXUIButton ixuibutton2 = base.PanelObject.transform.FindChild("CreateMenu/Close").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			IXUIButton ixuibutton3 = base.PanelObject.transform.FindChild("CreateMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton3.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCreateBtnClicked));
			IXUIButton ixuibutton4 = base.PanelObject.transform.FindChild("VipMenu/OK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton4.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnVipBtnClicked));
			IXUIButton ixuibutton5 = base.PanelObject.transform.FindChild("CreateMenu/EditPortrait").GetComponent("XUIButton") as IXUIButton;
			ixuibutton5.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEditPortraitClicked));
			foreach (IXUIButton ixuibutton6 in this.m_helpList.Keys)
			{
				ixuibutton6.RegisterClickEventHandler(new ButtonClickEventHandler(this._ShowCreateHelpClick));
			}
		}

		// Token: 0x06010775 RID: 67445 RVA: 0x00407EDC File Offset: 0x004060DC
		protected override void OnShow()
		{
			base.OnShow();
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			int vipLevel = (int)specificDocument.VipLevel;
			bool flag = vipLevel >= XSingleton<XGlobalConfig>.singleton.GetInt("GuildCreateVipRequirement");
			this.m_CreatePanel.SetActive(flag);
			this.m_VipPanel.SetActive(!flag);
			this.m_NameInput.SetText("");
			this.m_Portrait.SetSprite(XGuildDocument.GetPortraitName(this.m_PortraitIndex));
			bool flag2 = flag;
			if (flag2)
			{
				this.m_CreateHighlight.SetActive(XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN) >= (ulong)((long)this.m_CostNum));
			}
		}

		// Token: 0x06010776 RID: 67446 RVA: 0x00407F94 File Offset: 0x00406194
		public override void OnUnload()
		{
			bool flag = this.m_helpList != null;
			if (flag)
			{
				this.m_helpList.Clear();
				this.m_helpList = null;
			}
			base.OnUnload();
		}

		// Token: 0x06010777 RID: 67447 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06010778 RID: 67448 RVA: 0x00407FCC File Offset: 0x004061CC
		private bool _ShowCreateHelpClick(IXUIButton button)
		{
			string helpName;
			bool flag = this.m_helpList.TryGetValue(button, out helpName);
			bool result;
			if (flag)
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				Guildintroduce.RowData introduce = specificDocument.GetIntroduce(helpName);
				bool flag2 = introduce != null;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemHelp(introduce.Desc, introduce.Title, XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06010779 RID: 67449 RVA: 0x00408038 File Offset: 0x00406238
		private bool _OnCreateBtnClicked(IXUIButton btn)
		{
			string text = this.m_NameInput.GetText();
			bool flag = text.Length == 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_CREATE_NAME_REQUIRE"), "fece00");
			}
			else
			{
				this._doc.ReqCreateGuild(text, this.m_PortraitIndex);
			}
			return true;
		}

		// Token: 0x0601077A RID: 67450 RVA: 0x00408094 File Offset: 0x00406294
		private bool _OnVipBtnClicked(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Money, 0UL);
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0601077B RID: 67451 RVA: 0x004080C0 File Offset: 0x004062C0
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0601077C RID: 67452 RVA: 0x004080DC File Offset: 0x004062DC
		private bool _OnEditPortraitClicked(IXUIButton btn)
		{
			DlgBase<XGuildPortraitView, XGuildPortraitBehaviour>.singleton.Open(this.m_PortraitIndex, new ButtonClickEventHandler(this._OnPortraitChanged));
			return true;
		}

		// Token: 0x0601077D RID: 67453 RVA: 0x0040810C File Offset: 0x0040630C
		private bool _OnPortraitChanged(IXUIButton go)
		{
			this.m_PortraitIndex = DlgBase<XGuildPortraitView, XGuildPortraitBehaviour>.singleton.PortraitIndex;
			this.m_Portrait.SetSprite(XGuildDocument.GetPortraitName(this.m_PortraitIndex));
			return true;
		}

		// Token: 0x040076FB RID: 30459
		private IXUIInput m_NameInput;

		// Token: 0x040076FC RID: 30460
		private IXUILabel m_Cost;

		// Token: 0x040076FD RID: 30461
		private IXUISprite m_Portrait;

		// Token: 0x040076FE RID: 30462
		private GameObject m_CreatePanel;

		// Token: 0x040076FF RID: 30463
		private GameObject m_VipPanel;

		// Token: 0x04007700 RID: 30464
		private int m_PortraitIndex;

		// Token: 0x04007701 RID: 30465
		private int m_CostNum;

		// Token: 0x04007702 RID: 30466
		private GameObject m_CreateHighlight;

		// Token: 0x04007703 RID: 30467
		private Dictionary<IXUIButton, string> m_helpList = new Dictionary<IXUIButton, string>();

		// Token: 0x04007704 RID: 30468
		private XGuildListDocument _doc;

		// Token: 0x04007705 RID: 30469
		private XGuildDocument m_GuildDoc;
	}
}
