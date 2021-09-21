using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009C1 RID: 2497
	internal class XShowGetItemDocument : XDocComponent
	{
		// Token: 0x17002D8F RID: 11663
		// (get) Token: 0x06009747 RID: 38727 RVA: 0x0016F4AC File Offset: 0x0016D6AC
		public override uint ID
		{
			get
			{
				return XShowGetItemDocument.uuID;
			}
		}

		// Token: 0x17002D90 RID: 11664
		// (get) Token: 0x06009748 RID: 38728 RVA: 0x0016F4C4 File Offset: 0x0016D6C4
		// (set) Token: 0x06009749 RID: 38729 RVA: 0x0016F4DC File Offset: 0x0016D6DC
		public bool bBlock
		{
			get
			{
				return this.m_bBlock;
			}
			set
			{
				this.m_bBlock = value;
				bool flag = !this.m_bBlock;
				if (flag)
				{
					this.CheckScene();
				}
				else
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this.ShowItemToken);
					this.ShowItemToken = 0U;
				}
			}
		}

		// Token: 0x17002D91 RID: 11665
		// (get) Token: 0x0600974A RID: 38730 RVA: 0x0016F524 File Offset: 0x0016D724
		// (set) Token: 0x0600974B RID: 38731 RVA: 0x0016F53C File Offset: 0x0016D73C
		public bool bIgonre
		{
			get
			{
				return this.m_bIgnore;
			}
			set
			{
				this.m_bIgnore = value;
			}
		}

		// Token: 0x0600974C RID: 38732 RVA: 0x0016F546 File Offset: 0x0016D746
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.ItemQueue.Clear();
			this.StringQueue.Clear();
			this.StringQueueID = 0U;
			this.ItemFlashList.Clear();
		}

		// Token: 0x0600974D RID: 38733 RVA: 0x0016F57C File Offset: 0x0016D77C
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnAddVirtualItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnNumChange));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnChangeFinished));
		}

		// Token: 0x0600974E RID: 38734 RVA: 0x0014E32B File Offset: 0x0014C52B
		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		// Token: 0x0600974F RID: 38735 RVA: 0x0016F5E5 File Offset: 0x0016D7E5
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			this.m_bBlock = false;
			this.m_bIgnore = false;
			this.CheckScene();
		}

		// Token: 0x06009750 RID: 38736 RVA: 0x0016F604 File Offset: 0x0016D804
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.ShowItemToken);
			this.ShowItemToken = 0U;
			bool flag = DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.SetVisible(false, true);
			}
		}

		// Token: 0x06009751 RID: 38737 RVA: 0x0016F650 File Offset: 0x0016D850
		private bool CampareItems(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			int i = 0;
			while (i < xaddItemEventArgs.items.Count)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(xaddItemEventArgs.items[i].itemID);
				bool flag = itemConf != null;
				if (flag)
				{
					bool flag2 = !XBagDocument.ItemCanShowTips((uint)xaddItemEventArgs.items[i].itemID);
					if (!flag2)
					{
						bool flag3 = xaddItemEventArgs.items[i].itemCount >= itemConf.OverCnt;
						if (flag3)
						{
							return true;
						}
					}
				}
				IL_77:
				i++;
				continue;
				goto IL_77;
			}
			return false;
		}

		// Token: 0x06009752 RID: 38738 RVA: 0x0016F6F8 File Offset: 0x0016D8F8
		private bool DealwithFlashItems(XAddItemEventArgs arg)
		{
			bool flag = false;
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			for (int i = 0; i < arg.items.Count; i++)
			{
				bool flag2 = specificDocument.IsGiftBagItem(arg.items[i].itemID);
				if (flag2)
				{
					flag = true;
					break;
				}
			}
			bool flag3 = flag;
			if (flag3)
			{
				int j = 0;
				while (j < arg.items.Count)
				{
					bool flag4 = XBagDocument.GetItemConf(arg.items[j].itemID) != null;
					if (flag4)
					{
						bool flag5 = !XBagDocument.ItemCanShowTips((uint)arg.items[j].itemID);
						if (!flag5)
						{
							ItemBrief itemBrief = new ItemBrief();
							itemBrief.itemID = (uint)arg.items[j].itemID;
							itemBrief.itemCount = (uint)arg.items[j].itemCount;
							this.ItemFlashList.Add(itemBrief);
						}
					}
					IL_EE:
					j++;
					continue;
					goto IL_EE;
				}
			}
			return flag;
		}

		// Token: 0x06009753 RID: 38739 RVA: 0x0016F81C File Offset: 0x0016DA1C
		protected bool OnAddItem(XEventArgs args)
		{
			bool bIgnore = this.m_bIgnore;
			bool result;
			if (bIgnore)
			{
				result = false;
			}
			else
			{
				XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
				bool flag = !xaddItemEventArgs.bNew;
				if (flag)
				{
					result = true;
				}
				else
				{
					bool flag2 = this.DealwithFlashItems(xaddItemEventArgs);
					if (flag2)
					{
						this.m_bDirty = true;
						result = true;
					}
					else
					{
						bool flag3 = !this.CampareItems(args);
						if (flag3)
						{
							int i = 0;
							while (i < xaddItemEventArgs.items.Count)
							{
								bool flag4 = XBagDocument.GetItemConf(xaddItemEventArgs.items[i].itemID) != null;
								if (flag4)
								{
									bool flag5 = !XBagDocument.ItemCanShowTips((uint)xaddItemEventArgs.items[i].itemID);
									if (!flag5)
									{
										bool flag6 = !this.QueueIsFull;
										if (flag6)
										{
											XItem item = new XNormalItem
											{
												itemID = xaddItemEventArgs.items[i].itemID,
												itemCount = xaddItemEventArgs.items[i].itemCount
											};
											this.ItemQueue.Enqueue(item);
											bool flag7 = this.ItemQueue.Count >= 10;
											if (flag7)
											{
												this.QueueIsFull = true;
											}
										}
										else
										{
											this.ExceedCount++;
										}
									}
								}
								IL_138:
								i++;
								continue;
								goto IL_138;
							}
						}
						else
						{
							bool flag8 = this.m_ItemList == null;
							if (flag8)
							{
								this.m_ItemList = new List<XItem>();
							}
							for (int j = 0; j < xaddItemEventArgs.items.Count; j++)
							{
								bool flag9 = !XBagDocument.ItemCanShowTips((uint)xaddItemEventArgs.items[j].itemID);
								if (!flag9)
								{
									XItem item2 = new XNormalItem
									{
										itemID = xaddItemEventArgs.items[j].itemID,
										itemCount = xaddItemEventArgs.items[j].itemCount
									};
									this.m_ItemList.Add(item2);
								}
							}
						}
						this.m_bDirty = true;
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06009754 RID: 38740 RVA: 0x0016FA39 File Offset: 0x0016DC39
		public void ClearItemQueue()
		{
			this.ItemQueue.Clear();
			XShowGetItemDocument.ItemUIQueue.Clear();
			this.StringQueue.Clear();
			this.QueueIsFull = false;
			DlgBase<XShowGetItemUIView, XShowGetItemUIBehaviour>.singleton.isPlaying = false;
		}

		// Token: 0x06009755 RID: 38741 RVA: 0x0016FA74 File Offset: 0x0016DC74
		protected bool OnAddVirtualItem(XEventArgs args)
		{
			bool bIgnore = this.m_bIgnore;
			bool result;
			if (bIgnore)
			{
				result = false;
			}
			else
			{
				XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
				bool flag = !XBagDocument.ItemCanShowTips((uint)xvirtualItemChangedEventArgs.itemID);
				if (flag)
				{
					result = true;
				}
				else
				{
					XItem xitem = new XNormalItem();
					xitem.itemID = xvirtualItemChangedEventArgs.itemID;
					bool flag2 = xvirtualItemChangedEventArgs.itemID != 4;
					if (flag2)
					{
						xitem.itemCount = (int)(xvirtualItemChangedEventArgs.newValue - xvirtualItemChangedEventArgs.oldValue);
					}
					else
					{
						xitem.itemCount = (int)xvirtualItemChangedEventArgs.newValue;
					}
					bool flag3 = xitem.itemCount <= 0;
					if (flag3)
					{
						result = true;
					}
					else
					{
						ItemList.RowData itemConf = XBagDocument.GetItemConf(xitem.itemID);
						bool flag4 = xitem.itemCount < itemConf.OverCnt;
						if (flag4)
						{
							bool flag5 = XBagDocument.GetItemConf(xitem.itemID) != null;
							if (flag5)
							{
								bool flag6 = !this.QueueIsFull;
								if (flag6)
								{
									this.ItemQueue.Enqueue(xitem);
									bool flag7 = this.ItemQueue.Count >= 10;
									if (flag7)
									{
										this.QueueIsFull = true;
									}
								}
								else
								{
									this.ExceedCount++;
								}
							}
						}
						else
						{
							bool flag8 = this.m_ItemList == null;
							if (flag8)
							{
								this.m_ItemList = new List<XItem>();
							}
							this.m_ItemList.Add(xitem);
						}
						this.m_bDirty = true;
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06009756 RID: 38742 RVA: 0x0016FBD8 File Offset: 0x0016DDD8
		protected bool OnNumChange(XEventArgs args)
		{
			bool bIgnore = this.m_bIgnore;
			bool result;
			if (bIgnore)
			{
				result = false;
			}
			else
			{
				XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
				bool flag = !XBagDocument.ItemCanShowTips((uint)xitemNumChangedEventArgs.item.itemID);
				if (flag)
				{
					result = true;
				}
				else
				{
					bool flag2 = xitemNumChangedEventArgs.item.itemCount <= xitemNumChangedEventArgs.oldCount;
					if (flag2)
					{
						result = true;
					}
					else
					{
						bool flag3 = !xitemNumChangedEventArgs.bNew;
						if (flag3)
						{
							result = true;
						}
						else
						{
							XItem xitem = new XNormalItem();
							xitem.itemID = xitemNumChangedEventArgs.item.itemID;
							xitem.itemCount = xitemNumChangedEventArgs.item.itemCount - xitemNumChangedEventArgs.oldCount;
							ItemList.RowData itemConf = XBagDocument.GetItemConf(xitem.itemID);
							bool flag4 = xitem.itemCount < itemConf.OverCnt;
							if (flag4)
							{
								bool flag5 = XBagDocument.GetItemConf(xitem.itemID) != null;
								if (flag5)
								{
									bool flag6 = !this.QueueIsFull;
									if (flag6)
									{
										this.ItemQueue.Enqueue(xitem);
										bool flag7 = this.ItemQueue.Count >= 10;
										if (flag7)
										{
											this.QueueIsFull = true;
										}
									}
									else
									{
										this.ExceedCount++;
									}
								}
							}
							else
							{
								bool flag8 = this.m_ItemList == null;
								if (flag8)
								{
									this.m_ItemList = new List<XItem>();
								}
								this.m_ItemList.Add(xitem);
							}
							this.m_bDirty = true;
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06009757 RID: 38743 RVA: 0x0016FD4C File Offset: 0x0016DF4C
		protected bool OnChangeFinished(XEventArgs args)
		{
			bool bDirty = this.m_bDirty;
			if (bDirty)
			{
				bool flag = this.m_ItemList != null && this.m_ItemList.Count > 0;
				if (flag)
				{
					bool flag2 = true;
					for (int i = 0; i < this.m_ItemList.Count; i++)
					{
						bool flag3 = XBagDocument.GetItemConf(this.m_ItemList[i].itemID) == null;
						if (flag3)
						{
							flag2 = false;
							break;
						}
					}
					bool flag4 = flag2;
					if (flag4)
					{
						XShowGetItemDocument.ItemUIQueue.Enqueue(this.m_ItemList);
					}
					this.m_ItemList = null;
				}
				this.CheckScene();
				this.m_bDirty = false;
			}
			return true;
		}

		// Token: 0x06009758 RID: 38744 RVA: 0x0016FE04 File Offset: 0x0016E004
		private void CheckScene()
		{
			bool bBlock = this.m_bBlock;
			if (!bBlock)
			{
				bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && this.ItemQueue.Count > 0 && this.ShowItemToken == 0U;
				if (flag)
				{
					DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.SetVisible(true, true);
					this.ShowItemToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.4f, new XTimerMgr.ElapsedEventHandler(this.CheckQueueItem), null);
				}
				bool flag2 = this.StringQueue.Count > 0 && this.ShowItemToken == 0U;
				if (flag2)
				{
					DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.SetVisible(true, true);
					this.ShowItemToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.4f, new XTimerMgr.ElapsedEventHandler(this.CheckQueueItem), null);
				}
				this.CheckUIScene();
				this.CheckFlashItemScene();
			}
		}

		// Token: 0x06009759 RID: 38745 RVA: 0x0016FEDF File Offset: 0x0016E0DF
		private void CheckUIScene(IXUITweenTool tween)
		{
			this.CheckUIScene();
		}

		// Token: 0x0600975A RID: 38746 RVA: 0x0016FEEC File Offset: 0x0016E0EC
		private void CheckUIScene()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				bool flag2 = XShowGetItemDocument.ItemUIQueue.Count > 0 && !DlgBase<XShowGetItemUIView, XShowGetItemUIBehaviour>.singleton.isPlaying;
				if (flag2)
				{
					List<XItem> list = XShowGetItemDocument.ItemUIQueue.Peek();
					bool flag3 = list != null && list.Count > 0;
					if (flag3)
					{
						DlgBase<XShowGetItemUIView, XShowGetItemUIBehaviour>.singleton.ShowItems(list, new OnTweenFinishEventHandler(this.CheckUIScene));
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("list is null", null, null, null, null, null);
					}
					bool flag4 = XShowGetItemDocument.ItemUIQueue.Count > 0;
					if (flag4)
					{
						XShowGetItemDocument.ItemUIQueue.Dequeue();
					}
				}
			}
		}

		// Token: 0x0600975B RID: 38747 RVA: 0x0016FFA8 File Offset: 0x0016E1A8
		private void CheckFlashItemScene()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				bool flag2 = this.ItemFlashList.Count > 0 && !DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					bool inTutorial = XSingleton<XTutorialMgr>.singleton.InTutorial;
					if (inTutorial)
					{
						List<XItem> list = new List<XItem>();
						for (int i = 0; i < this.ItemFlashList.Count; i++)
						{
							list.Add(new XNormalItem
							{
								itemID = (int)this.ItemFlashList[i].itemID,
								itemCount = (int)this.ItemFlashList[i].itemCount
							});
						}
						XShowGetItemDocument.ItemUIQueue.Enqueue(list);
						this.ItemFlashList.Clear();
						this.CheckUIScene();
					}
					else
					{
						DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.Show(this.ItemFlashList, new Action(this.CheckFlashItemScene));
						this.ItemFlashList.Clear();
					}
				}
			}
		}

		// Token: 0x0600975C RID: 38748 RVA: 0x001700C4 File Offset: 0x0016E2C4
		public void CheckQueueItem(object o = null)
		{
			bool flag = this.ItemQueue.Count != 0 && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				bool flag2 = !this.m_bBlock;
				if (flag2)
				{
					DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.SetAlpha(1f);
					DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.ShowItem(this.ItemQueue.Dequeue());
				}
			}
			else
			{
				bool flag3 = this.QueueIsFull && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
				if (flag3)
				{
					this.QueueIsFull = false;
					bool flag4 = this.ExceedCount > 0;
					if (flag4)
					{
						bool flag5 = DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.IsVisible();
						if (flag5)
						{
							DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.SetAlpha(1f);
						}
						DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.ShowFullTip(this.ExceedCount);
					}
					this.ExceedCount = 0;
				}
				else
				{
					bool flag6 = this.StringQueue.Count != 0;
					if (flag6)
					{
						DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.SetAlpha(1f);
						StringTip stringTip = this.StringQueue.Dequeue();
						DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.ShowString(stringTip.str, stringTip.id);
					}
				}
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this.ShowItemToken);
			this.ShowItemToken = 0U;
			bool flag7 = !this.m_bBlock && DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.IsVisible();
			if (flag7)
			{
				this.ShowItemToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.4f, new XTimerMgr.ElapsedEventHandler(this.CheckQueueItem), null);
			}
		}

		// Token: 0x0600975D RID: 38749 RVA: 0x00170250 File Offset: 0x0016E450
		public uint AddTip(string str)
		{
			this.StringQueueID += 1U;
			StringTip item = default(StringTip);
			item.str = str;
			item.id = this.StringQueueID;
			this.StringQueue.Enqueue(item);
			this.CheckScene();
			return this.StringQueueID;
		}

		// Token: 0x0600975E RID: 38750 RVA: 0x001702A8 File Offset: 0x0016E4A8
		public void EditTip(string str, uint id)
		{
			bool flag = !DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.EditString(str, id);
			}
		}

		// Token: 0x0600975F RID: 38751 RVA: 0x001702D6 File Offset: 0x0016E4D6
		public void StopShowItem()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.ShowItemToken);
			this.ShowItemToken = 0U;
		}

		// Token: 0x17002D92 RID: 11666
		// (get) Token: 0x06009760 RID: 38752 RVA: 0x001702F4 File Offset: 0x0016E4F4
		public bool IsForbidGetItemUI
		{
			get
			{
				bool flag = XSuperRiskDocument.Doc.GameViewHandler != null;
				return flag && XSuperRiskDocument.Doc.GameViewHandler.IsVisible();
			}
		}

		// Token: 0x17002D93 RID: 11667
		// (get) Token: 0x06009761 RID: 38753 RVA: 0x0017032C File Offset: 0x0016E52C
		// (set) Token: 0x06009762 RID: 38754 RVA: 0x00170344 File Offset: 0x0016E544
		public bool IsForbidByLua
		{
			get
			{
				return this._ForbidByLua;
			}
			set
			{
				XSingleton<XDebug>.singleton.AddErrorLog("set fordie lua  " + value.ToString(), null, null, null, null, null);
				this._ForbidByLua = value;
			}
		}

		// Token: 0x06009763 RID: 38755 RVA: 0x0017036F File Offset: 0x0016E56F
		public void SetForbidByLua(bool bFlag)
		{
			this._ForbidByLua = bFlag;
		}

		// Token: 0x06009764 RID: 38756 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x040033A6 RID: 13222
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ShowGetItemDocument");

		// Token: 0x040033A7 RID: 13223
		public Queue<XItem> ItemQueue = new Queue<XItem>();

		// Token: 0x040033A8 RID: 13224
		public static Queue<List<XItem>> ItemUIQueue = new Queue<List<XItem>>();

		// Token: 0x040033A9 RID: 13225
		public List<ItemBrief> ItemFlashList = new List<ItemBrief>();

		// Token: 0x040033AA RID: 13226
		private Queue<StringTip> StringQueue = new Queue<StringTip>();

		// Token: 0x040033AB RID: 13227
		private uint StringQueueID;

		// Token: 0x040033AC RID: 13228
		private bool QueueIsFull = false;

		// Token: 0x040033AD RID: 13229
		private int ExceedCount = 0;

		// Token: 0x040033AE RID: 13230
		private uint ShowItemToken;

		// Token: 0x040033AF RID: 13231
		private bool _ForbidByLua = false;

		// Token: 0x040033B0 RID: 13232
		private bool m_bBlock;

		// Token: 0x040033B1 RID: 13233
		private bool m_bIgnore;

		// Token: 0x040033B2 RID: 13234
		private bool m_bDirty = false;

		// Token: 0x040033B3 RID: 13235
		private List<XItem> m_ItemList = null;
	}
}
