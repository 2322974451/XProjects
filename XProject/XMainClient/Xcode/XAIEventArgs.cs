using System;
using UnityEngine;

namespace XMainClient
{

	internal class XAIEventArgs : XEventArgs
	{

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

		public int EventType;

		public string EventArg;

		public int TypeId;

		public int SkillId;

		public Vector3 Pos;

		public ulong SenderUID;
	}
}
