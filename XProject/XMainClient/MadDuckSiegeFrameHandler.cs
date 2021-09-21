using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C77 RID: 3191
	internal class MadDuckSiegeFrameHandler : DlgHandlerBase
	{
		// Token: 0x0600B45F RID: 46175 RVA: 0x002338C0 File Offset: 0x00231AC0
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<MadDuckSiegeDocument>(MadDuckSiegeDocument.uuID);
			Transform transform = base.transform.Find("Bg");
			this.m_Help = (transform.Find("Help").GetComponent("XUISprite") as IXUISprite);
			this.m_HelpTip = (transform.Find("Help/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Reward = (transform.Find("Reward").GetComponent("XUIButton") as IXUIButton);
			this.m_Join = (transform.Find("Join").GetComponent("XUIButton") as IXUIButton);
			this.m_JoinRedPoint = transform.Find("Join/RedPoint");
			this.m_Time = (transform.Find("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_Cost = transform.Find("Item");
			this.InitShow();
		}

		// Token: 0x170031F1 RID: 12785
		// (get) Token: 0x0600B460 RID: 46176 RVA: 0x002339C0 File Offset: 0x00231BC0
		protected override string FileName
		{
			get
			{
				return "GameSystem/ThemeActivity/MadDuckSiegeFrame";
			}
		}

		// Token: 0x0600B461 RID: 46177 RVA: 0x002339D8 File Offset: 0x00231BD8
		public override void RegisterEvent()
		{
			this.m_Reward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardOpenClick));
			this.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClick));
			this.m_Help.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x0600B462 RID: 46178 RVA: 0x00233A30 File Offset: 0x00231C30
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_Cost.gameObject, int.Parse(this.doc.cost[0]), int.Parse(this.doc.cost[1]), true);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(this.m_Cost.gameObject, int.Parse(this.doc.cost[0]));
			XTempActivityDocument specificDocument = XDocuments.GetSpecificDocument<XTempActivityDocument>(XTempActivityDocument.uuID);
			DateTime endTime = specificDocument.GetEndTime(this.doc.ActInfo, -1);
			string arg = string.Format(XStringDefineProxy.GetString("CAREER_GROWTH_PROCESS_TIME"), this.doc.ActInfo.starttime / 10000U, this.doc.ActInfo.starttime % 10000U / 100U, this.doc.ActInfo.starttime % 100U);
			string arg2 = string.Format(XStringDefineProxy.GetString("CAREER_GROWTH_PROCESS_TIME"), endTime.Year, endTime.Month, endTime.Day);
			this.m_Time.SetText(string.Format("{0} ~ {1}", arg, arg2));
			this.m_HelpTip.SetText(XStringDefineProxy.GetString("MAD_DUCK_TIPS"));
			this.m_JoinRedPoint.gameObject.SetActive(this.doc.GetRedPoint());
		}

		// Token: 0x0600B463 RID: 46179 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B464 RID: 46180 RVA: 0x00233BAF File Offset: 0x00231DAF
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ActivityExchangeRewardHandler>(ref this.m_ActivityExchangeRewardHandler);
			base.OnUnload();
		}

		// Token: 0x0600B465 RID: 46181 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void InitShow()
		{
		}

		// Token: 0x0600B466 RID: 46182 RVA: 0x00233BC5 File Offset: 0x00231DC5
		private void OnHelpClicked(IXUISprite btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(this.doc.sys);
		}

		// Token: 0x0600B467 RID: 46183 RVA: 0x00233BE0 File Offset: 0x00231DE0
		private bool OnRewardOpenClick(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<ActivityExchangeRewardHandler>(ref this.m_ActivityExchangeRewardHandler, base.transform.Find("Bg"), true, this);
			List<SuperActivityTask.RowData> actTask = this.doc.ActTask;
			this.m_ActivityExchangeRewardHandler.SetActID(this.doc.ActInfo.actid);
			this.m_ActivityExchangeRewardHandler.SetData(actTask);
			return true;
		}

		// Token: 0x0600B468 RID: 46184 RVA: 0x00233C48 File Offset: 0x00231E48
		private bool OnJoinClick(IXUIButton btn)
		{
			this.doc.ActDoc.SendJoinScene(this.doc.ActInfo.actid, this.doc.sceneID);
			return true;
		}

		// Token: 0x040045F7 RID: 17911
		private MadDuckSiegeDocument doc = null;

		// Token: 0x040045F8 RID: 17912
		public ActivityExchangeRewardHandler m_ActivityExchangeRewardHandler;

		// Token: 0x040045F9 RID: 17913
		private IXUISprite m_Help;

		// Token: 0x040045FA RID: 17914
		private IXUILabel m_HelpTip;

		// Token: 0x040045FB RID: 17915
		private IXUIButton m_Reward;

		// Token: 0x040045FC RID: 17916
		private IXUIButton m_Join;

		// Token: 0x040045FD RID: 17917
		private Transform m_JoinRedPoint;

		// Token: 0x040045FE RID: 17918
		private IXUILabel m_Time;

		// Token: 0x040045FF RID: 17919
		private Transform m_Cost;
	}
}
