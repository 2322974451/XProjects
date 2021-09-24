using System;
using UnityEngine;

namespace XMainClient
{

	internal class XNavigationEventArgs : XEventArgs
	{

		public XNavigationEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_NaviMove;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Dest = Vector3.zero;
			this.CameraFollow = true;
			this.SpeedRatio = 1f;
			XEventPool<XNavigationEventArgs>.Recycle(this);
		}

		public Vector3 Dest;

		public bool CameraFollow = true;

		public float SpeedRatio = 1f;
	}
}
