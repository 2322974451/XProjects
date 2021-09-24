using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeFilterSkill : AIRunTimeNodeAction
	{

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

		private string _target_name;

		private bool _use_mp;

		private bool _use_name;

		private bool _use_hp;

		private bool _use_cool_down;

		private bool _use_attack_field;

		private bool _use_combo;

		private bool _use_install = false;

		private int _skill_type;

		private string _skill_name;

		private bool _detect_all_attack_field;

		private int _max_skill_num;
	}
}
