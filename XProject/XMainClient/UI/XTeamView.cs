using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018C1 RID: 6337
	internal class XTeamView : TabDlgBase<XTeamView>
	{
		// Token: 0x17003A48 RID: 14920
		// (get) Token: 0x06010863 RID: 67683 RVA: 0x0040DE8C File Offset: 0x0040C08C
		public override string fileName
		{
			get
			{
				return "Team/TeamDlg";
			}
		}

		// Token: 0x17003A49 RID: 14921
		// (get) Token: 0x06010864 RID: 67684 RVA: 0x0040DEA4 File Offset: 0x0040C0A4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A4A RID: 14922
		// (get) Token: 0x06010865 RID: 67685 RVA: 0x0040DEB8 File Offset: 0x0040C0B8
		public override int group
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06010866 RID: 67686 RVA: 0x0040DECC File Offset: 0x0040C0CC
		protected override void OnLoad()
		{
			base.OnLoad();
			this.m_MyTeamPanel = base.uiBehaviour.transform.FindChild("Bg/MyTeamFrame").gameObject;
			this.m_MyTeamPanel.SetActive(false);
			this.m_TeamListPanel = base.uiBehaviour.transform.FindChild("Bg/TeamListFrame").gameObject;
			this.m_TeamListPanel.SetActive(false);
			this.m_DungeonSelectorPanel = base.uiBehaviour.transform.FindChild("Bg/SelectFrame").gameObject;
			this.m_DungeonSelectorPanel.SetActive(false);
			this._doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
		}

		// Token: 0x06010867 RID: 67687 RVA: 0x0040DF78 File Offset: 0x0040C178
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XMyTeamHandler>(ref this._MyTeamHandler);
			DlgHandlerBase.EnsureUnload<XTeamListHandler>(ref this._TeamListHandler);
			DlgHandlerBase.EnsureUnload<XTeamDungeonSelectorHandler>(ref this._DungeonSelectorHandler);
			DlgHandlerBase.EnsureUnload<XYuyinView>(ref this._yuyinHandler);
			base.OnUnload();
		}

		// Token: 0x06010868 RID: 67688 RVA: 0x0040DFB4 File Offset: 0x0040C1B4
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			this._doc.ReqSceneDayCount();
			RpcC2G_GetTowerActivityTop rpc = new RpcC2G_GetTowerActivityTop();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
			XDragonNestDocument specificDocument = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
			specificDocument.SendReqDragonNestInfo();
			XGuildSmallMonsterDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
			specificDocument2.SendQuerySmallMonterInfo();
			bool flag = DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsLoaded() && DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(false, true);
			}
			DlgBase<RandomGiftView, RandomGiftBehaviour>.singleton.TryOpenUI();
		}

		// Token: 0x06010869 RID: 67689 RVA: 0x0040E052 File Offset: 0x0040C252
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
		}

		// Token: 0x0601086A RID: 67690 RVA: 0x0040E05C File Offset: 0x0040C25C
		public void RefreshYuyin(ulong uid)
		{
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Refresh(YuyinIconType.Team);
			}
		}

		// Token: 0x0601086B RID: 67691 RVA: 0x0040E088 File Offset: 0x0040C288
		public void ShowTeamView()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_FAMILYGARDEN;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CurSceneCanNotCtrl"), "fece00");
			}
			else
			{
				base.Load();
				bool flag2 = !base.IsVisible();
				if (flag2)
				{
					bool bInTeam = this._doc.bInTeam;
					if (bInTeam)
					{
						base.ShowWorkGameSystem(XSysDefine.XSys_Team_MyTeam);
					}
					else
					{
						base.ShowWorkGameSystem(XSysDefine.XSys_Team_TeamList);
					}
				}
				else
				{
					bool bInTeam2 = this._doc.bInTeam;
					if (bInTeam2)
					{
						base.ShowSubGamsSystem(XSysDefine.XSys_Team_MyTeam);
					}
					else
					{
						base.ShowSubGamsSystem(XSysDefine.XSys_Team_TeamList);
					}
				}
				bool bInTeam3 = this._doc.bInTeam;
				if (bInTeam3)
				{
					this._yuyinHandler.Show(YuyinIconType.Team, 5);
					this._yuyinHandler.Show(this._doc.bInTeam);
				}
			}
		}

		// Token: 0x0601086C RID: 67692 RVA: 0x0040E170 File Offset: 0x0040C370
		public void ShowTeamViewWithMsgBox(TeamLevelType _type, XTeamView.ShowTeamViewEventHandler _cbRealShow)
		{
			int dayLeftCount = ActivityNestHandler.GetDayLeftCount();
			this.mCurTeamLeveltype = _type;
			this.mShowTeamViewEvent = _cbRealShow;
			bool flag = dayLeftCount > 0;
			if (flag)
			{
				bool flag2 = _cbRealShow != null;
				if (flag2)
				{
					_cbRealShow();
				}
			}
			else
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				int num;
				int num2;
				bool flag3 = specificDocument.CanBuy(_type, out num, out num2);
				ButtonClickEventHandler handle;
				ButtonClickEventHandler handle2;
				string @string;
				if (flag3)
				{
					handle = new ButtonClickEventHandler(this._ShowTeamViewBuyTimes);
					handle2 = new ButtonClickEventHandler(this._ShowTeamViewNotBuyTimes);
					CostInfo buyCost = specificDocument.GetBuyCost(_type);
					@string = XStringDefineProxy.GetString("NEST_NO_TIMES_NEED_BUY_MSGBOX", new object[]
					{
						XLabelSymbolHelper.FormatCostWithIcon((int)buyCost.count, buyCost.type)
					});
				}
				else
				{
					handle = new ButtonClickEventHandler(this._ShowTeamViewNotBuyTimes);
					handle2 = new ButtonClickEventHandler(this._CancelShowTeamView);
					@string = XStringDefineProxy.GetString("NEST_NO_TIMES_CANNOT_BUY_MSGBOX");
				}
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(handle, handle2);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTweenTargetAndPlay(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.gameObject);
			}
		}

		// Token: 0x0601086D RID: 67693 RVA: 0x0040E2B0 File Offset: 0x0040C4B0
		private bool _ShowTeamViewBuyTimes(IXUIButton btn)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			specificDocument.ReqBuyCount(this.mCurTeamLeveltype);
			this._ShowTeamViewNotBuyTimes(btn);
			return true;
		}

		// Token: 0x0601086E RID: 67694 RVA: 0x0040E2E4 File Offset: 0x0040C4E4
		private bool _ShowTeamViewNotBuyTimes(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = this.mShowTeamViewEvent != null;
			if (flag)
			{
				this.mShowTeamViewEvent();
			}
			this.mShowTeamViewEvent = null;
			return true;
		}

		// Token: 0x0601086F RID: 67695 RVA: 0x0040E324 File Offset: 0x0040C524
		protected bool _CancelShowTeamView(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.mShowTeamViewEvent = null;
			return true;
		}

		// Token: 0x06010870 RID: 67696 RVA: 0x0040E34C File Offset: 0x0040C54C
		public override void SetupHandlers(XSysDefine sys)
		{
			XSysDefine xsysDefine = sys;
			if (xsysDefine != XSysDefine.XSys_Team_TeamList)
			{
				if (xsysDefine != XSysDefine.XSys_Team_MyTeam)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
				}
				else
				{
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XMyTeamHandler>(ref this._MyTeamHandler, this.m_MyTeamPanel, this, true));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XTeamDungeonSelectorHandler>(ref this._DungeonSelectorHandler, this.m_DungeonSelectorPanel, this, true));
					base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, base.uiBehaviour.transform, true, this));
				}
			}
			else
			{
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XTeamListHandler>(ref this._TeamListHandler, this.m_TeamListPanel, this, true));
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XTeamDungeonSelectorHandler>(ref this._DungeonSelectorHandler, this.m_DungeonSelectorPanel, this, true));
			}
		}

		// Token: 0x06010871 RID: 67697 RVA: 0x0040E428 File Offset: 0x0040C628
		public override void StackRefresh()
		{
			bool flag = (this._doc.bInTeam && this.mCurrentSys != XSysDefine.XSys_Team_MyTeam) || (!this._doc.bInTeam && this.mCurrentSys != XSysDefine.XSys_Team_TeamList);
			if (flag)
			{
				this.ShowTeamView();
			}
			base.StackRefresh();
		}

		// Token: 0x06010872 RID: 67698 RVA: 0x0040E488 File Offset: 0x0040C688
		public static void TryJoinTeam(int teamID, bool bHasPwd)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			if (bHasPwd)
			{
				DlgBase<XTeamInputPasswordView, XTeamInputPasswordBehaviour>.singleton.TeamID = teamID;
				DlgBase<XTeamInputPasswordView, XTeamInputPasswordBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
			else
			{
				specificDocument.ReqTeamOp(TeamOperate.TEAM_JOIN, (ulong)((long)teamID), null, TeamMemberType.TMT_NORMAL, null);
			}
		}

		// Token: 0x06010873 RID: 67699 RVA: 0x0040E4D4 File Offset: 0x0040C6D4
		public static void SetTeamRelationUI(Transform t, XTeamRelation relation, bool bOnlyOne, XTeamRelation.Relation targetRelation = XTeamRelation.Relation.TR_NONE)
		{
			bool flag = t == null;
			if (!flag)
			{
				IXUIList ixuilist = t.GetComponent("XUIList") as IXUIList;
				Transform transform = t.Find("Guild");
				Transform transform2 = t.Find("Friend");
				Transform transform3 = t.Find("Partner");
				bool flag2 = true;
				bool flag3 = relation == null;
				if (!flag3)
				{
					bool flag4 = targetRelation > XTeamRelation.Relation.TR_NONE;
					if (flag4)
					{
						bool flag5 = !relation.HasRelation(targetRelation);
						if (flag5)
						{
							goto IL_181;
						}
						XTeamRelation.Relation relation2 = relation.ActualRelation & targetRelation;
						transform.gameObject.SetActive(XTeamRelation.HasRelation(relation2, XTeamRelation.Relation.TR_GUILD));
						transform2.gameObject.SetActive(XTeamRelation.HasRelation(relation2, XTeamRelation.Relation.TR_FRIEND) && !XTeamRelation.HasRelation(relation2, XTeamRelation.Relation.TR_PARTNER));
						transform3.gameObject.SetActive(XTeamRelation.HasRelation(relation2, XTeamRelation.Relation.TR_PARTNER));
					}
					else
					{
						bool flag6 = !bOnlyOne;
						if (flag6)
						{
							transform.gameObject.SetActive(XTeamRelation.HasRelation(relation.FinalRelation2, XTeamRelation.Relation.TR_GUILD));
							transform2.gameObject.SetActive(XTeamRelation.HasRelation(relation.FinalRelation2, XTeamRelation.Relation.TR_FRIEND));
							transform3.gameObject.SetActive(XTeamRelation.HasRelation(relation.FinalRelation, XTeamRelation.Relation.TR_PARTNER));
						}
						else
						{
							transform.gameObject.SetActive(relation.FinalRelation == XTeamRelation.Relation.TR_GUILD);
							transform2.gameObject.SetActive(relation.FinalRelation == XTeamRelation.Relation.TR_FRIEND);
							transform3.gameObject.SetActive(relation.FinalRelation == XTeamRelation.Relation.TR_PARTNER);
						}
					}
					flag2 = false;
				}
				IL_181:
				bool flag7 = flag2;
				if (flag7)
				{
					transform.gameObject.SetActive(false);
					transform2.gameObject.SetActive(false);
					transform3.gameObject.SetActive(false);
				}
				bool flag8 = ixuilist != null;
				if (flag8)
				{
					ixuilist.Refresh();
				}
			}
		}

		// Token: 0x04007798 RID: 30616
		public XMyTeamHandler _MyTeamHandler;

		// Token: 0x04007799 RID: 30617
		public XTeamListHandler _TeamListHandler;

		// Token: 0x0400779A RID: 30618
		public XTeamDungeonSelectorHandler _DungeonSelectorHandler;

		// Token: 0x0400779B RID: 30619
		public XYuyinView _yuyinHandler;

		// Token: 0x0400779C RID: 30620
		public GameObject m_MyTeamPanel;

		// Token: 0x0400779D RID: 30621
		public GameObject m_TeamListPanel;

		// Token: 0x0400779E RID: 30622
		public GameObject m_DungeonSelectorPanel;

		// Token: 0x0400779F RID: 30623
		private XTeamDocument _doc;

		// Token: 0x040077A0 RID: 30624
		private XTeamView.ShowTeamViewEventHandler mShowTeamViewEvent;

		// Token: 0x040077A1 RID: 30625
		private TeamLevelType mCurTeamLeveltype = TeamLevelType.TeamLevelNest;

		// Token: 0x02001A1B RID: 6683
		// (Invoke) Token: 0x06011142 RID: 69954
		public delegate void ShowTeamViewEventHandler();
	}
}
