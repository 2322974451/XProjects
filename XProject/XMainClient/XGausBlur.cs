using System;
using UnityEngine;

internal class XGausBlur : XImageEffectBase
{

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

	public int iterations = 3;

	public float blurSpread = 0.6f;
}
