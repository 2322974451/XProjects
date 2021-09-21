using System;

namespace XMainClient
{
	// Token: 0x02000EB8 RID: 3768
	public interface INetSender
	{
		// Token: 0x0600C868 RID: 51304
		bool Send(Protocol protocol);

		// Token: 0x0600C869 RID: 51305
		bool Send(Rpc rpc);
	}
}
