using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XDummy : XEntity, IXDummy
	{

		public bool AutoAdded
		{
			get
			{
				return this._autoAdd;
			}
		}

		public XShowUpComponent Show
		{
			get
			{
				return this._show;
			}
		}

		public ulong RefID { get; set; }

		public float DefaultRotation
		{
			get
			{
				return this._defaultRotation;
			}
		}

		public XOutlookData OutlookData
		{
			get
			{
				return this._data;
			}
		}

		public bool IsUI
		{
			get
			{
				return this.isUI;
			}
		}

		public bool IsEnableUIRim
		{
			get
			{
				return this.enableUIRim;
			}
			set
			{
				bool flag = this.enableUIRim != value;
				if (flag)
				{
					this.enableUIRim = value;
					bool flag2 = this.enableUIRim;
					if (flag2)
					{
						XDummy.visibleDummyCount++;
					}
					else
					{
						XDummy.visibleDummyCount--;
					}
					bool flag3 = XDummy.visibleDummyCount > 0;
					if (flag3)
					{
						Shader.SetGlobalFloat("uirim", 1f);
					}
					else
					{
						Shader.SetGlobalFloat("uirim", 0f);
					}
				}
			}
		}

		public bool Initilize(uint type_id, Vector3 position, Quaternion rotation)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Dummy;
			this._id = (ulong)(((long)XSingleton<XCommon>.singleton.New_id & 1152921504606846975L) | (long)XAttributes.GetTypePrefix(EntitySpecies.Species_Dummy));
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(type_id);
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
			string value = XSingleton<XGlobalConfig>.singleton.PreFilterPrefab(byPresentID.Prefab);
			bool flag = string.IsNullOrEmpty(value);
			if (flag)
			{
				this._xobject = XGameObject.CreateXGameObject("", position, rotation, true, true);
			}
			else
			{
				this._xobject = XGameObject.CreateXGameObject("Prefabs/" + byPresentID.Prefab, position, rotation, true, true);
			}
			this._xobject.UID = this._id;
			this._xobject.Name = this._id.ToString();
			this._present_id = byID.PresentID;
			this._type_id = type_id;
			this._data = null;
			this._demonstration = false;
			this._autoAdd = false;
			return this.Initilize(0);
		}

		public bool Initilize(uint present_id, uint type_id, XOutlookData outlookData, bool autoAdd, bool demonstration, bool asyncLoad)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Dummy;
			this._id = (ulong)(((long)XSingleton<XCommon>.singleton.New_id & 1152921504606846975L) | (long)XAttributes.GetTypePrefix(EntitySpecies.Species_Dummy));
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(present_id);
			this._defaultRotation = byPresentID.UIAvatarAngle;
			string value = XSingleton<XGlobalConfig>.singleton.PreFilterPrefab(byPresentID.Prefab);
			bool flag = string.IsNullOrEmpty(value);
			if (flag)
			{
				this._xobject = XGameObject.CreateXGameObject("", asyncLoad, true);
			}
			else
			{
				this._xobject = XGameObject.CreateXGameObject("Prefabs/" + byPresentID.Prefab, asyncLoad, true);
			}
			this._xobject.UID = this._id;
			this._xobject.Name = this._id.ToString();
			this._present_id = present_id;
			this._type_id = type_id;
			this._data = outlookData;
			bool flag2 = this._data != null;
			if (flag2)
			{
				this._mainDummy = this._data.isMainDummy;
				this._data.SetProfType(this._type_id);
			}
			this._demonstration = demonstration;
			this._autoAdd = autoAdd;
			base.Scale = 1f;
			return this.Initilize(0);
		}

		public override bool Initilize(int flag)
		{
			this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
			bool demonstration = this._demonstration;
			if (demonstration)
			{
				this._machine = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XStateMachine.uuID) as XStateMachine);
				this._machine.SetDefaultState(XSingleton<XComponentMgr>.singleton.CreateComponent(this, XIdleComponent.uuID) as XIdleComponent);
				this._skill = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XSkillComponent.uuID) as XSkillComponent);
				this._show = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XShowUpComponent.uuID) as XShowUpComponent);
				this._buff = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBuffComponent.uuID) as XBuffComponent);
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XChargeComponent.uuID);
			}
			bool flag2 = this._data != null;
			if (flag2)
			{
				this._equip = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEquipComponent.uuID) as XEquipComponent);
			}
			this.ResetAnimation();
			this._xobject.Ator.cullingMode = 0;
			this._audio = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAudioComponent.uuID) as XAudioComponent);
			this._xobject.EnableCC = false;
			return true;
		}

		public void SetAnimation(string anim)
		{
			base.OverrideAnimClip("Idle", anim, true, false);
		}

		public float SetAnimationGetLength(string anim)
		{
			return base.OverrideAnimClipGetLength("Idle", anim, true);
		}

		public void PlaySpecifiedState(string state = "Stand")
		{
			base.Ator.CrossFade(state, 0.05f, 0, 0f);
		}

		public void ResetAnimation()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && base.Present.PresentLib.AttackIdle.Length > 0;
			if (flag)
			{
				base.OverrideAnimClip("Idle", base.Present.PresentLib.AttackIdle, true, false);
			}
			else
			{
				base.OverrideAnimClip("Idle", base.Present.PresentLib.Idle, true, false);
			}
		}

		public override void OnCreated()
		{
			XSingleton<XEntityMgr>.singleton.Puppets(this, false, false);
			for (int i = 0; i < base.Components.Count; i++)
			{
				bool flag = base.Components[i] != null;
				if (flag)
				{
					base.Components[i].Attached();
				}
			}
			this._layer = 19;
			base.SetCollisionLayer(this._layer);
			bool flag2 = this._equip != null;
			if (flag2)
			{
				this._equip.IsUIAvatar = this._data.uiAvatar;
				this._equip.SetEnhanceMaster(this._data.enhanceMasterLevel);
				this._equip.SetSuitFx(this._data.suitEffectID);
				this._equip.EquipFromVisibleList(this._data.OutlookList, this._data.hairColorID, this._data.suitEffectID);
				this._equip.SpriteFromData(this._data.sprite);
			}
			this._data = null;
			XSingleton<XEntityMgr>.singleton.Puppets(this, false, false);
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			bool flag = !this._autoAdd;
			if (flag)
			{
				this.Uninitilize();
			}
		}

		public override uint PresentID
		{
			get
			{
				return this._present_id;
			}
		}

		public override uint TypeID
		{
			get
			{
				return this._type_id;
			}
		}

		public override ulong ID
		{
			get
			{
				return this._id;
			}
		}

		protected sealed override void Move()
		{
			base.MoveObj.Position += this._movement;
			this._movement = Vector3.zero;
		}

		private static void _SetLayer(XGameObject gameObject, object o, int commandID)
		{
			XDummy xdummy = o as XDummy;
			bool flag = xdummy != null && gameObject != null;
			if (flag)
			{
				bool flag2 = xdummy.srcLayer < 0;
				if (!flag2)
				{
					Transform transform = gameObject.Find("");
					bool flag3 = transform != null;
					if (flag3)
					{
						XCommon.tmpRender.Clear();
						transform.GetComponentsInChildren<Renderer>(true, XCommon.tmpRender);
						int count = XCommon.tmpRender.Count;
						for (int i = 0; i < count; i++)
						{
							Renderer renderer = XCommon.tmpRender[i];
							renderer.gameObject.layer = xdummy.srcLayer;
						}
						XCommon.tmpRender.Clear();
					}
				}
			}
		}

		private static void _SetRenderQueue(XGameObject gameObject, object o, int commandID)
		{
			XDummy xdummy = o as XDummy;
			bool flag = xdummy != null && gameObject != null;
			if (flag)
			{
				Transform transform = gameObject.Find("");
				bool flag2 = transform != null;
				if (flag2)
				{
					transform.GetComponentsInChildren<Renderer>(XCommon.tmpRender);
					int count = XCommon.tmpRender.Count;
					for (int i = 0; i < count; i++)
					{
						Renderer renderer = XCommon.tmpRender[i];
						bool flag3 = renderer.CompareTag("BindedRes") || renderer.CompareTag("Mount_BindedRes");
						if (flag3)
						{
							int j = 0;
							int num = renderer.materials.Length;
							while (j < num)
							{
								renderer.materials[j].renderQueue = xdummy.renderQueue;
								j++;
							}
						}
					}
					XCommon.tmpRender.Clear();
				}
			}
		}

		public void SetupUIDummy(bool ui)
		{
			this.isUI = ui;
			this.srcLayer = (this.isUI ? XQualitySetting.UILayer : this._xobject.Layer);
			bool flag = this._equip != null;
			if (flag)
			{
				this._equip.IsUIAvatar = ui;
			}
			else
			{
				bool flag2 = this._xobject != null;
				if (flag2)
				{
					this._xobject.CallCommand(XDummy._setLayerCb, this, -1, false);
				}
			}
		}

		public void SetupRenderQueue(IUIDummy uiDummy)
		{
			bool flag = uiDummy != null;
			if (flag)
			{
				uiDummy.Reset();
				uiDummy.RefreshRenderQueue = new RefreshRenderQueueCb(this.RenderQueueCb);
			}
		}

		private void RenderQueueCb(int rq)
		{
			bool flag = this.renderQueue != rq;
			if (flag)
			{
				this.renderQueue = rq;
				bool flag2 = this._equip != null;
				if (flag2)
				{
					this._equip.SetRenderQueue(this.renderQueue);
				}
				else
				{
					bool flag3 = this._xobject != null;
					if (flag3)
					{
						this._xobject.CallCommand(XDummy._setRenderQueueCb, this, -1, false);
					}
				}
			}
		}

		public bool IsMainDummy()
		{
			return this._mainDummy;
		}

		public void SetOutlook(XOutlookData outlookData)
		{
			bool flag = this._equip != null && outlookData != null;
			if (flag)
			{
				this._equip.IsUIAvatar = outlookData.uiAvatar;
				this._equip.SetEnhanceMaster(outlookData.enhanceMasterLevel);
				this._equip.SetSuitFx(outlookData.suitEffectID);
				this._equip.EquipFromVisibleList(outlookData.OutlookList, outlookData.hairColorID, outlookData.suitEffectID);
				this._equip.SpriteFromData(outlookData.sprite);
			}
		}

		private ulong _id = 0UL;

		private uint _present_id;

		private uint _type_id;

		private int srcLayer = -1;

		private bool isUI = false;

		private int renderQueue = -1;

		private bool enableUIRim = false;

		private XShowUpComponent _show = null;

		private bool _demonstration;

		private bool _autoAdd;

		private bool _mainDummy = false;

		private XOutlookData _data = null;

		public static int visibleDummyCount = 0;

		private static CommandCallback _setLayerCb = new CommandCallback(XDummy._SetLayer);

		private static CommandCallback _setRenderQueueCb = new CommandCallback(XDummy._SetRenderQueue);

		private float _defaultRotation;
	}
}
