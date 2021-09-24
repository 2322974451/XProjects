using System;

namespace XMainClient
{

	internal class XAttackShowArgs : XEventArgs
	{

		public XAttackShowArgs()
		{
			this._eDefine = XEventDefine.XEvent_AttackShow;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.name = null;
			XEventPool<XAttackShowArgs>.Recycle(this);
		}

		public string name;
	}
}
