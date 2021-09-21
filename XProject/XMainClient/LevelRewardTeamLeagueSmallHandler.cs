using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BED RID: 3053
	internal class LevelRewardTeamLeagueSmallHandler : DlgHandlerBase
	{
		// Token: 0x0600ADEC RID: 44524 RVA: 0x00207FB0 File Offset: 0x002061B0
		protected override void Init()
		{
			base.Init();
			this.m_Tween = (base.transform.Find("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.InitDetail(base.transform.Find("Bg/Left"), 0);
			this.InitDetail(base.transform.Find("Bg/Right"), 1);
			this.CloseTween();
		}

		// Token: 0x0600ADED RID: 44525 RVA: 0x00208024 File Offset: 0x00206224
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

		// Token: 0x170030A7 RID: 12455
		// (get) Token: 0x0600ADEE RID: 44526 RVA: 0x00208124 File Offset: 0x00206324
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardTeamLeagueSmall";
			}
		}

		// Token: 0x0600ADEF RID: 44527 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void RegisterEvent()
		{
		}

		// Token: 0x0600ADF0 RID: 44528 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600ADF1 RID: 44529 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600ADF2 RID: 44530 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600ADF3 RID: 44531 RVA: 0x001E669E File Offset: 0x001E489E
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600ADF4 RID: 44532 RVA: 0x0020813C File Offset: 0x0020633C
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

		// Token: 0x0600ADF5 RID: 44533 RVA: 0x0020826C File Offset: 0x0020646C
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

		// Token: 0x0600ADF6 RID: 44534 RVA: 0x00208344 File Offset: 0x00206544
		public void CloseTween()
		{
			bool flag = this.m_Tween != null && this.m_Tween.gameObject.activeSelf;
			if (flag)
			{
				this.m_Tween.gameObject.SetActive(false);
			}
		}

		// Token: 0x040041D0 RID: 16848
		private IXUITweenTool m_Tween;

		// Token: 0x040041D1 RID: 16849
		private IXUILabel[] m_DetailLevel = new IXUILabel[2];

		// Token: 0x040041D2 RID: 16850
		private IXUISprite[] m_DetailAvatar = new IXUISprite[2];

		// Token: 0x040041D3 RID: 16851
		private IXUISprite[] m_DetailProfession = new IXUISprite[2];

		// Token: 0x040041D4 RID: 16852
		private IXUILabel[] m_DetailName = new IXUILabel[2];

		// Token: 0x040041D5 RID: 16853
		private IXUISprite[] m_DetailResult = new IXUISprite[2];

		// Token: 0x040041D6 RID: 16854
		private IXUILabel[] m_DetailHP = new IXUILabel[2];
	}
}
