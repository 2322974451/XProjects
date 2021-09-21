using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F5C RID: 3932
	internal class XAIEventArgs : XEventArgs
	{
		// Token: 0x0600D01F RID: 53279 RVA: 0x00303F1C File Offset: 0x0030211C
		public XAIEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIEvent;
			this.EventArg = "";
			this.EventType = 0;
			this.TypeId = 0;
			this.SkillId = 0;
			this.Pos = Vector3.zero;
			this.SenderUID = 0UL;
		}

		// Token: 0x0600D020 RID: 53280 RVA: 0x00303F6C File Offset: 0x0030216C
		public override void Recycle()
		{
			base.Recycle();
			this.EventArg = "";
			this.EventType = 0;
			this.TypeId = 0;
			this.SkillId = 0;
			this.Pos = Vector3.zero;
			this.SenderUID = 0UL;
			XEventPool<XAIEventArgs>.Recycle(this);
		}

		// Token: 0x04005E08 RID: 24072
		public int EventType;

		// Token: 0x04005E09 RID: 24073
		public string EventArg;

		// Token: 0x04005E0A RID: 24074
		public int TypeId;

		// Token: 0x04005E0B RID: 24075
		public int SkillId;

		// Token: 0x04005E0C RID: 24076
		public Vector3 Pos;

		// Token: 0x04005E0D RID: 24077
		public ulong SenderUID;
	}
}
