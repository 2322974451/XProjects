using System;

namespace UILib
{
	// Token: 0x02000025 RID: 37
	public interface IUIDummy : IUIWidget, IUIRect
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000F7 RID: 247
		int RenderQueue { get; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000F8 RID: 248
		// (set) Token: 0x060000F9 RID: 249
		RefreshRenderQueueCb RefreshRenderQueue { get; set; }

		// Token: 0x060000FA RID: 250
		void Reset();

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000FB RID: 251
		// (set) Token: 0x060000FC RID: 252
		int depth { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000FD RID: 253
		// (set) Token: 0x060000FE RID: 254
		float alpha { get; set; }
	}
}
