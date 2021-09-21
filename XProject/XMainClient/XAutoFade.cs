using System;
using System.Collections;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DB9 RID: 3513
	public sealed class XAutoFade
	{
		// Token: 0x0600BE5E RID: 48734 RVA: 0x0027B2A4 File Offset: 0x002794A4
		public static void PostUpdate()
		{
			bool flag = XAutoFade._fadeToBlack != null;
			if (flag)
			{
				bool flag2 = !XAutoFade._fadeToBlack.MoveNext();
				if (flag2)
				{
					XAutoFade._fadeToBlack = null;
				}
			}
			else
			{
				bool flag3 = XAutoFade._fadeToClear != null;
				if (flag3)
				{
					bool flag4 = !XAutoFade._fadeToClear.MoveNext();
					if (flag4)
					{
						XAutoFade._fadeToClear = null;
					}
				}
			}
		}

		// Token: 0x0600BE5F RID: 48735 RVA: 0x0027B304 File Offset: 0x00279504
		public static void MakeBlack(bool stopall = false)
		{
			if (stopall)
			{
				XAutoFade.StopAll();
			}
			XSingleton<XGameUI>.singleton.SetOverlayAlpha(1f);
		}

		// Token: 0x0600BE60 RID: 48736 RVA: 0x0027B32D File Offset: 0x0027952D
		public static void FadeOut2In(float In, float Out)
		{
			XAutoFade._in = In;
			XAutoFade.FadeOut(Out);
		}

		// Token: 0x0600BE61 RID: 48737 RVA: 0x0027B33D File Offset: 0x0027953D
		public static void FadeIn(float duration, bool fromBlack = false)
		{
			XAutoFade.StopAll();
			XAutoFade._force_from_black = fromBlack;
			XAutoFade.Start(XAutoFade.FadeType.ToClear, duration);
		}

		// Token: 0x0600BE62 RID: 48738 RVA: 0x0027B354 File Offset: 0x00279554
		public static void FadeOut(float duration)
		{
			XAutoFade.StopAll();
			XAutoFade.Start(XAutoFade.FadeType.ToBlack, duration);
		}

		// Token: 0x0600BE63 RID: 48739 RVA: 0x0027B365 File Offset: 0x00279565
		public static void FastFadeIn()
		{
			XAutoFade.StopAll();
			XSingleton<XGameUI>.singleton.SetOverlayAlpha(0f);
		}

		// Token: 0x0600BE64 RID: 48740 RVA: 0x0027B37E File Offset: 0x0027957E
		private static IEnumerator FadeToBlack(float duration)
		{
			float alpha = XSingleton<XGameUI>.singleton.GetOverlayAlpha();
			float rate = 1f / duration;
			float progress = alpha;
			while (progress < 1f && XSingleton<XGameUI>.singleton.GetOverlayAlpha() < 1f)
			{
				XSingleton<XGameUI>.singleton.SetOverlayAlpha(Mathf.Lerp(0f, 1f, progress));
				progress += rate * ((Time.timeScale != 0f) ? (Time.deltaTime / Time.timeScale) : Time.unscaledDeltaTime);
				yield return null;
			}
			XSingleton<XGameUI>.singleton.SetOverlayAlpha(1f);
			bool flag = XAutoFade._in > 0f;
			if (flag)
			{
				XAutoFade.FadeIn(XAutoFade._in, false);
				XAutoFade._in = 0f;
			}
			yield break;
		}

		// Token: 0x0600BE65 RID: 48741 RVA: 0x0027B38D File Offset: 0x0027958D
		private static IEnumerator FadeToClear(float duration)
		{
			float alpha = XSingleton<XGameUI>.singleton.GetOverlayAlpha();
			bool force_from_black = XAutoFade._force_from_black;
			if (force_from_black)
			{
				alpha = 1f;
				XSingleton<XGameUI>.singleton.SetOverlayAlpha(1f);
			}
			bool flag = duration == 0f;
			if (flag)
			{
				alpha = 0f;
			}
			else
			{
				float rate = 1f / duration;
				float progress = 1f - alpha;
				while (progress < 1f && XSingleton<XGameUI>.singleton.GetOverlayAlpha() > 0f)
				{
					XSingleton<XGameUI>.singleton.SetOverlayAlpha(Mathf.Lerp(1f, 0f, progress));
					progress += rate * ((Time.timeScale != 0f) ? (Time.deltaTime / Time.timeScale) : Time.unscaledDeltaTime);
					yield return null;
				}
			}
			XSingleton<XGameUI>.singleton.SetOverlayAlpha(0f);
			yield break;
		}

		// Token: 0x0600BE66 RID: 48742 RVA: 0x0027B39C File Offset: 0x0027959C
		private static void Start(XAutoFade.FadeType type, float duration)
		{
			if (type != XAutoFade.FadeType.ToBlack)
			{
				if (type == XAutoFade.FadeType.ToClear)
				{
					bool flag = XAutoFade._fadeToClear == null;
					if (flag)
					{
						XAutoFade._fadeToClear = XAutoFade.FadeToClear(duration);
					}
				}
			}
			else
			{
				bool flag2 = XAutoFade._fadeToBlack == null;
				if (flag2)
				{
					XAutoFade._fadeToBlack = XAutoFade.FadeToBlack(duration);
				}
			}
		}

		// Token: 0x0600BE67 RID: 48743 RVA: 0x0027B3F1 File Offset: 0x002795F1
		private static void StopAll()
		{
			XAutoFade._fadeToBlack = null;
			XAutoFade._fadeToClear = null;
		}

		// Token: 0x04004DC1 RID: 19905
		private static float _in = 0f;

		// Token: 0x04004DC2 RID: 19906
		private static bool _force_from_black = false;

		// Token: 0x04004DC3 RID: 19907
		private static IEnumerator _fadeToBlack = null;

		// Token: 0x04004DC4 RID: 19908
		private static IEnumerator _fadeToClear = null;

		// Token: 0x020019C1 RID: 6593
		private enum FadeType
		{
			// Token: 0x04007FC3 RID: 32707
			ToBlack,
			// Token: 0x04007FC4 RID: 32708
			ToClear
		}
	}
}
