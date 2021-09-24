using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_PkReqC2M
	{

		public static void OnReply(PkReqArg oArg, PkReqRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
					else
					{
						switch (oArg.type)
						{
						case PkReqType.PKREQ_ADDPK:
						{
							XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
							specificDocument.SetMatchTime(oRes.time, true);
							break;
						}
						case PkReqType.PKREQ_REMOVEPK:
						{
							XQualifyingDocument specificDocument2 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
							specificDocument2.SetMatchTime(0U, false);
							break;
						}
						case PkReqType.PKREQ_ALLINFO:
						{
							XQualifyingDocument specificDocument3 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
							specificDocument3.SetQualifyingInfo(oRes.allinfo);
							specificDocument3.SetChallengeRecordInfo(oRes.allinfo);
							break;
						}
						case PkReqType.PKREQ_FETCHPOINTREWARD:
						{
							XQualifyingDocument specificDocument4 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
							specificDocument4.RefreshPointReward(oArg.index);
							break;
						}
						}
					}
				}
			}
		}

		public static void OnTimeout(PkReqArg oArg)
		{
		}
	}
}
