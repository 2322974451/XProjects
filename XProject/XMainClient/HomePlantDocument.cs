using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class HomePlantDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return HomePlantDocument.uuID;
			}
		}

		public static HomePlantDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(HomePlantDocument.uuID) as HomePlantDocument;
			}
		}

		public static PlantSeed PlantSeedTable
		{
			get
			{
				return HomePlantDocument.m_PlantSeedTable;
			}
		}

		public static PlantSprite PlantSpriteTable
		{
			get
			{
				return HomePlantDocument.m_PlantSpriteTable;
			}
		}

		public HomeTypeEnum HomeType
		{
			get
			{
				return this.m_homeType;
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			HomePlantDocument.AsyncLoader.AddTask("Table/PlantSeed", HomePlantDocument.m_PlantSeedTable, false);
			HomePlantDocument.AsyncLoader.AddTask("Table/PlantSprite", HomePlantDocument.m_PlantSpriteTable, false);
			HomePlantDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_GuildLevelChanged, new XComponent.XEventHandler(this.OnGuildLevelChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
			base.EventSubscribe();
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool bIsDriveingTroubleMaker = this.m_bIsDriveingTroubleMaker;
			if (bIsDriveingTroubleMaker)
			{
				this.DriveTroubleMaker();
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		protected bool OnGuildLevelChanged(XEventArgs args)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_HALL && this.HomeType == HomeTypeEnum.GuildHome;
			if (flag)
			{
				this.FetchPlantInfo(0U);
			}
			return true;
		}

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_FAMILYGARDEN && (this.HomeType == HomeTypeEnum.MyHome || this.HomeType == HomeTypeEnum.OtherHome);
			if (flag)
			{
				this.FetchPlantInfo(0U);
			}
			return true;
		}

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

		public void FetchPlantInfo(uint farmId = 0U)
		{
			RpcC2M_FetchPlantInfo rpcC2M_FetchPlantInfo = new RpcC2M_FetchPlantInfo();
			rpcC2M_FetchPlantInfo.oArg.garden_id = this.GardenId;
			rpcC2M_FetchPlantInfo.oArg.farmland_id = farmId;
			rpcC2M_FetchPlantInfo.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FetchPlantInfo);
		}

		public void PlantCultivation(uint farmlandID, PlantGrowState type)
		{
			RpcC2M_PlantCultivation rpcC2M_PlantCultivation = new RpcC2M_PlantCultivation();
			rpcC2M_PlantCultivation.oArg.garden_id = this.GardenId;
			rpcC2M_PlantCultivation.oArg.farmland_id = farmlandID;
			rpcC2M_PlantCultivation.oArg.operate_type = type;
			rpcC2M_PlantCultivation.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PlantCultivation);
		}

		public void PlantHarvest(uint farmlandID)
		{
			RpcC2M_PlantHarvest rpcC2M_PlantHarvest = new RpcC2M_PlantHarvest();
			rpcC2M_PlantHarvest.oArg.garden_id = this.GardenId;
			rpcC2M_PlantHarvest.oArg.farmland_id = farmlandID;
			rpcC2M_PlantHarvest.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_PlantHarvest);
		}

		public void HomeSteal(uint farmlandID)
		{
			RpcC2M_GardenSteal rpcC2M_GardenSteal = new RpcC2M_GardenSteal();
			rpcC2M_GardenSteal.oArg.garden_id = this.GardenId;
			rpcC2M_GardenSteal.oArg.farmland_id = farmlandID;
			rpcC2M_GardenSteal.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenSteal);
		}

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

		public void ReqBreakNewFarmland(uint farmlandId)
		{
			RpcC2M_OPenGardenFarmland rpcC2M_OPenGardenFarmland = new RpcC2M_OPenGardenFarmland();
			rpcC2M_OPenGardenFarmland.oArg.garden_id = this.GardenId;
			rpcC2M_OPenGardenFarmland.oArg.farmland_id = farmlandId;
			rpcC2M_OPenGardenFarmland.oArg.quest_type = this.GetQuestType();
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_OPenGardenFarmland);
		}

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

		public List<XItem> HadSeedList
		{
			get
			{
				return this.m_hadSeedList;
			}
		}

		public List<XItem> GetHadSeedsList()
		{
			return this.HadSeedList;
		}

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

		public void ClickFarmModle(XNpc npc)
		{
			bool bIsPlayingAction = this.m_bIsPlayingAction;
			if (!bIsPlayingAction)
			{
				this.CurFarmlandId = this.GetFarmlandIdByNpcId(npc.TypeID);
				DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.Show(npc);
			}
		}

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

		public void PlayerActionEnd(XNpc npc)
		{
			this.m_targetNpc = npc;
			this.m_timeCounter = 0f;
			this.m_bShouldUpdate = true;
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HomePlantDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static PlantSeed m_PlantSeedTable = new PlantSeed();

		private static PlantSprite m_PlantSpriteTable = new PlantSprite();

		public Farm m_farm = new Farm();

		public HomeSpriteClass HomeSprite = new HomeSpriteClass();

		public string HomeOwnerName = "";

		private bool m_bIsDriveingTroubleMaker = false;

		private HomeTypeEnum m_homeType = HomeTypeEnum.None;

		public static readonly string PlantEffectPath = "Effects/FX_Particle/UIfx/UI_jy_zz";

		private ulong m_gardenId = 0UL;

		private bool m_hadRedDot = false;

		public HomePlantDlg View;

		private List<XItem> m_hadSeedList = new List<XItem>();

		public uint CurFarmlandId = 1U;

		private SeqList<int> HomeFarmlandIds;

		private SeqList<int> GuildFarmlandIds;

		private bool m_bIsPlayingAction = false;

		private uint m_token;

		private bool m_bShouldUpdate = false;

		private float m_timeCounter = 0f;

		private XNpc m_targetNpc = null;
	}
}
