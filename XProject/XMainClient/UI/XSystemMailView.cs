using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200184A RID: 6218
	internal class XSystemMailView : DlgHandlerBase
	{
		// Token: 0x06010266 RID: 66150 RVA: 0x003DE8F8 File Offset: 0x003DCAF8
		protected override void Init()
		{
			base.Init();
			this.m_sprsel = (base.PanelObject.transform.Find("btm/AllSelItem/sign").GetComponent("XUISprite") as IXUISprite);
			this.m_lblpage = (base.PanelObject.transform.Find("btm/pageItem/T").GetComponent("XUILabel") as IXUILabel);
			this.m_sprleft = (base.PanelObject.transform.Find("btm/pageItem/left").GetComponent("XUIButton") as IXUIButton);
			this.m_sprright = (base.PanelObject.transform.Find("btm/pageItem/right").GetComponent("XUIButton") as IXUIButton);
			this.m_btndel = (base.PanelObject.transform.Find("btm/deletBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_btnsq = (base.PanelObject.transform.Find("btm/sqBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_objDelHighlight = this.m_btndel.gameObject.transform.Find("Highlight").gameObject;
			this.ShowSel(false);
			this.m_objDelHighlight.SetActive(false);
			for (int i = 0; i < this.items.Length; i++)
			{
				string text = "Content/item" + i;
				GameObject gameObject = base.PanelObject.transform.Find(text).gameObject;
				bool flag = gameObject != null;
				if (flag)
				{
					this.items[i] = gameObject.AddComponent<XSystemItemMailView>();
				}
			}
			XSystemMailView.doSelSelect = new XSystemMailView.DelSelect(this.CheckDelbtnShow);
			XSystemMailView.doItemSelect = (XSystemMailView.DelSelect)Delegate.Combine(XSystemMailView.doItemSelect, new XSystemMailView.DelSelect(this.Hidehighlight));
		}

		// Token: 0x06010267 RID: 66151 RVA: 0x003DEAD0 File Offset: 0x003DCCD0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_sprsel.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAllSelClick));
			this.m_btndel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDelClick));
			this.m_sprleft.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPageLeftClick));
			this.m_sprright.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPageRightClick));
			this.m_btnsq.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSQClick));
		}

		// Token: 0x06010268 RID: 66152 RVA: 0x003DEB5D File Offset: 0x003DCD5D
		protected override void OnShow()
		{
			base.OnShow();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
			this._doc.ReqMailInfo();
		}

		// Token: 0x06010269 RID: 66153 RVA: 0x003DEB94 File Offset: 0x003DCD94
		public void Refresh()
		{
			this._doc.RefreshContentNil();
			this.ShowItemsSel(false);
			this.ShowSel(false);
			this.m_objDelHighlight.SetActive(false);
			this.m_btndel.SetEnable(false, false);
			this.Hidehighlight();
			this.RefreshItems();
			this.RefreshPage();
		}

		// Token: 0x0601026A RID: 66154 RVA: 0x003DEBF0 File Offset: 0x003DCDF0
		public void RefreshItems()
		{
			List<MailItem> mails = this._doc.mails;
			for (int i = 0; i < mails.Count; i++)
			{
				this.items[i].gameObject.SetActive(true);
				this.items[i].Refresh(mails[i].id);
			}
			for (int j = mails.Count; j < 7; j++)
			{
				this.items[j].gameObject.SetActive(false);
			}
		}

		// Token: 0x0601026B RID: 66155 RVA: 0x003DEC7C File Offset: 0x003DCE7C
		public void RefreshPage()
		{
			this.m_lblpage.SetText(this._doc.GetPageFormat());
		}

		// Token: 0x0601026C RID: 66156 RVA: 0x003DEC96 File Offset: 0x003DCE96
		public override void OnUnload()
		{
			XSystemMailView.doItemSelect = (XSystemMailView.DelSelect)Delegate.Remove(XSystemMailView.doItemSelect, new XSystemMailView.DelSelect(this.Hidehighlight));
			base.OnUnload();
		}

		// Token: 0x0601026D RID: 66157 RVA: 0x003DECC0 File Offset: 0x003DCEC0
		private bool OnDelClick(IXUIButton btn)
		{
			bool flag = !this.m_objDelHighlight.activeSelf || DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.IsVisible();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool hasRwd = this.hasRwd;
				if (hasRwd)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Mail_RWD"), "fece00");
				}
				else
				{
					this._doc.ReqMailOP(MailOP.Delete, this.selects);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0601026E RID: 66158 RVA: 0x003DED34 File Offset: 0x003DCF34
		private bool OnPageLeftClick(IXUIButton btn)
		{
			bool flag = this._doc.CtlPage(false);
			if (flag)
			{
				this.Refresh();
			}
			return true;
		}

		// Token: 0x0601026F RID: 66159 RVA: 0x003DED60 File Offset: 0x003DCF60
		private bool OnPageRightClick(IXUIButton btn)
		{
			bool flag = this._doc.CtlPage(true);
			if (flag)
			{
				this.Refresh();
			}
			return true;
		}

		// Token: 0x06010270 RID: 66160 RVA: 0x003DED8C File Offset: 0x003DCF8C
		private bool OnSQClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("sq click", null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.ReqMailOP(MailOP.ClaimAll, new List<ulong>());
			return true;
		}

		// Token: 0x06010271 RID: 66161 RVA: 0x003DEDC7 File Offset: 0x003DCFC7
		private void OnAllSelClick(IXUISprite spr)
		{
			this.ShowSel(!this.all_selected);
			this.ShowItemsSel(this.all_selected);
			this.CheckDelbtnShow();
		}

		// Token: 0x06010272 RID: 66162 RVA: 0x003DEDF0 File Offset: 0x003DCFF0
		private void ShowItemsSel(bool show)
		{
			foreach (XSystemItemMailView xsystemItemMailView in this.items)
			{
				xsystemItemMailView.ShowSel(show);
			}
		}

		// Token: 0x06010273 RID: 66163 RVA: 0x003DEE22 File Offset: 0x003DD022
		private void ShowSel(bool show)
		{
			this.all_selected = show;
			this.m_sprsel.SetAlpha(show ? 1f : 0.01f);
		}

		// Token: 0x06010274 RID: 66164 RVA: 0x003DEE48 File Offset: 0x003DD048
		private void CheckDelbtnShow()
		{
			bool flag = false;
			foreach (XSystemItemMailView xsystemItemMailView in this.items)
			{
				bool select = xsystemItemMailView.Select;
				if (select)
				{
					flag = true;
					break;
				}
			}
			this.m_objDelHighlight.SetActive(flag);
			this.m_btndel.SetEnable(flag, false);
		}

		// Token: 0x06010275 RID: 66165 RVA: 0x003DEEA0 File Offset: 0x003DD0A0
		private void Hidehighlight()
		{
			foreach (XSystemItemMailView xsystemItemMailView in this.items)
			{
				xsystemItemMailView.ShowHighLight(false);
			}
		}

		// Token: 0x17003959 RID: 14681
		// (get) Token: 0x06010276 RID: 66166 RVA: 0x003DEED4 File Offset: 0x003DD0D4
		private List<ulong> selects
		{
			get
			{
				List<ulong> list = new List<ulong>();
				foreach (XSystemItemMailView xsystemItemMailView in this.items)
				{
					bool flag = xsystemItemMailView != null && xsystemItemMailView.Select;
					if (flag)
					{
						list.Add(xsystemItemMailView.uid);
					}
				}
				return list;
			}
		}

		// Token: 0x1700395A RID: 14682
		// (get) Token: 0x06010277 RID: 66167 RVA: 0x003DEF34 File Offset: 0x003DD134
		public bool hasRwd
		{
			get
			{
				bool result = false;
				bool flag = this.items != null;
				if (flag)
				{
					for (int i = 0; i < this.items.Length; i++)
					{
						XSystemItemMailView xsystemItemMailView = this.items[i];
						bool flag2 = xsystemItemMailView != null;
						if (flag2)
						{
							bool flag3 = xsystemItemMailView.Select && xsystemItemMailView.isRwd;
							if (flag3)
							{
								result = true;
								break;
							}
						}
					}
				}
				return result;
			}
		}

		// Token: 0x0400736C RID: 29548
		private XMailDocument _doc = null;

		// Token: 0x0400736D RID: 29549
		public IXUISprite m_sprsel;

		// Token: 0x0400736E RID: 29550
		public IXUILabel m_lblpage;

		// Token: 0x0400736F RID: 29551
		public IXUIButton m_sprleft;

		// Token: 0x04007370 RID: 29552
		public IXUIButton m_sprright;

		// Token: 0x04007371 RID: 29553
		public IXUIButton m_btndel;

		// Token: 0x04007372 RID: 29554
		public IXUIButton m_btnsq;

		// Token: 0x04007373 RID: 29555
		public GameObject m_objDelHighlight;

		// Token: 0x04007374 RID: 29556
		public XSystemItemMailView[] items = new XSystemItemMailView[7];

		// Token: 0x04007375 RID: 29557
		public static XSystemMailView.DelSelect doSelSelect;

		// Token: 0x04007376 RID: 29558
		public static XSystemMailView.DelSelect doItemSelect;

		// Token: 0x04007377 RID: 29559
		private bool all_selected;

		// Token: 0x02001A16 RID: 6678
		// (Invoke) Token: 0x0601112C RID: 69932
		public delegate void DelSelect();
	}
}
