using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008AF RID: 2223
	public struct SceneMat
	{
		// Token: 0x06008668 RID: 34408 RVA: 0x0010F314 File Offset: 0x0010D514
		public void Fade(bool enable)
		{
			Material sharedMaterial = this.render.sharedMaterial;
			bool flag = sharedMaterial == null;
			if (!flag)
			{
				if (enable)
				{
					bool flag2 = this.srcMat == null;
					if (flag2)
					{
						this.srcMat = sharedMaterial;
						this.render.material.shader = ShaderManager._fade_maskR_noLight;
					}
				}
				else
				{
					this.render.sharedMaterial = this.srcMat;
				}
			}
		}

		// Token: 0x06008669 RID: 34409 RVA: 0x0010F387 File Offset: 0x0010D587
		public void InitRender(Renderer r)
		{
			this.render = r;
		}

		// Token: 0x040029FE RID: 10750
		public Renderer render;

		// Token: 0x040029FF RID: 10751
		public Material srcMat;
	}
}
