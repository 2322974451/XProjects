using System;

namespace XMainClient
{

	internal class Process_PtcG2C_HallIconSNtf
	{

		public static void Process(PtcG2C_HallIconSNtf roPtc)
		{
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument.OnHallIconNtfGet(roPtc.Data);
		}
	}
}
