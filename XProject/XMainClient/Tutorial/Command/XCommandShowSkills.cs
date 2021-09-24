using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient.Tutorial.Command
{

	internal class XCommandShowSkills : XBaseCommand
	{

		public override bool Execute()
		{
			bool flag = !string.IsNullOrEmpty(this._cmd.param1);
			if (flag)
			{
				this.Show(int.Parse(this._cmd.param1));
			}
			bool flag2 = !string.IsNullOrEmpty(this._cmd.param2);
			if (flag2)
			{
				this.Show(int.Parse(this._cmd.param2));
			}
			bool flag3 = !string.IsNullOrEmpty(this._cmd.param3);
			if (flag3)
			{
				this.Show(int.Parse(this._cmd.param3));
			}
			base.publicModule();
			return true;
		}

		private void Show(int idx)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.EnableSkill(idx);
			}
		}
	}
}
