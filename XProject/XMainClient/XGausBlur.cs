using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
internal class XGausBlur : XImageEffectBase
{
	// Token: 0x06000015 RID: 21 RVA: 0x000028BC File Offset: 0x00000ABC
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		int num = source.width / 4;
		int num2 = source.height / 4;
		RenderTexture renderTexture = RenderTexture.GetTemporary(num, num2, 0);
		this.DownSample4x(source, renderTexture);
		for (int i = 0; i < this.iterations; i++)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(num, num2, 0);
			this.FourTapCone(renderTexture, temporary, i);
			RenderTexture.ReleaseTemporary(renderTexture);
			renderTexture = temporary;
		}
		Graphics.Blit(renderTexture, destination);
		RenderTexture.ReleaseTemporary(renderTexture);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002938 File Offset: 0x00000B38
	public void FourTapCone(RenderTexture source, RenderTexture dest, int iteration)
	{
		float num = 0.5f + (float)iteration * this.blurSpread;
		Graphics.BlitMultiTap(source, dest, base.material, new Vector2[]
		{
			new Vector2(-num, -num),
			new Vector2(-num, num),
			new Vector2(num, num),
			new Vector2(num, -num)
		});
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000029A8 File Offset: 0x00000BA8
	private void DownSample4x(RenderTexture source, RenderTexture dest)
	{
		float num = 1f;
		Graphics.BlitMultiTap(source, dest, base.material, new Vector2[]
		{
			new Vector2(-num, -num),
			new Vector2(-num, num),
			new Vector2(num, num),
			new Vector2(num, -num)
		});
	}

	// Token: 0x04000010 RID: 16
	public int iterations = 3;

	// Token: 0x04000011 RID: 17
	public float blurSpread = 0.6f;
}
