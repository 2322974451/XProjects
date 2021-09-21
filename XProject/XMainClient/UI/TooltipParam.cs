using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001917 RID: 6423
	internal class TooltipParam : XSingleton<TooltipParam>
	{
		// Token: 0x06010CCF RID: 68815 RVA: 0x00438ED6 File Offset: 0x004370D6
		public void Reset()
		{
			this.BodyBag = null;
			this.bEquiped = false;
			this.bBinded = false;
			this.bShowPutInBtn = false;
			this.bShowTakeOutBtn = false;
			this.mainAttributes = null;
			this.compareAttributes = null;
			this.FashionOnBody = null;
		}

		// Token: 0x04007B3C RID: 31548
		public XBodyBag BodyBag = null;

		// Token: 0x04007B3D RID: 31549
		public List<uint> FashionOnBody;

		// Token: 0x04007B3E RID: 31550
		public bool bEquiped = false;

		// Token: 0x04007B3F RID: 31551
		public bool bBinded = false;

		// Token: 0x04007B40 RID: 31552
		public bool bShowPutInBtn = false;

		// Token: 0x04007B41 RID: 31553
		public bool bShowTakeOutBtn = false;

		// Token: 0x04007B42 RID: 31554
		public XAttributes mainAttributes = null;

		// Token: 0x04007B43 RID: 31555
		public XAttributes compareAttributes = null;
	}
}
