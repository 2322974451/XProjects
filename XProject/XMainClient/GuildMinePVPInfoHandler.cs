using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildMinePVPInfoHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
			this.doc.InfoHandler = this;
			this.m_Tween = (base.transform.Find("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Info = (base.transform.Find("Bg/Info").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Left/DetailTpl");
			this.m_DetailLeftPool.SetupPool(null, transform.gameObject, GuildMinePVPInfoHandler.TEAM_MEMBER_NUM, false);
			Transform transform2 = base.transform.Find("Bg/Right/DetailTpl");
			this.m_DetailRightPool.SetupPool(null, transform2.gameObject, GuildMinePVPInfoHandler.TEAM_MEMBER_NUM, false);
			this.InitDetail(this.m_DetailLeftPool, 0);
			this.InitDetail(this.m_DetailRightPool, 1);
			this.m_DetailGuildName[0] = (base.transform.Find("Bg/Left/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.m_DetailGuildName[1] = (base.transform.Find("Bg/Right/GuildName").GetComponent("XUILabel") as IXUILabel);
			this.CloseTween(null);
		}

		private void InitDetail(XUIPool pool, int team)
		{
			pool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)GuildMinePVPInfoHandler.TEAM_MEMBER_NUM))
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
				num++;
			}
			pool.ActualReturnAll(false);
		}

		protected override string FileName
		{
			get
			{
				return "Battle/GuildMinePVPLoading";
			}
		}

		public override void RegisterEvent()
		{
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ClearShow();
			this.m_Info.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_BATTLE_VS_INFO"));
		}

		private void ClearShow()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoCloseTweenTimerID);
			this._AutoCloseTweenTimerID = 0U;
		}

		protected override void OnHide()
		{
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
			this.ClearShow();
			base.OnHide();
		}

		public override void OnUnload()
		{
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
			this.doc.InfoHandler = null;
			this.ClearShow();
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		public void PlayStartTween()
		{
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
			}
			this._fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_vs_Clip01", base.transform.FindChild("Fx"), false);
			this.HideDetail();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this.doc.UserIdToRole.BufferValues.Count; i++)
			{
				XGuildMineBattleDocument.RoleData roleData = this.doc.UserIdToRole.BufferValues[i];
				bool flag2 = roleData.teamID == this.doc.MyTeam;
				if (flag2)
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

		private void SetStartDetail(XGuildMineBattleDocument.RoleData data, int team, int index)
		{
			bool flag = (long)index >= (long)((ulong)GuildMinePVPInfoHandler.TEAM_MEMBER_NUM);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"index:",
					index,
					" >= ",
					GuildMinePVPInfoHandler.TEAM_MEMBER_NUM
				}), null, null, null, null, null);
			}
			else
			{
				this.m_Detail[team, index].gameObject.SetActive(true);
				this.m_DetailLevel[team, index].SetText(data.lv.ToString());
				this.m_DetailAvatar[team, index].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)data.job));
				this.m_DetailProfession[team, index].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)data.job));
				this.m_DetailName[team, index].SetText(data.name);
				this.m_DetailGuildName[team].SetText(data.guildname);
			}
		}

		private void HideDetail()
		{
			for (int i = 0; i < 2; i++)
			{
				int num = 0;
				while ((long)num < (long)((ulong)GuildMinePVPInfoHandler.TEAM_MEMBER_NUM))
				{
					this.m_Detail[i, num].gameObject.SetActive(false);
					num++;
				}
			}
		}

		public void CloseTween(object param = null)
		{
			this.m_Tween.gameObject.SetActive(false);
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
		}

		private XGuildMineBattleDocument doc = null;

		private uint _AutoCloseTweenTimerID = 0U;

		public static readonly uint TEAM_MEMBER_NUM = 4U;

		private IXUITweenTool m_Tween;

		private IXUILabel m_Info;

		private XUIPool m_DetailLeftPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_DetailRightPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform[,] m_Detail = new Transform[2, (int)GuildMinePVPInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailLevel = new IXUILabel[2, (int)GuildMinePVPInfoHandler.TEAM_MEMBER_NUM];

		private IXUISprite[,] m_DetailAvatar = new IXUISprite[2, (int)GuildMinePVPInfoHandler.TEAM_MEMBER_NUM];

		private IXUISprite[,] m_DetailProfession = new IXUISprite[2, (int)GuildMinePVPInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[,] m_DetailName = new IXUILabel[2, (int)GuildMinePVPInfoHandler.TEAM_MEMBER_NUM];

		private IXUILabel[] m_DetailGuildName = new IXUILabel[2];

		private XFx _fx = null;
	}
}
