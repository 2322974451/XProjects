using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public struct SceneMat
	{

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

		public void InitRender(Renderer r)
		{
			this.render = r;
		}

		public Renderer render;

		public Material srcMat;
	}
}
