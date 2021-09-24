using System;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class XHudEntry
	{

		public float movementStart
		{
			get
			{
				return this.time + this.stay;
			}
		}

		public bool init = false;

		public float time;

		public float stay = 0f;

		public float offset = 0f;

		public float val = 0f;

		public IXUILabel label;

		public bool isDigital = true;

		public AnimationCurve offsetCurve = new AnimationCurve();

		public AnimationCurve alphaCurve = new AnimationCurve();

		public AnimationCurve scaleCurve = new AnimationCurve();
	}
}
