using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient.Tutorial.Command
{
	// Token: 0x020016C8 RID: 5832
	internal class XCommandShowSkills : XBaseCommand
	{
		// Token: 0x0600F080 RID: 61568 RVA: 0x0034DA30 File Offset: 0x0034BC30
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

		// Token: 0x0600F081 RID: 61569 RVA: 0x0034DADC File Offset: 0x0034BCDC
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
