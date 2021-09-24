using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{

	internal class CustomBattleBriefHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomModeBriefFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			this._start.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartButtonClicked));
			this._edit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEditButtonClicked));
		}

		private void OnCloseClicked(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

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

		private bool OnStartButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleStartNow(this._doc.CurrentCustomData.gameID);
			return true;
		}

		private bool OnEditButtonClicked(IXUIButton button)
		{
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowPasswordSettingHandler();
			return true;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._lefttime_counter.Update();
		}

		private XCustomBattleDocument _doc = null;

		private IXUISprite _close;

		private IXUILabel _name;

		private IXUILabel _type;

		private IXUILabel _creater;

		private Transform _slider;

		private IXUILabel _left_time;

		private IXUILabel _left_time_tip;

		private IXUILabel _size;

		private IXUILabel _length;

		private IXUILabel _limit;

		private IXUILabel _id;

		private IXUIButton _start;

		private IXUIButton _edit;

		private XLeftTimeCounter _lefttime_counter;
	}
}
