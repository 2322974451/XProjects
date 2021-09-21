using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001846 RID: 6214
	internal class XContentMailView : DlgHandlerBase
	{
		// Token: 0x06010241 RID: 66113 RVA: 0x003DD3E0 File Offset: 0x003DB5E0
		protected override void Init()
		{
			base.Init();
			this.m_lbltitle = (base.PanelObject.transform.Find("title/TitleLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_lbldate = (base.PanelObject.transform.Find("title/DateLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_lalcont = (base.PanelObject.transform.Find("content/contentLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_lblvalit = (base.PanelObject.transform.Find("btm/ValidityLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_btnrcv = (base.PanelObject.transform.Find("btm/rwdBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_lblrcv = (base.PanelObject.transform.Find("btm/rwdBtn/T").GetComponent("XUILabel") as IXUILabel);
			this.m_sprclaim = (base.PanelObject.transform.Find("btm/claimSpr").GetComponent("XUISprite") as IXUISprite);
			this.m_scroll = (base.PanelObject.transform.Find("items").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_objSlice = base.PanelObject.transform.Find("bg/slice").gameObject;
			this.m_objTpl = base.PanelObject.transform.Find("tpl").gameObject;
			this.m_scroll.ResetPosition();
			this.m_pool.SetupPool(this.m_scroll.gameObject, this.m_objTpl, 2U, false);
			this.m_tranAttach = base.PanelObject.transform.Find("bg/bg/T");
			XSystemMailView.doItemSelect = (XSystemMailView.DelSelect)Delegate.Combine(XSystemMailView.doItemSelect, new XSystemMailView.DelSelect(this.Refresh));
		}

		// Token: 0x06010242 RID: 66114 RVA: 0x003DD5EB File Offset: 0x003DB7EB
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnrcv.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRcvBtnClick));
		}

		// Token: 0x06010243 RID: 66115 RVA: 0x003DD60D File Offset: 0x003DB80D
		protected override void OnShow()
		{
			base.OnShow();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
			this.Refresh();
		}

		// Token: 0x06010244 RID: 66116 RVA: 0x003DD640 File Offset: 0x003DB840
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.leftTime < 86400 && this._doc != null;
			if (flag)
			{
				this.m_lblvalit.SetText(XStringDefineProxy.GetString("Mail_VALIT") + this._doc.valit);
			}
		}

		// Token: 0x06010245 RID: 66117 RVA: 0x003DD69A File Offset: 0x003DB89A
		public override void OnUnload()
		{
			XSystemMailView.doItemSelect = (XSystemMailView.DelSelect)Delegate.Remove(XSystemMailView.doItemSelect, new XSystemMailView.DelSelect(this.Refresh));
			base.OnUnload();
		}

		// Token: 0x06010246 RID: 66118 RVA: 0x003DD6C4 File Offset: 0x003DB8C4
		private bool OnRcvBtnClick(IXUIButton btn)
		{
			MailItem mailItem = this._doc.GetMailItem();
			bool flag = mailItem != null && mailItem.state == MailState.RWD;
			if (flag)
			{
				this.OnRcvClick();
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Mail_TIP"), "fece00");
			}
			return true;
		}

		// Token: 0x06010247 RID: 66119 RVA: 0x003DD720 File Offset: 0x003DB920
		private void OnRcvClick()
		{
			MailItem mailItem = this._doc.GetMailItem();
			bool flag = mailItem != null;
			if (flag)
			{
				this._doc.ReqMailOP(MailOP.Claim, mailItem.id);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Mail_DELAY"), "fece00");
			}
		}

		// Token: 0x06010248 RID: 66120 RVA: 0x003DD774 File Offset: 0x003DB974
		public void Refresh()
		{
			bool flag = this._doc.ShowMailContent();
			this.m_lbltitle.SetVisible(flag);
			this.m_lbldate.SetVisible(flag);
			this.m_lalcont.SetVisible(flag);
			this.m_lblvalit.SetVisible(flag);
			this.m_objSlice.SetActive(flag);
			this.m_pool.ReturnAll(false);
			this.m_btnrcv.SetVisible(flag);
			this.m_tranAttach.gameObject.SetActive(flag);
			this.m_sprclaim.SetVisible(flag);
			bool flag2 = flag;
			if (flag2)
			{
				MailItem mailItem = this._doc.GetMailItem();
				this.m_lbltitle.SetText(mailItem.title);
				this.m_lalcont.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(mailItem.content));
				this.m_lbldate.SetText(XStringDefineProxy.GetString("Mail_TIME") + " " + mailItem.date.ToString("yyyy-MM-dd HH:mm:ss"));
				bool flag3 = mailItem.items == null || mailItem.items.Count <= 0;
				if (flag3)
				{
					this.m_btnrcv.SetVisible(false);
				}
				this.RefreshItems(mailItem.items, mailItem.xitems);
				this.m_tranAttach.gameObject.SetActive(mailItem.items.Count > 0 || mailItem.xitems.Count > 0);
				this.RefreshValit(mailItem);
				this.m_lblrcv.SetText((mailItem.state == MailState.RWD) ? XStringDefineProxy.GetString("Mail_RCV") : XStringDefineProxy.GetString("Mail_NON"));
				this.m_btnrcv.SetVisible(mailItem.state == MailState.RWD);
				this.m_sprclaim.SetVisible(mailItem.state == MailState.CLAIMED);
			}
		}

		// Token: 0x06010249 RID: 66121 RVA: 0x003DD94C File Offset: 0x003DBB4C
		private void RefreshValit(MailItem mailItem)
		{
			this.leftTime = mailItem.valit;
			bool flag = mailItem.valit >= 86400;
			if (flag)
			{
				this.m_lblvalit.SetText(XStringDefineProxy.GetString("Mail_VALIT") + mailItem.valit / 86400 + XStringDefineProxy.GetString("Mail_DAY"));
			}
			else
			{
				bool flag2 = mailItem.valit >= 3600;
				if (flag2)
				{
					this.m_lblvalit.SetText(XStringDefineProxy.GetString("Mail_VALIT") + mailItem.valit / 3600 + XStringDefineProxy.GetString("Mail_HOUR"));
				}
				else
				{
					bool flag3 = mailItem.valit > 60;
					if (flag3)
					{
						this.m_lblvalit.SetText(XStringDefineProxy.GetString("Mail_VALIT") + mailItem.valit / 60 + XStringDefineProxy.GetString("Mail_MIN"));
					}
					else
					{
						this.m_lblvalit.SetText(XStringDefineProxy.GetString("Mail_VALIT") + "1" + XStringDefineProxy.GetString("Mail_MIN"));
					}
				}
			}
		}

		// Token: 0x0601024A RID: 66122 RVA: 0x003DDA6E File Offset: 0x003DBC6E
		public void SetContentNil()
		{
			this._doc.RefreshContentNil();
		}

		// Token: 0x0601024B RID: 66123 RVA: 0x003DDA80 File Offset: 0x003DBC80
		private void RefreshItems(List<ItemBrief> items, List<Item> xitems)
		{
			for (int i = 0; i < items.Count; i++)
			{
				GameObject gameObject = this.m_pool.FetchGameObject(false);
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
				gameObject.transform.localPosition = new Vector3((float)(-172 + 86 * i), 0f, 0f);
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)items[i].itemID);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf.ItemID, (int)items[i].itemCount, false);
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)itemConf.ItemID);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowTips));
			}
			for (int j = 0; j < xitems.Count; j++)
			{
				GameObject gameObject2 = this.m_pool.FetchGameObject(false);
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject2);
				gameObject2.transform.localPosition = new Vector3((float)(-172 + 86 * (j + items.Count)), 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)xitems[j].ItemID, (int)xitems[j].ItemCount, false);
				IXUISprite ixuisprite2 = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)xitems[j].ItemID;
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowTips));
			}
			this.m_scroll.ResetPosition();
		}

		// Token: 0x0601024C RID: 66124 RVA: 0x003DDC60 File Offset: 0x003DBE60
		private void ShowTips(IXUISprite spr)
		{
			bool flag = this._doc != null;
			if (flag)
			{
				MailItem mailItem = this._doc.GetMailItem();
				List<Item> xitems = mailItem.xitems;
				bool flag2 = false;
				for (int i = 0; i < xitems.Count; i++)
				{
					bool flag3 = (ulong)xitems[i].ItemID == spr.ID;
					if (flag3)
					{
						flag2 = true;
						XItem mainItem = XBagDocument.MakeXItem(xitems[i]);
						XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, false, 0U);
					}
				}
				bool flag4 = !flag2;
				if (flag4)
				{
					XItem mainItem2 = XBagDocument.MakeXItem((int)spr.ID, false);
					XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem2, spr, false, 0U);
				}
			}
		}

		// Token: 0x04007342 RID: 29506
		private XMailDocument _doc = null;

		// Token: 0x04007343 RID: 29507
		public IXUILabel m_lbltitle;

		// Token: 0x04007344 RID: 29508
		public IXUILabel m_lbldate;

		// Token: 0x04007345 RID: 29509
		public IXUILabel m_lalcont;

		// Token: 0x04007346 RID: 29510
		public IXUILabel m_lblvalit;

		// Token: 0x04007347 RID: 29511
		public GameObject m_objSlice;

		// Token: 0x04007348 RID: 29512
		public GameObject m_objTpl;

		// Token: 0x04007349 RID: 29513
		public IXUIButton m_btnrcv;

		// Token: 0x0400734A RID: 29514
		public IXUILabel m_lblrcv;

		// Token: 0x0400734B RID: 29515
		public IXUISprite m_sprclaim;

		// Token: 0x0400734C RID: 29516
		public Transform m_tranAttach;

		// Token: 0x0400734D RID: 29517
		public IXUIScrollView m_scroll;

		// Token: 0x0400734E RID: 29518
		private XUIPool m_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400734F RID: 29519
		private int leftTime = int.MaxValue;
	}
}
