using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XQualifyingLastSeasonRankDlg : DlgBase<XQualifyingLastSeasonRankDlg, XQualifyingLastSeasonRankBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/XQualifyingLastSeasonRankDlg";
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
			base.Init();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public void SetupRankWindow(List<QualifyingRankInfo> list)
		{
			base.uiBehaviour.m_RolePool.FakeReturnAll();
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RolePool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Bg/Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.FindChild("Bg/Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = gameObject.transform.FindChild("Bg/Point").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Bg/RankImage").GetComponent("XUISprite") as IXUISprite;
				bool flag = list[i].rank > 3U;
				if (flag)
				{
					ixuilabel.SetText(string.Format("No.{0}", list[i].rank));
				}
				else
				{
					ixuilabel.SetText("");
				}
				ixuilabel2.SetText(string.Format("Lv.{0}", list[i].level));
				ixuilabel3.SetText(list[i].name);
				ixuilabel4.SetText(list[i].point.ToString());
				ixuisprite.SetSprite(string.Format("N{0}", list[i].rank));
				ixuilabel3.ID = list[i].uid;
				bool flag2 = list[i].uid == 0UL;
				if (flag2)
				{
					ixuilabel3.RegisterLabelClickEventHandler(null);
				}
				else
				{
					ixuilabel3.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnRankItemClicked));
				}
				gameObject.transform.localPosition = base.uiBehaviour.m_RolePool.TplPos - new Vector3(0f, (float)(i * base.uiBehaviour.m_RolePool.TplHeight));
			}
			base.uiBehaviour.m_RolePool.ActualReturnAll(false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		private void OnRankItemClicked(IXUILabel label)
		{
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(label.ID, false);
		}

		private bool OnCloseDlg(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}
	}
}
