using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class CharacterItemBagHandler : DlgHandlerBase
	{

		private XItemMorePowerfulTipMgr newItemMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.NewItemMgr;
			}
		}

		private XItemMorePowerfulTipMgr redPointMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.RedPointMgr;
			}
		}

		public XWheelOfFortuneHandler WheelOfFortune
		{
			get
			{
				return this._WheelOfFortune;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/BagListPanel";
			}
		}

		protected override void Init()
		{
			base.Init();
			GameObject gameObject = base.PanelObject.transform.FindChild("WheelOfFortune").gameObject;
			DlgHandlerBase.EnsureCreate<XWheelOfFortuneHandler>(ref this._WheelOfFortune, gameObject, this, false);
			this.m_bagNumLab = (base.PanelObject.transform.FindChild("BagNum").GetComponent("XUILabel") as IXUILabel);
			this.m_expandBagBtn = (base.PanelObject.transform.FindChild("add").GetComponent("XUIButton") as IXUIButton);
			this.m_helpBtn = (base.PanelObject.transform.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			gameObject = base.PanelObject.transform.FindChild("Items").gameObject;
			this.m_bagWindow = new XBagWindow(gameObject, null, null);
			this.m_bagWindow.Init();
			gameObject = base.PanelObject.transform.Find("TabsFrame/Tpl").gameObject;
			this.m_tabTplPool.SetupPool(gameObject.transform.parent.gameObject, gameObject, 4U, false);
			this.m_doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XCharacterItemDocument.uuID) as XCharacterItemDocument);
			this.m_doc.Handler = this;
			BagExpandItemListTable.RowData expandItemConfByType = XBagDocument.GetExpandItemConfByType((uint)XFastEnumIntEqualityComparer<BagType>.ToInt(BagType.ItemBag));
			this.m_expandBagBtn.gameObject.SetActive(expandItemConfByType != null);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_expandBagBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBagExpandClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.BagType = 0U;
			this.FillTabs();
		}

		protected override void OnHide()
		{
			this.m_bagWindow.OnHide();
			this.itemBtnDic.Clear();
			this.newItemMgr.ReturnAll();
			this.redPointMgr.ReturnAll();
			this.m_doc.NewItems.TryClear();
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshBag();
			this.UpdateTabRedDot();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XWheelOfFortuneHandler>(ref this._WheelOfFortune);
			this.m_doc.Handler = null;
			base.OnUnload();
		}

		private void FillTabs()
		{
			this.m_tabTplPool.ReturnAll(false);
			bool flag = XCharacterItemDocument.TabList == null;
			if (!flag)
			{
				int count = XCharacterItemDocument.TabList.Count;
				this.m_tabReddotDic.Clear();
				for (int i = 0; i < count; i++)
				{
					XTuple<uint, string> xtuple = XCharacterItemDocument.TabList[i];
					bool flag2 = xtuple == null;
					if (!flag2)
					{
						GameObject gameObject = this.m_tabTplPool.FetchGameObject(false);
						gameObject.transform.localScale = Vector3.one;
						gameObject.transform.localPosition = new Vector3((float)(this.m_tabTplPool.TplWidth * i), 0f, 0f);
						IXUICheckBox ixuicheckBox = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
						ixuicheckBox.ID = (ulong)xtuple.Item1;
						ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabTooggleClicked));
						this.m_tabReddotDic.Add(xtuple.Item1, gameObject.transform.FindChild("Bg/RedPoint").gameObject);
						IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(xtuple.Item2);
						ixuilabel = (gameObject.transform.FindChild("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel);
						ixuilabel.SetText(xtuple.Item2);
						bool flag3 = i == 0;
						if (flag3)
						{
							ixuicheckBox.ForceSetFlag(true);
							this.OnTabTooggleClicked(ixuicheckBox);
						}
						else
						{
							ixuicheckBox.ForceSetFlag(false);
						}
					}
				}
				this.UpdateTabRedDot();
			}
		}

		private void FillContent()
		{
			this.RefreshBag();
			this._WheelOfFortune.SetVisible(false);
			this.m_doc.NewItems.bCanClear = true;
		}

		private void RefreshBag()
		{
			this.m_bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetItem));
			this.m_bagWindow.OnShow();
			this.SetBagNum();
		}

		public void Refresh()
		{
			this.m_bagWindow.RefreshWindow();
			this.SetBagNum();
		}

		public void UpdateBag()
		{
			this.itemBtnDic.Clear();
			this.m_bagWindow.UpdateBag();
			this.SetBagNum();
		}

		public void UpdateTabRedDot()
		{
			bool flag = this.m_tabReddotDic == null;
			if (!flag)
			{
				foreach (KeyValuePair<uint, GameObject> keyValuePair in this.m_tabReddotDic)
				{
					bool active;
					bool flag2 = this.m_doc.m_bagTypeRedDotDic.TryGetValue(keyValuePair.Key, out active);
					if (flag2)
					{
						bool flag3 = keyValuePair.Value != null;
						if (flag3)
						{
							keyValuePair.Value.SetActive(active);
						}
					}
					else
					{
						bool flag4 = keyValuePair.Value != null;
						if (flag4)
						{
							keyValuePair.Value.SetActive(false);
						}
					}
				}
			}
		}

		private void SetBagNum()
		{
			int totalNum = this.m_doc.GetTotalNum();
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			VIPTable.RowData byVIP = specificDocument.VIPReader.GetByVIP((int)specificDocument.VipLevel);
			bool flag = byVIP != null;
			if (flag)
			{
				uint num = byVIP.BagMax;
				BagExpandData bagExpandData = XBagDocument.BagDoc.GetBagExpandData(BagType.ItemBag);
				bool flag2 = bagExpandData != null;
				if (flag2)
				{
					num += bagExpandData.ExpandNum;
				}
				bool flag3 = (long)totalNum >= (long)((ulong)num);
				if (flag3)
				{
					this.m_bagNumLab.SetText(string.Format("[ff4366]{0}[-]/{1}", totalNum, num));
				}
				else
				{
					this.m_bagNumLab.SetText(string.Format("{0}[-]/{1}", totalNum, num));
				}
			}
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject = t.FindChild("RedPoint").gameObject;
			bool flag = this.m_bagWindow.m_XItemList == null || index >= this.m_bagWindow.m_XItemList.Count || index < 0;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				this.newItemMgr.ReturnInstance(ixuisprite);
				gameObject.SetActive(false);
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("empty", index.ToString());
			}
			else
			{
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("item", this.m_bagWindow.m_XItemList[index].itemID.ToString());
				XItem xitem = this.m_bagWindow.m_XItemList[index];
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, xitem);
				ixuisprite.ID = xitem.uid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
				bool flag2 = this.itemBtnDic.ContainsKey(ixuisprite.ID);
				if (flag2)
				{
					this.itemBtnDic[ixuisprite.ID] = ixuisprite;
				}
				else
				{
					this.itemBtnDic.Add(ixuisprite.ID, ixuisprite);
				}
				bool flag3 = this.m_doc.NewItems.IsNew(ixuisprite.ID);
				if (flag3)
				{
					this.newItemMgr.SetTip(ixuisprite);
				}
				else
				{
					this.newItemMgr.ReturnInstance(ixuisprite);
				}
				bool flag4 = this.m_doc.AvailableItems.IsNew(ixuisprite.ID);
				if (flag4)
				{
					gameObject.SetActive(true);
				}
				else
				{
					gameObject.SetActive(false);
				}
			}
		}

		public void AddItem(List<XItem> items)
		{
			this.m_bagWindow.UpdateBag();
		}

		public void RemoveItem(List<ulong> uids)
		{
			this.UpdateBag();
			foreach (ulong num in uids)
			{
				bool flag = num == DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.MainItemUID;
				if (flag)
				{
					DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(false);
				}
				bool flag2 = num == DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.MainItemUID;
				if (flag2)
				{
					DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.HideToolTip(true);
				}
			}
		}

		public void ItemNumChanged(XItem item)
		{
			this.m_bagWindow.UpdateItem(item);
		}

		public void UpdateItem(XItem item)
		{
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
			bool flag = equipConf == null;
			if (flag)
			{
				this.m_bagWindow.UpdateItem(item);
			}
			bool flag2 = item.uid == DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.MainItemUID;
			if (flag2)
			{
				DlgBase<EquipTooltipDlg, EquipTooltipDlgBehaviour>.singleton.HideToolTip(false);
			}
			bool flag3 = item.uid == DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.MainItemUID;
			if (flag3)
			{
				DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.HideToolTip(true);
			}
		}

		public void RefreshTips(ulong uid)
		{
			IXUISprite ixuisprite;
			bool flag = this.itemBtnDic.TryGetValue(uid, out ixuisprite);
			if (flag)
			{
				bool flag2 = ixuisprite == null;
				if (!flag2)
				{
					XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(ixuisprite.ID);
					bool flag3 = itemByUID == null;
					if (!flag3)
					{
						bool flag4 = itemByUID.Type == ItemType.PANDORA;
						if (flag4)
						{
							PandoraHeart.RowData pandoraHeartConf = XBagDocument.GetPandoraHeartConf(itemByUID.itemID, XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID);
							int num = 0;
							bool flag5 = pandoraHeartConf != null;
							if (flag5)
							{
								num = XBagDocument.BagDoc.ItemBag.GetItemCount((int)pandoraHeartConf.FireID);
							}
							bool flag6 = num > 2;
							if (!flag6)
							{
								this._OnItemClicked(ixuisprite);
							}
						}
					}
				}
			}
		}

		private void _OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID == null;
			if (!flag)
			{
				bool flag2 = this.m_doc.NewItems.RemoveItem(iSp.ID, itemByUID.Type, false);
				if (flag2)
				{
					this.Refresh();
				}
				CharacterEquipHandler.OnItemClicked(iSp);
			}
		}

		public bool OnBagExpandClicked(IXUIButton button)
		{
			XBagDocument.BagDoc.UseBagExpandTicket(BagType.ItemBag);
			return true;
		}

		private bool OnTabTooggleClicked(IXUICheckBox cb)
		{
			bool flag = !cb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_doc.BagType = (uint)cb.ID;
				this.FillContent();
				result = true;
			}
			return result;
		}

		private XCharacterItemDocument m_doc;

		private IXUILabel m_bagNumLab;

		private IXUIButton m_helpBtn;

		private IXUIButton m_expandBagBtn;

		private XBagWindow m_bagWindow;

		private XWheelOfFortuneHandler _WheelOfFortune;

		private XUIPool m_tabTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Dictionary<uint, GameObject> m_tabReddotDic = new Dictionary<uint, GameObject>();

		private Dictionary<ulong, IXUISprite> itemBtnDic = new Dictionary<ulong, IXUISprite>();
	}
}
