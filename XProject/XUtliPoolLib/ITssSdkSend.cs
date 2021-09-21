using System;

namespace XUtliPoolLib
{
	// Token: 0x0200006F RID: 111
	public interface ITssSdkSend : IXInterface
	{
		// Token: 0x06000394 RID: 916
		void SendDataToServer(byte[] data, uint length);
	}
}
