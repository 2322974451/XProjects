using System;
using UnityEngine;

public class XImageEffectBase : MonoBehaviour
{

	protected virtual void Start()
	{
		bool flag = !SystemInfo.supportsImageEffects;
		if (flag)
		{
			base.enabled = false;
		}
		else
		{
			bool flag2 = !this.shader || !this.shader.isSupported;
			if (flag2)
			{
				base.enabled = false;
			}
		}
	}

	protected Material material
	{
		get
		{
			bool flag = this.m_Material == null;
			if (flag)
			{
				this.m_Material = new Material(this.shader);
				this.m_Material.hideFlags = (HideFlags)61;
			}
			return this.m_Material;
		}
	}

	protected virtual void OnDisable()
	{
		bool flag = this.m_Material;
		if (flag)
		{
			UnityEngine.Object.Destroy(this.m_Material);
		}
	}

	public Shader shader;

	private Material m_Material;
}
