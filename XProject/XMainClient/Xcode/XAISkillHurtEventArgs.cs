using System;

namespace XMainClient
{

	internal class XAISkillHurtEventArgs : XEventArgs
	{

		public XAISkillHurtEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AISkillHurt;
		}

		public override void Recycle()
		{
			this.SkillId = 0U;
			base.Recycle();
			XEventPool<XAISkillHurtEventArgs>.Recycle(this);
		}

		public uint SkillId = 0U;

		public bool IsCaster = false;
	}
}
