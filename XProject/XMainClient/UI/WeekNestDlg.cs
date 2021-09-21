using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017EB RID: 6123
	internal class WeekNestDlg : DlgBase<WeekNestDlg, WeeknestBehaviour>
	{
		// Token: 0x170038BD RID: 14525
		// (get) Token: 0x0600FDC2 RID: 64962 RVA: 0x003B8DC8 File Offset: 0x003B6FC8
		public override string fileName
		{
			get
			{
				return "OperatingActivity/WeekNest";
			}
		}

		// Token: 0x170038BE RID: 14526
		// (get) Token: 0x0600FDC3 RID: 64963 RVA: 0x003B8DE0 File Offset: 0x003B6FE0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170038BF RID: 14527
		// (get) Token: 0x0600FDC4 RID: 64964 RVA: 0x003B8DF4 File Offset: 0x003B6FF4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038C0 RID: 14528
		// (get) Token: 0x0600FDC5 RID: 64965 RVA: 0x003B8E08 File Offset: 0x003B7008
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038C1 RID: 14529
		// (get) Token: 0x0600FDC6 RID: 64966 RVA: 0x003B8E1C File Offset: 0x003B701C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038C2 RID: 14530
		// (get) Token: 0x0600FDC7 RID: 64967 RVA: 0x003B8E30 File Offset: 0x003B7030
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600FDC8 RID: 64968 RVA: 0x003B8E43 File Offset: 0x003B7043
		protected override void Init()
		{
			base.Init();
			this.m_doc = XWeekNestDocument.Doc;
			this.m_doc.View = this;
		}

		// Token: 0x0600FDC9 RID: 64969 RVA: 0x003B8E64 File Offset: 0x003B7064
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_goBattleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoBattleClicked));
			base.uiBehaviour.m_rankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankBtnClicked));
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosed));
		}

		// Token: 0x0600FDCA RID: 64970 RVA: 0x003B8ED0 File Offset: 0x003B70D0
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_GoddessTrial);
			return true;
		}

		// Token: 0x0600FDCB RID: 64971 RVA: 0x003B8EF4 File Offset: 0x003B70F4
		protected override void OnShow()
		{
			this.m_doc.HadRedDot = false;
			base.uiBehaviour.m_tipsLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeekNestTips")));
			this.m_doc.ReqTeamCount();
		}

		// Token: 0x0600FDCC RID: 64972 RVA: 0x003B8F45 File Offset: 0x003B7145
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FDCD RID: 64973 RVA: 0x003B8F4F File Offset: 0x003B714F
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FDCE RID: 64974 RVA: 0x003B8F59 File Offset: 0x003B7159
		protected override void OnUnload()
		{
			base.uiBehaviour.m_bgTexture.SetTexturePath("");
			DlgHandlerBase.EnsureUnload<WeekNestRankHandler>(ref this.m_weekNestRankHandler);
			base.OnUnload();
		}

		// Token: 0x0600FDCF RID: 64975 RVA: 0x003B8F85 File Offset: 0x003B7185
		public void Resfresh()
		{
			this.FillContent();
		}

		// Token: 0x0600FDD0 RID: 64976 RVA: 0x003B8F90 File Offset: 0x003B7190
		private void FillContent()
		{
			XExpeditionDocument xexpeditionDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument;
			ExpeditionTable.RowData expeditionDataByID = xexpeditionDocument.GetExpeditionDataByID(this.m_doc.CurDNid);
			int dayCount = xexpeditionDocument.GetDayCount(TeamLevelType.TeamLevelWeekNest, null);
			int dayMaxCount = xexpeditionDocument.GetDayMaxCount(TeamLevelType.TeamLevelWeekNest, null);
			base.uiBehaviour.m_timesLab.SetText(string.Format("{0}{1}/{2}", XSingleton<XStringTable>.singleton.GetString("WeekNestFight"), dayCount, dayMaxCount));
			this.FillBgTexture();
			bool flag = expeditionDataByID != null;
			if (flag)
			{
				base.uiBehaviour.m_tittleLab.SetText(expeditionDataByID.DNExpeditionName);
				this.FillItem(expeditionDataByID);
			}
		}

		// Token: 0x0600FDD1 RID: 64977 RVA: 0x003B9048 File Offset: 0x003B7248
		private void FillItem(ExpeditionTable.RowData rowData)
		{
			base.uiBehaviour.m_ItemPool.ReturnAll(false);
			bool flag = rowData.ViewableDropList == null || rowData.ViewableDropList.Length == 0;
			if (!flag)
			{
				for (int i = 0; i < rowData.ViewableDropList.Length; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
					gameObject.transform.parent = base.uiBehaviour.m_itemsGo.transform;
					gameObject.name = i.ToString();
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3((float)(base.uiBehaviour.m_ItemPool.TplWidth * i), 0f, 0f);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)rowData.ViewableDropList[i];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)rowData.ViewableDropList[i], 0, false);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
		}

		// Token: 0x0600FDD2 RID: 64978 RVA: 0x003B9184 File Offset: 0x003B7384
		private void FillBgTexture()
		{
			base.uiBehaviour.m_bgTexture.SetTexturePath("atlas/UI/common/Pic/" + this.m_doc.GetPicNameByDNid((uint)this.m_doc.CurDNid));
		}

		// Token: 0x0600FDD3 RID: 64979 RVA: 0x003B91B8 File Offset: 0x003B73B8
		private bool OnGoBattleClicked(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				specificDocument.SetAndMatch(this.m_doc.CurDNid);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FDD4 RID: 64980 RVA: 0x003B91FC File Offset: 0x003B73FC
		private bool OnRankBtnClicked(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgHandlerBase.EnsureCreate<WeekNestRankHandler>(ref this.m_weekNestRankHandler, base.uiBehaviour.m_rankTra, true, this);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FDD5 RID: 64981 RVA: 0x003B923C File Offset: 0x003B743C
		private bool OnClickClosed(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.SetVisible(false, true);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FDD6 RID: 64982 RVA: 0x003B926C File Offset: 0x003B746C
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x04007008 RID: 28680
		private float m_fCoolTime = 0.5f;

		// Token: 0x04007009 RID: 28681
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x0400700A RID: 28682
		private XWeekNestDocument m_doc;

		// Token: 0x0400700B RID: 28683
		public WeekNestRankHandler m_weekNestRankHandler;
	}
}
