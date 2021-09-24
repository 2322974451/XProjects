using System;

namespace XMainClient
{

	internal class XAIStartSkillEventArgs : XEventArgs
	{

		public XAIStartSkillEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIStartSkill;
		}

		public override void Recycle()
		{
			this.SkillId = 0U;
			this.IsCaster = false;
			base.Recycle();
			XEventPool<XAIStartSkillEventArgs>.Recycle(this);
		}

		public uint SkillId = 0U;

		public bool IsCaster = false;
	}
}
