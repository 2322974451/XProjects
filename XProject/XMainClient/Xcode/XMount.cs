using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMount : XEntity
	{

		public override string Prefab
		{
			get
			{
				return this._present.PresentLib.Prefab;
			}
		}

		public bool HasTurnPresetation
		{
			get
			{
				return this._has_turn_anims;
			}
		}

		public int AngularSpeed
		{
			get
			{
				return this._present.PresentLib.AngluarSpeed;
			}
		}

		public XEntity Copilot
		{
			get
			{
				bool flag = this._copilot_enabled && this._mount_component != null;
				XEntity result;
				if (flag)
				{
					result = this._mount_component.Copilot;
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		private static void _Init(XGameObject gameObject, object o, int commandID)
		{
			XMount xmount = o as XMount;
			bool flag = xmount._mainbody == null || xmount._commandID != commandID;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("assert error mount:", xmount.Name, null, null, null, null);
			}
			else
			{
				uint num = XSingleton<XCommon>.singleton.XHash(xmount._prefab);
				Transform transform = gameObject.Find("");
				Vector3 zero = Vector3.zero;
				xmount._mountPoint0 = XEquipDocument.GetMountPoint(transform, "Seat_horse");
				bool flag2 = xmount._mountPoint0 == null;
				if (flag2)
				{
					zero.y = 0.8f;
					xmount._mountPoint0 = transform;
				}
				xmount._mountPoint1 = XEquipDocument.GetMountPoint(transform, "Seat_follow");
				bool flag3 = xmount._mountPoint1 == null;
				if (flag3)
				{
					xmount._mountPoint1 = transform;
				}
				bool flag4 = !XMount._basic_rotation.TryGetValue(num, out xmount._init_rotation0) && xmount._mountPoint0 != null;
				if (flag4)
				{
					xmount._init_rotation0 = xmount._mountPoint0.localRotation;
					XMount._basic_rotation.Add(num, xmount._init_rotation0);
				}
				bool flag5 = !XMount._basic_rotation.TryGetValue(num + 1U, out xmount._init_rotation1) && xmount._mountPoint1 != null;
				if (flag5)
				{
					xmount._init_rotation1 = xmount._mountPoint1.localRotation;
					XMount._basic_rotation.Add(num + 1U, xmount._init_rotation1);
				}
				int layer = xmount._mainbody.DefaultLayer;
				bool flag6 = xmount._mainbody is XDummy;
				if (flag6)
				{
					XDummy xdummy = xmount._mainbody as XDummy;
					bool isUI = xdummy.IsUI;
					if (isUI)
					{
						layer = XQualitySetting.UILayer;
					}
				}
				GameObject gameObject2 = gameObject.Get();
				bool flag7 = XMount.ForceDisableEffect(xmount._mainbody);
				XCommon.tmpRender.Clear();
				gameObject2.GetComponentsInChildren<Renderer>(XCommon.tmpRender);
				int count = XCommon.tmpRender.Count;
				int i = 0;
				while (i < count)
				{
					Renderer renderer = XCommon.tmpRender[i];
					GameObject gameObject3 = renderer.gameObject;
					string tag = renderer.gameObject.tag;
					bool flag8 = gameObject3.CompareTag("Mount_BindedRes");
					bool flag9 = gameObject3.CompareTag("Mount") || flag8;
					if (flag9)
					{
						bool flag10 = flag7 && flag8;
						if (flag10)
						{
							renderer.enabled = false;
						}
						else
						{
							bool flag11 = renderer is SkinnedMeshRenderer;
							if (flag11)
							{
								xmount._Render = renderer;
							}
							renderer.gameObject.layer = layer;
							XRenderComponent.AddMountObj(xmount._mainbody, gameObject2, renderer);
						}
					}
					IL_28D:
					i++;
					continue;
					goto IL_28D;
				}
				XCommon.tmpRender.Clear();
				bool flag12 = xmount._mount_component != null;
				if (flag12)
				{
					xmount._mount_component.RealMount(xmount._mountPoint0, zero, ref xmount._init_rotation0, xmount.Scale);
					xmount._mount_component.RealMountCopilot(xmount._mountPoint1, Vector3.zero, ref xmount._init_rotation1, xmount.Scale);
				}
				xmount.RealMountFx(xmount._specialFx, false);
				xmount.RealMountFx(xmount._specialCopilotFx, true);
			}
		}

		public bool Initilize(XEntity mainbody, uint present_id, bool isCopilot)
		{
			this._eEntity_Type |= XEntity.EnitityType.Entity_Mount;
			this._copilot_enabled = isCopilot;
			this._mainbody = mainbody;
			this._layer = this._mainbody.DefaultLayer;
			this._present_id = present_id;
			this._castShadow = (((this._mainbody.Transformee != null) ? this._mainbody.Transformee.IsPlayer : this._mainbody.IsPlayer) && XQualitySetting._CastShadow);
			this._prefab = "Prefabs/" + XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(present_id).Prefab;
			bool flag = !isCopilot && this._mainbody.Equipment != null && !this._mainbody.Equipment.IsVisible;
			if (flag)
			{
				this._xobject = XGameObject.CreateXGameObject("Prefabs/Empty_Mount", true, true);
			}
			else
			{
				this._xobject = XGameObject.CreateXGameObject(this._prefab, true, true);
			}
			this._xobject.Name = "mount_" + this._mainbody.ID.ToString();
			this._xobject.Tag = this._mainbody.EngineObject.Tag;
			this._xobject.Layer = this._mainbody.EngineObject.Layer;
			Vector3 position = this._mainbody.EngineObject.Position;
			position.y += 0.05f;
			this._xobject.Position = position;
			this._xobject.Rotation = this._mainbody.EngineObject.Rotation;
			bool result = this.Initilize(0);
			this._xobject.EnableBC = this._mainbody.EngineObject.EnableBC;
			this._xobject.EnableCC = this._mainbody.EngineObject.EnableCC;
			return result;
		}

		public override bool Initilize(int flag)
		{
			this._present = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XPresentComponent.uuID) as XPresentComponent);
			this._mount_component = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMountComponent.uuID) as XMountComponent);
			this._has_turn_anims = (!string.IsNullOrEmpty(base.Present.PresentLib.RunLeft) && !string.IsNullOrEmpty(base.Present.PresentLib.RunRight));
			bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && !string.IsNullOrEmpty(base.Present.PresentLib.AttackIdle);
			if (flag2)
			{
				base.OverrideAnimClip("Idle", base.Present.PresentLib.AttackIdle, true, false);
				base.OverrideAnimClip("Walk", base.Present.PresentLib.AttackWalk, true, false);
				base.OverrideAnimClip("Run", base.Present.PresentLib.AttackRun, true, false);
				bool has_turn_anims = this._has_turn_anims;
				if (has_turn_anims)
				{
					base.OverrideAnimClip("RunLeft", base.Present.PresentLib.AttackRunLeft, true, false);
					base.OverrideAnimClip("RunRight", base.Present.PresentLib.AttackRunRight, true, false);
				}
			}
			else
			{
				base.OverrideAnimClip("Idle", base.Present.PresentLib.Idle, true, false);
				base.OverrideAnimClip("Walk", base.Present.PresentLib.Walk, true, false);
				base.OverrideAnimClip("Run", base.Present.PresentLib.Run, true, false);
				bool has_turn_anims2 = this._has_turn_anims;
				if (has_turn_anims2)
				{
					base.OverrideAnimClip("RunLeft", base.Present.PresentLib.RunLeft, true, false);
					base.OverrideAnimClip("RunRight", base.Present.PresentLib.RunRight, true, false);
				}
			}
			return true;
		}

		public override uint PresentID
		{
			get
			{
				return this._present_id;
			}
		}

		public override void OnCreated()
		{
			base.OnCreated();
			this._mount_component.PreMount(this._mainbody);
			this._commandID = XEngineCommand.GetCommandID();
			this._xobject.CallCommand(XMount._initCb, this, this._commandID, true);
			this.InnerPlayFx();
			base.SetCollisionLayer(this._layer);
		}

		public override void OnDestroy()
		{
			bool flag = this._xobject != null;
			if (flag)
			{
				XRenderComponent.RemoveObj(this._mainbody, this._xobject.Get());
			}
			this._mainbody = null;
			this._commandID = -1;
			this._mountPoint0 = null;
			this._mountPoint1 = null;
			base.OnDestroy();
			this.Uninitilize();
		}

		public override bool CastFakeShadow()
		{
			return this._mainbody.CastFakeShadow();
		}

		private void InnerPlayFx()
		{
			bool flag = this._fx != "";
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.CreateAndPlay(this._fx, this.EngineObject, Vector3.zero, Vector3.one, 1f, false, 3f, true);
				this._fx = "";
			}
		}

		public void PlayFx(string fx)
		{
			this._fx = fx;
			this.InnerPlayFx();
		}

		public void UnMountEntity(XEntity entity)
		{
			bool flag = this._mount_component != null;
			if (flag)
			{
				this._mount_component.UnMount(entity);
			}
		}

		public void UnMountAll()
		{
			bool flag = this._mount_component != null;
			if (flag)
			{
				this._mount_component.UnMountAll();
			}
		}

		public bool MountCopilot(XEntity entity)
		{
			bool copilot_enabled = this._copilot_enabled;
			bool result;
			if (copilot_enabled)
			{
				bool flag = this._mount_component != null;
				if (flag)
				{
					bool flag2 = this._mount_component.PreMountCopilot(entity);
					bool flag3 = this._mountPoint1 != null;
					if (flag3)
					{
						this._mount_component.RealMountCopilot(this._mountPoint1, Vector3.zero, ref this._init_rotation1, base.Scale);
					}
					result = flag2;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Mountee ", this.ID.ToString(), " does not support a copilot.", null, null, null);
				result = false;
			}
			return result;
		}

		public float GetRadius()
		{
			bool flag = this._Render != null;
			float result;
			if (flag)
			{
				Vector3 extents = this._Render.bounds.extents;
				float num = (extents.x > extents.y) ? extents.x : extents.y;
				num = ((num > extents.z) ? num : extents.z);
				result = num;
			}
			else
			{
				result = -1f;
			}
			return result;
		}

		private static bool ForceDisableEffect(XEntity e)
		{
			return !XQualitySetting.GetQuality(EFun.ECommonHigh) && !e.IsPlayer;
		}

		public void SetActive(bool enable)
		{
			bool flag = this._xobject != null && this._xobject.IsLoaded;
			if (flag)
			{
				GameObject gameObject = this._xobject.Get();
				bool flag2 = gameObject != null;
				if (flag2)
				{
					bool flag3 = XMount.ForceDisableEffect(this._mainbody);
					XCommon.tmpRender.Clear();
					gameObject.GetComponentsInChildren<Renderer>(XCommon.tmpRender);
					int count = XCommon.tmpRender.Count;
					for (int i = 0; i < count; i++)
					{
						Renderer renderer = XCommon.tmpRender[i];
						string tag = renderer.gameObject.tag;
						bool flag4 = tag.StartsWith("Mount");
						if (flag4)
						{
							bool flag5 = flag3 && tag.StartsWith("Mount_BindedRes");
							if (flag5)
							{
								renderer.enabled = false;
							}
							else
							{
								renderer.enabled = enable;
							}
						}
					}
					XCommon.tmpRender.Clear();
				}
			}
		}

		private void RealMountFx(XFx fx, bool copilot)
		{
			bool flag = fx != null;
			if (flag)
			{
				Transform transform;
				if (copilot)
				{
					transform = this._mountPoint1;
				}
				else
				{
					transform = this._mountPoint0;
				}
				fx.SetParent(this._xobject.Find(""), (transform != null) ? transform.localPosition : Vector3.zero, Quaternion.identity, Vector3.one);
			}
		}

		public void MountFx(XFx fx, bool copilot)
		{
			if (copilot)
			{
				this._specialCopilotFx = fx;
			}
			else
			{
				this._specialFx = fx;
			}
			bool flag = this._xobject != null && this._xobject.IsLoaded;
			if (flag)
			{
				this.RealMountFx(fx, copilot);
			}
		}

		private static Dictionary<uint, Quaternion> _basic_rotation = new Dictionary<uint, Quaternion>();

		private uint _present_id;

		private int _commandID = -1;

		private XEntity _mainbody = null;

		private Renderer _Render = null;

		private bool _castShadow = false;

		private bool _copilot_enabled = false;

		private string _prefab;

		private bool _has_turn_anims = false;

		private Transform _mountPoint0 = null;

		private Transform _mountPoint1 = null;

		private XFx _specialFx = null;

		private XFx _specialCopilotFx = null;

		private Quaternion _init_rotation0 = Quaternion.identity;

		private Quaternion _init_rotation1 = Quaternion.identity;

		protected XMountComponent _mount_component = null;

		private string _fx = "";

		private static CommandCallback _initCb = new CommandCallback(XMount._Init);
	}
}
