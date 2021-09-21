using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000FB1 RID: 4017
	internal class XMentorRelationOpArgs : XEventArgs
	{
		// Token: 0x0600D108 RID: 53512 RVA: 0x0030568E File Offset: 0x0030388E
		public XMentorRelationOpArgs()
		{
			this._eDefine = XEventDefine.XEvent_MentorshipRelationOperation;
		}

		// Token: 0x0600D109 RID: 53513 RVA: 0x003056A3 File Offset: 0x003038A3
		public override void Recycle()
		{
			base.Recycle();
			this.oArg = null;
			this.oRes = null;
			XEventPool<XMentorRelationOpArgs>.Recycle(this);
		}

		// Token: 0x04005E9D RID: 24221
		public MentorRelationOpArg oArg;

		// Token: 0x04005E9E RID: 24222
		public MentorRelationOpRes oRes;
	}
}
