using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XSystemMailView : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_sprsel.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAllSelClick));
			this.m_btndel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDelClick));
			this.m_sprleft.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPageLeftClick));
			this.m_sprright.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPageRightClick));
			this.m_btnsq.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSQClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
			this._doc.ReqMailInfo();
		}

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

		public void RefreshPage()
		{
			this.m_lblpage.SetText(this._doc.GetPageFormat());
		}

		public override void OnUnload()
		{
			XSystemMailView.doItemSelect = (XSystemMailView.DelSelect)Delegate.Remove(XSystemMailView.doItemSelect, new XSystemMailView.DelSelect(this.Hidehighlight));
			base.OnUnload();
		}

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

		private bool OnPageLeftClick(IXUIButton btn)
		{
			bool flag = this._doc.CtlPage(false);
			if (flag)
			{
				this.Refresh();
			}
			return true;
		}

		private bool OnPageRightClick(IXUIButton btn)
		{
			bool flag = this._doc.CtlPage(true);
			if (flag)
			{
				this.Refresh();
			}
			return true;
		}

		private bool OnSQClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("sq click", null, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.ReqMailOP(MailOP.ClaimAll, new List<ulong>());
			return true;
		}

		private void OnAllSelClick(IXUISprite spr)
		{
			this.ShowSel(!this.all_selected);
			this.ShowItemsSel(this.all_selected);
			this.CheckDelbtnShow();
		}

		private void ShowItemsSel(bool show)
		{
			foreach (XSystemItemMailView xsystemItemMailView in this.items)
			{
				xsystemItemMailView.ShowSel(show);
			}
		}

		private void ShowSel(bool show)
		{
			this.all_selected = show;
			this.m_sprsel.SetAlpha(show ? 1f : 0.01f);
		}

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

		private void Hidehighlight()
		{
			foreach (XSystemItemMailView xsystemItemMailView in this.items)
			{
				xsystemItemMailView.ShowHighLight(false);
			}
		}

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

		private XMailDocument _doc = null;

		public IXUISprite m_sprsel;

		public IXUILabel m_lblpage;

		public IXUIButton m_sprleft;

		public IXUIButton m_sprright;

		public IXUIButton m_btndel;

		public IXUIButton m_btnsq;

		public GameObject m_objDelHighlight;

		public XSystemItemMailView[] items = new XSystemItemMailView[7];

		public static XSystemMailView.DelSelect doSelSelect;

		public static XSystemMailView.DelSelect doItemSelect;

		private bool all_selected;

		public delegate void DelSelect();
	}
}
