using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ActivityHelpRewardHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			Transform transform = base.transform;
			this.m_Time = (transform.Find("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_Close = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_WrapContent = (base.transform.Find("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ListScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform2 = transform.Find("Panel/WrapContent/RewardTpl/ItemTpl");
			this.m_ItemPool.SetupPool(null, transform2.gameObject, ActivityHelpRewardHandler.REWARD_SHOW_NUM, false);
			int num = 0;
			while ((long)num < (long)((ulong)ActivityHelpRewardHandler.REWARD_SHOW_NUM))
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(num * this.m_ItemPool.TplWidth), 0f, 0f) + this.m_ItemPool.TplPos;
				gameObject.name = string.Format("item{0}", num);
				num++;
			}
			this.InitShow();
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/ThemeActivity/ActivityHelpReward";
			}
		}

		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnListItemUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void InitShow()
		{
		}

		public void SetData(List<ActivityHelpReward> RewardData)
		{
			this.m_RewardData = RewardData;
			this.RefreshList(true);
		}

		public void RefreshList(bool bResetPosition = true)
		{
			this.m_RewardData.Sort(new Comparison<ActivityHelpReward>(ActivityHelpReward.Compare));
			int count = this.m_RewardData.Count;
			this.m_WrapContent.SetContentCount(count, false);
			if (bResetPosition)
			{
				this.m_ListScrollView.ResetPosition();
			}
			else
			{
				this.m_WrapContent.RefreshAllVisibleContents();
			}
		}

		private void _OnListItemUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this.m_RewardData.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index:" + index, null, null, null, null, null);
			}
			else
			{
				SuperActivityTask.RowData tableData = this.m_RewardData[index].tableData;
				string[] array = tableData.title.Split(new char[]
				{
					'|'
				});
				IXUILabel ixuilabel = t.Find("Title").GetComponent("XUILabel") as IXUILabel;
				bool flag2 = array.Length != 0;
				if (flag2)
				{
					ixuilabel.SetText(array[0]);
				}
				IXUILabel ixuilabel2 = t.Find("Desc").GetComponent("XUILabel") as IXUILabel;
				string arg = this.m_RewardData[index].tableData.cnt.ToString();
				bool flag3 = this.m_RewardData[index].state == 0U;
				if (flag3)
				{
					arg = string.Format("({0}/{1})", this.m_RewardData[index].progress, this.m_RewardData[index].tableData.cnt);
				}
				bool flag4 = array.Length > 1;
				if (flag4)
				{
					ixuilabel2.SetText(string.Format(array[1], arg));
				}
				IXUIButton ixuibutton = t.Find("Receive").GetComponent("XUIButton") as IXUIButton;
				Transform transform = t.Find("End");
				ixuibutton.SetEnable(this.m_RewardData[index].state == 1U, false);
				ixuibutton.gameObject.SetActive(this.m_RewardData[index].state != 2U);
				transform.gameObject.SetActive(this.m_RewardData[index].state == 2U);
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetRewardClick));
				int num = 0;
				while ((long)num < (long)((ulong)ActivityHelpRewardHandler.REWARD_SHOW_NUM))
				{
					Transform transform2 = t.Find(string.Format("item{0}", num));
					bool flag5 = num < this.m_RewardData[index].tableData.items.Count;
					if (flag5)
					{
						transform2.gameObject.SetActive(true);
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.m_RewardData[index].tableData.items[num, 0]);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform2.gameObject, itemConf, (int)this.m_RewardData[index].tableData.items[num, 1], false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(transform2.gameObject, (int)this.m_RewardData[index].tableData.items[num, 0]);
					}
					else
					{
						transform2.gameObject.SetActive(false);
					}
					num++;
				}
			}
		}

		private bool OnGetRewardClick(IXUIButton btn)
		{
			int index = (int)btn.ID;
			XTempActivityDocument.Doc.GetActivityAwards(this.m_RewardData[index].tableData.actid, this.m_RewardData[index].tableData.taskid);
			return true;
		}

		private bool OnCloseClick(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		public void SetEndTime(uint actID)
		{
			DateTime endTime = XTempActivityDocument.Doc.GetEndTime(actID);
			string arg = string.Format(XStringDefineProxy.GetString("CAREER_GROWTH_PROCESS_TIME"), endTime.Year, endTime.Month, endTime.Day);
			this.m_Time.SetText(string.Format("{0} {1}:00", arg, endTime.Hour));
		}

		private List<ActivityHelpReward> m_RewardData;

		public static readonly uint REWARD_SHOW_NUM = 3U;

		private IXUILabel m_Time;

		private IXUIButton m_Close;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ListScrollView;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
