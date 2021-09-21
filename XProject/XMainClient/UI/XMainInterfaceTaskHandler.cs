using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200183B RID: 6203
	internal class XMainInterfaceTaskHandler : DlgHandlerBase
	{
		// Token: 0x060101D5 RID: 66005 RVA: 0x003DA0B8 File Offset: 0x003D82B8
		protected override void Init()
		{
			base.Init();
			this.m_Emtpy = base.PanelObject.transform.Find("Empty").gameObject;
			this.m_ScrollView = (base.PanelObject.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (this.m_ScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.doc = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
		}

		// Token: 0x060101D6 RID: 66006 RVA: 0x003DA156 File Offset: 0x003D8356
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._OnWrapInit));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnWrapUpdated));
		}

		// Token: 0x060101D7 RID: 66007 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x060101D8 RID: 66008 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void _OnWrapInit(Transform t, int index)
		{
		}

		// Token: 0x060101D9 RID: 66009 RVA: 0x003DA190 File Offset: 0x003D8390
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

		// Token: 0x060101DA RID: 66010 RVA: 0x003DA3DC File Offset: 0x003D85DC
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

		// Token: 0x060101DB RID: 66011 RVA: 0x003DA44D File Offset: 0x003D864D
		public void RefreshVisibleContents()
		{
			this.m_WrapContent.RefreshAllVisibleContents();
		}

		// Token: 0x060101DC RID: 66012 RVA: 0x003DA45C File Offset: 0x003D865C
		private void _OnTaskClicked(IXUISprite iSp)
		{
			this.doc.DoTask((uint)iSp.ID);
			this.m_WrapContent.RefreshAllVisibleContents();
		}

		// Token: 0x040072EC RID: 29420
		private IXUIScrollView m_ScrollView;

		// Token: 0x040072ED RID: 29421
		private IXUIWrapContent m_WrapContent;

		// Token: 0x040072EE RID: 29422
		private GameObject m_Emtpy;

		// Token: 0x040072EF RID: 29423
		private XTaskDocument doc;
	}
}
