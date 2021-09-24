using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CompeteNestRankHandler : DlgHandlerBase
	{

		private XCompeteDocument m_doc
		{
			get
			{
				return XCompeteDocument.Doc;
			}
		}

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/CompeteNestRankDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.FindChild("Panel");
			this.m_wrapContent = (transform.FindChild("FourNameList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_tipsGo = base.PanelObject.transform.FindChild("Panel/Tips").gameObject;
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillDefault();
			this.m_doc.ReqRankList();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosedClicked));
		}

		private void FillDefault()
		{
			this.m_tipsGo.SetActive(true);
			this.m_wrapContent.gameObject.SetActive(false);
		}

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

		private bool OnClosedClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

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

		private IXUIButton m_closeBtn;

		private IXUIWrapContent m_wrapContent;

		private GameObject m_tipsGo;
	}
}
