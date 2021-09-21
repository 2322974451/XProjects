using System;

namespace XMainClient
{
	// Token: 0x0200145B RID: 5211
	internal class Player_cleric_attack_chongjizhishou_ex
	{
		// Token: 0x0600E674 RID: 58996 RVA: 0x0033E850 File Offset: 0x0033CA50
		public static bool CallBomber(XSkill skill)
		{
			XSkillComponent skill2 = skill.Firer.Skill;
			bool flag = skill2.SkillMobs != null;
			if (flag)
			{
				for (int i = 0; i < skill2.SkillMobs.Count; i++)
				{
					bool flag2 = !XEntity.ValideEntity(skill2.SkillMobs[i]);
					if (!flag2)
					{
						XSkill.SkillResult(skill.Token, skill.Firer, skill.MainCore, skill.MainCore.Soul.Result[0].Index, skill.MainCore.ID, skill.MainCore.Soul.Result[0].Token, skill2.SkillMobs[i].Rotate.GetMeaningfulFaceVector3(), skill2.SkillMobs[i].EngineObject.Position);
						skill.MainCore.ClearHurtTarget();
					}
				}
			}
			return false;
		}
	}
}
