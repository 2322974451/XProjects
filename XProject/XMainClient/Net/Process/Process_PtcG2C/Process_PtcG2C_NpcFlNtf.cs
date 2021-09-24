using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NpcFlNtf
	{

		public static void Process(PtcG2C_NpcFlNtf roPtc)
		{
			XNPCFavorDocument specificDocument = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			specificDocument.OnNpcFeelingChange(roPtc.Data);
		}
	}
}
