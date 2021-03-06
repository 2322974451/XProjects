using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTaskView : DlgBase<XTaskView, XTaskBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/QuestDlg";
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_BtnGo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnGoClicked));
			base.uiBehaviour.m_BtnReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnRewardClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this.doc.TaskRecord.Tasks.Count == 0;
			if (flag)
			{
				this.SetVisibleWithAnimation(false, null);
			}
			this.m_SelectedTab = -1;
			this.m_bFirstOpen = true;
			this.RefreshPage();
			this.m_bFirstOpen = false;
		}

		public void RefreshPage()
		{
			this._RefreshTabs();
		}

		public void TryShowTaskView()
		{
			base.Load();
			bool flag = this.doc.TaskRecord.Tasks.Count == 0;
			if (!flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		public void OnCloseClicked(IXUISprite sp)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		public bool OnBtnRewardClicked(IXUIButton btn)
		{
			this.doc.DoTask(this.doc.CurrentSelect);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public bool OnBtnGoClicked(IXUIButton btn)
		{
			this.doc.DoTask(this.doc.CurrentSelect);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private void OnTabClicked(ulong id)
		{
			this.OnTabSelect((uint)id);
		}

		private void OnTaskClicked(ulong id)
		{
			uint currentSelect = (uint)id;
			this.doc.CurrentSelect = currentSelect;
			this.RefreshRightContent();
		}

		private void _OnTaskClicked(IXUISprite iSp)
		{
			int index = (int)iSp.ID;
			this._OnTaskSelected(index);
		}

		private void _OnTaskSelected(int index)
		{
			bool flag = index < 0 || index >= this.m_TaskListIDs.Count;
			if (!flag)
			{
				uint currentSelect = this.m_TaskListIDs[index];
				this.doc.CurrentSelect = currentSelect;
				GameObject gameObject = this.m_TaskGos[index];
				IXUILabel ixuilabel = gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
				base.uiBehaviour.m_SelectTaskLabel.SetText(ixuilabel.GetText());
				base.uiBehaviour.m_SelectTask.transform.localPosition = gameObject.transform.localPosition;
				this.RefreshRightContent();
			}
		}

		private void _TrySelectTask(uint id)
		{
			bool flag = false;
			for (int i = 0; i < this.m_TaskListIDs.Count; i++)
			{
				bool flag2 = this.m_TaskListIDs[i] == id;
				if (flag2)
				{
					flag = true;
					this._OnTaskSelected(i);
					break;
				}
			}
			bool flag3 = !flag;
			if (flag3)
			{
				this._OnTaskSelected(0);
				base.uiBehaviour.m_TaskListScrollView.ResetPosition();
			}
		}

		public void OnTabSelect(uint type)
		{
			this.m_TaskListIDs.Clear();
			this.m_TaskGos.Clear();
			base.uiBehaviour.m_TasksPool.FakeReturnAll();
			int i = 0;
			int num = 0;
			while (i < this.doc.TaskRecord.Tasks.Count)
			{
				XTaskInfo xtaskInfo = this.doc.TaskRecord.Tasks[i];
				TaskTableNew.RowData tableData = xtaskInfo.TableData;
				bool flag = tableData == null || tableData.TaskType != type;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.m_TasksPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_TasksPool.TplPos.x, base.uiBehaviour.m_TasksPool.TplPos.y - (float)(base.uiBehaviour.m_TasksPool.TplHeight * num), base.uiBehaviour.m_TasksPool.TplPos.z);
					this.m_TaskGos.Add(gameObject);
					this.m_TaskListIDs.Add(xtaskInfo.ID);
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((long)num);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnTaskClicked));
					IXUILabel ixuilabel = gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(tableData.TaskTitle);
					num++;
				}
				i++;
			}
			base.uiBehaviour.m_TasksPool.ActualReturnAll(false);
			bool bFirstOpen = this.m_bFirstOpen;
			if (bFirstOpen)
			{
				base.uiBehaviour.m_TaskListScrollView.ResetPosition();
			}
			this._TrySelectTask(this.doc.CurrentSelect);
		}

		private void _RefreshTabs()
		{
			this.m_TabListIDs.Clear();
			this.m_TabListNames.Clear();
			for (int i = 0; i < this.doc.TaskRecord.Tasks.Count; i++)
			{
				TaskTableNew.RowData tableData = this.doc.TaskRecord.Tasks[i].TableData;
				bool flag = tableData == null;
				if (!flag)
				{
					int j;
					for (j = 0; j < this.m_TabListIDs.Count; j++)
					{
						bool flag2 = this.m_TabListIDs[j] == (int)tableData.TaskType;
						if (flag2)
						{
							break;
						}
					}
					bool flag3 = j == this.m_TabListIDs.Count;
					if (flag3)
					{
						this.m_TabListIDs.Add((int)tableData.TaskType);
					}
				}
			}
			this.m_TabListIDs.Sort(new Comparison<int>(XTaskDocument.SortByType));
			for (int k = 0; k < this.m_TabListIDs.Count; k++)
			{
				this.m_TabListNames.Add(XSingleton<XCommon>.singleton.StringCombine("TaskType", this.m_TabListIDs[k].ToString()));
			}
			base.uiBehaviour.m_Tabs.SetupTabs(this.m_TabListIDs, this.m_TabListNames, new XUITabControl.UITabControlCallback(this.OnTabClicked), true, 1f, this.m_SelectedTab, true);
		}

		public void RefreshRightContent()
		{
			TaskTableNew.RowData taskData = XTaskDocument.GetTaskData(this.doc.CurrentSelect);
			bool flag = taskData == null;
			if (!flag)
			{
				XTaskInfo taskInfo = this.doc.GetTaskInfo(this.doc.CurrentSelect);
				bool flag2 = taskInfo == null;
				if (!flag2)
				{
					base.uiBehaviour.m_Target.InputText = this.doc.ParseTaskDesc(taskData, taskInfo, false);
					base.uiBehaviour.m_Description.InputText = taskData.TaskDesc;
					base.uiBehaviour.m_ItemPool.FakeReturnAll();
					for (int i = 0; i < taskData.RewardItem.Count; i++)
					{
						GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_ItemPool.TplPos.x + (float)(base.uiBehaviour.m_ItemPool.TplWidth * i), base.uiBehaviour.m_ItemPool.TplPos.y, base.uiBehaviour.m_ItemPool.TplPos.z);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)taskData.RewardItem[0, 0], (int)taskData.RewardItem[0, 1], false);
					}
					base.uiBehaviour.m_ItemPool.ActualReturnAll(false);
					base.uiBehaviour.m_BtnGo.SetVisible(taskInfo.Status != TaskStatus.TaskStatus_Finish);
					base.uiBehaviour.m_BtnReward.SetVisible(taskInfo.Status == TaskStatus.TaskStatus_Finish);
				}
			}
		}

		private XTaskDocument doc;

		private List<int> m_TabListIDs = new List<int>();

		private List<string> m_TabListNames = new List<string>();

		private List<uint> m_TaskListIDs = new List<uint>();

		private List<GameObject> m_TaskGos = new List<GameObject>();

		private int m_SelectedTab = -1;

		private bool m_bFirstOpen = false;
	}
}
