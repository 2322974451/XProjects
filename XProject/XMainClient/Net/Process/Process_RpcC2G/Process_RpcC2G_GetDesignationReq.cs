using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetDesignationReq
	{

		public static void OnReply(GetDesignationReq oArg, GetDesignationRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
				specificDocument.MaxAbilityDesNum = oRes.maxPPT;
				specificDocument.SetDesignationInfo(1U, oRes.coverDesignationID, oRes.name);
				specificDocument.SetDesignationInfo(2U, oRes.abilityDesignationID, oRes.name);
				specificDocument.SetTabRedPoint(oRes.dataList);
			}
		}

		public static void OnTimeout(GetDesignationReq oArg)
		{
		}
	}
}
