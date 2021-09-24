using System;

namespace XMainClient
{

	internal class XCoolDownAllSkillsArgs : XEventArgs
	{

		public XCoolDownAllSkillsArgs()
		{
			this._eDefine = XEventDefine.XEvent_CoolDownAllSkills;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XCoolDownAllSkillsArgs>.Recycle(this);
		}
	}
}
