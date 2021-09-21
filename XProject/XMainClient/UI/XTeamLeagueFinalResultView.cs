using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001742 RID: 5954
	internal class XTeamLeagueFinalResultView : DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>
	{
		// Token: 0x170037E6 RID: 14310
		// (get) Token: 0x0600F62D RID: 63021 RVA: 0x0037C828 File Offset: 0x0037AA28
		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueFinalDuel";
			}
		}

		// Token: 0x170037E7 RID: 14311
		// (get) Token: 0x0600F62E RID: 63022 RVA: 0x0037C840 File Offset: 0x0037AA40
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037E8 RID: 14312
		// (get) Token: 0x0600F62F RID: 63023 RVA: 0x0037C854 File Offset: 0x0037AA54
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037E9 RID: 14313
		// (get) Token: 0x0600F630 RID: 63024 RVA: 0x0037C868 File Offset: 0x0037AA68
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037EA RID: 14314
		// (get) Token: 0x0600F631 RID: 63025 RVA: 0x0037C87C File Offset: 0x0037AA7C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037EB RID: 14315
		// (get) Token: 0x0600F632 RID: 63026 RVA: 0x0037C890 File Offset: 0x0037AA90
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F633 RID: 63027 RVA: 0x0037C8A3 File Offset: 0x0037AAA3
		protected override void Init()
		{
			this.InitProperties();
		}

		// Token: 0x0600F634 RID: 63028 RVA: 0x0037C8AD File Offset: 0x0037AAAD
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F635 RID: 63029 RVA: 0x0037C8B7 File Offset: 0x0037AAB7
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F636 RID: 63030 RVA: 0x0037C8C1 File Offset: 0x0037AAC1
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600F637 RID: 63031 RVA: 0x0037C8CB File Offset: 0x0037AACB
		protected override void OnShow()
		{
			base.OnShow();
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueEleInfo();
		}

		// Token: 0x0600F638 RID: 63032 RVA: 0x0037C8E0 File Offset: 0x0037AAE0
		protected override void OnHide()
		{
			XFreeTeamVersusLeagueDocument.Doc.SendCloseLeagueEleNtf();
			base.OnHide();
		}

		// Token: 0x0600F639 RID: 63033 RVA: 0x0037C8F8 File Offset: 0x0037AAF8
		private void InitProperties()
		{
			base.uiBehaviour.EnterMatch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickEnterMatch));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCloseBtn));
			string text = (XFreeTeamVersusLeagueDocument.Doc.TodayState == LeagueBattleTimeState.LBTS_Elimination || XFreeTeamVersusLeagueDocument.Doc.TodayState == LeagueBattleTimeState.LBTS_CrossElimination) ? XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("LeagueFinalSchedule")) : "";
			base.uiBehaviour.FinalTimeLabel.SetText(text);
			this._itemDic.Clear();
			foreach (object obj in base.uiBehaviour.Details.transform)
			{
				Transform transform = (Transform)obj;
				string name = transform.name;
				int num = name.IndexOf('_');
				bool flag = num > 0;
				if (flag)
				{
					uint num2 = Convert.ToUInt32(name.Substring(num - 1, 1));
					RoundFlag key = (RoundFlag)num2;
					bool flag2 = !this._itemDic.ContainsKey(key);
					if (flag2)
					{
						this._itemDic.Add(key, new List<GameObject>());
					}
					this._itemDic[key].Add(transform.gameObject);
				}
			}
		}

		// Token: 0x0600F63A RID: 63034 RVA: 0x0037CA6C File Offset: 0x0037AC6C
		private void RefreshEnterMatchBtn()
		{
			bool flag = XFreeTeamVersusLeagueDocument.Doc.IsMyTeamInFinal();
			if (flag)
			{
				base.uiBehaviour.EnterMatch.gameObject.SetActive(true);
				base.uiBehaviour.EnterMatch.SetEnable(XFreeTeamVersusLeagueDocument.Doc.IsMyTeamInFighting(), false);
			}
			else
			{
				base.uiBehaviour.EnterMatch.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600F63B RID: 63035 RVA: 0x0037CAD8 File Offset: 0x0037ACD8
		private bool OnClickCloseBtn(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F63C RID: 63036 RVA: 0x0037CAF4 File Offset: 0x0037ACF4
		private bool OnClickEnterMatch(IXUIButton button)
		{
			bool flag = XFreeTeamVersusLeagueDocument.Doc.IsMyTeamInFighting();
			if (flag)
			{
				XFreeTeamVersusLeagueDocument.Doc.SendJoinLeagueEleBattle();
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("LeagueNotInFinal"), "fece00");
			}
			return true;
		}

		// Token: 0x0600F63D RID: 63037 RVA: 0x0037CB44 File Offset: 0x0037AD44
		private void UpdateDetailItem(Transform item, LBEleRoomInfo info)
		{
			bool flag = info == null;
			if (flag)
			{
				info = new LBEleRoomInfo();
			}
			Transform item2 = item.Find("Team1");
			Transform item3 = item.Find("Team2");
			Transform transform = item.Find("Btnplay");
			transform.gameObject.SetActive(true);
			IXUISprite ixuisprite = transform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)info.liveid;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickLive));
			ixuisprite.gameObject.SetActive(info.liveid > 0U);
			bool flag2 = info.team1 != null && info.team1.leagueid > 0UL;
			if (flag2)
			{
				this.UpdateTeamItem(item2, info.team1, info.winleagueid, info.state, info.liveid);
			}
			else
			{
				this.UpdateEmptyItem(item2);
			}
			bool flag3 = info.team2 != null && info.team2.leagueid > 0UL;
			if (flag3)
			{
				this.UpdateTeamItem(item3, info.team2, info.winleagueid, info.state, info.liveid);
			}
			else
			{
				this.UpdateEmptyItem(item3);
			}
		}

		// Token: 0x0600F63E RID: 63038 RVA: 0x0037CC70 File Offset: 0x0037AE70
		private void OnClickLive(IXUISprite uiSprite)
		{
			bool flag = uiSprite.ID > 0UL;
			if (flag)
			{
				XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
				specificDocument.EnterSpectateBattle((uint)uiSprite.ID, LiveType.LIVE_LEAGUEBATTLE);
			}
		}

		// Token: 0x0600F63F RID: 63039 RVA: 0x0037CCAC File Offset: 0x0037AEAC
		private void UpdateEmptyItem(Transform item)
		{
			Transform transform = item.Find("Win");
			Transform transform2 = item.Find("Lose");
			Transform transform3 = item.Find("Empty");
			transform.gameObject.SetActive(false);
			transform2.gameObject.SetActive(false);
			transform3.gameObject.SetActive(true);
		}

		// Token: 0x0600F640 RID: 63040 RVA: 0x0037CD08 File Offset: 0x0037AF08
		private void UpdateTeamItem(Transform item, LBEleTeamInfo teamInfo, ulong winTeamId, LBEleRoomState state, uint liveID)
		{
			Transform transform = item.Find("Win");
			Transform transform2 = item.Find("Lose");
			Transform transform3 = item.Find("Empty");
			transform.gameObject.SetActive(false);
			transform2.gameObject.SetActive(false);
			transform3.gameObject.SetActive(false);
			Transform transform4 = (teamInfo.leagueid == winTeamId || winTeamId == 0UL) ? transform : transform2;
			transform4.gameObject.SetActive(true);
			IXUILabel ixuilabel = transform4.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = transform4.Find("Team").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(teamInfo.name);
			ixuilabel2.SetText(teamInfo.zonename + "-" + teamInfo.servername);
		}

		// Token: 0x0600F641 RID: 63041 RVA: 0x0037CDE4 File Offset: 0x0037AFE4
		public void RefreshUI()
		{
			RoundFlag[] array = (RoundFlag[])Enum.GetValues(typeof(RoundFlag));
			foreach (RoundFlag roundFlag in array)
			{
				int num = (int)roundFlag;
				bool flag = this._itemDic.ContainsKey((RoundFlag)num);
				if (flag)
				{
					List<GameObject> list = this._itemDic[(RoundFlag)num];
					List<LBEleRoomInfo> roomsInfoByRound = XFreeTeamVersusLeagueDocument.Doc.GetRoomsInfoByRound((uint)num);
					for (int j = 0; j < list.Count; j++)
					{
						LBEleRoomInfo info = (roomsInfoByRound != null && j < roomsInfoByRound.Count) ? roomsInfoByRound[j] : null;
						this.UpdateDetailItem(list[j].transform, info);
					}
				}
			}
			LeagueTeamDetail eliChampionTeam = XFreeTeamVersusLeagueDocument.Doc.EliChampionTeam;
			bool flag2 = eliChampionTeam != null && eliChampionTeam.members.Count > 0;
			if (flag2)
			{
				base.uiBehaviour.ChampionMembers.gameObject.SetActive(true);
				base.uiBehaviour.NoChampion.gameObject.SetActive(false);
				base.uiBehaviour.GuildName.SetText(eliChampionTeam.teamname);
				int childCount = base.uiBehaviour.ChampionMembers.childCount;
				int num2 = Mathf.Min(childCount, eliChampionTeam.members.Count);
				int k;
				for (k = 0; k < num2; k++)
				{
					Transform child = base.uiBehaviour.ChampionMembers.GetChild(k);
					child.gameObject.SetActive(true);
					this.UpdateFinalItem(child, eliChampionTeam.members[k]);
				}
				while (k < childCount)
				{
					base.uiBehaviour.ChampionMembers.GetChild(k++).gameObject.SetActive(false);
				}
			}
			else
			{
				base.uiBehaviour.ChampionMembers.gameObject.SetActive(false);
				base.uiBehaviour.NoChampion.gameObject.SetActive(true);
				base.uiBehaviour.GuildName.SetText("");
			}
			this.RefreshEnterMatchBtn();
		}

		// Token: 0x0600F642 RID: 63042 RVA: 0x0037D018 File Offset: 0x0037B218
		private void UpdateFinalItem(Transform transform, LeagueTeamMemberDetail memberInfo)
		{
			IXUILabel ixuilabel = transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(memberInfo.brief.name);
			IXUILabel ixuilabel2 = transform.Find("Score/Num").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(memberInfo.pkpoint.ToString());
			IXUISprite ixuisprite = transform.Find("head").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(XFastEnumIntEqualityComparer<RoleType>.ToInt(memberInfo.brief.profession)));
		}

		// Token: 0x04006ACE RID: 27342
		private Dictionary<RoundFlag, List<GameObject>> _itemDic = new Dictionary<RoundFlag, List<GameObject>>();
	}
}
