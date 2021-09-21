using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001EB RID: 491
	public interface IRenderObject
	{
		// Token: 0x170000D1 RID: 209
		// (set) Token: 0x06000B43 RID: 2883
		int InstanceID { set; }

		// Token: 0x06000B44 RID: 2884
		bool IsSameObj(int id);

		// Token: 0x06000B45 RID: 2885
		void SetRenderLayer(int layer);

		// Token: 0x06000B46 RID: 2886
		void SetShader(int type);

		// Token: 0x06000B47 RID: 2887
		void ResetShader();

		// Token: 0x06000B48 RID: 2888
		void SetColor(byte r, byte g, byte b, byte a);

		// Token: 0x06000B49 RID: 2889
		void SetColor(Color32 c);

		// Token: 0x06000B4A RID: 2890
		void Clean();

		// Token: 0x06000B4B RID: 2891
		void Update();
	}
}
