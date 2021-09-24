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

	internal class XBackFlowTasksHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Hall/BfTaskHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._scrollView = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this._wrapcontent = (base.transform.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrapcontent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnInitWrapcontent));
			this._wrapcontent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateWrapContent));
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.RefreshUI();
		}

		private void RefreshUI()
		{
			List<SpActivityTask> backflowTaskList = XBackFlowDocument.Doc.GetBackflowTaskList();
			this._wrapcontent.SetContentCount(backflowTaskList.Count, false);
			this._scrollView.ResetPosition();
		}

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

		private void OnInitWrapcontent(Transform itemTransform, int index)
		{
			IXUIButton ixuibutton = itemTransform.Find("Response/GetButton").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetTaskReward));
			IXUIButton ixuibutton2 = itemTransform.Find("Response/GetReward").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetTaskReward));
		}

		private IXUIWrapContent _wrapcontent;

		private IXUIScrollView _scrollView;
	}
}
