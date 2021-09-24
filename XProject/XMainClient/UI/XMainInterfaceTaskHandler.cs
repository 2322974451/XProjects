using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XMainInterfaceTaskHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_Emtpy = base.PanelObject.transform.Find("Empty").gameObject;
			this.m_ScrollView = (base.PanelObject.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (this.m_ScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.doc = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._OnWrapInit));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnWrapUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		private void _OnWrapInit(Transform t, int index)
		{
		}

		private void _OnWrapUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this.doc.TaskRecord.Tasks.Count;
			if (!flag)
			{
				XTaskInfo xtaskInfo = this.doc.TaskRecord.Tasks[index];
				TaskTableNew.RowData tableData = xtaskInfo.TableData;
				IXUISprite ixuisprite = t.Find("BackDrop").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("Title").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol = t.Find("Target").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				GameObject gameObject = ixuilabelSymbol.gameObject.transform.Find("Fx").gameObject;
				GameObject gameObject2 = ixuilabelSymbol.gameObject.transform.Find("RedPoint").gameObject;
				bool flag2 = tableData == null;
				if (flag2)
				{
					ixuisprite.RegisterSpriteClickEventHandler(null);
					ixuilabel.SetText(string.Empty);
					ixuilabelSymbol.InputText = string.Empty;
					gameObject.SetActive(false);
					gameObject2.SetActive(false);
				}
				else
				{
					ixuisprite.ID = (ulong)xtaskInfo.ID;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnTaskClicked));
					ixuilabel.SetText(XSingleton<XCommon>.singleton.StringCombine(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("TaskTypePrefix", tableData.TaskType.ToString())), tableData.TaskTitle));
					ixuilabelSymbol.InputText = this.doc.ParseTaskDesc(tableData, xtaskInfo, true);
					gameObject.SetActive(this.doc.NaviTask == xtaskInfo.ID);
					gameObject2.SetActive(false);
					bool flag3 = tableData.TaskType == 4U;
					if (flag3)
					{
						gameObject2.SetActive(xtaskInfo.Status == TaskStatus.TaskStatus_CanTake || XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildDailyTask));
					}
					bool flag4 = tableData.TaskType == 7U;
					if (flag4)
					{
						gameObject2.SetActive(xtaskInfo.Status == TaskStatus.TaskStatus_CanTake || XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildWeeklyBountyTask));
					}
					bool flag5 = tableData.TaskType == 8U;
					if (flag5)
					{
						gameObject2.SetActive(xtaskInfo.Status != TaskStatus.TaskStatus_Finish);
					}
				}
			}
		}

		public override void RefreshData()
		{
			base.RefreshData();
			List<XTaskInfo> tasks = this.doc.TaskRecord.Tasks;
			this.m_WrapContent.SetContentCount(tasks.Count, false);
			bool flag = tasks.Count == 0;
			if (flag)
			{
				this.m_Emtpy.SetActive(true);
			}
			else
			{
				this.m_Emtpy.SetActive(false);
				this.m_ScrollView.ResetPosition();
			}
		}

		public void RefreshVisibleContents()
		{
			this.m_WrapContent.RefreshAllVisibleContents();
		}

		private void _OnTaskClicked(IXUISprite iSp)
		{
			this.doc.DoTask((uint)iSp.ID);
			this.m_WrapContent.RefreshAllVisibleContents();
		}

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private GameObject m_Emtpy;

		private XTaskDocument doc;
	}
}
