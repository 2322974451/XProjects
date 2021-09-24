using System;

namespace XMainClient
{

	internal class XSkillJAPassedEventArgs : XEventArgs
	{

		public XSkillJAPassedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnJAPassed;
		}

		public override void Recycle()
		{
			this.Slot = -1;
			base.Recycle();
			XEventPool<XSkillJAPassedEventArgs>.Recycle(this);
		}

		public int Slot = -1;
	}
}
