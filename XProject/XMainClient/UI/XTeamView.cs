using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamView : TabDlgBase<XTeamView>
	{

		public override string fileName
		{
			get
			{
				return "Team/TeamDlg";
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
				return 0;
			}
		}

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

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XMyTeamHandler>(ref this._MyTeamHandler);
			DlgHandlerBase.EnsureUnload<XTeamListHandler>(ref this._TeamListHandler);
			DlgHandlerBase.EnsureUnload<XTeamDungeonSelectorHandler>(ref this._DungeonSelectorHandler);
			DlgHandlerBase.EnsureUnload<XYuyinView>(ref this._yuyinHandler);
			base.OnUnload();
		}

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

		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
		}

		public void RefreshYuyin(ulong uid)
		{
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Refresh(YuyinIconType.Team);
			}
		}

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

		private bool _ShowTeamViewBuyTimes(IXUIButton btn)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			specificDocument.ReqBuyCount(this.mCurTeamLeveltype);
			this._ShowTeamViewNotBuyTimes(btn);
			return true;
		}

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

		protected bool _CancelShowTeamView(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.mShowTeamViewEvent = null;
			return true;
		}

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

		public override void StackRefresh()
		{
			bool flag = (this._doc.bInTeam && this.mCurrentSys != XSysDefine.XSys_Team_MyTeam) || (!this._doc.bInTeam && this.mCurrentSys != XSysDefine.XSys_Team_TeamList);
			if (flag)
			{
				this.ShowTeamView();
			}
			base.StackRefresh();
		}

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

		public XMyTeamHandler _MyTeamHandler;

		public XTeamListHandler _TeamListHandler;

		public XTeamDungeonSelectorHandler _DungeonSelectorHandler;

		public XYuyinView _yuyinHandler;

		public GameObject m_MyTeamPanel;

		public GameObject m_TeamListPanel;

		public GameObject m_DungeonSelectorPanel;

		private XTeamDocument _doc;

		private XTeamView.ShowTeamViewEventHandler mShowTeamViewEvent;

		private TeamLevelType mCurTeamLeveltype = TeamLevelType.TeamLevelNest;

		public delegate void ShowTeamViewEventHandler();
	}
}
