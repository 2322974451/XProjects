using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F05 RID: 3845
	internal class XItemDrawerParam
	{
		// Token: 0x0600CC37 RID: 52279 RVA: 0x002EF254 File Offset: 0x002ED454
		public void Reset()
		{
			this.Profession = XItemDrawerParam.DefaultProfession;
			this.IconType = 0U;
			this.bShowLevelReq = true;
			this.bShowProfReq = true;
			this.bBinding = false;
			this.MaxItemCount = -1;
			this.NumColor = null;
			this.bHideBinding = false;
			this.bShowMask = false;
			this.MaxShowNum = -1;
		}

		// Token: 0x04005AB9 RID: 23225
		public static uint DefaultProfession = 0U;

		// Token: 0x04005ABA RID: 23226
		public uint Profession = 0U;

		// Token: 0x04005ABB RID: 23227
		public uint IconType = 0U;

		// Token: 0x04005ABC RID: 23228
		public bool bShowLevelReq = true;

		// Token: 0x04005ABD RID: 23229
		public bool bShowProfReq = true;

		// Token: 0x04005ABE RID: 23230
		public bool bBinding = false;

		// Token: 0x04005ABF RID: 23231
		public int MaxItemCount = -1;

		// Token: 0x04005AC0 RID: 23232
		public Color? NumColor = null;

		// Token: 0x04005AC1 RID: 23233
		public bool bHideBinding;

		// Token: 0x04005AC2 RID: 23234
		public bool bShowMask;

		// Token: 0x04005AC3 RID: 23235
		public int MaxShowNum = -1;
	}
}
