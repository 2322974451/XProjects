using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQualifyingRecordsHandler : DlgHandlerBase
	{

		public uint MatchTotalCount
		{
			get
			{
				return this.WinCount + this.DrawCount + this.LoseCount;
			}
		}

		public uint MatchTotalPercent
		{
			get
			{
				bool flag = this.MatchTotalCount == 0U;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					bool flag2 = this.WinCount == 0U;
					if (flag2)
					{
						result = 0U;
					}
					else
					{
						result = Math.Max(1U, 100U * this.WinCount / this.MatchTotalCount);
					}
				}
				return result;
			}
		}

		protected override void Init()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RecordPool.SetupPool(base.transform.Find("Bg/Bg/ScrollView").gameObject, base.transform.Find("Bg/Bg/ScrollView/RecordTpl").gameObject, 20U, false);
			this.m_ScrollView = (base.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.MatchTotalWin = (base.transform.FindChild("Bg/Bg/Message/Win/Label").GetComponent("XUILabel") as IXUILabel);
			this.MatchTotalLose = (base.transform.FindChild("Bg/Bg/Message/Lose/Label").GetComponent("XUILabel") as IXUILabel);
			this.RateOfTotalWin = (base.transform.FindChild("Bg/Bg/Message/Rate/Label").GetComponent("XUILabel") as IXUILabel);
			this.MaxConsecutiveWin = (base.transform.FindChild("Bg/Bg/Message/ConsWin/Label").GetComponent("XUILabel") as IXUILabel);
			this.MaxConsecutiveLose = (base.transform.FindChild("Bg/Bg/Message/ConsLose/Label").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Bg/Message/WinRate");
			for (int i = 0; i < transform.childCount; i++)
			{
				IXUILabel item = transform.FindChild(string.Format("Rate{0}", i)).GetComponent("XUILabel") as IXUILabel;
				this.RateOfWinProf.Add(item);
			}
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/QualifyRecords";
			}
		}

		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public void Refresh()
		{
			bool flag = !base.PanelObject.activeSelf;
			if (flag)
			{
				base.SetVisible(true);
			}
			this.MatchTotalWin.SetText(this.WinCount.ToString());
			this.MatchTotalLose.SetText(this.LoseCount.ToString());
			this.RateOfTotalWin.SetText(this.MatchTotalPercent.ToString() + "%");
			this.MaxConsecutiveWin.SetText(this.ContinueWin.ToString());
			this.MaxConsecutiveLose.SetText(this.ContinueLose.ToString());
			for (int i = 0; i < this.RateOfWinProf.Count; i++)
			{
				bool flag2 = i >= XGame.RoleCount || i >= this.ProfessionWin.Count;
				if (flag2)
				{
					this.RateOfWinProf[i].gameObject.SetActive(false);
				}
				else
				{
					this.RateOfWinProf[i].gameObject.SetActive(true);
					this.RateOfWinProf[i].SetText(this.ProfessionWin[i].ToString() + "%");
				}
			}
			this.m_RecordPool.FakeReturnAll();
			for (int j = 0; j < this.GameRecords.Count; j++)
			{
				GameObject gameObject = this.m_RecordPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.FindChild("OpponentName").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Avatar").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = gameObject.transform.FindChild("Status").GetComponent("XUISprite") as IXUISprite;
				IXUILabelSymbol ixuilabelSymbol = gameObject.transform.FindChild("Reward").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				ixuilabel.SetText(this.GameRecords[j].name);
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)this.GameRecords[j].profession));
				switch (this.GameRecords[j].result)
				{
				case PkResultType.PkResult_Win:
					ixuisprite2.SetSprite("jjc-pws-win");
					break;
				case PkResultType.PkResult_Lose:
					ixuisprite2.SetSprite("jjc-pws-lose");
					break;
				case PkResultType.PkResult_Draw:
					ixuisprite2.SetSprite("jjc-pws-draw");
					break;
				}
				ixuilabelSymbol.InputText = XStringDefineProxy.GetString("MATCH_RECORDS_REWARD", new object[]
				{
					(this.GameRecords[j].point < 0) ? "" : "+",
					this.GameRecords[j].point,
					XLabelSymbolHelper.FormatSmallIcon(21),
					this.GameRecords[j].honorpoint
				});
				gameObject.transform.localPosition = this.m_RecordPool.TplPos - new Vector3(0f, (float)(j * this.m_RecordPool.TplHeight));
			}
			this.m_RecordPool.ActualReturnAll(false);
			this.m_ScrollView.ResetPosition();
		}

		private bool OnCloseClicked(IXUIButton button)
		{
			base.SetVisible(false);
			return true;
		}

		public uint WinCount;

		public uint DrawCount;

		public uint LoseCount;

		public uint ContinueWin;

		public uint ContinueLose;

		public List<uint> ProfessionWin = new List<uint>();

		public List<PkOneRecord> GameRecords = new List<PkOneRecord>();

		public XUIPool m_RecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_Close;

		public IXUIScrollView m_ScrollView;

		public IXUILabel MatchTotalWin;

		public IXUILabel MatchTotalLose;

		public IXUILabel RateOfTotalWin;

		public IXUILabel MaxConsecutiveWin;

		public IXUILabel MaxConsecutiveLose;

		public List<IXUILabel> RateOfWinProf = new List<IXUILabel>();
	}
}
