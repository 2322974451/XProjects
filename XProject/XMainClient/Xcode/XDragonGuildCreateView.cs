using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildCreateView : DlgHandlerBase
	{

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

		protected override void OnHide()
		{
			base.OnHide();
		}

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

		private bool _OnVipBtnClicked(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Money, 0UL);
			base.SetVisible(false);
			return true;
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		private IXUIInput m_NameInput;

		private IXUILabel m_Cost;

		private GameObject m_CreatePanel;

		private GameObject m_VipPanel;

		private int m_CostNum;

		private GameObject m_CreateHighlight;

		private Dictionary<IXUIButton, string> m_helpList = new Dictionary<IXUIButton, string>();

		private XDragonGuildListDocument m_listDoc;

		private XDragonGuildDocument m_guildDoc;
	}
}
