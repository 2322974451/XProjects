using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBeHitEventArgs : XActionArgs
	{

		public XBeHitEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BeHit;
		}

		public override void Recycle()
		{
			this.HitData = null;
			this.HitDirection = Vector3.forward;
			this.ForceToFlyHit = false;
			this.Paralyze = 1f;
			this.HitFrom = null;
			base.Recycle();
			XEventPool<XBeHitEventArgs>.Recycle(this);
		}

		public XHitData HitData { get; set; }

		public Vector3 HitDirection = Vector3.forward;

		public bool ForceToFlyHit = false;

		public float Paralyze = 1f;

		public XEntity HitFrom = null;
	}
}
