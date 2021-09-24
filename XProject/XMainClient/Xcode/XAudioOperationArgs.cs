using System;

namespace XMainClient
{

	internal class XAudioOperationArgs : XEventArgs
	{

		public XAudioOperationArgs()
		{
			this._eDefine = XEventDefine.XEvent_AudioOperation;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.IsAudioOn = true;
			XEventPool<XAudioOperationArgs>.Recycle(this);
		}

		public bool IsAudioOn = true;
	}
}
