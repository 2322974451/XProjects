using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_UpdateStageInfoNtf
	{

		public static void Process(PtcG2C_UpdateStageInfoNtf roPtc)
		{
			XSingleton<XStageProgress>.singleton.Init(roPtc.Data.Stages);
			XAbyssPartyDocument specificDocument = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			bool flag = roPtc.Data.Stages.absparty != null;
			if (flag)
			{
				specificDocument.SetAbyssIndex(roPtc.Data.Stages.absparty.aby);
			}
		}
	}
}
