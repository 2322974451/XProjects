using System;

namespace XMainClient
{

	internal class Process_PtcM2C_LoginGuildInfo
	{

		public static void Process(PtcM2C_LoginGuildInfo roPtc)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			specificDocument.InitData(roPtc);
		}
	}
}
