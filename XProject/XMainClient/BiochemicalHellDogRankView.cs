using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BiochemicalHellDogRankView : DlgBase<BiochemicalHellDogRankView, BiochemicalHellDogRankBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ThemeActivity/ThemeActivityRank";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<BiochemicalHellDogDocument>(BiochemicalHellDogDocument.uuID);
			base.uiBehaviour._RankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour._Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.SendRankList();
		}

		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private void FillDefault()
		{
			base.uiBehaviour._tipsGo.SetActive(true);
			base.uiBehaviour._RankWrapContent.gameObject.SetActive(false);
		}

		public void FillContent()
		{
			bool flag = this._doc.RankList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", RankeType.FirstPassRank.ToString(), null, null, null, null);
			}
			else
			{
				bool flag2 = this._doc.RankList.InfoList == null || this._doc.RankList.InfoList.Count == 0;
				if (flag2)
				{
					this.FillDefault();
				}
				else
				{
					base.uiBehaviour._tipsGo.SetActive(false);
					base.uiBehaviour._RankWrapContent.gameObject.SetActive(true);
					int count = this._doc.RankList.InfoList.Count;
					base.uiBehaviour._RankWrapContent.SetContentCount(count, false);
					base.uiBehaviour._RankScrollView.ResetPosition();
				}
			}
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this._doc.RankList.InfoList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", RankeType.FirstPassRank.ToString(), null, null, null, null);
			}
			else
			{
				bool flag2 = index >= this._doc.RankList.InfoList.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("index >= rankDataList.rankList.Count", null, null, null, null, null);
				}
				else
				{
					FirstPassRankInfo firstPassRankInfo = this._doc.RankList.InfoList[index];
					IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(firstPassRankInfo.PassTimeStr.Replace("/n", "\n"));
					ixuilabel = (t.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
					IXUISprite ixuisprite = t.Find("TitleTex").GetComponent("XUISprite") as IXUISprite;
					DesignationTable.RowData tittleNameByRank = this._doc.GetTittleNameByRank(index + 1);
					bool flag3 = tittleNameByRank == null;
					if (flag3)
					{
						ixuilabel.SetText("");
						ixuisprite.SetAlpha(0f);
					}
					else
					{
						bool flag4 = string.IsNullOrEmpty(tittleNameByRank.Effect) || string.IsNullOrEmpty(tittleNameByRank.Atlas);
						if (flag4)
						{
							ixuilabel.SetText(tittleNameByRank.Designation);
							ixuisprite.SetAlpha(0f);
						}
						else
						{
							ixuisprite.SetAlpha(1f);
							ixuisprite.SetSprite(tittleNameByRank.Effect, tittleNameByRank.Atlas, false);
							ixuilabel.SetText("");
						}
					}
					ixuisprite.MakePixelPerfect();
					bool flag5 = firstPassRankInfo.InfoDataList.Count != 0;
					if (flag5)
					{
						Transform transform = t.FindChild("Labs");
						for (int i = 0; i < transform.childCount; i++)
						{
							bool flag6 = i >= firstPassRankInfo.InfoDataList.Count;
							if (flag6)
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

		private void OnClickName(IXUILabelSymbol iSp)
		{
			bool flag = this._doc.RankList.InfoList == null;
			if (!flag)
			{
				int index = (int)iSp.ID / 100;
				FirstPassRankInfo firstPassRankInfo = this._doc.RankList.InfoList[index];
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

		private BiochemicalHellDogDocument _doc;
	}
}
