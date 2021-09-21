using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C5B RID: 3163
	internal class WeekNestRankDlg : DlgBase<WeekNestRankDlg, WeekNestRankBehavior>
	{
		// Token: 0x170031A8 RID: 12712
		// (get) Token: 0x0600B325 RID: 45861 RVA: 0x0022C840 File Offset: 0x0022AA40
		public override string fileName
		{
			get
			{
				return "OperatingActivity/WeekNestRank";
			}
		}

		// Token: 0x170031A9 RID: 12713
		// (get) Token: 0x0600B326 RID: 45862 RVA: 0x0022C858 File Offset: 0x0022AA58
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B327 RID: 45863 RVA: 0x0022C86B File Offset: 0x0022AA6B
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600B328 RID: 45864 RVA: 0x0022C875 File Offset: 0x0022AA75
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600B329 RID: 45865 RVA: 0x0022C87F File Offset: 0x0022AA7F
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B32A RID: 45866 RVA: 0x0022C88C File Offset: 0x0022AA8C
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
		}

		// Token: 0x0600B32B RID: 45867 RVA: 0x0022C8DB File Offset: 0x0022AADB
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B32C RID: 45868 RVA: 0x0022C8E5 File Offset: 0x0022AAE5
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B32D RID: 45869 RVA: 0x0022C8F0 File Offset: 0x0022AAF0
		public void Refresh()
		{
			bool flag = XWeekNestDocument.Doc.LastWeekRankList.InfoList == null;
			if (!flag)
			{
				int count = XWeekNestDocument.Doc.LastWeekRankList.InfoList.Count;
				base.uiBehaviour.m_wrapContent.SetContentCount(count, false);
				base.uiBehaviour.m_ScrollView.ResetPosition();
				base.uiBehaviour.m_tipsGo.SetActive(count == 0);
			}
		}

		// Token: 0x0600B32E RID: 45870 RVA: 0x0022C968 File Offset: 0x0022AB68
		private void WrapContentItemUpdated(Transform t, int index)
		{
			List<FirstPassRankInfo> infoList = XWeekNestDocument.Doc.LastWeekRankList.InfoList;
			bool flag = index >= infoList.Count;
			if (!flag)
			{
				FirstPassRankInfo firstPassRankInfo = infoList[index];
				IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(firstPassRankInfo.PassTimeStr.Replace("/n", "\n"));
				ixuilabel = (t.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(XWeekNestDocument.Doc.GetTittleNameByRank(index + 1));
				bool flag2 = firstPassRankInfo.InfoDataList.Count != 0;
				if (flag2)
				{
					Transform transform = t.FindChild("Labs");
					for (int i = 0; i < transform.childCount; i++)
					{
						bool flag3 = i >= firstPassRankInfo.InfoDataList.Count;
						if (flag3)
						{
							transform.GetChild(i).gameObject.SetActive(false);
						}
						else
						{
							transform.GetChild(i).gameObject.SetActive(true);
							IXUILabelSymbol ixuilabelSymbol = transform.GetChild(i).GetComponent("XUILabelSymbol") as IXUILabelSymbol;
							ixuilabelSymbol.ID = (ulong)((long)(index * 100 + i));
							ixuilabelSymbol.InputText = firstPassRankInfo.InfoDataList[i].Name;
						}
					}
				}
				this.SetRank(t, index);
			}
		}

		// Token: 0x0600B32F RID: 45871 RVA: 0x0022CAE8 File Offset: 0x0022ACE8
		private bool OnCloseDlg(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B330 RID: 45872 RVA: 0x0022CB04 File Offset: 0x0022AD04
		private void SetRank(Transform tra, int rankIndex)
		{
			IXUILabel ixuilabel = tra.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = tra.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
			bool flag = (long)rankIndex == (long)((ulong)XRankDocument.INVALID_RANK);
			if (flag)
			{
				ixuilabel.SetVisible(false);
				ixuisprite.SetVisible(false);
			}
			else
			{
				bool flag2 = rankIndex < 3;
				if (flag2)
				{
					ixuisprite.SetSprite("N" + (rankIndex + 1));
					ixuisprite.SetVisible(true);
					ixuilabel.SetVisible(false);
				}
				else
				{
					ixuisprite.SetVisible(false);
					ixuilabel.SetText("No." + (rankIndex + 1));
					ixuilabel.SetVisible(true);
				}
			}
		}
	}
}
