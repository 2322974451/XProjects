using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C7E RID: 3198
	internal class XQualifyingRecordsHandler : DlgHandlerBase
	{
		// Token: 0x170031FC RID: 12796
		// (get) Token: 0x0600B4AD RID: 46253 RVA: 0x0023618C File Offset: 0x0023438C
		public uint MatchTotalCount
		{
			get
			{
				return this.WinCount + this.DrawCount + this.LoseCount;
			}
		}

		// Token: 0x170031FD RID: 12797
		// (get) Token: 0x0600B4AE RID: 46254 RVA: 0x002361B4 File Offset: 0x002343B4
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

		// Token: 0x0600B4AF RID: 46255 RVA: 0x00236200 File Offset: 0x00234400
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

		// Token: 0x170031FE RID: 12798
		// (get) Token: 0x0600B4B0 RID: 46256 RVA: 0x002363A8 File Offset: 0x002345A8
		protected override string FileName
		{
			get
			{
				return "GameSystem/QualifyRecords";
			}
		}

		// Token: 0x0600B4B1 RID: 46257 RVA: 0x002363BF File Offset: 0x002345BF
		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B4B2 RID: 46258 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600B4B3 RID: 46259 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B4B4 RID: 46260 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B4B5 RID: 46261 RVA: 0x002363DC File Offset: 0x002345DC
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

		// Token: 0x0600B4B6 RID: 46262 RVA: 0x00236758 File Offset: 0x00234958
		private bool OnCloseClicked(IXUIButton button)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0400462C RID: 17964
		public uint WinCount;

		// Token: 0x0400462D RID: 17965
		public uint DrawCount;

		// Token: 0x0400462E RID: 17966
		public uint LoseCount;

		// Token: 0x0400462F RID: 17967
		public uint ContinueWin;

		// Token: 0x04004630 RID: 17968
		public uint ContinueLose;

		// Token: 0x04004631 RID: 17969
		public List<uint> ProfessionWin = new List<uint>();

		// Token: 0x04004632 RID: 17970
		public List<PkOneRecord> GameRecords = new List<PkOneRecord>();

		// Token: 0x04004633 RID: 17971
		public XUIPool m_RecordPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004634 RID: 17972
		public IXUIButton m_Close;

		// Token: 0x04004635 RID: 17973
		public IXUIScrollView m_ScrollView;

		// Token: 0x04004636 RID: 17974
		public IXUILabel MatchTotalWin;

		// Token: 0x04004637 RID: 17975
		public IXUILabel MatchTotalLose;

		// Token: 0x04004638 RID: 17976
		public IXUILabel RateOfTotalWin;

		// Token: 0x04004639 RID: 17977
		public IXUILabel MaxConsecutiveWin;

		// Token: 0x0400463A RID: 17978
		public IXUILabel MaxConsecutiveLose;

		// Token: 0x0400463B RID: 17979
		public List<IXUILabel> RateOfWinProf = new List<IXUILabel>();
	}
}
