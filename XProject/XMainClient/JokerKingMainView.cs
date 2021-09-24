using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class JokerKingMainView : DlgBase<JokerKingMainView, JokerKingMainBehavior>
	{

		public override string fileName
		{
			get
			{
				return "OperatingActivity/JokerkingMain";
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnItemUpdateWrapUpdate));
			base.uiBehaviour.m_RankList.gameObject.SetActive(false);
			base.uiBehaviour.m_IntroText.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("KINGOFPOKER")));
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickHandler));
			base.uiBehaviour.m_BtnGo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGo));
			base.uiBehaviour.m_BtnDisable.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickJoin));
			base.uiBehaviour.m_BtnRankReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRankReward));
			base.uiBehaviour.m_BtnRankSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickRankRewardClose));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.InitRewardList();
			this._Doc.JokerKingMatchQuery();
		}

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

		private void SignJoin()
		{
			base.uiBehaviour.m_info.SetText(string.Empty);
			base.uiBehaviour.m_BtnGo.SetVisible(false);
			base.uiBehaviour.m_Matching.gameObject.SetActive(false);
			base.uiBehaviour.m_BtnDisable.SetVisible(true);
		}

		private void UnSignBegion()
		{
			base.uiBehaviour.m_info.SetText(XStringDefineProxy.GetString("JOKERKING_SIGN_NOT_BEGION"));
			base.uiBehaviour.m_BtnGo.SetVisible(false);
			base.uiBehaviour.m_Matching.gameObject.SetActive(false);
			base.uiBehaviour.m_BtnDisable.SetVisible(false);
		}

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

		private void SignMatching()
		{
			base.uiBehaviour.m_info.SetText(string.Empty);
			base.uiBehaviour.m_BtnGo.SetVisible(false);
			base.uiBehaviour.m_Matching.gameObject.SetActive(true);
			base.uiBehaviour.m_BtnDisable.SetVisible(false);
		}

		private bool OnClickGo(IXUIButton btn)
		{
			this._Doc.JokerKingMatchSignUp();
			return true;
		}

		private bool OnClickJoin(IXUIButton btn)
		{
			this._Doc.JokerKingMatchAdd();
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnClickHandler(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnClickRankReward(IXUIButton btn)
		{
			base.uiBehaviour.m_RankList.gameObject.SetActive(true);
			this.SetItemListRewardList();
			return true;
		}

		private void OnClickRankRewardClose(IXUISprite sprite)
		{
			base.uiBehaviour.m_RankList.gameObject.SetActive(false);
		}

		private void SetItemListRewardList()
		{
			base.uiBehaviour.m_WrapContent.SetContentCount(this.Tournaments.Length, false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		private PokerTournamentReward.RowData[] Tournaments
		{
			get
			{
				return XJokerKingDocument.JokerTournamed.Table;
			}
		}

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

		private XJokerKingDocument _Doc;
	}
}
