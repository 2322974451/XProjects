using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateItemAny : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return this.m_Text;
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

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

		private string m_Text;

		private ulong m_useCount;
	}
}
