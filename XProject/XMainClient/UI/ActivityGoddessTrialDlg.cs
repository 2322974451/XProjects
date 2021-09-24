using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ActivityGoddessTrialDlg : DlgBase<ActivityGoddessTrialDlg, ActivityGoddessTrialBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Hall/GoddessTrialDlg";
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

		public override bool hideMainMenu
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

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this._doc.GoddessTrialView = this;
			this.RefreshTimes();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
			base.uiBehaviour.m_goBattleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterTeamClick));
			base.uiBehaviour.m_getBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetReward));
			base.uiBehaviour.m_shopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoToShop));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_GoddessTrial);
			return true;
		}

		protected override void OnShow()
		{
			this.FillItem();
			this.RequstLeftCount();
		}

		protected override void OnHide()
		{
			base.uiBehaviour.m_ItemPool.ReturnAll(false);
		}

		private void FillItem()
		{
			base.uiBehaviour.m_ItemPool.ReturnAll(false);
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("GoddessTrialRewards", true);
			float num = (float)((int)(-(int)(sequenceList.Count - 1)) * base.uiBehaviour.m_ItemPool.TplWidth / 2);
			for (int i = 0; i < (int)sequenceList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3(num + (float)(i * base.uiBehaviour.m_ItemPool.TplWidth), 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, sequenceList[i, 0], sequenceList[i, 1], false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)sequenceList[i, 0]);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowTip));
			}
		}

		public void RefreshTimes()
		{
			bool flag = this._doc == null || !base.IsVisible();
			if (!flag)
			{
				int dayCount = this._doc.GetDayCount(TeamLevelType.TeamLevelGoddessTrial, null);
				int dayMaxCount = this._doc.GetDayMaxCount(TeamLevelType.TeamLevelGoddessTrial, null);
				base.uiBehaviour.m_canJoinTimeslab.SetText(string.Format("{0}/{1}", dayCount, dayMaxCount));
				bool flag2 = dayCount > 0;
				base.uiBehaviour.m_goBattleBtn.SetVisible(flag2);
				base.uiBehaviour.m_noTimesGo.SetActive(!flag2);
				base.uiBehaviour.m_hadGetGo.SetActive(false);
				int goddessRewardsCanGetTimes = this._doc.GoddessRewardsCanGetTimes;
				bool flag3 = goddessRewardsCanGetTimes > 0;
				if (flag3)
				{
					base.uiBehaviour.m_getBtn.SetVisible(true);
					base.uiBehaviour.m_NeedTimesLab.SetVisible(false);
				}
				else
				{
					bool flag4 = dayCount > 0;
					if (flag4)
					{
						int num = dayMaxCount - dayCount;
						int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GoddessTrialNeedJoinTimes");
						base.uiBehaviour.m_getBtn.SetVisible(false);
						base.uiBehaviour.m_NeedTimesLab.SetVisible(true);
						base.uiBehaviour.m_NeedTimesLab.SetText(string.Format(XStringDefineProxy.GetString("GODDESSTRIAL_NEEDFIGHT_TIMES"), @int - num % @int));
					}
					else
					{
						base.uiBehaviour.m_getBtn.SetVisible(false);
						base.uiBehaviour.m_NeedTimesLab.SetVisible(false);
						base.uiBehaviour.m_hadGetGo.SetActive(true);
					}
				}
			}
		}

		private void RequstLeftCount()
		{
			List<ExpeditionTable.RowData> expeditionList = this._doc.GetExpeditionList(TeamLevelType.TeamLevelGoddessTrial);
			bool flag = expeditionList != null && expeditionList.Count > 0;
			if (flag)
			{
				XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
				for (int i = 0; i < expeditionList.Count; i++)
				{
					bool flag2 = specificDocument.SealType == expeditionList[i].LevelSealType;
					if (flag2)
					{
						this._doc.ExpeditionId = expeditionList[i].DNExpeditionID;
						XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
						specificDocument2.ReqTeamOp(TeamOperate.TEAM_QUERYCOUNT, 0UL, null, TeamMemberType.TMT_NORMAL, null);
						return;
					}
				}
			}
			XSingleton<XDebug>.singleton.AddLog("Df data is error,not find target DATA!", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		private bool OnCloseDlg(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnEnterTeamClick(IXUIButton button)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(this._doc.ExpeditionId);
			return true;
		}

		private bool OnGetReward(IXUIButton button)
		{
			RpcC2G_GetGoddessTrialRewards rpc = new RpcC2G_GetGoddessTrialRewards();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
			return true;
		}

		private bool OnGoToShop(IXUIButton button)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Tear, 0UL);
			return true;
		}

		private void ShowTip(IXUISprite sp)
		{
			bool flag = this._doc.GoddessRewardsCanGetTimes > 0;
			if (flag)
			{
				this.OnGetReward(null);
			}
			else
			{
				XSingleton<UiUtility>.singleton.OnItemClick(sp);
			}
		}

		private XExpeditionDocument _doc;
	}
}
