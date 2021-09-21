using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016CD RID: 5837
	internal class XTargetRewardPopWindow
	{
		// Token: 0x0600F0BF RID: 61631 RVA: 0x00350098 File Offset: 0x0034E298
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

		// Token: 0x0600F0C0 RID: 61632 RVA: 0x003500F4 File Offset: 0x0034E2F4
		private bool OnClosePopwindow(IXUIButton btn)
		{
			bool flag = this.panelObject != null;
			if (flag)
			{
				this.panelObject.gameObject.SetActive(false);
			}
			return true;
		}

		// Token: 0x0600F0C1 RID: 61633 RVA: 0x0035012C File Offset: 0x0034E32C
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

		// Token: 0x0600F0C2 RID: 61634 RVA: 0x0035018C File Offset: 0x0034E38C
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

		// Token: 0x0600F0C3 RID: 61635 RVA: 0x003501FC File Offset: 0x0034E3FC
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

		// Token: 0x040066B6 RID: 26294
		public Transform panelObject = null;

		// Token: 0x040066B7 RID: 26295
		public IXUIButton closeBtn = null;

		// Token: 0x040066B8 RID: 26296
		public IXUIWrapContent wrapContent = null;

		// Token: 0x040066B9 RID: 26297
		public IXUIScrollView panelScrollView = null;

		// Token: 0x040066BA RID: 26298
		public TargetItemInfo targetItemInfo = null;

		// Token: 0x040066BB RID: 26299
		private int maxAwardNum = 3;
	}
}
