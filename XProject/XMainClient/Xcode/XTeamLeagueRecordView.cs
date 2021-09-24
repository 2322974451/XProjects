using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamLeagueRecordView : DlgBase<XTeamLeagueRecordView, XTeamLeagueRecordBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueRecord";
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
			XFreeTeamVersusLeagueDocument.Doc.SendGetLeagueBattleRecord();
		}

		private void InitProperties()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateRecordItem));
		}

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

		private bool OnCloseBtnClicked(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		public void RefreshUI()
		{
			this.RefreshBaseInfo();
			this.RefreshWrapContent();
		}

		private void RefreshWrapContent()
		{
			int pkRecordCount = XFreeTeamVersusLeagueDocument.Doc.GetPkRecordCount();
			base.uiBehaviour.WrapContent.SetContentCount(pkRecordCount, false);
			Transform parent = base.uiBehaviour.WrapContent.gameObject.transform.parent;
			IXUIScrollView ixuiscrollView = parent.GetComponent("XUIScrollView") as IXUIScrollView;
			ixuiscrollView.ResetPosition();
		}

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
