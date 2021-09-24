using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{

	internal class CustomBattleCustomModeCreateHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomModeCreateFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this._reward1 = (base.transform.Find("Box/Reward1").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._reward2 = (base.transform.Find("Box/Reward2").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._add_reward = (base.transform.Find("Box/Right").GetComponent("XUISprite") as IXUISprite);
			this._sub_reward = (base.transform.Find("Box/Left").GetComponent("XUISprite") as IXUISprite);
			this._reward_box = (base.transform.Find("Box/Box").GetComponent("XUISprite") as IXUISprite);
			this._reward_info = (base.transform.Find("Box/Box/Info").GetComponent("XUISprite") as IXUISprite);
			this._reward_tip = (base.transform.Find("Box/Box/Tips").GetComponent("XUILabel") as IXUILabel);
			this._reward_tip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("CustomBattleCreateBoxTip")));
			this._game_size = (base.transform.Find("Box/Size").GetComponent("XUILabel") as IXUILabel);
			this._game_wait_time = (base.transform.Find("Box/WaitTime").GetComponent("XUILabel") as IXUILabel);
			this._game_time = (base.transform.Find("Box/Time").GetComponent("XUILabel") as IXUILabel);
			this._game_time_add = (base.transform.Find("Box/Time/Add").GetComponent("XUISprite") as IXUISprite);
			this._game_time_sub = (base.transform.Find("Box/Time/Sub").GetComponent("XUISprite") as IXUISprite);
			this._game_name = (base.transform.Find("Settings/Name/Input").GetComponent("XUIInput") as IXUIInput);
			this._game_name_edit = (base.transform.Find("Settings/Name/Edit").GetComponent("XUISprite") as IXUISprite);
			this._friendsonly_switch = (base.transform.Find("Settings/FriendsOnly").GetComponent("XUISprite") as IXUISprite);
			this._guildonly_switch = (base.transform.Find("Settings/GuildOnly").GetComponent("XUISprite") as IXUISprite);
			this._fairmode_switch = (base.transform.Find("Settings/FairMode").GetComponent("XUISprite") as IXUISprite);
			this._password_switch = (base.transform.Find("Settings/Password").GetComponent("XUISprite") as IXUISprite);
			this._game_type_change = (base.transform.Find("Settings/GameChange").GetComponent("XUITexture") as IXUITexture);
			this._game_type_name = (base.transform.Find("Settings/GameChange/Name").GetComponent("XUILabel") as IXUILabel);
			this._game_create = (base.transform.Find("BtnCreate").GetComponent("XUIButton") as IXUIButton);
			this._game_create_cost = (base.transform.Find("BtnCreate/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._check_frame = base.transform.Find("CheckFrame");
			this._check_game_name = (base.transform.Find("CheckFrame/Name").GetComponent("XUILabel") as IXUILabel);
			this._check_game_reward1 = (base.transform.Find("CheckFrame/Reward/Reward1").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._check_game_reward2 = (base.transform.Find("CheckFrame/Reward/Reward2").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._check_cancel = (base.transform.Find("CheckFrame/Cancel").GetComponent("XUIButton") as IXUIButton);
			this._check_create = (base.transform.Find("CheckFrame/BtnCreate").GetComponent("XUIButton") as IXUIButton);
			this._check_create_cost = (base.transform.Find("CheckFrame/BtnCreate/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._change_frame = base.transform.Find("ChangeFrame");
			this._game_type_scrollview = (base.transform.Find("ChangeFrame/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._change_frame_close = (base.transform.Find("ChangeFrame/Close").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.Find("ChangeFrame/Panel/Tpl");
			this._game_type_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this._fx_point = base.transform.Find("Box/Box/Fx");
		}

		protected override void OnHide()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnHide();
		}

		public override void OnUnload()
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			this._game_type_pool.GetActiveList(list);
			for (int i = 0; i < list.Count; i++)
			{
				IXUITexture ixuitexture = list[i].transform.Find("Background").GetComponent("XUITexture") as IXUITexture;
				ixuitexture.SetTexturePath("");
			}
			ListPool<GameObject>.Release(list);
			this._game_type_change.SetTexturePath("");
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseButtonClicked));
			this._add_reward.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddRewardClicked));
			this._sub_reward.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSubRewardClicked));
			this._reward_box.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRewardBoxClicked));
			this._reward_info.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnRewardInfoPressed));
			this._game_time_add.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGameTimeAddClicked));
			this._game_time_sub.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGameTimeSubClicked));
			this._game_name_edit.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGameNameEditClicked));
			this._friendsonly_switch.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnFriendOnlySwitchClicked));
			this._guildonly_switch.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGuildOnlySwitchClicked));
			this._fairmode_switch.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnFairModeSwitchClicked));
			this._password_switch.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPasswordSwitchClicked));
			this._game_type_change.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnGameTypeChangeClicked));
			this._game_create.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGameCreateButtonClicked));
			this._check_cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCheckCancelButtonClicked));
			this._check_create.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCheckCreateButtonClicked));
			this._change_frame_close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChangeFrameCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._reward_tip.Alpha = 0f;
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			this._fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_BountyModeListFrame_Clip01", this._fx_point, false);
			this._doc.ResetCustomModeCreateData();
			this.RefreshData();
			this.RefreshTypeList();
		}

		private void RefreshTypeList()
		{
			this._game_type_pool.ReturnAll(false);
			CustomBattleTypeTable.RowData[] customBattleTypelist = this._doc.GetCustomBattleTypelist();
			for (int i = 0; i < customBattleTypelist.Length; i++)
			{
				bool flag = customBattleTypelist[i].gmcreate && !this._doc.IsCreateGM;
				if (!flag)
				{
					GameObject gameObject = this._game_type_pool.FetchGameObject(false);
					gameObject.transform.localPosition = this._game_type_pool.TplPos + new Vector3(0f, (float)(-(float)i * this._game_type_pool.TplHeight));
					IXUITexture ixuitexture = gameObject.transform.Find("Background").GetComponent("XUITexture") as IXUITexture;
					ixuitexture.SetTexturePath("atlas/UI/" + customBattleTypelist[i].show);
					IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(customBattleTypelist[i].name);
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((long)customBattleTypelist[i].type);
					GameObject gameObject2 = gameObject.transform.Find("Lock").gameObject;
					IXUILabel ixuilabel2 = gameObject2.GetComponent("XUILabel") as IXUILabel;
					bool notopen = customBattleTypelist[i].notopen;
					if (notopen)
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTypeSelect));
						ixuitexture.SetEnabled(true);
						gameObject2.SetActive(true);
					}
					else
					{
						ixuisprite.RegisterSpriteClickEventHandler(null);
						ixuitexture.SetEnabled(false);
						gameObject2.SetActive(false);
					}
					uint customBattleLevelLimitByType = this._doc.GetCustomBattleLevelLimitByType((uint)customBattleTypelist[i].type);
					bool flag2 = customBattleLevelLimitByType > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
					if (flag2)
					{
						gameObject2.SetActive(true);
						ixuilabel2.SetText(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL", new object[]
						{
							customBattleLevelLimitByType
						}));
						ixuisprite.RegisterSpriteClickEventHandler(null);
					}
					else
					{
						gameObject2.SetActive(false);
					}
				}
			}
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this._change_frame.gameObject.SetActive(false);
			this._check_frame.gameObject.SetActive(false);
			this._game_name.SetText(this._doc.CustomCreateData.gameName);
			uint num = 1U << XFastEnumIntEqualityComparer<CustomBattleScale>.ToInt(CustomBattleScale.CustomBattle_Scale_Friend);
			bool flag = (this._doc.CustomCreateData.scaleMask & num) == num;
			num = 1U << XFastEnumIntEqualityComparer<CustomBattleScale>.ToInt(CustomBattleScale.CustomBattle_Scale_Guild);
			bool flag2 = (this._doc.CustomCreateData.scaleMask & num) == num;
			this.SetSwitchSprite(this._friendsonly_switch, flag);
			this.SetSwitchSprite(this._guildonly_switch, flag2);
			this.SetSwitchSprite(this._fairmode_switch, this._doc.CustomCreateData.isFair);
			this.SetSwitchSprite(this._password_switch, this._doc.CustomCreateData.hasPassword);
			this.ShowGameType(1U);
		}

		public void SetPasswordSwitchSprite(bool flag)
		{
			this.SetSwitchSprite(this._password_switch, flag);
			XSingleton<UiUtility>.singleton.ShowSystemTip(flag ? XSingleton<XStringTable>.singleton.GetString("SetPasswordSucc") : XSingleton<XStringTable>.singleton.GetString("CancelPassword"), "fece00");
		}

		internal void SetSwitchSprite(IXUISprite sp, bool flag)
		{
			sp.SetSprite(flag ? "UI_Sw_on" : "UI_Sw_off");
		}

		private bool OnCloseButtonClicked(IXUIButton button)
		{
			base.SetVisible(false);
			return true;
		}

		private void OnAddRewardClicked(IXUISprite sp)
		{
			uint customBattleNextID = this._doc.GetCustomBattleNextID(this._doc.CustomCreateData.gameType, this._doc.CustomCreateData.configID);
			this.ShowConfig(customBattleNextID);
		}

		private void OnSubRewardClicked(IXUISprite sp)
		{
			uint customBattlePreID = this._doc.GetCustomBattlePreID(this._doc.CustomCreateData.gameType, this._doc.CustomCreateData.configID);
			this.ShowConfig(customBattlePreID);
		}

		private void OnRewardBoxClicked(IXUISprite sp)
		{
		}

		private bool OnRewardInfoPressed(IXUISprite sp, bool isPressed)
		{
			this._reward_tip.Alpha = (float)(isPressed ? 1 : 0);
			return true;
		}

		private void OnGameTimeAddClicked(IXUISprite sp)
		{
			CustomBattleTable.RowData customBattleData = this._doc.GetCustomBattleData(this._doc.CustomCreateData.configID);
			int num = customBattleData.timespan.Length;
			bool flag = (ulong)this._doc.CustomCreateData.battleTimeIndex < (ulong)((long)(num - 1));
			if (flag)
			{
				XCustomBattleDocument doc = this._doc;
				doc.CustomCreateData.battleTimeIndex = doc.CustomCreateData.battleTimeIndex + 1U;
			}
			this._game_time.SetText(XSingleton<UiUtility>.singleton.TimeAccFormatString((int)customBattleData.timespan[(int)this._doc.CustomCreateData.battleTimeIndex], 4, 0));
		}

		private void OnGameTimeSubClicked(IXUISprite sp)
		{
			CustomBattleTable.RowData customBattleData = this._doc.GetCustomBattleData(this._doc.CustomCreateData.configID);
			bool flag = this._doc.CustomCreateData.battleTimeIndex > 0U;
			if (flag)
			{
				XCustomBattleDocument doc = this._doc;
				doc.CustomCreateData.battleTimeIndex = doc.CustomCreateData.battleTimeIndex - 1U;
			}
			this._game_time.SetText(XSingleton<UiUtility>.singleton.TimeAccFormatString((int)customBattleData.timespan[(int)this._doc.CustomCreateData.battleTimeIndex], 4, 0));
		}

		private void OnGameNameEditClicked(IXUISprite sp)
		{
			this._game_name.selected(true);
		}

		private void OnFriendOnlySwitchClicked(IXUISprite sp)
		{
			uint num = 1U << XFastEnumIntEqualityComparer<CustomBattleScale>.ToInt(CustomBattleScale.CustomBattle_Scale_Friend);
			XCustomBattleDocument doc = this._doc;
			doc.CustomCreateData.scaleMask = (doc.CustomCreateData.scaleMask ^ num);
			bool flag = (this._doc.CustomCreateData.scaleMask & num) == num;
			this.SetSwitchSprite(this._friendsonly_switch, flag);
		}

		private void OnGuildOnlySwitchClicked(IXUISprite sp)
		{
			uint num = 1U << XFastEnumIntEqualityComparer<CustomBattleScale>.ToInt(CustomBattleScale.CustomBattle_Scale_Guild);
			XCustomBattleDocument doc = this._doc;
			doc.CustomCreateData.scaleMask = (doc.CustomCreateData.scaleMask ^ num);
			bool flag = (this._doc.CustomCreateData.scaleMask & num) == num;
			this.SetSwitchSprite(this._guildonly_switch, flag);
		}

		private void OnFairModeSwitchClicked(IXUISprite sp)
		{
			this._doc.CustomCreateData.isFair = !this._doc.CustomCreateData.isFair;
			this.SetSwitchSprite(this._fairmode_switch, this._doc.CustomCreateData.isFair);
		}

		private void OnPasswordSwitchClicked(IXUISprite sp)
		{
			bool flag = !this._doc.CustomCreateData.hasPassword;
			if (flag)
			{
				this.SetSwitchSprite(this._password_switch, true);
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowPasswordSettingHandler();
			}
			else
			{
				this._doc.CustomCreateData.hasPassword = false;
				this.SetPasswordSwitchSprite(false);
			}
		}

		private void OnGameTypeChangeClicked(IXUITexture sp)
		{
			this._change_frame.gameObject.SetActive(true);
		}

		private bool OnGameCreateButtonClicked(IXUIButton button)
		{
			this._check_game_name.SetText(this._game_name.GetText());
			this._doc.CustomCreateData.gameName = this._game_name.GetText();
			SeqListRef<uint> customBattleBestReward = this._doc.GetCustomBattleBestReward(this._doc.CustomCreateData.configID);
			this._check_game_reward1.InputText = "";
			this._check_game_reward2.InputText = "";
			bool flag = customBattleBestReward.Count > 0;
			if (flag)
			{
				this._check_game_reward1.InputText = XLabelSymbolHelper.FormatSmallIcon((int)customBattleBestReward[0, 0]) + " " + customBattleBestReward[0, 1].ToString();
			}
			bool flag2 = customBattleBestReward.Count > 1;
			if (flag2)
			{
				this._check_game_reward2.InputText = XLabelSymbolHelper.FormatSmallIcon((int)customBattleBestReward[1, 0]) + " " + customBattleBestReward[1, 1].ToString();
			}
			this._check_create_cost.InputText = XLabelSymbolHelper.FormatSmallIcon((int)this._doc.CustomCreateData.cost.itemID) + " " + this._doc.CustomCreateData.cost.itemCount.ToString();
			this._check_frame.gameObject.SetActive(true);
			return true;
		}

		private bool OnCheckCancelButtonClicked(IXUIButton button)
		{
			this._check_frame.gameObject.SetActive(false);
			return true;
		}

		private bool OnCheckCreateButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleCreate();
			return true;
		}

		private void OnChangeFrameCloseClicked(IXUISprite sp)
		{
			this._change_frame.gameObject.SetActive(false);
		}

		private void OnTypeSelect(IXUISprite sp)
		{
			uint num = (uint)sp.ID;
			this._change_frame.gameObject.SetActive(false);
			bool flag = num != this._doc.CustomCreateData.gameType;
			if (flag)
			{
				this._doc.CustomCreateData.gameType = num;
				this.ShowGameType(num);
			}
		}

		private void ShowGameType(uint typeid)
		{
			uint customBattleFirstID = this._doc.GetCustomBattleFirstID(typeid);
			CustomBattleTypeTable.RowData customBattleTypeData = this._doc.GetCustomBattleTypeData((int)typeid);
			this._game_type_change.SetTexturePath("atlas/UI/" + customBattleTypeData.show);
			this._game_type_name.SetText(customBattleTypeData.name);
			this.ShowConfig(customBattleFirstID);
		}

		private void ShowConfig(uint configID)
		{
			CustomBattleTable.RowData customBattleData = this._doc.GetCustomBattleData(configID);
			bool flag = customBattleData == null;
			if (!flag)
			{
				this._doc.CustomCreateData.configID = configID;
				this._doc.CustomCreateData.canJoinCount = customBattleData.joincount;
				this._doc.CustomCreateData.readyTime = customBattleData.readytimepan;
				this._game_size.SetText(this._doc.CustomCreateData.canJoinCount.ToString());
				this._game_wait_time.SetText(XSingleton<UiUtility>.singleton.TimeAccFormatString((int)this._doc.CustomCreateData.readyTime, 4, 0));
				bool flag2 = (ulong)this._doc.CustomCreateData.battleTimeIndex >= (ulong)((long)customBattleData.timespan.Length);
				if (flag2)
				{
					this._doc.CustomCreateData.battleTimeIndex = (uint)(customBattleData.timespan.Length - 1);
				}
				this._game_time.SetText(XSingleton<UiUtility>.singleton.TimeAccFormatString((int)customBattleData.timespan[(int)this._doc.CustomCreateData.battleTimeIndex], 4, 0));
				SeqListRef<uint> customBattleBestReward = this._doc.GetCustomBattleBestReward(configID);
				this._reward1.InputText = "";
				this._reward2.InputText = "";
				bool flag3 = customBattleBestReward.Count > 0;
				if (flag3)
				{
					this._reward1.InputText = XLabelSymbolHelper.FormatSmallIcon((int)customBattleBestReward[0, 0]) + " " + customBattleBestReward[0, 1].ToString();
				}
				bool flag4 = customBattleBestReward.Count > 1;
				if (flag4)
				{
					this._reward2.InputText = XLabelSymbolHelper.FormatSmallIcon((int)customBattleBestReward[1, 0]) + " " + customBattleBestReward[1, 1].ToString();
				}
				this._doc.CustomCreateData.cost.itemID = customBattleData.create[0, 0];
				this._doc.CustomCreateData.cost.itemCount = customBattleData.create[0, 1];
				this._game_create_cost.InputText = XLabelSymbolHelper.FormatSmallIcon((int)this._doc.CustomCreateData.cost.itemID) + " " + this._doc.CustomCreateData.cost.itemCount.ToString();
				bool flag5 = uint.MaxValue == this._doc.GetCustomBattleNextID(this._doc.CustomCreateData.gameType, configID);
				if (flag5)
				{
					this._add_reward.SetAlpha(0f);
				}
				else
				{
					this._add_reward.SetAlpha(1f);
				}
				bool flag6 = this._doc.GetCustomBattlePreID(this._doc.CustomCreateData.gameType, configID) == 0U;
				if (flag6)
				{
					this._sub_reward.SetAlpha(0f);
				}
				else
				{
					this._sub_reward.SetAlpha(1f);
				}
				this._reward_box.SetSprite(customBattleData.BoxSpriteName);
			}
		}

		private XCustomBattleDocument _doc = null;

		private IXUIButton _close;

		private IXUILabelSymbol _reward1;

		private IXUILabelSymbol _reward2;

		private IXUISprite _add_reward;

		private IXUISprite _sub_reward;

		private IXUISprite _reward_box;

		private IXUISprite _reward_info;

		private IXUILabel _reward_tip;

		private IXUILabel _game_size;

		private IXUILabel _game_wait_time;

		private IXUILabel _game_time;

		private IXUISprite _game_time_add;

		private IXUISprite _game_time_sub;

		private IXUIInput _game_name;

		private IXUISprite _game_name_edit;

		private IXUISprite _friendsonly_switch;

		private IXUISprite _guildonly_switch;

		private IXUISprite _fairmode_switch;

		private IXUISprite _password_switch;

		private IXUITexture _game_type_change;

		private IXUILabel _game_type_name;

		private IXUIButton _game_create;

		private IXUILabelSymbol _game_create_cost;

		private Transform _check_frame;

		private IXUILabel _check_game_name;

		private IXUILabelSymbol _check_game_reward1;

		private IXUILabelSymbol _check_game_reward2;

		private IXUIButton _check_cancel;

		private IXUIButton _check_create;

		private IXUILabelSymbol _check_create_cost;

		private Transform _change_frame;

		private IXUIScrollView _game_type_scrollview;

		private XUIPool _game_type_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUISprite _change_frame_close;

		private Transform _fx_point;

		private XFx _fx = null;
	}
}
