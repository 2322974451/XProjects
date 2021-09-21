using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016F4 RID: 5876
	internal class CrossGVGBattlePrepareView : GVGBattlePrepareBase<CrossGVGBattlePrepareView, CrossGVGBattlePrepareBehaviour>
	{
		// Token: 0x1700375F RID: 14175
		// (get) Token: 0x0600F26A RID: 62058 RVA: 0x0035C590 File Offset: 0x0035A790
		public override string fileName
		{
			get
			{
				return "Battle/CrossGVGBattlePrepare";
			}
		}

		// Token: 0x0600F26B RID: 62059 RVA: 0x0035C5A8 File Offset: 0x0035A7A8
		protected override void OnLoad()
		{
			base.OnLoad();
			base.uiBehaviour.mBluePanel = new CrossGVGBattleMember();
			base.uiBehaviour.mBluePanel.Setup(base.uiBehaviour.mBlueView, 1);
			base.uiBehaviour.mRankPanel = new CrossGVGBattleRankFrame();
			base.uiBehaviour.mRankPanel.Setup(base.uiBehaviour.mRankFrame, 1);
			base.uiBehaviour.mRevive.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnReviveNotify));
		}

		// Token: 0x0600F26C RID: 62060 RVA: 0x0035C634 File Offset: 0x0035A834
		public override void ReFreshGroup()
		{
			bool flag = !XSingleton<XScene>.singleton.bSpectator && base.uiBehaviour.mRankPanel.IsActive();
			if (flag)
			{
				base.uiBehaviour.mRankPanel.ReFreshData(this._Doc.BlueInfo);
			}
			base.ReFreshGroup();
		}

		// Token: 0x0600F26D RID: 62061 RVA: 0x0035C688 File Offset: 0x0035A888
		protected override void SelectionPattern()
		{
			base.uiBehaviour.mCombatScore.SetActive(false);
			base.uiBehaviour.mBattleDuelInfo.SetVisible(this._Doc.IsGCF());
		}

		// Token: 0x0600F26E RID: 62062 RVA: 0x0035C6B9 File Offset: 0x0035A8B9
		protected override void SectionShowReady()
		{
			base.uiBehaviour.mRankPanel.SetActive(false);
			base.SectionShowReady();
		}

		// Token: 0x0600F26F RID: 62063 RVA: 0x0035C6D8 File Offset: 0x0035A8D8
		protected override void SectionShowBattle()
		{
			base.SectionShowBattle();
			bool flag = !XSingleton<XScene>.singleton.bSpectator && !base.uiBehaviour.mRankPanel.IsActive();
			if (flag)
			{
				base.uiBehaviour.mRankPanel.SetActive(true);
			}
		}

		// Token: 0x0600F270 RID: 62064 RVA: 0x0035C728 File Offset: 0x0035A928
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !XSingleton<XScene>.singleton.bSpectator && base.uiBehaviour.mRankPanel.IsActive();
			if (flag)
			{
				base.uiBehaviour.mRankPanel.OnUpdate();
			}
		}

		// Token: 0x0600F271 RID: 62065 RVA: 0x0035C774 File Offset: 0x0035A974
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

		// Token: 0x0600F272 RID: 62066 RVA: 0x0035C7BC File Offset: 0x0035A9BC
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

		// Token: 0x0600F273 RID: 62067 RVA: 0x0035C848 File Offset: 0x0035AA48
		private bool _OnReviveNotify(IXUIButton btn)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.SendVSPayRevive();
			return true;
		}
	}
}
