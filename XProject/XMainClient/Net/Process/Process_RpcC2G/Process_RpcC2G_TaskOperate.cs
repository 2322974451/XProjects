using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_TaskOperate
	{

		public static void OnReply(TaskOPArg oArg, TaskOPRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				bool result = oRes.result;
				if (result)
				{
					bool flag3 = oArg.taskOP == 1;
					if (flag3)
					{
						bool flag4 = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
						if (flag4)
						{
							XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
							XTaskInfo taskInfo = specificDocument.GetTaskInfo((uint)oArg.taskID);
							bool flag5 = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.CanAutoContinue(taskInfo);
							if (flag5)
							{
								DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.ShowNpcDialog(DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.m_npc);
							}
							else
							{
								DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
							}
						}
					}
					bool flag6 = oArg.taskOP == 2;
					if (flag6)
					{
						DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
					}
				}
			}
		}

		public static void OnTimeout(TaskOPArg oArg)
		{
		}
	}
}
