using System;

namespace XMainClient
{

	internal class XFightGroupChangedArgs : XEventArgs
	{

		public XFightGroupChangedArgs()
		{
			this._eDefine = XEventDefine.XEvent_FightGroupChanged;
			this.newFightGroup = 0U;
			this.oldFightGroup = 0U;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.newFightGroup = 0U;
			this.oldFightGroup = 0U;
			XEventPool<XFightGroupChangedArgs>.Recycle(this);
		}

		public uint newFightGroup;

		public uint oldFightGroup;

		public XEntity targetEntity;
	}
}
