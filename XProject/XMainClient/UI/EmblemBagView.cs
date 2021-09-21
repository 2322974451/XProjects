using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001913 RID: 6419
	internal class EmblemBagView : DlgHandlerBase
	{
		// Token: 0x17003ADD RID: 15069
		// (get) Token: 0x06010C93 RID: 68755 RVA: 0x0043709C File Offset: 0x0043529C
		private XItemMorePowerfulTipMgr powerfullMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.RedPointMgr;
			}
		}

		// Token: 0x17003ADE RID: 15070
		// (get) Token: 0x06010C94 RID: 68756 RVA: 0x004370B8 File Offset: 0x004352B8
		private XItemMorePowerfulTipMgr newItemMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.NewItemMgr;
			}
		}

		// Token: 0x17003ADF RID: 15071
		// (get) Token: 0x06010C95 RID: 68757 RVA: 0x004370D4 File Offset: 0x004352D4
		private XBagWindow bagWindow
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.BagWindow;
			}
		}

		// Token: 0x17003AE0 RID: 15072
		// (get) Token: 0x06010C96 RID: 68758 RVA: 0x004370F0 File Offset: 0x004352F0
		public string IdentifyEffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_identifyEffectPath);
				if (flag)
				{
					this.m_identifyEffectPath = XSingleton<XGlobalConfig>.singleton.GetValue("EmblemIdentifyEffectPath");
				}
				return this.m_identifyEffectPath;
			}
		}

		// Token: 0x17003AE1 RID: 15073
		// (get) Token: 0x06010C97 RID: 68759 RVA: 0x0043712C File Offset: 0x0043532C
		protected override string FileName
		{
			get
			{
				return "ItemNew/EmblemListPanel";
			}
		}

		// Token: 0x06010C98 RID: 68760 RVA: 0x00437144 File Offset: 0x00435344
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			this._doc._BagHandler = this;
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_bagNumLab = (base.PanelObject.transform.FindChild("Panel/BagNum").GetComponent("XUILabel") as IXUILabel);
			this.m_expandBagBtn = (base.PanelObject.transform.FindChild("add").GetComponent("XUIButton") as IXUIButton);
			BagExpandItemListTable.RowData expandItemConfByType = XBagDocument.GetExpandItemConfByType((uint)XFastEnumIntEqualityComparer<BagType>.ToInt(BagType.EmblemBag));
			this.m_expandBagBtn.gameObject.SetActive(expandItemConfByType != null);
			this.EffectTra = base.PanelObject.transform.FindChild("Effect");
		}

		// Token: 0x06010C99 RID: 68761 RVA: 0x0043722A File Offset: 0x0043542A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_expandBagBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBagExpandClicked));
		}

		// Token: 0x06010C9A RID: 68762 RVA: 0x00437264 File Offset: 0x00435464
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Char_Emblem);
			return true;
		}

		// Token: 0x06010C9B RID: 68763 RVA: 0x00437287 File Offset: 0x00435487
		protected override void OnShow()
		{
			base.OnShow();
			this.Show();
		}

		// Token: 0x06010C9C RID: 68764 RVA: 0x00437298 File Offset: 0x00435498
		private void Show()
		{
			this.bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this._doc.GetEmblemItems));
			this.bagWindow.OnShow();
			this.SetBagNum();
			this._doc.NewItems.bCanClear = true;
		}

		// Token: 0x06010C9D RID: 68765 RVA: 0x004372F4 File Offset: 0x004354F4
		protected override void OnHide()
		{
			this.powerfullMgr.ReturnAll();
			this.newItemMgr.ReturnAll();
			this.bagWindow.OnHide();
			this._doc.NewItems.TryClear();
			this.itemBtnDic.Clear();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_emblemIdentifyToken);
			this.HideEffect(this.m_identifyFx);
			base.OnHide();
		}

		// Token: 0x06010C9E RID: 68766 RVA: 0x00437368 File Offset: 0x00435568
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Show();
		}

		// Token: 0x06010C9F RID: 68767 RVA: 0x0043737C File Offset: 0x0043557C
		public override void OnUnload()
		{
			this._doc._BagHandler = null;
			bool flag = this.m_identifyFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_identifyFx, true);
				this.m_identifyFx = null;
			}
			base.OnUnload();
		}

		// Token: 0x06010CA0 RID: 68768 RVA: 0x004373C5 File Offset: 0x004355C5
		public void Refresh()
		{
			this.bagWindow.RefreshWindow();
			this.SetBagNum();
		}

		// Token: 0x06010CA1 RID: 68769 RVA: 0x004373DC File Offset: 0x004355DC
		public void RefreshTips(ulong uid)
		{
			IXUISprite ixuisprite;
			bool flag = this.itemBtnDic.TryGetValue(uid, out ixuisprite);
			if (flag)
			{
				bool flag2 = ixuisprite != null;
				if (flag2)
				{
					this.OnItemClicked(ixuisprite);
				}
			}
		}

		// Token: 0x06010CA2 RID: 68770 RVA: 0x00437410 File Offset: 0x00435610
		private void SetBagNum()
		{
			int count = this._doc.GetEmblemItems().Count;
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			VIPTable.RowData byVIP = specificDocument.VIPReader.GetByVIP((int)specificDocument.VipLevel);
			bool flag = byVIP != null;
			if (flag)
			{
				uint num = byVIP.EmblemMax;
				BagExpandData bagExpandData = XBagDocument.BagDoc.GetBagExpandData(BagType.EmblemBag);
				bool flag2 = bagExpandData != null;
				if (flag2)
				{
					num += bagExpandData.ExpandNum;
				}
				bool flag3 = (long)count >= (long)((ulong)num);
				if (flag3)
				{
					this.m_bagNumLab.SetText(string.Format("[ff4366]{0}[-]/{1}", count, num));
				}
				else
				{
					this.m_bagNumLab.SetText(string.Format("{0}[-]/{1}", count, num));
				}
			}
		}

		// Token: 0x06010CA3 RID: 68771 RVA: 0x004374E0 File Offset: 0x004356E0
		private void WrapContentItemUpdated(Transform t, int index)
		{
			Transform transform = t.FindChild("Icon/SupplementBrought");
			bool flag = transform != null;
			if (flag)
			{
				transform.gameObject.SetActive(false);
			}
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			bool flag2 = this.bagWindow.m_XItemList == null || index >= this.bagWindow.m_XItemList.Count || index < 0;
			if (flag2)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				this.powerfullMgr.ReturnInstance(ixuisprite);
				this.newItemMgr.ReturnInstance(ixuisprite);
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("empty", index.ToString());
			}
			else
			{
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("emblem", this.bagWindow.m_XItemList[index].itemID.ToString());
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, this.bagWindow.m_XItemList[index]);
				ixuisprite.ID = this.bagWindow.m_XItemList[index].uid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
				bool flag3 = this.itemBtnDic.ContainsKey(ixuisprite.ID);
				if (flag3)
				{
					this.itemBtnDic[ixuisprite.ID] = ixuisprite;
				}
				else
				{
					this.itemBtnDic.Add(ixuisprite.ID, ixuisprite);
				}
				XEmblemItem xemblemItem = this.bagWindow.m_XItemList[index] as XEmblemItem;
				bool flag4 = this._doc.IsEmblemMorePowerful(ixuisprite.ID);
				if (flag4)
				{
					this.powerfullMgr.SetTip(ixuisprite);
				}
				else
				{
					this.powerfullMgr.ReturnInstance(ixuisprite);
				}
				bool flag5 = this._doc.NewItems.IsNew(ixuisprite.ID);
				if (flag5)
				{
					this.newItemMgr.SetTip(ixuisprite);
				}
				else
				{
					this.newItemMgr.ReturnInstance(ixuisprite);
				}
			}
		}

		// Token: 0x06010CA4 RID: 68772 RVA: 0x00437704 File Offset: 0x00435904
		public void ShowEmblemIdentifyEffect()
		{
			bool flag = this.m_identifyFx == null;
			if (flag)
			{
				this.m_identifyFx = XSingleton<XFxMgr>.singleton.CreateFx(this.IdentifyEffectPath, null, true);
			}
			else
			{
				this.m_identifyFx.SetActive(true);
			}
			this.m_identifyFx.Play(this.EffectTra, Vector3.zero, Vector3.one, 1f, true, false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_emblemIdentifyToken);
			this.m_emblemIdentifyToken = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(5f, new XTimerMgr.AccurateElapsedEventHandler(this.OnEmblemIdentifyTimer), null);
		}

		// Token: 0x06010CA5 RID: 68773 RVA: 0x0043779C File Offset: 0x0043599C
		private void OnEmblemIdentifyTimer(object param, float delay)
		{
			this.HideEffect(this.m_identifyFx);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_emblemIdentifyToken);
			this.m_emblemIdentifyToken = 0U;
		}

		// Token: 0x06010CA6 RID: 68774 RVA: 0x004377C4 File Offset: 0x004359C4
		private void HideEffect(XFx fx)
		{
			bool flag = fx != null;
			if (flag)
			{
				fx.Stop();
				fx.SetActive(false);
			}
		}

		// Token: 0x06010CA7 RID: 68775 RVA: 0x004377EC File Offset: 0x004359EC
		public void OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID == null;
			if (!flag)
			{
				bool flag2 = this._doc.NewItems.RemoveItem(iSp.ID, itemByUID.Type, false);
				if (flag2)
				{
					this.Refresh();
				}
				CharacterEquipHandler.OnItemClicked(iSp);
			}
		}

		// Token: 0x06010CA8 RID: 68776 RVA: 0x0043784E File Offset: 0x00435A4E
		public void OnAddItem()
		{
			this.bagWindow.UpdateBag();
			this.SetBagNum();
		}

		// Token: 0x06010CA9 RID: 68777 RVA: 0x0043784E File Offset: 0x00435A4E
		public void OnRemoveItem()
		{
			this.bagWindow.UpdateBag();
			this.SetBagNum();
		}

		// Token: 0x06010CAA RID: 68778 RVA: 0x00437864 File Offset: 0x00435A64
		public void OnItemCountChanged(XItem item)
		{
			this.bagWindow.UpdateItem(item);
		}

		// Token: 0x06010CAB RID: 68779 RVA: 0x00437874 File Offset: 0x00435A74
		public void OnSwapItem(XItem item1, XItem item2, int slot)
		{
			this.bagWindow.ReplaceItem(item1, item2);
		}

		// Token: 0x06010CAC RID: 68780 RVA: 0x00437864 File Offset: 0x00435A64
		public void OnUpdateItem(XItem item)
		{
			this.bagWindow.UpdateItem(item);
		}

		// Token: 0x06010CAD RID: 68781 RVA: 0x00437888 File Offset: 0x00435A88
		public bool OnBagExpandClicked(IXUIButton button)
		{
			XBagDocument.BagDoc.UseBagExpandTicket(BagType.EmblemBag);
			return true;
		}

		// Token: 0x04007B24 RID: 31524
		public IXUIButton m_Help;

		// Token: 0x04007B25 RID: 31525
		private XEmblemDocument _doc;

		// Token: 0x04007B26 RID: 31526
		private IXUILabel m_bagNumLab;

		// Token: 0x04007B27 RID: 31527
		private Dictionary<ulong, IXUISprite> itemBtnDic = new Dictionary<ulong, IXUISprite>();

		// Token: 0x04007B28 RID: 31528
		public IXUIButton m_expandBagBtn;

		// Token: 0x04007B29 RID: 31529
		private Transform EffectTra;

		// Token: 0x04007B2A RID: 31530
		private XFx m_identifyFx;

		// Token: 0x04007B2B RID: 31531
		private uint m_emblemIdentifyToken = 0U;

		// Token: 0x04007B2C RID: 31532
		private string m_identifyEffectPath = string.Empty;
	}
}
