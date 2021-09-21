using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001705 RID: 5893
	internal class ActivityGoddessTrialDlg : DlgBase<ActivityGoddessTrialDlg, ActivityGoddessTrialBehaviour>
	{
		// Token: 0x17003774 RID: 14196
		// (get) Token: 0x0600F315 RID: 62229 RVA: 0x0036200C File Offset: 0x0036020C
		public override string fileName
		{
			get
			{
				return "Hall/GoddessTrialDlg";
			}
		}

		// Token: 0x17003775 RID: 14197
		// (get) Token: 0x0600F316 RID: 62230 RVA: 0x00362024 File Offset: 0x00360224
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003776 RID: 14198
		// (get) Token: 0x0600F317 RID: 62231 RVA: 0x00362038 File Offset: 0x00360238
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003777 RID: 14199
		// (get) Token: 0x0600F318 RID: 62232 RVA: 0x0036204C File Offset: 0x0036024C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003778 RID: 14200
		// (get) Token: 0x0600F319 RID: 62233 RVA: 0x00362060 File Offset: 0x00360260
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003779 RID: 14201
		// (get) Token: 0x0600F31A RID: 62234 RVA: 0x00362074 File Offset: 0x00360274
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F31B RID: 62235 RVA: 0x00362087 File Offset: 0x00360287
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this._doc.GoddessTrialView = this;
			this.RefreshTimes();
		}

		// Token: 0x0600F31C RID: 62236 RVA: 0x003620B0 File Offset: 0x003602B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
			base.uiBehaviour.m_goBattleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterTeamClick));
			base.uiBehaviour.m_getBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetReward));
			base.uiBehaviour.m_shopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoToShop));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x0600F31D RID: 62237 RVA: 0x00362158 File Offset: 0x00360358
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_GoddessTrial);
			return true;
		}

		// Token: 0x0600F31E RID: 62238 RVA: 0x0036217B File Offset: 0x0036037B
		protected override void OnShow()
		{
			this.FillItem();
			this.RequstLeftCount();
		}

		// Token: 0x0600F31F RID: 62239 RVA: 0x0036218C File Offset: 0x0036038C
		protected override void OnHide()
		{
			base.uiBehaviour.m_ItemPool.ReturnAll(false);
		}

		// Token: 0x0600F320 RID: 62240 RVA: 0x003621A4 File Offset: 0x003603A4
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

		// Token: 0x0600F321 RID: 62241 RVA: 0x003622D0 File Offset: 0x003604D0
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

		// Token: 0x0600F322 RID: 62242 RVA: 0x00362470 File Offset: 0x00360670
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

		// Token: 0x0600F323 RID: 62243 RVA: 0x0036252C File Offset: 0x0036072C
		private bool OnCloseDlg(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F324 RID: 62244 RVA: 0x00362548 File Offset: 0x00360748
		private bool OnEnterTeamClick(IXUIButton button)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(this._doc.ExpeditionId);
			return true;
		}

		// Token: 0x0600F325 RID: 62245 RVA: 0x00362578 File Offset: 0x00360778
		private bool OnGetReward(IXUIButton button)
		{
			RpcC2G_GetGoddessTrialRewards rpc = new RpcC2G_GetGoddessTrialRewards();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
			return true;
		}

		// Token: 0x0600F326 RID: 62246 RVA: 0x003625A0 File Offset: 0x003607A0
		private bool OnGoToShop(IXUIButton button)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Tear, 0UL);
			return true;
		}

		// Token: 0x0600F327 RID: 62247 RVA: 0x003625C8 File Offset: 0x003607C8
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

		// Token: 0x04006869 RID: 26729
		private XExpeditionDocument _doc;
	}
}
