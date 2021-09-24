using System;

namespace XMainClient
{

	internal class XBigMeleeEnemyChange : XEventArgs
	{

		public XBigMeleeEnemyChange()
		{
			this._eDefine = XEventDefine.XEvent_BigMeleeEnemyChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.isEnemy = false;
			XEventPool<XBigMeleeEnemyChange>.Recycle(this);
		}

		public bool isEnemy;
	}
}
