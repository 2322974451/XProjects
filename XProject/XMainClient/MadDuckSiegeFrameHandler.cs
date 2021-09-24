using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MadDuckSiegeFrameHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "GameSystem/ThemeActivity/MadDuckSiegeFrame";
			}
		}

		public override void RegisterEvent()
		{
			this.m_Reward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardOpenClick));
			this.m_Join.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClick));
			this.m_Help.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClicked));
		}

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

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<ActivityExchangeRewardHandler>(ref this.m_ActivityExchangeRewardHandler);
			base.OnUnload();
		}

		private void InitShow()
		{
		}

		private void OnHelpClicked(IXUISprite btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(this.doc.sys);
		}

		private bool OnRewardOpenClick(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<ActivityExchangeRewardHandler>(ref this.m_ActivityExchangeRewardHandler, base.transform.Find("Bg"), true, this);
			List<SuperActivityTask.RowData> actTask = this.doc.ActTask;
			this.m_ActivityExchangeRewardHandler.SetActID(this.doc.ActInfo.actid);
			this.m_ActivityExchangeRewardHandler.SetData(actTask);
			return true;
		}

		private bool OnJoinClick(IXUIButton btn)
		{
			this.doc.ActDoc.SendJoinScene(this.doc.ActInfo.actid, this.doc.sceneID);
			return true;
		}

		private MadDuckSiegeDocument doc = null;

		public ActivityExchangeRewardHandler m_ActivityExchangeRewardHandler;

		private IXUISprite m_Help;

		private IXUILabel m_HelpTip;

		private IXUIButton m_Reward;

		private IXUIButton m_Join;

		private Transform m_JoinRedPoint;

		private IXUILabel m_Time;

		private Transform m_Cost;
	}
}
