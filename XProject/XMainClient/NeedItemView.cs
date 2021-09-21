using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CDB RID: 3291
	internal class NeedItemView
	{
		// Token: 0x0600B886 RID: 47238 RVA: 0x00252A72 File Offset: 0x00250C72
		public NeedItemView(bool showTotal = true)
		{
			this.bShowTotal = showTotal;
		}

		// Token: 0x0600B887 RID: 47239 RVA: 0x00252A84 File Offset: 0x00250C84
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

		// Token: 0x0600B888 RID: 47240 RVA: 0x00252AEB File Offset: 0x00250CEB
		public void ResetItem()
		{
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.goItem, null);
			this.itemid = 0;
		}

		// Token: 0x0600B889 RID: 47241 RVA: 0x00252B08 File Offset: 0x00250D08
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

		// Token: 0x0400490C RID: 18700
		public GameObject goItem;

		// Token: 0x0400490D RID: 18701
		public IXUISprite sprIcon;

		// Token: 0x0400490E RID: 18702
		public IXUILabel lbNum;

		// Token: 0x0400490F RID: 18703
		public bool bShowTotal;

		// Token: 0x04004910 RID: 18704
		public int itemid;

		// Token: 0x04004911 RID: 18705
		public int itemcount;

		// Token: 0x04004912 RID: 18706
		public bool bIsEnough;
	}
}
