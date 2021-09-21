using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A61 RID: 2657
	internal class XShowSameQualityItemsView : DlgBase<XShowSameQualityItemsView, XShowSameQualityItemsBehavior>
	{
		// Token: 0x17002F17 RID: 12055
		// (get) Token: 0x0600A127 RID: 41255 RVA: 0x001B2F18 File Offset: 0x001B1118
		public override string fileName
		{
			get
			{
				return "Guild/ShowSameQualityDlg";
			}
		}

		// Token: 0x17002F18 RID: 12056
		// (get) Token: 0x0600A128 RID: 41256 RVA: 0x001B2F30 File Offset: 0x001B1130
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A129 RID: 41257 RVA: 0x001B2F43 File Offset: 0x001B1143
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600A12A RID: 41258 RVA: 0x001B2F4D File Offset: 0x001B114D
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600A12B RID: 41259 RVA: 0x001B2F57 File Offset: 0x001B1157
		protected override void OnUnload()
		{
			this._handler = null;
			base.OnUnload();
		}

		// Token: 0x0600A12C RID: 41260 RVA: 0x001B2F68 File Offset: 0x001B1168
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.OkBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOkBtnClicked));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnWrapContentInit));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateWrapContentItem));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseView));
		}

		// Token: 0x0600A12D RID: 41261 RVA: 0x001B2FF1 File Offset: 0x001B11F1
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		// Token: 0x0600A12E RID: 41262 RVA: 0x001B3002 File Offset: 0x001B1202
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600A12F RID: 41263 RVA: 0x001B300C File Offset: 0x001B120C
		private void OnWrapContentInit(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.Find("Item1/Count/Add").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddItem));
			IXUISprite ixuisprite2 = itemTransform.Find("Item1/Count/Sub").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSubItem));
			IXUISprite ixuisprite3 = itemTransform.Find("Item2/Count/Add").GetComponent("XUISprite") as IXUISprite;
			ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddItem));
			IXUISprite ixuisprite4 = itemTransform.Find("Item2/Count/Sub").GetComponent("XUISprite") as IXUISprite;
			ixuisprite4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSubItem));
		}

		// Token: 0x0600A130 RID: 41264 RVA: 0x001B30D4 File Offset: 0x001B12D4
		private void OnSubItem(IXUISprite uiSprite)
		{
			int num = (int)uiSprite.ID;
			bool flag = num < this._itemList.Count;
			if (flag)
			{
				Transform transform = uiSprite.gameObject.transform.parent.FindChild("selNum");
				IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
				int itemID = this._itemList[num].itemID;
				int itemCount = this._itemList[num].itemCount;
				bool flag2 = this._itemIDAndNumber.ContainsKey(num);
				if (flag2)
				{
					bool flag3 = this._itemIDAndNumber[num].Count > 1;
					if (flag3)
					{
						this._itemIDAndNumber[num].RemoveAt(this._itemIDAndNumber[num].Count - 1);
					}
					else
					{
						this._itemIDAndNumber.Remove(num);
					}
					this._totalNumber--;
					this._curProgress--;
					ixuilabel.SetText((this._itemIDAndNumber.ContainsKey(num) ? this._itemIDAndNumber[num].Count : 0).ToString());
					base.uiBehaviour.progressLabel.SetText(this._curProgress + "/" + this._maxNeeded);
				}
			}
		}

		// Token: 0x0600A131 RID: 41265 RVA: 0x001B323C File Offset: 0x001B143C
		private void OnAddItem(IXUISprite uiSprite)
		{
			int num = (int)uiSprite.ID;
			bool flag = num < this._itemList.Count;
			if (flag)
			{
				Transform transform = uiSprite.gameObject.transform.parent.FindChild("selNum");
				IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
				int itemCount = this._itemList[num].itemCount;
				bool flag2 = this._itemIDAndNumber.ContainsKey(num);
				if (flag2)
				{
					bool flag3 = this._curProgress < this._maxNeeded;
					if (flag3)
					{
						bool flag4 = this._itemIDAndNumber[num].Count < this._itemList[num].itemCount;
						if (flag4)
						{
							this._itemIDAndNumber[num].Add(this._itemList[num].uid);
							this._curProgress++;
							this._totalNumber++;
							ixuilabel.SetText(this._itemIDAndNumber[num].Count.ToString());
							base.uiBehaviour.progressLabel.SetText(this._curProgress + "/" + this._maxNeeded);
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ItemNumberUpToMost"), "fece00");
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DoNotNeedMore"), "fece00");
					}
				}
				else
				{
					bool flag5 = this._curProgress < this._maxNeeded;
					if (flag5)
					{
						this._itemIDAndNumber.Add(num, new List<ulong>());
						this._itemIDAndNumber[num].Add(this._itemList[num].uid);
						this._curProgress++;
						this._totalNumber++;
						ixuilabel.SetText(this._itemIDAndNumber[num].Count.ToString());
						base.uiBehaviour.progressLabel.SetText(this._curProgress + "/" + this._maxNeeded);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DoNotNeedMore"), "fece00");
					}
				}
			}
		}

		// Token: 0x0600A132 RID: 41266 RVA: 0x001B34C4 File Offset: 0x001B16C4
		private void OnUpdateWrapContentItem(Transform itemTransform, int index)
		{
			bool flag = index * 2 >= this._itemList.Count;
			if (!flag)
			{
				Transform transform = itemTransform.Find("Item1");
				transform.gameObject.SetActive(true);
				int num = 2 * index;
				XItem info = this._itemList[num];
				this.UpdateSubItem(transform, info, num);
				Transform transform2 = itemTransform.Find("Item2");
				int num2 = num + 1;
				bool flag2 = num2 >= this._itemList.Count;
				if (flag2)
				{
					transform2.gameObject.SetActive(false);
				}
				else
				{
					transform2.gameObject.SetActive(true);
					XItem info2 = this._itemList[num2];
					this.UpdateSubItem(transform2, info2, num2);
				}
			}
		}

		// Token: 0x0600A133 RID: 41267 RVA: 0x001B3588 File Offset: 0x001B1788
		private void UpdateSubItem(Transform item, XItem info, int index)
		{
			IXUISprite ixuisprite = item.Find("Count/Add").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)index);
			IXUISprite ixuisprite2 = item.Find("Count/Sub").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.ID = (ulong)((long)index);
			int num = this._itemIDAndNumber.ContainsKey(index) ? this._itemIDAndNumber[index].Count : 0;
			IXUILabel ixuilabel = item.Find("Count/selNum").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(num.ToString());
			GameObject gameObject = item.Find("Item").gameObject;
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(gameObject, info);
			IXUISprite ixuisprite3 = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite3.ID = info.uid;
			ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
		}

		// Token: 0x0600A134 RID: 41268 RVA: 0x001B3690 File Offset: 0x001B1890
		private void OnClickItemIcon(IXUISprite spr)
		{
			XItem xitem = null;
			for (int i = 0; i < this._itemList.Count; i++)
			{
				bool flag = this._itemList[i].uid == spr.ID;
				if (flag)
				{
					xitem = this._itemList[i];
					break;
				}
			}
			bool flag2 = xitem != null;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(xitem, spr, false, 0U);
			}
		}

		// Token: 0x0600A135 RID: 41269 RVA: 0x001B3702 File Offset: 0x001B1902
		protected override void OnHide()
		{
			this.ClearData();
			base.OnHide();
		}

		// Token: 0x0600A136 RID: 41270 RVA: 0x001B3713 File Offset: 0x001B1913
		private void ClearData()
		{
			this._handler = null;
			this._totalNumber = 0;
			this._curProgress = 0;
			this._itemIDAndNumber.Clear();
			this._itemList.Clear();
			this._maxNeeded = 0;
		}

		// Token: 0x0600A137 RID: 41271 RVA: 0x001B374C File Offset: 0x001B194C
		public void ShowView(XShowSameQualityItemsView.SelectItemsHandler handler, ItemType type, ItemQuality quality, string tip, int maxNeeded, int current = 0)
		{
			this._handler = handler;
			this._itemType = type;
			this._itemQuality = quality;
			this._tip = tip;
			this._maxNeeded = maxNeeded;
			this._curProgress = current;
			this._itemList = XBagDocument.BagDoc.GetItemsByTypeAndQuality(1UL << (int)this._itemType, this._itemQuality);
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600A138 RID: 41272 RVA: 0x001B37B2 File Offset: 0x001B19B2
		public void ShowView(XShowSameQualityItemsView.SelectItemsHandler handler, List<XItem> itemList, string tip, int maxNeeded, int current = 0)
		{
			this._handler = handler;
			this._tip = tip;
			this._maxNeeded = maxNeeded;
			this._curProgress = current;
			this._itemList = itemList;
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600A139 RID: 41273 RVA: 0x001B37E4 File Offset: 0x001B19E4
		private void RefreshUI()
		{
			this._itemIDAndNumber.Clear();
			this._totalNumber = 0;
			base.uiBehaviour.progressLabel.SetText(this._curProgress + "/" + this._maxNeeded);
			this._itemList.Sort(new Comparison<XItem>(this.SortItemList));
			base.uiBehaviour.WrapContent.SetContentCount((this._itemList.Count + 1) / 2, false);
			base.uiBehaviour.ScrollView.ResetPosition();
			base.uiBehaviour.TipStr.SetText(this._tip);
		}

		// Token: 0x0600A13A RID: 41274 RVA: 0x001B3898 File Offset: 0x001B1A98
		private int SortItemList(XItem x, XItem y)
		{
			bool flag = x.itemConf.ReqLevel != y.itemConf.ReqLevel;
			int result;
			if (flag)
			{
				result = (int)(x.itemConf.ReqLevel - y.itemConf.ReqLevel);
			}
			else
			{
				result = x.itemID - y.itemID;
			}
			return result;
		}

		// Token: 0x0600A13B RID: 41275 RVA: 0x001B38F0 File Offset: 0x001B1AF0
		private bool OnOkBtnClicked(IXUIButton button)
		{
			List<ulong> list = new List<ulong>();
			foreach (List<ulong> collection in this._itemIDAndNumber.Values)
			{
				list.AddRange(collection);
			}
			bool flag = list.Count == 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ItemNoSelected"), "fece00");
			}
			else
			{
				bool flag2 = this._handler != null;
				if (flag2)
				{
					this._handler(list);
				}
				this.Close();
			}
			return true;
		}

		// Token: 0x0600A13C RID: 41276 RVA: 0x001B39AC File Offset: 0x001B1BAC
		private void Close()
		{
			this._itemList.Clear();
			this._handler = null;
			this._tip = "";
			this.SetVisible(false, true);
		}

		// Token: 0x0600A13D RID: 41277 RVA: 0x001B39D8 File Offset: 0x001B1BD8
		private bool OnCloseView(IXUIButton button)
		{
			this.Close();
			return true;
		}

		// Token: 0x040039F6 RID: 14838
		private XShowSameQualityItemsView.SelectItemsHandler _handler = null;

		// Token: 0x040039F7 RID: 14839
		private List<XItem> _itemList = new List<XItem>();

		// Token: 0x040039F8 RID: 14840
		private ItemType _itemType;

		// Token: 0x040039F9 RID: 14841
		private ItemQuality _itemQuality;

		// Token: 0x040039FA RID: 14842
		private string _tip;

		// Token: 0x040039FB RID: 14843
		private Dictionary<int, List<ulong>> _itemIDAndNumber = new Dictionary<int, List<ulong>>();

		// Token: 0x040039FC RID: 14844
		private int _totalNumber = 0;

		// Token: 0x040039FD RID: 14845
		private int _maxNeeded;

		// Token: 0x040039FE RID: 14846
		private int _curProgress = 0;

		// Token: 0x0200198C RID: 6540
		// (Invoke) Token: 0x0601101B RID: 69659
		public delegate void SelectItemsHandler(List<ulong> itemList);
	}
}
