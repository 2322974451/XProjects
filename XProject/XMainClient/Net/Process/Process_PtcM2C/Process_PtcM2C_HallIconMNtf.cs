using System;

namespace XMainClient
{

	internal class Process_PtcM2C_HallIconMNtf
	{

		public static void Process(PtcM2C_HallIconMNtf roPtc)
		{
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument.OnHallIconNtfGet(roPtc.Data);
		}
	}
}
