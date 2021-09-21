using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{
	// Token: 0x02001932 RID: 6450
	internal class CustomBattleCustomModeCreateHandler : DlgHandlerBase
	{
		// Token: 0x17003B27 RID: 15143
		// (get) Token: 0x06010F36 RID: 69430 RVA: 0x0044E3C0 File Offset: 0x0044C5C0
		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/CustomModeCreateFrame";
			}
		}

		// Token: 0x06010F37 RID: 69431 RVA: 0x0044E3D8 File Offset: 0x0044C5D8
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

		// Token: 0x06010F38 RID: 69432 RVA: 0x0044E90F File Offset: 0x0044CB0F
		protected override void OnHide()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnHide();
		}

		// Token: 0x06010F39 RID: 69433 RVA: 0x0044E934 File Offset: 0x0044CB34
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

		// Token: 0x06010F3A RID: 69434 RVA: 0x0044E9D8 File Offset: 0x0044CBD8
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

		// Token: 0x06010F3B RID: 69435 RVA: 0x0044EB88 File Offset: 0x0044CD88
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

		// Token: 0x06010F3C RID: 69436 RVA: 0x0044EC00 File Offset: 0x0044CE00
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

		// Token: 0x06010F3D RID: 69437 RVA: 0x0044EE28 File Offset: 0x0044D028
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

		// Token: 0x06010F3E RID: 69438 RVA: 0x0044EF20 File Offset: 0x0044D120
		public void SetPasswordSwitchSprite(bool flag)
		{
			this.SetSwitchSprite(this._password_switch, flag);
			XSingleton<UiUtility>.singleton.ShowSystemTip(flag ? XSingleton<XStringTable>.singleton.GetString("SetPasswordSucc") : XSingleton<XStringTable>.singleton.GetString("CancelPassword"), "fece00");
		}

		// Token: 0x06010F3F RID: 69439 RVA: 0x0044EF6F File Offset: 0x0044D16F
		internal void SetSwitchSprite(IXUISprite sp, bool flag)
		{
			sp.SetSprite(flag ? "UI_Sw_on" : "UI_Sw_off");
		}

		// Token: 0x06010F40 RID: 69440 RVA: 0x0044EF88 File Offset: 0x0044D188
		private bool OnCloseButtonClicked(IXUIButton button)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06010F41 RID: 69441 RVA: 0x0044EFA4 File Offset: 0x0044D1A4
		private void OnAddRewardClicked(IXUISprite sp)
		{
			uint customBattleNextID = this._doc.GetCustomBattleNextID(this._doc.CustomCreateData.gameType, this._doc.CustomCreateData.configID);
			this.ShowConfig(customBattleNextID);
		}

		// Token: 0x06010F42 RID: 69442 RVA: 0x0044EFE8 File Offset: 0x0044D1E8
		private void OnSubRewardClicked(IXUISprite sp)
		{
			uint customBattlePreID = this._doc.GetCustomBattlePreID(this._doc.CustomCreateData.gameType, this._doc.CustomCreateData.configID);
			this.ShowConfig(customBattlePreID);
		}

		// Token: 0x06010F43 RID: 69443 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnRewardBoxClicked(IXUISprite sp)
		{
		}

		// Token: 0x06010F44 RID: 69444 RVA: 0x0044F02C File Offset: 0x0044D22C
		private bool OnRewardInfoPressed(IXUISprite sp, bool isPressed)
		{
			this._reward_tip.Alpha = (float)(isPressed ? 1 : 0);
			return true;
		}

		// Token: 0x06010F45 RID: 69445 RVA: 0x0044F054 File Offset: 0x0044D254
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

		// Token: 0x06010F46 RID: 69446 RVA: 0x0044F0E8 File Offset: 0x0044D2E8
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

		// Token: 0x06010F47 RID: 69447 RVA: 0x0044F16D File Offset: 0x0044D36D
		private void OnGameNameEditClicked(IXUISprite sp)
		{
			this._game_name.selected(true);
		}

		// Token: 0x06010F48 RID: 69448 RVA: 0x0044F180 File Offset: 0x0044D380
		private void OnFriendOnlySwitchClicked(IXUISprite sp)
		{
			uint num = 1U << XFastEnumIntEqualityComparer<CustomBattleScale>.ToInt(CustomBattleScale.CustomBattle_Scale_Friend);
			XCustomBattleDocument doc = this._doc;
			doc.CustomCreateData.scaleMask = (doc.CustomCreateData.scaleMask ^ num);
			bool flag = (this._doc.CustomCreateData.scaleMask & num) == num;
			this.SetSwitchSprite(this._friendsonly_switch, flag);
		}

		// Token: 0x06010F49 RID: 69449 RVA: 0x0044F1D4 File Offset: 0x0044D3D4
		private void OnGuildOnlySwitchClicked(IXUISprite sp)
		{
			uint num = 1U << XFastEnumIntEqualityComparer<CustomBattleScale>.ToInt(CustomBattleScale.CustomBattle_Scale_Guild);
			XCustomBattleDocument doc = this._doc;
			doc.CustomCreateData.scaleMask = (doc.CustomCreateData.scaleMask ^ num);
			bool flag = (this._doc.CustomCreateData.scaleMask & num) == num;
			this.SetSwitchSprite(this._guildonly_switch, flag);
		}

		// Token: 0x06010F4A RID: 69450 RVA: 0x0044F228 File Offset: 0x0044D428
		private void OnFairModeSwitchClicked(IXUISprite sp)
		{
			this._doc.CustomCreateData.isFair = !this._doc.CustomCreateData.isFair;
			this.SetSwitchSprite(this._fairmode_switch, this._doc.CustomCreateData.isFair);
		}

		// Token: 0x06010F4B RID: 69451 RVA: 0x0044F278 File Offset: 0x0044D478
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

		// Token: 0x06010F4C RID: 69452 RVA: 0x0044F2D5 File Offset: 0x0044D4D5
		private void OnGameTypeChangeClicked(IXUITexture sp)
		{
			this._change_frame.gameObject.SetActive(true);
		}

		// Token: 0x06010F4D RID: 69453 RVA: 0x0044F2EC File Offset: 0x0044D4EC
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

		// Token: 0x06010F4E RID: 69454 RVA: 0x0044F458 File Offset: 0x0044D658
		private bool OnCheckCancelButtonClicked(IXUIButton button)
		{
			this._check_frame.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x06010F4F RID: 69455 RVA: 0x0044F480 File Offset: 0x0044D680
		private bool OnCheckCreateButtonClicked(IXUIButton button)
		{
			this._doc.SendCustomBattleCreate();
			return true;
		}

		// Token: 0x06010F50 RID: 69456 RVA: 0x0044F49F File Offset: 0x0044D69F
		private void OnChangeFrameCloseClicked(IXUISprite sp)
		{
			this._change_frame.gameObject.SetActive(false);
		}

		// Token: 0x06010F51 RID: 69457 RVA: 0x0044F4B4 File Offset: 0x0044D6B4
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

		// Token: 0x06010F52 RID: 69458 RVA: 0x0044F514 File Offset: 0x0044D714
		private void ShowGameType(uint typeid)
		{
			uint customBattleFirstID = this._doc.GetCustomBattleFirstID(typeid);
			CustomBattleTypeTable.RowData customBattleTypeData = this._doc.GetCustomBattleTypeData((int)typeid);
			this._game_type_change.SetTexturePath("atlas/UI/" + customBattleTypeData.show);
			this._game_type_name.SetText(customBattleTypeData.name);
			this.ShowConfig(customBattleFirstID);
		}

		// Token: 0x06010F53 RID: 69459 RVA: 0x0044F574 File Offset: 0x0044D774
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

		// Token: 0x04007CBB RID: 31931
		private XCustomBattleDocument _doc = null;

		// Token: 0x04007CBC RID: 31932
		private IXUIButton _close;

		// Token: 0x04007CBD RID: 31933
		private IXUILabelSymbol _reward1;

		// Token: 0x04007CBE RID: 31934
		private IXUILabelSymbol _reward2;

		// Token: 0x04007CBF RID: 31935
		private IXUISprite _add_reward;

		// Token: 0x04007CC0 RID: 31936
		private IXUISprite _sub_reward;

		// Token: 0x04007CC1 RID: 31937
		private IXUISprite _reward_box;

		// Token: 0x04007CC2 RID: 31938
		private IXUISprite _reward_info;

		// Token: 0x04007CC3 RID: 31939
		private IXUILabel _reward_tip;

		// Token: 0x04007CC4 RID: 31940
		private IXUILabel _game_size;

		// Token: 0x04007CC5 RID: 31941
		private IXUILabel _game_wait_time;

		// Token: 0x04007CC6 RID: 31942
		private IXUILabel _game_time;

		// Token: 0x04007CC7 RID: 31943
		private IXUISprite _game_time_add;

		// Token: 0x04007CC8 RID: 31944
		private IXUISprite _game_time_sub;

		// Token: 0x04007CC9 RID: 31945
		private IXUIInput _game_name;

		// Token: 0x04007CCA RID: 31946
		private IXUISprite _game_name_edit;

		// Token: 0x04007CCB RID: 31947
		private IXUISprite _friendsonly_switch;

		// Token: 0x04007CCC RID: 31948
		private IXUISprite _guildonly_switch;

		// Token: 0x04007CCD RID: 31949
		private IXUISprite _fairmode_switch;

		// Token: 0x04007CCE RID: 31950
		private IXUISprite _password_switch;

		// Token: 0x04007CCF RID: 31951
		private IXUITexture _game_type_change;

		// Token: 0x04007CD0 RID: 31952
		private IXUILabel _game_type_name;

		// Token: 0x04007CD1 RID: 31953
		private IXUIButton _game_create;

		// Token: 0x04007CD2 RID: 31954
		private IXUILabelSymbol _game_create_cost;

		// Token: 0x04007CD3 RID: 31955
		private Transform _check_frame;

		// Token: 0x04007CD4 RID: 31956
		private IXUILabel _check_game_name;

		// Token: 0x04007CD5 RID: 31957
		private IXUILabelSymbol _check_game_reward1;

		// Token: 0x04007CD6 RID: 31958
		private IXUILabelSymbol _check_game_reward2;

		// Token: 0x04007CD7 RID: 31959
		private IXUIButton _check_cancel;

		// Token: 0x04007CD8 RID: 31960
		private IXUIButton _check_create;

		// Token: 0x04007CD9 RID: 31961
		private IXUILabelSymbol _check_create_cost;

		// Token: 0x04007CDA RID: 31962
		private Transform _change_frame;

		// Token: 0x04007CDB RID: 31963
		private IXUIScrollView _game_type_scrollview;

		// Token: 0x04007CDC RID: 31964
		private XUIPool _game_type_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007CDD RID: 31965
		private IXUISprite _change_frame_close;

		// Token: 0x04007CDE RID: 31966
		private Transform _fx_point;

		// Token: 0x04007CDF RID: 31967
		private XFx _fx = null;
	}
}
