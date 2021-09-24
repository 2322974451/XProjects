using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRenderComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XRenderComponent.uuID;
			}
		}

		public XRenderComponent()
		{
			this._onHitBackCb = new XTimerMgr.ElapsedEventHandler(this.OnHitBack);
		}

		public static bool HasRenderComponent(XEntity e, bool hasFadeEffect)
		{
			return (e.IsRole && !e.IsPlayer && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall) || (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && hasFadeEffect);
		}

		public static XRenderComponent AddRenderComponent(XEntity e)
		{
			bool flag = XSingleton<XScene>.singleton.CanFadeOnCreate && !e.IsRole && !e.IsPuppet && (e.SkillMgr == null || e.Present.PresentLib.Appear == "");
			bool flag2 = (EntityMask.Fade & e.Attributes.Tag) > 0U;
			bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && (flag || e.IsRole) && XQualitySetting.GetQuality(EFun.EFadeInOut);
			if (flag3)
			{
				flag2 = true;
			}
			bool flag4 = XRenderComponent.HasRenderComponent(e, flag2);
			XRenderComponent result;
			if (flag4)
			{
				XRenderComponent xrenderComponent = XSingleton<XComponentMgr>.singleton.CreateComponent(e, XRenderComponent.uuID) as XRenderComponent;
				bool flag5 = xrenderComponent != null;
				if (flag5)
				{
					xrenderComponent._fadeOnCreate = flag;
					xrenderComponent._fadeEffect = flag2;
					bool flag6 = e.IsRole && XSingleton<XScene>.singleton.IsViewGridScene;
					if (flag6)
					{
						xrenderComponent._action = XRenderComponent.RenderAction.DistanceFade;
						xrenderComponent._fadeState = XRenderComponent.FadeState.InVisible;
					}
					else
					{
						xrenderComponent._fadeState = XRenderComponent.FadeState.Visible;
					}
				}
				result = xrenderComponent;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void SetEntityLayer(int initLayer)
		{
			this._currentLayer = initLayer;
		}

		public void PostCreateComponent()
		{
			bool flag = this._entity.IsRole && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this._target_part_flag = 1;
				bool flag2 = this._entity.Attributes.Outlook.state.type == OutLookStateType.OutLook_RidePet;
				if (flag2)
				{
					this._target_part_flag += 4;
				}
				bool quality = XQualitySetting.GetQuality(EFun.ERoleShadow);
				if (quality)
				{
					this._target_part_flag += 2;
				}
			}
		}

		private void AddObject(GameObject mainGo, Renderer render)
		{
			bool flag = render != null;
			if (flag)
			{
				int renderLayer = (this._fadeState == XRenderComponent.FadeState.InVisible) ? XQualitySetting.InVisiblityLayer : this._currentLayer;
				bool flag2 = !this._fadeEffect || render.CompareTag("BindedRes") || render.CompareTag("Mount_BindedRes") || render.CompareTag("Shadow");
				if (flag2)
				{
					UnFadeObject unFadeObject = new UnFadeObject();
					unFadeObject.InstanceID = mainGo.GetInstanceID();
					unFadeObject.renderGO = render.gameObject;
					unFadeObject.SetRenderLayer(renderLayer);
					this.renderObjs.Add(unFadeObject);
				}
				else
				{
					Material material = render.material;
					bool flag3 = material != null;
					if (flag3)
					{
						MatPackage matPack = MatPackage.GetMatPack(material, render);
						matPack.InstanceID = mainGo.GetInstanceID();
						matPack.SetRenderLayer(renderLayer);
						this.renderObjs.Add(matPack);
					}
				}
			}
		}

		private void RemoveObject(int instanceID)
		{
			for (int i = this.renderObjs.Count - 1; i >= 0; i--)
			{
				IRenderObject renderObject = this.renderObjs[i];
				bool flag = renderObject.IsSameObj(instanceID);
				if (flag)
				{
					renderObject.SetRenderLayer(this._entity.DefaultLayer);
					renderObject.ResetShader();
					this.renderObjs.RemoveAt(i);
				}
			}
		}

		public static void AddEquipObj(XEntity e, GameObject mainGo, Renderer render)
		{
			bool flag = e != null && mainGo != null && render != null;
			if (flag)
			{
				XRenderComponent renderer = e.Renderer;
				bool flag2 = renderer != null;
				if (flag2)
				{
					renderer._load_part_flag |= XFastEnumIntEqualityComparer<XRenderComponent.LoadPart>.ToInt(XRenderComponent.LoadPart.Equip);
					renderer.AddObject(mainGo, render);
				}
			}
		}

		public static void AddFx(XEntity e, XFx fx)
		{
			bool flag = e != null && fx != null;
			if (flag)
			{
				XRenderComponent renderer = e.Renderer;
				bool flag2 = renderer != null;
				if (flag2)
				{
					int renderLayer = (renderer._fadeState == XRenderComponent.FadeState.InVisible) ? XQualitySetting.InVisiblityLayer : renderer._currentLayer;
					bool flag3 = renderer._type == XRenderComponent.FadeType.FadeOut;
					if (flag3)
					{
						renderLayer = XQualitySetting.InVisiblityLayer;
					}
					fx.SetRenderLayer(renderLayer);
					renderer.renderObjs.Add(fx);
				}
			}
		}

		public static void RemoveObj(XEntity e, GameObject go)
		{
			bool flag = e != null && go != null;
			if (flag)
			{
				XRenderComponent renderer = e.Renderer;
				bool flag2 = renderer != null;
				if (flag2)
				{
					renderer.RemoveObject(go.GetInstanceID());
				}
			}
		}

		public static void RemoveFx(XEntity e, XFx fx)
		{
			bool flag = e != null && fx != null;
			if (flag)
			{
				XRenderComponent renderer = e.Renderer;
				bool flag2 = renderer != null;
				if (flag2)
				{
					renderer.RemoveObject(fx._instanceID);
				}
			}
		}

		public static void AddShadowObj(XEntity e, GameObject mainGo, Renderer render)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && e != null;
			if (flag)
			{
				XRenderComponent renderer = e.Renderer;
				bool flag2 = renderer != null;
				if (flag2)
				{
					renderer._load_part_flag |= XFastEnumIntEqualityComparer<XRenderComponent.LoadPart>.ToInt(XRenderComponent.LoadPart.Shadow);
					renderer.AddObject(mainGo, render);
				}
			}
		}

		public static void AddMountObj(XEntity e, GameObject mainGo, Renderer render)
		{
			bool flag = e != null;
			if (flag)
			{
				XRenderComponent renderer = e.Renderer;
				bool flag2 = renderer != null;
				if (flag2)
				{
					int num = XFastEnumIntEqualityComparer<XRenderComponent.LoadPart>.ToInt(XRenderComponent.LoadPart.Mount);
					bool flag3 = (renderer._target_part_flag & num) != 0 && e.Attributes.Outlook.state.type == OutLookStateType.OutLook_RidePet;
					if (flag3)
					{
						renderer._load_part_flag |= num;
					}
					renderer.AddObject(mainGo, render);
				}
			}
		}

		public static void OnHit(XEntity e)
		{
			bool flag = e != null;
			if (flag)
			{
				XRenderComponent renderer = e.Renderer;
				bool flag2 = renderer != null;
				if (flag2)
				{
					bool flag3 = renderer._action > XRenderComponent.RenderAction.None;
					if (!flag3)
					{
						renderer.SetShader(XRenderComponent.RenderAction.HitRender, XRenderComponent.hitColor);
						XSingleton<XTimerMgr>.singleton.KillTimer(renderer._timerToken);
						renderer._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, renderer._onHitBackCb, null);
					}
				}
			}
		}

		private static XRenderComponent DynamicAddRenderComp(XEntity e, bool hide)
		{
			XRenderComponent xrenderComponent = XSingleton<XComponentMgr>.singleton.CreateComponent(e, XRenderComponent.uuID) as XRenderComponent;
			bool flag = xrenderComponent != null;
			if (flag)
			{
				e.Renderer = xrenderComponent;
				xrenderComponent._fadeOnCreate = false;
				xrenderComponent._fadeEffect = true;
				xrenderComponent._fadeState = (hide ? XRenderComponent.FadeState.InVisible : XRenderComponent.FadeState.Visible);
				bool flag2 = e.Equipment != null;
				if (flag2)
				{
					e.Equipment.RefreshRenderObj();
				}
				else
				{
					e.EngineObject.CallCommand(XRenderComponent._initCb, xrenderComponent, -1, false);
				}
			}
			return xrenderComponent;
		}

		public static void OnFade(XEntity e, bool fadeIn, float time, bool isVisibleAfterFadeout)
		{
			bool flag = e != null;
			if (flag)
			{
				XRenderComponent xrenderComponent = e.Renderer;
				bool flag2 = xrenderComponent == null;
				if (flag2)
				{
					xrenderComponent = XRenderComponent.DynamicAddRenderComp(e, false);
				}
				bool flag3 = xrenderComponent != null;
				if (flag3)
				{
					xrenderComponent._InFadeState = !fadeIn;
					xrenderComponent.InitFade(fadeIn ? XRenderComponent.FadeType.FadeIn : XRenderComponent.FadeType.FadeOut, time, isVisibleAfterFadeout ? 50 : 0);
				}
			}
		}

		public static void OnHide(XEntity e, bool hide)
		{
			bool flag = e != null;
			if (flag)
			{
				XRenderComponent renderer = e.Renderer;
				bool flag2 = renderer != null;
				if (flag2)
				{
					renderer._fadeState = (hide ? XRenderComponent.FadeState.InVisible : XRenderComponent.FadeState.Visible);
					renderer._action = XRenderComponent.RenderAction.None;
					renderer.ResetShader();
					int layer = hide ? XQualitySetting.InVisiblityLayer : renderer._currentLayer;
					renderer.SetLayer(layer);
				}
				else
				{
					XRenderComponent.DynamicAddRenderComp(e, hide);
				}
			}
		}

		private void OnFade()
		{
			Color32 color = XRenderComponent.fadeColor;
			color.a = (byte)this._targetFadeColor;
			this.SetShader(XRenderComponent.RenderAction.Fade, color);
			this._action = XRenderComponent.RenderAction.None;
			int layer = (this._targetFadeColor == 0) ? XQualitySetting.InVisiblityLayer : this._currentLayer;
			this.SetLayer(layer);
		}

		public static void OnTransform(XEntity src, XEntity target, bool to)
		{
			XRenderComponent renderer = src.Renderer;
			XRenderComponent renderer2 = target.Renderer;
			bool flag = renderer != null;
			if (flag)
			{
				bool flag2 = renderer._action == XRenderComponent.RenderAction.DistanceFade;
				if (flag2)
				{
					if (to)
					{
						src.EngineObject.Layer = src.DefaultLayer;
						renderer._fadeState = XRenderComponent.FadeState.Visible;
					}
				}
				else
				{
					bool inFadeState = renderer._InFadeState;
					if (inFadeState)
					{
						XRenderComponent.OnFade(target, false, renderer._time, renderer._targetFadeColor != 0);
					}
					else
					{
						bool flag3 = renderer2 != null;
						if (flag3)
						{
							renderer2.FadeInImmediately();
						}
					}
				}
			}
		}

		private void InitFade(XRenderComponent.FadeType fadeType, float time, int targetColor)
		{
			this._type = fadeType;
			this._time = time;
			this._elapsed = 0f;
			this._targetFadeColor = targetColor;
			bool flag = this._type == XRenderComponent.FadeType.FadeIn;
			if (flag)
			{
				this.SetLayer(this._currentLayer);
			}
			this.SetShader(XRenderComponent.RenderAction.Fade, XRenderComponent.fadeColor);
		}

		private void SetLayer(int layer)
		{
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.SetRenderLayer(layer);
			}
		}

		public void FadeInImmediately()
		{
			this._action = XRenderComponent.RenderAction.None;
			this._time = 0f;
			this._elapsed = 0f;
			this._type = XRenderComponent.FadeType.NotFade;
			this.ResetShader();
		}

		private void OnHitBack(object o)
		{
			bool flag = this._action == XRenderComponent.RenderAction.HitRender;
			if (flag)
			{
				this._action = XRenderComponent.RenderAction.None;
				this.ResetShader();
			}
		}

		private void SetFade(Color32 c, byte a)
		{
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.SetColor(c.r, c.g, c.b, a);
			}
		}

		private void SetShader(XRenderComponent.RenderAction action, Color32 color)
		{
			this._action = action;
			int shader = 0;
			XRenderComponent.RenderAction action2 = this._action;
			if (action2 - XRenderComponent.RenderAction.HitRender > 1)
			{
				if (action2 - XRenderComponent.RenderAction.Fade <= 1)
				{
					shader = 0;
				}
			}
			else
			{
				shader = 1;
			}
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.SetShader(shader);
				renderObject.SetColor(color);
			}
		}

		private void ResetShader()
		{
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.ResetShader();
			}
		}

		private void DistanceFade()
		{
			switch (this._fadeState)
			{
			case XRenderComponent.FadeState.Visible:
			{
				Vector3 position = XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position;
				Vector3 position2 = this._entity.MoveObj.Position;
				float num = (position2.x - position.x) * (position2.x - position.x) + (position2.z - position.z) * (position2.z - position.z);
				bool flag = num > XQualitySetting._FadeDistance;
				if (flag)
				{
					this._time = 0.5f;
					this._elapsed = 0f;
					this._type = XRenderComponent.FadeType.FadeOut;
					this._fadeState = XRenderComponent.FadeState.Fading;
					this.SetShader(XRenderComponent.RenderAction.DistanceFade, XRenderComponent.fadeColor);
				}
				break;
			}
			case XRenderComponent.FadeState.Fading:
			{
				bool flag2 = this._type == XRenderComponent.FadeType.FadeIn;
				int renderLayer = flag2 ? this._currentLayer : XQualitySetting.InVisiblityLayer;
				for (int i = 0; i < this.renderObjs.Count; i++)
				{
					IRenderObject renderObject = this.renderObjs[i];
					renderObject.ResetShader();
					renderObject.SetRenderLayer(renderLayer);
				}
				this._fadeState = (flag2 ? XRenderComponent.FadeState.Visible : XRenderComponent.FadeState.InVisible);
				this._type = XRenderComponent.FadeType.NotFade;
				break;
			}
			case XRenderComponent.FadeState.InVisible:
			{
				Vector3 position3 = XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position;
				Vector3 position4 = this._entity.MoveObj.Position;
				float num2 = (position4.x - position3.x) * (position4.x - position3.x) + (position4.z - position3.z) * (position4.z - position3.z);
				bool flag3 = num2 < XQualitySetting._FadeDistance - 2f;
				if (flag3)
				{
					bool flag4 = this._entity.Ator != null;
					if (flag4)
					{
						this._entity.Ator.enabled = true;
					}
					this._time = 1f;
					this._elapsed = 0f;
					this._type = XRenderComponent.FadeType.FadeIn;
					this.SetShader(XRenderComponent.RenderAction.DistanceFade, XRenderComponent.fadeColor);
					for (int j = 0; j < this.renderObjs.Count; j++)
					{
						IRenderObject renderObject2 = this.renderObjs[j];
						renderObject2.SetColor(XRenderComponent.fadeColor.r, XRenderComponent.fadeColor.g, XRenderComponent.fadeColor.b, 0);
						renderObject2.SetRenderLayer(this._currentLayer);
					}
					bool flag5 = this._entity.Ator != null;
					if (flag5)
					{
						this._entity.Ator.enabled = true;
					}
					this._fadeState = XRenderComponent.FadeState.Fading;
					this._entity.Ator.ResetTrigger();
				}
				break;
			}
			}
		}

		public override void OnDetachFromHost()
		{
			bool flag = this._timerToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
			}
			this._action = XRenderComponent.RenderAction.None;
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.ResetShader();
				renderObject.SetRenderLayer(this._entity.DefaultLayer);
				renderObject.Clean();
			}
			this.renderObjs.Clear();
			this._load_part_flag = 0;
			this._target_part_flag = 0;
			this._currentLayer = XRole.RoleLayer;
			this._fadeOnCreate = false;
			this._fadeEffect = false;
			this._InFadeState = false;
			this._type = XRenderComponent.FadeType.FadeIn;
			this._fadeState = XRenderComponent.FadeState.Visible;
			this._elapsed = 0f;
			this._time = 0f;
			this._targetFadeColor = 0;
			this._timerToken = 0U;
			this._blinkValue = 0.01f;
			this._blinkDelta = 0.01f;
			base.OnDetachFromHost();
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_FadeIn, new XComponent.XEventHandler(this.OnIn));
			base.RegisterEvent(XEventDefine.XEvent_FadeOut, new XComponent.XEventHandler(this.OnOut));
			base.RegisterEvent(XEventDefine.XEvent_Highlight, new XComponent.XEventHandler(this.HighlightSelf));
		}

		private static void _Init(XGameObject gameObject, object o, int commandID)
		{
			XRenderComponent xrenderComponent = o as XRenderComponent;
			GameObject gameObject2 = gameObject.Get();
			XCommon.tmpRender.Clear();
			gameObject2.GetComponentsInChildren<Renderer>(XCommon.tmpRender);
			int count = XCommon.tmpRender.Count;
			for (int i = 0; i < count; i++)
			{
				Renderer renderer = XCommon.tmpRender[i];
				bool flag = !renderer.CompareTag("Shadow");
				if (flag)
				{
					xrenderComponent.AddObject(gameObject2, renderer);
				}
			}
			XCommon.tmpRender.Clear();
			bool flag2 = xrenderComponent._fadeState == XRenderComponent.FadeState.InVisible;
			if (flag2)
			{
				xrenderComponent.ResetShader();
				xrenderComponent.SetLayer(XQualitySetting.InVisiblityLayer);
			}
			else
			{
				bool inFadeState = xrenderComponent._InFadeState;
				if (inFadeState)
				{
					xrenderComponent.OnFade();
				}
				else
				{
					bool fadeOnCreate = xrenderComponent._fadeOnCreate;
					if (fadeOnCreate)
					{
						xrenderComponent.InitFade(XRenderComponent.FadeType.FadeIn, 1f, 255);
						xrenderComponent.SetFade(XRenderComponent.fadeColor, 0);
					}
				}
			}
		}

		public override void Attached()
		{
			bool flag = this._entity.Equipment == null && (this._fadeEffect || this._fadeOnCreate);
			if (flag)
			{
				this._entity.EngineObject.CallCommand(XRenderComponent._initCb, this, -1, false);
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool isTransform = this._entity.IsTransform;
			if (!isTransform)
			{
				bool flag = true;
				bool flag2 = this._type > XRenderComponent.FadeType.NotFade;
				if (flag2)
				{
					flag = false;
					this._elapsed += fDeltaT;
					bool flag3 = this._elapsed < this._time;
					if (flag3)
					{
						XRenderComponent.FadeType type = this._type;
						if (type != XRenderComponent.FadeType.FadeIn)
						{
							if (type == XRenderComponent.FadeType.FadeOut)
							{
								float num = (float)(255 - this._targetFadeColor) * (this._time - this._elapsed) / this._time + (float)this._targetFadeColor;
								this.SetFade(XRenderComponent.fadeColor, (byte)num);
							}
						}
						else
						{
							this.SetFade(XRenderComponent.fadeColor, (byte)(255f * this._elapsed / this._time));
						}
					}
					else
					{
						flag = true;
					}
				}
				bool flag4 = flag;
				if (flag4)
				{
					switch (this._action)
					{
					case XRenderComponent.RenderAction.Blink:
					{
						this._blinkValue += this._blinkDelta;
						bool flag5 = this._blinkValue > 0.4f;
						if (flag5)
						{
							this._blinkDelta = -0.01f;
						}
						bool flag6 = this._blinkValue < 0.2f;
						if (flag6)
						{
							this._blinkDelta = 0.01f;
						}
						float num2 = (this._blinkValue > 0.4f) ? 0.4f : this._blinkValue;
						byte b = (byte)(255f * num2);
						for (int i = 0; i < this.renderObjs.Count; i++)
						{
							IRenderObject renderObject = this.renderObjs[i];
							renderObject.SetColor(b, b, b, b);
						}
						break;
					}
					case XRenderComponent.RenderAction.Fade:
					{
						bool flag7 = flag;
						if (flag7)
						{
							bool flag8 = this._type == XRenderComponent.FadeType.FadeIn;
							if (flag8)
							{
								this.ResetShader();
								this._fadeState = XRenderComponent.FadeState.Visible;
							}
							else
							{
								bool flag9 = this._type == XRenderComponent.FadeType.FadeOut;
								if (flag9)
								{
									this._fadeState = ((this._targetFadeColor == 0) ? XRenderComponent.FadeState.InVisible : XRenderComponent.FadeState.Visible);
									int layer = (this._targetFadeColor == 0) ? XQualitySetting.InVisiblityLayer : this._currentLayer;
									this.SetLayer(layer);
								}
							}
							this._type = XRenderComponent.FadeType.NotFade;
							this._action = XRenderComponent.RenderAction.None;
						}
						break;
					}
					case XRenderComponent.RenderAction.DistanceFade:
					{
						bool flag10 = this._target_part_flag == this._load_part_flag && XSingleton<XTimerMgr>.singleton.NeedFixedUpdate;
						if (flag10)
						{
							this.DistanceFade();
						}
						break;
					}
					}
				}
				for (int j = 0; j < this.renderObjs.Count; j++)
				{
					IRenderObject renderObject2 = this.renderObjs[j];
					renderObject2.Update();
				}
			}
		}

		protected bool OnIn(XEventArgs e)
		{
			XFadeInEventArgs xfadeInEventArgs = e as XFadeInEventArgs;
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.SetRenderLayer(this._currentLayer);
			}
			return true;
		}

		protected bool OnOut(XEventArgs e)
		{
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.SetRenderLayer(XQualitySetting.InVisiblityLayer);
			}
			return true;
		}

		private bool HighlightSelf(XEventArgs e)
		{
			this._blinkValue = 0.2f;
			this._blinkDelta = 0.01f;
			this.SetShader(XRenderComponent.RenderAction.Blink, XRenderComponent.highlightColor);
			return true;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Renderer");

		private List<IRenderObject> renderObjs = new List<IRenderObject>();

		private int _load_part_flag = 0;

		private int _target_part_flag = 0;

		private int _currentLayer = XRole.RoleLayer;

		private bool _fadeOnCreate = false;

		private bool _fadeEffect = false;

		private bool _InFadeState = false;

		private XRenderComponent.FadeType _type = XRenderComponent.FadeType.FadeIn;

		private XRenderComponent.FadeState _fadeState = XRenderComponent.FadeState.Visible;

		private float _elapsed = 0f;

		private float _time = 0f;

		private int _targetFadeColor = 0;

		private uint _timerToken = 0U;

		private float _blinkValue = 0.01f;

		private float _blinkDelta = 0.01f;

		private XTimerMgr.ElapsedEventHandler _onHitBackCb = null;

		private XRenderComponent.RenderAction _action = XRenderComponent.RenderAction.None;

		private static CommandCallback _initCb = new CommandCallback(XRenderComponent._Init);

		private static Color32 hitColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 204);

		private static Color32 fadeColor = new Color32(192, 192, 192, byte.MaxValue);

		private static Color32 highlightColor = new Color32(133, 121, 91, 51);

		private enum FadeType
		{

			NotFade,

			FadeIn,

			FadeOut
		}

		private enum FadeState
		{

			Visible,

			Fading,

			InVisible
		}

		public enum LoadPart
		{

			Equip = 1,

			Shadow,

			Mount = 4
		}

		private enum RenderAction
		{

			None,

			HitRender,

			Blink,

			Fade,

			DistanceFade
		}
	}
}
