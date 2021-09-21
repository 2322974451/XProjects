using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CF9 RID: 3321
	internal class FirstPassRankView : DlgBase<FirstPassRankView, FitstpassRankBehaviour>
	{
		// Token: 0x170032A4 RID: 12964
		// (get) Token: 0x0600B9AD RID: 47533 RVA: 0x0025C258 File Offset: 0x0025A458
		private FirstPassDocument m_doc
		{
			get
			{
				return FirstPassDocument.Doc;
			}
		}

		// Token: 0x170032A5 RID: 12965
		// (get) Token: 0x0600B9AE RID: 47534 RVA: 0x0025C270 File Offset: 0x0025A470
		public override string fileName
		{
			get
			{
				return "OperatingActivity/FirstPassRank";
			}
		}

		// Token: 0x170032A6 RID: 12966
		// (get) Token: 0x0600B9AF RID: 47535 RVA: 0x0025C288 File Offset: 0x0025A488
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170032A7 RID: 12967
		// (get) Token: 0x0600B9B0 RID: 47536 RVA: 0x0025C29C File Offset: 0x0025A49C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170032A8 RID: 12968
		// (get) Token: 0x0600B9B1 RID: 47537 RVA: 0x0025C2B0 File Offset: 0x0025A4B0
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600B9B2 RID: 47538 RVA: 0x0025C2C3 File Offset: 0x0025A4C3
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600B9B3 RID: 47539 RVA: 0x0025C2CD File Offset: 0x0025A4CD
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosedClicked));
		}

		// Token: 0x0600B9B4 RID: 47540 RVA: 0x0025C2F4 File Offset: 0x0025A4F4
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B9B5 RID: 47541 RVA: 0x0025C2FE File Offset: 0x0025A4FE
		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600B9B6 RID: 47542 RVA: 0x0025C325 File Offset: 0x0025A525
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B9B7 RID: 47543 RVA: 0x0025C330 File Offset: 0x0025A530
		protected override void OnShow()
		{
			base.OnShow();
			this.FillDefault();
			bool flag = this.m_doc.CurData != null;
			if (flag)
			{
				this.m_doc.ReqRankList(this.m_doc.CurData.Id);
			}
		}

		// Token: 0x0600B9B8 RID: 47544 RVA: 0x0025C37A File Offset: 0x0025A57A
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600B9B9 RID: 47545 RVA: 0x0025C384 File Offset: 0x0025A584
		private void FillDefault()
		{
			bool flag = this.m_doc.CurData != null;
			if (flag)
			{
				base.uiBehaviour.m_tittleLab.SetText(string.Format(XStringDefineProxy.GetString("FirstPassTittle"), this.m_doc.CurData.FirstPassRow.RankTittle));
			}
			else
			{
				base.uiBehaviour.m_tittleLab.SetText(string.Empty);
			}
			base.uiBehaviour.m_tipsGo.SetActive(true);
			base.uiBehaviour.m_wrapContent.gameObject.SetActive(false);
		}

		// Token: 0x0600B9BA RID: 47546 RVA: 0x0025C41C File Offset: 0x0025A61C
		public void FillContent()
		{
			bool flag = this.m_doc.RankList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fail to get rank list whose type is ", RankeType.FirstPassRank.ToString(), null, null, null, null);
			}
			else
			{
				bool flag2 = this.m_doc.CurData != null && this.m_doc.CurData.FirstPassRow != null;
				if (flag2)
				{
					base.uiBehaviour.m_needHideTittleGo.SetActive(this.m_doc.CurData.FirstPassRow.NestType > 0U);
				}
				bool flag3 = this.m_doc.RankList.InfoList == null || this.m_doc.RankList.InfoList.Count == 0;
				if (flag3)
				{
					base.uiBehaviour.m_tipsGo.SetActive(true);
					base.uiBehaviour.m_wrapContent.gameObject.SetActive(false);
				}
				else
				{
					base.uiBehaviour.m_tipsGo.SetActive(false);
					base.uiBehaviour.m_wrapContent.gameObject.SetActive(true);
					int count = this.m_doc.RankList.InfoList.Count;
					base.uiBehaviour.m_wrapContent.SetContentCount(count, false);
				}
			}
		}

		// Token: 0x0600B9BB RID: 47547 RVA: 0x0025C568 File Offset: 0x0025A768
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
					bool flag3 = firstPassRankInfo == null;
					if (!flag3)
					{
						IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(firstPassRankInfo.PassTimeStr.Replace("/n", "\n"));
						ixuilabel = (t.FindChild("Image/Rank").GetComponent("XUILabel") as IXUILabel);
						ixuilabel.SetText(firstPassRankInfo.StarNum.ToString());
						bool flag4 = this.m_doc.CurData != null && this.m_doc.CurData.FirstPassRow != null;
						if (flag4)
						{
							t.FindChild("Image").gameObject.SetActive(this.m_doc.CurData.FirstPassRow.NestType > 0U);
						}
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
		}

		// Token: 0x0600B9BC RID: 47548 RVA: 0x0025C7C8 File Offset: 0x0025A9C8
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

		// Token: 0x0600B9BD RID: 47549 RVA: 0x0025C890 File Offset: 0x0025AA90
		private bool OnClosedClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600B9BE RID: 47550 RVA: 0x0025C8AC File Offset: 0x0025AAAC
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
	}
}
