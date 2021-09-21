using System;
using XMainClient.UI.UICommon;

namespace XMainClient.Tutorial.Command
{
	// Token: 0x020016C4 RID: 5828
	internal class XCommandIsShowButton : XBaseCommand
	{
		// Token: 0x0600F06F RID: 61551 RVA: 0x0034D174 File Offset: 0x0034B374
		public override bool Execute()
		{
			bool flag = this._cmd.param1 == null || this._cmd.param2 == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int num = int.Parse(this._cmd.param2);
				bool flag2 = num == 0;
				bool learnSkillButtonState = !flag2;
				bool flag3 = this._cmd.param1 == "LearnSkillButton";
				if (flag3)
				{
					this.SetLearnSkillButtonState(learnSkillButtonState);
				}
				base.publicModule();
				result = true;
			}
			return result;
		}

		// Token: 0x0600F070 RID: 61552 RVA: 0x0034D1FE File Offset: 0x0034B3FE
		private void SetLearnSkillButtonState(bool state)
		{
			DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.SetLearnSkillButtonState(state);
		}
	}
}
