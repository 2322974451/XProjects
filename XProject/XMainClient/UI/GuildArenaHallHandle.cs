using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildArenaHallHandle : GVGHallBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/GuildArena/HallFrame";
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool responseNow = this.m_responseNow;
			if (responseNow)
			{
				this.UpdateSignUpTime();
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			this.m_Status = (base.PanelObject.transform.FindChild("Go/Status").GetComponent("XUILabel") as IXUILabel);
			this.m_SignUp = (base.PanelObject.transform.FindChild("Go/Btn_Go").GetComponent("XUIButton") as IXUIButton);
			this.m_SignUpLabel = (base.PanelObject.transform.FindChild("Go/Btn_Go/Go").GetComponent("XUILabel") as IXUILabel);
			this.SetupRewardList(XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("Guild_Arena_Award", XGlobalConfig.ListSeparator));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.StackRefresh();
		}

		protected override int GetContentSize()
		{
			return this._Doc.IntegralUnits.Count;
		}

		public override void StackRefresh()
		{
			this._Doc.SendGetApplyGuildList();
			this.UpdateSignStatu();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.UpdateSignStatu();
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_SignUp.RegisterClickEventHandler(new ButtonClickEventHandler(this.RegistractionClick));
		}

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

		private XGuildArenaDocument _Doc;

		private IXUILabel m_Status;

		private IXUIButton m_SignUp;

		private IXUILabel m_SignUpLabel;

		private bool m_responseNow = false;
	}
}
