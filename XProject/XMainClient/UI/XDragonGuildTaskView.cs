using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class XDragonGuildTaskView : DlgBase<XDragonGuildTaskView, XDragonGuildTaskBehaviour>
	{

		public uint CurFrame
		{
			get
			{
				return this._curframe;
			}
		}

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

		public override string fileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopTask";
			}
		}

		public override int layer
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

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.ReqInfo();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
			this._doc.View = null;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		public bool OnTabStateChange(IXUICheckBox check)
		{
			bool bChecked = check.bChecked;
			if (bChecked)
			{
				this.OnTabClicked((int)check.ID);
			}
			return true;
		}

		private void OnTabClicked(int index)
		{
			this._curframe = (uint)index;
			this._doc.ReqInfo();
		}

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

		private void UpdateRedPoint()
		{
			base.uiBehaviour.m_taskrep.gameObject.SetActive(this._doc.HadTaskRedPoint());
			base.uiBehaviour.m_acieverep.gameObject.SetActive(this._doc.HadAchieveRedPoint());
		}

		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

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

		private void UpdateProgress()
		{
			base.uiBehaviour.m_GuildExpCur.SetText(XDragonGuildDocument.Doc.BaseData.curexp.ToString());
			base.uiBehaviour.m_GuildExpMax.SetText("/" + XDragonGuildDocument.Doc.GetMaxExp().ToString());
			base.uiBehaviour.m_progress.value = XDragonGuildDocument.Doc.BaseData.curexp / XDragonGuildDocument.Doc.GetMaxExp();
		}

		private void RefreshTaskUI()
		{
			base.uiBehaviour.m_cdrewards.SetText(this._doc.m_taskresettime);
			base.uiBehaviour.m_wrapcontent.SetContentCount(this._doc.m_tasklist.Count, false);
			base.uiBehaviour.m_cdrewards.SetVisible(true);
			base.uiBehaviour.m_Toptask.gameObject.SetActive(true);
			base.uiBehaviour.m_Topachieve.gameObject.SetActive(false);
		}

		private void RefreshAchieveUI()
		{
			base.uiBehaviour.m_wrapcontent.SetContentCount(this._doc.m_achievelist.Count, false);
			base.uiBehaviour.m_cdrewards.SetVisible(false);
			base.uiBehaviour.m_Toptask.gameObject.SetActive(false);
			base.uiBehaviour.m_Topachieve.gameObject.SetActive(true);
		}

		private uint _curframe;

		private XDragonGuildTaskDocument _doc = null;
	}
}
