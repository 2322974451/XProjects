using System;

namespace XMainClient
{

	internal class XSkillQTEEventArgs : XEventArgs
	{

		public XSkillQTEEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_QTE;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.State = 0U;
			this.On = false;
			XEventPool<XSkillQTEEventArgs>.Recycle(this);
		}

		public uint State = 0U;

		public bool On = false;
	}
}
