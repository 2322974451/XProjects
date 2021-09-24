using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XTssSdk : XSingleton<XTssSdk>, ITssSdkSend, IXInterface
	{

		public void SendDataToServer(byte[] data, uint length)
		{
			bool flag = !string.IsNullOrEmpty(XSingleton<XLoginDocument>.singleton.OpenID);
			if (flag)
			{
				PtcC2G_TssSdkSendAnti2Server ptcC2G_TssSdkSendAnti2Server = new PtcC2G_TssSdkSendAnti2Server();
				ptcC2G_TssSdkSendAnti2Server.Data.anti_data = data;
				ptcC2G_TssSdkSendAnti2Server.Data.anti_data_len = length;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_TssSdkSendAnti2Server);
			}
		}

		public bool Deprecated { get; set; }
	}
}
