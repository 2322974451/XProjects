using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BattleCaptainPVPHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "Battle/BattleCaptainPVP";
			}
		}

		public override void RegisterEvent()
		{
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.InitShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._StratTimerID);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._StratTimerID);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
			this._StratTimerID = 0U;
			this._RefreshDataTimerID = 0U;
			this.m_EndIcon.SetTexturePath("");
			base.OnHide();
		}

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

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

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

		public void PlayAudio(int param)
		{
			XSingleton<XAudioMgr>.singleton.PlayUISound(string.Format("Audio/VO/System/system{0}", param), true, AudioChannel.Action);
		}

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

		private void OnEndMoveOver(IXUITweenTool tween)
		{
			this._doc.PlayBigResult();
		}

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

		public void ShowStart()
		{
			this._StratTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this._ShowStart), null);
		}

		private void _ShowStart(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.m_Start.PlayTween(true, -1f);
			}
		}

		private void AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this._doc.ReqBattleCaptainPVPRefreshInfo(false);
				this._RefreshDataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.AutoRefresh), null);
			}
		}

		public void StartAutoRefresh(object param)
		{
			bool flag = base.IsVisible() && this._RefreshDataTimerID == 0U;
			if (flag)
			{
				this._RefreshDataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(3f, new XTimerMgr.ElapsedEventHandler(this.AutoRefresh), null);
			}
		}

		private XBattleCaptainPVPDocument _doc = null;

		private Vector3 NoVisible = new Vector3(2000f, 0f, 0f);

		private uint _StratTimerID = 0U;

		private uint _RefreshDataTimerID = 0U;

		private ulong BlueLeader = 0UL;

		private ulong RedLeader = 0UL;

		public string picPath = null;

		public IXUILabel m_Leader;

		public IXUILabel m_Blue;

		public IXUILabel m_Red;

		public IXUILabel m_AllEndTime;

		public IXUILabel m_RoundEndTime;

		public IXUILabel m_EndText;

		public IXUILabel m_ReliveTime;

		public IXUITweenTool m_Start;

		public IXUITweenTool m_Relive;

		public IXUITweenTool m_End;

		public IXUITexture m_EndIcon;

		public IXUISprite m_KillText;

		public Transform teamLeader;

		public IXUILabel m_BlueLeaderName;

		public IXUILabel m_BlueHpPer;

		public IXUIProgress m_BlueHpBar;

		public IXUILabel m_RedLeaderName;

		public IXUILabel m_RedHpPer;

		public IXUIProgress m_RedHpBar;

		public GameObject m_Win;

		public GameObject m_Draw;

		public GameObject m_Lose;

		public IXUITweenTool[] m_Killicon = new IXUITweenTool[XBattleCaptainPVPDocument.CONTINUOUS_KILL + 1U];

		private Vector3 infoDis;

		public XUIPool m_ShowIntoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel[] m_Killer = new IXUILabel[XBattleCaptainPVPDocument.GAME_INFO];

		public IXUILabel[] m_Dead = new IXUILabel[XBattleCaptainPVPDocument.GAME_INFO];

		public IXUISprite[] m_InfoIcon = new IXUISprite[XBattleCaptainPVPDocument.GAME_INFO];
	}
}
