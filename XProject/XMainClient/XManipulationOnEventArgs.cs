using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FAA RID: 4010
	internal class XManipulationOnEventArgs : XEventArgs
	{
		// Token: 0x0600D0FA RID: 53498 RVA: 0x003054F2 File Offset: 0x003036F2
		public XManipulationOnEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Manipulation_On;
		}

		// Token: 0x0600D0FB RID: 53499 RVA: 0x0030550E File Offset: 0x0030370E
		public override void Recycle()
		{
			base.Recycle();
			this.data = null;
			XEventPool<XManipulationOnEventArgs>.Recycle(this);
		}

		// Token: 0x04005E91 RID: 24209
		public XManipulationData data = null;
	}
}
