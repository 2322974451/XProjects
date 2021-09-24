using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFlowerSendDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFlowerSendDocument.uuID;
			}
		}

		public void SendFlower(ulong roleID, uint count, uint sendItemID)
		{
			RpcC2G_SendFlower rpcC2G_SendFlower = new RpcC2G_SendFlower();
			rpcC2G_SendFlower.oArg.roleid = roleID;
			rpcC2G_SendFlower.oArg.count = count;
			rpcC2G_SendFlower.oArg.sendItemID = sendItemID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SendFlower);
		}

		public void SendFlower(ulong roleID, uint count, uint sendItemID, uint needCostID, uint needCostCount)
		{
			RpcC2G_SendFlower rpcC2G_SendFlower = new RpcC2G_SendFlower();
			rpcC2G_SendFlower.oArg.roleid = roleID;
			rpcC2G_SendFlower.oArg.count = count;
			rpcC2G_SendFlower.oArg.sendItemID = sendItemID;
			rpcC2G_SendFlower.oArg.costItemID = needCostID;
			rpcC2G_SendFlower.oArg.costItemNum = needCostCount;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SendFlower);
		}

		public void OnSendFlower(SendFlowerArg oArg, SendFlowerRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.RefreshSendFlowerInfo();
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)oArg.sendItemID);
				string arg = (itemConf != null) ? XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U) : "";
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("FLOWER_SEND_SUC"), oArg.count, arg), "fece00");
				XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
				bool flag2 = specificDocument.View != null && specificDocument.View.IsVisible();
				if (flag2)
				{
					specificDocument.View.ReReqRank();
				}
			}
			else
			{
				bool flag3 = oRes.errorcode == ErrorCode.ERR_ITEM_NEED_DIAMOND;
				if (flag3)
				{
					DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.ShowGoToMallError(oArg);
				}
				else
				{
					bool flag4 = oRes.errorcode == ErrorCode.ERR_ITEM_NOT_ENOUGH;
					if (flag4)
					{
						DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.FlowerNotEnough(oArg);
					}
					else
					{
						bool flag5 = oRes.errorcode == ErrorCode.ERR_SHOP_LACKMONEY;
						if (flag5)
						{
							DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.ShowLackMoneyError();
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
						}
					}
				}
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FlowerSendDocument");
	}
}
