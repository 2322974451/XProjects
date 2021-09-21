using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x0200002C RID: 44
	public interface IXUIProgress : IXUIObject
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000124 RID: 292
		// (set) Token: 0x06000125 RID: 293
		float value { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000126 RID: 294
		// (set) Token: 0x06000127 RID: 295
		int width { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000128 RID: 296
		GameObject foreground { get; }

		// Token: 0x06000129 RID: 297
		void SetValueWithAnimation(float value);

		// Token: 0x0600012A RID: 298
		void SetTotalSection(uint section);

		// Token: 0x0600012B RID: 299
		void SetDepthOffset(int d);

		// Token: 0x0600012C RID: 300
		void SetForegroundColor(Color c);

		// Token: 0x0600012D RID: 301
		void ForceUpdate();
	}
}
