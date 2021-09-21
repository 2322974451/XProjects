using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FDE RID: 4062
	public class MatPackage : IRenderObject
	{
		// Token: 0x170036D8 RID: 14040
		// (set) Token: 0x0600D2F9 RID: 54009 RVA: 0x00316650 File Offset: 0x00314850
		public int InstanceID
		{
			set
			{
				this.m_instanceID = value;
			}
		}

		// Token: 0x0600D2FA RID: 54010 RVA: 0x0031665C File Offset: 0x0031485C
		public bool GetFlag(MatPackage.EFlag flag)
		{
			return (this.m_flag & (uint)flag) > 0U;
		}

		// Token: 0x0600D2FB RID: 54011 RVA: 0x0031667C File Offset: 0x0031487C
		public void SetFlag(MatPackage.EFlag flag, bool add)
		{
			if (add)
			{
				this.m_flag |= (uint)flag;
			}
			else
			{
				this.m_flag &= (uint)(~(uint)flag);
			}
		}

		// Token: 0x0600D2FC RID: 54012 RVA: 0x003166B4 File Offset: 0x003148B4
		public bool IsSameObj(int id)
		{
			return this.m_instanceID == id;
		}

		// Token: 0x0600D2FD RID: 54013 RVA: 0x003166D0 File Offset: 0x003148D0
		public void SetRenderLayer(int layer)
		{
			bool flag = this.m_renderGO != null;
			if (flag)
			{
				this.m_renderGO.layer = layer;
			}
		}

		// Token: 0x0600D2FE RID: 54014 RVA: 0x00316700 File Offset: 0x00314900
		public void SetShader(int type)
		{
			bool flag = type == 0;
			if (flag)
			{
				this.SetFadeShader();
			}
			else
			{
				this.SetFlag(MatPackage.EFlag.EShaderChanged, true);
			}
		}

		// Token: 0x0600D2FF RID: 54015 RVA: 0x0031672C File Offset: 0x0031492C
		public void SetFadeShader()
		{
			bool flag = this.srcMat != null;
			if (flag)
			{
				bool flag2 = this.srcShader == ShaderManager._skin8 || this.srcShader == ShaderManager._skin_blend;
				if (flag2)
				{
					this.srcMat.shader = ShaderManager._skin_effect;
				}
				else
				{
					bool flag3 = this.srcShader == ShaderManager._skin_cutout || this.srcShader == ShaderManager._skin_cutout4;
					if (!flag3)
					{
						this.srcMat.shader = ShaderManager._fade_maskR_noLight;
					}
				}
				this.SetFlag(MatPackage.EFlag.EShaderChanged, true);
			}
		}

		// Token: 0x0600D300 RID: 54016 RVA: 0x003167D8 File Offset: 0x003149D8
		public void ResetShader()
		{
			bool flag = this.srcMat != null;
			if (flag)
			{
				bool flag2 = this.srcMat.shader != this.srcShader;
				if (flag2)
				{
					this.srcMat.shader = this.srcShader;
				}
				this.SetFlag(MatPackage.EFlag.EShaderChanged, false);
				bool flag3 = this.m_render != null && this.m_mpb != null;
				if (flag3)
				{
					bool flag4 = this.GetFlag(MatPackage.EFlag.EHasColor);
					if (flag4)
					{
						ShaderManager.SetColor(this.m_mpb, this.srcColor, ShaderManager._ShaderKeyIDColor0);
						this.m_render.SetPropertyBlock(this.m_mpb);
					}
				}
			}
		}

		// Token: 0x0600D301 RID: 54017 RVA: 0x00316888 File Offset: 0x00314A88
		public void SetColor(byte r, byte g, byte b, byte a)
		{
			bool flag = this.GetFlag(MatPackage.EFlag.EShaderChanged);
			if (flag)
			{
				MatPackage.color32.r = r;
				MatPackage.color32.g = g;
				MatPackage.color32.b = b;
				MatPackage.color32.a = a;
				ShaderManager.SetColor32(this.m_mpb, MatPackage.color32, ShaderManager._ShaderKeyIDColor0);
				this.SetFlag(MatPackage.EFlag.EShaderPropertySet, true);
			}
		}

		// Token: 0x0600D302 RID: 54018 RVA: 0x003168F0 File Offset: 0x00314AF0
		public void SetColor(Color32 c)
		{
			bool flag = this.GetFlag(MatPackage.EFlag.EShaderChanged);
			if (flag)
			{
				ShaderManager.SetColor(this.m_mpb, c, ShaderManager._ShaderKeyIDColor0);
				this.SetFlag(MatPackage.EFlag.EShaderPropertySet, true);
			}
		}

		// Token: 0x0600D303 RID: 54019 RVA: 0x0031692C File Offset: 0x00314B2C
		public void Update()
		{
			bool flag = this.m_render != null && this.m_mpb != null && this.GetFlag(MatPackage.EFlag.EShaderPropertySet);
			if (flag)
			{
				this.m_render.SetPropertyBlock(this.m_mpb);
				this.SetFlag(MatPackage.EFlag.EShaderPropertySet, false);
			}
		}

		// Token: 0x0600D304 RID: 54020 RVA: 0x0031697C File Offset: 0x00314B7C
		public void Clean()
		{
			this.debugName = "";
			this.srcMat = null;
			this.m_instanceID = -1;
			this.m_render = null;
			this.m_renderGO = null;
			this.m_flag = 0U;
			bool flag = this.m_mpb != null;
			if (flag)
			{
				this.m_mpb.Clear();
			}
			MatPackage.ReturnMatPack(this);
		}

		// Token: 0x0600D305 RID: 54021 RVA: 0x003169DA File Offset: 0x00314BDA
		private static void ReturnMatPack(MatPackage matPack)
		{
			MatPackage.m_MatPackCache.Enqueue(matPack);
		}

		// Token: 0x0600D306 RID: 54022 RVA: 0x003169EC File Offset: 0x00314BEC
		public static MatPackage GetMatPack(Material mat, Renderer render)
		{
			bool flag = MatPackage.m_MatPackCache.Count > 0;
			MatPackage matPackage;
			if (flag)
			{
				matPackage = MatPackage.m_MatPackCache.Dequeue();
			}
			else
			{
				matPackage = new MatPackage();
			}
			matPackage.debugName = render.gameObject.name;
			matPackage.m_render = render;
			matPackage.m_renderGO = render.gameObject;
			bool flag2 = mat != null;
			if (flag2)
			{
				matPackage.srcMat = mat;
				matPackage.srcShader = mat.shader;
				matPackage.SetFlag(MatPackage.EFlag.EIsCutout, matPackage.srcMat.HasProperty("_Cutoff"));
				bool flag3 = matPackage.srcMat.HasProperty("_Color");
				matPackage.SetFlag(MatPackage.EFlag.EHasColor, flag3);
				bool flag4 = flag3;
				if (flag4)
				{
					matPackage.srcColor = matPackage.srcMat.GetColor("_Color");
				}
			}
			bool flag5 = render != null;
			if (flag5)
			{
				render.GetPropertyBlock(matPackage.m_mpb);
			}
			return matPackage;
		}

		// Token: 0x04005FE3 RID: 24547
		private static Queue<MatPackage> m_MatPackCache = new Queue<MatPackage>();

		// Token: 0x04005FE4 RID: 24548
		private static Color32 color32;

		// Token: 0x04005FE5 RID: 24549
		public Material srcMat = null;

		// Token: 0x04005FE6 RID: 24550
		public Shader srcShader = null;

		// Token: 0x04005FE7 RID: 24551
		public Color srcColor = new Color(1f, 1f, 1f, 1f);

		// Token: 0x04005FE8 RID: 24552
		private int m_instanceID = -1;

		// Token: 0x04005FE9 RID: 24553
		private GameObject m_renderGO = null;

		// Token: 0x04005FEA RID: 24554
		private Renderer m_render = null;

		// Token: 0x04005FEB RID: 24555
		private MaterialPropertyBlock m_mpb = new MaterialPropertyBlock();

		// Token: 0x04005FEC RID: 24556
		private uint m_flag = 0U;

		// Token: 0x04005FED RID: 24557
		public string debugName = "";

		// Token: 0x020019FB RID: 6651
		public enum EFlag
		{
			// Token: 0x040081D4 RID: 33236
			EShaderChanged = 1,
			// Token: 0x040081D5 RID: 33237
			EShaderPropertySet,
			// Token: 0x040081D6 RID: 33238
			EIsCutout = 4,
			// Token: 0x040081D7 RID: 33239
			EHasColor = 8
		}
	}
}
