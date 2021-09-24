using System;

namespace XMainClient
{

	internal class XInitCoolDownAllSkillsArgs : XEventArgs
	{

		public XInitCoolDownAllSkillsArgs()
		{
			this._eDefine = XEventDefine.XEvent_InitCoolDownAllSkills;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XInitCoolDownAllSkillsArgs>.Recycle(this);
		}
	}
}
