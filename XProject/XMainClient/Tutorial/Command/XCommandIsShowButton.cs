using System;
using XMainClient.UI.UICommon;

namespace XMainClient.Tutorial.Command
{

	internal class XCommandIsShowButton : XBaseCommand
	{

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

		private void SetLearnSkillButtonState(bool state)
		{
			DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.SetLearnSkillButtonState(state);
		}
	}
}
