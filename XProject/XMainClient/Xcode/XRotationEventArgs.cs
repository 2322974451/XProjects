using System;
using UnityEngine;

namespace XMainClient
{

	internal class XRotationEventArgs : XEventArgs
	{

		public XRotationEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Rotation;
		}

		public override void Recycle()
		{
			this.TargetDir = Vector3.forward;
			this.Palstance = 0f;
			base.Recycle();
			XEventPool<XRotationEventArgs>.Recycle(this);
		}

		public Vector3 TargetDir = Vector3.forward;

		public float Palstance = 0f;
	}
}
