using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B97 RID: 2967
	internal class BattleCaptainPVPHandler : DlgHandlerBase
	{
		// Token: 0x0600AA38 RID: 43576 RVA: 0x001E6004 File Offset: 0x001E4204
		protected override void Init()
		{
			base.Init();
			XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
			specificDocument.Handler = this;
			this.m_Leader = (base.PanelObject.transform.Find("Start/Leader").GetComponent("XUILabel") as IXUILabel);
			this.m_Start = (base.PanelObject.transform.Find("Start").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Blue = (base.PanelObject.transform.Find("Sorce/Blue").GetComponent("XUILabel") as IXUILabel);
			this.m_Red = (base.PanelObject.transform.Find("Sorce/Red").GetComponent("XUILabel") as IXUILabel);
			this.m_End = (base.PanelObject.transform.Find("End").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Win = base.PanelObject.transform.Find("End/Win").gameObject;
			this.m_Draw = base.PanelObject.transform.Find("End/Draw").gameObject;
			this.m_Lose = base.PanelObject.transform.Find("End/Lose").gameObject;
			this.m_AllEndTime = (base.PanelObject.transform.Find("End/AllEndTime").GetComponent("XUILabel") as IXUILabel);
			this.m_RoundEndTime = (base.PanelObject.transform.Find("End/RoundEndTime").GetComponent("XUILabel") as IXUILabel);
			this.m_EndText = (base.PanelObject.transform.Find("End/T").GetComponent("XUILabel") as IXUILabel);
			this.m_ReliveTime = (base.PanelObject.transform.Find("ReliveTime").GetComponent("XUILabel") as IXUILabel);
			this.m_Relive = (base.PanelObject.transform.Find("ReliveTime").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_EndIcon = (base.PanelObject.transform.Find("End/Icon").GetComponent("XUITexture") as IXUITexture);
			int num = 1;
			while ((long)num <= (long)((ulong)XBattleCaptainPVPDocument.CONTINUOUS_KILL))
			{
				this.m_Killicon[num] = (base.PanelObject.transform.Find("Continuous/Killicon" + num).GetComponent("XUIPlayTween") as IXUITweenTool);
				num++;
			}
			this.m_KillText = (base.PanelObject.transform.Find("Continuous/KillText").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.PanelObject.transform.FindChild("KillInfo/Bg/InfoTpl");
			this.m_ShowIntoPool.SetupPool(null, transform.gameObject, XDeck.GROUP_NEED_CARD_MAX, false);
			this.m_ShowIntoPool.FakeReturnAll();
			int num2 = 0;
			while ((long)num2 < (long)((ulong)XBattleCaptainPVPDocument.GAME_INFO))
			{
				GameObject gameObject = this.m_ShowIntoPool.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				this.infoDis = new Vector3(0f, (float)(-(float)ixuisprite.spriteHeight), 0f);
				gameObject.transform.localPosition = this.infoDis * (float)num2;
				this.m_Killer[num2] = (gameObject.transform.Find("killer").GetComponent("XUILabel") as IXUILabel);
				this.m_Dead[num2] = (gameObject.transform.Find("dead").GetComponent("XUILabel") as IXUILabel);
				this.m_InfoIcon[num2] = (gameObject.transform.Find("icon").GetComponent("XUISprite") as IXUISprite);
				num2++;
			}
			this.m_ShowIntoPool.ActualReturnAll(false);
			this._doc = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
			this.teamLeader = base.PanelObject.transform.Find("TeamLeader");
			this.m_BlueLeaderName = (this.teamLeader.Find("LeaderBlue").GetComponent("XUILabel") as IXUILabel);
			this.m_BlueHpPer = (this.teamLeader.Find("LeaderBlue/Per").GetComponent("XUILabel") as IXUILabel);
			this.m_BlueHpBar = (this.teamLeader.Find("LeaderBlue/HpBar").GetComponent("XUIProgress") as IXUIProgress);
			this.m_RedLeaderName = (this.teamLeader.transform.Find("LeaderRed").GetComponent("XUILabel") as IXUILabel);
			this.m_RedHpPer = (this.teamLeader.transform.Find("LeaderRed/Per").GetComponent("XUILabel") as IXUILabel);
			this.m_RedHpBar = (this.teamLeader.transform.Find("LeaderRed/HpBar").GetComponent("XUIProgress") as IXUIProgress);
		}

		// Token: 0x1700303C RID: 12348
		// (get) Token: 0x0600AA39 RID: 43577 RVA: 0x001E6530 File Offset: 0x001E4730
		protected override string FileName
		{
			get
			{
				return "Battle/BattleCaptainPVP";
			}
		}

		// Token: 0x0600AA3A RID: 43578 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void RegisterEvent()
		{
		}

		// Token: 0x0600AA3B RID: 43579 RVA: 0x001E6547 File Offset: 0x001E4747
		protected override void OnShow()
		{
			base.OnShow();
			this.InitShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._StratTimerID);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
		}

		// Token: 0x0600AA3C RID: 43580 RVA: 0x001E657C File Offset: 0x001E477C
		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._StratTimerID);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
			this._StratTimerID = 0U;
			this._RefreshDataTimerID = 0U;
			this.m_EndIcon.SetTexturePath("");
			base.OnHide();
		}

		// Token: 0x0600AA3D RID: 43581 RVA: 0x001E65D4 File Offset: 0x001E47D4
		public override void OnUnload()
		{
			bool flag = base.PanelObject != null;
			if (flag)
			{
				base.PanelObject.SetActive(false);
			}
			this._doc.TeamBlood.Clear();
			this._doc.Handler = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._StratTimerID);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
			this._StratTimerID = 0U;
			this._RefreshDataTimerID = 0U;
			this._doc.myTeam = 0;
			this._doc.groupLeader1 = 0UL;
			this._doc.groupLeader2 = 0UL;
			this._doc.spectateInitTeam = 0;
			this._doc.spectateNowTeam = 0;
			this._doc.playedBigResult = false;
			base.OnUnload();
		}

		// Token: 0x0600AA3E RID: 43582 RVA: 0x001E669E File Offset: 0x001E489E
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600AA3F RID: 43583 RVA: 0x001E66A8 File Offset: 0x001E48A8
		private void InitShow()
		{
			this._doc.qInfo.Clear();
			this.m_Start.gameObject.SetActive(false);
			this.m_End.gameObject.SetActive(false);
			this.m_ReliveTime.gameObject.SetActive(false);
			this.ShowGameInfo();
			this.ShowConKill(0);
			this.m_Blue.SetText("0");
			this.m_Red.SetText("0");
			this.m_BlueLeaderName.SetText("");
			this.m_BlueHpPer.SetText("");
			this.m_BlueHpBar.value = 0f;
			this.m_RedLeaderName.SetText("");
			this.m_RedHpPer.SetText("");
			this.m_RedHpBar.value = 0f;
		}

		// Token: 0x0600AA40 RID: 43584 RVA: 0x001E6794 File Offset: 0x001E4994
		public void ShowGameInfo()
		{
			this.m_ShowIntoPool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)XBattleCaptainPVPDocument.GAME_INFO))
			{
				GameObject gameObject = this.m_ShowIntoPool.FetchGameObject(false);
				bool flag = this._doc.qInfo.Count <= num;
				if (flag)
				{
					gameObject.transform.localPosition = this.NoVisible;
				}
				else
				{
					gameObject.transform.localPosition = this.infoDis * (float)num;
					int num2 = 0;
					foreach (XBattleCaptainPVPDocument.KillInfo killInfo in this._doc.qInfo)
					{
						bool flag2 = num2 == num;
						if (flag2)
						{
							this.m_Killer[num].SetText(killInfo.KillName);
							this.m_Dead[num].SetText(killInfo.DeadName);
							bool isDoodad = killInfo.IsDoodad;
							if (isDoodad)
							{
								this.m_InfoIcon[num].SetSprite("hall_zljt_0");
							}
							else
							{
								this.m_InfoIcon[num].SetSprite("klj");
							}
							break;
						}
						num2++;
					}
				}
				num++;
			}
			this.m_ShowIntoPool.ActualReturnAll(false);
		}

		// Token: 0x0600AA41 RID: 43585 RVA: 0x001E68FC File Offset: 0x001E4AFC
		public void ShowConKill(int count)
		{
			bool flag = count <= 1;
			if (flag)
			{
				this.m_KillText.SetAlpha(0f);
			}
			else
			{
				this.m_KillText.SetAlpha(1f);
				string arg = (count >= 9) ? "9" : count.ToString();
				this.m_KillText.SetSprite(string.Format("{0}{1}", "kill", arg));
				this.m_KillText.MakePixelPerfect();
			}
			bool flag2 = count > 0;
			if (flag2)
			{
				int param = (count >= 5) ? 5 : count;
				this.PlayAudio(param);
			}
			bool flag3 = (long)count >= (long)((ulong)XBattleCaptainPVPDocument.CONTINUOUS_KILL);
			if (flag3)
			{
				count = (int)XBattleCaptainPVPDocument.CONTINUOUS_KILL;
			}
			int num = 1;
			while ((long)num <= (long)((ulong)XBattleCaptainPVPDocument.CONTINUOUS_KILL))
			{
				bool flag4 = num <= count;
				if (flag4)
				{
					this.m_Killicon[num].gameObject.transform.localPosition = new Vector3((float)(((double)((float)(num - 1) + 0.5f) - (double)count / 2.0) * (double)XBattleCaptainPVPDocument.ConKillIconDis), 0f, 0f);
					this.m_Killicon[num].PlayTween(true, -1f);
				}
				else
				{
					this.m_Killicon[num].gameObject.transform.localPosition = this.NoVisible;
				}
				num++;
			}
		}

		// Token: 0x0600AA42 RID: 43586 RVA: 0x001E6A66 File Offset: 0x001E4C66
		public void PlayAudio(int param)
		{
			XSingleton<XAudioMgr>.singleton.PlayUISound(string.Format("Audio/VO/System/system{0}", param), true, AudioChannel.Action);
		}

		// Token: 0x0600AA43 RID: 43587 RVA: 0x001E6A88 File Offset: 0x001E4C88
		public void ShowReviveTime(float time, bool isClose)
		{
			bool flag = isClose && this.m_Relive.gameObject.activeSelf;
			if (flag)
			{
				this.m_Relive.PlayTween(true, -1f);
			}
			bool flag2 = time < 0f;
			if (flag2)
			{
				time = 0f;
			}
			int num = (int)time;
			this.m_ReliveTime.SetText(num.ToString());
		}

		// Token: 0x0600AA44 RID: 43588 RVA: 0x001E6AF0 File Offset: 0x001E4CF0
		public void ShowEndTime(float time, bool isClose, bool isEndAll)
		{
			bool flag = isClose && this.m_End.gameObject.activeSelf;
			if (flag)
			{
				if (isEndAll)
				{
					this.m_End.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnEndMoveOver));
				}
				else
				{
					this.m_End.RegisterOnFinishEventHandler(null);
				}
				this.m_End.PlayTween(true, -1f);
			}
			bool flag2 = time < 0f;
			if (flag2)
			{
				time = 0f;
			}
			int num = (int)time;
			bool playedBigResult = this._doc.playedBigResult;
			if (playedBigResult)
			{
				this.m_AllEndTime.Alpha = 1f;
				this.m_RoundEndTime.Alpha = 0f;
				this.m_AllEndTime.SetText(string.Format(XStringDefineProxy.GetString("CAPTAIN_END"), num.ToString()));
			}
			else
			{
				this.m_AllEndTime.Alpha = 0f;
				this.m_RoundEndTime.Alpha = 1f;
				this.m_RoundEndTime.SetText(string.Format(XStringDefineProxy.GetString("CAPTAIN_ROUND"), num.ToString()));
			}
		}

		// Token: 0x0600AA45 RID: 43589 RVA: 0x001E6C13 File Offset: 0x001E4E13
		private void OnEndMoveOver(IXUITweenTool tween)
		{
			this._doc.PlayBigResult();
		}

		// Token: 0x0600AA46 RID: 43590 RVA: 0x001E6C24 File Offset: 0x001E4E24
		public void ShowSorce(bool isMyWin)
		{
			if (isMyWin)
			{
				int num = int.Parse(this.m_Blue.GetText());
				this.m_Blue.SetText((num + 1).ToString());
			}
			else
			{
				int num2 = int.Parse(this.m_Red.GetText());
				this.m_Red.SetText((num2 + 1).ToString());
			}
		}

		// Token: 0x0600AA47 RID: 43591 RVA: 0x001E6C90 File Offset: 0x001E4E90
		public void ShowLeaderHpName(ulong blueLeader, ulong redLeader)
		{
			this.BlueLeader = blueLeader;
			this.RedLeader = redLeader;
			bool flag = blueLeader == 0UL;
			if (flag)
			{
				this.m_BlueLeaderName.SetText("");
			}
			else
			{
				XBattleCaptainPVPDocument.RoleData roleInfo = this._doc.GetRoleInfo(blueLeader);
				bool flag2 = roleInfo.roleID > 0UL;
				if (flag2)
				{
					this.m_BlueLeaderName.SetText(roleInfo.Name);
				}
				else
				{
					this.m_BlueLeaderName.SetText("");
				}
			}
			bool flag3 = redLeader == 0UL;
			if (flag3)
			{
				this.m_RedLeaderName.SetText("");
			}
			else
			{
				XBattleCaptainPVPDocument.RoleData roleInfo = this._doc.GetRoleInfo(redLeader);
				bool flag4 = roleInfo.roleID > 0UL;
				if (flag4)
				{
					this.m_RedLeaderName.SetText(roleInfo.Name);
				}
				else
				{
					this.m_RedLeaderName.SetText("");
				}
			}
		}

		// Token: 0x0600AA48 RID: 43592 RVA: 0x001E6D78 File Offset: 0x001E4F78
		public void RefreshLeaderHp()
		{
			bool isEnd = this._doc.isEnd;
			if (isEnd)
			{
				this.BlueLeader = 0UL;
				this.RedLeader = 0UL;
			}
			bool flag = this.BlueLeader == 0UL && this.RedLeader == 0UL;
			if (!flag)
			{
				XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this.BlueLeader);
				bool flag2 = entity != null;
				if (flag2)
				{
					double attr = entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Total);
					double attr2 = entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
					double num = attr / attr2;
					this.m_BlueHpPer.SetText(string.Format("{0}%", Math.Ceiling(num * 100.0).ToString()));
					this.m_BlueHpBar.value = (float)num;
				}
				else
				{
					this.m_BlueHpPer.SetText("");
					this.m_BlueHpBar.value = 0f;
				}
				entity = XSingleton<XEntityMgr>.singleton.GetEntity(this.RedLeader);
				bool flag3 = entity != null;
				if (flag3)
				{
					double attr = entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Total);
					double attr2 = entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
					double num = attr / attr2;
					this.m_RedHpPer.SetText(string.Format("{0}%", Math.Ceiling(num * 100.0).ToString()));
					this.m_RedHpBar.value = (float)num;
				}
				else
				{
					this.m_RedHpPer.SetText("");
					this.m_RedHpBar.value = 0f;
				}
			}
		}

		// Token: 0x0600AA49 RID: 43593 RVA: 0x001E6F15 File Offset: 0x001E5115
		public void ShowStart()
		{
			this._StratTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this._ShowStart), null);
		}

		// Token: 0x0600AA4A RID: 43594 RVA: 0x001E6F3C File Offset: 0x001E513C
		private void _ShowStart(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.m_Start.PlayTween(true, -1f);
			}
		}

		// Token: 0x0600AA4B RID: 43595 RVA: 0x001E6F68 File Offset: 0x001E5168
		private void AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this._doc.ReqBattleCaptainPVPRefreshInfo(false);
				this._RefreshDataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.AutoRefresh), null);
			}
		}

		// Token: 0x0600AA4C RID: 43596 RVA: 0x001E6FB4 File Offset: 0x001E51B4
		public void StartAutoRefresh(object param)
		{
			bool flag = base.IsVisible() && this._RefreshDataTimerID == 0U;
			if (flag)
			{
				this._RefreshDataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(3f, new XTimerMgr.ElapsedEventHandler(this.AutoRefresh), null);
			}
		}

		// Token: 0x04003EE9 RID: 16105
		private XBattleCaptainPVPDocument _doc = null;

		// Token: 0x04003EEA RID: 16106
		private Vector3 NoVisible = new Vector3(2000f, 0f, 0f);

		// Token: 0x04003EEB RID: 16107
		private uint _StratTimerID = 0U;

		// Token: 0x04003EEC RID: 16108
		private uint _RefreshDataTimerID = 0U;

		// Token: 0x04003EED RID: 16109
		private ulong BlueLeader = 0UL;

		// Token: 0x04003EEE RID: 16110
		private ulong RedLeader = 0UL;

		// Token: 0x04003EEF RID: 16111
		public string picPath = null;

		// Token: 0x04003EF0 RID: 16112
		public IXUILabel m_Leader;

		// Token: 0x04003EF1 RID: 16113
		public IXUILabel m_Blue;

		// Token: 0x04003EF2 RID: 16114
		public IXUILabel m_Red;

		// Token: 0x04003EF3 RID: 16115
		public IXUILabel m_AllEndTime;

		// Token: 0x04003EF4 RID: 16116
		public IXUILabel m_RoundEndTime;

		// Token: 0x04003EF5 RID: 16117
		public IXUILabel m_EndText;

		// Token: 0x04003EF6 RID: 16118
		public IXUILabel m_ReliveTime;

		// Token: 0x04003EF7 RID: 16119
		public IXUITweenTool m_Start;

		// Token: 0x04003EF8 RID: 16120
		public IXUITweenTool m_Relive;

		// Token: 0x04003EF9 RID: 16121
		public IXUITweenTool m_End;

		// Token: 0x04003EFA RID: 16122
		public IXUITexture m_EndIcon;

		// Token: 0x04003EFB RID: 16123
		public IXUISprite m_KillText;

		// Token: 0x04003EFC RID: 16124
		public Transform teamLeader;

		// Token: 0x04003EFD RID: 16125
		public IXUILabel m_BlueLeaderName;

		// Token: 0x04003EFE RID: 16126
		public IXUILabel m_BlueHpPer;

		// Token: 0x04003EFF RID: 16127
		public IXUIProgress m_BlueHpBar;

		// Token: 0x04003F00 RID: 16128
		public IXUILabel m_RedLeaderName;

		// Token: 0x04003F01 RID: 16129
		public IXUILabel m_RedHpPer;

		// Token: 0x04003F02 RID: 16130
		public IXUIProgress m_RedHpBar;

		// Token: 0x04003F03 RID: 16131
		public GameObject m_Win;

		// Token: 0x04003F04 RID: 16132
		public GameObject m_Draw;

		// Token: 0x04003F05 RID: 16133
		public GameObject m_Lose;

		// Token: 0x04003F06 RID: 16134
		public IXUITweenTool[] m_Killicon = new IXUITweenTool[XBattleCaptainPVPDocument.CONTINUOUS_KILL + 1U];

		// Token: 0x04003F07 RID: 16135
		private Vector3 infoDis;

		// Token: 0x04003F08 RID: 16136
		public XUIPool m_ShowIntoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F09 RID: 16137
		public IXUILabel[] m_Killer = new IXUILabel[XBattleCaptainPVPDocument.GAME_INFO];

		// Token: 0x04003F0A RID: 16138
		public IXUILabel[] m_Dead = new IXUILabel[XBattleCaptainPVPDocument.GAME_INFO];

		// Token: 0x04003F0B RID: 16139
		public IXUISprite[] m_InfoIcon = new IXUISprite[XBattleCaptainPVPDocument.GAME_INFO];
	}
}
