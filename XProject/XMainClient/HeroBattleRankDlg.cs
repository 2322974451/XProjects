using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class HeroBattleRankDlg : DlgBase<HeroBattleRankDlg, HeroBattleRankBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/HeroBattleRankDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_RankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdated));
			this._doc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			base.uiBehaviour.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
		}

		private bool OnCloseDlg(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public void SetupRankFrame()
		{
			this.SetRankTpl(base.uiBehaviour.m_MyRankTs, 0, true);
			base.uiBehaviour.m_RankWrapContent.SetContentCount(this._doc.LastWeek_MainRankList.Count, false);
			base.uiBehaviour.m_RankScrollView.ResetPosition();
		}

		public void WrapListUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.LastWeek_MainRankList.Count;
			if (!flag)
			{
				this.SetRankTpl(t, index, false);
			}
		}

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

		private void OnPlayerInfoClick(IXUILabel label)
		{
			bool flag = label.ID == 0UL;
			if (!flag)
			{
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(label.ID, false);
			}
		}

		private XHeroBattleDocument _doc = null;
	}
}
