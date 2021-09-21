using System;

namespace XMainClient
{
	// Token: 0x02000EB3 RID: 3763
	public interface INetEventData
	{
		// Token: 0x170034F3 RID: 13555
		// (get) Token: 0x0600C851 RID: 51281
		// (set) Token: 0x0600C852 RID: 51282
		Protocol protocol { get; set; }

		// Token: 0x170034F4 RID: 13556
		// (get) Token: 0x0600C853 RID: 51283
		// (set) Token: 0x0600C854 RID: 51284
		Rpc rpc { get; set; }

		// Token: 0x0600C855 RID: 51285
		void ManualReturnProtocol();
	}
}
