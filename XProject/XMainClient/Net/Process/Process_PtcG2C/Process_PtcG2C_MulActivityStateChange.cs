using System;

namespace XMainClient
{

	internal class Process_PtcG2C_MulActivityStateChange
	{

		public static void Process(PtcG2C_MulActivityStateChange roPtc)
		{
			XActivityDocument.Doc.ChangeActivityState(roPtc.Data.changeInfo);
		}
	}
}
