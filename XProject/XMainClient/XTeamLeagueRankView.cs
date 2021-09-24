using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamLeagueRankView : DlgBase<XTeamLeagueRankView, XTeamLeagueRankBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueRank";
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

		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			this.IsLastWeek = false;
			base.OnHide();
		}

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

		private void InitProperties()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateRankItem));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.InitWrapContentItem));
		}

		private void InitWrapContentItem(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.Find("Background").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickRankItem));
		}

		private void OnClickRankItem(IXUISprite uiSprite)
		{
			ulong id = uiSprite.ID;
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueTeamInfo(id);
		}

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

		private bool OnCloseBtnClicked(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		public bool IsLastWeek = false;

		private XBaseRankList list = null;
	}
}
