using System;

namespace XMainClient
{
	// Token: 0x02000EBA RID: 3770
	public interface INetObserver
	{
		// Token: 0x0600C86B RID: 51307
		void OnConnect(bool bSuccess);

		// Token: 0x0600C86C RID: 51308
		void OnClosed(NetErrCode nErrCode);

		// Token: 0x0600C86D RID: 51309
		void OnReceive(uint dwType, int nLen);
	}
}
