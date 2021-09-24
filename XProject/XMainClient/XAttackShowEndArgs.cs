using System;

namespace XMainClient
{

	internal class XAttackShowEndArgs : XEventArgs
	{

		public XAttackShowEndArgs()
		{
			this._eDefine = XEventDefine.XEvent_AttackShowEnd;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.ForceQuit = true;
			XEventPool<XAttackShowEndArgs>.Recycle(this);
		}

		public bool ForceQuit = true;
	}
}
