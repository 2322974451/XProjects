using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XChargeEventArgs : XActionArgs
	{

		public XChargeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Charge;
			this.Data = null;
			this.TimeGone = 0f;
		}

		public override void Recycle()
		{
			this.Data = null;
			this.AimedTarget = null;
			this.Height = 0f;
			this.TimeSpan = 0f;
			this.TimeScale = 1f;
			this.TimeGone = 0f;
			base.Recycle();
			XEventPool<XChargeEventArgs>.Recycle(this);
		}

		public XChargeData Data { get; set; }

		public float Height { get; set; }

		public float TimeSpan { get; set; }

		public XEntity AimedTarget = null;

		public float TimeScale = 1f;

		public float TimeGone;
	}
}
