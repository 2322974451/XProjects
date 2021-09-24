using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HeroBattleMVPDlg : DlgBase<HeroBattleMVPDlg, HeroBattleMVPBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/HeroBattleMVPDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_ShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
			float interval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleMvpAutoEnd"));
			this._miniCloseTime = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleMvpEnd"));
			this._signTime = Time.time;
			this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.AutoClose), null);
		}

		public void Refresh()
		{
			base.uiBehaviour.LogoDN.SetActive(false);
			base.uiBehaviour.LogoTX.SetActive(false);
			base.uiBehaviour.LogoWC.SetActive(false);
			base.uiBehaviour.LogoQQ.SetActive(false);
			XLevelRewardDocument.HeroBattleData heroBattleData = (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE) ? this._doc.HeroData : this._doc.MobaData;
			base.uiBehaviour.m_ShareBtn.SetVisible(heroBattleData.MvpData.uID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
			base.uiBehaviour.m_Name.SetText(heroBattleData.MvpData.Name);
			base.uiBehaviour.m_Kill.SetText(heroBattleData.MvpData.KillCount.ToString());
			base.uiBehaviour.m_Death.SetText(heroBattleData.MvpData.DeathCount.ToString());
			base.uiBehaviour.m_Assit.SetText(heroBattleData.MvpData.AssitCount.ToString());
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			OverWatchTable.RowData byHeroID = specificDocument.OverWatchReader.GetByHeroID(heroBattleData.MvpHeroID);
			bool flag = byHeroID == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find overwatch data in HeroMvpDlg by heroID = ", heroBattleData.MvpHeroID.ToString(), null, null, null, null);
			}
			else
			{
				base.uiBehaviour.m_HeroName.SetText(byHeroID.Name);
				base.uiBehaviour.m_HeroDesc.SetText(byHeroID.Description);
				base.uiBehaviour.m_HeroSay.SetText(byHeroID.Motto);
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		private void AutoClose(object o = null)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.OnCloseBtnClick(null);
			}
		}

		private void OnCloseBtnClick(IXUISprite iSp)
		{
			bool flag = Time.time - this._signTime < this._miniCloseTime;
			if (!flag)
			{
				this._signTime = Time.time;
				XSingleton<XCutScene>.singleton.Stop(true);
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.CutSceneShowEnd();
			}
		}

		private bool OnShareBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_ShareBtn.SetAlpha(0f);
			base.uiBehaviour.LogoDN.SetActive(true);
			base.uiBehaviour.LogoTX.SetActive(true);
			base.uiBehaviour.LogoWC.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat);
			base.uiBehaviour.LogoQQ.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ);
			XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.WeekShare;
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.ShowGlory);
			XSingleton<XScreenShotMgr>.singleton.StartExternalScreenShotView(null);
			return true;
		}

		private XLevelRewardDocument _doc = null;

		private uint _timerToken;

		private float _signTime;

		private float _miniCloseTime;
	}
}
