using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFreezeEventArgs : XActionArgs
	{

		public XFreezeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Freeze;
		}

		public override void Recycle()
		{
			this.HitData = null;
			this.Duration = 0f;
			this.Dir = Vector3.zero;
			this.Present = false;
			base.Recycle();
			XEventPool<XFreezeEventArgs>.Recycle(this);
		}

		public XHitData HitData { get; set; }

		public float Duration = 0f;

		public bool Present = false;

		public Vector3 Dir = Vector3.zero;
	}
}
