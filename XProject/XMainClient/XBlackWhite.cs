using System;
using UnityEngine;

public class XBlackWhite : XImageEffectBase
{

	private void OnRenderImage(RenderTexture source, RenderTexture dest)
	{
		base.material.SetTexture("_MainTex", source);
		base.material.SetFloat("_iHeight", 1f);
		base.material.SetFloat("_iWidth", 1f);
		Graphics.Blit(source, dest, base.material);
	}
}
