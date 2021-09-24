using System;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_TssSdkAntiDataNtf
	{

		public static void Process(PtcG2C_TssSdkAntiDataNtf roPtc)
		{
			XSingleton<XUpdater.XUpdater>.singleton.XTssSdk.OnRcvWhichNeedToSendClientSdk(roPtc.Data.anti_data, roPtc.Data.anti_data_len);
		}
	}
}
