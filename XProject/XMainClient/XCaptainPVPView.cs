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

	internal class XCaptainPVPView : DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/CaptainDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
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
			this._doc = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
			this._doc.View = this;
			DlgHandlerBase.EnsureCreate<BattleRecordHandler>(ref this.m_CaptainBattleRecordHandler, base.uiBehaviour.m_BattleRecordFrame, null, false);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_BtnShop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClicked));
			base.uiBehaviour.m_BtnRecord.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRecordClicked));
			base.uiBehaviour.m_BtnStartSingle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartSingleClicked));
			base.uiBehaviour.m_BtnStartTeam.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartTeamClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_CaptainPVP);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.InitShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._DataTimerID);
			this._AutoRefresh(null);
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_CaptainBattleRecordHandler.SetVisible(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._DataTimerID);
			this._DataTimerID = 0U;
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<BattleRecordHandler>(ref this.m_CaptainBattleRecordHandler);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._DataTimerID);
			this._DataTimerID = 0U;
			this._doc.View = null;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

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

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public bool OnRoleClicked(IXUISprite sp)
		{
			return true;
		}

		private bool OnItemListCloseClicked(IXUIButton sp)
		{
			return true;
		}

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

		public bool OnGetWeekRewardClicked(IXUIButton sp)
		{
			bool canGetWeekReward = this._doc.canGetWeekReward;
			if (canGetWeekReward)
			{
				this._doc.ReqGetWeekReward();
			}
			return true;
		}

		private bool OnShopClicked(IXUIButton sp)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mall_Honer, 0UL);
			return true;
		}

		private bool OnRecordClicked(IXUIButton sp)
		{
			this._doc.ReqGetHistory();
			this.m_CaptainBattleRecordHandler.SetupRecord(this._doc.RecordList);
			return true;
		}

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

		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this._doc.ReqGetShowInfo();
				this._DataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(3.1f, new XTimerMgr.ElapsedEventHandler(this._AutoRefresh), null);
			}
		}

		private XCaptainPVPDocument _doc = null;

		public BattleRecordHandler m_CaptainBattleRecordHandler;

		private uint _DataTimerID = 0U;
	}
}
