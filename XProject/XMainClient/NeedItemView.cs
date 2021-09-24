using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class NeedItemView
	{

		public NeedItemView(bool showTotal = true)
		{
			this.bShowTotal = showTotal;
		}

		public void FindFrom(Transform t)
		{
			bool flag = t != null;
			if (flag)
			{
				this.goItem = t.gameObject;
				this.lbNum = (t.Find("Num").GetComponent("XUILabel") as IXUILabel);
				this.sprIcon = (t.Find("Icon").GetComponent("XUISprite") as IXUISprite);
			}
		}

		public void ResetItem()
		{
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.goItem, null);
			this.itemid = 0;
		}

		public bool SetItem(int itemID, int needCount)
		{
			this.itemid = itemID;
			this.itemcount = needCount;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.goItem, itemID, needCount, true);
			this.sprIcon.ID = (ulong)((long)itemID);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(itemID);
			ulong num = (ulong)((long)needCount);
			bool flag = itemCount >= num;
			if (flag)
			{
				bool flag2 = this.bShowTotal;
				if (flag2)
				{
					this.lbNum.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_FMT"), XSingleton<UiUtility>.singleton.NumberFormat(itemCount), XSingleton<UiUtility>.singleton.NumberFormat(num)));
				}
				else
				{
					this.lbNum.SetText(string.Format("{0}", XSingleton<UiUtility>.singleton.NumberFormat(num)));
				}
				this.bIsEnough = true;
			}
			else
			{
				bool flag3 = this.bShowTotal;
				if (flag3)
				{
					this.lbNum.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_NOTENOUGH_FMT"), XSingleton<UiUtility>.singleton.NumberFormat(itemCount), XSingleton<UiUtility>.singleton.NumberFormat(num)));
				}
				else
				{
					this.lbNum.SetText(string.Format("[FF0000]{0}[-]", XSingleton<UiUtility>.singleton.NumberFormat(num)));
				}
				this.bIsEnough = false;
			}
			return this.bIsEnough;
		}

		public GameObject goItem;

		public IXUISprite sprIcon;

		public IXUILabel lbNum;

		public bool bShowTotal;

		public int itemid;

		public int itemcount;

		public bool bIsEnough;
	}
}
