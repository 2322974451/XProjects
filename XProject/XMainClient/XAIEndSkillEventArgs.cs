using System;

namespace XMainClient
{

	internal class XAIEndSkillEventArgs : XEventArgs
	{

		public XAIEndSkillEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIEndSkill;
		}

		public override void Recycle()
		{
			this.SkillId = 0U;
			this.IsCaster = false;
			base.Recycle();
			XEventPool<XAIEndSkillEventArgs>.Recycle(this);
		}

		public uint SkillId = 0U;

		public bool IsCaster = false;
	}
}
