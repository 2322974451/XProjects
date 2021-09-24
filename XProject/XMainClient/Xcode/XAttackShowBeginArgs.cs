using System;
using UnityEngine;

namespace XMainClient
{

	internal class XAttackShowBeginArgs : XEventArgs
	{

		public XAttackShowBeginArgs()
		{
			this._eDefine = XEventDefine.XEvent_AttackShowBegin;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.XCamera = null;
			XEventPool<XAttackShowBeginArgs>.Recycle(this);
		}

		public GameObject XCamera = null;
	}
}
