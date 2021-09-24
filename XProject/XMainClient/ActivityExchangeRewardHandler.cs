using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ActivityExchangeRewardHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			Transform transform = base.transform;
			this.m_Close = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_WrapContent = (base.transform.Find("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ListScrollView = (base.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform2 = transform.Find("Panel/WrapContent/RewardTpl/CostItemTpl");
			this.m_CostItemPool.SetupPool(null, transform2.gameObject, ActivityExchangeRewardHandler.COST_SHOW_NUM, false);
			Transform transform3 = transform.Find("Panel/WrapContent/RewardTpl/RewardItemTpl");
			this.m_RewardItemPool.SetupPool(null, transform3.gameObject, ActivityExchangeRewardHandler.REWARD_SHOW_NUM, false);
			int num = 0;
			while ((long)num < (long)((ulong)ActivityExchangeRewardHandler.COST_SHOW_NUM))
			{
				GameObject gameObject = this.m_CostItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(num * this.m_CostItemPool.TplWidth), 0f, 0f) + this.m_CostItemPool.TplPos;
				gameObject.name = string.Format("CostItem{0}", num);
				num++;
			}
			int num2 = 0;
			while ((long)num2 < (long)((ulong)ActivityExchangeRewardHandler.REWARD_SHOW_NUM))
			{
				GameObject gameObject2 = this.m_RewardItemPool.FetchGameObject(false);
				gameObject2.transform.localPosition = new Vector3((float)(num2 * this.m_RewardItemPool.TplWidth), 0f, 0f) + this.m_RewardItemPool.TplPos;
				gameObject2.name = string.Format("RewardItem{0}", num2);
				num2++;
			}
			this.InitShow();
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/ThemeActivity/ActivityExchangeReward";
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

		public void SetActID(uint actid)
		{
			this.m_actid = actid;
		}

		public void SetData(List<SuperActivityTask.RowData> data)
		{
			this.m_Data = data;
			this.m_FatherDataList = XTempActivityDocument.Doc.GetFatherTask(this.m_Data);
			this.RefreshList(true);
		}

		public void RefreshList(bool bResetPosition = true)
		{
			int count = this.m_FatherDataList.Count;
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
			bool flag = index < 0 || index >= this.m_FatherDataList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index:" + index, null, null, null, null, null);
			}
			else
			{
				SuperActivityTask.RowData rowData = this.m_FatherDataList[index];
				List<SuperActivityTask.RowData> sonTask = XTempActivityDocument.Doc.GetSonTask(this.m_Data, rowData);
				uint activityState = XTempActivityDocument.Doc.GetActivityState(this.m_actid, rowData.taskid);
				uint activityProgress = XTempActivityDocument.Doc.GetActivityProgress(this.m_actid, rowData.taskid);
				IXUIButton ixuibutton = t.Find("NoCompleteBtn").GetComponent("XUIButton") as IXUIButton;
				IXUIButton ixuibutton2 = t.Find("ExchangeBtn").GetComponent("XUIButton") as IXUIButton;
				Transform transform = t.Find("End");
				ixuibutton.SetEnable(false, false);
				ixuibutton.gameObject.SetActive(activityState == 0U);
				ixuibutton2.gameObject.SetActive(activityState == 1U);
				transform.gameObject.SetActive(activityState == 2U);
				ixuibutton2.ID = (ulong)((long)index);
				ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetRewardClick));
				IXUILabel ixuilabel = t.Find("Progress").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Format("{0}/{1}", activityProgress, rowData.cnt));
				int num = 0;
				while ((long)num < (long)((ulong)ActivityExchangeRewardHandler.COST_SHOW_NUM))
				{
					Transform transform2 = t.Find(string.Format("CostItem{0}", num));
					bool flag2 = num < sonTask.Count;
					if (flag2)
					{
						transform2.gameObject.SetActive(true);
						bool flag3 = sonTask[num].num.Length < 2;
						if (!flag3)
						{
							int num2 = (int)sonTask[num].num[0];
							int num3 = Math.Min((int)(activityProgress + 1U), sonTask[num].num.Length - 1);
							int num4 = (int)sonTask[num].num[num3];
							ulong itemCount = XBagDocument.BagDoc.GetItemCount(num2);
							ItemList.RowData itemConf = XBagDocument.GetItemConf(num2);
							XItemDrawerMgr.Param.MaxItemCount = num4;
							XItemDrawerMgr.Param.NumColor = new Color?((itemCount >= (ulong)((long)num4)) ? Color.white : new Color(0.9647059f, 0.15294118f, 0.047058824f));
							XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform2.gameObject, itemConf, (int)itemCount, false);
							XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(transform2.gameObject, num2);
						}
					}
					else
					{
						transform2.gameObject.SetActive(false);
					}
					IL_2AE:
					num++;
					continue;
					goto IL_2AE;
				}
				int num5 = 0;
				while ((long)num5 < (long)((ulong)ActivityExchangeRewardHandler.REWARD_SHOW_NUM))
				{
					Transform transform3 = t.Find(string.Format("RewardItem{0}", num5));
					bool flag4 = num5 < rowData.items.Count;
					if (flag4)
					{
						transform3.gameObject.SetActive(true);
						ItemList.RowData itemConf2 = XBagDocument.GetItemConf((int)rowData.items[num5, 0]);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform3.gameObject, itemConf2, (int)rowData.items[num5, 1], false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(transform3.gameObject, (int)rowData.items[num5, 0]);
					}
					else
					{
						transform3.gameObject.SetActive(false);
					}
					num5++;
				}
			}
		}

		private bool OnGetRewardClick(IXUIButton btn)
		{
			int index = (int)btn.ID;
			XTempActivityDocument.Doc.GetActivityAwards(this.m_actid, this.m_FatherDataList[index].taskid);
			return true;
		}

		private bool OnCloseClick(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private List<SuperActivityTask.RowData> m_Data;

		private List<SuperActivityTask.RowData> m_FatherDataList;

		private uint m_actid;

		public static readonly uint COST_SHOW_NUM = 3U;

		public static readonly uint REWARD_SHOW_NUM = 3U;

		private IXUIButton m_Close;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ListScrollView;

		private XUIPool m_CostItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
