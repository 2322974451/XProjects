using System;

namespace UILib
{
	// Token: 0x02000048 RID: 72
	public interface IXUILabelSymbol : IXUIObject
	{
		// Token: 0x17000055 RID: 85
		// (set) Token: 0x060001EA RID: 490
		string InputText { set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001EB RID: 491
		IXUISprite IBoardSprite { get; }

		// Token: 0x060001EC RID: 492
		void UpdateDepth(int depth);

		// Token: 0x060001ED RID: 493
		void RegisterTeamEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001EE RID: 494
		void RegisterGuildEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001EF RID: 495
		void RegisterDragonGuildEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001F0 RID: 496
		void RegisterItemEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001F1 RID: 497
		void RegisterNameEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001F2 RID: 498
		void RegisterPkEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001F3 RID: 499
		void RegisterSpectateEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001F4 RID: 500
		void RegisterUIEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001F5 RID: 501
		void RegisterDefaultEventHandler(HyperLinkClickEventHandler eventHandler);

		// Token: 0x060001F6 RID: 502
		void RegisterSymbolClickHandler(LabelSymbolClickEventHandler eventHandler);
	}
}
