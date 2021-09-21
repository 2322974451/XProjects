using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C16 RID: 3094
	internal class GuildMineRewardView : DlgBase<GuildMineRewardView, GuildMineRewardBehaviour>
	{
		// Token: 0x170030F6 RID: 12534
		// (get) Token: 0x0600AFA9 RID: 44969 RVA: 0x00215858 File Offset: 0x00213A58
		public override string fileName
		{
			get
			{
				return "Guild/GuildMine/GuildMineResult";
			}
		}

		// Token: 0x170030F7 RID: 12535
		// (get) Token: 0x0600AFAA RID: 44970 RVA: 0x00215870 File Offset: 0x00213A70
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030F8 RID: 12536
		// (get) Token: 0x0600AFAB RID: 44971 RVA: 0x00215884 File Offset: 0x00213A84
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030F9 RID: 12537
		// (get) Token: 0x0600AFAC RID: 44972 RVA: 0x00215898 File Offset: 0x00213A98
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030FA RID: 12538
		// (get) Token: 0x0600AFAD RID: 44973 RVA: 0x002158AC File Offset: 0x00213AAC
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030FB RID: 12539
		// (get) Token: 0x0600AFAE RID: 44974 RVA: 0x002158C0 File Offset: 0x00213AC0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030FC RID: 12540
		// (get) Token: 0x0600AFAF RID: 44975 RVA: 0x002158D4 File Offset: 0x00213AD4
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildMine);
			}
		}

		// Token: 0x0600AFB0 RID: 44976 RVA: 0x002158ED File Offset: 0x00213AED
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
			DlgHandlerBase.EnsureCreate<GuildMineRankHandler>(ref this.m_rankHanler, base.uiBehaviour.m_Bg, false, this);
		}

		// Token: 0x0600AFB1 RID: 44977 RVA: 0x0021591C File Offset: 0x00213B1C
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_Rank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClicked));
		}

		// Token: 0x0600AFB2 RID: 44978 RVA: 0x00215984 File Offset: 0x00213B84
		public bool OnCloseClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureUnload<GuildMineRankHandler>(ref this.m_rankHanler);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AFB3 RID: 44979 RVA: 0x002159AC File Offset: 0x00213BAC
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildMine);
			return true;
		}

		// Token: 0x0600AFB4 RID: 44980 RVA: 0x002159CC File Offset: 0x00213BCC
		private bool OnRankClicked(IXUIButton btn)
		{
			this.m_rankHanler.SetVisible(true);
			return true;
		}

		// Token: 0x0600AFB5 RID: 44981 RVA: 0x002159EC File Offset: 0x00213BEC
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600AFB6 RID: 44982 RVA: 0x002159F6 File Offset: 0x00213BF6
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600AFB7 RID: 44983 RVA: 0x00215A00 File Offset: 0x00213C00
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600AFB8 RID: 44984 RVA: 0x00215A0C File Offset: 0x00213C0C
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

		// Token: 0x0600AFB9 RID: 44985 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x0400430A RID: 17162
		private XGuildMineMainDocument doc = null;

		// Token: 0x0400430B RID: 17163
		private GuildMineRankHandler m_rankHanler;
	}
}
