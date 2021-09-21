using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BF6 RID: 3062
	internal class XTeamLeagueRankView : DlgBase<XTeamLeagueRankView, XTeamLeagueRankBehavior>
	{
		// Token: 0x170030B1 RID: 12465
		// (get) Token: 0x0600AE20 RID: 44576 RVA: 0x00208FD8 File Offset: 0x002071D8
		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueRank";
			}
		}

		// Token: 0x170030B2 RID: 12466
		// (get) Token: 0x0600AE21 RID: 44577 RVA: 0x00208FF0 File Offset: 0x002071F0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030B3 RID: 12467
		// (get) Token: 0x0600AE22 RID: 44578 RVA: 0x00209004 File Offset: 0x00207204
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030B4 RID: 12468
		// (get) Token: 0x0600AE23 RID: 44579 RVA: 0x00209018 File Offset: 0x00207218
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AE24 RID: 44580 RVA: 0x0020902B File Offset: 0x0020722B
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600AE25 RID: 44581 RVA: 0x0020903C File Offset: 0x0020723C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600AE26 RID: 44582 RVA: 0x00209046 File Offset: 0x00207246
		protected override void OnHide()
		{
			this.IsLastWeek = false;
			base.OnHide();
		}

		// Token: 0x0600AE27 RID: 44583 RVA: 0x00209058 File Offset: 0x00207258
		public void RefreshUI(XBaseRankList list)
		{
			int num = 0;
			this.list = list;
			bool flag = list != null;
			if (flag)
			{
				num = this.list.rankList.Count;
				base.uiBehaviour.WrapContent.SetContentCount(list.rankList.Count, false);
			}
			base.uiBehaviour.NoRankTrans.gameObject.SetActive(num == 0);
		}

		// Token: 0x0600AE28 RID: 44584 RVA: 0x002090C4 File Offset: 0x002072C4
		private void InitProperties()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateRankItem));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.InitWrapContentItem));
		}

		// Token: 0x0600AE29 RID: 44585 RVA: 0x0020912C File Offset: 0x0020732C
		private void InitWrapContentItem(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.Find("Background").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickRankItem));
		}

		// Token: 0x0600AE2A RID: 44586 RVA: 0x00209168 File Offset: 0x00207368
		private void OnClickRankItem(IXUISprite uiSprite)
		{
			ulong id = uiSprite.ID;
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueTeamInfo(id);
		}

		// Token: 0x0600AE2B RID: 44587 RVA: 0x0020918C File Offset: 0x0020738C
		private void UpdateRankItem(Transform itemTransform, int index)
		{
			bool flag = this.list != null && index < this.list.rankList.Count;
			if (flag)
			{
				XLeagueTeamRankInfo xleagueTeamRankInfo = this.list.rankList[index] as XLeagueTeamRankInfo;
				IXUILabel ixuilabel = itemTransform.Find("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = itemTransform.Find("RankImage").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel2 = itemTransform.Find("TeamName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = itemTransform.Find("ServerName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = itemTransform.Find("Score").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = itemTransform.Find("WinTimes").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel6 = itemTransform.Find("WinRates").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = itemTransform.Find("Background").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteName = ixuisprite.spriteName.Substring(0, ixuisprite.spriteName.Length - 1) + Mathf.Min(xleagueTeamRankInfo.rank + 1U, 3f);
				ixuisprite.gameObject.SetActive(xleagueTeamRankInfo.rank < 3U);
				ixuilabel.SetText((xleagueTeamRankInfo.rank >= 3U) ? (xleagueTeamRankInfo.rank + 1U).ToString() : "");
				ixuilabel4.SetText(xleagueTeamRankInfo.point.ToString());
				ixuilabel5.SetText(xleagueTeamRankInfo.winNum.ToString());
				ixuilabel6.SetText((int)(xleagueTeamRankInfo.winRate * 100f) + "%");
				ixuilabel2.SetText(xleagueTeamRankInfo.teamName);
				ixuilabel3.SetText("(" + xleagueTeamRankInfo.serverName + ")");
				ixuisprite2.ID = xleagueTeamRankInfo.leagueTeamID;
			}
		}

		// Token: 0x0600AE2C RID: 44588 RVA: 0x002093B4 File Offset: 0x002075B4
		private bool OnCloseBtnClicked(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x040041F3 RID: 16883
		public bool IsLastWeek = false;

		// Token: 0x040041F4 RID: 16884
		private XBaseRankList list = null;
	}
}
