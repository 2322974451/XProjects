using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C7D RID: 3197
	internal class XQualifyingLastSeasonRankDlg : DlgBase<XQualifyingLastSeasonRankDlg, XQualifyingLastSeasonRankBehavior>
	{
		// Token: 0x170031F9 RID: 12793
		// (get) Token: 0x0600B4A4 RID: 46244 RVA: 0x00235E8C File Offset: 0x0023408C
		public override string fileName
		{
			get
			{
				return "GameSystem/XQualifyingLastSeasonRankDlg";
			}
		}

		// Token: 0x170031FA RID: 12794
		// (get) Token: 0x0600B4A5 RID: 46245 RVA: 0x00235EA4 File Offset: 0x002340A4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170031FB RID: 12795
		// (get) Token: 0x0600B4A6 RID: 46246 RVA: 0x00235EB8 File Offset: 0x002340B8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B4A7 RID: 46247 RVA: 0x00235ECB File Offset: 0x002340CB
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
		}

		// Token: 0x0600B4A8 RID: 46248 RVA: 0x00235EF2 File Offset: 0x002340F2
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B4A9 RID: 46249 RVA: 0x00235EFC File Offset: 0x002340FC
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

		// Token: 0x0600B4AA RID: 46250 RVA: 0x00236154 File Offset: 0x00234354
		private void OnRankItemClicked(IXUILabel label)
		{
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(label.ID, false);
		}

		// Token: 0x0600B4AB RID: 46251 RVA: 0x00236164 File Offset: 0x00234364
		private bool OnCloseDlg(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}
	}
}
