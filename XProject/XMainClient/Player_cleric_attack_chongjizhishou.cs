using System;

namespace XMainClient
{
	// Token: 0x02001361 RID: 4961
	internal class Player_cleric_attack_chongjizhishou
	{
		// Token: 0x0600E278 RID: 57976 RVA: 0x003390C0 File Offset: 0x003372C0
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
