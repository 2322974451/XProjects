using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{
	// Token: 0x02001930 RID: 6448
	internal class CustomBattleBriefHandler : DlgHandlerBase
	{
		// Token: 0x17003B25 RID: 15141
		// (get) Token: 0x06010F1E RID: 69406 RVA: 0x0044D510 File Offset: 0x0044B710
		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomModeBriefFrame";
			}
		}

		// Token: 0x06010F1F RID: 69407 RVA: 0x0044D528 File Offset: 0x0044B728
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._close = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this._name = (base.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this._type = (base.transform.Find("Bg/Type").GetComponent("XUILabel") as IXUILabel);
			this._creater = (base.transform.Find("Bg/Creater").GetComponent("XUILabel") as IXUILabel);
			this._slider = base.transform.Find("Bg/Slider");
			this._left_time = (base.transform.Find("Bg/Slider/Time").GetComponent("XUILabel") as IXUILabel);
			this._left_time_tip = (base.transform.Find("Bg/Slider/Time/Tip").GetComponent("XUILabel") as IXUILabel);
			this._lefttime_counter = new XLeftTimeCounter(this._left_time, false);
			this._size = (base.transform.Find("Bg/Size").GetComponent("XUILabel") as IXUILabel);
			this._length = (base.transform.Find("Bg/Length").GetComponent("XUILabel") as IXUILabel);
			this._limit = (base.transform.Find("Bg/Limit").GetComponent("XUILabel") as IXUILabel);
			this._id = (base.transform.Find("Bg/ID").GetComponent("XUILabel") as IXUILabel);
			this._start = (base.transform.Find("Bg/Start").GetComponent("XUIButton") as IXUIButton);
			this._edit = (base.transform.Find("Bg/Edit").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x06010F20 RID: 69408 RVA: 0x0044D734 File Offset: 0x0044B934
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			this._start.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartButtonClicked));
			this._edit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEditButtonClicked));
		}

		// Token: 0x06010F21 RID: 69409 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnCloseClicked(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		// Token: 0x06010F22 RID: 69410 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x06010F23 RID: 69411 RVA: 0x0044D794 File Offset: 0x0044B994
		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = this._doc.CurrentCustomData == null;
			if (flag)
			{
				base.SetVisible(false);
			}
			else
			{
				CustomBattleTable.RowData customBattleData = this._doc.GetCustomBattleData(this._doc.CurrentCustomData.configID);
				this._type.SetText(customBattleData.desc);
				this._name.SetText(this._doc.CurrentCustomData.gameName);
				this._id.SetText(this._doc.CurrentCustomData.token);
				this._creater.SetText(this._doc.CurrentCustomData.gameCreator);
				this._size.SetText(this._doc.CurrentCustomData.joinText);
				this._length.SetText(XSingleton<UiUtility>.singleton.TimeAccFormatString((int)this._doc.CurrentCustomData.gameLength, 4, 0));
				uint num = 1U << XFastEnumIntEqualityComparer<CustomBattleScale>.ToInt(CustomBattleScale.CustomBattle_Scale_Friend);
				bool flag2 = (this._doc.CurrentCustomData.gameMask & num) == num;
				num = 1U << XFastEnumIntEqualityComparer<CustomBattleScale>.ToInt(CustomBattleScale.CustomBattle_Scale_Guild);
				bool flag3 = (this._doc.CurrentCustomData.gameMask & num) == num;
				string text = "";
				bool flag4 = flag2;
				if (flag4)
				{
					text += XSingleton<XStringTable>.singleton.GetString("FriendOnlyJoin");
				}
				bool flag5 = flag3;
				if (flag5)
				{
					text = text + ((text == "") ? "" : ",") + XSingleton<XStringTable>.singleton.GetString("GuildOnlyJoin");
				}
				bool flag6 = text == "";
				if (flag6)
				{
					text = XSingleton<XStringTable>.singleton.GetString("AllJoin");
				}
				this._limit.SetText(text);
				this._start.SetEnable(this._doc.CurrentCustomData.creatorID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, false);
				this._edit.SetEnable(this._doc.CurrentCustomData.creatorID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, false);
				switch (this._doc.CurrentCustomData.gameStatus)
				{
				case CustomBattleState.CustomBattle_Ready:
					this._left_time_tip.SetText(XSingleton<XStringTable>.singleton.GetString("WaitForStart"));
					this._lefttime_counter.SetLeftTime(this._doc.CurrentCustomData.gameStartLeftTime, -1);
					break;
				case CustomBattleState.CustomBattle_Going:
					this._left_time_tip.SetText(XSingleton<XStringTable>.singleton.GetString("WaitForEnd"));
					this._lefttime_counter.SetLeftTime(this._doc.CurrentCustomData.gameEndLeftTime, -1);
					this._start.SetEnable(false, false);
					break;
				case CustomBattleState.CustomBattle_End:
					this._left_time_tip.SetText(XSingleton<XStringTable>.singleton.GetString("WaitForEnd"));
					this._lefttime_counter.SetLeftTime(this._doc.CurrentCustomData.gameEndLeftTime, -1);
					this._start.SetEnable(false, false);
					break;
				case CustomBattleState.CustomBattle_Destory:
					this._left_time_tip.SetText(XSingleton<XStringTable>.singleton.GetString("WaitForEnd"));
					this._lefttime_counter.SetLeftTime(this._doc.CurrentCustomData.gameEndLeftTime, -1);
					this._start.SetEnable(false, false);
					break;
				}
			}
		}

		// Token: 0x06010F24 RID: 69412 RVA: 0x0044DB14 File Offset: 0x0044BD14
		private bool OnStartButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleStartNow(this._doc.CurrentCustomData.gameID);
			return true;
		}

		// Token: 0x06010F25 RID: 69413 RVA: 0x0044DB44 File Offset: 0x0044BD44
		private bool OnEditButtonClicked(IXUIButton button)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowPasswordSettingHandler();
			return true;
		}

		// Token: 0x06010F26 RID: 69414 RVA: 0x0044DB62 File Offset: 0x0044BD62
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._lefttime_counter.Update();
		}

		// Token: 0x04007CA1 RID: 31905
		private XCustomBattleDocument _doc = null;

		// Token: 0x04007CA2 RID: 31906
		private IXUISprite _close;

		// Token: 0x04007CA3 RID: 31907
		private IXUILabel _name;

		// Token: 0x04007CA4 RID: 31908
		private IXUILabel _type;

		// Token: 0x04007CA5 RID: 31909
		private IXUILabel _creater;

		// Token: 0x04007CA6 RID: 31910
		private Transform _slider;

		// Token: 0x04007CA7 RID: 31911
		private IXUILabel _left_time;

		// Token: 0x04007CA8 RID: 31912
		private IXUILabel _left_time_tip;

		// Token: 0x04007CA9 RID: 31913
		private IXUILabel _size;

		// Token: 0x04007CAA RID: 31914
		private IXUILabel _length;

		// Token: 0x04007CAB RID: 31915
		private IXUILabel _limit;

		// Token: 0x04007CAC RID: 31916
		private IXUILabel _id;

		// Token: 0x04007CAD RID: 31917
		private IXUIButton _start;

		// Token: 0x04007CAE RID: 31918
		private IXUIButton _edit;

		// Token: 0x04007CAF RID: 31919
		private XLeftTimeCounter _lefttime_counter;
	}
}
