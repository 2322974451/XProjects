using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C71 RID: 3185
	internal class ActivityExchangeRewardHandler : DlgHandlerBase
	{
		// Token: 0x0600B427 RID: 46119 RVA: 0x00232250 File Offset: 0x00230450
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

		// Token: 0x170031E8 RID: 12776
		// (get) Token: 0x0600B428 RID: 46120 RVA: 0x00232424 File Offset: 0x00230624
		protected override string FileName
		{
			get
			{
				return "GameSystem/ThemeActivity/ActivityExchangeReward";
			}
		}

		// Token: 0x0600B429 RID: 46121 RVA: 0x0023243B File Offset: 0x0023063B
		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnListItemUpdated));
		}

		// Token: 0x0600B42A RID: 46122 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B42B RID: 46123 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B42C RID: 46124 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B42D RID: 46125 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void InitShow()
		{
		}

		// Token: 0x0600B42E RID: 46126 RVA: 0x0023246E File Offset: 0x0023066E
		public void SetActID(uint actid)
		{
			this.m_actid = actid;
		}

		// Token: 0x0600B42F RID: 46127 RVA: 0x00232478 File Offset: 0x00230678
		public void SetData(List<SuperActivityTask.RowData> data)
		{
			this.m_Data = data;
			this.m_FatherDataList = XTempActivityDocument.Doc.GetFatherTask(this.m_Data);
			this.RefreshList(true);
		}

		// Token: 0x0600B430 RID: 46128 RVA: 0x002324A0 File Offset: 0x002306A0
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

		// Token: 0x0600B431 RID: 46129 RVA: 0x002324E8 File Offset: 0x002306E8
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

		// Token: 0x0600B432 RID: 46130 RVA: 0x00232894 File Offset: 0x00230A94
		private bool OnGetRewardClick(IXUIButton btn)
		{
			int index = (int)btn.ID;
			XTempActivityDocument.Doc.GetActivityAwards(this.m_actid, this.m_FatherDataList[index].taskid);
			return true;
		}

		// Token: 0x0600B433 RID: 46131 RVA: 0x002328D4 File Offset: 0x00230AD4
		private bool OnCloseClick(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x040045D6 RID: 17878
		private List<SuperActivityTask.RowData> m_Data;

		// Token: 0x040045D7 RID: 17879
		private List<SuperActivityTask.RowData> m_FatherDataList;

		// Token: 0x040045D8 RID: 17880
		private uint m_actid;

		// Token: 0x040045D9 RID: 17881
		public static readonly uint COST_SHOW_NUM = 3U;

		// Token: 0x040045DA RID: 17882
		public static readonly uint REWARD_SHOW_NUM = 3U;

		// Token: 0x040045DB RID: 17883
		private IXUIButton m_Close;

		// Token: 0x040045DC RID: 17884
		private IXUIWrapContent m_WrapContent;

		// Token: 0x040045DD RID: 17885
		private IXUIScrollView m_ListScrollView;

		// Token: 0x040045DE RID: 17886
		private XUIPool m_CostItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040045DF RID: 17887
		private XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
