using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000B25 RID: 2853
	internal class XSuperRiskMapRenderer
	{
		// Token: 0x0600A75E RID: 42846 RVA: 0x001D9435 File Offset: 0x001D7635
		public void SetInitInfo(Vector2 _ZeroPos, float stepx, float stepy)
		{
			this.ZeroPos = _ZeroPos;
			this.StepSizeX = stepx;
			this.StepSizeY = stepy;
		}

		// Token: 0x0600A75F RID: 42847 RVA: 0x001D9450 File Offset: 0x001D7650
		public Vector2 CoordToUI(Coordinate coord)
		{
			return this.ZeroPos + new Vector2((float)coord.x * this.StepSizeX, (float)(-(float)coord.y) * this.StepSizeY);
		}

		// Token: 0x04003DD7 RID: 15831
		private Vector2 ZeroPos = Vector2.zero;

		// Token: 0x04003DD8 RID: 15832
		private float StepSizeX = 0f;

		// Token: 0x04003DD9 RID: 15833
		private float StepSizeY = 0f;
	}
}
