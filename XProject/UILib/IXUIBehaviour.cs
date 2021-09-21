using System;

namespace UILib
{
	// Token: 0x02000005 RID: 5
	public interface IXUIBehaviour : IXUIObject
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24
		IXUIDlg uiDlgInterface { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000019 RID: 25
		IXUIObject[] uiChilds { get; }
	}
}
