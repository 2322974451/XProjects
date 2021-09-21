using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x020008A7 RID: 2215
	internal class XBuffTriggerByCastSkill : XBuffTrigger
	{
		// Token: 0x06008633 RID: 34355 RVA: 0x0010DFF7 File Offset: 0x0010C1F7
		public XBuffTriggerByCastSkill(XBuff buff) : base(buff)
		{
			this.m_SpecifiedSkillsSet = buff.RelevantSkills;
		}

		// Token: 0x06008634 RID: 34356 RVA: 0x0010E00E File Offset: 0x0010C20E
		public override void OnCastSkill(HurtInfo rawInput)
		{
			base.OnCastSkill(rawInput);
			this.m_RawInput = rawInput;
			base.Trigger();
		}

		// Token: 0x06008635 RID: 34357 RVA: 0x0010E028 File Offset: 0x0010C228
		public override bool CheckTriggerCondition()
		{
			bool flag = this.m_SpecifiedSkillsSet != null && (this.m_RawInput == null || !this.m_SpecifiedSkillsSet.Contains(this.m_RawInput.SkillID));
			return !flag;
		}

		// Token: 0x040029D6 RID: 10710
		private HurtInfo m_RawInput;

		// Token: 0x040029D7 RID: 10711
		private HashSet<uint> m_SpecifiedSkillsSet;
	}
}
