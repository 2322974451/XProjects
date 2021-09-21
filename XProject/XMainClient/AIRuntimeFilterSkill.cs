using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD5 RID: 2773
	internal class AIRuntimeFilterSkill : AIRunTimeNodeAction
	{
		// Token: 0x0600A5A9 RID: 42409 RVA: 0x001CDEC4 File Offset: 0x001CC0C4
		public AIRuntimeFilterSkill(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
			this._use_mp = (node.GetAttribute("UseMP") != "0");
			this._use_name = (node.GetAttribute("UseName") != "0");
			this._use_hp = (node.GetAttribute("UseHP") != "0");
			this._use_cool_down = (node.GetAttribute("UseCoolDown") != "0");
			this._use_attack_field = (node.GetAttribute("UseAttackField") != "0");
			this._use_combo = (node.GetAttribute("UseCombo") != "0");
			this._use_install = (node.GetAttribute("UseInstall") != "0");
			this._skill_type = int.Parse(node.GetAttribute("SkillType"));
			this._skill_name = node.GetAttribute("SkillName");
			this._detect_all_attack_field = (node.GetAttribute("DetectAllPlayInAttackField") != "0");
			string attribute = node.GetAttribute("MaxSkillNum");
			bool flag = !string.IsNullOrEmpty(attribute);
			if (flag)
			{
				this._max_skill_num = int.Parse(attribute);
			}
			else
			{
				this._max_skill_num = 0;
			}
		}

		// Token: 0x0600A5AA RID: 42410 RVA: 0x001CE020 File Offset: 0x001CC220
		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			FilterSkillArg filterSkillArg = new FilterSkillArg();
			filterSkillArg.mAIArgUseMP = this._use_mp;
			filterSkillArg.mAIArgUseName = this._use_name;
			filterSkillArg.mAIArgUseHP = this._use_hp;
			filterSkillArg.mAIArgUseCoolDown = this._use_cool_down;
			filterSkillArg.mAIArgUseAttackField = this._use_attack_field;
			filterSkillArg.mAIArgUseCombo = this._use_combo;
			filterSkillArg.mAIArgUseInstall = this._use_install;
			filterSkillArg.mAIArgSkillType = this._skill_type;
			filterSkillArg.mAIArgSkillName = this._skill_name;
			filterSkillArg.mAIArgDetectAllPlayInAttackField = this._detect_all_attack_field;
			filterSkillArg.mAIArgMaxSkillNum = this._max_skill_num;
			XEntity target = null;
			bool flag = xgameObjectByName != null;
			if (flag)
			{
				target = XSingleton<XEntityMgr>.singleton.GetEntity(xgameObjectByName.UID);
			}
			return XSingleton<XAISkill>.singleton.SelectSkill(entity, target, filterSkillArg);
		}

		// Token: 0x04003CA5 RID: 15525
		private string _target_name;

		// Token: 0x04003CA6 RID: 15526
		private bool _use_mp;

		// Token: 0x04003CA7 RID: 15527
		private bool _use_name;

		// Token: 0x04003CA8 RID: 15528
		private bool _use_hp;

		// Token: 0x04003CA9 RID: 15529
		private bool _use_cool_down;

		// Token: 0x04003CAA RID: 15530
		private bool _use_attack_field;

		// Token: 0x04003CAB RID: 15531
		private bool _use_combo;

		// Token: 0x04003CAC RID: 15532
		private bool _use_install = false;

		// Token: 0x04003CAD RID: 15533
		private int _skill_type;

		// Token: 0x04003CAE RID: 15534
		private string _skill_name;

		// Token: 0x04003CAF RID: 15535
		private bool _detect_all_attack_field;

		// Token: 0x04003CB0 RID: 15536
		private int _max_skill_num;
	}
}
