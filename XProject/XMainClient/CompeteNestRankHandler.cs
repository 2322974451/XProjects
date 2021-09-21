using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A46 RID: 2630
	internal class CompeteNestRankHandler : DlgHandlerBase
	{
		// Token: 0x17002EE1 RID: 12001
		// (get) Token: 0x06009FB8 RID: 40888 RVA: 0x001A7CEC File Offset: 0x001A5EEC
		private XCompeteDocument m_doc
		{
			get
			{
				return XCompeteDocument.Doc;
			}
		}

		// Token: 0x17002EE2 RID: 12002
		// (get) Token: 0x06009FB9 RID: 40889 RVA: 0x001A7D04 File Offset: 0x001A5F04
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/CompeteNestRankDlg";
			}
		}

		// Token: 0x06009FBA RID: 40890 RVA: 0x001A7D1C File Offset: 0x001A5F1C
		protected override void Init()
		{
			base.Init();
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.FindChild("Panel");
			this.m_wrapContent = (transform.FindChild("FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_tipsGo = base.PanelObject.transform.FindChild("Panel/Tips").gameObject;
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x06009FBB RID: 40891 RVA: 0x001A7DC9 File Offset: 0x001A5FC9
		protected override void OnShow()
		{
			base.OnShow();
			this.FillDefault();
			this.m_doc.ReqRankList();
		}

		// Token: 0x06009FBC RID: 40892 RVA: 0x001A7DE6 File Offset: 0x001A5FE6
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosedClicked));
		}

		// Token: 0x06009FBD RID: 40893 RVA: 0x001A7E08 File Offset: 0x001A6008
		private void FillDefault()
		{
			this.m_tipsGo.SetActive(true);
			this.m_wrapContent.gameObject.SetActive(false);
		}

		// Token: 0x06009FBE RID: 40894 RVA: 0x001A7E2C File Offset: 0x001A602C
		public void FillContent()
		{
			bool flag = this.m_doc.RankList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", RankeType.CompeteDragonRank.ToString(), null, null, null, null);
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

		// Token: 0x06009FBF RID: 40895 RVA: 0x001A7F0C File Offset: 0x001A610C
		private void WrapContentItemUpdated(Transform t, int index)
		{
			XCompeteDocument specificDocument = XDocuments.GetSpecificDocument<XCompeteDocument>(XCompeteDocument.uuID);
			bool flag = specificDocument.RankList.InfoList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", RankeType.CompeteDragonRank.ToString(), null, null, null, null);
			}
			else
			{
				bool flag2 = index >= specificDocument.RankList.InfoList.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("index >= rankDataList.rankList.Count", null, null, null, null, null);
				}
				else
				{
					FirstPassRankInfo firstPassRankInfo = specificDocument.RankList.InfoList[index];
					IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(firstPassRankInfo.PassTimeStr.Replace("/n", "\n"));
					ixuilabel = (t.FindChild("Title/Text").GetComponent("XUILabel") as IXUILabel);
					IXUISprite ixuisprite = t.FindChild("Title/Pic").GetComponent("XUISprite") as IXUISprite;
					DesignationTable.RowData tittleNameByRank = specificDocument.GetTittleNameByRank(index + 1);
					bool flag3 = tittleNameByRank.Atlas != null && tittleNameByRank.Atlas != "" && tittleNameByRank.Effect != null && tittleNameByRank.Effect != "";
					if (flag3)
					{
						ixuisprite.gameObject.SetActive(true);
						ixuilabel.gameObject.SetActive(false);
						ixuisprite.SetSprite(tittleNameByRank.Effect, tittleNameByRank.Atlas, false);
					}
					else
					{
						ixuisprite.gameObject.SetActive(false);
						ixuilabel.gameObject.SetActive(true);
						ixuilabel.SetText(tittleNameByRank.Designation);
					}
					bool flag4 = firstPassRankInfo.InfoDataList.Count != 0;
					if (flag4)
					{
						Transform transform = t.FindChild("Labs");
						for (int i = 0; i < transform.childCount; i++)
						{
							bool flag5 = i >= firstPassRankInfo.InfoDataList.Count;
							if (flag5)
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

		// Token: 0x06009FC0 RID: 40896 RVA: 0x001A81B8 File Offset: 0x001A63B8
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

		// Token: 0x06009FC1 RID: 40897 RVA: 0x001A8280 File Offset: 0x001A6480
		private bool OnClosedClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06009FC2 RID: 40898 RVA: 0x001A829C File Offset: 0x001A649C
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

		// Token: 0x04003908 RID: 14600
		private IXUIButton m_closeBtn;

		// Token: 0x04003909 RID: 14601
		private IXUIWrapContent m_wrapContent;

		// Token: 0x0400390A RID: 14602
		private GameObject m_tipsGo;
	}
}
