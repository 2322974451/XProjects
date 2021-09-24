using System;

namespace XMainClient.UI
{

	internal class InnerGVGBattlePrepareView : GVGBattlePrepareBase<InnerGVGBattlePrepareView, InnerGVGBattlePrepareBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/GuildArenaPrepareDlg";
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			base.uiBehaviour.mBluePanel = new InnerGVGBattleMember();
			base.uiBehaviour.mBluePanel.Setup(base.uiBehaviour.mBlueView, 1);
		}

		protected override void SelectionPattern()
		{
			base.SelectionPattern();
			base.uiBehaviour.mCombatScore.SetActive(this._Doc.IsGMF());
			base.uiBehaviour.mBattleDuelInfo.SetVisible(this._Doc.IsGPR());
		}
	}
}
