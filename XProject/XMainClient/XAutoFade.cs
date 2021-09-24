using System;
using System.Collections;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public sealed class XAutoFade
	{

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

		public static void MakeBlack(bool stopall = false)
		{
			if (stopall)
			{
				XAutoFade.StopAll();
			}
			XSingleton<XGameUI>.singleton.SetOverlayAlpha(1f);
		}

		public static void FadeOut2In(float In, float Out)
		{
			XAutoFade._in = In;
			XAutoFade.FadeOut(Out);
		}

		public static void FadeIn(float duration, bool fromBlack = false)
		{
			XAutoFade.StopAll();
			XAutoFade._force_from_black = fromBlack;
			XAutoFade.Start(XAutoFade.FadeType.ToClear, duration);
		}

		public static void FadeOut(float duration)
		{
			XAutoFade.StopAll();
			XAutoFade.Start(XAutoFade.FadeType.ToBlack, duration);
		}

		public static void FastFadeIn()
		{
			XAutoFade.StopAll();
			XSingleton<XGameUI>.singleton.SetOverlayAlpha(0f);
		}

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

		private static void StopAll()
		{
			XAutoFade._fadeToBlack = null;
			XAutoFade._fadeToClear = null;
		}

		private static float _in = 0f;

		private static bool _force_from_black = false;

		private static IEnumerator _fadeToBlack = null;

		private static IEnumerator _fadeToClear = null;

		private enum FadeType
		{

			ToBlack,

			ToClear
		}
	}
}
