using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_PkTimeoutM2CNtf
	{

		public static void Process(PtcM2C_PkTimeoutM2CNtf roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MATCH_TIME_OUT"), "fece00");
			XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
			specificDocument.SetMatchTime(0U, false);
		}
	}
}
