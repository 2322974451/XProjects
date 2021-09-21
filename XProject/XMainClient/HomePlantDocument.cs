using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C3B RID: 3131
	internal class HomePlantDocument : XDocComponent
	{
		// Token: 0x17003156 RID: 12630
		// (get) Token: 0x0600B148 RID: 45384 RVA: 0x0021F968 File Offset: 0x0021DB68
		public override uint ID
		{
			get
			{
				return HomePlantDocument.uuID;
			}
		}

		// Token: 0x17003157 RID: 12631
		// (get) Token: 0x0600B149 RID: 45385 RVA: 0x0021F980 File Offset: 0x0021DB80
		public static HomePlantDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(HomePlantDocument.uuID) as HomePlantDocument;
			}
		}

		// Token: 0x17003158 RID: 12632
		// (get) Token: 0x0600B14A RID: 45386 RVA: 0x0021F9AC File Offset: 0x0021DBAC
		public static PlantSeed PlantSeedTable
		{
			get
			{
				return HomePlantDocument.m_PlantSeedTable;
			}
		}

		// Token: 0x17003159 RID: 12633
		// (get) Token: 0x0600B14B RID: 45387 RVA: 0x0021F9C4 File Offset: 0x0021DBC4
		public static PlantSprite PlantSpriteTable
		{
			get
			{
				return HomePlantDocument.m_PlantSpriteTable;
			}
		}

		// Token: 0x1700315A RID: 12634
		// (get) Token: 0x0600B14C RID: 45388 RVA: 0x0021F9DC File Offset: 0x0021DBDC
		public HomeTypeEnum HomeType
		{
			get
			{
				return this.m_homeType;
			}
		}

		// Token: 0x1700315B RID: 12635
		// (get) Token: 0x0600B14D RID: 45389 RVA: 0x0021F9F4 File Offset: 0x0021DBF4
		// (set) Token: 0x0600B14E RID: 45390 RVA: 0x0021FA0C File Offset: 0x0021DC0C
		public ulong GardenId
		{
			get
			{
				return this.m_gardenId;
			}
			set
			{
				this.m_gardenId = value;
				this.SetHomeType();
			}
		}

		// Token: 0x0600B14F RID: 45391 RVA: 0x0021FA20 File Offset: 0x0021DC20
		private void SetHomeType()
		{
			bool flag = this.m_gardenId == 0UL;
			if (flag)
			{
				this.m_homeType = HomeTypeEnum.None;
			}
			else
			{
				bool flag2 = this.GardenId == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					this.m_homeType = HomeTypeEnum.MyHome;
				}
				else
				{
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					bool flag3 = specificDocument.bInGuild && specificDocument.UID == this.GardenId;
					if (flag3)
					{
						this.m_homeType = HomeTypeEnum.GuildHome;
					}
					else
					{
						this.m_homeType = HomeTypeEnum.OtherHome;
					}
				}
			}
		}

		// Token: 0x1700315C RID: 12636
		// (get) Token: 0x0600B151 RID: 45393 RVA: 0x0021FAEC File Offset: 0x0021DCEC
		// (set) Token: 0x0600B150 RID: 45392 RVA: 0x0021FAA4 File Offset: 0x0021DCA4
		public bool HadRedDot
		{
			get
			{
				return this.m_hadRedDot;
			}
			set
			{
				bool flag = this.m_hadRedDot != value;
				if (flag)
				{
					this.m_hadRedDot = value;
					bool flag2 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._HomeHandler != null;
					if (flag2)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._HomeHandler.RefreshPlantRedDot();
					}
				}
			}
		}

		// Token: 0x0600B152 RID: 45394 RVA: 0x0021FB04 File Offset: 0x0021DD04
		private Dictionary<uint, Farmland> GetAllFarmland()
		{
			bool flag = this.HomeType == HomeTypeEnum.GuildHome;
			Dictionary<uint, Farmland> result;
			if (flag)
			{
				result = this.m_farm.GuildFarmlandDic;
			}
			else
			{
				result = this.m_farm.HomeFarmlandDic;
			}
			return result;
		}

		// Token: 0x0600B153 RID: 45395 RVA: 0x0021FB3E File Offset: 0x0021DD3E
		public static void Execute(OnLoadedCallback callback = null)
		{
			HomePlantDocument.AsyncLoader.AddTask("Table/PlantSeed", HomePlantDocument.m_PlantSeedTable, false);
			HomePlantDocument.AsyncLoader.AddTask("Table/PlantSprite", HomePlantDocument.m_PlantSpriteTable, false);
			HomePlantDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B154 RID: 45396 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600B155 RID: 45397 RVA: 0x0021FB79 File Offset: 0x0021DD79
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_GuildLevelChanged, new XComponent.XEventHandler(this.OnGuildLevelChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
			base.EventSubscribe();
		}

		// Token: 0x0600B156 RID: 45398 RVA: 0x0021FBB0 File Offset: 0x0021DDB0
		public override void OnDetachFromHost()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			this.m_bIsPlayingAction = false;
			bool flag = this.HomeSprite != null;
			if (flag)
			{
				this.HomeSprite.ClearInfo();
			}
			base.OnDetachFromHost();
		}

		// Token: 0x0600B157 RID: 45399 RVA: 0x0021FBF8 File Offset: 0x0021DDF8
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool bIsDriveingTroubleMaker = this.m_bIsDriveingTroubleMaker;
			if (bIsDriveingTroubleMaker)
			{
				this.DriveTroubleMaker();
			}
		}

		// Token: 0x0600B158 RID: 45400 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600B159 RID: 45401 RVA: 0x0021FC18 File Offset: 0x0021DE18
		protected bool OnGuildLevelChanged(XEventArgs args)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_HALL && this.HomeType == HomeTypeEnum.GuildHome;
			if (flag)
			{
				this.FetchPlantInfo(0U);
			}
			return true;
		}

		// Token: 0x0600B15A RID: 45402 RVA: 0x0021FC54 File Offset: 0x0021DE54
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_FAMILYGARDEN && (this.HomeType == HomeTypeEnum.MyHome || this.HomeType == HomeTypeEnum.OtherHome);
			if (flag)
			{
				this.FetchPlantInfo(0U);
			}
			return true;
		}

		// Token: 0x0600B15B RID: 45403 RVA: 0x0021FC9C File Offset: 0x0021DE9C
		public void StartPlant(uint farmlandID, uint seedID, bool isCancle = false)
		{
			RpcC2M_StartPlant rpcC2M_StartPlant = new RpcC2M_StartPlant();
			rpcC2M_StartPlant.oArg.farmland_id = farmlandID;
			rpcC2M_StartPlant.oArg.seed_id = seedID;
			rpcC2M_StartPlant.oArg.quest_type = this.GetQuestType();
			rpcC2M_StartPlant.oArg.garden_id = this.GardenId;
			rpcC2M_StartPlant.oArg.cancel = isCancle;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_StartPlant);
		}

		// Token: 0x0600B15C RID: 45404 RVA: 0x0021FD08 File Offset: 0x0021DF08
		public void FetchPlantInfo(uint farmId = 0U)
		{
			RpcC2M_FetchPlantInfo rpcC2M_FetchPlantInfo = new RpcC2M_FetchPlantInfo();
			rpcC2M_FetchPlantInfo.oArg.garden_id = this.GardenId;
			rpcC2M_FetchPlantInfo.oArg.farmland_id = farmId;
			rpcC2M_FetchPlantInfo.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FetchPlantInfo);
		}

		// Token: 0x0600B15D RID: 45405 RVA: 0x0021FD5C File Offset: 0x0021DF5C
		public void PlantCultivation(uint farmlandID, PlantGrowState type)
		{
			RpcC2M_PlantCultivation rpcC2M_PlantCultivation = new RpcC2M_PlantCultivation();
			rpcC2M_PlantCultivation.oArg.garden_id = this.GardenId;
			rpcC2M_PlantCultivation.oArg.farmland_id = farmlandID;
			rpcC2M_PlantCultivation.oArg.operate_type = type;
			rpcC2M_PlantCultivation.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PlantCultivation);
		}

		// Token: 0x0600B15E RID: 45406 RVA: 0x0021FDBC File Offset: 0x0021DFBC
		public void PlantHarvest(uint farmlandID)
		{
			RpcC2M_PlantHarvest rpcC2M_PlantHarvest = new RpcC2M_PlantHarvest();
			rpcC2M_PlantHarvest.oArg.garden_id = this.GardenId;
			rpcC2M_PlantHarvest.oArg.farmland_id = farmlandID;
			rpcC2M_PlantHarvest.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PlantHarvest);
		}

		// Token: 0x0600B15F RID: 45407 RVA: 0x0021FE10 File Offset: 0x0021E010
		public void HomeSteal(uint farmlandID)
		{
			RpcC2M_GardenSteal rpcC2M_GardenSteal = new RpcC2M_GardenSteal();
			rpcC2M_GardenSteal.oArg.garden_id = this.GardenId;
			rpcC2M_GardenSteal.oArg.farmland_id = farmlandID;
			rpcC2M_GardenSteal.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenSteal);
		}

		// Token: 0x0600B160 RID: 45408 RVA: 0x0021FE64 File Offset: 0x0021E064
		public void DriveTroubleMaker()
		{
			bool flag = !this.HomeSprite.IsHadSprite;
			if (!flag)
			{
				RpcC2M_GardenExpelSprite rpcC2M_GardenExpelSprite = new RpcC2M_GardenExpelSprite();
				rpcC2M_GardenExpelSprite.oArg.garden_id = this.GardenId;
				rpcC2M_GardenExpelSprite.oArg.sprite_id = this.HomeSprite.SpriteId;
				rpcC2M_GardenExpelSprite.oArg.quest_type = this.GetQuestType();
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenExpelSprite);
				this.m_bIsDriveingTroubleMaker = true;
			}
		}

		// Token: 0x0600B161 RID: 45409 RVA: 0x0021FEDC File Offset: 0x0021E0DC
		public void ReqBreakNewFarmland(uint farmlandId)
		{
			RpcC2M_OPenGardenFarmland rpcC2M_OPenGardenFarmland = new RpcC2M_OPenGardenFarmland();
			rpcC2M_OPenGardenFarmland.oArg.garden_id = this.GardenId;
			rpcC2M_OPenGardenFarmland.oArg.farmland_id = farmlandId;
			rpcC2M_OPenGardenFarmland.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_OPenGardenFarmland);
		}

		// Token: 0x0600B162 RID: 45410 RVA: 0x0021FF30 File Offset: 0x0021E130
		public void OnStartPlantBack(StartPlantArg oArg, StartPlantRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					Farmland farmland = this.GetFarmland(oArg.farmland_id);
					bool cancel = oArg.cancel;
					if (cancel)
					{
						bool flag3 = this.View != null && this.View.IsVisible();
						if (flag3)
						{
							this.View.SetVisible(false, true);
						}
						farmland.SetFarmlandFree();
						farmland.SetFxEffect();
					}
					else
					{
						bool flag4 = farmland != null;
						if (flag4)
						{
							farmland.SetFarmInfo(oArg.seed_id, 0f, 1U, 0UL, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
							farmland.SetCropState(oRes.grow_state);
							farmland.SetFxEffect();
						}
						bool flag5 = this.View != null && this.View.IsVisible();
						if (flag5)
						{
							this.View.RefreshUI();
						}
					}
				}
			}
		}

		// Token: 0x0600B163 RID: 45411 RVA: 0x00220034 File Offset: 0x0021E234
		public void OnFetchPlantInfoBack(uint farmId, FetchPlantInfoRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				bool flag2 = farmId > 0U;
				if (flag2)
				{
					bool flag3 = false;
					for (int i = 0; i < oRes.plant_info.Count; i++)
					{
						bool flag4 = oRes.plant_info[i].farmland_id == farmId;
						if (flag4)
						{
							flag3 = true;
							break;
						}
					}
					bool flag5 = !flag3;
					if (flag5)
					{
						Farmland farmland = this.GetFarmland(farmId);
						bool flag6 = farmland != null;
						if (flag6)
						{
							farmland.SetFarmlandFree();
							farmland.Destroy();
						}
					}
				}
				for (int j = 0; j < oRes.plant_info.Count; j++)
				{
					Farmland farmland = this.GetFarmland(oRes.plant_info[j].farmland_id);
					bool flag7 = farmland == null;
					if (!flag7)
					{
						farmland.SetFarmInfo(oRes.plant_info[j].seed_id, oRes.plant_info[j].growup_amount, oRes.plant_info[j].notice_times, (ulong)oRes.plant_info[j].growup_cd, oRes.plant_info[j].owner);
						farmland.SetFarmlandLog(oRes.plant_info[j].event_log, 0U);
						farmland.SetCropState(oRes.plant_info[j].plant_grow_state);
					}
				}
				bool flag8 = farmId == 0U;
				if (flag8)
				{
					bool flag9 = this.HomeType == HomeTypeEnum.GuildHome;
					if (flag9)
					{
						this.m_farm.SetGuildFarmlandLock();
					}
					else
					{
						this.m_farm.SetHomeFarmlandLock();
					}
					this.HomeSprite.SetSpriteInfo(oRes.sprite_id);
					for (int k = 0; k < oRes.farmland_id.Count; k++)
					{
						Farmland farmland = this.GetFarmland(oRes.farmland_id[k]);
						bool flag10 = farmland == null;
						if (!flag10)
						{
							farmland.SetLockStatus(false);
						}
					}
				}
				bool flag11 = this.HomeType == HomeTypeEnum.GuildHome;
				if (flag11)
				{
					this.m_farm.SetGuildFarmlandFxEffect();
				}
				else
				{
					this.m_farm.SetHomeFarmlandFxEffect();
				}
				bool flag12 = farmId > 0U;
				if (flag12)
				{
					Farmland farmland2 = this.GetFarmland(this.CurFarmlandId);
					HomeTypeEnum homeType = this.HomeType;
					bool flag13 = farmland2 != null && farmland2.IsFree && homeType == HomeTypeEnum.OtherHome;
					if (flag13)
					{
						bool flag14 = DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.IsVisible();
						if (flag14)
						{
							DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.SetVisible(false, true);
						}
					}
					else
					{
						bool flag15 = DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.IsVisible();
						if (flag15)
						{
							DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.RefreshUI();
						}
						else
						{
							DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.SetVisible(true, true);
						}
					}
				}
				else
				{
					bool flag16 = DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.IsVisible();
					if (flag16)
					{
						DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.RefreshUI();
					}
				}
			}
		}

		// Token: 0x0600B164 RID: 45412 RVA: 0x00220338 File Offset: 0x0021E538
		public void OnPlantCultivationBack(PlantCultivationArg oArg, PlantCultivationRes oRes)
		{
			uint farmland_id = oArg.farmland_id;
			bool flag = oRes.result != ErrorCode.ERR_SUCCESS && oRes.result != ErrorCode.ERR_GARDEN_PLANT_CUL_ERR;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_GARDEN_PLANT_CUL_ERR;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				Farmland farmland = this.GetFarmland(farmland_id);
				bool flag3 = farmland != null;
				if (flag3)
				{
					farmland.UpdateFarmInfo(oRes.growup_amount, oRes.notice_times);
					farmland.SetCropState(PlantGrowState.growCD);
					farmland.AddFarmlandLog(new GardenEventLog
					{
						role_id = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID,
						role_name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name,
						target = farmland.SeedId,
						event_type = (uint)oArg.operate_type,
						result = (oRes.result != ErrorCode.ERR_GARDEN_PLANT_CUL_ERR)
					});
				}
				bool flag4 = this.View != null && this.View.IsVisible();
				if (flag4)
				{
					this.View.RefreshUI();
				}
			}
		}

		// Token: 0x0600B165 RID: 45413 RVA: 0x00220480 File Offset: 0x0021E680
		public void OnPlantHarvestBack(uint famland_id, PlantHarvestRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				Farmland farmland = this.GetFarmland(famland_id);
				bool flag2 = farmland != null;
				if (flag2)
				{
					bool flag3 = oRes.extra && farmland.Row != null;
					if (flag3)
					{
						string arg = "";
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)farmland.Row.ExtraDropItem[0]);
						bool flag4 = itemConf != null;
						if (flag4)
						{
							arg = itemConf.ItemName[0];
						}
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("HomeExtraGet"), farmland.Row.ExtraDropItem[1], arg), "fece00");
					}
					bool flag5 = oRes.harvest && farmland.Row != null;
					if (flag5)
					{
						string arg2 = "";
						ItemList.RowData itemConf2 = XBagDocument.GetItemConf((int)farmland.Row.HarvestPlant[0]);
						bool flag6 = itemConf2 != null;
						if (flag6)
						{
							arg2 = itemConf2.ItemName[0];
						}
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("HomeHarvest"), farmland.Row.HarvestPlant[1], arg2), "fece00");
					}
					farmland.SetFarmlandFree();
					farmland.SetFxEffect();
				}
				this.SetHadRedDot();
				bool flag7 = this.View != null && this.View.IsVisible();
				if (flag7)
				{
					this.View.RefreshUI();
				}
			}
		}

		// Token: 0x0600B166 RID: 45414 RVA: 0x0022061C File Offset: 0x0021E81C
		public void OnHomeStealBack(uint famland_id, GardenStealRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("StealSuccess"), "fece00");
				Farmland farmland = this.GetFarmland(famland_id);
				bool flag2 = farmland != null;
				if (flag2)
				{
					farmland.AddStolenUid(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
				}
				bool flag3 = this.View != null && this.View.IsVisible();
				if (flag3)
				{
					this.View.SetVisible(false, true);
				}
			}
		}

		// Token: 0x0600B167 RID: 45415 RVA: 0x002206B8 File Offset: 0x0021E8B8
		public void OnDriveTroubleMakerBack(GardenExpelSpriteRes oRes)
		{
			this.m_bIsDriveingTroubleMaker = false;
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
						bool flag4 = oRes.result != ErrorCode.ERR_GARDEN_EXPELSPRITE_MAX;
						if (flag4)
						{
							return;
						}
					}
					this.HomeSprite.ClearInfo();
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DriveTroubleMakerSuccee"), "fece00");
				}
			}
		}

		// Token: 0x0600B168 RID: 45416 RVA: 0x00220780 File Offset: 0x0021E980
		public void OnBreakNewFarmlandBack(uint farmlandId, OpenGardenFarmlandRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				Farmland farmland = this.GetFarmland(farmlandId);
				bool flag2 = farmland != null;
				if (flag2)
				{
					farmland.SetLockStatus(false);
					farmland.SetFxEffect();
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BreakNewFarmlandSuccess"), "fece00");
			}
		}

		// Token: 0x0600B169 RID: 45417 RVA: 0x002207F0 File Offset: 0x0021E9F0
		public void OnGetHomeEventBack(PtcG2C_GardenPlantEventNotice roPtc)
		{
			bool flag = roPtc.Data.garden_id != this.GardenId;
			if (!flag)
			{
				GardenPlayEventType event_type = roPtc.Data.event_type;
				if (event_type != GardenPlayEventType.PLANT)
				{
					switch (event_type)
					{
					case GardenPlayEventType.PLANT_DELETE:
					{
						bool flag2 = this.HomeType == HomeTypeEnum.GuildHome;
						if (flag2)
						{
							Farmland farmland = this.GetFarmland(roPtc.Data.farmland_id);
							bool flag3 = farmland != null;
							if (flag3)
							{
								farmland.SetFarmlandFree();
								farmland.SetFxEffect();
							}
						}
						break;
					}
					case GardenPlayEventType.PLANT_SPRITE:
					{
						bool exist = roPtc.Data.exist;
						if (exist)
						{
							this.HomeSprite.SetSpriteInfo(roPtc.Data.sprite_id);
						}
						else
						{
							bool flag4 = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible() && DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.m_npc != null && DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.m_npc.NPCType == 3U;
							if (flag4)
							{
								DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DriveTroubleMakerFaild"), "fece00");
								this.SetFarmlandBoxStatus(true);
							}
							this.HomeSprite.ClearInfo();
						}
						break;
					}
					case GardenPlayEventType.PLANT_MATURE:
					{
						Farmland farmland2 = this.GetFarmland(roPtc.Data.farmland_id);
						bool flag5 = farmland2 != null;
						if (flag5)
						{
							farmland2.SetCropState(PlantGrowState.growMature);
						}
						break;
					}
					}
				}
				else
				{
					bool flag6 = this.HomeType == HomeTypeEnum.GuildHome;
					if (flag6)
					{
						Farmland farmland3 = this.GetFarmland(roPtc.Data.farmland_id);
						bool flag7 = farmland3 != null;
						if (flag7)
						{
							farmland3.DestroyFxEffect();
						}
					}
				}
			}
		}

		// Token: 0x1700315D RID: 12637
		// (get) Token: 0x0600B16A RID: 45418 RVA: 0x0022099C File Offset: 0x0021EB9C
		public List<XItem> HadSeedList
		{
			get
			{
				return this.m_hadSeedList;
			}
		}

		// Token: 0x0600B16B RID: 45419 RVA: 0x002209B4 File Offset: 0x0021EBB4
		public List<XItem> GetHadSeedsList()
		{
			return this.HadSeedList;
		}

		// Token: 0x0600B16C RID: 45420 RVA: 0x002209CC File Offset: 0x0021EBCC
		public void GetHadSeedList()
		{
			this.m_hadSeedList.Clear();
			HomeTypeEnum homeType = this.HomeType;
			bool flag = homeType == HomeTypeEnum.GuildHome;
			ulong typeFilter;
			if (flag)
			{
				typeFilter = 2097152UL;
			}
			else
			{
				typeFilter = 1048576UL;
			}
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.m_hadSeedList);
		}

		// Token: 0x0600B16D RID: 45421 RVA: 0x00220A24 File Offset: 0x0021EC24
		public Farmland GetFarmland(uint farmlandId)
		{
			bool flag = this.HomeType == HomeTypeEnum.GuildHome;
			Farmland result;
			if (flag)
			{
				result = this.m_farm.GetGuildFarmland(farmlandId);
			}
			else
			{
				result = this.m_farm.GetHomeFarmland(farmlandId);
			}
			return result;
		}

		// Token: 0x0600B16E RID: 45422 RVA: 0x00220A60 File Offset: 0x0021EC60
		public uint GetFarmlandIdByNpcId(uint npcId)
		{
			bool flag = this.HomeType == HomeTypeEnum.GuildHome;
			uint result;
			if (flag)
			{
				result = this.m_farm.GetGuildFarmlandIdByNpcId(npcId);
			}
			else
			{
				result = this.m_farm.GetHomeFarmlandIdByNpcId(npcId);
			}
			return result;
		}

		// Token: 0x0600B16F RID: 45423 RVA: 0x00220A9C File Offset: 0x0021EC9C
		private void GetFarmlandNpcIds(ref List<uint> lst)
		{
			bool flag = this.HomeType == HomeTypeEnum.GuildHome;
			if (flag)
			{
				this.m_farm.GetGuildNpcIds(ref lst);
			}
			else
			{
				this.m_farm.GetHomeNpcIds(ref lst);
			}
		}

		// Token: 0x0600B170 RID: 45424 RVA: 0x00220AD8 File Offset: 0x0021ECD8
		public void SetHadRedDot()
		{
			bool flag = this.HomeType != HomeTypeEnum.MyHome;
			if (flag)
			{
				this.HadRedDot = false;
			}
			else
			{
				bool flag2 = false;
				Dictionary<uint, Farmland> allFarmland = this.GetAllFarmland();
				foreach (KeyValuePair<uint, Farmland> keyValuePair in allFarmland)
				{
					bool flag3 = keyValuePair.Value != null && keyValuePair.Value.Stage == GrowStage.Ripe;
					if (flag3)
					{
						flag2 = true;
						break;
					}
				}
				this.HadRedDot = (flag2 | this.HomeSprite.IsHadSprite);
			}
		}

		// Token: 0x0600B171 RID: 45425 RVA: 0x00220B84 File Offset: 0x0021ED84
		public void SetFarmlandBoxStatus(bool status)
		{
			List<uint> list = new List<uint>();
			this.GetFarmlandNpcIds(ref list);
			for (int i = 0; i < list.Count; i++)
			{
				XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(list[i]);
				bool flag = npc != null;
				if (flag)
				{
					npc.EngineObject.EnableBC = status;
				}
			}
		}

		// Token: 0x0600B172 RID: 45426 RVA: 0x00220BE4 File Offset: 0x0021EDE4
		public void ClearFarmInfo()
		{
			bool flag = this.HomeType == HomeTypeEnum.GuildHome;
			if (flag)
			{
				this.m_farm.ResetGuildFarmland();
			}
			else
			{
				this.m_farm.ResetHomeFarmland();
			}
		}

		// Token: 0x0600B173 RID: 45427 RVA: 0x00220C20 File Offset: 0x0021EE20
		public uint GetNpcIdByFarmId(uint farmId)
		{
			bool flag = this.HomeType == HomeTypeEnum.GuildHome;
			SeqList<int> seqList;
			if (flag)
			{
				bool flag2 = this.GuildFarmlandIds == null;
				if (flag2)
				{
					this.GuildFarmlandIds = XSingleton<XGlobalConfig>.singleton.GetSequenceList("NpcIdTransToFarmId_Guild", false);
				}
				seqList = this.GuildFarmlandIds;
			}
			else
			{
				bool flag3 = this.HomeFarmlandIds == null;
				if (flag3)
				{
					this.HomeFarmlandIds = XSingleton<XGlobalConfig>.singleton.GetSequenceList("NpcIdTransToFarmId", false);
				}
				seqList = this.HomeFarmlandIds;
			}
			bool flag4 = seqList != null;
			if (flag4)
			{
				for (int i = 0; i < (int)seqList.Count; i++)
				{
					bool flag5 = (long)seqList[i, 1] == (long)((ulong)farmId);
					if (flag5)
					{
						return (uint)seqList[i, 0];
					}
				}
			}
			return 0U;
		}

		// Token: 0x0600B174 RID: 45428 RVA: 0x00220CEC File Offset: 0x0021EEEC
		public bool GetBreakHomeFarmlandData(out int param0, out int param1)
		{
			param0 = 0;
			param1 = 0;
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("BreakNewFarmlandCost", false);
			int count = (int)XSingleton<XGlobalConfig>.singleton.GetSequenceList("BreakFarmlandLevel", false).Count;
			int num = this.GetBreakFarmlandNum() - count;
			bool flag = num >= 0 && num < (int)sequenceList.Count;
			bool result;
			if (flag)
			{
				param0 = sequenceList[num, 0];
				param1 = sequenceList[num, 1];
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600B175 RID: 45429 RVA: 0x00220D68 File Offset: 0x0021EF68
		private int GetBreakFarmlandNum()
		{
			bool flag = this.HomeType == HomeTypeEnum.GuildHome;
			int result;
			if (flag)
			{
				result = this.m_farm.GetBreakGuildFarmlandNum();
			}
			else
			{
				result = this.m_farm.GetBreakHomeFarmlandNum();
			}
			return result;
		}

		// Token: 0x0600B176 RID: 45430 RVA: 0x00220DA4 File Offset: 0x0021EFA4
		public PlantGrowState GrowStateTrans(CropState state)
		{
			PlantGrowState result;
			switch (state)
			{
			case CropState.Disinsection:
				result = PlantGrowState.growPest;
				break;
			case CropState.Watering:
				result = PlantGrowState.growDrought;
				break;
			case CropState.Fertilizer:
				result = PlantGrowState.growSluggish;
				break;
			default:
				result = PlantGrowState.growCD;
				break;
			}
			return result;
		}

		// Token: 0x0600B177 RID: 45431 RVA: 0x00220DDC File Offset: 0x0021EFDC
		private GardenQuestType GetQuestType()
		{
			GardenQuestType result;
			switch (this.m_homeType)
			{
			case HomeTypeEnum.MyHome:
				result = GardenQuestType.MYSELF;
				break;
			case HomeTypeEnum.OtherHome:
				result = GardenQuestType.FRIEND;
				break;
			case HomeTypeEnum.GuildHome:
				result = GardenQuestType.GUILD;
				break;
			default:
				result = GardenQuestType.MYSELF;
				break;
			}
			return result;
		}

		// Token: 0x0600B178 RID: 45432 RVA: 0x00220E18 File Offset: 0x0021F018
		public string GetHomePlantAction(ActionType type)
		{
			uint basicTypeID = XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID;
			string arg = "";
			switch (type)
			{
			case ActionType.Harvest:
				arg = "harvest";
				break;
			case ActionType.Plant:
			case ActionType.Disinsection:
			case ActionType.Fertilizer:
				arg = "plant";
				break;
			case ActionType.Watering:
				arg = "watering";
				break;
			case ActionType.DriveTroubleMaker:
				arg = "ganyazi";
				break;
			}
			return string.Format("Player_{0}_{1}", XSingleton<XProfessionSkillMgr>.singleton.GetLowerCaseWord(basicTypeID), arg);
		}

		// Token: 0x0600B179 RID: 45433 RVA: 0x00220E9C File Offset: 0x0021F09C
		public void ClickFarmModle(XNpc npc)
		{
			bool bIsPlayingAction = this.m_bIsPlayingAction;
			if (!bIsPlayingAction)
			{
				this.CurFarmlandId = this.GetFarmlandIdByNpcId(npc.TypeID);
				DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.Show(npc);
			}
		}

		// Token: 0x0600B17A RID: 45434 RVA: 0x00220ED4 File Offset: 0x0021F0D4
		public void CliclTroubleMakerModle(XNpc npc)
		{
			bool flag = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
			if (!flag)
			{
				bool bIsPlayingAction = this.m_bIsPlayingAction;
				if (!bIsPlayingAction)
				{
					this.m_bIsPlayingAction = true;
					XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this.GetHomePlantAction(ActionType.DriveTroubleMaker));
					XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
					this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(1.667f, new XTimerMgr.ElapsedEventHandler(this.PlayActionEnd), npc);
					this.SetFarmlandBoxStatus(false);
					this.HomeSprite.SetSpriteBoxStatus(false);
				}
			}
		}

		// Token: 0x0600B17B RID: 45435 RVA: 0x00220F6C File Offset: 0x0021F16C
		private void PlayActionEnd(object o = null)
		{
			XNpc xnpc = o as XNpc;
			bool flag = !XEntity.ValideEntity(xnpc);
			if (!flag)
			{
				XSingleton<XEntityMgr>.singleton.Player.PlayStateBack();
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.ShowNpcDialog(xnpc);
				this.m_bIsPlayingAction = false;
			}
		}

		// Token: 0x0600B17C RID: 45436 RVA: 0x00220FB3 File Offset: 0x0021F1B3
		public void PlayerActionEnd(XNpc npc)
		{
			this.m_targetNpc = npc;
			this.m_timeCounter = 0f;
			this.m_bShouldUpdate = true;
		}

		// Token: 0x0600B17D RID: 45437 RVA: 0x00220FD0 File Offset: 0x0021F1D0
		public override void Update(float fDeltaT)
		{
			bool bShouldUpdate = this.m_bShouldUpdate;
			if (bShouldUpdate)
			{
				this.m_timeCounter += fDeltaT;
				bool flag = this.m_timeCounter >= 1.667f;
				if (flag)
				{
					this.m_timeCounter = 0f;
					this.m_bShouldUpdate = false;
					bool flag2 = this.m_targetNpc != null;
					if (flag2)
					{
						DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.ShowNpcDialog(this.m_targetNpc);
					}
				}
			}
			base.Update(fDeltaT);
		}

		// Token: 0x0400444E RID: 17486
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HomePlantDocument");

		// Token: 0x0400444F RID: 17487
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04004450 RID: 17488
		private static PlantSeed m_PlantSeedTable = new PlantSeed();

		// Token: 0x04004451 RID: 17489
		private static PlantSprite m_PlantSpriteTable = new PlantSprite();

		// Token: 0x04004452 RID: 17490
		public Farm m_farm = new Farm();

		// Token: 0x04004453 RID: 17491
		public HomeSpriteClass HomeSprite = new HomeSpriteClass();

		// Token: 0x04004454 RID: 17492
		public string HomeOwnerName = "";

		// Token: 0x04004455 RID: 17493
		private bool m_bIsDriveingTroubleMaker = false;

		// Token: 0x04004456 RID: 17494
		private HomeTypeEnum m_homeType = HomeTypeEnum.None;

		// Token: 0x04004457 RID: 17495
		public static readonly string PlantEffectPath = "Effects/FX_Particle/UIfx/UI_jy_zz";

		// Token: 0x04004458 RID: 17496
		private ulong m_gardenId = 0UL;

		// Token: 0x04004459 RID: 17497
		private bool m_hadRedDot = false;

		// Token: 0x0400445A RID: 17498
		public HomePlantDlg View;

		// Token: 0x0400445B RID: 17499
		private List<XItem> m_hadSeedList = new List<XItem>();

		// Token: 0x0400445C RID: 17500
		public uint CurFarmlandId = 1U;

		// Token: 0x0400445D RID: 17501
		private SeqList<int> HomeFarmlandIds;

		// Token: 0x0400445E RID: 17502
		private SeqList<int> GuildFarmlandIds;

		// Token: 0x0400445F RID: 17503
		private bool m_bIsPlayingAction = false;

		// Token: 0x04004460 RID: 17504
		private uint m_token;

		// Token: 0x04004461 RID: 17505
		private bool m_bShouldUpdate = false;

		// Token: 0x04004462 RID: 17506
		private float m_timeCounter = 0f;

		// Token: 0x04004463 RID: 17507
		private XNpc m_targetNpc = null;
	}
}
