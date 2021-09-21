using System;

namespace UILib
{
	// Token: 0x0200001F RID: 31
	public interface IXUIList : IXUIObject
	{
		// Token: 0x060000D3 RID: 211
		void Refresh();

		// Token: 0x060000D4 RID: 212
		void CloseList();

		// Token: 0x060000D5 RID: 213
		void SetAnimateSmooth(bool b);

		// Token: 0x060000D6 RID: 214
		void RegisterRepositionHandle(OnAfterRepostion reposition);

		// Token: 0x060000D7 RID: 215
		IUIRect GetParentUIRect();

		// Token: 0x060000D8 RID: 216
		IUIPanel GetParentPanel();
	}
}
