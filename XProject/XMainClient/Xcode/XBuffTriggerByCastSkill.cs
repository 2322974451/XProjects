using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XBuffTriggerByCastSkill : XBuffTrigger
	{

		public XBuffTriggerByCastSkill(XBuff buff) : base(buff)
		{
			this.m_SpecifiedSkillsSet = buff.RelevantSkills;
		}

		public override void OnCastSkill(HurtInfo rawInput)
		{
			base.OnCastSkill(rawInput);
			this.m_RawInput = rawInput;
			base.Trigger();
		}

		public override bool CheckTriggerCondition()
		{
			bool flag = this.m_SpecifiedSkillsSet != null && (this.m_RawInput == null || !this.m_SpecifiedSkillsSet.Contains(this.m_RawInput.SkillID));
			return !flag;
		}

		private HurtInfo m_RawInput;

		private HashSet<uint> m_SpecifiedSkillsSet;
	}
}
