using System;

namespace UILib
{
	// Token: 0x02000026 RID: 38
	public interface IUIBloodGrid : IUIWidget, IUIRect
	{
		// Token: 0x060000FF RID: 255
		void SetMAXHP(int maxHp);

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000100 RID: 256
		int MAXHP { get; }
	}
}
