using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001793 RID: 6035
	internal class HeroBattleMVPDlg : DlgBase<HeroBattleMVPDlg, HeroBattleMVPBehaviour>
	{
		// Token: 0x1700384D RID: 14413
		// (get) Token: 0x0600F942 RID: 63810 RVA: 0x00393380 File Offset: 0x00391580
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700384E RID: 14414
		// (get) Token: 0x0600F943 RID: 63811 RVA: 0x00393394 File Offset: 0x00391594
		public override string fileName
		{
			get
			{
				return "GameSystem/HeroBattleMVPDlg";
			}
		}

		// Token: 0x0600F944 RID: 63812 RVA: 0x003933AB File Offset: 0x003915AB
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
		}

		// Token: 0x0600F945 RID: 63813 RVA: 0x003933C8 File Offset: 0x003915C8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_ShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareBtnClick));
		}

		// Token: 0x0600F946 RID: 63814 RVA: 0x00393418 File Offset: 0x00391618
		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
			float interval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleMvpAutoEnd"));
			this._miniCloseTime = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleMvpEnd"));
			this._signTime = Time.time;
			this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.AutoClose), null);
		}

		// Token: 0x0600F947 RID: 63815 RVA: 0x0039348C File Offset: 0x0039168C
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

		// Token: 0x0600F948 RID: 63816 RVA: 0x00393645 File Offset: 0x00391845
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
		}

		// Token: 0x0600F949 RID: 63817 RVA: 0x00393660 File Offset: 0x00391860
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F94A RID: 63818 RVA: 0x0039366C File Offset: 0x0039186C
		private void AutoClose(object o = null)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.OnCloseBtnClick(null);
			}
		}

		// Token: 0x0600F94B RID: 63819 RVA: 0x0039368C File Offset: 0x0039188C
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

		// Token: 0x0600F94C RID: 63820 RVA: 0x003936D8 File Offset: 0x003918D8
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

		// Token: 0x04006CD6 RID: 27862
		private XLevelRewardDocument _doc = null;

		// Token: 0x04006CD7 RID: 27863
		private uint _timerToken;

		// Token: 0x04006CD8 RID: 27864
		private float _signTime;

		// Token: 0x04006CD9 RID: 27865
		private float _miniCloseTime;
	}
}
