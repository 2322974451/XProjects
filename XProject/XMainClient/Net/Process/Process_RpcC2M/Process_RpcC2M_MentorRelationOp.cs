using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_MentorRelationOp
	{

		public static void OnReply(MentorRelationOpArg oArg, MentorRelationOpRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XMentorshipDocument.Doc.OnGetMentorshipOpReply(oArg, oRes);
				}
			}
		}

		public static void OnTimeout(MentorRelationOpArg oArg)
		{
		}
	}
}
