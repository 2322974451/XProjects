using System;

namespace XMainClient
{

	internal class XHUDAddEventArgs : XEventArgs
	{

		public XHUDAddEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_HUDAdd;
			this.caster = null;
		}

		public override void Recycle()
		{
			this.damageResult = null;
			this.caster = null;
			base.Recycle();
			XEventPool<XHUDAddEventArgs>.Recycle(this);
		}

		public ProjectDamageResult damageResult { get; set; }

		public XEntity caster { get; set; }
	}
}
