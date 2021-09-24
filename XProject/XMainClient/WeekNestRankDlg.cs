using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class WeekNestRankDlg : DlgBase<WeekNestRankDlg, WeekNestRankBehavior>
	{

		public override string fileName
		{
			get
			{
				return "OperatingActivity/WeekNestRank";
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
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

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

		private bool OnCloseDlg(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

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
