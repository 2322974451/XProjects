﻿using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ChangeDeclaration
	{

		public static void OnReply(ChangeDeclarationArg oArg, ChangeDeclarationRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					bool flag3 = DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.HomepageHandler != null;
					if (flag3)
					{
						DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.HomepageHandler.SetDeclaration(oRes.declaration);
					}
				}
			}
		}

		public static void OnTimeout(ChangeDeclarationArg oArg)
		{
		}
	}
}
