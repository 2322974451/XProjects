using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A4D RID: 2637
	internal class XDragonGuildCreateView : DlgHandlerBase
	{
		// Token: 0x06009FF1 RID: 40945 RVA: 0x001A967C File Offset: 0x001A787C
		protected override void Init()
		{
			base.Init();
			this.m_CreatePanel = base.PanelObject.transform.FindChild("CreateMenu").gameObject;
			this.m_VipPanel = base.PanelObject.transform.FindChild("VipMenu").gameObject;
			this.m_NameInput = (base.PanelObject.transform.FindChild("CreateMenu/NameInput").GetComponent("XUIInput") as IXUIInput);
			this.m_Cost = (base.PanelObject.transform.FindChild("CreateMenu/OK/MoneyCost").GetComponent("XUILabel") as IXUILabel);
			this.m_CostNum = XSingleton<XGlobalConfig>.singleton.GetInt("DragonGuildCreateCost");
			this.m_Cost.SetText(this.m_CostNum.ToString());
			IXUILabelSymbol ixuilabelSymbol = base.PanelObject.transform.FindChild("VipMenu/Note").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			ixuilabelSymbol.InputText = XStringDefineProxy.GetString("GUILD_CREATE_VIP_REQUIRE", new object[]
			{
				XSingleton<XGlobalConfig>.singleton.GetInt("GuildCreateVipRequirement")
			});
			this.m_guildDoc = XDragonGuildDocument.Doc;
			this.m_listDoc = XDragonGuildListDocument.Doc;
			this.m_CreateHighlight = base.PanelObject.transform.FindChild("CreateMenu/OK/Highlight").gameObject;
			Transform transform = base.PanelObject.transform.FindChild("CreateMenu/HelpList");
			int i = 0;
			int childCount = transform.childCount;
			while (i < childCount)
			{
				Transform child = transform.GetChild(i);
				this.m_helpList.Add(child.GetComponent("XUIButton") as IXUIButton, child.name);
				DragonGuildIntroduce.RowData introduce = this.m_guildDoc.GetIntroduce(child.name);
				bool flag = introduce != null;
				if (flag)
				{
					IXUILabel ixuilabel = child.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(introduce.Title);
				}
				i++;
			}
		}

		// Token: 0x06009FF2 RID: 40946 RVA: 0x001A988C File Offset: 0x001A7A8C
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
			foreach (IXUIButton ixuibutton5 in this.m_helpList.Keys)
			{
				ixuibutton5.RegisterClickEventHandler(new ButtonClickEventHandler(this._ShowCreateHelpClick));
			}
		}

		// Token: 0x06009FF3 RID: 40947 RVA: 0x001A99E0 File Offset: 0x001A7BE0
		protected override void OnShow()
		{
			base.OnShow();
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			int vipLevel = (int)specificDocument.VipLevel;
			bool flag = vipLevel >= XSingleton<XGlobalConfig>.singleton.GetInt("GuildCreateVipRequirement");
			this.m_CreatePanel.SetActive(flag);
			this.m_VipPanel.SetActive(!flag);
			this.m_NameInput.SetText("");
			bool flag2 = flag;
			if (flag2)
			{
				this.m_CreateHighlight.SetActive(XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN) >= (ulong)((long)this.m_CostNum));
			}
		}

		// Token: 0x06009FF4 RID: 40948 RVA: 0x001A9A80 File Offset: 0x001A7C80
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

		// Token: 0x06009FF5 RID: 40949 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009FF6 RID: 40950 RVA: 0x001A9AB8 File Offset: 0x001A7CB8
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

		// Token: 0x06009FF7 RID: 40951 RVA: 0x001A9B24 File Offset: 0x001A7D24
		private bool _OnCreateBtnClicked(IXUIButton btn)
		{
			string text = this.m_NameInput.GetText();
			bool flag = text.Length == 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DRAGON_GUILD_CREATE_NAME_REQUIRE"), "fece00");
			}
			else
			{
				this.m_listDoc.ReqCreateDragonGuild(text);
			}
			return true;
		}

		// Token: 0x06009FF8 RID: 40952 RVA: 0x001A9B7C File Offset: 0x001A7D7C
		private bool _OnVipBtnClicked(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Money, 0UL);
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06009FF9 RID: 40953 RVA: 0x001A9BA8 File Offset: 0x001A7DA8
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04003935 RID: 14645
		private IXUIInput m_NameInput;

		// Token: 0x04003936 RID: 14646
		private IXUILabel m_Cost;

		// Token: 0x04003937 RID: 14647
		private GameObject m_CreatePanel;

		// Token: 0x04003938 RID: 14648
		private GameObject m_VipPanel;

		// Token: 0x04003939 RID: 14649
		private int m_CostNum;

		// Token: 0x0400393A RID: 14650
		private GameObject m_CreateHighlight;

		// Token: 0x0400393B RID: 14651
		private Dictionary<IXUIButton, string> m_helpList = new Dictionary<IXUIButton, string>();

		// Token: 0x0400393C RID: 14652
		private XDragonGuildListDocument m_listDoc;

		// Token: 0x0400393D RID: 14653
		private XDragonGuildDocument m_guildDoc;
	}
}
