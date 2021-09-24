using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWorldBossEndRankView : DlgBase<XWorldBossEndRankView, XWorldBossEndRankBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/WorldBossEndRankDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_WorldBoss_EndRank);
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			this._Doc.WorldBossEndRankView = this;
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_DamageRankTab.bChecked = true;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_BtnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_BtnGoReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoRewardClick));
			base.uiBehaviour.m_DamageRankTab.ID = (ulong)((long)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.WorldBossDamageRank));
			base.uiBehaviour.m_DamageRankTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRankTabClicked));
			base.uiBehaviour.m_GuildRankTab.ID = (ulong)((long)XFastEnumIntEqualityComparer<RankeType>.ToInt(RankeType.WorldBossGuildRank));
			base.uiBehaviour.m_GuildRankTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRankTabClicked));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DamageRankWrapContentItemUpdated));
		}

		private bool OnRankTabClicked(IXUICheckBox checkbox)
		{
			bool flag = !checkbox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				this.m_CurrRankType = (RankeType)checkbox.ID;
				RankeType currRankType = this.m_CurrRankType;
				if (currRankType != RankeType.WorldBossGuildRank)
				{
					if (currRankType == RankeType.WorldBossDamageRank)
					{
						specificDocument.ReqWorldBossEnd();
					}
				}
				else
				{
					specificDocument.ReqRankData(this.m_CurrRankType, false);
				}
				result = true;
			}
			return result;
		}

		protected override void OnUnload()
		{
			this._Doc.WorldBossDescView = null;
			base.OnUnload();
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnGoRewardClick(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mail, 0UL);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public void RefreshDamageRank()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_RankTitle.SetText(XSingleton<XStringTable>.singleton.GetString("WORLDBOSS_RESULT_RANK_ROLE"));
				XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				List<WorldBossDamageInfo> endListDamage = specificDocument.EndListDamage;
				bool flag2 = endListDamage.Count == 0;
				if (flag2)
				{
					base.uiBehaviour.m_RankPanel_EmptyRank.gameObject.SetActive(true);
					base.uiBehaviour.m_RankPanel_EmptyRank.SetText(XStringDefineProxy.GetString("GUILD_BOSS_EMPTY_RANK"));
					base.uiBehaviour.m_WrapContent.gameObject.SetActive(false);
				}
				else
				{
					base.uiBehaviour.m_RankPanel_EmptyRank.gameObject.SetActive(false);
					base.uiBehaviour.m_WrapContent.gameObject.SetActive(true);
					base.uiBehaviour.m_WrapContent.SetContentCount(endListDamage.Count, false);
					base.uiBehaviour.m_ScrollView.ResetPosition();
				}
			}
		}

		public void RefreshGuildRank()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_RankTitle.SetText(XSingleton<XStringTable>.singleton.GetString("WORLDBOSS_RESULT_RANK_GUILD"));
				XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				List<XBaseRankInfo> rankList = specificDocument.GuildRankList.rankList;
				bool flag2 = rankList == null || rankList.Count == 0;
				if (flag2)
				{
					base.uiBehaviour.m_RankPanel_EmptyRank.gameObject.SetActive(true);
					base.uiBehaviour.m_RankPanel_EmptyRank.SetText(XStringDefineProxy.GetString("GUILD_BOSS_EMPTY_RANK"));
					base.uiBehaviour.m_WrapContent.gameObject.SetActive(false);
				}
				else
				{
					base.uiBehaviour.m_RankPanel_EmptyRank.gameObject.SetActive(false);
					base.uiBehaviour.m_WrapContent.gameObject.SetActive(true);
					base.uiBehaviour.m_WrapContent.SetContentCount(rankList.Count, false);
					base.uiBehaviour.m_ScrollView.ResetPosition();
				}
			}
		}

		private void DamageRankWrapContentItemUpdated(Transform t, int index)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				IXUISprite ixuisprite = t.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel2 = t.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
				float num = 0f;
				string inputText = "";
				bool flag2 = this.m_CurrRankType == RankeType.WorldBossDamageRank;
				if (flag2)
				{
					List<WorldBossDamageInfo> endListDamage = specificDocument.EndListDamage;
					bool flag3 = endListDamage == null;
					if (flag3)
					{
						return;
					}
					bool flag4 = index < 0 || index >= endListDamage.Count;
					if (flag4)
					{
						return;
					}
					WorldBossDamageInfo worldBossDamageInfo = endListDamage[index];
					bool flag5 = worldBossDamageInfo == null;
					if (flag5)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("XGuildDragonView.GuildRankWrapContentItemUpdated  is null ", null, null, null, null, null);
						return;
					}
					num = worldBossDamageInfo.damage;
					inputText = worldBossDamageInfo.rolename;
				}
				else
				{
					bool flag6 = this.m_CurrRankType == RankeType.WorldBossGuildRank;
					if (flag6)
					{
						List<XBaseRankInfo> rankList = specificDocument.GuildRankList.rankList;
						bool flag7 = rankList == null;
						if (flag7)
						{
							return;
						}
						bool flag8 = index < 0 || index >= rankList.Count;
						if (flag8)
						{
							return;
						}
						XBaseRankInfo xbaseRankInfo = rankList[index];
						bool flag9 = xbaseRankInfo == null;
						if (flag9)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("XGuildDragonView.GuildRankWrapContentItemUpdated  is null ", null, null, null, null, null);
							return;
						}
						num = xbaseRankInfo.value;
						inputText = xbaseRankInfo.name;
					}
				}
				ixuilabel2.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)num));
				ixuilabelSymbol.InputText = inputText;
				bool flag10 = index < 3;
				if (flag10)
				{
					ixuisprite.spriteName = string.Format("N{0}", index + 1);
					ixuisprite.SetVisible(true);
				}
				else
				{
					ixuisprite.SetVisible(false);
					ixuilabel.SetText((index + 1).ToString());
				}
			}
		}

		public void SetMyRankFrame()
		{
			GameObject myRank = base.uiBehaviour.m_MyRank;
			GameObject myOutOfRange = base.uiBehaviour.m_MyOutOfRange;
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			List<XBaseRankInfo> rankList = specificDocument.GuildRankList.rankList;
			bool flag = rankList != null && rankList.Count == 0;
			if (flag)
			{
				myOutOfRange.SetActive(false);
				myRank.SetActive(false);
			}
			else
			{
				bool flag2 = this.m_CurrRankType == RankeType.WorldBossGuildRank;
				if (flag2)
				{
					XGuildDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					bool flag3 = !specificDocument2.bInGuild;
					if (flag3)
					{
						myOutOfRange.SetActive(false);
						myRank.SetActive(false);
						return;
					}
				}
				bool flag4 = specificDocument.GuildRankList.myRankInfo == null;
				if (flag4)
				{
					myRank.SetActive(false);
				}
				else
				{
					myRank.SetActive(true);
					IXUISprite ixuisprite = myRank.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
					IXUILabelSymbol ixuilabelSymbol = myRank.transform.FindChild("Name").gameObject.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					IXUILabel ixuilabel = myRank.transform.FindChild("Value").gameObject.GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = myRank.transform.FindChild("Rank").gameObject.GetComponent("XUILabel") as IXUILabel;
					ixuilabelSymbol.InputText = specificDocument.GuildRankList.myRankInfo.name;
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion(specificDocument.GuildRankList.myRankInfo.value));
					bool flag5 = specificDocument.GuildRankList.myRankInfo.rank < 3U;
					if (flag5)
					{
						ixuisprite.spriteName = string.Format("N{0}", specificDocument.GuildRankList.myRankInfo.rank + 1U);
						ixuisprite.SetVisible(true);
					}
					else
					{
						ixuisprite.SetVisible(false);
						ixuilabel2.SetText((specificDocument.GuildRankList.myRankInfo.rank + 1U).ToString());
					}
					myOutOfRange.SetActive(specificDocument.GuildRankList.myRankInfo.rank == XRankDocument.INVALID_RANK);
				}
			}
		}

		public void SetMyRankFrame(WorldBossDamageInfo myInfo)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			GameObject myRank = base.uiBehaviour.m_MyRank;
			GameObject myOutOfRange = base.uiBehaviour.m_MyOutOfRange;
			List<WorldBossDamageInfo> endListDamage = specificDocument.EndListDamage;
			bool flag = endListDamage.Count == 0;
			if (flag)
			{
				myOutOfRange.SetActive(false);
				myRank.SetActive(false);
			}
			else
			{
				bool flag2 = myInfo == null;
				if (flag2)
				{
					myRank.SetActive(false);
				}
				else
				{
					myRank.SetActive(true);
					IXUISprite ixuisprite = myRank.transform.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
					IXUILabelSymbol ixuilabelSymbol = myRank.transform.FindChild("Name").gameObject.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					IXUILabel ixuilabel = myRank.transform.FindChild("Value").gameObject.GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = myRank.transform.FindChild("Rank").gameObject.GetComponent("XUILabel") as IXUILabel;
					ixuilabelSymbol.InputText = myInfo.rolename;
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)myInfo.damage));
					bool flag3 = myInfo.rank < 3U;
					if (flag3)
					{
						ixuisprite.spriteName = string.Format("N{0}", myInfo.rank + 1U);
						ixuisprite.SetVisible(true);
					}
					else
					{
						ixuisprite.SetVisible(false);
						ixuilabel2.SetText((myInfo.rank + 1U).ToString());
					}
					myOutOfRange.SetActive(myInfo.rank == XRankDocument.INVALID_RANK);
				}
			}
		}

		private XWorldBossDocument _Doc;

		private RankeType m_CurrRankType;
	}
}
