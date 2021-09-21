using System;

namespace UILib
{
	// Token: 0x02000006 RID: 6
	public interface IXUIBillBoardCompRef
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001A RID: 26
		IXUISpecLabelSymbol NameSpecLabelSymbol { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001B RID: 27
		IXUISpecLabelSymbol GuildSpecLabelSymbol { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001C RID: 28
		IXUISpecLabelSymbol DesiSpecLabelSymbol { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001D RID: 29
		IXUIProgress BloodBar { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001E RID: 30
		IXUIProgress IndureBar { get; }
	}
}
