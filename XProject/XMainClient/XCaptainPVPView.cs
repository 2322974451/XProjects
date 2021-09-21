using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CBB RID: 3259
	internal class XCaptainPVPView : DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>
	{
		// Token: 0x17003267 RID: 12903
		// (get) Token: 0x0600B737 RID: 46903 RVA: 0x00247430 File Offset: 0x00245630
		public override string fileName
		{
			get
			{
				return "GameSystem/CaptainDlg";
			}
		}

		// Token: 0x17003268 RID: 12904
		// (get) Token: 0x0600B738 RID: 46904 RVA: 0x00247448 File Offset: 0x00245648
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003269 RID: 12905
		// (get) Token: 0x0600B739 RID: 46905 RVA: 0x0024745C File Offset: 0x0024565C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700326A RID: 12906
		// (get) Token: 0x0600B73A RID: 46906 RVA: 0x00247470 File Offset: 0x00245670
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700326B RID: 12907
		// (get) Token: 0x0600B73B RID: 46907 RVA: 0x00247484 File Offset: 0x00245684
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700326C RID: 12908
		// (get) Token: 0x0600B73C RID: 46908 RVA: 0x00247498 File Offset: 0x00245698
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700326D RID: 12909
		// (get) Token: 0x0600B73D RID: 46909 RVA: 0x002474AC File Offset: 0x002456AC
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B73E RID: 46910 RVA: 0x002474BF File Offset: 0x002456BF
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
			this._doc.View = this;
			DlgHandlerBase.EnsureCreate<BattleRecordHandler>(ref this.m_CaptainBattleRecordHandler, base.uiBehaviour.m_BattleRecordFrame, null, false);
		}

		// Token: 0x0600B73F RID: 46911 RVA: 0x002474F8 File Offset: 0x002456F8
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_BtnShop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClicked));
			base.uiBehaviour.m_BtnRecord.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRecordClicked));
			base.uiBehaviour.m_BtnStartSingle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartSingleClicked));
			base.uiBehaviour.m_BtnStartTeam.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartTeamClicked));
		}

		// Token: 0x0600B740 RID: 46912 RVA: 0x002475B4 File Offset: 0x002457B4
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_CaptainPVP);
			return true;
		}

		// Token: 0x0600B741 RID: 46913 RVA: 0x002475D7 File Offset: 0x002457D7
		protected override void OnShow()
		{
			base.OnShow();
			this.InitShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._DataTimerID);
			this._AutoRefresh(null);
		}

		// Token: 0x0600B742 RID: 46914 RVA: 0x00247601 File Offset: 0x00245801
		protected override void OnHide()
		{
			base.OnHide();
			this.m_CaptainBattleRecordHandler.SetVisible(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._DataTimerID);
			this._DataTimerID = 0U;
		}

		// Token: 0x0600B743 RID: 46915 RVA: 0x00247630 File Offset: 0x00245830
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<BattleRecordHandler>(ref this.m_CaptainBattleRecordHandler);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._DataTimerID);
			this._DataTimerID = 0U;
			this._doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600B744 RID: 46916 RVA: 0x0024766B File Offset: 0x0024586B
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600B745 RID: 46917 RVA: 0x00247678 File Offset: 0x00245878
		public void RefreshButtonState()
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool flag2 = specificDocument.SoloMatchType == KMatchType.KMT_PVP;
				if (flag2)
				{
					DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_BtnStartSingleLabel.SetText(string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")));
					DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_BtnStartTeam.SetEnable(false, false);
				}
				else
				{
					DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_BtnStartSingleLabel.SetText(string.Format(XStringDefineProxy.GetString("CAPTAINPVP_SINGLE"), new object[0]));
					DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_BtnStartTeam.SetEnable(true, false);
				}
			}
		}

		// Token: 0x0600B746 RID: 46918 RVA: 0x00247738 File Offset: 0x00245938
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B747 RID: 46919 RVA: 0x00247754 File Offset: 0x00245954
		public bool OnRoleClicked(IXUISprite sp)
		{
			return true;
		}

		// Token: 0x0600B748 RID: 46920 RVA: 0x00247768 File Offset: 0x00245968
		private bool OnItemListCloseClicked(IXUIButton sp)
		{
			return true;
		}

		// Token: 0x0600B749 RID: 46921 RVA: 0x0024777C File Offset: 0x0024597C
		private void OnBoxClicked(IXUITexture sp)
		{
			bool canGetWeekReward = this._doc.canGetWeekReward;
			if (canGetWeekReward)
			{
				this._doc.ReqGetWeekReward();
			}
			else
			{
				bool flag = !this._doc.isEmptyBox;
				if (flag)
				{
					this.RefreshWeekReward();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SRS_FETCHED"), "fece00");
				}
			}
		}

		// Token: 0x0600B74A RID: 46922 RVA: 0x002477E4 File Offset: 0x002459E4
		public bool OnGetWeekRewardClicked(IXUIButton sp)
		{
			bool canGetWeekReward = this._doc.canGetWeekReward;
			if (canGetWeekReward)
			{
				this._doc.ReqGetWeekReward();
			}
			return true;
		}

		// Token: 0x0600B74B RID: 46923 RVA: 0x00247814 File Offset: 0x00245A14
		private bool OnShopClicked(IXUIButton sp)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mall_Honer, 0UL);
			return true;
		}

		// Token: 0x0600B74C RID: 46924 RVA: 0x0024783C File Offset: 0x00245A3C
		private bool OnRecordClicked(IXUIButton sp)
		{
			this._doc.ReqGetHistory();
			this.m_CaptainBattleRecordHandler.SetupRecord(this._doc.RecordList);
			return true;
		}

		// Token: 0x0600B74D RID: 46925 RVA: 0x00247874 File Offset: 0x00245A74
		private bool OnStartSingleClicked(IXUIButton sp)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			bool result;
			if (bInTeam)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CAPTAIN_SINGLE_MATCH_TIP"), "fece00");
				result = false;
			}
			else
			{
				KMatchOp op = (specificDocument.SoloMatchType != KMatchType.KMT_PVP) ? KMatchOp.KMATCH_OP_START : KMatchOp.KMATCH_OP_STOP;
				specificDocument.ReqMatchStateChange(KMatchType.KMT_PVP, op, false);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B74E RID: 46926 RVA: 0x002478D8 File Offset: 0x00245AD8
		private bool OnStartTeamClicked(IXUIButton sp)
		{
			this.OnCloseClicked(sp);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelCaptainPVP);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag = expeditionList.Count > 0;
			if (flag)
			{
				specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
			}
			return true;
		}

		// Token: 0x0600B74F RID: 46927 RVA: 0x00247938 File Offset: 0x00245B38
		public void InitShow()
		{
			base.uiBehaviour.m_BattleRecord.SetText("");
			base.uiBehaviour.m_BoxLabel.SetText("0/0");
			base.uiBehaviour.m_MatchNum.SetText("");
			base.uiBehaviour.m_ExRewardLabel.SetText("");
			base.uiBehaviour.m_BtnStartSingleLabel.SetText(string.Format(XStringDefineProxy.GetString("CAPTAINPVP_SINGLE"), new object[0]));
			base.uiBehaviour.m_BtnStartTeam.SetEnable(true, false);
			this.RefreshButtonState();
		}

		// Token: 0x0600B750 RID: 46928 RVA: 0x002479E0 File Offset: 0x00245BE0
		public void RefreshWeekReward()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				int weekWinCount = this._doc.weekWinCount;
				string arg = (weekWinCount == this._doc.weekMax) ? "[00ff37]" : "[ffffff]";
				string text = string.Format("{0}{1}[-]", arg, weekWinCount);
				base.uiBehaviour.m_WeekRewardLabel.SetText(string.Format(XStringDefineProxy.GetString("CAPTAIN_WEEK_REWARD"), this._doc.weekMax, this._doc.weekWinCount, this._doc.weekMax));
				base.uiBehaviour.m_WeekRewardPool.ReturnAll(false);
				string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("PVPWeekRewards").Split(XGlobalConfig.AllSeparators);
				int num = array.Length / 2;
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_WeekRewardPool.FetchGameObject(false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, int.Parse(array[i * 2]), int.Parse(array[i * 2 + 1]), false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject, int.Parse(array[i * 2]));
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					gameObject.transform.localPosition = new Vector3((float)(i * ixuisprite.spriteWidth), 0f, 0f);
					gameObject.transform.Find("HadGet").gameObject.SetActive(this._doc.isEmptyBox);
					IXUIButton ixuibutton = gameObject.transform.Find("GetRewardBtn").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.gameObject.SetActive(this._doc.canGetWeekReward);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetWeekRewardClicked));
				}
			}
		}

		// Token: 0x0600B751 RID: 46929 RVA: 0x00247BE8 File Offset: 0x00245DE8
		public void RefreshExReward(int joinNum, int joinNumMax)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				int num = Math.Max(joinNumMax - joinNum, 0);
				string arg = (num == 0) ? "[ff3e3e]" : "[00ff37]";
				string text = string.Format("{0}{1}[-]", arg, num);
				DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_ExRewardLabel.SetText(string.Format(XStringDefineProxy.GetString("CAPTAINPVP_EXTRA"), new object[]
				{
					XSingleton<XGlobalConfig>.singleton.GetValue("PVPDayOpenTime"),
					joinNumMax.ToString(),
					text,
					joinNumMax.ToString()
				}));
				base.uiBehaviour.m_ExRewardPool.ReturnAll(false);
				string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("PVPDayRewards").Split(XGlobalConfig.AllSeparators);
				int num2 = array.Length / 2;
				for (int i = 0; i < num2; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_ExRewardPool.FetchGameObject(false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, int.Parse(array[i * 2]), int.Parse(array[i * 2 + 1]), false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject, int.Parse(array[i * 2]));
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					gameObject.transform.localPosition = new Vector3((float)(i * ixuisprite.spriteWidth), 0f, 0f);
				}
			}
		}

		// Token: 0x0600B752 RID: 46930 RVA: 0x00247D74 File Offset: 0x00245F74
		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this._doc.ReqGetShowInfo();
				this._DataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(3.1f, new XTimerMgr.ElapsedEventHandler(this._AutoRefresh), null);
			}
		}

		// Token: 0x040047F9 RID: 18425
		private XCaptainPVPDocument _doc = null;

		// Token: 0x040047FA RID: 18426
		public BattleRecordHandler m_CaptainBattleRecordHandler;

		// Token: 0x040047FB RID: 18427
		private uint _DataTimerID = 0U;
	}
}
