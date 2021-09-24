using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class CrossGVGBattlePrepareView : GVGBattlePrepareBase<CrossGVGBattlePrepareView, CrossGVGBattlePrepareBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/CrossGVGBattlePrepare";
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			base.uiBehaviour.mBluePanel = new CrossGVGBattleMember();
			base.uiBehaviour.mBluePanel.Setup(base.uiBehaviour.mBlueView, 1);
			base.uiBehaviour.mRankPanel = new CrossGVGBattleRankFrame();
			base.uiBehaviour.mRankPanel.Setup(base.uiBehaviour.mRankFrame, 1);
			base.uiBehaviour.mRevive.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnReviveNotify));
		}

		public override void ReFreshGroup()
		{
			bool flag = !XSingleton<XScene>.singleton.bSpectator && base.uiBehaviour.mRankPanel.IsActive();
			if (flag)
			{
				base.uiBehaviour.mRankPanel.ReFreshData(this._Doc.BlueInfo);
			}
			base.ReFreshGroup();
		}

		protected override void SelectionPattern()
		{
			base.uiBehaviour.mCombatScore.SetActive(false);
			base.uiBehaviour.mBattleDuelInfo.SetVisible(this._Doc.IsGCF());
		}

		protected override void SectionShowReady()
		{
			base.uiBehaviour.mRankPanel.SetActive(false);
			base.SectionShowReady();
		}

		protected override void SectionShowBattle()
		{
			base.SectionShowBattle();
			bool flag = !XSingleton<XScene>.singleton.bSpectator && !base.uiBehaviour.mRankPanel.IsActive();
			if (flag)
			{
				base.uiBehaviour.mRankPanel.SetActive(true);
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !XSingleton<XScene>.singleton.bSpectator && base.uiBehaviour.mRankPanel.IsActive();
			if (flag)
			{
				base.uiBehaviour.mRankPanel.OnUpdate();
			}
		}

		protected override void OnUnload()
		{
			bool flag = base.uiBehaviour.mRankPanel != null;
			if (flag)
			{
				base.uiBehaviour.mRankPanel.Recycle();
				base.uiBehaviour.mRankPanel = null;
			}
			base.OnUnload();
		}

		protected override void SetupOtherResurgence()
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			bool flag = specificDocument.ReviveItemID > 0U && specificDocument.ReviveItemNumber > 0U;
			if (flag)
			{
				base.uiBehaviour.mRevive.SetVisible(true);
				string inputText = XLabelSymbolHelper.FormatItemSmallIcon(XStringDefineProxy.GetString("ReviveOntime"), (int)specificDocument.ReviveItemID, (int)specificDocument.ReviveItemNumber);
				base.uiBehaviour.mReviveSymbol.InputText = inputText;
			}
			else
			{
				base.uiBehaviour.mRevive.SetVisible(false);
			}
		}

		private bool _OnReviveNotify(IXUIButton btn)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.SendVSPayRevive();
			return true;
		}
	}
}
