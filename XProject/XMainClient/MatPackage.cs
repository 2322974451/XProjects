using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public class MatPackage : IRenderObject
	{

		public int InstanceID
		{
			set
			{
				this.m_instanceID = value;
			}
		}

		public bool GetFlag(MatPackage.EFlag flag)
		{
			return (this.m_flag & (uint)flag) > 0U;
		}

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

		public bool IsSameObj(int id)
		{
			return this.m_instanceID == id;
		}

		public void SetRenderLayer(int layer)
		{
			bool flag = this.m_renderGO != null;
			if (flag)
			{
				this.m_renderGO.layer = layer;
			}
		}

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

		public void SetColor(Color32 c)
		{
			bool flag = this.GetFlag(MatPackage.EFlag.EShaderChanged);
			if (flag)
			{
				ShaderManager.SetColor(this.m_mpb, c, ShaderManager._ShaderKeyIDColor0);
				this.SetFlag(MatPackage.EFlag.EShaderPropertySet, true);
			}
		}

		public void Update()
		{
			bool flag = this.m_render != null && this.m_mpb != null && this.GetFlag(MatPackage.EFlag.EShaderPropertySet);
			if (flag)
			{
				this.m_render.SetPropertyBlock(this.m_mpb);
				this.SetFlag(MatPackage.EFlag.EShaderPropertySet, false);
			}
		}

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

		private static void ReturnMatPack(MatPackage matPack)
		{
			MatPackage.m_MatPackCache.Enqueue(matPack);
		}

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

		private static Queue<MatPackage> m_MatPackCache = new Queue<MatPackage>();

		private static Color32 color32;

		public Material srcMat = null;

		public Shader srcShader = null;

		public Color srcColor = new Color(1f, 1f, 1f, 1f);

		private int m_instanceID = -1;

		private GameObject m_renderGO = null;

		private Renderer m_render = null;

		private MaterialPropertyBlock m_mpb = new MaterialPropertyBlock();

		private uint m_flag = 0U;

		public string debugName = "";

		public enum EFlag
		{

			EShaderChanged = 1,

			EShaderPropertySet,

			EIsCutout = 4,

			EHasColor = 8
		}
	}
}
