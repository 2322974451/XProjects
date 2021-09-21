using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016DC RID: 5852
	public class XDragonGuildTaskView : DlgBase<XDragonGuildTaskView, XDragonGuildTaskBehaviour>
	{
		// Token: 0x1700374C RID: 14156
		// (get) Token: 0x0600F156 RID: 61782 RVA: 0x00354068 File Offset: 0x00352268
		public uint CurFrame
		{
			get
			{
				return this._curframe;
			}
		}

		// Token: 0x0600F157 RID: 61783 RVA: 0x00354080 File Offset: 0x00352280
		protected override void Init()
		{
			base.Init();
			this._curframe = 1U;
			this._doc = XDocuments.GetSpecificDocument<XDragonGuildTaskDocument>(XDragonGuildTaskDocument.uuID);
			this._doc.View = this;
			base.uiBehaviour.m_wrapcontent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateDailyTask));
			base.uiBehaviour.m_task.ID = 1UL;
			base.uiBehaviour.m_task.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabStateChange));
			base.uiBehaviour.m_achieve.ID = 2UL;
			base.uiBehaviour.m_achieve.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabStateChange));
		}

		// Token: 0x1700374D RID: 14157
		// (get) Token: 0x0600F158 RID: 61784 RVA: 0x00354138 File Offset: 0x00352338
		public override string fileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopTask";
			}
		}

		// Token: 0x1700374E RID: 14158
		// (get) Token: 0x0600F159 RID: 61785 RVA: 0x00354150 File Offset: 0x00352350
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700374F RID: 14159
		// (get) Token: 0x0600F15A RID: 61786 RVA: 0x00354164 File Offset: 0x00352364
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003750 RID: 14160
		// (get) Token: 0x0600F15B RID: 61787 RVA: 0x00354178 File Offset: 0x00352378
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600F15C RID: 61788 RVA: 0x0035418B File Offset: 0x0035238B
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.ReqInfo();
		}

		// Token: 0x0600F15D RID: 61789 RVA: 0x003541A1 File Offset: 0x003523A1
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F15E RID: 61790 RVA: 0x003541AB File Offset: 0x003523AB
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		// Token: 0x0600F15F RID: 61791 RVA: 0x003541D2 File Offset: 0x003523D2
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600F160 RID: 61792 RVA: 0x003541DC File Offset: 0x003523DC
		protected override void OnUnload()
		{
			base.OnUnload();
			this._doc.View = null;
		}

		// Token: 0x0600F161 RID: 61793 RVA: 0x003541F3 File Offset: 0x003523F3
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0600F162 RID: 61794 RVA: 0x00354200 File Offset: 0x00352400
		public bool OnTabStateChange(IXUICheckBox check)
		{
			bool bChecked = check.bChecked;
			if (bChecked)
			{
				this.OnTabClicked((int)check.ID);
			}
			return true;
		}

		// Token: 0x0600F163 RID: 61795 RVA: 0x0035422D File Offset: 0x0035242D
		private void OnTabClicked(int index)
		{
			this._curframe = (uint)index;
			this._doc.ReqInfo();
		}

		// Token: 0x0600F164 RID: 61796 RVA: 0x00354244 File Offset: 0x00352444
		public void RefreshUI()
		{
			this.UpdateProgress();
			this.UpdateRedPoint();
			bool flag = this.CurFrame == 1U;
			if (flag)
			{
				this.RefreshTaskUI();
			}
			else
			{
				bool flag2 = this.CurFrame == 2U;
				if (flag2)
				{
					this.RefreshAchieveUI();
				}
			}
			base.uiBehaviour.m_GuildLevel.SetText("Lv." + XDragonGuildDocument.Doc.BaseData.level.ToString());
		}

		// Token: 0x0600F165 RID: 61797 RVA: 0x003542C0 File Offset: 0x003524C0
		private void UpdateRedPoint()
		{
			base.uiBehaviour.m_taskrep.gameObject.SetActive(this._doc.HadTaskRedPoint());
			base.uiBehaviour.m_acieverep.gameObject.SetActive(this._doc.HadAchieveRedPoint());
		}

		// Token: 0x0600F166 RID: 61798 RVA: 0x00354310 File Offset: 0x00352510
		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F167 RID: 61799 RVA: 0x0035432C File Offset: 0x0035252C
		private void UpdateDailyTask(Transform t, int index)
		{
			XDragonGuildTpl dataByindex = this._doc.GetDataByindex(index, this._curframe);
			Transform transform = t.Find("HadGet");
			IXUILabel ixuilabel = t.Find("Title").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("Describe").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("Describe/T/ExpAddup").GetComponent("XUILabel") as IXUILabel;
			IXUIButton ixuibutton = t.Find("GetBtn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.ID = (ulong)dataByindex.id;
			Transform transform2 = t.Find("GetBtn/Text");
			Transform transform3 = t.Find("GetBtn/Text_cant");
			Transform transform4 = t.Find("GetBtn/Text_over");
			Transform transform5 = t.Find("Times");
			IXUILabel ixuilabel4 = t.Find("Times/LeftTimes").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel5 = t.Find("Time").GetComponent("XUILabel") as IXUILabel;
			List<Transform> list = new List<Transform>();
			Transform transform6 = t.Find("Items");
			for (int i = 0; i < 3; i++)
			{
				list.Add(transform6.GetChild(i));
			}
			ixuilabel.SetText(dataByindex.title);
			ixuilabel5.SetText(string.Format("{0}/{1}", dataByindex.doingCount, dataByindex.finishCount));
			ixuilabel2.SetText(dataByindex.desc);
			ixuilabel3.SetText("+" + dataByindex.exp.ToString());
			transform2.gameObject.SetActive(dataByindex.state == 2);
			transform3.gameObject.SetActive(dataByindex.state == 1);
			transform4.gameObject.SetActive(dataByindex.state == 4);
			transform.gameObject.SetActive(dataByindex.state == 3);
			transform5.gameObject.SetActive(this.CurFrame == 2U);
			ixuibutton.gameObject.SetActive(dataByindex.state != 3);
			bool flag = dataByindex.state == 4 || dataByindex.state == 1;
			if (flag)
			{
				ixuibutton.SetEnable(false, false);
			}
			else
			{
				ixuibutton.SetEnable(true, false);
			}
			bool flag2 = dataByindex.state == 2;
			if (flag2)
			{
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTaskOrAchieveClick));
			}
			bool flag3 = this.CurFrame == 2U;
			if (flag3)
			{
				ixuilabel4.SetText(dataByindex.lefttime.ToString());
			}
			for (int j = 0; j < 3; j++)
			{
				list[j].gameObject.SetActive(true);
				bool flag4 = j >= dataByindex.item.Count;
				if (flag4)
				{
					list[j].gameObject.SetActive(false);
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(list[j].gameObject, (int)dataByindex.item[j, 0], (int)dataByindex.item[j, 1], true);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(list[j].gameObject, (int)dataByindex.item[j, 0]);
				}
			}
		}

		// Token: 0x0600F168 RID: 61800 RVA: 0x003546A4 File Offset: 0x003528A4
		private bool OnTaskOrAchieveClick(IXUIButton btn)
		{
			int id = (int)btn.ID;
			bool flag = this.CurFrame == 1U;
			if (flag)
			{
				this._doc.ReqFetchTask(id);
			}
			else
			{
				bool flag2 = this.CurFrame == 2U;
				if (flag2)
				{
					this._doc.ReqFetchAchieve(id);
				}
			}
			return true;
		}

		// Token: 0x0600F169 RID: 61801 RVA: 0x003546FC File Offset: 0x003528FC
		public void OnTaskFetch(uint id)
		{
			for (int i = 0; i < this._doc.m_tasklist.Count; i++)
			{
				bool flag = id == this._doc.m_tasklist[i].id;
				if (flag)
				{
					this._doc.m_tasklist[i].state = 3;
				}
			}
			this.RefreshUI();
		}

		// Token: 0x0600F16A RID: 61802 RVA: 0x00354768 File Offset: 0x00352968
		private void UpdateProgress()
		{
			base.uiBehaviour.m_GuildExpCur.SetText(XDragonGuildDocument.Doc.BaseData.curexp.ToString());
			base.uiBehaviour.m_GuildExpMax.SetText("/" + XDragonGuildDocument.Doc.GetMaxExp().ToString());
			base.uiBehaviour.m_progress.value = XDragonGuildDocument.Doc.BaseData.curexp / XDragonGuildDocument.Doc.GetMaxExp();
		}

		// Token: 0x0600F16B RID: 61803 RVA: 0x003547F8 File Offset: 0x003529F8
		private void RefreshTaskUI()
		{
			base.uiBehaviour.m_cdrewards.SetText(this._doc.m_taskresettime);
			base.uiBehaviour.m_wrapcontent.SetContentCount(this._doc.m_tasklist.Count, false);
			base.uiBehaviour.m_cdrewards.SetVisible(true);
			base.uiBehaviour.m_Toptask.gameObject.SetActive(true);
			base.uiBehaviour.m_Topachieve.gameObject.SetActive(false);
		}

		// Token: 0x0600F16C RID: 61804 RVA: 0x00354884 File Offset: 0x00352A84
		private void RefreshAchieveUI()
		{
			base.uiBehaviour.m_wrapcontent.SetContentCount(this._doc.m_achievelist.Count, false);
			base.uiBehaviour.m_cdrewards.SetVisible(false);
			base.uiBehaviour.m_Toptask.gameObject.SetActive(false);
			base.uiBehaviour.m_Topachieve.gameObject.SetActive(true);
		}

		// Token: 0x04006723 RID: 26403
		private uint _curframe;

		// Token: 0x04006724 RID: 26404
		private XDragonGuildTaskDocument _doc = null;
	}
}
