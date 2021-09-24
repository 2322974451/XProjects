using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ChooseSpecialEffects
	{

		public static void OnReply(ChooseSpecialEffectsArg oArg, ChooseSpecialEffectsRes oRes)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.SetActiveSuitEffect(oArg, oRes);
		}

		public static void OnTimeout(ChooseSpecialEffectsArg oArg)
		{
		}
	}
}
