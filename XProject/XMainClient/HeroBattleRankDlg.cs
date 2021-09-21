using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C2B RID: 3115
	internal class HeroBattleRankDlg : DlgBase<HeroBattleRankDlg, HeroBattleRankBehavior>
	{
		// Token: 0x1700311C RID: 12572
		// (get) Token: 0x0600B06A RID: 45162 RVA: 0x0021AEC8 File Offset: 0x002190C8
		public override string fileName
		{
			get
			{
				return "GameSystem/HeroBattleRankDlg";
			}
		}

		// Token: 0x1700311D RID: 12573
		// (get) Token: 0x0600B06B RID: 45163 RVA: 0x0021AEE0 File Offset: 0x002190E0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B06C RID: 45164 RVA: 0x0021AEF3 File Offset: 0x002190F3
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600B06D RID: 45165 RVA: 0x0021AEFD File Offset: 0x002190FD
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600B06E RID: 45166 RVA: 0x0021AF07 File Offset: 0x00219107
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B06F RID: 45167 RVA: 0x0021AF14 File Offset: 0x00219114
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_RankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdated));
			this._doc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			base.uiBehaviour.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
		}

		// Token: 0x0600B070 RID: 45168 RVA: 0x0021AF74 File Offset: 0x00219174
		private bool OnCloseDlg(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B071 RID: 45169 RVA: 0x0021AF90 File Offset: 0x00219190
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B072 RID: 45170 RVA: 0x0021AF9A File Offset: 0x0021919A
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B073 RID: 45171 RVA: 0x0021AFA4 File Offset: 0x002191A4
		public void SetupRankFrame()
		{
			this.SetRankTpl(base.uiBehaviour.m_MyRankTs, 0, true);
			base.uiBehaviour.m_RankWrapContent.SetContentCount(this._doc.LastWeek_MainRankList.Count, false);
			base.uiBehaviour.m_RankScrollView.ResetPosition();
		}

		// Token: 0x0600B074 RID: 45172 RVA: 0x0021AFFC File Offset: 0x002191FC
		public void WrapListUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.LastWeek_MainRankList.Count;
			if (!flag)
			{
				this.SetRankTpl(t, index, false);
			}
		}

		// Token: 0x0600B075 RID: 45173 RVA: 0x0021B038 File Offset: 0x00219238
		public void SetRankTpl(Transform t, int index, bool isMy)
		{
			HeroBattleRankData heroBattleRankData = isMy ? this._doc.LastWeek_MyRankData : this._doc.LastWeek_MainRankList[index];
			IXUILabel ixuilabel = t.Find("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.Find("RankImage").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("Value1").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = t.Find("Value2").GetComponent("XUILabel") as IXUILabel;
			bool flag = heroBattleRankData.rank < 3U;
			if (flag)
			{
				ixuisprite.SetVisible(true);
				ixuilabel.SetVisible(false);
				ixuisprite.spriteName = string.Format("N{0}", heroBattleRankData.rank + 1U);
			}
			else
			{
				ixuisprite.SetVisible(false);
				ixuilabel.SetVisible(true);
				ixuilabel.SetText(string.Format("No.{0}", heroBattleRankData.rank + 1U));
			}
			if (isMy)
			{
				bool flag2 = heroBattleRankData.rank == uint.MaxValue;
				if (flag2)
				{
					base.uiBehaviour.m_OutOfRank.SetActive(true);
					ixuisprite.SetVisible(false);
					ixuilabel.SetVisible(false);
				}
				else
				{
					base.uiBehaviour.m_OutOfRank.SetActive(false);
				}
			}
			bool flag3 = heroBattleRankData.fightTotal == 0U;
			int num;
			if (flag3)
			{
				num = 0;
			}
			else
			{
				num = (int)Mathf.Floor(heroBattleRankData.winTotal * 100U / heroBattleRankData.fightTotal);
			}
			ixuilabel2.SetText(heroBattleRankData.name);
			ixuilabel3.SetText(string.Format("{0}%", num));
			ixuilabel4.SetText(heroBattleRankData.fightTotal.ToString());
			ixuilabel2.ID = heroBattleRankData.roleID;
			ixuilabel2.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnPlayerInfoClick));
		}

		// Token: 0x0600B076 RID: 45174 RVA: 0x0021B23C File Offset: 0x0021943C
		private void OnPlayerInfoClick(IXUILabel label)
		{
			bool flag = label.ID == 0UL;
			if (!flag)
			{
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(label.ID, false);
			}
		}

		// Token: 0x040043DA RID: 17370
		private XHeroBattleDocument _doc = null;
	}
}
