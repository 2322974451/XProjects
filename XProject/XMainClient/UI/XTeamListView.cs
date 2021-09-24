using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamListView : DlgBase<XTeamListView, XTeamListBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/TeamListDlg";
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

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.doc.AllListView = this;
			this.doc.InitTeamListSelection();
		}

		protected override void OnUnload()
		{
			this.doc.AllListView = null;
			DlgHandlerBase.EnsureUnload<XTitleBar>(ref base.uiBehaviour.m_TitleBar);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_TitleBar.RegisterClickEventHandler(new TitleClickEventHandler(this._OnTitleClickEventHandler));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.m_BtnJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnJoinBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._bFirstOpen = true;
			this.m_SelectedTeamID = -1;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
			base.uiBehaviour.m_TitleBar.Refresh((ulong)((long)XFastEnumIntEqualityComparer<TeamBriefSortType>.ToInt(this.doc.TeamListSortType)));
			base.uiBehaviour.m_TitleBar.SetArrowDir(this.doc.TeamListSortDirection > 0);
			this._InitCategories();
			this.doc.ClearTeamList();
			this.RefreshPage();
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._TimerID = 0U;
		}

		public override void StackRefresh()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimerID);
			this._AutoRefresh(null);
		}

		private void _InitCategories()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this.m_SelectedCategoriesGo.Clear();
			base.uiBehaviour.m_CategoryPool.FakeReturnAll();
			GameObject gameObject = base.uiBehaviour.m_CategoryPool.FetchGameObject(false);
			gameObject.transform.localPosition = base.uiBehaviour.m_CategoryPool.TplPos;
			gameObject.transform.parent = base.uiBehaviour.m_CategoryPool._tpl.transform.parent;
			XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
			this.m_SelectAll = this._SetCategory(gameObject, 0UL, XStringDefineProxy.GetString("ALL"));
			List<XTeamCategory> categories = specificDocument.TeamCategoryMgr.m_Categories;
			for (int i = 0; i < categories.Count; i++)
			{
				gameObject = base.uiBehaviour.m_CategoryPool.FetchGameObject(false);
				gameObject.transform.parent = base.uiBehaviour.m_CategoryScrollView.gameObject.transform;
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_CategoryPool.TplPos.x, base.uiBehaviour.m_CategoryPool.TplPos.y - (float)(base.uiBehaviour.m_CategoryPool.TplHeight * (i + 1)), base.uiBehaviour.m_CategoryPool.TplPos.z);
				this.m_SelectedCategoriesGo.Add(this._SetCategory(gameObject, (ulong)((long)categories[i].category), categories[i].Name));
			}
			base.uiBehaviour.m_CategoryPool.ActualReturnAll(false);
			this._RefreshCategoryStates();
			base.uiBehaviour.m_CategoryScrollView.ResetPosition();
		}

		private IXUICheckBox _SetCategory(GameObject go, ulong id, string strName)
		{
			Transform transform = go.transform.FindChild("Normal");
			IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.ID = id;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnCategoryStateChanged));
			IXUILabel ixuilabel = go.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(strName);
			return ixuicheckBox;
		}

		private void _RefreshCategoryStates()
		{
			bool bChecked = true;
			for (int i = 0; i < this.m_SelectedCategoriesGo.Count; i++)
			{
				IXUICheckBox ixuicheckBox = this.m_SelectedCategoriesGo[i];
				int item = (int)ixuicheckBox.ID;
				bool flag = this.doc.TeamListSelectedCategories.Contains(item);
				if (flag)
				{
					ixuicheckBox.bChecked = true;
				}
				else
				{
					ixuicheckBox.bChecked = false;
					bChecked = false;
				}
			}
			this.m_SelectAll.bChecked = bChecked;
		}

		private bool _OnCategoryStateChanged(IXUICheckBox ckb)
		{
			bool flag = false;
			int num = (int)ckb.ID;
			bool flag2 = this.doc.TeamListSelectedCategories.Contains(num);
			if (flag2)
			{
				bool flag3 = !ckb.bChecked;
				if (flag3)
				{
					this.doc.TeamListSelectedCategories.Remove(num);
					bool flag4 = num == 0;
					if (flag4)
					{
						this._SelectAll(false);
					}
					else
					{
						this.m_SelectAll.bChecked = false;
						this.doc.TeamListSelectedCategories.Remove(0);
					}
					flag = true;
				}
			}
			else
			{
				bool bChecked = ckb.bChecked;
				if (bChecked)
				{
					this.doc.TeamListSelectedCategories.Add(num);
					bool flag5 = num == 0;
					if (flag5)
					{
						this._SelectAll(true);
					}
					flag = true;
				}
			}
			bool flag6 = flag;
			if (flag6)
			{
				this.doc.ReqTeamList(false);
			}
			return true;
		}

		private void _SelectAll(bool bSelect)
		{
			for (int i = 0; i < this.m_SelectedCategoriesGo.Count; i++)
			{
				int item = (int)this.m_SelectedCategoriesGo[i].ID;
				if (bSelect)
				{
					this.doc.TeamListSelectedCategories.Add(item);
				}
				else
				{
					this.doc.TeamListSelectedCategories.Remove(item);
				}
			}
			this._RefreshCategoryStates();
		}

		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.doc.ReqTeamList(false);
				this._TimerID = XSingleton<XTimerMgr>.singleton.SetTimer(3f, new XTimerMgr.ElapsedEventHandler(this._AutoRefresh), null);
			}
		}

		public void RefreshPage()
		{
			List<XTeamBriefData> teamList = this.doc.TeamList;
			base.uiBehaviour.m_WrapContent.SetContentCount(teamList.Count, false);
			bool bFirstOpen = this._bFirstOpen;
			if (bFirstOpen)
			{
				base.uiBehaviour.m_ScrollView.ResetPosition();
				this._bFirstOpen = false;
			}
			base.uiBehaviour.m_NoTeam.SetActive(teamList.Count == 0);
			XTeamBriefData xteamBriefData = null;
			bool flag = this.m_SelectedTeamID != 0;
			if (flag)
			{
				for (int i = 0; i < teamList.Count; i++)
				{
					bool flag2 = teamList[i].teamID == this.m_SelectedTeamID;
					if (flag2)
					{
						xteamBriefData = teamList[i];
						break;
					}
				}
				bool flag3 = xteamBriefData == null;
				if (flag3)
				{
					this.m_SelectedTeamID = 0;
				}
			}
			this._UpdateButtonState(xteamBriefData);
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			List<XTeamBriefData> teamList = this.doc.TeamList;
			bool flag = index >= teamList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Item index out of range: ", index.ToString(), null, null, null, null);
			}
			else
			{
				XTeamBriefData xteamBriefData = teamList[index];
				IXUILabel ixuilabel = t.FindChild("DungeonName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("TeamName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("DungeonLevel").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.FindChild("MemberCount").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = t.FindChild("CategoryName").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject = t.FindChild("Select").gameObject;
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				GameObject gameObject2 = t.Find("Lock").gameObject;
				IXUISprite ixuisprite2 = t.Find("Regression").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetVisible(xteamBriefData.regression);
				IXUISprite ixuisprite3 = t.Find("SisterTA").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.ID = 0UL;
				ixuisprite3.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnPressTarjaInfo));
				IXUILabel ixuilabel6 = ixuisprite3.transform.Find("Info").GetComponent("XUILabel") as IXUILabel;
				bool flag2 = ixuilabel6 != null;
				if (flag2)
				{
					ixuilabel6.SetVisible(false);
				}
				IXUISprite ixuisprite4 = t.Find("SisterTATeam").GetComponent("XUISprite") as IXUISprite;
				ixuilabel6 = (ixuisprite4.transform.Find("Info").GetComponent("XUILabel") as IXUILabel);
				bool flag3 = ixuilabel6 != null;
				if (flag3)
				{
					ixuilabel6.SetVisible(false);
				}
				ixuisprite4.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnPressTarjaInfo));
				ixuisprite4.ID = 1UL;
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnTeamClick));
				bool flag4 = xteamBriefData.rift != null;
				if (flag4)
				{
					ixuilabel.SetText(xteamBriefData.rift.GetSceneName(xteamBriefData.dungeonName));
				}
				else
				{
					ixuilabel.SetText(xteamBriefData.dungeonName);
				}
				ixuilabel2.SetText(xteamBriefData.teamName);
				ixuilabel3.SetText(XStringDefineProxy.GetString("LEVEL", new object[]
				{
					xteamBriefData.dungeonLevel
				}));
				ixuilabel4.SetText(string.Format("{0}/{1}", xteamBriefData.currentMemberCount, xteamBriefData.totalMemberCount));
				ixuilabel5.SetText((xteamBriefData.category != null) ? xteamBriefData.category.Name : string.Empty);
				gameObject.SetActive(xteamBriefData.teamID == this.m_SelectedTeamID);
				gameObject2.SetActive(xteamBriefData.hasPwd);
				xteamBriefData.goldGroup.SetUI(t.Find("RewardHunt").gameObject, true);
				ixuisprite4.SetVisible(xteamBriefData.isTarja);
				ixuisprite3.SetVisible(this.doc.ShowTarja(xteamBriefData.dungeonID));
			}
		}

		private bool _OnTitleClickEventHandler(ulong ID)
		{
			this.doc.TeamListSortType = (TeamBriefSortType)ID;
			this.doc.SortTeamListAndShow();
			return this.doc.TeamListSortDirection > 0;
		}

		private void _UpdateButtonState(XTeamBriefData briefData)
		{
			base.uiBehaviour.m_BtnJoin.SetEnable(this.m_SelectedTeamID != 0 && !this.doc.bInTeam, false);
			bool flag = briefData != null;
			if (flag)
			{
				base.uiBehaviour.m_PPTRequirement.SetText(briefData.GetStrTeamPPT(0.0));
			}
			else
			{
				base.uiBehaviour.m_PPTRequirement.SetText(XTeamBriefData.GetStrTeamPPT(0.0, 0.0));
			}
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnPressTarjaInfo(IXUISprite sprite, bool pressed)
		{
			IXUILabel ixuilabel = sprite.transform.Find("Info").GetComponent("XUILabel") as IXUILabel;
			bool flag = ixuilabel != null;
			if (flag)
			{
				bool flag2 = sprite.ID == 1UL;
				if (flag2)
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TEAM_TARJA_DESC_TEAM")));
				}
				else
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TEAM_TARJA_DESC")));
				}
				ixuilabel.SetVisible(pressed);
			}
			return false;
		}

		private void _OnTeamClick(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			List<XTeamBriefData> teamList = this.doc.TeamList;
			bool flag = num >= teamList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Item index out of range: ", num.ToString(), null, null, null, null);
			}
			else
			{
				XTeamBriefData xteamBriefData = teamList[num];
				this.m_SelectedTeamID = xteamBriefData.teamID;
				base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
				this._UpdateButtonState(xteamBriefData);
			}
		}

		private bool _OnJoinBtnClick(IXUIButton go)
		{
			this._RealShowJoinTeamView();
			return true;
		}

		private void _RealShowJoinTeamView()
		{
			bool bInTeam = this.doc.bInTeam;
			if (bInTeam)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAM_ALREADY_INTEAM, "fece00");
			}
			else
			{
				XTeamBriefData teamBriefByID = this.doc.GetTeamBriefByID(this.m_SelectedTeamID);
				bool flag = teamBriefByID == null;
				if (!flag)
				{
					XTeamView.TryJoinTeam(teamBriefByID.teamID, teamBriefByID.hasPwd);
				}
			}
		}

		private XTeamDocument doc;

		private bool _bFirstOpen = false;

		private uint _TimerID = 0U;

		private int m_SelectedTeamID = 0;

		private List<IXUICheckBox> m_SelectedCategoriesGo = new List<IXUICheckBox>();

		private IXUICheckBox m_SelectAll;
	}
}
