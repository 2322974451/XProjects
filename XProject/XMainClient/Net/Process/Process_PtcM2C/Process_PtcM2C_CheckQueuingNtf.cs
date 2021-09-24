using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_CheckQueuingNtf
	{

		public static void Process(PtcM2C_CheckQueuingNtf roPtc)
		{
			ErrorCode errorcode = roPtc.Data.errorcode;
			if (errorcode != ErrorCode.ERR_SUCCESS)
			{
				if (errorcode == ErrorCode.ERR_ACCOUNT_QUEUING)
				{
					XSingleton<XLoginDocument>.singleton.WaitForServerQueue(roPtc.Data.rolecount, roPtc.Data.timeleft);
				}
			}
			else
			{
				XSingleton<XLoginDocument>.singleton.EnterToSelectChar();
			}
		}
	}
}
