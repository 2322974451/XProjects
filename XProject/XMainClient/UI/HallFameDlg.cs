using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HallFameDlg : DlgBase<HallFameDlg, HallFameBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/HallFameDlg";
			}
		}

		public override int layer
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_HallFame);
			}
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.UpdateTabs();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshRightView(this._curSelectedType);
		}

		protected override void OnHide()
		{
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			base.Return3DAvatarPool();
			this.ClearAvatarStates();
			bool flag = this._selectedRoleEffect != null;
			if (flag)
			{
				this._selectedRoleEffect.SetActive(false);
			}
			this._mainPlayerDummy = null;
			this._curRoleID = 0UL;
			base.OnHide();
		}

		protected override void OnUnload()
		{
			this._tabs.Clear();
			base.uiBehaviour.TabPool.ReturnAll(false);
			base.Return3DAvatarPool();
			bool flag = this._selectedRoleEffect != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._selectedRoleEffect, true);
				this._selectedRoleEffect = null;
			}
			this._curSelectedType = (ArenaStarType)0;
			base.OnUnload();
		}

		public ArenaStarType CurSelectedType
		{
			get
			{
				return this._curSelectedType;
			}
		}

		public void RefreshRightView(ArenaStarType id)
		{
			bool flag = id == this._curSelectedType;
			if (flag)
			{
				base.Return3DAvatarPool();
				this.ClearAvatarStates();
				this._mainPlayerDummy = null;
				XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
				base.Alloc3DAvatarPool("HallFameDlg");
				List<HallFameRoleInfo> rankInfoListBySysID = XHallFameDocument.Doc.GetRankInfoListBySysID(id);
				int num = Mathf.Min(rankInfoListBySysID.Count, base.uiBehaviour.RoleList.childCount);
				int i = 0;
				while (i < num)
				{
					HallFameRoleInfo roleInfo = rankInfoListBySysID[i];
					Transform child = base.uiBehaviour.RoleList.GetChild(i++);
					this.SetRankRoleInfoShow(child, roleInfo, i - 1);
				}
				while (i < base.uiBehaviour.RoleList.childCount)
				{
					Transform child2 = base.uiBehaviour.RoleList.GetChild(i++);
					child2.gameObject.SetActive(false);
				}
				bool flag2 = num > 0;
				if (flag2)
				{
					this.SelectDefaultRole();
				}
				else
				{
					base.uiBehaviour.RoleDetail.gameObject.SetActive(false);
				}
				bool active = false;
				for (int j = 0; j < rankInfoListBySysID.Count; j++)
				{
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null && rankInfoListBySysID[j].OutLook.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag3)
					{
						active = true;
						break;
					}
				}
				base.uiBehaviour.RankBtn.gameObject.SetActive(this.CurSelectedType != ArenaStarType.AST_LEAGUE);
				base.uiBehaviour.ShareBtn.gameObject.SetActive(active);
				this.UpdateSeasonDate();
				this.RefreshRedPoint();
			}
		}

		private void SelectDefaultRole()
		{
			base.uiBehaviour.RoleDetail.gameObject.SetActive(true);
			Transform child = base.uiBehaviour.RoleList.GetChild(0);
			IXUISprite uiSprite = child.GetComponent("XUISprite") as IXUISprite;
			this.OnRoleSelected(uiSprite);
		}

		private void InitProperties()
		{
			this._curSelectedType = (ArenaStarType)0;
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCloseBtn));
			base.uiBehaviour.ShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickShareBtn));
			base.uiBehaviour.SupportBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSupportBtn));
			base.uiBehaviour.RankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRankBtn));
			base.uiBehaviour.HelpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.TabPool.ReturnAll(false);
			ArenaStarType[] array = (ArenaStarType[])Enum.GetValues(typeof(ArenaStarType));
			this._tabs.Clear();
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = base.uiBehaviour.TabPool.FetchGameObject(false);
				IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)((long)array[i]);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckTabItem));
				Transform transform = ixuicheckBox.gameObject.transform;
				transform.localPosition = new Vector3(base.uiBehaviour.TabPool.TplPos.x, base.uiBehaviour.TabPool.TplPos.y - (float)(base.uiBehaviour.TabPool.TplHeight * i), 0f);
				IXUILabel ixuilabel = transform.Find("Selected/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString(array[i].ToString() + "_Hall_Fame"));
				ixuilabel = (transform.Find("NormalTextLabel").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString(array[i].ToString() + "_Hall_Fame"));
				this._tabs.Add(ixuicheckBox);
			}
			this._selectedRoleEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_HallFameDlg_fx01", null, true);
			this._selectedRoleEffect.SetActive(false);
		}

		private bool OnClickRankBtn(IXUIButton button)
		{
			switch (this._curSelectedType)
			{
			case ArenaStarType.AST_PK:
			{
				XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
				DlgBase<XQualifyingLastSeasonRankDlg, XQualifyingLastSeasonRankBehavior>.singleton.SetVisibleWithAnimation(true, null);
				DlgBase<XQualifyingLastSeasonRankDlg, XQualifyingLastSeasonRankBehavior>.singleton.SetupRankWindow(specificDocument.LastSeasonRankList);
				break;
			}
			case ArenaStarType.AST_HEROBATTLE:
				DlgBase<HeroBattleRankDlg, HeroBattleRankBehavior>.singleton.SetVisibleWithAnimation(true, null);
				DlgBase<HeroBattleRankDlg, HeroBattleRankBehavior>.singleton.SetupRankFrame();
				break;
			case ArenaStarType.AST_WEEKNEST:
				DlgBase<WeekNestRankDlg, WeekNestRankBehavior>.singleton.SetVisibleWithAnimation(true, null);
				DlgBase<WeekNestRankDlg, WeekNestRankBehavior>.singleton.Refresh();
				break;
			case ArenaStarType.AST_LEAGUE:
			{
				DlgBase<XTeamLeagueRankView, XTeamLeagueRankBehavior>.singleton.SetVisibleWithAnimation(true, null);
				XRankDocument specificDocument2 = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
				DlgBase<XTeamLeagueRankView, XTeamLeagueRankBehavior>.singleton.RefreshUI(specificDocument2.LastWeekLeagueTeamRankList);
				break;
			}
			}
			return true;
		}

		private bool OnClickSupportBtn(IXUIButton button)
		{
			XHallFameDocument.Doc.SendArenaStarRoleReq(ArenaStarReqType.ASRT_DIANZAN, this._curSelectedType, 0UL);
			return true;
		}

		private bool OnClickShareBtn(IXUIButton button)
		{
			DlgBase<HallFameShareDlg, HallFameShareBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private void RefreshRoleRaceDetail(ulong roleID)
		{
			HallFameRoleInfo roleInfoByRoleID = XHallFameDocument.Doc.GetRoleInfoByRoleID(roleID);
			bool flag = roleInfoByRoleID == null;
			if (!flag)
			{
				ArenaStarHistData hisData = roleInfoByRoleID.hisData;
				this._curRoleID = roleID;
				IXUISprite ixuisprite = base.uiBehaviour.RoleDetail.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)roleInfoByRoleID.OutLook.profession));
				IXUILabel ixuilabel = base.uiBehaviour.RoleDetail.Find("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(roleInfoByRoleID.OutLook.name);
				bool flag2 = hisData != null;
				if (flag2)
				{
					IXUILabel ixuilabel2 = base.uiBehaviour.RoleDetail.Find("History/ChampionNum").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(hisData.rankOneNum.ToString());
					IXUILabel ixuilabel3 = base.uiBehaviour.RoleDetail.Find("History/TopTenNum").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(hisData.rankTenNum.ToString());
					IXUILabel ixuilabel4 = base.uiBehaviour.RoleDetail.Find("HistoryRecord/HistoryRecordValue").GetComponent("XUILabel") as IXUILabel;
					string text = "";
					for (int i = 0; i < hisData.rankRecent.Count - 1; i++)
					{
						uint num = hisData.rankRecent[i].rank;
						num = ((num == uint.MaxValue) ? 0U : num);
						text += ((num == 0U) ? XSingleton<XStringTable>.singleton.GetString("NoRank") : string.Format(XSingleton<XStringTable>.singleton.GetString("RANK"), num));
						text += "\n";
					}
					bool flag3 = hisData.rankRecent.Count > 0;
					if (flag3)
					{
						uint num2 = hisData.rankRecent[hisData.rankRecent.Count - 1].rank;
						num2 = ((num2 == uint.MaxValue) ? 0U : num2);
						text += ((num2 == 0U) ? XSingleton<XStringTable>.singleton.GetString("NoRank") : string.Format(XSingleton<XStringTable>.singleton.GetString("RANK"), num2));
					}
					ixuilabel4.SetText(text);
					base.uiBehaviour.RecentEmpty.gameObject.SetActive(string.IsNullOrEmpty(text));
				}
				bool flag4 = XHallFameDocument.Doc.Season_time <= 1U;
				if (flag4)
				{
					base.uiBehaviour.RoleDetail.Find("NOW").gameObject.SetActive(false);
					base.uiBehaviour.CurrentEmpty.gameObject.SetActive(true);
				}
				else
				{
					base.uiBehaviour.RoleDetail.Find("NOW").gameObject.SetActive(true);
					base.uiBehaviour.CurrentEmpty.gameObject.SetActive(false);
					List<int> lastData = roleInfoByRoleID.LastData;
					bool flag5 = lastData != null;
					if (flag5)
					{
						for (int j = 0; j < 4; j++)
						{
							IXUILabel ixuilabel5 = base.uiBehaviour.RoleDetail.Find("NOW/ShowValue_" + (j + 1)).GetComponent("XUILabel") as IXUILabel;
							string text2 = (j < lastData.Count) ? lastData[j].ToString() : "";
							bool flag6 = j < lastData.Count && j == 0 && this.CurSelectedType == ArenaStarType.AST_WEEKNEST;
							if (flag6)
							{
								text2 += XSingleton<XStringTable>.singleton.GetString("SECOND_DUARATION");
							}
							bool flag7 = j < lastData.Count && j == 2 && this.CurSelectedType == ArenaStarType.AST_HEROBATTLE;
							if (flag7)
							{
								text2 += "%";
							}
							bool flag8 = j < lastData.Count && j == 2 && this.CurSelectedType == ArenaStarType.AST_LEAGUE;
							if (flag8)
							{
								text2 += "%";
							}
							ixuilabel5.SetText(text2);
							IXUILabel ixuilabel6 = ixuilabel5.gameObject.transform.Find("Content").GetComponent("XUILabel") as IXUILabel;
							text2 = ((j < lastData.Count) ? XSingleton<XStringTable>.singleton.GetString(string.Concat(new object[]
							{
								"Fame_Hall_",
								this._curSelectedType,
								"_",
								j + 1
							})) : "");
							ixuilabel6.SetText(text2);
						}
					}
				}
			}
		}

		public void RefreshRedPoint()
		{
			foreach (IXUICheckBox ixuicheckBox in this._tabs)
			{
				Transform transform = ixuicheckBox.gameObject.transform;
				Transform transform2 = transform.Find("RedPoint");
				transform2.gameObject.SetActive(XHallFameDocument.Doc.CanSupportType.Contains((ArenaStarType)ixuicheckBox.ID));
			}
			this.RefreshSupportBtn();
		}

		private bool OnCheckTabItem(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				XRankDocument specificDocument = XDocuments.GetSpecificDocument<XRankDocument>(XRankDocument.uuID);
				ArenaStarType arenaStarType = (ArenaStarType)iXUICheckBox.ID;
				this._curSelectedType = arenaStarType;
				switch (arenaStarType)
				{
				case ArenaStarType.AST_PK:
					specificDocument.ReqRankList(XRankType.LastWeek_PKRank);
					break;
				case ArenaStarType.AST_HEROBATTLE:
				{
					XHeroBattleDocument specificDocument2 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					specificDocument2.QueryLastSeasonRankInfo();
					break;
				}
				case ArenaStarType.AST_WEEKNEST:
					XWeekNestDocument.Doc.ReqLastSeasonRankList();
					break;
				case ArenaStarType.AST_LEAGUE:
					specificDocument.ReqRankList(XRankType.LastWeek_LeagueTeamRank);
					break;
				default:
					return false;
				}
				XHallFameDocument.Doc.SendArenaStarRoleReq(ArenaStarReqType.ASRT_ROLEDATA, arenaStarType, 0UL);
			}
			return true;
		}

		private bool OnClickCloseBtn(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		private void UpdateTabs()
		{
			this.SetTabsState();
		}

		private void RefreshSupportBtn()
		{
			base.uiBehaviour.SupportBtn.SetEnable(XHallFameDocument.Doc.CanSupportType.Contains(this._curSelectedType), false);
			Transform transform = base.uiBehaviour.SupportBtn.gameObject.transform.Find("RedPoint");
			transform.gameObject.SetActive(XHallFameDocument.Doc.CanSupportType.Contains(this._curSelectedType));
		}

		private void SetTabsState()
		{
			ArenaStarType[] array = (ArenaStarType[])Enum.GetValues(typeof(ArenaStarType));
			int num = Mathf.Min(array.Length, this._tabs.Count);
			int i;
			for (i = 0; i < num; i++)
			{
				this._tabs[i].ID = (ulong)((long)array[i]);
			}
			while (i < this._tabs.Count)
			{
				this._tabs[i++].SetEnable(false);
			}
			bool bChecked = this._tabs[0].bChecked;
			if (bChecked)
			{
				this.OnCheckTabItem(this._tabs[0]);
			}
			else
			{
				this._tabs[0].bChecked = true;
			}
		}

		private void SetRankRoleInfoShow(Transform role, HallFameRoleInfo roleInfo, int index)
		{
			string sprite = "mrt_mh" + (this._curSelectedType - ArenaStarType.AST_PK);
			Transform transform = role.Find("TitleFrame/KingRoot");
			int childCount = transform.childCount;
			IXUISprite ixuisprite = role.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRoleSelected));
			ixuisprite.ID = roleInfo.OutLook.roleid;
			role.gameObject.SetActive(true);
			IXUILabel ixuilabel = role.Find("TitleFrame/Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(roleInfo.OutLook.name);
			IXUILabel ixuilabel2 = role.Find("TitleFrame/Rank").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText("NO." + roleInfo.Rank);
			IXUISprite ixuisprite2 = role.Find("TitleFrame/ProfIcon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)roleInfo.OutLook.profession));
			IXUILabel ixuilabel3 = role.Find("TitleFrame/Guild").GetComponent("XUILabel") as IXUILabel;
			ixuilabel3.SetText(roleInfo.TeamName);
			Transform transform2 = role.Find("Snapshot");
			IUIDummy iuidummy = transform2.GetComponent("UIDummy") as IUIDummy;
			bool flag = roleInfo.OutLook.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, iuidummy);
				XSingleton<X3DAvatarMgr>.singleton.ResetMainAnimation();
				this._mainPlayerDummy = iuidummy;
			}
			else
			{
				XDummy xdummy = XSingleton<X3DAvatarMgr>.singleton.FindCreateCommonRoleDummy(this.m_dummPool, roleInfo.OutLook.roleid, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(roleInfo.OutLook.profession), roleInfo.OutLook.outlook, iuidummy, index);
				this._avatars[index] = xdummy;
			}
			ArenaStarHistData hisData = roleInfo.hisData;
			bool flag2 = hisData != null;
			if (flag2)
			{
				Transform child = transform.GetChild(0);
				int num = Mathf.Min((int)hisData.rankOneNum, 5);
				IXUISprite ixuisprite3 = child.GetComponent("XUISprite") as IXUISprite;
				int i = 0;
				float num2 = (hisData.rankOneNum > 0U) ? ((float)(num - 1) / 2f * (float)ixuisprite3.spriteWidth) : 0f;
				while (i < childCount)
				{
					Transform child2 = transform.GetChild(i);
					bool flag3 = (long)i < (long)((ulong)hisData.rankOneNum);
					if (flag3)
					{
						child2.localPosition = new Vector3(-num2 + (float)(i * ixuisprite3.spriteWidth), child2.localPosition.y, child2.localPosition.z);
						child2.gameObject.SetActive(true);
						IXUISprite ixuisprite4 = child2.GetChild(0).GetComponent("XUISprite") as IXUISprite;
						ixuisprite4.SetSprite(sprite);
					}
					else
					{
						child2.gameObject.SetActive(false);
					}
					i++;
				}
			}
		}

		private void OnRoleSelected(IXUISprite uiSprite)
		{
			this.RefreshRoleRaceDetail(uiSprite.ID);
			bool flag = this._selectedRoleEffect != null;
			if (flag)
			{
				this._selectedRoleEffect.SetUIWidget(uiSprite.gameObject.transform.FindChild("p").gameObject);
				this._selectedRoleEffect.SetActive(true);
				this._selectedRoleEffect.Play(uiSprite.gameObject.transform, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		private void ClearAvatarStates()
		{
			for (int i = 0; i < 4; i++)
			{
				bool flag = this._avatars[i] == null;
				if (!flag)
				{
					this._avatars[i] = null;
				}
			}
		}

		private void UpdateSeasonDate()
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(XHallFameDocument.Doc.SeasonBeginTime).ToLocalTime();
			DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(XHallFameDocument.Doc.SeasonEndTime).ToLocalTime();
			base.uiBehaviour.DateSeasonLabel.SetText(((XHallFameDocument.Doc.SeasonBeginTime == 0UL) ? "--.--" : dateTime.ToString("MM.dd")) + "_" + ((XHallFameDocument.Doc.SeasonEndTime == 0UL) ? "--.--" : dateTime2.ToString("MM.dd")));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_HallFame);
			return true;
		}

		private List<IXUICheckBox> _tabs = new List<IXUICheckBox>();

		private ArenaStarType _curSelectedType;

		private const int avatarMax = 4;

		private const int maxShowDetail = 4;

		private const int maxShowTopOneIcon = 5;

		private XDummy[] _avatars = new XDummy[4];

		private XFx _selectedRoleEffect;

		private ulong _curRoleID;

		private IUIDummy _mainPlayerDummy;
	}
}
