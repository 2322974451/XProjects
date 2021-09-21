using System;

namespace XMainClient.UI
{
	// Token: 0x0200174E RID: 5966
	internal class InnerGVGBattlePrepareView : GVGBattlePrepareBase<InnerGVGBattlePrepareView, InnerGVGBattlePrepareBehaviour>
	{
		// Token: 0x170037F2 RID: 14322
		// (get) Token: 0x0600F693 RID: 63123 RVA: 0x0037F328 File Offset: 0x0037D528
		public override string fileName
		{
			get
			{
				return "Battle/GuildArenaPrepareDlg";
			}
		}

		// Token: 0x0600F694 RID: 63124 RVA: 0x0037F33F File Offset: 0x0037D53F
		protected override void OnLoad()
		{
			base.OnLoad();
			base.uiBehaviour.mBluePanel = new InnerGVGBattleMember();
			base.uiBehaviour.mBluePanel.Setup(base.uiBehaviour.mBlueView, 1);
		}

		// Token: 0x0600F695 RID: 63125 RVA: 0x0037F378 File Offset: 0x0037D578
		protected override void SelectionPattern()
		{
			base.SelectionPattern();
			base.uiBehaviour.mCombatScore.SetActive(this._Doc.IsGMF());
			base.uiBehaviour.mBattleDuelInfo.SetVisible(this._Doc.IsGPR());
		}
	}
}
