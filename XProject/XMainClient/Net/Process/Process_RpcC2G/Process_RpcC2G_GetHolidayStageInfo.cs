using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GetHolidayStageInfo
	{

		public static void OnReply(GetHolidayStageInfoArg oArg, GetHolidayStageInfoRes oRes)
		{
			XOperatingActivityDocument specificDocument = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
			specificDocument.SetHolidayData(oRes);
		}

		public static void OnTimeout(GetHolidayStageInfoArg oArg)
		{
		}
	}
}
