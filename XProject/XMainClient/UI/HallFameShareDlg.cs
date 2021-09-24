using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HallFameShareDlg : DlgBase<HallFameShareDlg, HallFameShareBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/HallFameShareDlg";
			}
		}

		public override int layer
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

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.ShareBtn.SetAlpha(1f);
			this.ShowMainRoleAvatar();
			this.UpdateRoleDetail();
			this.PlayVictoryAction();
		}

		private void PlayVictoryAction()
		{
			float interval = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Disappear);
			this.m_show_time_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.KillDummyTimer), null);
		}

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

		private void ShowMainRoleAvatar()
		{
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, base.uiBehaviour.uiDummy);
			bool flag = this._roleEffect != null;
			if (flag)
			{
				this._roleEffect.SetActive(true);
			}
		}

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

		private void InitProperties()
		{
			base.uiBehaviour.ShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickToShare));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickToClose));
			this._roleEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_HallFameDlg_fx02", null, true);
			this._roleEffect.SetActive(false);
			this._roleEffect.SetParent(base.uiBehaviour.ParticleHanging);
		}

		private bool ClickToClose(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		private void KillDummyTimer(object sender)
		{
			this.KillTimer();
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Present != null;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
			}
		}

		private void KillTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			this.m_show_time_token = 0U;
		}

		private XFx _roleEffect;

		private uint m_show_time_token = 0U;
	}
}
