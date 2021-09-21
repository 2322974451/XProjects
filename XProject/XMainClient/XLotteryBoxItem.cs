using System;

namespace XMainClient
{
	// Token: 0x02000DEE RID: 3566
	internal class XLotteryBoxItem : XItem
	{
		// Token: 0x0600C10D RID: 49421 RVA: 0x0028E444 File Offset: 0x0028C644
		public override void Init()
		{
			base.Init();
			for (int i = 0; i < XLotteryBoxItem.POOL_SIZE; i++)
			{
				XItem xitem = this.itemList[i];
				bool flag = xitem == null;
				if (flag)
				{
					xitem = new XNormalItem();
					this.itemList[i] = xitem;
				}
				xitem.itemID = 0;
				xitem.itemCount = 0;
			}
		}

		// Token: 0x0600C10E RID: 49422 RVA: 0x0028E49F File Offset: 0x0028C69F
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XLotteryBoxItem>.Recycle(this);
		}

		// Token: 0x04005129 RID: 20777
		public static readonly int POOL_SIZE = 8;

		// Token: 0x0400512A RID: 20778
		public XItem[] itemList = new XItem[XLotteryBoxItem.POOL_SIZE];
	}
}
