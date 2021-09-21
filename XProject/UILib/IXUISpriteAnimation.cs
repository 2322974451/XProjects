using System;

namespace UILib
{
	// Token: 0x0200004A RID: 74
	public interface IXUISpriteAnimation : IXUIObject
	{
		// Token: 0x060001FB RID: 507
		void SetNamePrefix(string name);

		// Token: 0x060001FC RID: 508
		void SetNamePrefix(string atlas, string name);

		// Token: 0x060001FD RID: 509
		void SetFrameRate(int rate);

		// Token: 0x060001FE RID: 510
		void Reset();

		// Token: 0x060001FF RID: 511
		void StopAndReset();

		// Token: 0x06000200 RID: 512
		void RegisterFinishCallback(SpriteAnimationFinishCallback callback);

		// Token: 0x06000201 RID: 513
		void MakePixelPerfect();
	}
}
