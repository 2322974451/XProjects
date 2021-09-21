using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C75 RID: 3189
	internal class BiochemicalHellDogRankView : DlgBase<BiochemicalHellDogRankView, BiochemicalHellDogRankBehaviour>
	{
		// Token: 0x170031EA RID: 12778
		// (get) Token: 0x0600B449 RID: 46153 RVA: 0x00233038 File Offset: 0x00231238
		public override string fileName
		{
			get
			{
				return "GameSystem/ThemeActivity/ThemeActivityRank";
			}
		}

		// Token: 0x0600B44A RID: 46154 RVA: 0x00233050 File Offset: 0x00231250
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<BiochemicalHellDogDocument>(BiochemicalHellDogDocument.uuID);
			base.uiBehaviour._RankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour._Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		// Token: 0x0600B44B RID: 46155 RVA: 0x002330AF File Offset: 0x002312AF
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.SendRankList();
		}

		// Token: 0x0600B44C RID: 46156 RVA: 0x002330C8 File Offset: 0x002312C8
		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B44D RID: 46157 RVA: 0x002330E4 File Offset: 0x002312E4
		private void FillDefault()
		{
			base.uiBehaviour._tipsGo.SetActive(true);
			base.uiBehaviour._RankWrapContent.gameObject.SetActive(false);
		}

		// Token: 0x0600B44E RID: 46158 RVA: 0x00233110 File Offset: 0x00231310
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

		// Token: 0x0600B44F RID: 46159 RVA: 0x002331F8 File Offset: 0x002313F8
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

		// Token: 0x0600B450 RID: 46160 RVA: 0x002334A4 File Offset: 0x002316A4
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

		// Token: 0x0600B451 RID: 46161 RVA: 0x0023356C File Offset: 0x0023176C
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

		// Token: 0x040045F0 RID: 17904
		private BiochemicalHellDogDocument _doc;
	}
}
