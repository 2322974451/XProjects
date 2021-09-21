using System;

namespace XUtliPoolLib
{
	// Token: 0x0200006E RID: 110
	public interface ITssSdk
	{
		// Token: 0x06000392 RID: 914
		void OnLogin(int platf, string openId, uint worldId, string roleId);

		// Token: 0x06000393 RID: 915
		void OnRcvWhichNeedToSendClientSdk(byte[] data, uint length);
	}
}
