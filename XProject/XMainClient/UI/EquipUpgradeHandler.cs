using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EquipUpgradeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/UpgradeFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosed));
			this.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelp));
			this.m_upgradeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnUpgrade));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

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

		public override void OnUnload()
		{
			base.OnUnload();
		}

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

		public override void StackRefresh()
		{
			this.RefreshData();
			base.StackRefresh();
		}

		public void ShowUI()
		{
			this.FillContent();
		}

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

		private void FillAttrWithName(GameObject go, int attrId, int num)
		{
			IXUILabel ixuilabel = go.transform.GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString((XAttributeDefine)attrId));
			ixuilabel = (go.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(num.ToString());
		}

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

		private bool OnClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private bool OnHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_EquipUpgrade);
			return true;
		}

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

		public void OnEquipClicked(IXUISprite iSp)
		{
			this.m_doc.SelectEquip(iSp.ID);
		}

		private void OnGetItemAccess(IXUISprite iSp)
		{
			int itemid = (int)iSp.ID;
			XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
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

		private EquipUpgradeDocument m_doc;

		private GameObject m_beforeItem;

		private GameObject m_afterItem;

		private GameObject m_beforeUpgradeGo;

		private GameObject m_afterUpgradeGo;

		private IXUIButton m_helpBtn;

		private IXUIButton m_closeBtn;

		private IXUIButton m_upgradeBtn;

		private XUIPool m_needItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_BeforeAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_AfterAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private readonly int m_gap = 30;

		private float m_delayTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;
	}
}
