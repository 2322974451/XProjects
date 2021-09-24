using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEquipComponent : XComponent, IDelayLoad
	{

		public override uint ID
		{
			get
			{
				return XEquipComponent.uuID;
			}
		}

		public XAffiliate Sprite
		{
			get
			{
				return this._sprite;
			}
		}

		public XEquipComponent()
		{
			this._combineMeshTask = new CombineMeshTask(new MountLoadCallback(this.PartLoaded));
		}

		public bool IsUIAvatar
		{
			get
			{
				return this._isUIAvatar;
			}
			set
			{
				this._isUIAvatar = value;
			}
		}

		public bool IsVisible
		{
			get
			{
				return this._visible;
			}
		}

		public bool IsRenderEnable
		{
			get
			{
				return this._enableRender;
			}
		}

		private static void _GetSkinmesh(XGameObject gameObject, object o, int commandID)
		{
			XEquipComponent xequipComponent = o as XEquipComponent;
			bool flag = xequipComponent != null;
			if (flag)
			{
				Transform transform = gameObject.Find("");
				xequipComponent.GetEquipPoints(transform);
				Transform transform2 = transform.Find("CombinedMesh");
				bool flag2 = transform2 != null;
				if (flag2)
				{
					transform2.parent = null;
					UnityEngine.Object.Destroy(transform2.gameObject);
				}
				SkinnedMeshRenderer skinnedMeshRenderer = gameObject.SMR;
				bool flag3 = skinnedMeshRenderer == null;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog2("error role prefab not skin mesh:{0}", new object[]
					{
						gameObject.m_Location
					});
				}
				else
				{
					bool flag4 = transform != skinnedMeshRenderer.transform;
					if (flag4)
					{
						skinnedMeshRenderer = null;
						xequipComponent._combineMeshTask.noCombine = true;
					}
				}
				xequipComponent._combineMeshTask.skin = skinnedMeshRenderer;
				bool flag5 = skinnedMeshRenderer != null;
				if (flag5)
				{
					skinnedMeshRenderer.enabled = false;
				}
			}
		}

		private bool IsSkinmeshLoaded()
		{
			return this._combineMeshTask.skin != null || this._combineMeshTask.noCombine;
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._type_id = this._entity.TypeID;
			this.m_mainWeaponID = 0;
			this.m_sideWeaponID = 0;
			bool isRole = this._entity.IsRole;
			short id;
			if (isRole)
			{
				id = (short)this._type_id;
			}
			else
			{
				bool isDummy = this._entity.IsDummy;
				if (isDummy)
				{
					id = (short)this._type_id;
				}
				else
				{
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._type_id);
					id = byID.FashionTemplate;
				}
			}
			this._defaultEquipList = XEquipDocument.GetDefaultEquip(id);
			bool flag = this._defaultEquipList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Cant find defaultEquip with id: ", id.ToString(), ", typeid ", this._type_id.ToString(), ", entityType ", this._entity.EntityType.ToString());
				this._prof_id = 0;
			}
			else
			{
				this._prof_id = (int)(this._defaultEquipList.id - 1);
			}
			this._host.EngineObject.CallCommand(XEquipComponent._getSkinmeshCb, this, -1, false);
			this._LoadFinishedCallback = null;
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnPlayerDeathEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnRevived, new XComponent.XEventHandler(this.OnPlayerReviveEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnMounted, new XComponent.XEventHandler(this.OnMountEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnUnMounted, new XComponent.XEventHandler(this.OnMountEvent));
		}

		public override void Attached()
		{
			bool flag = this._entity.IsPlayer && XQualitySetting._CastShadow;
			if (flag)
			{
				this.m_CustomShadow = XSingleton<XCustomShadowMgr>.singleton.AddShadowProjector(XSingleton<XScene>.singleton.GameCamera.CameraTrans);
			}
			bool isViewGridScene = XSingleton<XScene>.singleton.IsViewGridScene;
			if (isViewGridScene)
			{
				bool flag2 = this._entity is XDummy;
				if (flag2)
				{
					this._visible = true;
				}
				else
				{
					bool flag3 = XEquipDocument.CurrentVisibleRole < XQualitySetting.GetVisibleRoleCount();
					if (flag3)
					{
						XEquipDocument.CurrentVisibleRole++;
						this._visible = true;
					}
					else
					{
						this._visible = false;
					}
				}
			}
			else
			{
				this._visible = true;
			}
			bool visible = this._visible;
			if (visible)
			{
				bool flag4 = this.IsSkinmeshLoaded();
				if (flag4)
				{
					this.Load();
				}
				else
				{
					XSingleton<XResourceLoaderMgr>.singleton.AddDelayProcess(this);
				}
			}
		}

		public override void OnDetachFromHost()
		{
			bool flag = this.m_CustomShadow != null;
			if (flag)
			{
				XSingleton<XCustomShadowMgr>.singleton.RemoveShadowProjector(this.m_CustomShadow);
				this.m_CustomShadow = null;
			}
			bool flag2 = this._visible && !this._isUIAvatar;
			if (flag2)
			{
				XEquipDocument.CurrentVisibleRole--;
			}
			XSingleton<XResourceLoaderMgr>.singleton.RemoveDelayProcess(this);
			this.UnEquipFx();
			this.UnEquipAffiliateParts();
			this._combineMeshTask.Reset(this._entity);
			this._type_id = 0U;
			this._prof_id = 0;
			this.m_mainWeaponID = 0;
			this._root = null;
			this._rootFx = null;
			this._rootFxID = 0U;
			this._rootPoint = null;
			this._mainWeaponFx = null;
			this.m_sideWeaponID = 0;
			this._wing = null;
			this._wingPoint = null;
			this._tail = null;
			this._tailPoint = null;
			this._sprite = null;
			this._spritePoint = null;
			this._fishing = null;
			this._finshingPoint = null;
			this._defaultEquipList = null;
			this.enhanceLevel = 0U;
			this._LoadFinishedCallback = null;
			this._isUIAvatar = false;
			this._enableRealTimeShadow = false;
			this._enableRender = true;
			this._renderQueue = -1;
			this._visible = true;
			this._hairColorID = 0U;
			base.OnDetachFromHost();
		}

		public void Load()
		{
			this.EquipFromAttr();
			this.SpriteFromAttr();
		}

		public EDelayProcessType DelayUpdate()
		{
			bool flag = this._combineMeshTask != null;
			EDelayProcessType result;
			if (flag)
			{
				bool flag2 = this._combineMeshTask.combineStatus == ECombineStatus.ENotCombine;
				if (flag2)
				{
					this.Load();
					result = EDelayProcessType.EUpdate;
				}
				else
				{
					bool flag3 = this.IsSkinmeshLoaded() && this._combineMeshTask.Process();
					if (flag3)
					{
						this.CombineMesh();
					}
					bool flag4 = this._combineMeshTask.combineStatus == ECombineStatus.ECombined;
					if (flag4)
					{
						bool flag5 = this.combineFinishFrame > 1;
						if (flag5)
						{
							for (EPartType epartType = EPartType.ECombinePartEnd; epartType < EPartType.EMountEnd; epartType++)
							{
								EquipLoadTask equipLoadTask = this._combineMeshTask.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType)];
								this.PartLoaded(equipLoadTask as MountLoadTask);
							}
							this.combineFinishFrame = 0;
							result = EDelayProcessType.EFinish;
						}
						else
						{
							this.SetHairColor();
							this.RefreshSuitFx();
							this.combineFinishFrame++;
							result = EDelayProcessType.EUpdate;
						}
					}
					else
					{
						result = EDelayProcessType.EUpdate;
					}
				}
			}
			else
			{
				result = EDelayProcessType.EFinish;
			}
			return result;
		}

		private void SetHairColor()
		{
			bool flag = this._combineMeshTask.skin != null;
			if (flag)
			{
				Color hairColor = XFashionStorageDocument.GetHairColor(this._hairColorID);
				ShaderManager.SetColor(this._combineMeshTask.mpb, hairColor, ShaderManager._ShaderKeyIDHairColor);
				this._combineMeshTask.skin.SetPropertyBlock(this._combineMeshTask.mpb);
			}
		}

		public void SetLoadFinishedCallback(LoadFinishedCallback callback)
		{
			this._LoadFinishedCallback = callback;
		}

		private void UnEquipFx()
		{
			this.DestroyFx(this._mainWeaponFx);
			this.DestroyFx(this.sideWeaponFx);
			this.DestroyFx(ref this._rootFx);
			bool flag = this.sideWeaponPoint != null;
			if (flag)
			{
				for (int i = 0; i < this.sideWeaponPoint.Length; i++)
				{
					this.sideWeaponPoint[i] = null;
				}
			}
		}

		private void UnEquipAffiliateParts()
		{
			bool flag = this._wing != null;
			if (flag)
			{
				this._entity.DestroyAffiliate(this._wing);
				this._wing = null;
			}
			bool flag2 = this._tail != null;
			if (flag2)
			{
				this._entity.DestroyAffiliate(this._tail);
				this._tail = null;
			}
			bool flag3 = this._fishing != null;
			if (flag3)
			{
				this._entity.DestroyAffiliate(this._fishing);
				this._fishing = null;
			}
			bool flag4 = this._sprite != null;
			if (flag4)
			{
				this._entity.DestroyAffiliate(this._sprite);
				this._sprite = null;
			}
		}

		private void UnEquipAffiliateParts(ref XAffiliate aff)
		{
			bool flag = aff != null;
			if (flag)
			{
				this._entity.DestroyAffiliate(aff);
				aff = null;
			}
		}

		private void GetEquipPoints(Transform root)
		{
			this._root = root;
			bool flag = this._defaultEquipList == null;
			if (!flag)
			{
				this._wingPoint = XEquipDocument.GetMountPoint(root, this._defaultEquipList.WingPoint);
				bool flag2 = this._mainWeaponFx == null;
				if (flag2)
				{
					this._mainWeaponFx = new XFx[XEquipComponent._mainWeapointSize];
				}
				bool flag3 = this._mainWeaponPoint == null;
				if (flag3)
				{
					this._mainWeaponPoint = new Transform[XEquipComponent._mainWeapointSize];
				}
				this._mainWeaponPoint[0] = XEquipDocument.GetMountPoint(root, this._defaultEquipList.WeaponPoint[0]);
				bool flag4 = this._defaultEquipList.WeaponPoint.Length > 1 && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World;
				if (flag4)
				{
					this._mainWeaponPoint[1] = XEquipDocument.GetMountPoint(root, this._defaultEquipList.WeaponPoint[1]);
				}
				else
				{
					this._mainWeaponPoint[1] = null;
				}
				bool flag5 = !string.IsNullOrEmpty(this._defaultEquipList.RootPoint);
				if (flag5)
				{
					this._rootPoint = XEquipDocument.GetMountPoint(root, this._defaultEquipList.RootPoint);
				}
				else
				{
					this._rootPoint = null;
				}
				bool flag6 = this.sideWeaponPoint == null;
				if (flag6)
				{
					this.sideWeaponPoint = new Transform[XEquipComponent.sideWeaponPointSize];
				}
				bool flag7 = this.sideWeaponFx == null;
				if (flag7)
				{
					this.sideWeaponFx = new XFx[XEquipComponent.sideWeaponPointSize];
				}
				for (int i = 0; i < XEquipComponent.sideWeaponPointSize; i++)
				{
					bool flag8 = this._defaultEquipList.SideWeaponPoint == null;
					if (flag8)
					{
						break;
					}
					bool flag9 = i < this._defaultEquipList.SideWeaponPoint.Length;
					if (flag9)
					{
						this.sideWeaponPoint[i] = XEquipDocument.GetMountPoint(root, this._defaultEquipList.SideWeaponPoint[i]);
					}
					else
					{
						this.sideWeaponPoint[i] = null;
					}
				}
				this._tailPoint = XEquipDocument.GetMountPoint(root, this._defaultEquipList.TailPoint);
				this._spritePoint = XEquipDocument.GetMountPoint(root, "sprite");
				this._finshingPoint = XEquipDocument.GetMountPoint(root, this._defaultEquipList.FishingPoint);
			}
		}

		public void EquipFromVisibleList(FashionPositionInfo[] outlookList, uint hairID, uint effectID)
		{
			this.EquipAll(outlookList, hairID, effectID);
		}

		public void EquipFromAttr()
		{
			bool isDummy = this._entity.IsDummy;
			if (!isDummy)
			{
				bool isRole = this._entity.IsRole;
				if (isRole)
				{
					this.EquipAll(this._entity.Attributes.Outlook.OutlookList, this._entity.Attributes.Outlook.hairColorID, this._entity.Attributes.Outlook.suitEffectID);
				}
				else
				{
					XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._type_id);
					int equiplistByFashionTemplate = XEquipDocument.GetEquiplistByFashionTemplate(byID.FashionTemplate, ref XOutlookData.sharedFashionList);
					this.EquipAll(XOutlookData.sharedFashionList, 0U, 0U);
					XOutlookData.InitFasionList(ref XOutlookData.sharedFashionList);
				}
			}
		}

		public void OnEquipChange()
		{
			this.EquipFromAttr();
		}

		private void EquipAll(FashionPositionInfo[] fashionList, uint hairID = 0U, uint effect = 0U)
		{
			bool flag = !this._visible;
			if (!flag)
			{
				bool flag2 = fashionList == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("null fashion list", null, null, null, null, null);
				}
				else
				{
					this._combineMeshTask.roleType = this._prof_id;
					XSingleton<XResourceLoaderMgr>.singleton.RemoveDelayProcess(this);
					this._combineMeshTask.BeginCombine();
					HashSet<string> hashSet = HashPool<string>.Get();
					int num = XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionSecondaryWeapon);
					int num2 = XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.Hair);
					this._rootFxID = effect;
					int i = 0;
					int num3 = fashionList.Length;
					while (i < num3)
					{
						FashionPositionInfo fashionPositionInfo = fashionList[i];
						bool flag3 = num == i;
						if (flag3)
						{
							this.m_sideWeaponID = fashionPositionInfo.fasionID;
						}
						else
						{
							bool flag4 = num2 == i;
							if (flag4)
							{
								this._hairColorID = ((fashionPositionInfo.fasionID < 10000 || hairID == 0U) ? XFashionStorageDocument.GetDefaultColorID((uint)fashionPositionInfo.fasionID) : hairID);
							}
						}
						int num4 = CombineMeshTask.ConvertPart((FashionPosition)i);
						bool flag5 = num4 >= 0;
						if (flag5)
						{
							EquipLoadTask equipLoadTask = this._combineMeshTask.parts[num4];
							equipLoadTask.Load(this._entity, this._prof_id, ref fashionPositionInfo, XSingleton<XResourceLoaderMgr>.singleton.DelayLoad && !this._entity.IsPlayer, hashSet);
						}
						i++;
					}
					HashPool<string>.Release(hashSet);
					bool flag6 = this._combineMeshTask.EndCombine() && this.IsSkinmeshLoaded();
					if (flag6)
					{
						this.DelayUpdate();
					}
					XSingleton<XResourceLoaderMgr>.singleton.AddDelayProcess(this);
				}
			}
		}

		private void CombineMesh()
		{
			bool needCombine = this._combineMeshTask.needCombine;
			if (needCombine)
			{
				XEquipDocument._CombineMeshUtility.Combine(this._combineMeshTask);
				bool flag = this._combineMeshTask.skin != null && this._combineMeshTask.skin.sharedMaterial != null;
				if (flag)
				{
					this._combineMeshTask.skin.sharedMaterial.name = this._entity.EngineObject.Name;
				}
			}
			bool flag2 = this.m_CustomShadow != null;
			if (flag2)
			{
				this.m_CustomShadow.Begin(this._entity.EngineObject);
			}
			this._combineMeshTask.combineStatus = ECombineStatus.ECombined;
			int num = this._isUIAvatar ? XQualitySetting.UILayer : this._entity.DefaultLayer;
			bool flag3 = this._combineMeshTask.skin != null;
			if (flag3)
			{
				bool flag4 = num >= 0;
				if (flag4)
				{
					this._combineMeshTask.skin.gameObject.layer = num;
				}
				this._combineMeshTask.skin.enabled = this._enableRender;
				for (EPartType epartType = EPartType.EMountEnd; epartType <= EPartType.EMountEnd; epartType++)
				{
					DecalLoadTask decalLoadTask = this._combineMeshTask.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType)] as DecalLoadTask;
					decalLoadTask.PostLoad(this._combineMeshTask);
				}
				Color hairColor = XFashionStorageDocument.GetHairColor(this._hairColorID);
				ShaderManager.SetColor(this._combineMeshTask.mpb, hairColor, ShaderManager._ShaderKeyIDHairColor);
				this._combineMeshTask.skin.SetPropertyBlock(this._combineMeshTask.mpb);
				int quality = XQualitySetting.GetQuality();
				bool flag5 = CombineMeshTask.s_CombineMatType == ECombineMatType.EIndependent || (this._entity.IsPlayer && quality >= XQualitySetting.normalLevel);
				if (flag5)
				{
					this._combineMeshTask.skin.quality = (SkinQuality)4;
				}
				else
				{
					this._combineMeshTask.skin.quality = 0;
				}
				bool flag6 = CombineMeshTask.s_CombineMatType == ECombineMatType.ECombined;
				if (flag6)
				{
					this._host.EngineObject.SyncPhysicBox(new Vector3(0f, 0.5f, 0f), new Vector3(0.5f, 1f, 0.5f));
				}
				this.RefreshFxActive(ref this._mainWeaponFx, this._enableRender);
				this.RefreshFxActive(ref this.sideWeaponFx, this._enableRender);
				this.RefreshFxActive(ref this._rootFx, this._enableRender);
				bool flag7 = num != XQualitySetting.UILayer && num >= 0;
				if (flag7)
				{
					GameObject gameObject = this._combineMeshTask.skin.gameObject;
					XRenderComponent.RemoveObj(this._entity, gameObject);
					XRenderComponent.AddEquipObj(this._entity, gameObject, this._combineMeshTask.skin);
				}
				this.RefreshSecondWeaponFx();
			}
			bool flag8 = this._LoadFinishedCallback != null;
			if (flag8)
			{
				this._LoadFinishedCallback(this);
			}
		}

		private void RefreshShadow()
		{
			bool enableRealTimeShadow = this._enableRealTimeShadow;
			if (enableRealTimeShadow)
			{
				bool flag = this._entity.IsPlayer && this.m_CustomShadow == null;
				if (flag)
				{
					this.m_CustomShadow = XSingleton<XCustomShadowMgr>.singleton.AddShadowProjector(XSingleton<XScene>.singleton.GameCamera.CameraTrans);
					bool flag2 = this.m_CustomShadow != null;
					if (flag2)
					{
						this.m_CustomShadow.Begin(this._entity.EngineObject);
					}
				}
			}
			else
			{
				bool flag3 = this.m_CustomShadow != null;
				if (flag3)
				{
					XSingleton<XCustomShadowMgr>.singleton.RemoveShadowProjector(this.m_CustomShadow);
					this.m_CustomShadow = null;
				}
			}
		}

		private void RefreshEnable()
		{
			int layer = this._isUIAvatar ? XQualitySetting.UILayer : this._entity.DefaultLayer;
			for (EPartType epartType = EPartType.ECombinePartEnd; epartType < EPartType.EMountEnd; epartType++)
			{
				MountLoadTask mountLoadTask = this._combineMeshTask.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType)] as MountLoadTask;
				mountLoadTask.ProcessEnable(this._enableRender, XEquipComponent.ForceDisableEffect(this._entity, mountLoadTask), layer);
			}
			bool flag = this._combineMeshTask.skin != null;
			if (flag)
			{
				this._combineMeshTask.skin.enabled = this._enableRender;
			}
			this.RefreshFxActive(ref this._mainWeaponFx, this._enableRender);
			this.RefreshFxActive(ref this.sideWeaponFx, this._enableRender);
			this.RefreshFxActive(ref this._rootFx, this._enableRender);
		}

		private void RefreshRenderQueue()
		{
			bool flag = this._renderQueue > 0;
			if (flag)
			{
				for (EPartType epartType = EPartType.ECombinePartEnd; epartType < EPartType.EMountEnd; epartType++)
				{
					MountLoadTask mountLoadTask = this._combineMeshTask.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType)] as MountLoadTask;
					mountLoadTask.ProcessRenderQueue(this._renderQueue);
				}
				this.RefreshFxQueue(ref this._mainWeaponFx, this._renderQueue);
				this.RefreshFxQueue(ref this.sideWeaponFx, this._renderQueue);
				this.RefreshFxQueue(ref this._rootFx, this._renderQueue);
			}
		}

		private static bool HideWing(XEntity e, MountLoadTask mountPart)
		{
			bool flag = mountPart.part == EPartType.EWeaponEnd && e.Attributes != null && (e.Attributes.Outlook.state.type == OutLookStateType.OutLook_RidePet || e.Attributes.Outlook.state.type == OutLookStateType.OutLook_RidePetCopilot);
			if (flag)
			{
				bool flag2 = e.Attributes.Outlook.state.param > 0U && !XPetDocument.GetWithowWind(e.Attributes.Outlook.state.param);
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		private static bool ForceDisableEffect(XEntity e, MountLoadTask mountPart)
		{
			return XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_LOGIN && !XQualitySetting.GetQuality(EFun.ECommonHigh) && !e.IsPlayer && mountPart.part != EPartType.ECombinePartEnd;
		}

		private void PartLoaded(MountLoadTask mountPart)
		{
			bool flag = this._entity == null || this._combineMeshTask.combineStatus != ECombineStatus.ECombined;
			if (!flag)
			{
				bool flag2 = mountPart != null && mountPart.processStatus == EProcessStatus.EPreProcess;
				if (flag2)
				{
					XGameObject xgo = mountPart.xgo;
					bool flag3 = xgo == null;
					if (flag3)
					{
						bool flag4 = mountPart.part == EPartType.EWeaponEnd;
						if (flag4)
						{
							this.UnEquipAffiliateParts(ref this._wing);
						}
						else
						{
							bool flag5 = mountPart.part == EPartType.ETail;
							if (flag5)
							{
								this.UnEquipAffiliateParts(ref this._tail);
							}
							else
							{
								bool flag6 = mountPart.part == EPartType.ESprite;
								if (flag6)
								{
									this.UnEquipAffiliateParts(ref this._sprite);
								}
							}
						}
					}
					else
					{
						int layer = this._isUIAvatar ? XQualitySetting.UILayer : this._entity.DefaultLayer;
						bool flag7 = XEquipComponent.HideWing(this._entity, mountPart);
						bool forceDisable = XEquipComponent.ForceDisableEffect(this._entity, mountPart);
						bool enable = !flag7 && this._enableRender;
						mountPart.ProcessRender(this._entity, layer, enable, this._renderQueue, forceDisable);
						bool flag8 = mountPart.part == EPartType.ECombinePartEnd;
						if (flag8)
						{
							this.m_mainWeaponID = mountPart.fpi.fasionID;
							WeaponLoadTask weaponLoadTask = mountPart as WeaponLoadTask;
							bool flag9 = weaponLoadTask != null && this._mainWeaponPoint != null;
							if (flag9)
							{
								weaponLoadTask.PostProcess(this._mainWeaponPoint[0], this._mainWeaponPoint[1], this._entity);
							}
							this.RefreshEquipFx();
						}
						else
						{
							XAffiliate xaffiliate = null;
							bool flag10 = mountPart.part == EPartType.EWeaponEnd;
							if (flag10)
							{
								this._wing = mountPart.PostProcess(this._entity, this._wing, this._wingPoint);
								xaffiliate = this._wing;
							}
							else
							{
								bool flag11 = mountPart.part == EPartType.ETail;
								if (flag11)
								{
									this._tail = mountPart.PostProcess(this._entity, this._tail, this._tailPoint);
									xaffiliate = this._tail;
								}
								else
								{
									bool flag12 = mountPart.part == EPartType.ESprite;
									if (flag12)
									{
										this._sprite = mountPart.PostProcess(this._entity, this._sprite, this._spritePoint);
										bool flag13 = this._sprite != null;
										if (flag13)
										{
											xaffiliate = this._sprite;
											this._sprite.MirrorState = false;
											this._sprite.ChangeSpriteMatColor();
											this.UpdateSpriteOffset(this._entity.IsMounted ? ESpriteStatus.EMount : ESpriteStatus.ENormal);
										}
									}
								}
							}
							bool flag14 = xaffiliate != null;
							if (flag14)
							{
								xaffiliate.OnMount();
							}
						}
					}
					mountPart.processStatus = EProcessStatus.EProcessed;
				}
			}
		}

		public bool IsLoadingPart()
		{
			return this._combineMeshTask.combineStatus == ECombineStatus.ECombineing;
		}

		public bool IsCombineFinish()
		{
			return this._combineMeshTask.combineStatus == ECombineStatus.ECombined;
		}

		public void EquipFishing(bool enabled, uint presentid = 0U)
		{
			if (enabled)
			{
				XAffiliate xaffiliate = XSingleton<XEntityMgr>.singleton.CreateAffiliate(presentid, this._entity);
				xaffiliate.MirrorState = false;
				this._fishing = xaffiliate;
				xaffiliate.EngineObject.SetParentTrans(this._finshingPoint);
				xaffiliate.EngineObject.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, Vector3.one, false);
			}
			else
			{
				bool flag = this._fishing != null;
				if (flag)
				{
					this._entity.DestroyAffiliate(this._fishing);
					this._fishing = null;
				}
			}
		}

		public void PlayFishingRodAnimation(string anim)
		{
			bool flag = this._fishing != null;
			if (flag)
			{
				this._fishing.Presentation(anim, null, null);
			}
		}

		public void EffectFromAttr()
		{
		}

		public uint SpriteFromAttr()
		{
			bool isDummy = this._entity.IsDummy;
			uint result;
			if (isDummy)
			{
				result = 0U;
			}
			else
			{
				bool isRole = this._entity.IsRole;
				if (isRole)
				{
					bool flag = this._entity.Attributes.Outlook.sprite.leaderid == 0U;
					if (flag)
					{
						this.AttachSprite(false, 0U);
					}
					else
					{
						XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
						SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(this._entity.Attributes.Outlook.sprite.leaderid);
						bool flag2 = bySpriteID == null;
						if (!flag2)
						{
							this.AttachSprite(true, bySpriteID.PresentID);
							return bySpriteID.PresentID;
						}
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Error! sprite leaderID = ", this._entity.Attributes.Outlook.sprite.leaderid), null, null, null, null, null);
						this.AttachSprite(false, 0U);
					}
				}
				result = 0U;
			}
			return result;
		}

		public void SpriteFromData(XOutlookSprite sprite)
		{
			bool flag = sprite.leaderid == 0U;
			if (flag)
			{
				this.AttachSprite(false, 0U);
			}
			else
			{
				XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
				SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(sprite.leaderid);
				bool flag2 = bySpriteID == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Error! sprite leaderID = {0}", sprite.leaderid), null, null, null, null, null);
					this.AttachSprite(false, 0U);
				}
				else
				{
					this.AttachSprite(true, bySpriteID.PresentID);
				}
			}
		}

		public void AttachSprite(bool bAttached, uint presentid = 0U)
		{
			MountLoadTask mountLoadTask = this._combineMeshTask.parts[11] as MountLoadTask;
			FashionPositionInfo fashionPositionInfo = new FashionPositionInfo(0);
			fashionPositionInfo.presentID = (bAttached ? presentid : 0U);
			mountLoadTask.Load(this._entity, -1, ref fashionPositionInfo, true, null);
		}

		private void UpdateSpriteOffset(ESpriteStatus spriteState)
		{
			bool flag = this._combineMeshTask.combineStatus == ECombineStatus.ECombined && this._spritePoint != null && this._combineMeshTask.skin != null;
			if (flag)
			{
				Vector3 size = this._combineMeshTask.skin.localBounds.size;
				size.x /= -2f;
				size.z = 0f;
				bool flag2 = spriteState == ESpriteStatus.EMount || spriteState == ESpriteStatus.EDead;
				if (flag2)
				{
					size.y /= 2f;
				}
				this._spritePoint.localPosition = XSingleton<XGlobalConfig>.singleton.SpriteOffset + size;
			}
		}

		public void RefreashSprite()
		{
			this.UpdateSpriteOffset(this._entity.IsMounted ? ESpriteStatus.EMount : ESpriteStatus.ENormal);
		}

		private void UpdateEnhanceLevel(XBodyBag equipBag)
		{
			bool flag = equipBag != null;
			if (flag)
			{
				this.enhanceLevel = uint.MaxValue;
				for (int i = 0; i < XBagDocument.EquipMax; i++)
				{
					XEquipItem xequipItem = equipBag[i] as XEquipItem;
					bool flag2 = xequipItem != null && xequipItem.itemID != 0;
					if (!flag2)
					{
						this.enhanceLevel = 0U;
						return;
					}
					this.enhanceLevel = Math.Min(this.enhanceLevel, xequipItem.enhanceInfo.EnhanceLevel);
				}
				bool flag3 = this.enhanceLevel != uint.MaxValue;
				if (flag3)
				{
					return;
				}
			}
			this.enhanceLevel = 0U;
		}

		public void SetEnhanceMaster(uint level)
		{
			this.enhanceLevel = level;
		}

		public void SetSuitFx(uint id)
		{
			this._rootFxID = id;
		}

		private bool ShowEquipFx(bool login = true)
		{
			XQualitySetting.ESetting quality = (XQualitySetting.ESetting)XQualitySetting.GetQuality();
			bool flag = this._entity.IsDummy || this._entity.IsPlayer;
			XQualitySetting.ESetting esetting = quality;
			if (esetting - XQualitySetting.ESetting.EHeigh <= 1)
			{
				flag = true;
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_LOGIN;
			if (flag2)
			{
				flag = (flag && login);
			}
			return flag;
		}

		private void RefreshEnhanceLevel()
		{
			bool isDummy = this._entity.IsDummy;
			if (!isDummy)
			{
				bool flag = this._entity.Attributes != null;
				if (flag)
				{
					this.enhanceLevel = this._entity.Attributes.Outlook.enhanceMasterLevel;
				}
				else
				{
					this.enhanceLevel = 0U;
				}
			}
		}

		private void RefreshSuitFxID()
		{
			bool isDummy = this._entity.IsDummy;
			if (!isDummy)
			{
				bool flag = this._entity.Attributes != null;
				if (flag)
				{
					this._rootFxID = this._entity.Attributes.Outlook.suitEffectID;
				}
				else
				{
					this._rootFxID = 0U;
				}
			}
		}

		public void RefreshSuitFx()
		{
			this.RefreshSuitFxID();
			this.SetSuitFx(this.ShowEquipFx(false));
		}

		public void RefreshEquipFx()
		{
			this.RefreshEnhanceLevel();
			this.SetWeaponFx(this.ShowEquipFx(true));
		}

		public void RefreshSecondWeaponFx()
		{
			this.SetSideWeaponFx(this.ShowEquipFx(true));
		}

		private void SetSideWeaponFx(bool setFx)
		{
			bool flag = this.sideWeaponFx == null || this.sideWeaponPoint == null;
			if (!flag)
			{
				string[] strFxs = null;
				bool flag2 = setFx && XFashionDocument.TryGetFashionEnhanceFx(this.m_sideWeaponID, this._type_id, out strFxs);
				if (flag2)
				{
					this.SetWeaponFx(ref this.sideWeaponFx, ref this.sideWeaponPoint, strFxs);
				}
				else
				{
					this.DestroyFx(this.sideWeaponFx);
				}
			}
		}

		private void SetSuitFx(bool setFx)
		{
			string text = null;
			bool flag = setFx && XFashionStorageDocument.TryGetSpecialEffect(this._rootFxID, this._type_id, out text);
			if (flag)
			{
				bool flag2 = this._rootFx != null && !this._rootFx.FxName.Equals(text);
				if (flag2)
				{
					this.DestroyFx(ref this._rootFx);
					this._rootFx = null;
				}
				bool flag3 = this._rootFx != null;
				if (!flag3)
				{
					Transform transform = (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_LOGIN && this._rootPoint != null) ? this._rootPoint : this._root;
					bool isUIAvatar = this._isUIAvatar;
					if (isUIAvatar)
					{
						this._rootFx = XSingleton<XFxMgr>.singleton.CreateUIFx(text, transform, true);
						bool flag4 = this._renderQueue > 0;
						if (flag4)
						{
							this._rootFx.SetRenderQueue(this._renderQueue);
						}
					}
					else
					{
						this._rootFx = XSingleton<XFxMgr>.singleton.CreateFx(text, XFx._ProcessMesh, true);
						this._rootFx.SetActive(this._enableRender);
						this._rootFx.SetRenderLayer(this._entity.DefaultLayer);
						this._rootFx.Play(transform, Vector3.zero, Vector3.one, 1f, true, false);
						this._rootFx.SetParent(transform, Vector3.zero, Quaternion.Euler(new Vector3(0f, 0f, -transform.localEulerAngles.z)), Vector3.one);
						XRenderComponent.AddFx(this._entity, this._rootFx);
						bool flag5 = this._rootFx != null && this._entity.Mount != null;
						if (flag5)
						{
							this._entity.Mount.MountFx(this._rootFx, this._entity.IsCopilotMounted);
						}
					}
				}
			}
			else
			{
				this.DestroyFx(ref this._rootFx);
			}
		}

		private void SetWeaponFx(ref XFx[] xfxs, ref Transform[] points, string[] strFxs)
		{
			bool flag = xfxs == null || points == null;
			if (!flag)
			{
				bool flag2 = strFxs == null;
				if (flag2)
				{
					this.DestroyFx(xfxs);
				}
				else
				{
					bool flag3 = !this.ComparerValue(xfxs, strFxs);
					bool flag4 = flag3;
					if (flag4)
					{
						this.DestroyFx(xfxs);
					}
					bool flag5 = flag3;
					if (flag5)
					{
						int i = 0;
						int num = points.Length;
						while (i < num)
						{
							bool flag6 = points[i] == null || i >= strFxs.Length;
							if (!flag6)
							{
								bool isUIAvatar = this._isUIAvatar;
								if (isUIAvatar)
								{
									xfxs[i] = XSingleton<XFxMgr>.singleton.CreateUIFx(strFxs[i], points[i], true);
									bool flag7 = this._renderQueue > 0;
									if (flag7)
									{
										xfxs[i].SetRenderQueue(this._renderQueue);
									}
								}
								else
								{
									XFx xfx = XSingleton<XFxMgr>.singleton.CreateFx(strFxs[i], XFx._ProcessMesh, true);
									xfx.SetActive(this._enableRender);
									xfx.SetRenderLayer(this._entity.DefaultLayer);
									xfx.Play(points[i], Vector3.zero, Vector3.one, 1f, true, false);
									xfxs[i] = xfx;
									XRenderComponent.AddFx(this._entity, xfxs[i]);
								}
							}
							i++;
						}
					}
				}
			}
		}

		private bool ComparerValue(XFx[] fxs, string[] str)
		{
			bool flag = str == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int i = 0;
				int num = fxs.Length;
				while (i < num)
				{
					bool flag2 = i < str.Length;
					if (flag2)
					{
						bool flag3 = fxs[i] == null || string.IsNullOrEmpty(str[i]);
						if (flag3)
						{
							return false;
						}
						bool flag4 = !fxs[i].FxName.Equals(str[i]);
						if (flag4)
						{
							return false;
						}
					}
					else
					{
						bool flag5 = fxs[i] != null;
						if (flag5)
						{
							return false;
						}
					}
					i++;
				}
				result = true;
			}
			return result;
		}

		private void SetWeaponFx(bool setFx)
		{
			string[] strFxs = null;
			bool flag = setFx && (XFashionDocument.TryGetFashionEnhanceFx(this.m_mainWeaponID, this._type_id, out strFxs) || XEquipDocument.TryGetEnhanceFxData(this._type_id, this.enhanceLevel, out strFxs));
			if (flag)
			{
				this.SetWeaponFx(ref this._mainWeaponFx, ref this._mainWeaponPoint, strFxs);
			}
			else
			{
				this.DestroyFx(this._mainWeaponFx);
			}
		}

		private void DestroyFx(XFx[] fxs)
		{
			bool flag = fxs != null && fxs.Length != 0;
			if (flag)
			{
				int i = 0;
				int num = fxs.Length;
				while (i < num)
				{
					bool flag2 = fxs[i] == null;
					if (!flag2)
					{
						this.DestroyFx(ref fxs[i]);
					}
					i++;
				}
			}
		}

		private void DestroyFx(ref XFx fx)
		{
			bool flag = fx != null;
			if (flag)
			{
				XRenderComponent.RemoveFx(this._entity, fx);
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
				fx = null;
			}
		}

		private void RefreshFxActive(ref XFx[] xfxs, bool active)
		{
			bool flag = xfxs == null;
			if (!flag)
			{
				for (int i = 0; i < xfxs.Length; i++)
				{
					this.RefreshFxActive(ref xfxs[i], active);
				}
			}
		}

		private void RefreshFxActive(ref XFx xfx, bool active)
		{
			bool flag = xfx != null;
			if (flag)
			{
				xfx.SetActive(active);
			}
		}

		private void RefreshFxQueue(ref XFx xfx, int renderQueue)
		{
			bool flag = xfx != null;
			if (flag)
			{
				xfx.SetRenderQueue(renderQueue);
			}
		}

		private void RefreshFxQueue(ref XFx[] xfxs, int renderQueue)
		{
			for (int i = 0; i < xfxs.Length; i++)
			{
				this.RefreshFxQueue(ref xfxs[i], renderQueue);
			}
		}

		protected bool OnPlayerDeathEvent(XEventArgs e)
		{
			bool flag = this._sprite == null || this._entity.Attributes.Outlook.sprite.leaderid == 0U;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
				SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(this._entity.Attributes.Outlook.sprite.leaderid);
				this._sprite.Presentation(bySpriteID.DeathAnim, null, null);
				this.UpdateSpriteOffset(ESpriteStatus.EDead);
				result = true;
			}
			return result;
		}

		protected bool OnPlayerReviveEvent(XEventArgs e)
		{
			bool flag = this._sprite == null || this._entity.Attributes.Outlook.sprite.leaderid == 0U;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
				SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(this._entity.Attributes.Outlook.sprite.leaderid);
				this._sprite.Presentation(bySpriteID.ReviveAnim, null, null);
				this.UpdateSpriteOffset(this._entity.IsMounted ? ESpriteStatus.EMount : ESpriteStatus.ENormal);
				result = true;
			}
			return result;
		}

		protected bool OnMountEvent(XEventArgs e)
		{
			bool flag = e is XOnMountedEventArgs;
			if (flag)
			{
				this.UpdateSpriteOffset(ESpriteStatus.EMount);
				int layer = this._isUIAvatar ? XQualitySetting.UILayer : this._entity.DefaultLayer;
				MountLoadTask mountLoadTask = this._combineMeshTask.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.EWeaponEnd)] as MountLoadTask;
				bool flag2 = XEquipComponent.HideWing(this._entity, mountLoadTask);
				mountLoadTask.ProcessEnable(!flag2 && this._enableRender, false, layer);
				bool flag3 = this.m_CustomShadow != null;
				if (flag3)
				{
					this.m_CustomShadow.OnTargetChange(this._entity.MoveObj);
				}
				bool flag4 = this._rootFx != null && this._entity.Mount != null;
				if (flag4)
				{
					this._entity.Mount.MountFx(this._rootFx, this._entity.IsCopilotMounted);
				}
			}
			else
			{
				bool flag5 = e is XOnUnMountedEventArgs;
				if (flag5)
				{
					this.UpdateSpriteOffset(ESpriteStatus.ENormal);
					int layer2 = this._isUIAvatar ? XQualitySetting.UILayer : this._entity.DefaultLayer;
					MountLoadTask mountLoadTask2 = this._combineMeshTask.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.EWeaponEnd)] as MountLoadTask;
					mountLoadTask2.ProcessEnable(this._enableRender, XEquipComponent.ForceDisableEffect(this._entity, mountLoadTask2), layer2);
					bool flag6 = this.m_CustomShadow != null;
					if (flag6)
					{
						this.m_CustomShadow.OnTargetChange(this._entity.EngineObject);
					}
					bool flag7 = this._rootFx != null;
					if (flag7)
					{
						this._rootFx.SetParent(this._root, Vector3.zero, Quaternion.identity, Vector3.one);
					}
				}
			}
			return true;
		}

		public void EnableRealTimeShadow(bool enable)
		{
			this._enableRealTimeShadow = enable;
			bool flag = this.IsCombineFinish();
			if (flag)
			{
				this.RefreshShadow();
			}
		}

		public void EnableRender(bool enable)
		{
			this._enableRender = enable;
			bool flag = this.IsCombineFinish();
			if (flag)
			{
				this.RefreshEnable();
			}
		}

		public void SetRenderQueue(int renderQueue)
		{
			this._renderQueue = renderQueue;
			bool flag = this.IsCombineFinish();
			if (flag)
			{
				this.RefreshRenderQueue();
			}
		}

		public void RefreshRenderObj()
		{
			bool flag = this.IsCombineFinish();
			if (flag)
			{
				bool flag2 = this._combineMeshTask.skin != null;
				if (flag2)
				{
					GameObject gameObject = this._combineMeshTask.skin.gameObject;
					XRenderComponent.AddEquipObj(this._entity, gameObject, this._combineMeshTask.skin);
				}
				for (EPartType epartType = EPartType.ECombinePartEnd; epartType < EPartType.EMountEnd; epartType++)
				{
					MountLoadTask mountLoadTask = this._combineMeshTask.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType)] as MountLoadTask;
					mountLoadTask.ProcessRenderComponent(this._entity);
				}
				bool flag3 = this._mainWeaponFx != null;
				if (flag3)
				{
					int i = 0;
					int num = this._mainWeaponFx.Length;
					while (i < num)
					{
						XFx xfx = this._mainWeaponFx[i];
						bool flag4 = xfx != null;
						if (flag4)
						{
							XRenderComponent.AddFx(this._entity, xfx);
						}
						i++;
					}
				}
				bool flag5 = this.sideWeaponPoint != null;
				if (flag5)
				{
					int j = 0;
					int num2 = this.sideWeaponPoint.Length;
					while (j < num2)
					{
						XFx xfx2 = this.sideWeaponFx[j];
						bool flag6 = xfx2 != null;
						if (flag6)
						{
							XRenderComponent.AddFx(this._entity, xfx2);
						}
						j++;
					}
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Character_Equipment");

		private uint _type_id;

		private int _prof_id = 0;

		public Transform _root = null;

		private XFx _rootFx = null;

		private uint _rootFxID = 0U;

		private Transform _rootPoint = null;

		private int m_mainWeaponID = 0;

		private Transform[] _mainWeaponPoint = null;

		private XFx[] _mainWeaponFx = null;

		private static int _mainWeapointSize = 2;

		private int m_sideWeaponID = 0;

		private XFx[] sideWeaponFx = null;

		private Transform[] sideWeaponPoint = null;

		private static int sideWeaponPointSize = 2;

		private XAffiliate _wing = null;

		private Transform _wingPoint = null;

		private XAffiliate _tail = null;

		private Transform _tailPoint = null;

		private XAffiliate _sprite = null;

		private Transform _spritePoint = null;

		private XAffiliate _fishing = null;

		private Transform _finshingPoint = null;

		private DefaultEquip.RowData _defaultEquipList;

		private CombineMeshTask _combineMeshTask = null;

		private uint enhanceLevel = 0U;

		private LoadFinishedCallback _LoadFinishedCallback;

		private bool _isUIAvatar = false;

		private bool _enableRealTimeShadow = false;

		private bool _enableRender = true;

		private int _renderQueue = -1;

		private bool _visible = true;

		private uint _hairColorID = 0U;

		private static CommandCallback _getSkinmeshCb = new CommandCallback(XEquipComponent._GetSkinmesh);

		private XCustomShadow m_CustomShadow = null;

		private int combineFinishFrame = 0;
	}
}
