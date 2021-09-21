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
	// Token: 0x02000D11 RID: 3345
	internal class XTaskView : DlgBase<XTaskView, XTaskBehaviour>
	{
		// Token: 0x170032DF RID: 13023
		// (get) Token: 0x0600BAAB RID: 47787 RVA: 0x00262ADC File Offset: 0x00260CDC
		public override string fileName
		{
			get
			{
				return "GameSystem/QuestDlg";
			}
		}

		// Token: 0x170032E0 RID: 13024
		// (get) Token: 0x0600BAAC RID: 47788 RVA: 0x00262AF4 File Offset: 0x00260CF4
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170032E1 RID: 13025
		// (get) Token: 0x0600BAAD RID: 47789 RVA: 0x00262B08 File Offset: 0x00260D08
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170032E2 RID: 13026
		// (get) Token: 0x0600BAAE RID: 47790 RVA: 0x00262B1C File Offset: 0x00260D1C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170032E3 RID: 13027
		// (get) Token: 0x0600BAAF RID: 47791 RVA: 0x00262B30 File Offset: 0x00260D30
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170032E4 RID: 13028
		// (get) Token: 0x0600BAB0 RID: 47792 RVA: 0x00262B44 File Offset: 0x00260D44
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170032E5 RID: 13029
		// (get) Token: 0x0600BAB1 RID: 47793 RVA: 0x00262B58 File Offset: 0x00260D58
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600BAB2 RID: 47794 RVA: 0x00262B6B File Offset: 0x00260D6B
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
		}

		// Token: 0x0600BAB3 RID: 47795 RVA: 0x00262B80 File Offset: 0x00260D80
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_BtnGo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnGoClicked));
			base.uiBehaviour.m_BtnReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnRewardClicked));
		}

		// Token: 0x0600BAB4 RID: 47796 RVA: 0x00262BE8 File Offset: 0x00260DE8
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

		// Token: 0x0600BAB5 RID: 47797 RVA: 0x00262C3E File Offset: 0x00260E3E
		public void RefreshPage()
		{
			this._RefreshTabs();
		}

		// Token: 0x0600BAB6 RID: 47798 RVA: 0x00262C48 File Offset: 0x00260E48
		public void TryShowTaskView()
		{
			base.Load();
			bool flag = this.doc.TaskRecord.Tasks.Count == 0;
			if (!flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x0600BAB7 RID: 47799 RVA: 0x00262C84 File Offset: 0x00260E84
		public void OnCloseClicked(IXUISprite sp)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x0600BAB8 RID: 47800 RVA: 0x00262C90 File Offset: 0x00260E90
		public bool OnBtnRewardClicked(IXUIButton btn)
		{
			this.doc.DoTask(this.doc.CurrentSelect);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600BAB9 RID: 47801 RVA: 0x00262CC4 File Offset: 0x00260EC4
		public bool OnBtnGoClicked(IXUIButton btn)
		{
			this.doc.DoTask(this.doc.CurrentSelect);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600BABA RID: 47802 RVA: 0x00262CF7 File Offset: 0x00260EF7
		private void OnTabClicked(ulong id)
		{
			this.OnTabSelect((uint)id);
		}

		// Token: 0x0600BABB RID: 47803 RVA: 0x00262D04 File Offset: 0x00260F04
		private void OnTaskClicked(ulong id)
		{
			uint currentSelect = (uint)id;
			this.doc.CurrentSelect = currentSelect;
			this.RefreshRightContent();
		}

		// Token: 0x0600BABC RID: 47804 RVA: 0x00262D2C File Offset: 0x00260F2C
		private void _OnTaskClicked(IXUISprite iSp)
		{
			int index = (int)iSp.ID;
			this._OnTaskSelected(index);
		}

		// Token: 0x0600BABD RID: 47805 RVA: 0x00262D4C File Offset: 0x00260F4C
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

		// Token: 0x0600BABE RID: 47806 RVA: 0x00262E04 File Offset: 0x00261004
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

		// Token: 0x0600BABF RID: 47807 RVA: 0x00262E78 File Offset: 0x00261078
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

		// Token: 0x0600BAC0 RID: 47808 RVA: 0x00263058 File Offset: 0x00261258
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

		// Token: 0x0600BAC1 RID: 47809 RVA: 0x002631D4 File Offset: 0x002613D4
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

		// Token: 0x04004B18 RID: 19224
		private XTaskDocument doc;

		// Token: 0x04004B19 RID: 19225
		private List<int> m_TabListIDs = new List<int>();

		// Token: 0x04004B1A RID: 19226
		private List<string> m_TabListNames = new List<string>();

		// Token: 0x04004B1B RID: 19227
		private List<uint> m_TaskListIDs = new List<uint>();

		// Token: 0x04004B1C RID: 19228
		private List<GameObject> m_TaskGos = new List<GameObject>();

		// Token: 0x04004B1D RID: 19229
		private int m_SelectedTab = -1;

		// Token: 0x04004B1E RID: 19230
		private bool m_bFirstOpen = false;
	}
}
