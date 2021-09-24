using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildListView : DlgBase<XGuildListView, XGuildListBehaviour>
	{

		public XGuildCreateView CreateView
		{
			get
			{
				return this._CreateView;
			}
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildListDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

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

		protected override void OnUnload()
		{
			this._ListDoc.GuildListView = null;
			DlgHandlerBase.EnsureUnload<XGuildCreateView>(ref this._CreateView);
			DlgHandlerBase.EnsureUnload<XTitleBar>(ref base.uiBehaviour.m_TitleBar);
			base.OnUnload();
		}

		public override void Reset()
		{
		}

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

		protected override void OnShow()
		{
			base.uiBehaviour.m_SearchText.SetText("");
			this._ListDoc.SearchText = "";
			this._ListDoc.ReqGuildList();
			this._CreateView.SetVisible(false);
			this.RefreshPage(true);
			base.uiBehaviour.m_TitleBar.Refresh((ulong)((long)XFastEnumIntEqualityComparer<GuildSortType>.ToInt(this._ListDoc.SortType)));
		}

		private bool _OnTitleClickEventHandler(ulong ID)
		{
			this._ListDoc.SortType = (GuildSortType)ID;
			this._ListDoc.ReqGuildList();
			return this._ListDoc.SortDirection > 0;
		}

		public void RefreshPage(bool bResetPosition = true)
		{
			List<XGuildListData> listData = this._ListDoc.ListData;
			this.GetPPT = true;
			base.uiBehaviour.m_WrapContent.SetContentCount(listData.Count, false);
		}

		public void NewContentAppended()
		{
			List<XGuildListData> listData = this._ListDoc.ListData;
			base.uiBehaviour.m_WrapContent.SetContentCount(listData.Count, false);
		}

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

		private void WrapContentItemInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("ValidContent/Apply").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnJoinBtnClick));
			ixuibutton = (t.FindChild("ValidContent/View").GetComponent("XUIButton") as IXUIButton);
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnViewBtnClick));
			IXUILabel ixuilabel = t.FindChild("LoadMore").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnLoadMoreClick));
		}

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

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		private bool _OnSearchBtnClick(IXUIButton go)
		{
			string text = base.uiBehaviour.m_SearchText.GetText();
			this._ListDoc.ReqSearch(text);
			return true;
		}

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

		private void _OnLoadMoreClick(IXUILabel go)
		{
			this._ListDoc.ReqMoreGuilds();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
		}

		public static readonly Color TitleUnSelectedColor = new Color(0.60784316f, 0.60784316f, 0.60784316f);

		public static readonly Color TitleSelectedColor = Color.white;

		private XGuildListDocument _ListDoc;

		private XGuildDocument _GuildDoc;

		private XGuildCreateView _CreateView;

		private XGuildBasicInfoDisplay _BasicInfoDisplayer = new XGuildBasicInfoDisplay();

		private int m_curPPT = 0;

		private bool GetPPT = false;
	}
}
