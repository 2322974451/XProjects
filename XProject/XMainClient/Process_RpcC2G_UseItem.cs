using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EC9 RID: 3785
	internal class Process_RpcC2G_UseItem
	{
		// Token: 0x0600C8C0 RID: 51392 RVA: 0x002CF09C File Offset: 0x002CD29C
		public static void OnReply(UseItemArg oArg, UseItemRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				XEquipCreateDocument.Doc.IsCreating = false;
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.ErrorCode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<XTutorialHelper>.singleton.UseItem = true;
					bool flag3 = oArg.OpType == 7U;
					if (flag3)
					{
						bool flag4 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
						if (flag4)
						{
							DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.PlayUseItemEffect(true);
						}
						ItemBuffTable.RowData itembuffDataByID = XHomeCookAndPartyDocument.Doc.GetItembuffDataByID(oArg.itemID);
						bool flag5 = itembuffDataByID != null;
						if (flag5)
						{
							BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)itembuffDataByID.Buffs[0, 0], (int)itembuffDataByID.Buffs[0, 1]);
							bool flag6 = buffData != null;
							if (flag6)
							{
								double num = Math.Round((double)(buffData.BuffDuration / 3600f), 1);
								string text = string.Format(XSingleton<XStringTable>.singleton.GetString("FoodBuffTip"), itembuffDataByID.Name, buffData.BuffName, num);
								XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
							}
						}
					}
					else
					{
						bool flag7 = oArg.OpType == 12U;
						if (flag7)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FASHION_STORAGE_SUCCESS"), "fece00");
						}
						else
						{
							bool flag8 = oArg.itemID > 0U;
							if (flag8)
							{
								ItemList.RowData itemConf = XBagDocument.GetItemConf((int)oArg.itemID);
								bool flag9 = (int)itemConf.ItemType == XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.Tarja);
								if (flag9)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("USE_ITEM_SUCCESS_TARJA"), "fece00");
								}
							}
						}
					}
					bool flag10 = oRes.expand != null;
					if (flag10)
					{
						XBagDocument.BagDoc.SetBagExpandData(oRes.expand, true);
					}
				}
				bool flag11 = ItemUseMgr.GetItemUseValue(ItemUse.Composite) == oArg.OpType;
				if (flag11)
				{
					XEquipCreateDocument.Doc.OnReqCreateEquipSet(oArg, oRes);
				}
				else
				{
					XCharacterItemDocument specificDocument = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
					specificDocument.OnUseItem(oArg, oRes);
					ArtifactBagDocument.Doc.OnUseItem(oArg, oRes);
					bool flag12 = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
					if (flag12)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
					}
				}
			}
		}

		// Token: 0x0600C8C1 RID: 51393 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(UseItemArg oArg)
		{
		}
	}
}
