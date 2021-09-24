using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateSell : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("SELL");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			return this._CanItemBeSold(item);
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.moneyID);
			bool flag = itemConf == null || this.itemRowData == null;
			if (!flag)
			{
				string @string = XStringDefineProxy.GetString("ItemSellConfirm", new object[]
				{
					this.itemCount.ToString(),
					XSingleton<UiUtility>.singleton.ChooseProfString(this.itemRowData.ItemName, 0U),
					((long)((ulong)this.moneyCount * (ulong)((long)this.itemCount))).ToString(),
					XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U)
				});
				XSingleton<UiUtility>.singleton.ShowModalDialog(@string, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._OnSellClicked));
			}
		}

		protected bool _CanItemBeSold(XItem item)
		{
			bool flag = item == null || item.itemConf == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = item.itemConf.Sell[0] > 0U;
				if (flag2)
				{
					this.itemCount = item.itemCount;
					this.itemRowData = item.itemConf;
					this.moneyID = item.itemConf.Sell[0];
					this.moneyCount = item.itemConf.Sell[1];
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		private bool _OnSellClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XSingleton<XGame>.singleton.Doc.XBagDoc.ReqItemSell(this.mainItemUID);
			return true;
		}

		private int itemCount = 0;

		private ItemList.RowData itemRowData = null;

		private uint moneyID = 0U;

		private uint moneyCount = 0U;
	}
}
