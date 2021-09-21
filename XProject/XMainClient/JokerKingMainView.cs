using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C0F RID: 3087
	internal class JokerKingMainView : DlgBase<JokerKingMainView, JokerKingMainBehavior>
	{
		// Token: 0x170030E9 RID: 12521
		// (get) Token: 0x0600AF47 RID: 44871 RVA: 0x00212C20 File Offset: 0x00210E20
		public override string fileName
		{
			get
			{
				return "OperatingActivity/JokerkingMain";
			}
		}

		// Token: 0x170030EA RID: 12522
		// (get) Token: 0x0600AF48 RID: 44872 RVA: 0x00212C38 File Offset: 0x00210E38
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AF49 RID: 44873 RVA: 0x00212C4C File Offset: 0x00210E4C
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnItemUpdateWrapUpdate));
			base.uiBehaviour.m_RankList.gameObject.SetActive(false);
			base.uiBehaviour.m_IntroText.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("KINGOFPOKER")));
		}

		// Token: 0x0600AF4A RID: 44874 RVA: 0x00212CCC File Offset: 0x00210ECC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickHandler));
			base.uiBehaviour.m_BtnGo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGo));
			base.uiBehaviour.m_BtnDisable.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickJoin));
			base.uiBehaviour.m_BtnRankReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRankReward));
			base.uiBehaviour.m_BtnRankSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickRankRewardClose));
		}

		// Token: 0x0600AF4B RID: 44875 RVA: 0x00212D72 File Offset: 0x00210F72
		protected override void OnShow()
		{
			base.OnShow();
			this.InitRewardList();
			this._Doc.JokerKingMatchQuery();
		}

		// Token: 0x0600AF4C RID: 44876 RVA: 0x00212D90 File Offset: 0x00210F90
		public void RefreshData()
		{
			bool flag = this._Doc.MatchState == CardMatchState.CardMatch_StateDummy;
			if (flag)
			{
				bool isSignUp = this._Doc.IsSignUp;
				if (isSignUp)
				{
					this.SignMatching();
				}
				else
				{
					this.SignBegioning();
				}
			}
			else
			{
				this.SignJoin();
			}
		}

		// Token: 0x0600AF4D RID: 44877 RVA: 0x00212DDC File Offset: 0x00210FDC
		private void SignJoin()
		{
			base.uiBehaviour.m_info.SetText(string.Empty);
			base.uiBehaviour.m_BtnGo.SetVisible(false);
			base.uiBehaviour.m_Matching.gameObject.SetActive(false);
			base.uiBehaviour.m_BtnDisable.SetVisible(true);
		}

		// Token: 0x0600AF4E RID: 44878 RVA: 0x00212E3C File Offset: 0x0021103C
		private void UnSignBegion()
		{
			base.uiBehaviour.m_info.SetText(XStringDefineProxy.GetString("JOKERKING_SIGN_NOT_BEGION"));
			base.uiBehaviour.m_BtnGo.SetVisible(false);
			base.uiBehaviour.m_Matching.gameObject.SetActive(false);
			base.uiBehaviour.m_BtnDisable.SetVisible(false);
		}

		// Token: 0x0600AF4F RID: 44879 RVA: 0x00212EA0 File Offset: 0x002110A0
		private void SignBegioning()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("PokerTournamentSignUpNum");
			base.uiBehaviour.m_info.SetText(XStringDefineProxy.GetString("JOKERKING_SIGN_BEGION", new object[]
			{
				(long)@int - (long)((ulong)this._Doc.JokerKingTimes),
				@int
			}));
			base.uiBehaviour.m_BtnGo.SetVisible(true);
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("PokerTournamentSignUpCost", true);
			base.uiBehaviour.m_LabelSymbol.InputText = XStringDefineProxy.GetString("JOKERKING_SIGN_UP", new object[]
			{
				XLabelSymbolHelper.FormatCostWithIcon(sequenceList[0, 1], ItemEnum.DRAGON_COIN)
			});
			base.uiBehaviour.m_Matching.gameObject.SetActive(false);
			base.uiBehaviour.m_BtnDisable.SetVisible(false);
		}

		// Token: 0x0600AF50 RID: 44880 RVA: 0x00212F80 File Offset: 0x00211180
		private void SignMatching()
		{
			base.uiBehaviour.m_info.SetText(string.Empty);
			base.uiBehaviour.m_BtnGo.SetVisible(false);
			base.uiBehaviour.m_Matching.gameObject.SetActive(true);
			base.uiBehaviour.m_BtnDisable.SetVisible(false);
		}

		// Token: 0x0600AF51 RID: 44881 RVA: 0x00212FE0 File Offset: 0x002111E0
		private bool OnClickGo(IXUIButton btn)
		{
			this._Doc.JokerKingMatchSignUp();
			return true;
		}

		// Token: 0x0600AF52 RID: 44882 RVA: 0x00213000 File Offset: 0x00211200
		private bool OnClickJoin(IXUIButton btn)
		{
			this._Doc.JokerKingMatchAdd();
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AF53 RID: 44883 RVA: 0x00213028 File Offset: 0x00211228
		private bool OnClickHandler(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AF54 RID: 44884 RVA: 0x00213044 File Offset: 0x00211244
		private bool OnClickRankReward(IXUIButton btn)
		{
			base.uiBehaviour.m_RankList.gameObject.SetActive(true);
			this.SetItemListRewardList();
			return true;
		}

		// Token: 0x0600AF55 RID: 44885 RVA: 0x00213075 File Offset: 0x00211275
		private void OnClickRankRewardClose(IXUISprite sprite)
		{
			base.uiBehaviour.m_RankList.gameObject.SetActive(false);
		}

		// Token: 0x0600AF56 RID: 44886 RVA: 0x0021308F File Offset: 0x0021128F
		private void SetItemListRewardList()
		{
			base.uiBehaviour.m_WrapContent.SetContentCount(this.Tournaments.Length, false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		// Token: 0x170030EB RID: 12523
		// (get) Token: 0x0600AF57 RID: 44887 RVA: 0x002130C0 File Offset: 0x002112C0
		private PokerTournamentReward.RowData[] Tournaments
		{
			get
			{
				return XJokerKingDocument.JokerTournamed.Table;
			}
		}

		// Token: 0x0600AF58 RID: 44888 RVA: 0x002130DC File Offset: 0x002112DC
		private void OnItemUpdateWrapUpdate(Transform t, int index)
		{
			bool flag = index >= this.Tournaments.Length;
			if (!flag)
			{
				IXUILabel ixuilabel = t.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
				PokerTournamentReward.RowData rowData = this.Tournaments[index];
				bool flag2 = rowData.Rank[0] == rowData.Rank[1];
				if (flag2)
				{
					bool flag3 = rowData.Rank[0] <= 3U;
					if (flag3)
					{
						ixuisprite.SetSprite(string.Format("N{0}", rowData.Rank[0]));
						ixuisprite.SetVisible(true);
						ixuilabel.SetVisible(false);
					}
					else
					{
						ixuisprite.SetVisible(false);
						ixuilabel.SetVisible(true);
						ixuilabel.SetText(string.Format("No.", rowData.Rank[0]));
					}
				}
				else
				{
					ixuisprite.SetVisible(false);
					ixuilabel.SetVisible(true);
					ixuilabel.SetText(string.Format("{0}-{1}", rowData.Rank[0], rowData.Rank[1]));
				}
				for (int i = 0; i < 4; i++)
				{
					Transform transform = t.FindChild(XSingleton<XCommon>.singleton.StringCombine("Grid/Item", i.ToString()));
					bool flag4 = i < rowData.Reward.Count;
					if (flag4)
					{
						transform.gameObject.SetActive(true);
						uint num = rowData.Reward[i, 0];
						uint itemCount = rowData.Reward[i, 1];
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)num);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform.gameObject, itemConf, (int)itemCount, false);
						IXUISprite ixuisprite2 = transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.ID = (ulong)num;
						ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					}
					else
					{
						transform.gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600AF59 RID: 44889 RVA: 0x0021332C File Offset: 0x0021152C
		private void InitRewardList()
		{
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("PokerTournamentReward", XGlobalConfig.ListSeparator);
			int num = andSeparateValue.Length;
			base.uiBehaviour.m_RewardPool.ReturnAll(false);
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardPool.FetchGameObject(false);
				gameObject.transform.parent = base.uiBehaviour.m_Reward;
				gameObject.transform.localPosition = new Vector3((float)(i * 90), 0f);
				int num2 = int.Parse(andSeparateValue[i]);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, num2, 0, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = gameObject.transform.FindChild("Icon/Num").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Empty);
				ixuisprite.ID = (ulong)((long)num2);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		// Token: 0x040042CE RID: 17102
		private XJokerKingDocument _Doc;
	}
}
