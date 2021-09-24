using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FirstPassRankView : DlgBase<FirstPassRankView, FitstpassRankBehaviour>
	{

		private FirstPassDocument m_doc
		{
			get
			{
				return FirstPassDocument.Doc;
			}
		}

		public override string fileName
		{
			get
			{
				return "OperatingActivity/FirstPassRank";
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

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosedClicked));
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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
			this.SetVisible(false, true);
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
	}
}
