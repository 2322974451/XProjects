using System;

namespace XMainClient
{

	internal class XLotteryBoxItem : XItem
	{

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

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XLotteryBoxItem>.Recycle(this);
		}

		public static readonly int POOL_SIZE = 8;

		public XItem[] itemList = new XItem[XLotteryBoxItem.POOL_SIZE];
	}
}
