using System;

namespace XMainClient
{

	internal class XGuildLevelChangedEventArgs : XEventArgs
	{

		public XGuildLevelChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_GuildLevelChanged;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.level = 0U;
			XEventPool<XGuildLevelChangedEventArgs>.Recycle(this);
		}

		public uint level = 0U;
	}
}
