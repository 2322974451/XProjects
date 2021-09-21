using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200177D RID: 6013
	internal class HallFameDlg : DlgBase<HallFameDlg, HallFameBehavior>
	{
		// Token: 0x17003828 RID: 14376
		// (get) Token: 0x0600F81A RID: 63514 RVA: 0x0038A2C8 File Offset: 0x003884C8
		public override string fileName
		{
			get
			{
				return "GameSystem/HallFameDlg";
			}
		}

		// Token: 0x17003829 RID: 14377
		// (get) Token: 0x0600F81B RID: 63515 RVA: 0x0038A2E0 File Offset: 0x003884E0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700382A RID: 14378
		// (get) Token: 0x0600F81C RID: 63516 RVA: 0x0038A2F4 File Offset: 0x003884F4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700382B RID: 14379
		// (get) Token: 0x0600F81D RID: 63517 RVA: 0x0038A308 File Offset: 0x00388508
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700382C RID: 14380
		// (get) Token: 0x0600F81E RID: 63518 RVA: 0x0038A31C File Offset: 0x0038851C
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700382D RID: 14381
		// (get) Token: 0x0600F81F RID: 63519 RVA: 0x0038A330 File Offset: 0x00388530
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700382E RID: 14382
		// (get) Token: 0x0600F820 RID: 63520 RVA: 0x0038A344 File Offset: 0x00388544
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_HallFame);
			}
		}

		// Token: 0x0600F821 RID: 63521 RVA: 0x0038A35D File Offset: 0x0038855D
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600F822 RID: 63522 RVA: 0x0038A36E File Offset: 0x0038856E
		protected override void OnShow()
		{
			base.OnShow();
			this.UpdateTabs();
		}

		// Token: 0x0600F823 RID: 63523 RVA: 0x0038A37F File Offset: 0x0038857F
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshRightView(this._curSelectedType);
		}

		// Token: 0x0600F824 RID: 63524 RVA: 0x0038A398 File Offset: 0x00388598
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

		// Token: 0x0600F825 RID: 63525 RVA: 0x0038A3F4 File Offset: 0x003885F4
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

		// Token: 0x1700382F RID: 14383
		// (get) Token: 0x0600F826 RID: 63526 RVA: 0x0038A460 File Offset: 0x00388660
		public ArenaStarType CurSelectedType
		{
			get
			{
				return this._curSelectedType;
			}
		}

		// Token: 0x0600F827 RID: 63527 RVA: 0x0038A478 File Offset: 0x00388678
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

		// Token: 0x0600F828 RID: 63528 RVA: 0x0038A640 File Offset: 0x00388840
		private void SelectDefaultRole()
		{
			base.uiBehaviour.RoleDetail.gameObject.SetActive(true);
			Transform child = base.uiBehaviour.RoleList.GetChild(0);
			IXUISprite uiSprite = child.GetComponent("XUISprite") as IXUISprite;
			this.OnRoleSelected(uiSprite);
		}

		// Token: 0x0600F829 RID: 63529 RVA: 0x0038A690 File Offset: 0x00388890
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

		// Token: 0x0600F82A RID: 63530 RVA: 0x0038A8EC File Offset: 0x00388AEC
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

		// Token: 0x0600F82B RID: 63531 RVA: 0x0038A9B0 File Offset: 0x00388BB0
		private bool OnClickSupportBtn(IXUIButton button)
		{
			XHallFameDocument.Doc.SendArenaStarRoleReq(ArenaStarReqType.ASRT_DIANZAN, this._curSelectedType, 0UL);
			return true;
		}

		// Token: 0x0600F82C RID: 63532 RVA: 0x0038A9D8 File Offset: 0x00388BD8
		private bool OnClickShareBtn(IXUIButton button)
		{
			DlgBase<HallFameShareDlg, HallFameShareBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600F82D RID: 63533 RVA: 0x0038A9F8 File Offset: 0x00388BF8
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

		// Token: 0x0600F82E RID: 63534 RVA: 0x0038AED4 File Offset: 0x003890D4
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

		// Token: 0x0600F82F RID: 63535 RVA: 0x0038AF68 File Offset: 0x00389168
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

		// Token: 0x0600F830 RID: 63536 RVA: 0x0038B010 File Offset: 0x00389210
		private bool OnClickCloseBtn(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F831 RID: 63537 RVA: 0x0038B02C File Offset: 0x0038922C
		private void UpdateTabs()
		{
			this.SetTabsState();
		}

		// Token: 0x0600F832 RID: 63538 RVA: 0x0038B038 File Offset: 0x00389238
		private void RefreshSupportBtn()
		{
			base.uiBehaviour.SupportBtn.SetEnable(XHallFameDocument.Doc.CanSupportType.Contains(this._curSelectedType), false);
			Transform transform = base.uiBehaviour.SupportBtn.gameObject.transform.Find("RedPoint");
			transform.gameObject.SetActive(XHallFameDocument.Doc.CanSupportType.Contains(this._curSelectedType));
		}

		// Token: 0x0600F833 RID: 63539 RVA: 0x0038B0B0 File Offset: 0x003892B0
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

		// Token: 0x0600F834 RID: 63540 RVA: 0x0038B180 File Offset: 0x00389380
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

		// Token: 0x0600F835 RID: 63541 RVA: 0x0038B494 File Offset: 0x00389694
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

		// Token: 0x0600F836 RID: 63542 RVA: 0x0038B51C File Offset: 0x0038971C
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

		// Token: 0x0600F837 RID: 63543 RVA: 0x0038B558 File Offset: 0x00389758
		private void UpdateSeasonDate()
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(XHallFameDocument.Doc.SeasonBeginTime).ToLocalTime();
			DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(XHallFameDocument.Doc.SeasonEndTime).ToLocalTime();
			base.uiBehaviour.DateSeasonLabel.SetText(((XHallFameDocument.Doc.SeasonBeginTime == 0UL) ? "--.--" : dateTime.ToString("MM.dd")) + "_" + ((XHallFameDocument.Doc.SeasonEndTime == 0UL) ? "--.--" : dateTime2.ToString("MM.dd")));
		}

		// Token: 0x0600F838 RID: 63544 RVA: 0x0038B61C File Offset: 0x0038981C
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_HallFame);
			return true;
		}

		// Token: 0x04006C4C RID: 27724
		private List<IXUICheckBox> _tabs = new List<IXUICheckBox>();

		// Token: 0x04006C4D RID: 27725
		private ArenaStarType _curSelectedType;

		// Token: 0x04006C4E RID: 27726
		private const int avatarMax = 4;

		// Token: 0x04006C4F RID: 27727
		private const int maxShowDetail = 4;

		// Token: 0x04006C50 RID: 27728
		private const int maxShowTopOneIcon = 5;

		// Token: 0x04006C51 RID: 27729
		private XDummy[] _avatars = new XDummy[4];

		// Token: 0x04006C52 RID: 27730
		private XFx _selectedRoleEffect;

		// Token: 0x04006C53 RID: 27731
		private ulong _curRoleID;

		// Token: 0x04006C54 RID: 27732
		private IUIDummy _mainPlayerDummy;
	}
}
