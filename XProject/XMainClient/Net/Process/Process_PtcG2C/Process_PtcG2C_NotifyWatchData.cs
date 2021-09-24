using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NotifyWatchData
	{

		public static void Process(PtcG2C_NotifyWatchData roPtc)
		{
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			specificDocument.DealWithTeamMessage(roPtc.Data);
		}
	}
}
