using System;
using UnityEngine;

public class XRadialBlur : XImageEffectBase
{

	private void OnRenderImage(RenderTexture source, RenderTexture dest)
	{
		base.material.SetTexture("_MainTex", source);
		base.material.SetFloat("_BlurStrength", this.blurStrength);
		base.material.SetFloat("_BlurWidth", this.blurWidth);
		base.material.SetFloat("_iHeight", 1f);
		base.material.SetFloat("_iWidth", 1f);
		Graphics.Blit(source, dest, base.material);
	}

	public float blurStrength = 6f;

	public float blurWidth = 0.7f;
}
