using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildMineRewardView : DlgBase<GuildMineRewardView, GuildMineRewardBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildMine/GuildMineResult";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildMine);
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			DlgHandlerBase.EnsureCreate<GuildMineRankHandler>(ref this.m_rankHanler, base.uiBehaviour.m_Bg, false, this);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Rank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureUnload<GuildMineRankHandler>(ref this.m_rankHanler);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildMine);
			return true;
		}

		private bool OnRankClicked(IXUIButton btn)
		{
			this.m_rankHanler.SetVisible(true);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public void SetRewardInfo(QueryResWarRes res)
		{
			bool flag = res.finalrank == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("data is null", null, null, null, null, null);
			}
			else
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
				if (!flag2)
				{
					DlgBase<GuildMineRewardView, GuildMineRewardBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.HideChatMini();
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					uint num = 0U;
					for (int i = 0; i < res.finalrank.data.Count; i++)
					{
						num = Math.Max(res.finalrank.data[i].res, num);
					}
					base.uiBehaviour.m_Win.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("GUILD_MINE_WIN"), res.finalrank.data[0].guildname));
					base.uiBehaviour.m_GuildPool.FakeReturnAll();
					int num2 = 0;
					while ((long)num2 < (long)((ulong)XGuildMineMainDocument.GUILD_NUM_MAX))
					{
						bool flag3 = num2 >= res.finalrank.data.Count;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("GuildCount:" + res.finalrank.data.Count, null, null, null, null, null);
							break;
						}
						GameObject gameObject = base.uiBehaviour.m_GuildPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num2 * base.uiBehaviour.m_GuildPool.TplWidth), 0f);
						bool flag4 = specificDocument.UID == res.finalrank.data[num2].guildid;
						IXUILabel ixuilabel;
						if (flag4)
						{
							gameObject.transform.Find("GuildInfo/GuildName/OtherGuild").gameObject.SetActive(false);
							ixuilabel = (gameObject.transform.Find("GuildInfo/GuildName/MyGuild").GetComponent("XUILabel") as IXUILabel);
							gameObject.transform.Find("Bg/MyGuild").gameObject.SetActive(true);
						}
						else
						{
							gameObject.transform.Find("GuildInfo/GuildName/MyGuild").gameObject.SetActive(false);
							ixuilabel = (gameObject.transform.Find("GuildInfo/GuildName/OtherGuild").GetComponent("XUILabel") as IXUILabel);
							gameObject.transform.Find("Bg/MyGuild").gameObject.SetActive(false);
						}
						ixuilabel.SetText(res.finalrank.data[num2].guildname);
						IXUILabel ixuilabel2 = gameObject.transform.Find("GuildInfo/MineNum").GetComponent("XUILabel") as IXUILabel;
						ixuilabel2.SetText(res.finalrank.data[num2].res.ToString());
						IXUISprite ixuisprite = gameObject.transform.Find("GuildInfo/Logo").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetSprite(XGuildDocument.GetPortraitName((int)res.finalrank.data[num2].guildicon));
						IXUISlider ixuislider = gameObject.transform.Find("GuildInfo/Slider").GetComponent("XUISlider") as IXUISlider;
						bool flag5 = num > 0U;
						if (flag5)
						{
							ixuislider.Value = res.finalrank.data[num2].res / num;
						}
						else
						{
							ixuislider.Value = 0f;
						}
						IXUISprite ixuisprite2 = gameObject.transform.Find("Rank").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.SetSprite(string.Format("N{0}", num2 + 1));
						XUIPool xuipool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
						Transform transform = gameObject.transform.FindChild("Reward/RewardTpl");
						xuipool.SetupPool(null, transform.gameObject, 3U, false);
						xuipool.FakeReturnAll();
						GuildMineralBattleReward.RowData reward = XGuildMineBattleDocument.GetReward((uint)(num2 + 1));
						bool flag6 = reward != null;
						if (flag6)
						{
							for (int j = 0; j < reward.RewardShow.Count; j++)
							{
								GameObject gameObject2 = xuipool.FetchGameObject(false);
								gameObject2.transform.localPosition = new Vector3((float)(j * xuipool.TplWidth), 0f, 0f);
								int num3 = reward.RewardShow[j, 0];
								int itemCount = reward.RewardShow[j, 1];
								XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, num3, itemCount, false);
								IXUISprite ixuisprite3 = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
								ixuisprite3.ID = (ulong)((long)num3);
								ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
							}
						}
						xuipool.ActualReturnAll(false);
						num2++;
					}
					base.uiBehaviour.m_GuildPool.ActualReturnAll(false);
				}
			}
		}

		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		private XGuildMineMainDocument doc = null;

		private GuildMineRankHandler m_rankHanler;
	}
}
