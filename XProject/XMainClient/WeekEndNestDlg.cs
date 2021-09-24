using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class WeekEndNestDlg : DlgBase<WeekEndNestDlg, WeekEndNestBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/WeekEndNestDlg";
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

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosed));
			base.uiBehaviour.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelp));
			base.uiBehaviour.m_getBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGeted));
			base.uiBehaviour.m_gotoTeamBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoTeam));
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = WeekEndNestDocument.Doc;
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
			bool needLoginShow = this.m_doc.NeedLoginShow;
			if (needLoginShow)
			{
				this.m_doc.NeedLoginShow = false;
			}
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public void Refresh()
		{
			this.FillContent();
		}

		private void FillContent()
		{
			base.uiBehaviour.m_tittleLab.SetText(this.m_doc.GetLevelName());
			base.uiBehaviour.m_rulesLab.SetText(this.m_doc.GetRules());
			base.uiBehaviour.m_tex.SetTexturePath(this.m_doc.GetTexName());
			base.uiBehaviour.m_timesLab.SetText(string.Format("{0}/{1}", this.m_doc.LeftCount, this.m_doc.MaxCount()));
			bool flag = this.m_doc.GetStatus == 1U;
			if (flag)
			{
				base.uiBehaviour.m_getSpr.SetGrey(true);
				base.uiBehaviour.m_reddotGo.SetActive(true);
			}
			else
			{
				base.uiBehaviour.m_getSpr.SetGrey(false);
				base.uiBehaviour.m_reddotGo.SetActive(false);
			}
			base.uiBehaviour.m_itemPool.ReturnAll(true);
			SeqListRef<uint> reward = this.m_doc.GetReward();
			for (int i = 0; i < (int)reward.count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_itemPool.FetchGameObject(false);
				gameObject.name = reward[i, 0].ToString();
				gameObject.transform.parent = base.uiBehaviour.m_parentTra;
				gameObject.transform.localPosition = new Vector3((float)(i * base.uiBehaviour.m_itemPool.TplWidth), 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)reward[i, 0], (int)reward[i, 1], false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)reward[i, 0];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnShowTips));
			}
		}

		private bool OnClosed(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool OnHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_WeekEndNest);
			return true;
		}

		private bool OnGeted(IXUIButton btn)
		{
			bool flag = this.m_doc.GetStatus != 1U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_doc.ReqGetReward();
				result = true;
			}
			return result;
		}

		private bool OnGotoTeam(IXUIButton btn)
		{
			int dnId = this.m_doc.GetDnId();
			bool flag = dnId == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				specificDocument.SetAndMatch(dnId);
				result = true;
			}
			return result;
		}

		private void OnShowTips(IXUISprite spr)
		{
			int itemID = (int)spr.ID;
			XItem mainItem = XBagDocument.MakeXItem(itemID, true);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, true, 0U);
		}

		private WeekEndNestDocument m_doc;
	}
}
