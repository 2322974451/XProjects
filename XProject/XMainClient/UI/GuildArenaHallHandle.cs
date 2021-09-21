using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001834 RID: 6196
	internal class GuildArenaHallHandle : GVGHallBase
	{
		// Token: 0x17003934 RID: 14644
		// (get) Token: 0x0601016A RID: 65898 RVA: 0x003D771C File Offset: 0x003D591C
		protected override string FileName
		{
			get
			{
				return "Guild/GuildArena/HallFrame";
			}
		}

		// Token: 0x0601016B RID: 65899 RVA: 0x003D7734 File Offset: 0x003D5934
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool responseNow = this.m_responseNow;
			if (responseNow)
			{
				this.UpdateSignUpTime();
			}
		}

		// Token: 0x0601016C RID: 65900 RVA: 0x003D775C File Offset: 0x003D595C
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			this.m_Status = (base.PanelObject.transform.FindChild("Go/Status").GetComponent("XUILabel") as IXUILabel);
			this.m_SignUp = (base.PanelObject.transform.FindChild("Go/Btn_Go").GetComponent("XUIButton") as IXUIButton);
			this.m_SignUpLabel = (base.PanelObject.transform.FindChild("Go/Btn_Go/Go").GetComponent("XUILabel") as IXUILabel);
			this.SetupRewardList(XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("Guild_Arena_Award", XGlobalConfig.ListSeparator));
		}

		// Token: 0x0601016D RID: 65901 RVA: 0x003D781A File Offset: 0x003D5A1A
		protected override void OnShow()
		{
			base.OnShow();
			this.StackRefresh();
		}

		// Token: 0x0601016E RID: 65902 RVA: 0x003D782C File Offset: 0x003D5A2C
		protected override int GetContentSize()
		{
			return this._Doc.IntegralUnits.Count;
		}

		// Token: 0x0601016F RID: 65903 RVA: 0x003D784E File Offset: 0x003D5A4E
		public override void StackRefresh()
		{
			this._Doc.SendGetApplyGuildList();
			this.UpdateSignStatu();
		}

		// Token: 0x06010170 RID: 65904 RVA: 0x003D7864 File Offset: 0x003D5A64
		public override void RefreshData()
		{
			base.RefreshData();
			this.UpdateSignStatu();
		}

		// Token: 0x06010171 RID: 65905 RVA: 0x003D7878 File Offset: 0x003D5A78
		protected override void OnItemWrapUpdate(Transform t, int index)
		{
			IXUILabel ixuilabel = t.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUILabelSymbol ixuilabelSymbol = t.FindChild("GuildName").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel2 = t.FindChild("Score").GetComponent("XUILabel") as IXUILabel;
			bool flag = index == -1;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				ixuilabelSymbol.InputText = XStringDefineProxy.GetString("GUILD_ARENA_UNLAYOUT");
				ixuilabel2.SetText(string.Empty);
			}
			else
			{
				Integralunit integralunit = this._Doc.IntegralUnits[index];
				ixuilabel.SetText((index + 1).ToString());
				ixuilabelSymbol.InputText = integralunit.name;
				ixuilabel2.SetText(integralunit.guildscore.ToString());
				bool flag2 = integralunit.guildid == this.selfGuildID;
				if (flag2)
				{
					this.selfIndex = index;
				}
			}
		}

		// Token: 0x06010172 RID: 65906 RVA: 0x003D7978 File Offset: 0x003D5B78
		private void UpdateSignUpTime()
		{
			bool flag = this._Doc.RegistrationTime > 0.0;
			if (flag)
			{
				this.m_Status.SetText(XStringDefineProxy.GetString("GUILD_ARENA_SIGN_TIME", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this._Doc.RegistrationTime, 5)
				}));
			}
			else
			{
				this.m_Status.SetText(XStringDefineProxy.GetString("GUILD_ARENA_OVER"));
				this.UpdateSignStatu();
			}
		}

		// Token: 0x06010173 RID: 65907 RVA: 0x003D79FC File Offset: 0x003D5BFC
		private void UpdateSignStatu()
		{
			this.m_responseNow = false;
			bool flag = this._Doc.BattleStep == GuildArenaType.notopen;
			if (flag)
			{
				this.m_Status.SetText(XStringDefineProxy.GetString("GUILD_ARENA_UNOPEN"));
			}
			else
			{
				bool flag2 = this._Doc.BattleStep == GuildArenaType.resttime;
				if (flag2)
				{
					this.m_Status.SetText(XStringDefineProxy.GetString("GUILD_ARENA_OVER"));
				}
				else
				{
					bool flag3 = this._Doc.RegistrationTime > 0.0;
					if (flag3)
					{
						this.m_responseNow = true;
					}
					else
					{
						this.m_Status.SetText(XStringDefineProxy.GetString("GUILD_ARENA_OVER"));
					}
				}
			}
			bool flag4 = this._Doc.BattleStep == GuildArenaType.notopen || !this._Doc.RegistrationStatu;
			if (flag4)
			{
				this.m_SignUpLabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_SIGN_HAVE"));
			}
			else
			{
				this.m_SignUpLabel.SetText(XStringDefineProxy.GetString("GUILD_ARENA_SIGN_SHOW"));
			}
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag5 = specificDocument.Position == GuildPosition.GPOS_VICELEADER || specificDocument.Position == GuildPosition.GPOS_LEADER;
			this.m_SignUp.SetGrey(this._Doc.RegistrationStatu || (this._Doc.BattleStep == GuildArenaType.apply && flag5));
		}

		// Token: 0x06010174 RID: 65908 RVA: 0x003D7B4A File Offset: 0x003D5D4A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_SignUp.RegisterClickEventHandler(new ButtonClickEventHandler(this.RegistractionClick));
		}

		// Token: 0x06010175 RID: 65909 RVA: 0x003D7B6C File Offset: 0x003D5D6C
		private bool RegistractionClick(IXUIButton btn)
		{
			bool flag = this._Doc.BattleStep == GuildArenaType.notopen;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool registrationStatu = this._Doc.RegistrationStatu;
				if (registrationStatu)
				{
					bool flag2 = this._Doc.BattleStep == GuildArenaType.battlefinal;
					if (flag2)
					{
						DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.SelectTabIndex(GuildArenaTab.Combat);
					}
					else
					{
						DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.SelectTabIndex(GuildArenaTab.Duel);
					}
				}
				else
				{
					bool flag3 = this._Doc.BattleStep != GuildArenaType.apply;
					if (flag3)
					{
						return false;
					}
					bool flag4 = this._Doc.RegistrationTime > 0.0;
					if (flag4)
					{
						XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
						bool flag5 = specificDocument.CheckUnlockLevel(XSysDefine.XSys_GuildPvp);
						if (flag5)
						{
							bool flag6 = specificDocument.Position == GuildPosition.GPOS_VICELEADER || specificDocument.Position == GuildPosition.GPOS_LEADER;
							if (flag6)
							{
								this._Doc.SendApplyGuildArena();
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_ARENA_SIGN_PROFESSION"), "fece00");
							}
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_ARENA_SIGN_LOW_LEVEL"), "fece00");
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x040072C1 RID: 29377
		private XGuildArenaDocument _Doc;

		// Token: 0x040072C2 RID: 29378
		private IXUILabel m_Status;

		// Token: 0x040072C3 RID: 29379
		private IXUIButton m_SignUp;

		// Token: 0x040072C4 RID: 29380
		private IXUILabel m_SignUpLabel;

		// Token: 0x040072C5 RID: 29381
		private bool m_responseNow = false;
	}
}
