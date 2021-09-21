using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DBF RID: 3519
	internal sealed class XDummy : XEntity, IXDummy
	{
		// Token: 0x17003360 RID: 13152
		// (get) Token: 0x0600BEA6 RID: 48806 RVA: 0x0027D658 File Offset: 0x0027B858
		public bool AutoAdded
		{
			get
			{
				return this._autoAdd;
			}
		}

		// Token: 0x17003361 RID: 13153
		// (get) Token: 0x0600BEA7 RID: 48807 RVA: 0x0027D670 File Offset: 0x0027B870
		public XShowUpComponent Show
		{
			get
			{
				return this._show;
			}
		}

		// Token: 0x17003362 RID: 13154
		// (get) Token: 0x0600BEA8 RID: 48808 RVA: 0x0027D688 File Offset: 0x0027B888
		// (set) Token: 0x0600BEA9 RID: 48809 RVA: 0x0027D690 File Offset: 0x0027B890
		public ulong RefID { get; set; }

		// Token: 0x17003363 RID: 13155
		// (get) Token: 0x0600BEAA RID: 48810 RVA: 0x0027D69C File Offset: 0x0027B89C
		public float DefaultRotation
		{
			get
			{
				return this._defaultRotation;
			}
		}

		// Token: 0x17003364 RID: 13156
		// (get) Token: 0x0600BEAB RID: 48811 RVA: 0x0027D6B4 File Offset: 0x0027B8B4
		public XOutlookData OutlookData
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x17003365 RID: 13157
		// (get) Token: 0x0600BEAC RID: 48812 RVA: 0x0027D6CC File Offset: 0x0027B8CC
		public bool IsUI
		{
			get
			{
				return this.isUI;
			}
		}

		// Token: 0x17003366 RID: 13158
		// (get) Token: 0x0600BEAD RID: 48813 RVA: 0x0027D6E4 File Offset: 0x0027B8E4
		// (set) Token: 0x0600BEAE RID: 48814 RVA: 0x0027D6FC File Offset: 0x0027B8FC
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

		// Token: 0x0600BEAF RID: 48815 RVA: 0x0027D780 File Offset: 0x0027B980
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

		// Token: 0x0600BEB0 RID: 48816 RVA: 0x0027D89C File Offset: 0x0027BA9C
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

		// Token: 0x0600BEB1 RID: 48817 RVA: 0x0027D9E8 File Offset: 0x0027BBE8
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

		// Token: 0x0600BEB2 RID: 48818 RVA: 0x0027DB2C File Offset: 0x0027BD2C
		public void SetAnimation(string anim)
		{
			base.OverrideAnimClip("Idle", anim, true, false);
		}

		// Token: 0x0600BEB3 RID: 48819 RVA: 0x0027DB40 File Offset: 0x0027BD40
		public float SetAnimationGetLength(string anim)
		{
			return base.OverrideAnimClipGetLength("Idle", anim, true);
		}

		// Token: 0x0600BEB4 RID: 48820 RVA: 0x0027DB5F File Offset: 0x0027BD5F
		public void PlaySpecifiedState(string state = "Stand")
		{
			base.Ator.CrossFade(state, 0.05f, 0, 0f);
		}

		// Token: 0x0600BEB5 RID: 48821 RVA: 0x0027DB7C File Offset: 0x0027BD7C
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

		// Token: 0x0600BEB6 RID: 48822 RVA: 0x0027DBFC File Offset: 0x0027BDFC
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

		// Token: 0x0600BEB7 RID: 48823 RVA: 0x0027DD20 File Offset: 0x0027BF20
		public override void OnDestroy()
		{
			base.OnDestroy();
			bool flag = !this._autoAdd;
			if (flag)
			{
				this.Uninitilize();
			}
		}

		// Token: 0x17003367 RID: 13159
		// (get) Token: 0x0600BEB8 RID: 48824 RVA: 0x0027DD4C File Offset: 0x0027BF4C
		public override uint PresentID
		{
			get
			{
				return this._present_id;
			}
		}

		// Token: 0x17003368 RID: 13160
		// (get) Token: 0x0600BEB9 RID: 48825 RVA: 0x0027DD64 File Offset: 0x0027BF64
		public override uint TypeID
		{
			get
			{
				return this._type_id;
			}
		}

		// Token: 0x17003369 RID: 13161
		// (get) Token: 0x0600BEBA RID: 48826 RVA: 0x0027DD7C File Offset: 0x0027BF7C
		public override ulong ID
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x0600BEBB RID: 48827 RVA: 0x0027DD94 File Offset: 0x0027BF94
		protected sealed override void Move()
		{
			base.MoveObj.Position += this._movement;
			this._movement = Vector3.zero;
		}

		// Token: 0x0600BEBC RID: 48828 RVA: 0x0027DDC0 File Offset: 0x0027BFC0
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

		// Token: 0x0600BEBD RID: 48829 RVA: 0x0027DE80 File Offset: 0x0027C080
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

		// Token: 0x0600BEBE RID: 48830 RVA: 0x0027DF70 File Offset: 0x0027C170
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

		// Token: 0x0600BEBF RID: 48831 RVA: 0x0027DFE8 File Offset: 0x0027C1E8
		public void SetupRenderQueue(IUIDummy uiDummy)
		{
			bool flag = uiDummy != null;
			if (flag)
			{
				uiDummy.Reset();
				uiDummy.RefreshRenderQueue = new RefreshRenderQueueCb(this.RenderQueueCb);
			}
		}

		// Token: 0x0600BEC0 RID: 48832 RVA: 0x0027E01C File Offset: 0x0027C21C
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

		// Token: 0x0600BEC1 RID: 48833 RVA: 0x0027E08C File Offset: 0x0027C28C
		public bool IsMainDummy()
		{
			return this._mainDummy;
		}

		// Token: 0x0600BEC2 RID: 48834 RVA: 0x0027E0A4 File Offset: 0x0027C2A4
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

		// Token: 0x04004DF7 RID: 19959
		private ulong _id = 0UL;

		// Token: 0x04004DF8 RID: 19960
		private uint _present_id;

		// Token: 0x04004DF9 RID: 19961
		private uint _type_id;

		// Token: 0x04004DFA RID: 19962
		private int srcLayer = -1;

		// Token: 0x04004DFB RID: 19963
		private bool isUI = false;

		// Token: 0x04004DFC RID: 19964
		private int renderQueue = -1;

		// Token: 0x04004DFD RID: 19965
		private bool enableUIRim = false;

		// Token: 0x04004DFE RID: 19966
		private XShowUpComponent _show = null;

		// Token: 0x04004DFF RID: 19967
		private bool _demonstration;

		// Token: 0x04004E00 RID: 19968
		private bool _autoAdd;

		// Token: 0x04004E01 RID: 19969
		private bool _mainDummy = false;

		// Token: 0x04004E02 RID: 19970
		private XOutlookData _data = null;

		// Token: 0x04004E03 RID: 19971
		public static int visibleDummyCount = 0;

		// Token: 0x04004E04 RID: 19972
		private static CommandCallback _setLayerCb = new CommandCallback(XDummy._SetLayer);

		// Token: 0x04004E05 RID: 19973
		private static CommandCallback _setRenderQueueCb = new CommandCallback(XDummy._SetRenderQueue);

		// Token: 0x04004E07 RID: 19975
		private float _defaultRotation;
	}
}
