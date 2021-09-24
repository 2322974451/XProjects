using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateCompose : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("UPGRADE");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			bool flag = item == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Compose);
				bool flag3 = !flag2;
				if (flag3)
				{
					result = false;
				}
				else
				{
					XEquipCreateDocument doc = XEquipCreateDocument.Doc;
					ItemComposeTable.RowData itemCoomposeRow = doc.GetItemCoomposeRow(item.itemID);
					bool flag4 = itemCoomposeRow == null;
					if (flag4)
					{
						result = false;
					}
					else
					{
						this.itemRowData = XBagDocument.GetItemConf(itemCoomposeRow.ItemID);
						bool flag5 = this.itemRowData == null;
						if (flag5)
						{
							result = false;
						}
						else
						{
							this.m_composeName = XSingleton<UiUtility>.singleton.ChooseProfString(this.itemRowData.ItemName, 0U);
							this.m_composeDividend = itemCoomposeRow.SrcItem1[1];
							this.m_level = itemCoomposeRow.Level;
							result = true;
						}
					}
				}
			}
			return result;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				bool flag2 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)this.m_level);
				if (flag2)
				{
					string text = string.Format(XSingleton<XStringTable>.singleton.GetString("CannotCompose"), this.m_level);
					XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
					return;
				}
			}
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.mainItemUID);
			bool flag3 = itemByUID == null;
			if (!flag3)
			{
				int itemCount = itemByUID.itemCount;
				string text2 = XSingleton<UiUtility>.singleton.ChooseProfString(itemByUID.itemConf.ItemName, 0U);
				bool flag4 = itemCount >= this.m_composeDividend;
				if (flag4)
				{
					int num = itemCount / this.m_composeDividend;
					int num2 = num * this.m_composeDividend;
					string text3 = XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("ItemComposeTips1"));
					text3 = string.Format(text3, new object[]
					{
						num2,
						text2,
						num,
						this.m_composeName,
						this.m_composeDividend
					});
					XSingleton<UiUtility>.singleton.ShowModalDialog(text3, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._OnComposeClicked));
				}
				else
				{
					string text4 = string.Format(XSingleton<XStringTable>.singleton.GetString("ItemComposeTips2"), this.m_composeDividend);
					XSingleton<UiUtility>.singleton.ShowSystemTip(text4, "fece00");
				}
			}
		}

		private bool _OnComposeClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XSingleton<XGame>.singleton.Doc.XBagDoc.ReqItemCompose(this.mainItemUID);
			return true;
		}

		private int m_composeDividend = 1;

		private int m_level = 1;

		private string m_composeName = "";

		private ItemList.RowData itemRowData = null;
	}
}
