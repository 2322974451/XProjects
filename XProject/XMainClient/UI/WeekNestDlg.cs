using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class WeekNestDlg : DlgBase<WeekNestDlg, WeeknestBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "OperatingActivity/WeekNest";
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
			base.Init();
			this.m_doc = XWeekNestDocument.Doc;
			this.m_doc.View = this;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_goBattleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoBattleClicked));
			base.uiBehaviour.m_rankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankBtnClicked));
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosed));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_GoddessTrial);
			return true;
		}

		protected override void OnShow()
		{
			this.m_doc.HadRedDot = false;
			base.uiBehaviour.m_tipsLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeekNestTips")));
			this.m_doc.ReqTeamCount();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		protected override void OnUnload()
		{
			base.uiBehaviour.m_bgTexture.SetTexturePath("");
			DlgHandlerBase.EnsureUnload<WeekNestRankHandler>(ref this.m_weekNestRankHandler);
			base.OnUnload();
		}

		public void Resfresh()
		{
			this.FillContent();
		}

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

		private void FillBgTexture()
		{
			base.uiBehaviour.m_bgTexture.SetTexturePath("atlas/UI/common/Pic/" + this.m_doc.GetPicNameByDNid((uint)this.m_doc.CurDNid));
		}

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

		private float m_fCoolTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private XWeekNestDocument m_doc;

		public WeekNestRankHandler m_weekNestRankHandler;
	}
}
