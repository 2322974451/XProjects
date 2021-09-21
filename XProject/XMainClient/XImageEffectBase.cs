using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class XImageEffectBase : MonoBehaviour
{
	// Token: 0x06000019 RID: 25 RVA: 0x00002A28 File Offset: 0x00000C28
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

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x0600001A RID: 26 RVA: 0x00002A78 File Offset: 0x00000C78
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

	// Token: 0x0600001B RID: 27 RVA: 0x00002AC4 File Offset: 0x00000CC4
	protected virtual void OnDisable()
	{
		bool flag = this.m_Material;
		if (flag)
		{
			UnityEngine.Object.Destroy(this.m_Material);
		}
	}

	// Token: 0x04000012 RID: 18
	public Shader shader;

	// Token: 0x04000013 RID: 19
	private Material m_Material;
}
