using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E83 RID: 3715
	internal class TooltipButtonOperateSell : TooltipButtonOperateBase
	{
		// Token: 0x0600C69B RID: 50843 RVA: 0x002BF6E0 File Offset: 0x002BD8E0
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("SELL");
		}

		// Token: 0x0600C69C RID: 50844 RVA: 0x002BF6FC File Offset: 0x002BD8FC
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600C69D RID: 50845 RVA: 0x002BF710 File Offset: 0x002BD910
		public override bool IsButtonVisible(XItem item)
		{
			return this._CanItemBeSold(item);
		}

		// Token: 0x0600C69E RID: 50846 RVA: 0x002BF72C File Offset: 0x002BD92C
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

		// Token: 0x0600C69F RID: 50847 RVA: 0x002BF7F4 File Offset: 0x002BD9F4
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

		// Token: 0x0600C6A0 RID: 50848 RVA: 0x002BF884 File Offset: 0x002BDA84
		private bool _OnSellClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XSingleton<XGame>.singleton.Doc.XBagDoc.ReqItemSell(this.mainItemUID);
			return true;
		}

		// Token: 0x04005712 RID: 22290
		private int itemCount = 0;

		// Token: 0x04005713 RID: 22291
		private ItemList.RowData itemRowData = null;

		// Token: 0x04005714 RID: 22292
		private uint moneyID = 0U;

		// Token: 0x04005715 RID: 22293
		private uint moneyCount = 0U;
	}
}
