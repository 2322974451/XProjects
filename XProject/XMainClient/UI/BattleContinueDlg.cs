using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleContinueDlg : DlgBase<BattleContinueDlg, BattleContinueDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/BattleContinueDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Continue.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnContinueClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(false);
				DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.Show(false);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(false, true);
				base.uiBehaviour.m_tween.PlayTween(true, -1f);
			}
			bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisiblePure(false);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(false, true);
				DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(false);
			}
			bool flag3 = DlgBase<XChatView, XChatBehaviour>.singleton.IsLoaded();
			if (flag3)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
			}
		}

		protected bool OnContinueClicked(IXUIButton button)
		{
			this.SetVisible(false, true);
			XBossBushDocument specificDocument = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
			specificDocument.SendQuery(BossRushReqStatus.BOSSRUSH_RESULT_WIN);
			specificDocument.SendQuery(BossRushReqStatus.BOSSRUSH_REQ_BASEDATA);
			return true;
		}

		protected bool OnReturnClicked(IXUIButton button)
		{
			XSingleton<XLevelFinishMgr>.singleton.ForceLevelFinish(true);
			XSingleton<XLevelFinishMgr>.singleton.WaitingLevelContinueSelect = false;
			this.SetVisible(false, true);
			return true;
		}

		public void ShowBossrushResult()
		{
			this.SetVisible(true, true);
			XSingleton<XLevelFinishMgr>.singleton.WaitingLevelContinueSelect = true;
			XBossBushDocument specificDocument = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
			base.uiBehaviour.m_Next.gameObject.SetActive(true);
			base.uiBehaviour.m_lblNum.SetText(XStringDefineProxy.GetString("BOSS_RATE_RWD", new object[]
			{
				specificDocument.rwdRate
			}));
			base.uiBehaviour.m_lblNum.SetVisible(specificDocument.rwdRate > 1f);
			base.uiBehaviour.m_NextItemPool.ReturnAll(false);
			for (int i = 0; i < specificDocument.bossRushRow.reward.Count; i++)
			{
				uint num = specificDocument.bossRushRow.reward[i, 0];
				uint num2 = specificDocument.bossRushRow.reward[i, 1];
				GameObject gameObject = base.uiBehaviour.m_NextItemPool.FetchGameObject(false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)num, (int)(num2 * specificDocument.rwdRate), false);
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				bool flag = specificDocument.bossRushRow.reward.Count % 2 == 0;
				if (flag)
				{
					gameObject.transform.localPosition = new Vector3(130f * ((float)(i - specificDocument.bossRushRow.reward.Count / 2) + 0.5f), 0f, 0f);
				}
				else
				{
					gameObject.transform.localPosition = new Vector3((float)(130 * (i - specificDocument.bossRushRow.reward.Count / 2)), 0f, 0f);
				}
			}
		}

		private XLevelDocument _doc;
	}
}
