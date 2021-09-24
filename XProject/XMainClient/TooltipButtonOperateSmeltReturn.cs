using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateSmeltReturn : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("SmeltReturn");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_SmeltReturn);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = item == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = item.Type == ItemType.EMBLEM;
					if (flag3)
					{
						XEmblemItem xemblemItem = item as XEmblemItem;
						bool bIsSkillEmblem = xemblemItem.bIsSkillEmblem;
						if (bIsSkillEmblem)
						{
							return false;
						}
					}
					result = true;
				}
			}
			return result;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(mainUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				uint num = 0U;
				bool flag2 = itemByUID.Type == ItemType.EMBLEM;
				if (flag2)
				{
					EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(itemByUID.itemID);
					bool flag3 = emblemConf != null && emblemConf.SmeltNeedItem.count > 0;
					if (flag3)
					{
						num = itemByUID.smeltDegreeNum * emblemConf.SmeltNeedItem[0, 1] * (uint)emblemConf.ReturnSmeltStoneRate / 100U;
					}
				}
				else
				{
					bool flag4 = itemByUID.Type == ItemType.EQUIP;
					if (flag4)
					{
						EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
						bool flag5 = equipConf != null && equipConf.SmeltNeedItem.count > 0;
						if (flag5)
						{
							num = itemByUID.smeltDegreeNum * equipConf.SmeltNeedItem[0, 1] * (uint)equipConf.ReturnSmeltStoneRate / 100U;
						}
					}
				}
				bool flag6 = num == 0U;
				if (flag6)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("SmeltReturnTips1"), "fece00");
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("SmeltReturnTips2"), num), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.SmeltStoneReturn));
				}
			}
		}

		private bool SmeltStoneReturn(IXUIButton btn)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				XSmeltDocument.Doc.ReqSmeltReturn(itemByUID.uid);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}
	}
}
