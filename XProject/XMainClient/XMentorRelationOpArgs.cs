using System;
using KKSG;

namespace XMainClient
{

	internal class XMentorRelationOpArgs : XEventArgs
	{

		public XMentorRelationOpArgs()
		{
			this._eDefine = XEventDefine.XEvent_MentorshipRelationOperation;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.oArg = null;
			this.oRes = null;
			XEventPool<XMentorRelationOpArgs>.Recycle(this);
		}

		public MentorRelationOpArg oArg;

		public MentorRelationOpRes oRes;
	}
}
