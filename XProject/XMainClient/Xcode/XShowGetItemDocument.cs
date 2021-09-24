using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XShowGetItemDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XShowGetItemDocument.uuID;
			}
		}

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

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.ItemQueue.Clear();
			this.StringQueue.Clear();
			this.StringQueueID = 0U;
			this.ItemFlashList.Clear();
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnAddVirtualItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnNumChange));
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnChangeFinished));
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			this.m_bBlock = false;
			this.m_bIgnore = false;
			this.CheckScene();
		}

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

		public void ClearItemQueue()
		{
			this.ItemQueue.Clear();
			XShowGetItemDocument.ItemUIQueue.Clear();
			this.StringQueue.Clear();
			this.QueueIsFull = false;
			DlgBase<XShowGetItemUIView, XShowGetItemUIBehaviour>.singleton.isPlaying = false;
		}

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

		private void CheckUIScene(IXUITweenTool tween)
		{
			this.CheckUIScene();
		}

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

		public void EditTip(string str, uint id)
		{
			bool flag = !DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XShowGetItemView, XShowGetItemBehaviour>.singleton.EditString(str, id);
			}
		}

		public void StopShowItem()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.ShowItemToken);
			this.ShowItemToken = 0U;
		}

		public bool IsForbidGetItemUI
		{
			get
			{
				bool flag = XSuperRiskDocument.Doc.GameViewHandler != null;
				return flag && XSuperRiskDocument.Doc.GameViewHandler.IsVisible();
			}
		}

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

		public void SetForbidByLua(bool bFlag)
		{
			this._ForbidByLua = bFlag;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ShowGetItemDocument");

		public Queue<XItem> ItemQueue = new Queue<XItem>();

		public static Queue<List<XItem>> ItemUIQueue = new Queue<List<XItem>>();

		public List<ItemBrief> ItemFlashList = new List<ItemBrief>();

		private Queue<StringTip> StringQueue = new Queue<StringTip>();

		private uint StringQueueID;

		private bool QueueIsFull = false;

		private int ExceedCount = 0;

		private uint ShowItemToken;

		private bool _ForbidByLua = false;

		private bool m_bBlock;

		private bool m_bIgnore;

		private bool m_bDirty = false;

		private List<XItem> m_ItemList = null;
	}
}
