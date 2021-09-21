using System;

namespace UILib
{
	// Token: 0x0200002F RID: 47
	public interface IXUIScrollBar
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000136 RID: 310
		// (set) Token: 0x06000137 RID: 311
		float value { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000138 RID: 312
		// (set) Token: 0x06000139 RID: 313
		float size { get; set; }

		// Token: 0x0600013A RID: 314
		void RegisterScrollBarChangeEventHandler(ScrollBarChangeEventHandler eventHandler);

		// Token: 0x0600013B RID: 315
		void RegisterScrollBarDragFinishedEventHandler(ScrollBarDragFinishedEventHandler eventHandler);
	}
}
