using System;

namespace XMainClient
{

	internal abstract class XSkillExternalArgs : XEventArgs
	{

		public XSkillExternalArgs()
		{
			this._eDefine = XEventDefine.XEvent_SkillExternal;
		}

		public override void Recycle()
		{
			this.callback = null;
			this.delay = 0f;
			base.Recycle();
		}

		public SkillExternalCallback callback = null;

		public float delay = 0f;
	}
}
