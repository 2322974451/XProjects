using System;
using UnityEngine;

namespace XMainClient
{

	internal class XEndureEventArgs : XEventArgs
	{

		public XEndureEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Endure;
		}

		public override void Recycle()
		{
			this.Fx = null;
			this.Dir = Vector3.zero;
			this.HitFrom = null;
			base.Recycle();
			XEventPool<XEndureEventArgs>.Recycle(this);
		}

		public string Fx = null;

		public Vector3 Dir = Vector3.zero;

		public XEntity HitFrom = null;
	}
}
