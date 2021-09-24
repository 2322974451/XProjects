using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_PetOperationOther
	{

		public static void OnReply(PetOperationOtherArg oArg, PetOperationOtherRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
				specificDocument.OnPetPetOperationOtherBack(oArg, oRes);
			}
		}

		public static void OnTimeout(PetOperationOtherArg oArg)
		{
		}
	}
}
