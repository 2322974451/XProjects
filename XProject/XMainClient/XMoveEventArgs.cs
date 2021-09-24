using System;
using UnityEngine;

namespace XMainClient
{

	internal class XMoveEventArgs : XActionArgs
	{

		public XMoveEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Move;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Destination = Vector3.zero;
			this.Speed = 0f;
			this.Inertia = false;
			this.Stoppage = true;
			this.StopTowards = 0f;
			XEventPool<XMoveEventArgs>.Recycle(this);
		}

		public Vector3 Destination = Vector3.zero;

		public float Speed = 0f;

		public bool Inertia = false;

		public bool Stoppage = true;

		public float StopTowards = 0f;
	}
}
