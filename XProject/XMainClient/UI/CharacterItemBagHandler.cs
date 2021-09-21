using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001892 RID: 6290
	internal class CharacterItemBagHandler : DlgHandlerBase
	{
		// Token: 0x170039DC RID: 14812
		// (get) Token: 0x060105F4 RID: 67060 RVA: 0x003FC8BC File Offset: 0x003FAABC
		private XItemMorePowerfulTipMgr newItemMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.NewItemMgr;
			}
		}

		// Token: 0x170039DD RID: 14813
		// (get) Token: 0x060105F5 RID: 67061 RVA: 0x003FC8D8 File Offset: 0x003FAAD8
		private XItemMorePowerfulTipMgr redPointMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.RedPointMgr;
			}
		}

		// Token: 0x170039DE RID: 14814
		// (get) Token: 0x060105F6 RID: 67062 RVA: 0x003FC8F4 File Offset: 0x003FAAF4
		public XWheelOfFortuneHandler WheelOfFortune
		{
			get
			{
				return this._WheelOfFortune;
			}
		}

		// Token: 0x170039DF RID: 14815
		// (get) Token: 0x060105F7 RID: 67063 RVA: 0x003FC90C File Offset: 0x003FAB0C
		protected override string FileName
		{
			get
			{
				return "ItemNew/BagListPanel";
			}
		}

		// Token: 0x060105F8 RID: 67064 RVA: 0x003FC924 File Offset: 0x003FAB24
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

		// Token: 0x060105F9 RID: 67065 RVA: 0x003FCA9D File Offset: 0x003FAC9D
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_expandBagBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBagExpandClicked));
		}

		// Token: 0x060105FA RID: 67066 RVA: 0x003FCABF File Offset: 0x003FACBF
		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.BagType = 0U;
			this.FillTabs();
		}

		// Token: 0x060105FB RID: 67067 RVA: 0x003FCAE0 File Offset: 0x003FACE0
		protected override void OnHide()
		{
			this.m_bagWindow.OnHide();
			this.itemBtnDic.Clear();
			this.newItemMgr.ReturnAll();
			this.redPointMgr.ReturnAll();
			this.m_doc.NewItems.TryClear();
			base.OnHide();
		}

		// Token: 0x060105FC RID: 67068 RVA: 0x003FCB36 File Offset: 0x003FAD36
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshBag();
			this.UpdateTabRedDot();
		}

		// Token: 0x060105FD RID: 67069 RVA: 0x003FCB4E File Offset: 0x003FAD4E
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XWheelOfFortuneHandler>(ref this._WheelOfFortune);
			this.m_doc.Handler = null;
			base.OnUnload();
		}

		// Token: 0x060105FE RID: 67070 RVA: 0x003FCB74 File Offset: 0x003FAD74
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

		// Token: 0x060105FF RID: 67071 RVA: 0x003FCD32 File Offset: 0x003FAF32
		private void FillContent()
		{
			this.RefreshBag();
			this._WheelOfFortune.SetVisible(false);
			this.m_doc.NewItems.bCanClear = true;
		}

		// Token: 0x06010600 RID: 67072 RVA: 0x003FCD5B File Offset: 0x003FAF5B
		private void RefreshBag()
		{
			this.m_bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this.m_doc.GetItem));
			this.m_bagWindow.OnShow();
			this.SetBagNum();
		}

		// Token: 0x06010601 RID: 67073 RVA: 0x003FCD9A File Offset: 0x003FAF9A
		public void Refresh()
		{
			this.m_bagWindow.RefreshWindow();
			this.SetBagNum();
		}

		// Token: 0x06010602 RID: 67074 RVA: 0x003FCDB0 File Offset: 0x003FAFB0
		public void UpdateBag()
		{
			this.itemBtnDic.Clear();
			this.m_bagWindow.UpdateBag();
			this.SetBagNum();
		}

		// Token: 0x06010603 RID: 67075 RVA: 0x003FCDD4 File Offset: 0x003FAFD4
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

		// Token: 0x06010604 RID: 67076 RVA: 0x003FCEA0 File Offset: 0x003FB0A0
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

		// Token: 0x06010605 RID: 67077 RVA: 0x003FCF68 File Offset: 0x003FB168
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

		// Token: 0x06010606 RID: 67078 RVA: 0x003FD142 File Offset: 0x003FB342
		public void AddItem(List<XItem> items)
		{
			this.m_bagWindow.UpdateBag();
		}

		// Token: 0x06010607 RID: 67079 RVA: 0x003FD154 File Offset: 0x003FB354
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

		// Token: 0x06010608 RID: 67080 RVA: 0x003FD1E8 File Offset: 0x003FB3E8
		public void ItemNumChanged(XItem item)
		{
			this.m_bagWindow.UpdateItem(item);
		}

		// Token: 0x06010609 RID: 67081 RVA: 0x003FD1F8 File Offset: 0x003FB3F8
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

		// Token: 0x0601060A RID: 67082 RVA: 0x003FD274 File Offset: 0x003FB474
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

		// Token: 0x0601060B RID: 67083 RVA: 0x003FD338 File Offset: 0x003FB538
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

		// Token: 0x0601060C RID: 67084 RVA: 0x003FD39C File Offset: 0x003FB59C
		public bool OnBagExpandClicked(IXUIButton button)
		{
			XBagDocument.BagDoc.UseBagExpandTicket(BagType.ItemBag);
			return true;
		}

		// Token: 0x0601060D RID: 67085 RVA: 0x003FD3BC File Offset: 0x003FB5BC
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

		// Token: 0x04007620 RID: 30240
		private XCharacterItemDocument m_doc;

		// Token: 0x04007621 RID: 30241
		private IXUILabel m_bagNumLab;

		// Token: 0x04007622 RID: 30242
		private IXUIButton m_helpBtn;

		// Token: 0x04007623 RID: 30243
		private IXUIButton m_expandBagBtn;

		// Token: 0x04007624 RID: 30244
		private XBagWindow m_bagWindow;

		// Token: 0x04007625 RID: 30245
		private XWheelOfFortuneHandler _WheelOfFortune;

		// Token: 0x04007626 RID: 30246
		private XUIPool m_tabTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007627 RID: 30247
		private Dictionary<uint, GameObject> m_tabReddotDic = new Dictionary<uint, GameObject>();

		// Token: 0x04007628 RID: 30248
		private Dictionary<ulong, IXUISprite> itemBtnDic = new Dictionary<ulong, IXUISprite>();
	}
}
