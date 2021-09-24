using System;

namespace XMainClient
{

	internal class Process_PtcG2C_LoginReward2CNtf
	{

		public static void Process(PtcG2C_LoginReward2CNtf roPtc)
		{
			XSevenLoginDocument specificDocument = XDocuments.GetSpecificDocument<XSevenLoginDocument>(XSevenLoginDocument.uuID);
			specificDocument.OnSevenLoginReward(roPtc.Data);
		}
	}
}
