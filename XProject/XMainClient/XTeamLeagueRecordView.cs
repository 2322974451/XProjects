using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BF8 RID: 3064
	internal class XTeamLeagueRecordView : DlgBase<XTeamLeagueRecordView, XTeamLeagueRecordBehavior>
	{
		// Token: 0x170030B5 RID: 12469
		// (get) Token: 0x0600AE30 RID: 44592 RVA: 0x002094FC File Offset: 0x002076FC
		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueRecord";
			}
		}

		// Token: 0x170030B6 RID: 12470
		// (get) Token: 0x0600AE31 RID: 44593 RVA: 0x00209514 File Offset: 0x00207714
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030B7 RID: 12471
		// (get) Token: 0x0600AE32 RID: 44594 RVA: 0x00209528 File Offset: 0x00207728
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030B8 RID: 12472
		// (get) Token: 0x0600AE33 RID: 44595 RVA: 0x0020953C File Offset: 0x0020773C
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AE34 RID: 44596 RVA: 0x0020954F File Offset: 0x0020774F
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600AE35 RID: 44597 RVA: 0x00209560 File Offset: 0x00207760
		protected override void OnShow()
		{
			base.OnShow();
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueBattleRecord();
		}

		// Token: 0x0600AE36 RID: 44598 RVA: 0x00209575 File Offset: 0x00207775
		private void InitProperties()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateRecordItem));
		}

		// Token: 0x0600AE37 RID: 44599 RVA: 0x002095B4 File Offset: 0x002077B4
		private void UpdateRecordItem(Transform itemTransform, int index)
		{
			LeaguePKRecordInfo pkRecordInfoByIndex = XFreeTeamVersusLeagueDocument.Doc.GetPkRecordInfoByIndex(index);
			bool flag = pkRecordInfoByIndex != null;
			if (flag)
			{
				IXUILabel ixuilabel = itemTransform.Find("OpponentName").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(pkRecordInfoByIndex.opponentTeamName);
				IXUILabel ixuilabel2 = itemTransform.Find("Reward").GetComponent("XUILabel") as IXUILabel;
				string arg = (pkRecordInfoByIndex.scoreChange >= 0) ? "+" : "-";
				ixuilabel2.SetText(arg + Math.Abs(pkRecordInfoByIndex.scoreChange));
				IXUISprite ixuisprite = itemTransform.Find("Status").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteName = this.ReplaceString(ixuisprite.spriteName, (pkRecordInfoByIndex.result == PkResultType.PkResult_Draw) ? "draw" : "win");
				ixuisprite.spriteName = this.ReplaceString(ixuisprite.spriteName, (pkRecordInfoByIndex.result == PkResultType.PkResult_Win) ? "win" : "lose");
			}
		}

		// Token: 0x0600AE38 RID: 44600 RVA: 0x002096C4 File Offset: 0x002078C4
		private string ReplaceString(string origin, string target)
		{
			bool flag = origin.Contains("win");
			string result;
			if (flag)
			{
				result = origin.Replace("win", target);
			}
			else
			{
				bool flag2 = origin.Contains("lose");
				if (flag2)
				{
					result = origin.Replace("lose", target);
				}
				else
				{
					bool flag3 = origin.Contains("draw");
					if (flag3)
					{
						result = origin.Replace("draw", target);
					}
					else
					{
						result = "";
					}
				}
			}
			return result;
		}

		// Token: 0x0600AE39 RID: 44601 RVA: 0x00209738 File Offset: 0x00207938
		private bool OnCloseBtnClicked(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AE3A RID: 44602 RVA: 0x00209754 File Offset: 0x00207954
		public void RefreshUI()
		{
			this.RefreshBaseInfo();
			this.RefreshWrapContent();
		}

		// Token: 0x0600AE3B RID: 44603 RVA: 0x00209768 File Offset: 0x00207968
		private void RefreshWrapContent()
		{
			int pkRecordCount = XFreeTeamVersusLeagueDocument.Doc.GetPkRecordCount();
			base.uiBehaviour.WrapContent.SetContentCount(pkRecordCount, false);
			Transform parent = base.uiBehaviour.WrapContent.gameObject.transform.parent;
			IXUIScrollView ixuiscrollView = parent.GetComponent("XUIScrollView") as IXUIScrollView;
			ixuiscrollView.ResetPosition();
		}

		// Token: 0x0600AE3C RID: 44604 RVA: 0x002097C8 File Offset: 0x002079C8
		private void RefreshBaseInfo()
		{
			LeagueBattleRecordBaseInfo pkrecordBaseInfo = XFreeTeamVersusLeagueDocument.Doc.PKRecordBaseInfo;
			base.uiBehaviour.WinRateLabel.SetText((int)(pkrecordBaseInfo.winRate * 100f) + "%");
			base.uiBehaviour.WinTimesLabel.SetText(pkrecordBaseInfo.totalWinNum.ToString());
			base.uiBehaviour.LostTimesLabel.SetText(pkrecordBaseInfo.totalLoseNum.ToString());
			base.uiBehaviour.ConsWinLabel.SetText(pkrecordBaseInfo.maxContinueWin.ToString());
			base.uiBehaviour.ConsLoseLabel.SetText(pkrecordBaseInfo.maxContinueLose.ToString());
		}
	}
}
