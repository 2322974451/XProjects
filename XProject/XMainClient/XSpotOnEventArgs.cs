using System;
using UnityEngine;

namespace XMainClient
{

	internal class XSpotOnEventArgs : XEventArgs
	{

		public XSpotOnEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_SpotOn;
		}

		public override void Recycle()
		{
			Color red = Color.red;
			base.Recycle();
			XEventPool<XSpotOnEventArgs>.Recycle(this);
		}

		public bool Enabled = false;

		public Color color = Color.red;
	}
}
