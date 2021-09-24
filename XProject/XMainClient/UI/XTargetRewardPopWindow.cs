using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTargetRewardPopWindow
	{

		public void init()
		{
			bool flag = this.wrapContent != null;
			if (flag)
			{
				this.wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.PopWrapContentItemUpdated));
			}
			bool flag2 = this.closeBtn != null;
			if (flag2)
			{
				this.closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosePopwindow));
			}
		}

		private bool OnClosePopwindow(IXUIButton btn)
		{
			bool flag = this.panelObject != null;
			if (flag)
			{
				this.panelObject.gameObject.SetActive(false);
			}
			return true;
		}

		public void ShowPopView(TargetItemInfo info)
		{
			bool flag = this.panelObject != null;
			if (flag)
			{
				this.panelObject.gameObject.SetActive(true);
				this.targetItemInfo = info;
				this.wrapContent.SetContentCount(info.subItems.Count, false);
				this.panelScrollView.ResetPosition();
			}
		}

		private void PopWrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.targetItemInfo != null;
			if (flag)
			{
				bool flag2 = index < this.targetItemInfo.subItems.Count && index >= 0;
				if (flag2)
				{
					this._SetRecord(t, this.targetItemInfo, index);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("targetItemInfo is nil or index: ", index.ToString(), null, null, null, null);
			}
		}

		protected void _SetRecord(Transform t, TargetItemInfo info, int showIndex)
		{
			IXUILabel ixuilabel = t.Find("TLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("DLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabelSymbol ixuilabelSymbol = t.Find("Sprite").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUISprite ixuisprite = t.Find("Fini").GetComponent("XUISprite") as IXUISprite;
			Transform[] array = new Transform[this.maxAwardNum];
			for (int i = 0; i < this.maxAwardNum; i++)
			{
				array[i] = t.Find("tmp/ItemTpl1_" + (i + 1));
			}
			int num = info.subItems.Count - 1;
			GoalAwards.RowData rowData = info.subItems[showIndex];
			ixuilabel.SetText(rowData.Description);
			ixuilabel2.SetText(rowData.Explanation);
			bool flag = (ulong)info.gottenAwardsIndex >= (ulong)((long)(showIndex + 1));
			if (flag)
			{
				ixuisprite.SetSprite("L_ylq");
			}
			else
			{
				ixuisprite.SetSprite("L_wlq");
			}
			bool flag2 = rowData.TitleID > 0U;
			if (flag2)
			{
				ixuilabelSymbol.SetVisible(true);
				XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
				DesignationTable.RowData byID = specificDocument._DesignationTable.GetByID((int)rowData.TitleID);
				bool flag3 = byID.Effect == "";
				string inputText;
				if (flag3)
				{
					inputText = byID.Color + byID.Designation;
				}
				else
				{
					inputText = XLabelSymbolHelper.FormatDesignation(byID.Atlas, byID.Effect, 16);
				}
				ixuilabelSymbol.InputText = inputText;
			}
			else
			{
				ixuilabelSymbol.SetVisible(false);
			}
			int num2 = Math.Min(this.maxAwardNum, rowData.Awards.Count);
			XTargetRewardDocument specificDocument2 = XDocuments.GetSpecificDocument<XTargetRewardDocument>(XTargetRewardDocument.uuID);
			for (int j = 0; j < num2; j++)
			{
				bool flag4 = specificDocument2 != null && specificDocument2.m_designationId == (int)rowData.Awards[j, 0];
				if (flag4)
				{
					array[j].gameObject.SetActive(false);
				}
				else
				{
					array[j].gameObject.SetActive(true);
					int num3 = (int)rowData.Awards[j, 0];
					int itemCount = (int)rowData.Awards[j, 1];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(array[j].gameObject, num3, itemCount, false);
					IXUISprite ixuisprite2 = array[j].gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)((long)num3);
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
			for (int k = num2; k < this.maxAwardNum; k++)
			{
				array[k].gameObject.SetActive(false);
			}
		}

		public Transform panelObject = null;

		public IXUIButton closeBtn = null;

		public IXUIWrapContent wrapContent = null;

		public IXUIScrollView panelScrollView = null;

		public TargetItemInfo targetItemInfo = null;

		private int maxAwardNum = 3;
	}
}
