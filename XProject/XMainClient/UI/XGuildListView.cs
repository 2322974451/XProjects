using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018B1 RID: 6321
	internal class XGuildListView : DlgBase<XGuildListView, XGuildListBehaviour>
	{
		// Token: 0x17003A2D RID: 14893
		// (get) Token: 0x06010795 RID: 67477 RVA: 0x00408654 File Offset: 0x00406854
		public XGuildCreateView CreateView
		{
			get
			{
				return this._CreateView;
			}
		}

		// Token: 0x17003A2E RID: 14894
		// (get) Token: 0x06010796 RID: 67478 RVA: 0x0040866C File Offset: 0x0040686C
		public override string fileName
		{
			get
			{
				return "Guild/GuildListDlg";
			}
		}

		// Token: 0x17003A2F RID: 14895
		// (get) Token: 0x06010797 RID: 67479 RVA: 0x00408684 File Offset: 0x00406884
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A30 RID: 14896
		// (get) Token: 0x06010798 RID: 67480 RVA: 0x00408698 File Offset: 0x00406898
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A31 RID: 14897
		// (get) Token: 0x06010799 RID: 67481 RVA: 0x004086AC File Offset: 0x004068AC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A32 RID: 14898
		// (get) Token: 0x0601079A RID: 67482 RVA: 0x004086C0 File Offset: 0x004068C0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A33 RID: 14899
		// (get) Token: 0x0601079B RID: 67483 RVA: 0x004086D4 File Offset: 0x004068D4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A34 RID: 14900
		// (get) Token: 0x0601079C RID: 67484 RVA: 0x004086E8 File Offset: 0x004068E8
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601079D RID: 67485 RVA: 0x004086FC File Offset: 0x004068FC
		protected override void Init()
		{
			this._ListDoc = XDocuments.GetSpecificDocument<XGuildListDocument>(XGuildListDocument.uuID);
			this._ListDoc.GuildListView = this;
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapContentItemInit));
			foreach (IXUIButton ixuibutton in base.uiBehaviour.m_helpList.Keys)
			{
				Guildintroduce.RowData introduce = this._GuildDoc.GetIntroduce(ixuibutton.gameObject.name);
				bool flag = introduce != null;
				if (flag)
				{
					IXUILabel ixuilabel = ixuibutton.gameObject.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(introduce.Title);
				}
			}
			DlgHandlerBase.EnsureCreate<XGuildCreateView>(ref this._CreateView, base.uiBehaviour.m_CreatePanel, null, true);
		}

		// Token: 0x0601079E RID: 67486 RVA: 0x0040882C File Offset: 0x00406A2C
		protected override void OnUnload()
		{
			this._ListDoc.GuildListView = null;
			DlgHandlerBase.EnsureUnload<XGuildCreateView>(ref this._CreateView);
			DlgHandlerBase.EnsureUnload<XTitleBar>(ref base.uiBehaviour.m_TitleBar);
			base.OnUnload();
		}

		// Token: 0x0601079F RID: 67487 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Reset()
		{
		}

		// Token: 0x060107A0 RID: 67488 RVA: 0x00408860 File Offset: 0x00406A60
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_Create.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCreateBtnClick));
			base.uiBehaviour.m_Search.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnSearchBtnClick));
			base.uiBehaviour.m_QuickJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnQuickJoinBtnClick));
			base.uiBehaviour.m_TitleBar.RegisterClickEventHandler(new TitleClickEventHandler(this._OnTitleClickEventHandler));
			foreach (IXUIButton ixuibutton in base.uiBehaviour.m_helpList.Keys)
			{
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._ShowHelpClick));
			}
		}

		// Token: 0x060107A1 RID: 67489 RVA: 0x00408960 File Offset: 0x00406B60
		protected override void OnShow()
		{
			base.uiBehaviour.m_SearchText.SetText("");
			this._ListDoc.SearchText = "";
			this._ListDoc.ReqGuildList();
			this._CreateView.SetVisible(false);
			this.RefreshPage(true);
			base.uiBehaviour.m_TitleBar.Refresh((ulong)((long)XFastEnumIntEqualityComparer<GuildSortType>.ToInt(this._ListDoc.SortType)));
		}

		// Token: 0x060107A2 RID: 67490 RVA: 0x004089D8 File Offset: 0x00406BD8
		private bool _OnTitleClickEventHandler(ulong ID)
		{
			this._ListDoc.SortType = (GuildSortType)ID;
			this._ListDoc.ReqGuildList();
			return this._ListDoc.SortDirection > 0;
		}

		// Token: 0x060107A3 RID: 67491 RVA: 0x00408A14 File Offset: 0x00406C14
		public void RefreshPage(bool bResetPosition = true)
		{
			List<XGuildListData> listData = this._ListDoc.ListData;
			this.GetPPT = true;
			base.uiBehaviour.m_WrapContent.SetContentCount(listData.Count, false);
		}

		// Token: 0x060107A4 RID: 67492 RVA: 0x00408A50 File Offset: 0x00406C50
		public void NewContentAppended()
		{
			List<XGuildListData> listData = this._ListDoc.ListData;
			base.uiBehaviour.m_WrapContent.SetContentCount(listData.Count, false);
		}

		// Token: 0x060107A5 RID: 67493 RVA: 0x00408A84 File Offset: 0x00406C84
		private bool _ShowHelpClick(IXUIButton button)
		{
			string helpName;
			bool flag = this.m_uiBehaviour.m_helpList.TryGetValue(button, out helpName);
			bool result;
			if (flag)
			{
				Guildintroduce.RowData introduce = this._GuildDoc.GetIntroduce(helpName);
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

		// Token: 0x060107A6 RID: 67494 RVA: 0x00408AEC File Offset: 0x00406CEC
		private void WrapContentItemInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("ValidContent/Apply").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnJoinBtnClick));
			ixuibutton = (t.FindChild("ValidContent/View").GetComponent("XUIButton") as IXUIButton);
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnViewBtnClick));
			IXUILabel ixuilabel = t.FindChild("LoadMore").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnLoadMoreClick));
		}

		// Token: 0x060107A7 RID: 67495 RVA: 0x00408B84 File Offset: 0x00406D84
		private void WrapContentItemUpdated(Transform t, int index)
		{
			List<XGuildListData> listData = this._ListDoc.ListData;
			bool flag = index >= listData.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Item index out of range: ", index.ToString(), null, null, null, null);
			}
			else
			{
				XGuildListData xguildListData = listData[index];
				Transform transform = t.FindChild("LoadMore");
				Transform transform2 = t.FindChild("ValidContent");
				IXUISprite ixuisprite = t.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
				bool flag2 = xguildListData.uid == 0UL;
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
					this._BasicInfoDisplayer.Set(xguildListData);
					IXUIButton ixuibutton = t.FindChild("ValidContent/Apply").GetComponent("XUIButton") as IXUIButton;
					IXUILabel ixuilabel = t.FindChild("ValidContent/Apply/T").GetComponent("XUILabel") as IXUILabel;
					IXUIButton ixuibutton2 = t.FindChild("ValidContent/View").GetComponent("XUIButton") as IXUIButton;
					IXUISprite ixuisprite2 = t.FindChild("ValidContent/Portrait").GetComponent("XUISprite") as IXUISprite;
					ixuibutton.SetEnable(!xguildListData.bIsApplying && !this._GuildDoc.bInGuild, false);
					ixuisprite2.SetSprite(XGuildDocument.GetPortraitName(xguildListData.portraitIndex));
					bool bIsApplying = xguildListData.bIsApplying;
					if (bIsApplying)
					{
						ixuilabel.SetText(XStringDefineProxy.GetString("APPLYING"));
					}
					else
					{
						bool flag3 = !xguildListData.bNeedApprove;
						if (flag3)
						{
							ixuilabel.SetText(XStringDefineProxy.GetString("JOIN"));
						}
						else
						{
							ixuilabel.SetText(XStringDefineProxy.GetString("APPLY"));
						}
						ixuibutton.SetGrey((ulong)xguildListData.requiredPPT < (ulong)((long)this.CurPPT));
					}
					ixuibutton.ID = (ulong)((long)index);
					ixuibutton2.ID = (ulong)((long)index);
				}
			}
		}

		// Token: 0x17003A35 RID: 14901
		// (get) Token: 0x060107A8 RID: 67496 RVA: 0x00408DBC File Offset: 0x00406FBC
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

		// Token: 0x060107A9 RID: 67497 RVA: 0x00408E10 File Offset: 0x00407010
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x060107AA RID: 67498 RVA: 0x00408E2C File Offset: 0x0040702C
		private bool _OnCreateBtnClick(IXUIButton go)
		{
			bool bInGuild = this._GuildDoc.bInGuild;
			bool result;
			if (bInGuild)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILD_ALREADY_IN_GUILD, "fece00");
				result = true;
			}
			else
			{
				this._CreateView.SetVisible(true);
				result = true;
			}
			return result;
		}

		// Token: 0x060107AB RID: 67499 RVA: 0x00408E74 File Offset: 0x00407074
		private bool _OnSearchBtnClick(IXUIButton go)
		{
			string text = base.uiBehaviour.m_SearchText.GetText();
			this._ListDoc.ReqSearch(text);
			return true;
		}

		// Token: 0x060107AC RID: 67500 RVA: 0x00408EA8 File Offset: 0x004070A8
		private bool _OnQuickJoinBtnClick(IXUIButton go)
		{
			bool bInGuild = this._GuildDoc.bInGuild;
			bool result;
			if (bInGuild)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILD_ALREADY_IN_GUILD, "fece00");
				result = true;
			}
			else
			{
				this._ListDoc.ReqQuickJoin();
				result = true;
			}
			return result;
		}

		// Token: 0x060107AD RID: 67501 RVA: 0x00408EF0 File Offset: 0x004070F0
		private bool _OnViewBtnClick(IXUIButton go)
		{
			XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
			int num = (int)go.ID;
			bool flag = num < 0 || num >= this._ListDoc.ListData.Count;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				specificDocument.View(this._ListDoc.ListData[num]);
				result = true;
			}
			return result;
		}

		// Token: 0x060107AE RID: 67502 RVA: 0x00408F54 File Offset: 0x00407154
		private bool _OnJoinBtnClick(IXUIButton go)
		{
			bool bInGuild = this._GuildDoc.bInGuild;
			bool result;
			if (bInGuild)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILD_ALREADY_IN_GUILD, "fece00");
				result = true;
			}
			else
			{
				int num = (int)go.ID;
				bool flag = num < 0 || num >= this._ListDoc.ListData.Count;
				if (flag)
				{
					result = false;
				}
				else
				{
					XGuildListData xguildListData = this._ListDoc.ListData[num];
					DlgBase<XGuildApplyView, XGuildApplyBehaviour>.singleton.ShowApply(xguildListData.uid, xguildListData.guildName, xguildListData.requiredPPT, xguildListData.bNeedApprove, xguildListData.announcement);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060107AF RID: 67503 RVA: 0x00408FF7 File Offset: 0x004071F7
		private void _OnLoadMoreClick(IXUILabel go)
		{
			this._ListDoc.ReqMoreGuilds();
		}

		// Token: 0x060107B0 RID: 67504 RVA: 0x00409006 File Offset: 0x00407206
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
		}

		// Token: 0x0400770F RID: 30479
		public static readonly Color TitleUnSelectedColor = new Color(0.60784316f, 0.60784316f, 0.60784316f);

		// Token: 0x04007710 RID: 30480
		public static readonly Color TitleSelectedColor = Color.white;

		// Token: 0x04007711 RID: 30481
		private XGuildListDocument _ListDoc;

		// Token: 0x04007712 RID: 30482
		private XGuildDocument _GuildDoc;

		// Token: 0x04007713 RID: 30483
		private XGuildCreateView _CreateView;

		// Token: 0x04007714 RID: 30484
		private XGuildBasicInfoDisplay _BasicInfoDisplayer = new XGuildBasicInfoDisplay();

		// Token: 0x04007715 RID: 30485
		private int m_curPPT = 0;

		// Token: 0x04007716 RID: 30486
		private bool GetPPT = false;
	}
}
