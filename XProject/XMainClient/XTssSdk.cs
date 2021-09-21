using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B35 RID: 2869
	public class XTssSdk : XSingleton<XTssSdk>, ITssSdkSend, IXInterface
	{
		// Token: 0x0600A7F5 RID: 42997 RVA: 0x001DDF08 File Offset: 0x001DC108
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

		// Token: 0x17003017 RID: 12311
		// (get) Token: 0x0600A7F6 RID: 42998 RVA: 0x001DDF5A File Offset: 0x001DC15A
		// (set) Token: 0x0600A7F7 RID: 42999 RVA: 0x001DDF62 File Offset: 0x001DC162
		public bool Deprecated { get; set; }
	}
}
