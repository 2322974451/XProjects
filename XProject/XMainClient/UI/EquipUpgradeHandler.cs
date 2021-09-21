using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016E2 RID: 5858
	internal class EquipUpgradeHandler : DlgHandlerBase
	{
		// Token: 0x17003755 RID: 14165
		// (get) Token: 0x0600F1BF RID: 61887 RVA: 0x00357D20 File Offset: 0x00355F20
		protected override string FileName
		{
			get
			{
				return "ItemNew/UpgradeFrame";
			}
		}

		// Token: 0x0600F1C0 RID: 61888 RVA: 0x00357D38 File Offset: 0x00355F38
		protected override void Init()
		{
			base.Init();
			this.m_doc = EquipUpgradeDocument.Doc;
			this.m_doc.Handler = this;
			Transform transform = base.PanelObject.transform.Find("Bg/Top");
			this.m_beforeItem = transform.Find("UpgradeItemBefore").gameObject;
			this.m_afterItem = transform.Find("UpgradeItemAfter").gameObject;
			transform = base.PanelObject.transform.Find("Bg");
			this.m_helpBtn = (transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_closeBtn = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			transform = base.PanelObject.transform.Find("Bg/Bottom");
			this.m_upgradeBtn = (transform.Find("UpgradeBtn").GetComponent("XUIButton") as IXUIButton);
			transform = transform.Find("Items");
			this.m_needItemPool.SetupPool(transform.gameObject, transform.FindChild("Item").gameObject, 2U, true);
			transform = base.PanelObject.transform.FindChild("Bg/UpgradeAttr");
			this.m_beforeUpgradeGo = transform.Find("BeforeEnhance").gameObject;
			this.m_afterUpgradeGo = transform.Find("AfterEnhance").gameObject;
			this.m_BeforeAttrPool.SetupPool(this.m_beforeUpgradeGo, transform.Find("BeforeAttrTpl").gameObject, 2U, false);
			this.m_AfterAttrPool.SetupPool(this.m_afterUpgradeGo, transform.Find("AfterAttrTpl").gameObject, 2U, false);
		}

		// Token: 0x0600F1C1 RID: 61889 RVA: 0x00357EF0 File Offset: 0x003560F0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosed));
			this.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelp));
			this.m_upgradeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnUpgrade));
		}

		// Token: 0x0600F1C2 RID: 61890 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600F1C3 RID: 61891 RVA: 0x00357F50 File Offset: 0x00356150
		protected override void OnHide()
		{
			base.OnHide();
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.OnPopHandlerSetVisible(false, null);
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.StackRefresh();
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(0UL);
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(null);
			}
		}

		// Token: 0x0600F1C4 RID: 61892 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F1C5 RID: 61893 RVA: 0x00357FB4 File Offset: 0x003561B4
		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this.OnEquipClicked));
			}
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag.GetItemByUID(this.m_doc.SelectUid);
			bool flag2 = itemByUID == null;
			if (flag2)
			{
				this.m_doc.SelectEquip(0UL);
			}
			else
			{
				this.m_doc.SelectEquip(this.m_doc.SelectUid);
			}
			this.FillContent();
		}

		// Token: 0x0600F1C6 RID: 61894 RVA: 0x00358051 File Offset: 0x00356251
		public override void StackRefresh()
		{
			this.RefreshData();
			base.StackRefresh();
		}

		// Token: 0x0600F1C7 RID: 61895 RVA: 0x00358062 File Offset: 0x00356262
		public void ShowUI()
		{
			this.FillContent();
		}

		// Token: 0x0600F1C8 RID: 61896 RVA: 0x0035806C File Offset: 0x0035626C
		private void FillContent()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.SelectUid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
				bool flag2 = equipConf == null;
				if (!flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_beforeItem, itemByUID);
					IXUISprite ixuisprite = this.m_beforeItem.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = itemByUID.uid;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItem));
					EquipList.RowData equipConf2 = XBagDocument.GetEquipConf((int)equipConf.UpgadeTargetID);
					bool flag3 = equipConf2 != null;
					if (flag3)
					{
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_afterItem, equipConf2.ItemID, 0, false);
						ixuisprite = (this.m_afterItem.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
						ixuisprite.ID = (ulong)equipConf2.ItemID;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItem));
					}
					this.FillAttribute(equipConf, equipConf2);
					this.FillNeedItem(equipConf.UpgradeNeedMaterials);
				}
			}
		}

		// Token: 0x0600F1C9 RID: 61897 RVA: 0x003581A4 File Offset: 0x003563A4
		private void FillAttribute(EquipList.RowData row, EquipList.RowData targetRow)
		{
			bool flag = targetRow == null;
			if (!flag)
			{
				this.m_BeforeAttrPool.ReturnAll(false);
				this.m_AfterAttrPool.ReturnAll(false);
				SeqListRef<int> attributes = row.Attributes;
				float num = (float)((attributes.Count - 1) * this.m_gap / 2);
				for (int i = 0; i < attributes.Count; i++)
				{
					GameObject gameObject = this.m_BeforeAttrPool.FetchGameObject(false);
					gameObject.name = i.ToString();
					gameObject.transform.parent = this.m_beforeUpgradeGo.transform;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3(0f, num - (float)(this.m_gap * i), 0f);
					this.FillAttrWithName(gameObject, attributes[i, 0], attributes[i, 1]);
					int data = this.GetData(attributes[i, 0], targetRow.Attributes);
					int dvalue = data - attributes[i, 1];
					gameObject = this.m_AfterAttrPool.FetchGameObject(false);
					gameObject.name = i.ToString();
					gameObject.transform.parent = this.m_afterUpgradeGo.transform;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3(0f, num - (float)(this.m_gap * i), 0f);
					this.FillAttrNoName(gameObject, data, dvalue);
				}
			}
		}

		// Token: 0x0600F1CA RID: 61898 RVA: 0x0035833C File Offset: 0x0035653C
		private void FillAttrWithName(GameObject go, int attrId, int num)
		{
			IXUILabel ixuilabel = go.transform.GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString((XAttributeDefine)attrId));
			ixuilabel = (go.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(num.ToString());
		}

		// Token: 0x0600F1CB RID: 61899 RVA: 0x0035839C File Offset: 0x0035659C
		private void FillAttrNoName(GameObject go, int num, int dvalue)
		{
			IXUILabel ixuilabel = go.transform.GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(num.ToString());
			bool flag = dvalue > 0;
			if (flag)
			{
				ixuilabel = (go.transform.FindChild("Up").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(string.Format("[63ff85]{0}[-]", dvalue));
				ixuilabel.gameObject.SetActive(true);
			}
			else
			{
				go.transform.FindChild("Up").gameObject.SetActive(false);
			}
		}

		// Token: 0x0600F1CC RID: 61900 RVA: 0x0035843C File Offset: 0x0035663C
		private int GetData(int id, SeqListRef<int> seq)
		{
			for (int i = 0; i < (int)seq.count; i++)
			{
				bool flag = seq[i, 0] == id;
				if (flag)
				{
					return seq[i, 1];
				}
			}
			return 0;
		}

		// Token: 0x0600F1CD RID: 61901 RVA: 0x00358484 File Offset: 0x00356684
		private void FillNeedItem(SeqListRef<uint> items)
		{
			this.m_needItemPool.ReturnAll(false);
			for (int i = 0; i < (int)items.count; i++)
			{
				uint num = items[i, 0];
				GameObject gameObject = this.m_needItemPool.FetchGameObject(false);
				gameObject.name = num.ToString();
				gameObject.transform.localPosition = new Vector3((float)(this.m_needItemPool.TplWidth * i), 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)num, 0, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				IXUILabel ixuilabel = gameObject.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.gameObject.SetActive(true);
				uint num2 = (uint)XBagDocument.BagDoc.GetItemCount((int)num);
				bool flag = num2 >= items[i, 1];
				if (flag)
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItem));
					ixuilabel.SetText(string.Format("[00ff00]{0}[-]/{1}", num2, items[i, 1]));
				}
				else
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGetItemAccess));
					ixuilabel.SetText(string.Format("[ff0000]{0}[-]/{1}", num2, items[i, 1]));
				}
			}
		}

		// Token: 0x0600F1CE RID: 61902 RVA: 0x0035861C File Offset: 0x0035681C
		private bool OnClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600F1CF RID: 61903 RVA: 0x00358638 File Offset: 0x00356838
		private bool OnHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_EquipUpgrade);
			return true;
		}

		// Token: 0x0600F1D0 RID: 61904 RVA: 0x0035865C File Offset: 0x0035685C
		private bool OnUpgrade(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_delayTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_doc.ReqUpgrade();
				result = true;
			}
			return result;
		}

		// Token: 0x0600F1D1 RID: 61905 RVA: 0x00358690 File Offset: 0x00356890
		private void OnClickItem(IXUISprite iSp)
		{
			ulong id = iSp.ID;
			XItem xitem = XBagDocument.BagDoc.GetItemByUID(id);
			bool flag = xitem == null;
			if (flag)
			{
				xitem = XBagDocument.MakeXItem((int)id, false);
			}
			bool flag2 = xitem == null;
			if (!flag2)
			{
				XSingleton<UiUtility>.singleton.ShowTooltipDialog(xitem, null, iSp, false, 0U);
			}
		}

		// Token: 0x0600F1D2 RID: 61906 RVA: 0x003586DE File Offset: 0x003568DE
		public void OnEquipClicked(IXUISprite iSp)
		{
			this.m_doc.SelectEquip(iSp.ID);
		}

		// Token: 0x0600F1D3 RID: 61907 RVA: 0x003586F4 File Offset: 0x003568F4
		private void OnGetItemAccess(IXUISprite iSp)
		{
			int itemid = (int)iSp.ID;
			XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
		}

		// Token: 0x0600F1D4 RID: 61908 RVA: 0x00358718 File Offset: 0x00356918
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

		// Token: 0x04006762 RID: 26466
		private EquipUpgradeDocument m_doc;

		// Token: 0x04006763 RID: 26467
		private GameObject m_beforeItem;

		// Token: 0x04006764 RID: 26468
		private GameObject m_afterItem;

		// Token: 0x04006765 RID: 26469
		private GameObject m_beforeUpgradeGo;

		// Token: 0x04006766 RID: 26470
		private GameObject m_afterUpgradeGo;

		// Token: 0x04006767 RID: 26471
		private IXUIButton m_helpBtn;

		// Token: 0x04006768 RID: 26472
		private IXUIButton m_closeBtn;

		// Token: 0x04006769 RID: 26473
		private IXUIButton m_upgradeBtn;

		// Token: 0x0400676A RID: 26474
		private XUIPool m_needItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400676B RID: 26475
		private XUIPool m_BeforeAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400676C RID: 26476
		private XUIPool m_AfterAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400676D RID: 26477
		private readonly int m_gap = 30;

		// Token: 0x0400676E RID: 26478
		private float m_delayTime = 0.5f;

		// Token: 0x0400676F RID: 26479
		private float m_fLastClickBtnTime = 0f;
	}
}
