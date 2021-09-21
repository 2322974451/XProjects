using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C5C RID: 3164
	internal class WeekNestRankHandler : DlgHandlerBase
	{
		// Token: 0x170031AA RID: 12714
		// (get) Token: 0x0600B332 RID: 45874 RVA: 0x0022CBD4 File Offset: 0x0022ADD4
		private XWeekNestDocument m_doc
		{
			get
			{
				return XWeekNestDocument.Doc;
			}
		}

		// Token: 0x170031AB RID: 12715
		// (get) Token: 0x0600B333 RID: 45875 RVA: 0x0022CBEC File Offset: 0x0022ADEC
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/WeekNestRank";
			}
		}

		// Token: 0x0600B334 RID: 45876 RVA: 0x0022CC04 File Offset: 0x0022AE04
		protected override void Init()
		{
			base.Init();
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.FindChild("Panel");
			this.m_wrapContent = (transform.FindChild("FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_tipsGo = base.PanelObject.transform.FindChild("Tips").gameObject;
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600B335 RID: 45877 RVA: 0x0022CCB1 File Offset: 0x0022AEB1
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosedClicked));
		}

		// Token: 0x0600B336 RID: 45878 RVA: 0x0022CCD3 File Offset: 0x0022AED3
		protected override void OnShow()
		{
			base.OnShow();
			this.FillDefault();
			this.m_doc.ReqRankList();
		}

		// Token: 0x0600B337 RID: 45879 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B338 RID: 45880 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600B339 RID: 45881 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B33A RID: 45882 RVA: 0x0022CCFA File Offset: 0x0022AEFA
		private void FillDefault()
		{
			this.m_tipsGo.SetActive(true);
			this.m_wrapContent.gameObject.SetActive(false);
		}

		// Token: 0x0600B33B RID: 45883 RVA: 0x0022CD1C File Offset: 0x0022AF1C
		public void FillContent()
		{
			bool flag = this.m_doc.RankList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", RankeType.FirstPassRank.ToString(), null, null, null, null);
			}
			else
			{
				bool flag2 = this.m_doc.RankList.InfoList == null || this.m_doc.RankList.InfoList.Count == 0;
				if (flag2)
				{
					this.m_tipsGo.SetActive(true);
					this.m_wrapContent.gameObject.SetActive(false);
				}
				else
				{
					this.m_tipsGo.SetActive(false);
					this.m_wrapContent.gameObject.SetActive(true);
					int count = this.m_doc.RankList.InfoList.Count;
					this.m_wrapContent.SetContentCount(count, false);
				}
			}
		}

		// Token: 0x0600B33C RID: 45884 RVA: 0x0022CDFC File Offset: 0x0022AFFC
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.m_doc.RankList.InfoList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", RankeType.FirstPassRank.ToString(), null, null, null, null);
			}
			else
			{
				bool flag2 = index >= this.m_doc.RankList.InfoList.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("index >= rankDataList.rankList.Count", null, null, null, null, null);
				}
				else
				{
					FirstPassRankInfo firstPassRankInfo = this.m_doc.RankList.InfoList[index];
					IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(firstPassRankInfo.PassTimeStr.Replace("/n", "\n"));
					ixuilabel = (t.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(this.m_doc.GetTittleNameByRank(index + 1));
					bool flag3 = firstPassRankInfo.InfoDataList.Count != 0;
					if (flag3)
					{
						Transform transform = t.FindChild("Labs");
						for (int i = 0; i < transform.childCount; i++)
						{
							bool flag4 = i >= firstPassRankInfo.InfoDataList.Count;
							if (flag4)
							{
								transform.GetChild(i).gameObject.SetActive(false);
							}
							else
							{
								transform.GetChild(i).gameObject.SetActive(true);
								IXUILabelSymbol ixuilabelSymbol = transform.GetChild(i).GetComponent("XUILabelSymbol") as IXUILabelSymbol;
								ixuilabelSymbol.ID = (ulong)((long)(index * 100 + i));
								ixuilabelSymbol.InputText = firstPassRankInfo.InfoDataList[i].Name;
								ixuilabelSymbol.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this.OnClickName));
							}
						}
					}
					this.SetRank(t, index);
				}
			}
		}

		// Token: 0x0600B33D RID: 45885 RVA: 0x0022CFF8 File Offset: 0x0022B1F8
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

		// Token: 0x0600B33E RID: 45886 RVA: 0x0022D0C0 File Offset: 0x0022B2C0
		private bool OnClosedClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600B33F RID: 45887 RVA: 0x0022D0DC File Offset: 0x0022B2DC
		private void OnClickName(IXUILabelSymbol iSp)
		{
			bool flag = this.m_doc.RankList.InfoList == null;
			if (!flag)
			{
				int index = (int)iSp.ID / 100;
				FirstPassRankInfo firstPassRankInfo = this.m_doc.RankList.InfoList[index];
				bool flag2 = firstPassRankInfo == null;
				if (!flag2)
				{
					int index2 = (int)iSp.ID % 100;
					FirstPassInfoData firstPassInfoData = firstPassRankInfo.InfoDataList[index2];
					bool flag3 = firstPassInfoData == null;
					if (!flag3)
					{
						XCharacterCommonMenuDocument.ReqCharacterMenuInfo(firstPassInfoData.Id, false);
					}
				}
			}
		}

		// Token: 0x0400454F RID: 17743
		private IXUIButton m_closeBtn;

		// Token: 0x04004550 RID: 17744
		private IXUIWrapContent m_wrapContent;

		// Token: 0x04004551 RID: 17745
		private GameObject m_tipsGo;
	}
}
