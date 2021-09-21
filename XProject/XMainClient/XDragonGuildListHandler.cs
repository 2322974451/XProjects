using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A4E RID: 2638
	internal class XDragonGuildListHandler : DlgHandlerBase
	{
		// Token: 0x17002EEB RID: 12011
		// (get) Token: 0x06009FFB RID: 40955 RVA: 0x001A9BD8 File Offset: 0x001A7DD8
		protected override string FileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopList";
			}
		}

		// Token: 0x06009FFC RID: 40956 RVA: 0x001A9BF0 File Offset: 0x001A7DF0
		protected override void Init()
		{
			base.Init();
			this.m_listDoc.View = this;
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_Create = (base.transform.FindChild("Bg/Create").GetComponent("XUIButton") as IXUIButton);
			this.m_QuickJoin = (base.transform.FindChild("Bg/QuickJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_Search = (base.transform.FindChild("Bg/Search").GetComponent("XUIButton") as IXUIButton);
			this.m_SearchText = (base.transform.FindChild("Bg/SearchText").GetComponent("XUIInput") as IXUIInput);
			this.m_CreatePanel = base.transform.FindChild("Bg/CreatePanel").gameObject;
			Transform transform = base.transform.FindChild("Bg/HelpList");
			int i = 0;
			int childCount = transform.childCount;
			while (i < childCount)
			{
				Transform child = transform.GetChild(i);
				this.m_helpList.Add(child.GetComponent("XUIButton") as IXUIButton, child.name);
				i++;
			}
			Transform transform2 = base.transform.FindChild("Bg/Titles");
			DlgHandlerBase.EnsureCreate<XTitleBar>(ref this.m_TitleBar, transform2.gameObject, null, true);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			this.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapContentItemInit));
			foreach (IXUIButton ixuibutton in this.m_helpList.Keys)
			{
				DragonGuildIntroduce.RowData introduce = this.m_guildDoc.GetIntroduce(ixuibutton.gameObject.name);
				bool flag = introduce != null;
				if (flag)
				{
					IXUILabel ixuilabel = ixuibutton.gameObject.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(introduce.Title);
				}
			}
			DlgHandlerBase.EnsureCreate<XDragonGuildCreateView>(ref this._CreateView, this.m_CreatePanel, null, true);
		}

		// Token: 0x06009FFD RID: 40957 RVA: 0x001A9E98 File Offset: 0x001A8098
		public override void OnUnload()
		{
			this.m_listDoc.View = null;
			DlgHandlerBase.EnsureUnload<XDragonGuildCreateView>(ref this._CreateView);
			DlgHandlerBase.EnsureUnload<XTitleBar>(ref this.m_TitleBar);
			base.OnUnload();
		}

		// Token: 0x06009FFE RID: 40958 RVA: 0x001A9EC8 File Offset: 0x001A80C8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnHelpBtnClick));
			this.m_Create.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCreateBtnClick));
			this.m_Search.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSearchBtnClick));
			this.m_QuickJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnQuickJoinBtnClick));
			this.m_TitleBar.RegisterClickEventHandler(new TitleClickEventHandler(this._OnTitleClickEventHandler));
			foreach (IXUIButton ixuibutton in this.m_helpList.Keys)
			{
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._ShowHelpClick));
			}
		}

		// Token: 0x06009FFF RID: 40959 RVA: 0x001A9FB0 File Offset: 0x001A81B0
		protected override void OnShow()
		{
			this.m_SearchText.SetText("");
			this.m_listDoc.SearchText = "";
			this.m_listDoc.ReqDragonGuildList();
			this._CreateView.SetVisible(false);
			this.RefreshPage(true);
			this.m_TitleBar.Refresh((ulong)((long)XFastEnumIntEqualityComparer<DragonGuildSortType>.ToInt(this.m_listDoc.SortType)));
		}

		// Token: 0x0600A000 RID: 40960 RVA: 0x001AA020 File Offset: 0x001A8220
		private bool _OnHelpBtnClick(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildCollectSummon);
			return true;
		}

		// Token: 0x0600A001 RID: 40961 RVA: 0x001AA044 File Offset: 0x001A8244
		private bool _OnCreateBtnClick(IXUIButton go)
		{
			bool flag = this.m_guildDoc.IsInDragonGuild();
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_DG_ALREADY_IN_DG, "fece00");
				result = true;
			}
			else
			{
				this._CreateView.SetVisible(true);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A002 RID: 40962 RVA: 0x001AA090 File Offset: 0x001A8290
		private bool _OnSearchBtnClick(IXUIButton go)
		{
			string text = this.m_SearchText.GetText();
			this.m_listDoc.ReqSearch(text);
			return true;
		}

		// Token: 0x0600A003 RID: 40963 RVA: 0x001AA0BC File Offset: 0x001A82BC
		private bool _OnQuickJoinBtnClick(IXUIButton go)
		{
			bool flag = this.m_guildDoc.IsInDragonGuild();
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_DG_ALREADY_IN_DG, "fece00");
				result = true;
			}
			else
			{
				this.m_listDoc.ReqQuickJoin();
				result = true;
			}
			return result;
		}

		// Token: 0x0600A004 RID: 40964 RVA: 0x001AA104 File Offset: 0x001A8304
		private bool _OnTitleClickEventHandler(ulong ID)
		{
			this.m_listDoc.SortType = (DragonGuildSortType)ID;
			this.m_listDoc.ReqDragonGuildList();
			return this.m_listDoc.SortDirection > 0;
		}

		// Token: 0x0600A005 RID: 40965 RVA: 0x001AA140 File Offset: 0x001A8340
		private bool _ShowHelpClick(IXUIButton button)
		{
			string helpName;
			bool flag = this.m_helpList.TryGetValue(button, out helpName);
			bool result;
			if (flag)
			{
				DragonGuildIntroduce.RowData introduce = this.m_guildDoc.GetIntroduce(helpName);
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

		// Token: 0x0600A006 RID: 40966 RVA: 0x001AA1A4 File Offset: 0x001A83A4
		public void NewContentAppended()
		{
			List<XDragonGuildListData> listData = this.m_listDoc.ListData;
			this.m_WrapContent.SetContentCount(listData.Count, false);
		}

		// Token: 0x0600A007 RID: 40967 RVA: 0x001AA1D4 File Offset: 0x001A83D4
		private void WrapContentItemUpdated(Transform t, int index)
		{
			List<XDragonGuildListData> listData = this.m_listDoc.ListData;
			bool flag = index >= listData.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Item index out of range: ", index.ToString(), null, null, null, null);
			}
			else
			{
				XDragonGuildListData xdragonGuildListData = listData[index];
				Transform transform = t.FindChild("LoadMore");
				Transform transform2 = t.FindChild("ValidContent");
				IXUISprite ixuisprite = t.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
				bool flag2 = xdragonGuildListData.uid == 0UL;
				if (flag2)
				{
					ixuisprite.SetVisible(false);
					transform.gameObject.SetActive(true);
					transform2.gameObject.SetActive(false);
				}
				else
				{
					ixuisprite.SetVisible(true);
					transform.gameObject.SetActive(false);
					transform2.gameObject.SetActive(true);
					this._BasicInfoDisplayer.Init(t.FindChild("ValidContent"), false);
					this._BasicInfoDisplayer.Set(xdragonGuildListData);
					IXUIButton ixuibutton = t.FindChild("ValidContent/Apply").GetComponent("XUIButton") as IXUIButton;
					IXUILabel ixuilabel = t.FindChild("ValidContent/Apply/T").GetComponent("XUILabel") as IXUILabel;
					IXUIButton ixuibutton2 = t.FindChild("ValidContent/View").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.SetEnable(!xdragonGuildListData.bIsApplying && !this.m_guildDoc.IsInDragonGuild(), false);
					bool bIsApplying = xdragonGuildListData.bIsApplying;
					if (bIsApplying)
					{
						ixuilabel.SetText(XStringDefineProxy.GetString("APPLYING"));
					}
					else
					{
						bool flag3 = !xdragonGuildListData.bNeedApprove;
						if (flag3)
						{
							ixuilabel.SetText(XStringDefineProxy.GetString("JOIN"));
						}
						else
						{
							ixuilabel.SetText(XStringDefineProxy.GetString("APPLY"));
						}
						ixuibutton.SetGrey((ulong)xdragonGuildListData.requiredPPT <= (ulong)((long)this.CurPPT));
					}
					ixuibutton.ID = (ulong)((long)index);
					ixuibutton2.ID = (ulong)((long)index);
				}
			}
		}

		// Token: 0x17002EEC RID: 12012
		// (get) Token: 0x0600A008 RID: 40968 RVA: 0x001AA3E0 File Offset: 0x001A85E0
		private int CurPPT
		{
			get
			{
				bool getPPT = this.GetPPT;
				if (getPPT)
				{
					XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
					XPlayerAttributes xplayerAttributes = player.Attributes as XPlayerAttributes;
					this.m_curPPT = (int)xplayerAttributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
					this.GetPPT = false;
				}
				return this.m_curPPT;
			}
		}

		// Token: 0x0600A009 RID: 40969 RVA: 0x001AA434 File Offset: 0x001A8634
		private void WrapContentItemInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("ValidContent/Apply").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnJoinBtnClick));
			IXUILabel ixuilabel = t.FindChild("LoadMore").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnLoadMoreClick));
		}

		// Token: 0x0600A00A RID: 40970 RVA: 0x001AA4A0 File Offset: 0x001A86A0
		private bool _OnJoinBtnClick(IXUIButton go)
		{
			bool flag = XDragonGuildDocument.Doc.IsInDragonGuild();
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_DG_ALREADY_IN_DG, "fece00");
				result = true;
			}
			else
			{
				int num = (int)go.ID;
				bool flag2 = num < 0 || num >= this.m_listDoc.ListData.Count;
				if (flag2)
				{
					result = false;
				}
				else
				{
					XDragonGuildListData xdragonGuildListData = this.m_listDoc.ListData[num];
					DlgBase<XDragonGuildApplyView, XDragonGuildApplyBehaviour>.singleton.ShowApply(xdragonGuildListData.uid, xdragonGuildListData.dragonGuildName, xdragonGuildListData.requiredPPT, xdragonGuildListData.bNeedApprove);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600A00B RID: 40971 RVA: 0x001AA53F File Offset: 0x001A873F
		private void _OnLoadMoreClick(IXUILabel go)
		{
			this.m_listDoc.ReqMoreGuilds();
		}

		// Token: 0x0600A00C RID: 40972 RVA: 0x001AA54E File Offset: 0x001A874E
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.m_WrapContent.RefreshAllVisibleContents();
		}

		// Token: 0x0600A00D RID: 40973 RVA: 0x001AA564 File Offset: 0x001A8764
		public void RefreshPage(bool bResetPosition = true)
		{
			List<XDragonGuildListData> listData = this.m_listDoc.ListData;
			this.GetPPT = true;
			this.m_WrapContent.SetContentCount(listData.Count, false);
		}

		// Token: 0x0400393E RID: 14654
		private XDragonGuildListDocument m_listDoc = XDragonGuildListDocument.Doc;

		// Token: 0x0400393F RID: 14655
		private XDragonGuildDocument m_guildDoc = XDragonGuildDocument.Doc;

		// Token: 0x04003940 RID: 14656
		private XDragonGuildCreateView _CreateView;

		// Token: 0x04003941 RID: 14657
		private XDragonGuildBasicInfoDisplay _BasicInfoDisplayer = new XDragonGuildBasicInfoDisplay();

		// Token: 0x04003942 RID: 14658
		private int m_curPPT = 0;

		// Token: 0x04003943 RID: 14659
		private bool GetPPT = false;

		// Token: 0x04003944 RID: 14660
		private IXUIButton m_Help;

		// Token: 0x04003945 RID: 14661
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04003946 RID: 14662
		private IXUIScrollView m_ScrollView;

		// Token: 0x04003947 RID: 14663
		private IXUIButton m_Create;

		// Token: 0x04003948 RID: 14664
		private IXUIButton m_QuickJoin;

		// Token: 0x04003949 RID: 14665
		private IXUIButton m_Search;

		// Token: 0x0400394A RID: 14666
		private IXUIInput m_SearchText;

		// Token: 0x0400394B RID: 14667
		private GameObject m_CreatePanel;

		// Token: 0x0400394C RID: 14668
		private XTitleBar m_TitleBar;

		// Token: 0x0400394D RID: 14669
		private Dictionary<IXUIButton, string> m_helpList = new Dictionary<IXUIButton, string>();
	}
}
