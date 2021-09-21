using System;

namespace UILib
{
	// Token: 0x02000032 RID: 50
	public interface IXUISlider : IXUIObject
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000144 RID: 324
		// (set) Token: 0x06000145 RID: 325
		float Value { get; set; }

		// Token: 0x06000146 RID: 326
		void RegisterValueChangeEventHandler(SliderValueChangeEventHandler eventHandler);

		// Token: 0x06000147 RID: 327
		void RegisterClickEventHandler(SliderClickEventHandler eventHandler);
	}
}
