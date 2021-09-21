using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A1F RID: 2591
	internal class XBackFlowTasksHandler : DlgHandlerBase
	{
		// Token: 0x17002EBE RID: 11966
		// (get) Token: 0x06009E70 RID: 40560 RVA: 0x001A0530 File Offset: 0x0019E730
		protected override string FileName
		{
			get
			{
				return "Hall/BfTaskHandler";
			}
		}

		// Token: 0x06009E71 RID: 40561 RVA: 0x001A0548 File Offset: 0x0019E748
		protected override void Init()
		{
			base.Init();
			this._scrollView = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this._wrapcontent = (base.transform.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrapcontent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnInitWrapcontent));
			this._wrapcontent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateWrapContent));
		}

		// Token: 0x06009E72 RID: 40562 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06009E73 RID: 40563 RVA: 0x001A05D7 File Offset: 0x0019E7D7
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		// Token: 0x06009E74 RID: 40564 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009E75 RID: 40565 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06009E76 RID: 40566 RVA: 0x001A05E8 File Offset: 0x0019E7E8
		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshUI();
		}

		// Token: 0x06009E77 RID: 40567 RVA: 0x001A05FC File Offset: 0x0019E7FC
		private void RefreshUI()
		{
			List<SpActivityTask> backflowTaskList = XBackFlowDocument.Doc.GetBackflowTaskList();
			this._wrapcontent.SetContentCount(backflowTaskList.Count, false);
			this._scrollView.ResetPosition();
		}

		// Token: 0x06009E78 RID: 40568 RVA: 0x001A0634 File Offset: 0x0019E834
		private void OnUpdateWrapContent(Transform itemTransform, int index)
		{
			List<SpActivityTask> backflowTaskList = XBackFlowDocument.Doc.GetBackflowTaskList();
			bool flag = index < backflowTaskList.Count;
			if (flag)
			{
				SuperActivityTask.RowData dataByActivityByTypeID = XTempActivityDocument.Doc.GetDataByActivityByTypeID(5U, backflowTaskList[index].taskid);
				bool flag2 = dataByActivityByTypeID != null;
				if (flag2)
				{
					string[] array = dataByActivityByTypeID.title.Split(new char[]
					{
						'='
					});
					IXUILabel ixuilabel = itemTransform.Find("Task").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = itemTransform.Find("Task/TaskDec").GetComponent("XUILabel") as IXUILabel;
					bool flag3 = array.Length != 0;
					if (flag3)
					{
						ixuilabel.SetText(array[0]);
					}
					else
					{
						ixuilabel.SetText("");
					}
					bool flag4 = array.Length > 1;
					if (flag4)
					{
						ixuilabel2.SetText(array[1]);
					}
					else
					{
						ixuilabel2.SetText("");
					}
					IXUILabel ixuilabel3 = itemTransform.Find("Progress").GetComponent("XUILabel") as IXUILabel;
					int num = (int)((backflowTaskList[index].state == 0U) ? backflowTaskList[index].progress : ((uint)dataByActivityByTypeID.cnt));
					ixuilabel3.SetText(num + "/" + dataByActivityByTypeID.cnt);
					Transform transform = itemTransform.Find("AwardList");
					int i = 0;
					bool flag5 = dataByActivityByTypeID.items.count > 0;
					if (flag5)
					{
						int num2 = Mathf.Min((int)dataByActivityByTypeID.items.count, transform.childCount);
						while (i < num2)
						{
							Transform child = transform.GetChild(i);
							child.gameObject.SetActive(true);
							XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(child.gameObject, (int)dataByActivityByTypeID.items[i, 0], (int)dataByActivityByTypeID.items[i, 1], true);
							IXUISprite ixuisprite = child.gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
							ixuisprite.ID = (ulong)dataByActivityByTypeID.items[i, 0];
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
							i++;
						}
					}
					while (i < transform.childCount)
					{
						transform.GetChild(i++).gameObject.SetActive(false);
					}
					IXUIButton ixuibutton = itemTransform.Find("Response/GetReward").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)((long)index);
					IXUIButton ixuibutton2 = itemTransform.Find("Response/GetButton").GetComponent("XUIButton") as IXUIButton;
					ixuibutton2.ID = (ulong)((long)index);
					Transform transform2 = itemTransform.Find("Response/HadGet");
					ixuibutton.gameObject.SetActive(backflowTaskList[index].state == 1U);
					ixuibutton2.gameObject.SetActive(backflowTaskList[index].state == 0U);
					transform2.gameObject.SetActive(backflowTaskList[index].state == 2U);
				}
			}
		}

		// Token: 0x06009E79 RID: 40569 RVA: 0x001A0964 File Offset: 0x0019EB64
		private bool OnGetTaskReward(IXUIButton button)
		{
			int num = (int)button.ID;
			List<SpActivityTask> backflowTaskList = XBackFlowDocument.Doc.GetBackflowTaskList();
			bool flag = num < backflowTaskList.Count;
			if (flag)
			{
				SpActivityTask spActivityTask = backflowTaskList[num];
				bool flag2 = spActivityTask.state == 0U;
				if (flag2)
				{
					SuperActivityTask.RowData[] table = XTempActivityDocument.SuperActivityTaskTable.Table;
					for (int i = 0; i < table.Length; i++)
					{
						bool flag3 = table[i].taskid == spActivityTask.taskid;
						if (flag3)
						{
							SuperActivityTask.RowData rowData = table[i];
							bool flag4 = rowData.arg != null && rowData.arg.Length != 0;
							if (flag4)
							{
								bool flag5 = rowData.arg[0] == 1;
								if (flag5)
								{
									DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.SelectChapter(rowData.arg[1], (uint)rowData.arg[2]);
								}
								else
								{
									bool flag6 = rowData.arg[0] == 2;
									if (flag6)
									{
										DlgBase<TheExpView, TheExpBehaviour>.singleton.ShowView(rowData.arg[1]);
									}
								}
							}
							else
							{
								XSingleton<XGameSysMgr>.singleton.OpenSystem((int)rowData.jump);
							}
							break;
						}
					}
				}
				else
				{
					XTempActivityDocument.Doc.GetActivityAwards(5U, spActivityTask.taskid);
				}
			}
			return true;
		}

		// Token: 0x06009E7A RID: 40570 RVA: 0x001A0AB4 File Offset: 0x0019ECB4
		private void OnInitWrapcontent(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("Response/GetButton").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetTaskReward));
			IXUIButton ixuibutton2 = itemTransform.Find("Response/GetReward").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetTaskReward));
		}

		// Token: 0x0400383E RID: 14398
		private IXUIWrapContent _wrapcontent;

		// Token: 0x0400383F RID: 14399
		private IXUIScrollView _scrollView;
	}
}
