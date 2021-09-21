using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E8B RID: 3723
	internal class WeekEndNestDlg : DlgBase<WeekEndNestDlg, WeekEndNestBehaviour>
	{
		// Token: 0x170034A0 RID: 13472
		// (get) Token: 0x0600C6C3 RID: 50883 RVA: 0x002C0584 File Offset: 0x002BE784
		public override string fileName
		{
			get
			{
				return "GameSystem/WeekEndNestDlg";
			}
		}

		// Token: 0x170034A1 RID: 13473
		// (get) Token: 0x0600C6C4 RID: 50884 RVA: 0x002C059C File Offset: 0x002BE79C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170034A2 RID: 13474
		// (get) Token: 0x0600C6C5 RID: 50885 RVA: 0x002C05B0 File Offset: 0x002BE7B0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170034A3 RID: 13475
		// (get) Token: 0x0600C6C6 RID: 50886 RVA: 0x002C05C4 File Offset: 0x002BE7C4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170034A4 RID: 13476
		// (get) Token: 0x0600C6C7 RID: 50887 RVA: 0x002C05D8 File Offset: 0x002BE7D8
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C6C8 RID: 50888 RVA: 0x002C05EB File Offset: 0x002BE7EB
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600C6C9 RID: 50889 RVA: 0x002C05F8 File Offset: 0x002BE7F8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosed));
			base.uiBehaviour.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelp));
			base.uiBehaviour.m_getBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGeted));
			base.uiBehaviour.m_gotoTeamBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoTeam));
		}

		// Token: 0x0600C6CA RID: 50890 RVA: 0x002C0681 File Offset: 0x002BE881
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600C6CB RID: 50891 RVA: 0x002C068B File Offset: 0x002BE88B
		protected override void Init()
		{
			base.Init();
			this.m_doc = WeekEndNestDocument.Doc;
		}

		// Token: 0x0600C6CC RID: 50892 RVA: 0x002C06A0 File Offset: 0x002BE8A0
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600C6CD RID: 50893 RVA: 0x002C06AC File Offset: 0x002BE8AC
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

		// Token: 0x0600C6CE RID: 50894 RVA: 0x002C06E4 File Offset: 0x002BE8E4
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600C6CF RID: 50895 RVA: 0x002C06EE File Offset: 0x002BE8EE
		public void Refresh()
		{
			this.FillContent();
		}

		// Token: 0x0600C6D0 RID: 50896 RVA: 0x002C06F8 File Offset: 0x002BE8F8
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

		// Token: 0x0600C6D1 RID: 50897 RVA: 0x002C0910 File Offset: 0x002BEB10
		private bool OnClosed(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600C6D2 RID: 50898 RVA: 0x002C092C File Offset: 0x002BEB2C
		private bool OnHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_WeekEndNest);
			return true;
		}

		// Token: 0x0600C6D3 RID: 50899 RVA: 0x002C0950 File Offset: 0x002BEB50
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

		// Token: 0x0600C6D4 RID: 50900 RVA: 0x002C0988 File Offset: 0x002BEB88
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

		// Token: 0x0600C6D5 RID: 50901 RVA: 0x002C09C8 File Offset: 0x002BEBC8
		private void OnShowTips(IXUISprite spr)
		{
			int itemID = (int)spr.ID;
			XItem mainItem = XBagDocument.MakeXItem(itemID, true);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, true, 0U);
		}

		// Token: 0x0400573D RID: 22333
		private WeekEndNestDocument m_doc;
	}
}
