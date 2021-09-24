using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTargetRewardView : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.popWindow.panelObject = base.PanelObject.transform.Find("Top");
			this.popWindow.closeBtn = (base.PanelObject.transform.Find("Top/Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.popWindow.wrapContent = (base.PanelObject.transform.FindChild("Top/Bg/detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.popWindow.panelScrollView = (base.PanelObject.transform.FindChild("Top/Bg/detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this.popWindow.init();
			this._doc = XDocuments.GetSpecificDocument<XTargetRewardDocument>(XTargetRewardDocument.uuID);
			this._doc.InitOpenGoalAward();
			int num = 0;
			for (int i = 0; i < this.m_padTabs.Length; i++)
			{
				this.m_padTabs[i] = (base.PanelObject.transform.Find("padTabs/TabList/TabTpl" + i + "/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
				this.m_padPoint[i] = (base.PanelObject.transform.Find("padTabs/TabList/TabTpl" + i + "/Bg/RedPoint").GetComponent("XUISprite") as IXUISprite);
				IXUISprite ixuisprite = base.PanelObject.transform.Find("padTabs/TabList/TabTpl" + i).GetComponent("XUISprite") as IXUISprite;
				this.m_padPoint[i].gameObject.SetActive(false);
				bool flag = this.m_padTabs[i] != null;
				if (flag)
				{
					this.m_padTabs[i].ID = (ulong)i;
					this.m_padTabs[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabControlStateChange));
				}
				bool flag2 = ixuisprite != null;
				if (flag2)
				{
					ixuisprite.gameObject.SetActive(this._doc.m_isGoalOpen[i + 1]);
					bool flag3 = this._doc.m_isGoalOpen[i + 1] && num == 0;
					if (flag3)
					{
						num = i;
						this.m_padTabs[i].ForceSetFlag(true);
					}
					else
					{
						this.m_padTabs[i].ForceSetFlag(false);
					}
				}
			}
			this.m_GoalList = (base.PanelObject.transform.Find("padTabs/TabList").GetComponent("XUIList") as IXUIList);
			this.m_PanelScrollView = (base.PanelObject.transform.FindChild("detail/detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("detail/detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			this.m_GoalList.Refresh();
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this._doc != null;
			if (flag)
			{
				bool flag2 = index < this._doc.targetAwardDetails.Count && index >= 0;
				if (flag2)
				{
					TargetItemInfo info = this._doc.targetAwardDetails[index];
					this._SetRecord(t, info);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("_doc is nil or index: ", index.ToString(), null, null, null, null);
			}
		}

		protected void _SetProgressBar(IXUILabel label, IXUIProgress progressBar, TargetItemInfo info)
		{
			int num = info.subItems.Count - 1;
			int num2 = (int)Math.Min(info.gottenAwardsIndex, info.doneIndex);
			num2 = Math.Min(num2, num);
			GoalAwards.RowData rowData = info.subItems[num2];
			double num3 = info.totalvalue;
			double num4 = rowData.AwardsValue;
			bool flag = (ulong)info.gottenAwardsIndex == (ulong)((long)(num + 1));
			if (flag)
			{
				label.SetVisible(false);
				progressBar.SetVisible(false);
			}
			else
			{
				label.SetVisible(true);
				progressBar.SetVisible(true);
				bool flag2 = rowData.ShowType == 2U;
				if (flag2)
				{
					bool flag3 = info.gottenAwardsIndex < info.doneIndex;
					if (flag3)
					{
						num3 = 1.0;
						num4 = 1.0;
					}
					else
					{
						num3 = 0.0;
						num4 = 1.0;
					}
				}
				label.SetText(XSingleton<UiUtility>.singleton.NumberFormat((ulong)num3) + " / " + XSingleton<UiUtility>.singleton.NumberFormat((ulong)num4));
				bool flag4 = (ulong)info.gottenAwardsIndex < (ulong)((long)(num + 1)) && info.gottenAwardsIndex == info.doneIndex;
				if (flag4)
				{
					bool flag5 = num3 < num4;
					if (flag5)
					{
						progressBar.value = (float)(num3 / num4);
					}
					else
					{
						progressBar.value = 0f;
					}
				}
				else
				{
					progressBar.value = 1f;
				}
			}
		}

		protected void _SetRecord(Transform t, TargetItemInfo info)
		{
			IXUILabel ixuilabel = t.Find("TLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("DLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("ch").GetComponent("XUILabel") as IXUILabel;
			IXUIButton ixuibutton = t.Find("Get").GetComponent("XUIButton") as IXUIButton;
			IXUISprite ixuisprite = t.Find("Fini").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = t.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
			IXUIProgress ixuiprogress = t.Find("slider").GetComponent("XUIProgress") as IXUIProgress;
			IXUILabel label = t.Find("slider/PLabel").GetComponent("XUILabel") as IXUILabel;
			Transform[] array = new Transform[this.maxAwardNum];
			for (int i = 0; i < this.maxAwardNum; i++)
			{
				array[i] = t.Find("tmp/ItemTpl1_" + (i + 1));
			}
			int num = info.subItems.Count - 1;
			int num2 = (int)Math.Min(info.gottenAwardsIndex, info.doneIndex);
			num2 = Math.Min(num2, num);
			GoalAwards.RowData rowData = info.subItems[num2];
			ixuilabel.SetText(rowData.Description);
			ixuilabel2.SetText(rowData.Explanation);
			ixuisprite.SetVisible((ulong)info.gottenAwardsIndex == (ulong)((long)(num + 1)));
			ixuisprite2.SetVisible(info.gottenAwardsIndex < info.doneIndex);
			this._SetProgressBar(label, ixuiprogress, info);
			int num3 = Math.Min(this.maxAwardNum, rowData.Awards.Count);
			bool flag = (ulong)info.gottenAwardsIndex == (ulong)((long)(num + 1));
			if (flag)
			{
				num3 = 0;
			}
			for (int j = 0; j < num3; j++)
			{
				array[j].gameObject.SetActive(true);
				int num4 = (int)rowData.Awards[j, 0];
				int itemCount = (int)rowData.Awards[j, 1];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(array[j].gameObject, num4, itemCount, false);
				IXUISprite ixuisprite3 = array[j].gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.ID = (ulong)((long)num4);
				ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			for (int k = num3; k < this.maxAwardNum; k++)
			{
				array[k].gameObject.SetActive(false);
			}
			bool visible = info.gottenAwardsIndex >= info.doneIndex && (ulong)info.gottenAwardsIndex != (ulong)((long)(num + 1));
			bool visible2 = info.gottenAwardsIndex < info.doneIndex;
			ixuiprogress.SetVisible(visible);
			ixuibutton.SetVisible(visible2);
			ixuibutton.ID = (ulong)info.goalAwardsID;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClick));
			ixuilabel3.ID = (ulong)info.goalAwardsID;
			ixuilabel3.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnLabelClick));
		}

		private void OnLabelClick(IXUILabel uiSprite)
		{
			this.ShowDetailView((int)uiSprite.ID);
		}

		private void ShowDetailView(int goalAwardsID)
		{
			TargetItemInfo info = new TargetItemInfo();
			bool flag = false;
			for (int i = 0; i < this._doc.targetAwardDetails.Count; i++)
			{
				bool flag2 = (ulong)this._doc.targetAwardDetails[i].goalAwardsID == (ulong)((long)goalAwardsID);
				if (flag2)
				{
					flag = true;
					info = this._doc.targetAwardDetails[i];
					break;
				}
			}
			bool flag3 = !flag;
			if (!flag3)
			{
				this.popWindow.ShowPopView(info);
			}
		}

		private bool OnBtnClick(IXUIButton btn)
		{
			TargetItemInfo targetItemInfo = new TargetItemInfo();
			bool flag = false;
			for (int i = 0; i < this._doc.targetAwardDetails.Count; i++)
			{
				bool flag2 = (ulong)this._doc.targetAwardDetails[i].goalAwardsID == (ulong)((long)((int)btn.ID));
				if (flag2)
				{
					flag = true;
					targetItemInfo = this._doc.targetAwardDetails[i];
					break;
				}
			}
			bool flag3 = flag && targetItemInfo.gottenAwardsIndex < targetItemInfo.doneIndex;
			if (flag3)
			{
				this._doc.ClaimAchieve((int)btn.ID);
			}
			return true;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc = XDocuments.GetSpecificDocument<XTargetRewardDocument>(XTargetRewardDocument.uuID);
			this._doc.rwdView = this;
			this.RefreshRedPoint();
			this.m_padTabs[0].ForceSetFlag(true);
			this.ReqDetailInfo(0);
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.PanelObject.SetActive(false);
		}

		public override void OnUnload()
		{
			this._doc = null;
			base.OnUnload();
		}

		public bool OnTabControlStateChange(IXUICheckBox chkBox)
		{
			bool bChecked = chkBox.bChecked;
			if (bChecked)
			{
				this.OnTabClick((int)chkBox.ID);
			}
			return true;
		}

		private void OnTabClick(int index)
		{
			this.ReqDetailInfo(index);
		}

		private void ReqDetailInfo(int index)
		{
			bool flag = this._doc != null;
			if (flag)
			{
				this.m_targetRewardType = index + TargetRewardType.Athletics;
				this._doc.FetchTargetRewardType(this.m_targetRewardType);
			}
		}

		public void RefreshDetails()
		{
			this.m_WrapContent.SetContentCount(this._doc.targetAwardDetails.Count, false);
			this.m_PanelScrollView.ResetPosition();
		}

		public void RefreshRedPoint()
		{
			for (int i = 0; i < this.m_padPoint.Length; i++)
			{
				this.m_padPoint[i].SetVisible(false);
			}
			for (int j = 0; j < this._doc.m_redList.Count; j++)
			{
				int num = (int)this._doc.m_redList[j];
				bool flag = num <= this.m_padPoint.Length;
				if (flag)
				{
					this.m_padPoint[num - 1].SetVisible(true);
				}
			}
		}

		private XTargetRewardDocument _doc = null;

		private XTargetRewardPopWindow popWindow = new XTargetRewardPopWindow();

		private IXUICheckBox[] m_padTabs = new IXUICheckBox[4];

		private IXUISprite[] m_padPoint = new IXUISprite[4];

		public TargetRewardType m_targetRewardType;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_PanelScrollView;

		private IXUIList m_GoalList;

		private int maxAwardNum = 4;
	}
}
