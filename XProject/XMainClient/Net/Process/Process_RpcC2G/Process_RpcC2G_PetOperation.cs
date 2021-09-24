using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_PetOperation
	{

		public static void OnReply(PetOperationArg oArg, PetOperationRes oRes)
		{
			PetOP type = oArg.type;
			if (type == PetOP.PetExpTransfer)
			{
				bool flag = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.ExpTransferHandler != null;
				if (flag)
				{
					DlgBase<XPetMainView, XPetMainBehaviour>.singleton.ExpTransferHandler.m_CanTransfer = true;
				}
			}
			bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
				switch (oArg.type)
				{
				case PetOP.PetFellow:
					specificDocument.OnMount(oArg, oRes);
					break;
				case PetOP.PetFight:
					specificDocument.OnFight(oArg, oRes);
					break;
				case PetOP.PetFeed:
					specificDocument.OnFeed(oArg, oRes);
					break;
				case PetOP.PetTouch:
					specificDocument.OnPetTouch(oArg, oRes);
					break;
				case PetOP.PetRelease:
					specificDocument.OnRelease(oArg, oRes);
					break;
				case PetOP.ExpandSeat:
					specificDocument.OnBuySeat(oArg, oRes);
					break;
				case PetOP.SetPetPairRide:
					specificDocument.OnReqSetTravelSetBack(oArg, oRes);
					break;
				case PetOP.QueryPetPairRideInvite:
					specificDocument.OnReqReqInviteListBack(oArg, oRes);
					break;
				case PetOP.OffPetPairRide:
					specificDocument.OnReqOffPetPairRideBack();
					break;
				case PetOP.IgnorePetPairRideInvite:
					specificDocument.OnReqIgnoreAllBack();
					break;
				}
				specificDocument.OnPetOperation(oArg, oRes);
			}
		}

		public static void OnTimeout(PetOperationArg oArg)
		{
		}
	}
}
