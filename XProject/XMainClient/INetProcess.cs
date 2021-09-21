using System;

namespace XMainClient
{
	// Token: 0x02000EB6 RID: 3766
	public interface INetProcess
	{
		// Token: 0x0600C861 RID: 51297
		void OnConnect(bool bSuccess);

		// Token: 0x0600C862 RID: 51298
		void OnClosed(NetErrCode nErrCode);

		// Token: 0x0600C863 RID: 51299
		void OnPrePropress(NetEvent data);

		// Token: 0x0600C864 RID: 51300
		void OnProcess(NetEvent data);

		// Token: 0x0600C865 RID: 51301
		void OnPostProcess(NetEvent data);
	}
}
