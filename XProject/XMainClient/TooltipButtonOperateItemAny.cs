using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CA2 RID: 3234
	internal class TooltipButtonOperateItemAny : TooltipButtonOperateBase
	{
		// Token: 0x0600B637 RID: 46647 RVA: 0x0024192C File Offset: 0x0023FB2C
		public override string GetButtonText()
		{
			return this.m_Text;
		}

		// Token: 0x0600B638 RID: 46648 RVA: 0x00241944 File Offset: 0x0023FB44
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B639 RID: 46649 RVA: 0x00241958 File Offset: 0x0023FB58
		public override bool IsButtonVisible(XItem item)
		{
			ItemType type = item.Type;
			if (type != ItemType.PECK)
			{
				if (type == ItemType.EMBLEM_MATERIAL)
				{
					this.m_Text = XStringDefineProxy.GetString("Make");
					return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Char_Emblem) && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_EquipCreate_EmblemSet);
				}
			}
			else
			{
				ChestList.RowData chestConf = XBagDocument.GetChestConf(item.itemID);
				bool flag = chestConf != null && chestConf.MultiOpen;
				if (flag)
				{
					this.m_useCount = (ulong)((long)XBagDocument.BagDoc.ItemBag.GetItemCountByUid(item.uid));
					bool flag2 = this.m_useCount > 1UL;
					if (flag2)
					{
						this.m_Text = XStringDefineProxy.GetString("OpenAll");
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600B63A RID: 46650 RVA: 0x00241A1C File Offset: 0x0023FC1C
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID == null;
			if (!flag)
			{
				ItemType type = itemByUID.Type;
				if (type != ItemType.PECK)
				{
					if (type == ItemType.EMBLEM_MATERIAL)
					{
						XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_EquipCreate_EmblemSet, 0UL);
					}
				}
				else
				{
					ChestList.RowData chestConf = XBagDocument.GetChestConf(itemByUID.itemID);
					bool flag2 = chestConf != null && chestConf.MultiOpen;
					if (flag2)
					{
						this.OpenAnyTimesTip(itemByUID);
					}
				}
			}
		}

		// Token: 0x0600B63B RID: 46651 RVA: 0x00241AB0 File Offset: 0x0023FCB0
		private void OpenAnyTimesTip(XItem item)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
			bool flag = !item.bBinding && itemConf != null && itemConf.IsNeedShowTipsPanel == 1;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("CanNotSeal"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.UseOnceItem));
			}
			else
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(item, 0U, 0U);
			}
		}

		// Token: 0x0600B63C RID: 46652 RVA: 0x00241B38 File Offset: 0x0023FD38
		private bool UseOnceItem(IXUIButton btn)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 0U);
				XSingleton<UiUtility>.singleton.CloseModalDlg();
				result = true;
			}
			return result;
		}

		// Token: 0x0400474F RID: 18255
		private string m_Text;

		// Token: 0x04004750 RID: 18256
		private ulong m_useCount;
	}
}
