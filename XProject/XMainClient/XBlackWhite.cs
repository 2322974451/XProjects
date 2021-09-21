using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class XBlackWhite : XImageEffectBase
{
	// Token: 0x06000013 RID: 19 RVA: 0x00002858 File Offset: 0x00000A58
	private void OnRenderImage(RenderTexture source, RenderTexture dest)
	{
		base.material.SetTexture("_MainTex", source);
		base.material.SetFloat("_iHeight", 1f);
		base.material.SetFloat("_iWidth", 1f);
		Graphics.Blit(source, dest, base.material);
	}
}
