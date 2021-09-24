using System;

namespace XMainClient
{

	internal class XProjectDamageEventArgs : XEventArgs
	{

		public XProjectDamageEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_ProjectDamage;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Damage = null;
			this.Hurt = null;
			this.Receiver = null;
			XEventPool<XProjectDamageEventArgs>.Recycle(this);
		}

		public ProjectDamageResult Damage;

		public HurtInfo Hurt;

		public XEntity Receiver;
	}
}
