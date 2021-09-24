using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SkyArenaInfoHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XSkyArenaBattleDocument>(XSkyArenaBattleDocument.uuID);
			this.doc.InfoHandler = this;
			this.m_Tween = (base.transform.Find("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Info = (base.transform.Find("Bg/Info").GetComponent("XUILabel") as IXUILabel);
			this.m_InfoEnd = (this.m_Info.gameObject.transform.Find("End").GetComponent("XUILabel") as IXUILabel);
			this.m_End = base.transform.Find("Bg/End");
			this.m_Res = (this.m_End.Find("Reward/Res").GetComponent("XUISprite") as IXUISprite);
			this.m_ResFX = this.m_End.Find("Reward/FX");
			this.m_Close = (this.m_End.Find("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = this.m_End.Find("Reward/Count/Left");
			this.m_AllKillNum[0] = (transform.Find("KillNum").GetComponent("XUILabel") as IXUILabel);
			this.m_AllDamage[0] = (transform.Find("Damage").GetComponent("XUILabel") as IXUILabel);
			Transform transform2 = this.m_End.Find("Reward/Count/Right");
			this.m_AllKillNum[1] = (transform2.Find("KillNum").GetComponent("XUILabel") as IXUILabel);
			this.m_AllDamage[1] = (transform2.Find("Damage").GetComponent("XUILabel") as IXUILabel);
			Transform transform3 = base.transform.Find("Bg/Left/DetailTpl");
			this.m_DetailLeftPool.SetupPool(null, transform3.gameObject, SkyArenaInfoHandler.TEAM_MEMBER_NUM, false);
			Transform transform4 = base.transform.Find("Bg/Right/DetailTpl");
			this.m_DetailRightPool.SetupPool(null, transform4.gameObject, SkyArenaInfoHandler.TEAM_MEMBER_NUM, false);
			this.InitDetail(this.m_DetailLeftPool, 0);
			this.InitDetail(this.m_DetailRightPool, 1);
			this.CloseTween();
		}

		private void InitDetail(XUIPool pool, int team)
		{
			pool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)SkyArenaInfoHandler.TEAM_MEMBER_NUM))
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
				this.m_DetailStart[team, num] = gameObject.transform.Find("Start");
				this.m_DetailPPT[team, num] = (this.m_DetailStart[team, num].Find("PPT").GetComponent("XUILabel") as IXUILabel);
				this.m_DetailEnd[team, num] = gameObject.transform.Find("End");
				this.m_DetailDamage[team, num] = (this.m_DetailEnd[team, num].Find("Damage").GetComponent("XUILabel") as IXUILabel);
				this.m_DetailKillNum[team, num] = (this.m_DetailEnd[team, num].Find("KillNum").GetComponent("XUILabel") as IXUILabel);
				num++;
			}
			pool.ActualReturnAll(false);
		}

		protected override string FileName
		{
			get
			{
				return "Battle/SkyArenaLoading";
			}
		}

		public override void RegisterEvent()
		{
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ClearShow();
		}

		private void ClearShow()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoCloseTweenTimerID);
			this._AutoCloseTweenTimerID = 0U;
		}

		protected override void OnHide()
		{
			this.ClearShow();
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.doc.InfoHandler = null;
			this.ClearShow();
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		private void RefreshInfo()
		{
		}

		public void PlayStartTween()
		{
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
			}
			this._fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_vs_Clip01", base.transform.FindChild("Fx"), false);
			this.m_End.gameObject.SetActive(false);
			this.m_InfoEnd.gameObject.SetActive(false);
			bool flag2 = this.doc.Stage == 1U;
			if (flag2)
			{
				this.m_Info.gameObject.SetActive(true);
				this.m_Info.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_BEGIN_TIP"), this.doc.Floor));
			}
			else
			{
				this.m_Info.gameObject.SetActive(false);
			}
			this.HideDetail();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this.doc.UserIdToRole.BufferValues.Count; i++)
			{
				XSkyArenaBattleDocument.RoleData roleData = this.doc.UserIdToRole.BufferValues[i];
				bool flag3 = roleData.teamid == this.doc.MyTeam;
				if (flag3)
				{
					this.SetStartDetail(roleData, 0, num);
					num++;
				}
				else
				{
					this.SetStartDetail(roleData, 1, num2);
					num2++;
				}
			}
			this.m_Tween.PlayTween(true, -1f);
			float interval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SkyArenaStartAnimTime")) + 1f;
			this._AutoCloseTweenTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.CloseTween), null);
		}

		public void PlayEndTween(SkyCityEstimateInfo data)
		{
			bool flag = data == null;
			if (!flag)
			{
				this.m_End.gameObject.SetActive(true);
				this.m_InfoEnd.gameObject.SetActive(true);
				this.m_Info.gameObject.SetActive(true);
				this.doc.ShowAddStage = 0U;
				bool flag2 = data.winteamid == 0U;
				if (flag2)
				{
					this.m_Info.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_DRAW"), data.floor));
					this.m_ResFX.gameObject.SetActive(false);
					this.m_Res.gameObject.SetActive(true);
					this.m_Res.SetSprite("BattleEven");
				}
				else
				{
					bool flag3 = (ulong)data.winteamid == (ulong)((long)this.doc.MyTeam);
					if (flag3)
					{
						this.m_Info.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_WIN"), data.floor + 1U));
						this.m_ResFX.gameObject.SetActive(true);
						this.m_Res.gameObject.SetActive(false);
						this.m_Res.SetSprite("BattleWin");
						this.doc.ShowAddStage = 1U;
					}
					else
					{
						this.m_Info.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_FAIL"), data.floor));
						this.m_ResFX.gameObject.SetActive(false);
						this.m_Res.gameObject.SetActive(true);
						this.m_Res.SetSprite("BattleLose");
					}
				}
				bool flag4 = data.floor <= 0U;
				if (flag4)
				{
					this.m_Info.SetText("");
					XSingleton<XDebug>.singleton.AddErrorLog("floor:" + data.floor, null, null, null, null, null);
				}
				ulong num = 0UL;
				ulong num2 = 0UL;
				this.HideDetail();
				int num3 = 0;
				int num4 = 0;
				for (int i = 0; i < data.info.Count; i++)
				{
					SkyCityEstimateBaseInfo skyCityEstimateBaseInfo = data.info[i];
					XSkyArenaBattleDocument.RoleData roleData;
					bool flag5 = !this.doc.UserIdToRole.TryGetValue(skyCityEstimateBaseInfo.roleid, out roleData);
					if (flag5)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("UID:" + skyCityEstimateBaseInfo.roleid + " No Find!", null, null, null, null, null);
					}
					else
					{
						bool flag6 = roleData.teamid == this.doc.MyTeam;
						if (flag6)
						{
							this.SetEndDetail(roleData, skyCityEstimateBaseInfo, 0, num3);
							num += skyCityEstimateBaseInfo.damage;
							num3++;
						}
						else
						{
							this.SetEndDetail(roleData, skyCityEstimateBaseInfo, 1, num4);
							num2 += skyCityEstimateBaseInfo.damage;
							num4++;
						}
					}
				}
				for (int j = 0; j < data.teamscore.Count; j++)
				{
					bool flag7 = (ulong)data.teamscore[j].teamid == (ulong)((long)this.doc.MyTeam);
					if (flag7)
					{
						this.m_AllKillNum[0].SetText(data.teamscore[j].score.ToString());
					}
					else
					{
						this.m_AllKillNum[1].SetText(data.teamscore[j].score.ToString());
					}
				}
				this.m_AllDamage[0].SetText(num.ToString());
				this.m_AllDamage[1].SetText(num2.ToString());
				bool flag8 = (ulong)this.doc.Stage == (ulong)((long)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SkyCityGames")));
				if (flag8)
				{
					this.m_Tween.RegisterOnFinishEventHandler(null);
					this.m_InfoEnd.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_BIG_REWARD_TIP"));
				}
				else
				{
					this.m_Tween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnEndMoveOver));
					this.m_InfoEnd.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_SMALL_REWARD_TIP"));
				}
				this.m_Tween.PlayTween(true, -1f);
				this.m_Close.RegisterClickEventHandler(null);
			}
		}

		private void SetStartDetail(XSkyArenaBattleDocument.RoleData data, int team, int index)
		{
			bool flag = (long)index >= (long)((ulong)SkyArenaInfoHandler.TEAM_MEMBER_NUM);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"index:",
					index,
					" >= ",
					SkyArenaInfoHandler.TEAM_MEMBER_NUM
				}), null, null, null, null, null);
			}
			else
			{
				this.m_Detail[team, index].gameObject.SetActive(true);
				this.m_DetailLevel[team, index].SetText(data.lv.ToString());
				this.m_DetailAvatar[team, index].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)data.job));
				this.m_DetailProfession[team, index].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)data.job));
				this.m_DetailName[team, index].SetText(data.name);
				this.m_DetailStart[team, index].gameObject.SetActive(true);
				this.m_DetailPPT[team, index].SetText(data.ppt.ToString());
				this.m_DetailEnd[team, index].gameObject.SetActive(false);
			}
		}

		private void SetEndDetail(XSkyArenaBattleDocument.RoleData data, SkyCityEstimateBaseInfo endData, int team, int index)
		{
			bool flag = (long)index > (long)((ulong)SkyArenaInfoHandler.TEAM_MEMBER_NUM);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"index:",
					index,
					" > ",
					SkyArenaInfoHandler.TEAM_MEMBER_NUM
				}), null, null, null, null, null);
			}
			else
			{
				this.m_Detail[team, index].gameObject.SetActive(true);
				this.m_DetailLevel[team, index].SetText(data.lv.ToString());
				this.m_DetailAvatar[team, index].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)data.job));
				this.m_DetailProfession[team, index].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)data.job));
				this.m_DetailName[team, index].SetText(data.name);
				this.m_DetailStart[team, index].gameObject.SetActive(false);
				this.m_DetailEnd[team, index].gameObject.SetActive(true);
				this.m_DetailDamage[team, index].SetText(endData.damage.ToString());
				this.m_DetailKillNum[team, index].SetText(endData.killer.ToString());
			}
		}

		private void HideDetail()
		{
			for (int i = 0; i < 2; i++)
			{
				int num = 0;
				while ((long)num < (long)((ulong)SkyArenaInfoHandler.TEAM_MEMBER_NUM))
				{
					this.m_Detail[i, num].gameObject.SetActive(false);
					num++;
				}
			}
		}

		private void OnEndMoveOver(IXUITweenTool tween)
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.CloseTween();
			DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.ShowTip(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_ROUND_ALL_END_REST"));
			this.doc.StageEnd();
			return true;
		}

		private void CloseTween(object param)
		{
			this.CloseTween();
		}

		public void CloseTween()
		{
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
			bool flag2 = this.m_Tween != null;
			if (flag2)
			{
				this.m_Tween.gameObject.SetActive(false);
			}
		}

		private XSkyArenaBattleDocument doc = null;

		private uint _AutoCloseTweenTimerID = 0U;

		public static readonly uint TEAM_MEMBER_NUM = 3U;

		private IXUITweenTool m_Tween;

		private Transform m_End;

		private IXUISprite m_Res;

		private Transform m_ResFX;

		private IXUIButton m_Close;

		private IXUILabel m_Info;

		private IXUILabel m_InfoEnd;

		private XUIPool m_DetailLeftPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_DetailRightPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform[,] m_Detail = new Transform[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailLevel = new IXUILabel[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private IXUISprite[,] m_DetailAvatar = new IXUISprite[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private IXUISprite[,] m_DetailProfession = new IXUISprite[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailName = new IXUILabel[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private Transform[,] m_DetailStart = new Transform[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailPPT = new IXUILabel[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private Transform[,] m_DetailEnd = new Transform[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailDamage = new IXUILabel[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailKillNum = new IXUILabel[2, (int)SkyArenaInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[] m_AllKillNum = new IXUILabel[2];

		private IXUILabel[] m_AllDamage = new IXUILabel[2];

		private XFx _fx = null;
	}
}
