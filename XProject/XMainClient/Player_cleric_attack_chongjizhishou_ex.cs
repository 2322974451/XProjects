using System;

namespace XMainClient
{

	internal class Player_cleric_attack_chongjizhishou_ex
	{

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
