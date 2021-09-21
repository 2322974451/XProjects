using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000990 RID: 2448
	internal class XFlowerSendDocument : XDocComponent
	{
		// Token: 0x17002CB9 RID: 11449
		// (get) Token: 0x06009338 RID: 37688 RVA: 0x00157E1C File Offset: 0x0015601C
		public override uint ID
		{
			get
			{
				return XFlowerSendDocument.uuID;
			}
		}

		// Token: 0x06009339 RID: 37689 RVA: 0x00157E34 File Offset: 0x00156034
		public void SendFlower(ulong roleID, uint count, uint sendItemID)
		{
			RpcC2G_SendFlower rpcC2G_SendFlower = new RpcC2G_SendFlower();
			rpcC2G_SendFlower.oArg.roleid = roleID;
			rpcC2G_SendFlower.oArg.count = count;
			rpcC2G_SendFlower.oArg.sendItemID = sendItemID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SendFlower);
		}

		// Token: 0x0600933A RID: 37690 RVA: 0x00157E7C File Offset: 0x0015607C
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

		// Token: 0x0600933B RID: 37691 RVA: 0x00157EE0 File Offset: 0x001560E0
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

		// Token: 0x0600933C RID: 37692 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0400317C RID: 12668
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FlowerSendDocument");
	}
}
