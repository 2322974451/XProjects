using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001882 RID: 6274
	internal class BattleContinueDlg : DlgBase<BattleContinueDlg, BattleContinueDlgBehaviour>
	{
		// Token: 0x170039CA RID: 14794
		// (get) Token: 0x0601052F RID: 66863 RVA: 0x003F47C0 File Offset: 0x003F29C0
		public override string fileName
		{
			get
			{
				return "Battle/BattleContinueDlg";
			}
		}

		// Token: 0x170039CB RID: 14795
		// (get) Token: 0x06010530 RID: 66864 RVA: 0x003F47D8 File Offset: 0x003F29D8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039CC RID: 14796
		// (get) Token: 0x06010531 RID: 66865 RVA: 0x003F47EC File Offset: 0x003F29EC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010532 RID: 66866 RVA: 0x003F47FF File Offset: 0x003F29FF
		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument);
		}

		// Token: 0x06010533 RID: 66867 RVA: 0x003F4821 File Offset: 0x003F2A21
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Continue.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnContinueClicked));
		}

		// Token: 0x06010534 RID: 66868 RVA: 0x003F4848 File Offset: 0x003F2A48
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

		// Token: 0x06010535 RID: 66869 RVA: 0x003F490C File Offset: 0x003F2B0C
		protected bool OnContinueClicked(IXUIButton button)
		{
			this.SetVisible(false, true);
			XBossBushDocument specificDocument = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
			specificDocument.SendQuery(BossRushReqStatus.BOSSRUSH_RESULT_WIN);
			specificDocument.SendQuery(BossRushReqStatus.BOSSRUSH_REQ_BASEDATA);
			return true;
		}

		// Token: 0x06010536 RID: 66870 RVA: 0x003F4944 File Offset: 0x003F2B44
		protected bool OnReturnClicked(IXUIButton button)
		{
			XSingleton<XLevelFinishMgr>.singleton.ForceLevelFinish(true);
			XSingleton<XLevelFinishMgr>.singleton.WaitingLevelContinueSelect = false;
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x06010537 RID: 66871 RVA: 0x003F4978 File Offset: 0x003F2B78
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

		// Token: 0x04007591 RID: 30097
		private XLevelDocument _doc;
	}
}
