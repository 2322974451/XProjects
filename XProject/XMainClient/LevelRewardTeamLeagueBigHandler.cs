using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardTeamLeagueBigHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_Tween = (base.transform.Find("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Close = (base.transform.Find("Bg").GetComponent("XUIButton") as IXUIButton);
			this.InitTeam(base.transform.Find("Bg/TeamL"), 0);
			this.InitTeam(base.transform.Find("Bg/TeamR"), 1);
			Transform transform = base.transform.Find("Bg/Left/DetailTpl");
			this.m_DetailLeftPool.SetupPool(null, transform.gameObject, LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM, false);
			Transform transform2 = base.transform.Find("Bg/Right/DetailTpl");
			this.m_DetailRightPool.SetupPool(null, transform2.gameObject, LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM, false);
			this.InitDetail(this.m_DetailLeftPool, 0);
			this.InitDetail(this.m_DetailRightPool, 1);
			this.m_Reward = base.transform.Find("Bg/Reward");
			this.m_Rank = (this.m_Reward.Find("Rank").GetComponent("XUILabel") as IXUILabel);
			this.m_RankTip = (this.m_Reward.Find("Rank/RankTip").GetComponent("XUILabel") as IXUILabel);
			this.m_RankPic = (this.m_Reward.Find("Rank/RankPic").GetComponent("XUISprite") as IXUISprite);
			this.m_Point = (this.m_Reward.Find("Point").GetComponent("XUILabel") as IXUILabel);
			this.m_PointPic = (this.m_Reward.Find("Point/PointPic").GetComponent("XUISprite") as IXUISprite);
			this.m_Honor = (this.m_Reward.Find("Honor").GetComponent("XUILabel") as IXUILabel);
			this.CloseTween();
		}

		private void InitTeam(Transform t, int team)
		{
			this.m_TeamName[team] = (t.Find("TeamName").GetComponent("XUILabel") as IXUILabel);
			this.m_Server[team] = (t.Find("Server").GetComponent("XUILabel") as IXUILabel);
			this.m_Result[team] = (t.Find("Result").GetComponent("XUISprite") as IXUISprite);
			this.m_None[team] = t.Find("None");
		}

		private void InitDetail(XUIPool pool, int team)
		{
			pool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM))
			{
				GameObject gameObject = pool.FetchGameObject(false);
				bool flag = team == 0;
				if (flag)
				{
					this.m_Detail[team, num] = base.transform.Find(string.Format("Bg/Left/Detail{0}", num));
				}
				bool flag2 = team == 1;
				if (flag2)
				{
					this.m_Detail[team, num] = base.transform.Find(string.Format("Bg/Right/Detail{0}", num));
				}
				XSingleton<UiUtility>.singleton.AddChild(this.m_Detail[team, num], gameObject.transform);
				this.m_DetailLevel[team, num] = (gameObject.transform.Find("Level").GetComponent("XUILabel") as IXUILabel);
				this.m_DetailAvatar[team, num] = (gameObject.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite);
				this.m_DetailProfession[team, num] = (gameObject.transform.Find("Profession").GetComponent("XUISprite") as IXUISprite);
				this.m_DetailName[team, num] = (gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
				this.m_DetailKillNum[team, num] = (gameObject.transform.Find("KillNum").GetComponent("XUILabel") as IXUILabel);
				this.m_DetailNoPlay[team, num] = gameObject.transform.Find("NoPlay");
				num++;
			}
			pool.ActualReturnAll(false);
		}

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardTeamLeagueBig";
			}
		}

		public override void RegisterEvent()
		{
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		public void SetRewardData(LeagueBattleResultNtf data)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ShowTeamLeagueBigReward", null, null, null, null, null);
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			bool flag = specificDocument.BattleBaseInfoBlue == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("TeamLeague SetBigRewardData: BattleBaseInfoBlue is Null", null, null, null, null, null);
			}
			else
			{
				bool flag2 = specificDocument.BattleBaseInfoBlue.league_teamid == data.winteam.league_teamid;
				bool flag3 = specificDocument.BattleBaseInfoBlue.league_teamid == data.loseteam.league_teamid;
				bool flag4 = flag2 ^ !flag3;
				if (flag4)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
					{
						"MyTeamID:",
						specificDocument.BattleBaseInfoBlue.league_teamid,
						"\nLeagueBattleResultNtfTeamID:",
						data.winteam.league_teamid,
						" ",
						data.loseteam.league_teamid
					}), null, null, null, null, null);
				}
				else
				{
					this.SetDetail(data.winteam, flag2, true);
					this.SetDetail(data.loseteam, flag3, false);
					bool active = specificDocument.FindBlueMember(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID) || specificDocument.FindRedMember(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
					bool flag5 = data.type == LeagueBattleType.LeagueBattleType_Eliminate || data.type == LeagueBattleType.LeagueBattleType_CrossEliminate;
					if (flag5)
					{
						active = false;
					}
					this.m_Reward.gameObject.SetActive(active);
					this.m_Tween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnEndMoveOver));
					this.m_Tween.PlayTween(true, -1f);
				}
			}
		}

		private void SetDetail(LeagueBattleResultTeam data, bool isLeft, bool isWin)
		{
			int num = isLeft ? 0 : 1;
			this.m_TeamName[num].SetText(data.name);
			this.m_Server[num].SetText(data.servername);
			if (isWin)
			{
				this.m_Result[num].SetSprite("bhdz_win");
			}
			else
			{
				this.m_Result[num].SetSprite("bhdz_lose");
			}
			this.m_None[num].gameObject.SetActive(data.members.Count == 0);
			if (isLeft)
			{
				this.m_Honor.SetText(data.honorpoint.ToString());
				this.m_Rank.SetText(data.rank_change.ToString());
				bool flag = data.rank_change >= 0;
				if (flag)
				{
					this.m_Rank.SetText(string.Format("+{0}", data.rank_change.ToString()));
					this.m_RankTip.SetText(XSingleton<XStringTable>.singleton.GetString("TEAM_LEAGUE_RANK_UP"));
					this.m_RankPic.SetSprite("hall_zljt_0");
				}
				else
				{
					this.m_Rank.SetText(data.rank_change.ToString());
					this.m_RankTip.SetText(XSingleton<XStringTable>.singleton.GetString("TEAM_LEAGUE_RANK_DOWN"));
					this.m_RankPic.SetSprite("hall_zljt_1");
				}
				bool flag2 = data.score_change >= 0;
				if (flag2)
				{
					this.m_Point.SetText(string.Format("+{0}", data.score_change.ToString()));
					this.m_PointPic.SetSprite("hall_zljt_0");
				}
				else
				{
					this.m_Point.SetText(data.score_change.ToString());
					this.m_PointPic.SetSprite("hall_zljt_1");
				}
			}
			for (int i = 0; i < data.members.Count; i++)
			{
				this.m_Detail[num, i].gameObject.SetActive(true);
				this.m_DetailLevel[num, i].SetText(data.members[i].basedata.level.ToString());
				this.m_DetailAvatar[num, i].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)data.members[i].basedata.profession));
				this.m_DetailProfession[num, i].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)data.members[i].basedata.profession));
				this.m_DetailName[num, i].SetText(data.members[i].basedata.name);
				this.m_DetailKillNum[num, i].SetText(data.members[i].killnum.ToString());
				this.m_DetailNoPlay[num, i].gameObject.SetActive(!data.members[i].is_up);
			}
			int num2 = data.members.Count;
			while ((long)num2 < (long)((ulong)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM))
			{
				this.m_Detail[num, num2].gameObject.SetActive(false);
				num2++;
			}
		}

		private void OnEndMoveOver(IXUITweenTool tween)
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			specificDocument.SendLeaveScene();
			return true;
		}

		public void CloseTween()
		{
			bool activeSelf = this.m_Tween.gameObject.activeSelf;
			if (activeSelf)
			{
				this.m_Tween.gameObject.SetActive(false);
			}
		}

		public static readonly uint TEAM_MEMBER_NUM = 4U;

		private IXUITweenTool m_Tween;

		private IXUIButton m_Close;

		private Transform m_Reward;

		private IXUILabel m_Rank;

		private IXUILabel m_RankTip;

		private IXUISprite m_RankPic;

		private IXUILabel m_Point;

		private IXUISprite m_PointPic;

		private IXUILabel m_Honor;

		private XUIPool m_DetailLeftPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_DetailRightPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform[,] m_Detail = new Transform[2, (int)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailLevel = new IXUILabel[2, (int)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM];

		private IXUISprite[,] m_DetailAvatar = new IXUISprite[2, (int)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM];

		private IXUISprite[,] m_DetailProfession = new IXUISprite[2, (int)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailName = new IXUILabel[2, (int)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailKillNum = new IXUILabel[2, (int)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM];

		private Transform[,] m_DetailNoPlay = new Transform[2, (int)LevelRewardTeamLeagueBigHandler.TEAM_MEMBER_NUM];

		private IXUILabel[] m_TeamName = new IXUILabel[2];

		private IXUILabel[] m_Server = new IXUILabel[2];

		private IXUISprite[] m_Result = new IXUISprite[2];

		private Transform[] m_None = new Transform[2];
	}
}
