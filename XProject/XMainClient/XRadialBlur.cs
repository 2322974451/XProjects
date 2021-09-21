using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class XRadialBlur : XImageEffectBase
{
	// Token: 0x0600001D RID: 29 RVA: 0x00002AF8 File Offset: 0x00000CF8
	private void OnRenderImage(RenderTexture source, RenderTexture dest)
	{
		base.material.SetTexture("_MainTex", source);
		base.material.SetFloat("_BlurStrength", this.blurStrength);
		base.material.SetFloat("_BlurWidth", this.blurWidth);
		base.material.SetFloat("_iHeight", 1f);
		base.material.SetFloat("_iWidth", 1f);
		Graphics.Blit(source, dest, base.material);
	}

	// Token: 0x04000014 RID: 20
	public float blurStrength = 6f;

	// Token: 0x04000015 RID: 21
	public float blurWidth = 0.7f;
}
