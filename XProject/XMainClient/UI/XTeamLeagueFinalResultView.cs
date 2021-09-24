using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamLeagueFinalResultView : DlgBase<XTeamLeagueFinalResultView, XTeamLeagueFinalResultBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueFinalDuel";
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
			this.InitProperties();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		protected override void OnShow()
		{
			base.OnShow();
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueEleInfo();
		}

		protected override void OnHide()
		{
			XFreeTeamVersusLeagueDocument.Doc.SendCloseLeagueEleNtf();
			base.OnHide();
		}

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

		private bool OnClickCloseBtn(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

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

		private void OnClickLive(IXUISprite uiSprite)
		{
			bool flag = uiSprite.ID > 0UL;
			if (flag)
			{
				XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
				specificDocument.EnterSpectateBattle((uint)uiSprite.ID, LiveType.LIVE_LEAGUEBATTLE);
			}
		}

		private void UpdateEmptyItem(Transform item)
		{
			Transform transform = item.Find("Win");
			Transform transform2 = item.Find("Lose");
			Transform transform3 = item.Find("Empty");
			transform.gameObject.SetActive(false);
			transform2.gameObject.SetActive(false);
			transform3.gameObject.SetActive(true);
		}

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

		private void UpdateFinalItem(Transform transform, LeagueTeamMemberDetail memberInfo)
		{
			IXUILabel ixuilabel = transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(memberInfo.brief.name);
			IXUILabel ixuilabel2 = transform.Find("Score/Num").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(memberInfo.pkpoint.ToString());
			IXUISprite ixuisprite = transform.Find("head").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(XFastEnumIntEqualityComparer<RoleType>.ToInt(memberInfo.brief.profession)));
		}

		private Dictionary<RoundFlag, List<GameObject>> _itemDic = new Dictionary<RoundFlag, List<GameObject>>();
	}
}
