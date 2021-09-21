using System;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000DBB RID: 3515
	internal class XHudEntry
	{
		// Token: 0x1700335C RID: 13148
		// (get) Token: 0x0600BE89 RID: 48777 RVA: 0x0027CC18 File Offset: 0x0027AE18
		public float movementStart
		{
			get
			{
				return this.time + this.stay;
			}
		}

		// Token: 0x04004DE1 RID: 19937
		public bool init = false;

		// Token: 0x04004DE2 RID: 19938
		public float time;

		// Token: 0x04004DE3 RID: 19939
		public float stay = 0f;

		// Token: 0x04004DE4 RID: 19940
		public float offset = 0f;

		// Token: 0x04004DE5 RID: 19941
		public float val = 0f;

		// Token: 0x04004DE6 RID: 19942
		public IXUILabel label;

		// Token: 0x04004DE7 RID: 19943
		public bool isDigital = true;

		// Token: 0x04004DE8 RID: 19944
		public AnimationCurve offsetCurve = new AnimationCurve();

		// Token: 0x04004DE9 RID: 19945
		public AnimationCurve alphaCurve = new AnimationCurve();

		// Token: 0x04004DEA RID: 19946
		public AnimationCurve scaleCurve = new AnimationCurve();
	}
}
