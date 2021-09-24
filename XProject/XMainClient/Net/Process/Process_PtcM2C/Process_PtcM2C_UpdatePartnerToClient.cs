using System;

namespace XMainClient
{

	internal class Process_PtcM2C_UpdatePartnerToClient
	{

		public static void Process(PtcM2C_UpdatePartnerToClient roPtc)
		{
			XPartnerDocument.Doc.UpdatePartnerToClient(roPtc);
		}
	}
}
