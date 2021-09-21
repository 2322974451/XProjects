using System;

namespace XMainClient
{
	// Token: 0x02000FA3 RID: 4003
	internal class XOnEntityCreatedArgs : XEventArgs
	{
		// Token: 0x0600D0EC RID: 53484 RVA: 0x003053A2 File Offset: 0x003035A2
		public XOnEntityCreatedArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnEntityCreated;
			this.entity = null;
		}

		// Token: 0x0600D0ED RID: 53485 RVA: 0x003053BB File Offset: 0x003035BB
		public override void Recycle()
		{
			base.Recycle();
			this.entity = null;
			XEventPool<XOnEntityCreatedArgs>.Recycle(this);
		}

		// Token: 0x04005E8A RID: 24202
		public XEntity entity;
	}
}
