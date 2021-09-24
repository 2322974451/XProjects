using System;
using UnityEngine;

namespace XMainClient
{

	internal class XOnEntityTransferEventArgs : XEventArgs
	{

		public XOnEntityTransferEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnEntityTransfer;
			this.TransPos = Vector3.zero;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XOnEntityTransferEventArgs>.Recycle(this);
		}

		public Vector3 TransPos;
	}
}
