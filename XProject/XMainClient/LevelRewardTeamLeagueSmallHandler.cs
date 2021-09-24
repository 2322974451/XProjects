using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardTeamLeagueSmallHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_Tween = (base.transform.Find("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.InitDetail(base.transform.Find("Bg/Left"), 0);
			this.InitDetail(base.transform.Find("Bg/Right"), 1);
			this.CloseTween();
		}

		private void InitDetail(Transform t, int team)
		{
			Transform transform = t.Find("Detail/DetailTpl");
			this.m_DetailLevel[team] = (transform.transform.Find("Level").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailAvatar[team] = (transform.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailProfession[team] = (transform.transform.Find("Profession").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailName[team] = (transform.transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailResult[team] = (transform.transform.Find("Result").GetComponent("XUISprite") as IXUISprite);
			this.m_DetailHP[team] = (transform.Find("HP").GetComponent("XUILabel") as IXUILabel);
		}

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardTeamLeagueSmall";
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

		public void SetRewardData(LeagueBattleOneResultNtf data)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ShowTeamLeagueSmallReward", null, null, null, null, null);
			XTeamLeagueBattleDocument specificDocument = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			bool flag = specificDocument.FindBlueMember(data.winrole.roleid);
			bool flag2 = specificDocument.FindBlueMember(data.loserole.roleid);
			bool flag3 = flag ^ !flag2;
			if (flag3)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"winroleId:",
					data.winrole.roleid,
					" isMyTeam:",
					flag.ToString()
				}), null, null, null, null, null);
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"loseroleId:",
					data.loserole.roleid,
					" isMyTeam:",
					flag2.ToString()
				}), null, null, null, null, null);
			}
			else
			{
				this.SetDetail(data.winrole, data.winhppercent, flag, true);
				this.SetDetail(data.loserole, data.losehppercent, flag2, false);
				this.m_Tween.PlayTween(true, -1f);
			}
		}

		private void SetDetail(LeagueBattleRoleBrief data, float hp, bool isLeft, bool isWin)
		{
			int num = isLeft ? 0 : 1;
			this.m_DetailLevel[num].SetText(data.level.ToString());
			this.m_DetailAvatar[num].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)data.profession));
			this.m_DetailProfession[num].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)data.profession));
			this.m_DetailName[num].SetText(data.name);
			if (isWin)
			{
				this.m_DetailResult[num].SetSprite("bhdz_win");
			}
			else
			{
				this.m_DetailResult[num].SetSprite("bhdz_lose");
			}
			this.m_DetailHP[num].SetText(string.Format("{0}%", hp.ToString("f2")));
		}

		public void CloseTween()
		{
			bool flag = this.m_Tween != null && this.m_Tween.gameObject.activeSelf;
			if (flag)
			{
				this.m_Tween.gameObject.SetActive(false);
			}
		}

		private IXUITweenTool m_Tween;

		private IXUILabel[] m_DetailLevel = new IXUILabel[2];

		private IXUISprite[] m_DetailAvatar = new IXUISprite[2];

		private IXUISprite[] m_DetailProfession = new IXUISprite[2];

		private IXUILabel[] m_DetailName = new IXUILabel[2];

		private IXUISprite[] m_DetailResult = new IXUISprite[2];

		private IXUILabel[] m_DetailHP = new IXUILabel[2];
	}
}
