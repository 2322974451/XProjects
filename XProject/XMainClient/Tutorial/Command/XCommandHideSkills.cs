using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient.Tutorial.Command
{
	// Token: 0x020016C6 RID: 5830
	internal class XCommandHideSkills : XBaseCommand
	{
		// Token: 0x0600F077 RID: 61559 RVA: 0x0034D3C0 File Offset: 0x0034B5C0
		public override bool Execute()
		{
			bool flag = !string.IsNullOrEmpty(this._cmd.param1);
			if (flag)
			{
				this.Hide(int.Parse(this._cmd.param1));
			}
			bool flag2 = !string.IsNullOrEmpty(this._cmd.param2);
			if (flag2)
			{
				this.Hide(int.Parse(this._cmd.param2));
			}
			bool flag3 = !string.IsNullOrEmpty(this._cmd.param3);
			if (flag3)
			{
				this.Hide(int.Parse(this._cmd.param3));
			}
			base.publicModule();
			return true;
		}

		// Token: 0x0600F078 RID: 61560 RVA: 0x0034D46C File Offset: 0x0034B66C
		private void Hide(int idx)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.DisableSkill(idx);
			}
		}
	}
}
