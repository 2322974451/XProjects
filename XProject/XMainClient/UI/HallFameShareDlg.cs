using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200177E RID: 6014
	internal class HallFameShareDlg : DlgBase<HallFameShareDlg, HallFameShareBehavior>
	{
		// Token: 0x17003830 RID: 14384
		// (get) Token: 0x0600F83A RID: 63546 RVA: 0x0038B65C File Offset: 0x0038985C
		public override string fileName
		{
			get
			{
				return "GameSystem/HallFameShareDlg";
			}
		}

		// Token: 0x17003831 RID: 14385
		// (get) Token: 0x0600F83B RID: 63547 RVA: 0x0038B674 File Offset: 0x00389874
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003832 RID: 14386
		// (get) Token: 0x0600F83C RID: 63548 RVA: 0x0038B688 File Offset: 0x00389888
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003833 RID: 14387
		// (get) Token: 0x0600F83D RID: 63549 RVA: 0x0038B69C File Offset: 0x0038989C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F83E RID: 63550 RVA: 0x0038B6AF File Offset: 0x003898AF
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600F83F RID: 63551 RVA: 0x0038B6C0 File Offset: 0x003898C0
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.ShareBtn.SetAlpha(1f);
			this.ShowMainRoleAvatar();
			this.UpdateRoleDetail();
			this.PlayVictoryAction();
		}

		// Token: 0x0600F840 RID: 63552 RVA: 0x0038B6F8 File Offset: 0x003898F8
		private void PlayVictoryAction()
		{
			float interval = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Disappear);
			this.m_show_time_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.KillDummyTimer), null);
		}

		// Token: 0x0600F841 RID: 63553 RVA: 0x0038B748 File Offset: 0x00389948
		private void UpdateRoleDetail()
		{
			ulong roleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			HallFameRoleInfo roleInfoByRoleID = XHallFameDocument.Doc.GetRoleInfoByRoleID(roleID);
			bool flag = roleInfoByRoleID != null;
			if (flag)
			{
				ArenaStarType curSelectedType = DlgBase<HallFameDlg, HallFameBehavior>.singleton.CurSelectedType;
				string @string = XSingleton<XStringTable>.singleton.GetString(curSelectedType.ToString() + "_Hall_Fame");
				IXUILabel ixuilabel = base.uiBehaviour.RoleName.gameObject.transform.Find("Title").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(@string + XSingleton<XStringTable>.singleton.GetString("SeasonFame"));
				base.uiBehaviour.RoleName.SetText(roleInfoByRoleID.OutLook.name);
				ixuilabel = (base.uiBehaviour.TopTenTimes.gameObject.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(@string + XSingleton<XStringTable>.singleton.GetString("TotalTopTen"));
				base.uiBehaviour.TopTenTimes.SetText(roleInfoByRoleID.hisData.rankTenNum.ToString());
				ixuilabel = (base.uiBehaviour.SeasonSpan.gameObject.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(@string + XSingleton<XStringTable>.singleton.GetString("SeasonTime"));
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(XHallFameDocument.Doc.SeasonBeginTime).ToLocalTime();
				DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(XHallFameDocument.Doc.SeasonEndTime).ToLocalTime();
				base.uiBehaviour.SeasonSpan.SetText(((XHallFameDocument.Doc.SeasonBeginTime == 0UL) ? "--:--" : dateTime.ToString("MM.dd")) + "_" + ((XHallFameDocument.Doc.SeasonEndTime == 0UL) ? "--:--" : dateTime2.ToString("MM.dd")));
				ixuilabel = (base.uiBehaviour.ChampionTimes.gameObject.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(@string + XSingleton<XStringTable>.singleton.GetString("TotalTopOne"));
				base.uiBehaviour.ChampionTimes.SetText(roleInfoByRoleID.hisData.rankOneNum.ToString());
				string text = (roleInfoByRoleID.hisData.rankRecent.Count == 0) ? "" : roleInfoByRoleID.hisData.rankRecent[0].rank.ToString();
				for (int i = 1; i < roleInfoByRoleID.hisData.rankRecent.Count; i++)
				{
					uint num = roleInfoByRoleID.hisData.rankRecent[i].rank;
					num = ((num == uint.MaxValue) ? 0U : num);
					text = text + "/" + num;
				}
				base.uiBehaviour.RecentSeason.SetText(text);
			}
		}

		// Token: 0x0600F842 RID: 63554 RVA: 0x0038BAB4 File Offset: 0x00389CB4
		private void ShowMainRoleAvatar()
		{
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, base.uiBehaviour.uiDummy);
			bool flag = this._roleEffect != null;
			if (flag)
			{
				this._roleEffect.SetActive(true);
			}
		}

		// Token: 0x0600F843 RID: 63555 RVA: 0x0038BAF4 File Offset: 0x00389CF4
		protected override void OnHide()
		{
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			bool flag = this._roleEffect != null;
			if (flag)
			{
				this._roleEffect.SetActive(false);
			}
			this.KillTimer();
			XSingleton<X3DAvatarMgr>.singleton.ResetMainAnimation();
			base.OnHide();
		}

		// Token: 0x0600F844 RID: 63556 RVA: 0x0038BB44 File Offset: 0x00389D44
		protected override void OnUnload()
		{
			bool flag = this._roleEffect != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._roleEffect, true);
				this._roleEffect = null;
			}
			this.KillTimer();
			XSingleton<X3DAvatarMgr>.singleton.ResetMainAnimation();
			base.OnUnload();
		}

		// Token: 0x0600F845 RID: 63557 RVA: 0x0038BB94 File Offset: 0x00389D94
		private void InitProperties()
		{
			base.uiBehaviour.ShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickToShare));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickToClose));
			this._roleEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_HallFameDlg_fx02", null, true);
			this._roleEffect.SetActive(false);
			this._roleEffect.SetParent(base.uiBehaviour.ParticleHanging);
		}

		// Token: 0x0600F846 RID: 63558 RVA: 0x0038BC18 File Offset: 0x00389E18
		private bool ClickToClose(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F847 RID: 63559 RVA: 0x0038BC34 File Offset: 0x00389E34
		private bool ClickToShare(IXUIButton button)
		{
			bool flag = XSingleton<UiUtility>.singleton.CheckPlatfomStatus();
			if (flag)
			{
				base.uiBehaviour.ShareBtn.SetAlpha(0f);
				XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.ShowGlory);
				XSingleton<XScreenShotMgr>.singleton.StartExternalScreenShotView(new ScreenShotCallback(this.ShareSuccess));
			}
			return true;
		}

		// Token: 0x0600F848 RID: 63560 RVA: 0x0038BC94 File Offset: 0x00389E94
		private void ShareSuccess(bool succ)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ShareSuccess", null, null, null, null, null);
			bool flag = base.IsVisible();
			if (flag)
			{
				base.uiBehaviour.ShareBtn.SetAlpha(1f);
				this.SetVisible(false, true);
			}
		}

		// Token: 0x0600F849 RID: 63561 RVA: 0x0038BCE4 File Offset: 0x00389EE4
		private void KillDummyTimer(object sender)
		{
			this.KillTimer();
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Present != null;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
			}
		}

		// Token: 0x0600F84A RID: 63562 RVA: 0x0038BD42 File Offset: 0x00389F42
		private void KillTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			this.m_show_time_token = 0U;
		}

		// Token: 0x04006C55 RID: 27733
		private XFx _roleEffect;

		// Token: 0x04006C56 RID: 27734
		private uint m_show_time_token = 0U;
	}
}
