using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B83 RID: 2947
	internal class ScriptCode : XSingleton<ScriptCode>
	{
		// Token: 0x0600A96D RID: 43373 RVA: 0x001E2724 File Offset: 0x001E0924
		public override bool Init()
		{
			this.m_CutSceneDoMap["archer_slash_show"] = new CutSceneDo(archer_slash_show.Do);
			this.m_CutSceneDoMap["cleric_slash_show"] = new CutSceneDo(cleric_slash_show.Do);
			this.m_CutSceneDoMap["first_slash_show"] = new CutSceneDo(first_slash_show.Do);
			this.m_CutSceneDoMap["geraint_fly_away"] = new CutSceneDo(geraint_fly_away.Do);
			this.m_CutSceneDoMap["geraint_get_wings"] = new CutSceneDo(geraint_get_wings.Do);
			this.m_CutSceneDoMap["newbie_level"] = new CutSceneDo(newbie_level.Do);
			this.m_CutSceneDoMap["newbie_level_end"] = new CutSceneDo(newbie_level_end.Do);
			this.m_CutSceneDoMap["second_slash_show"] = new CutSceneDo(second_slash_show.Do);
			this.m_CutSceneDoMap["sorceress_slash_show"] = new CutSceneDo(sorceress_slash_show.Do);
			this.m_CutSceneDoMap["warrior_slash_show"] = new CutSceneDo(warrior_slash_show.Do);
			this.m_CutSceneDoMap["academic_slash_show"] = new CutSceneDo(academic_slash_show.Do);
			this.m_CutSceneDoMap["assassin_slash_show"] = new CutSceneDo(assassin_slash_show.Do);
			this.m_CutSceneDoMap["kali_slash_show"] = new CutSceneDo(kali_slash_show.Do);
			this.m_CutSceneDoMap["warrior_show"] = new CutSceneDo(warrior_show.Do);
			this.m_CutSceneDoMap["sorceress_show"] = new CutSceneDo(sorceress_show.Do);
			this.m_CutSceneDoMap["archer_show"] = new CutSceneDo(archer_show.Do);
			this.m_CutSceneDoMap["cleric_show"] = new CutSceneDo(cleric_show.Do);
			this.m_CutSceneDoMap["academic_show"] = new CutSceneDo(academic_show.Do);
			this.m_CutSceneDoMap["assassin_show"] = new CutSceneDo(assassin_show.Do);
			this.m_CutSceneDoMap["kali_show"] = new CutSceneDo(kali_show.Do);
			this.m_CutSceneDoMap["heromvp"] = new CutSceneDo(heromvp.Do);
			this.m_CutSceneDoMap["mobaend"] = new CutSceneDo(mobaend.Do);
			this.m_SkillDoMap["Monster_broo_black_teleport_backDisappear"] = new SkillDo(Monster_broo_black_teleport_back.Disappear);
			this.m_SkillDoMap["Monster_broo_white_boss_teleport_backDisappear"] = new SkillDo(Monster_broo_white_boss_teleport_back.Disappear);
			this.m_SkillDoMap["Monster_broo_white_boss_teleport_fowardDisappear"] = new SkillDo(Monster_broo_white_boss_teleport_foward.Disappear);
			this.m_SkillDoMap["Monster_broo_white_opposer_teleport_backDisappear"] = new SkillDo(Monster_broo_white_opposer_teleport_back.Disappear);
			this.m_SkillDoMap["NPC_Velskud_teleportDisappear"] = new SkillDo(NPC_Velskud_teleport.Disappear);
			this.m_SkillDoMap["NPC_Velskud_wing_teleportDisappear"] = new SkillDo(NPC_Velskud_wing_teleport.Disappear);
			this.m_SkillDoMap["Player_sorceress_dashDisappear"] = new SkillDo(Player_sorceress_dash.Disappear);
			this.m_SkillDoMap["Player_warrior_chargecheckInput"] = new SkillDo(Player_warrior_charge.checkInput);
			this.m_SkillDoMap["Player_warrior_dash_startcanfirecharge"] = new SkillDo(Player_warrior_dash_start.canfirecharge);
			this.m_SkillDoMap["Player_cleric_attack_chongjizhishouCallBomber"] = new SkillDo(Player_cleric_attack_chongjizhishou.CallBomber);
			this.m_SkillDoMap["Player_assassin_attack_chakelahuanying_dashDisappear"] = new SkillDo(Player_assassin_attack_chakelahuanying_dash.Disappear);
			this.m_SkillDoMap["Player_academic_buff_fuhuoReviveAlly"] = new SkillDo(Player_academic_buff_fuhuo.ReviveAlly);
			this.m_SkillDoMap["Player_kali_attack_reqingsihuoDisappear"] = new SkillDo(Player_kali_attack_reqingsihuo.Disappear);
			return true;
		}

		// Token: 0x0600A96E RID: 43374 RVA: 0x001E2B30 File Offset: 0x001E0D30
		public bool ExecuteCutScene(string method, List<XActor> actors)
		{
			CutSceneDo cutSceneDo = null;
			bool flag = this.m_CutSceneDoMap.TryGetValue(method, out cutSceneDo);
			if (flag)
			{
				bool flag2 = cutSceneDo != null;
				if (flag2)
				{
					return cutSceneDo(actors);
				}
			}
			return false;
		}

		// Token: 0x0600A96F RID: 43375 RVA: 0x001E2B6C File Offset: 0x001E0D6C
		public void ExecuteSkill(string method, XSkill skill)
		{
			SkillDo skillDo = null;
			bool flag = this.m_SkillDoMap.TryGetValue(method, out skillDo);
			if (flag)
			{
				bool flag2 = skillDo != null;
				if (flag2)
				{
					skillDo(skill);
				}
			}
		}

		// Token: 0x0600A970 RID: 43376 RVA: 0x001E2BA2 File Offset: 0x001E0DA2
		public void GetSkillDo(string method, out SkillDo sd)
		{
			sd = null;
			this.m_SkillDoMap.TryGetValue(method, out sd);
		}

		// Token: 0x04003EA3 RID: 16035
		private Dictionary<string, CutSceneDo> m_CutSceneDoMap = new Dictionary<string, CutSceneDo>();

		// Token: 0x04003EA4 RID: 16036
		private Dictionary<string, SkillDo> m_SkillDoMap = new Dictionary<string, SkillDo>();
	}
}
