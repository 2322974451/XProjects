using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FE0 RID: 4064
	internal class XRenderComponent : XComponent
	{
		// Token: 0x170036DB RID: 14043
		// (get) Token: 0x0600D317 RID: 54039 RVA: 0x00316C70 File Offset: 0x00314E70
		public override uint ID
		{
			get
			{
				return XRenderComponent.uuID;
			}
		}

		// Token: 0x0600D318 RID: 54040 RVA: 0x00316C88 File Offset: 0x00314E88
		public XRenderComponent()
		{
			this._onHitBackCb = new XTimerMgr.ElapsedEventHandler(this.OnHitBack);
		}

		// Token: 0x0600D319 RID: 54041 RVA: 0x00316D40 File Offset: 0x00314F40
		public static bool HasRenderComponent(XEntity e, bool hasFadeEffect)
		{
			return (e.IsRole && !e.IsPlayer && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall) || (XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && hasFadeEffect);
		}

		// Token: 0x0600D31A RID: 54042 RVA: 0x00316D98 File Offset: 0x00314F98
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

		// Token: 0x0600D31B RID: 54043 RVA: 0x00316EB6 File Offset: 0x003150B6
		public void SetEntityLayer(int initLayer)
		{
			this._currentLayer = initLayer;
		}

		// Token: 0x0600D31C RID: 54044 RVA: 0x00316EC0 File Offset: 0x003150C0
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

		// Token: 0x0600D31D RID: 54045 RVA: 0x00316F4C File Offset: 0x0031514C
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

		// Token: 0x0600D31E RID: 54046 RVA: 0x00317038 File Offset: 0x00315238
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

		// Token: 0x0600D31F RID: 54047 RVA: 0x003170A8 File Offset: 0x003152A8
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

		// Token: 0x0600D320 RID: 54048 RVA: 0x00317100 File Offset: 0x00315300
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

		// Token: 0x0600D321 RID: 54049 RVA: 0x00317170 File Offset: 0x00315370
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

		// Token: 0x0600D322 RID: 54050 RVA: 0x003171B0 File Offset: 0x003153B0
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

		// Token: 0x0600D323 RID: 54051 RVA: 0x003171EC File Offset: 0x003153EC
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

		// Token: 0x0600D324 RID: 54052 RVA: 0x00317248 File Offset: 0x00315448
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

		// Token: 0x0600D325 RID: 54053 RVA: 0x003172BC File Offset: 0x003154BC
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

		// Token: 0x0600D326 RID: 54054 RVA: 0x00317330 File Offset: 0x00315530
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

		// Token: 0x0600D327 RID: 54055 RVA: 0x003173BC File Offset: 0x003155BC
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

		// Token: 0x0600D328 RID: 54056 RVA: 0x00317418 File Offset: 0x00315618
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

		// Token: 0x0600D329 RID: 54057 RVA: 0x00317484 File Offset: 0x00315684
		private void OnFade()
		{
			Color32 color = XRenderComponent.fadeColor;
			color.a = (byte)this._targetFadeColor;
			this.SetShader(XRenderComponent.RenderAction.Fade, color);
			this._action = XRenderComponent.RenderAction.None;
			int layer = (this._targetFadeColor == 0) ? XQualitySetting.InVisiblityLayer : this._currentLayer;
			this.SetLayer(layer);
		}

		// Token: 0x0600D32A RID: 54058 RVA: 0x003174D4 File Offset: 0x003156D4
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

		// Token: 0x0600D32B RID: 54059 RVA: 0x0031756C File Offset: 0x0031576C
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

		// Token: 0x0600D32C RID: 54060 RVA: 0x003175C4 File Offset: 0x003157C4
		private void SetLayer(int layer)
		{
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.SetRenderLayer(layer);
			}
		}

		// Token: 0x0600D32D RID: 54061 RVA: 0x00317603 File Offset: 0x00315803
		public void FadeInImmediately()
		{
			this._action = XRenderComponent.RenderAction.None;
			this._time = 0f;
			this._elapsed = 0f;
			this._type = XRenderComponent.FadeType.NotFade;
			this.ResetShader();
		}

		// Token: 0x0600D32E RID: 54062 RVA: 0x00317634 File Offset: 0x00315834
		private void OnHitBack(object o)
		{
			bool flag = this._action == XRenderComponent.RenderAction.HitRender;
			if (flag)
			{
				this._action = XRenderComponent.RenderAction.None;
				this.ResetShader();
			}
		}

		// Token: 0x0600D32F RID: 54063 RVA: 0x00317660 File Offset: 0x00315860
		private void SetFade(Color32 c, byte a)
		{
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.SetColor(c.r, c.g, c.b, a);
			}
		}

		// Token: 0x0600D330 RID: 54064 RVA: 0x003176B4 File Offset: 0x003158B4
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

		// Token: 0x0600D331 RID: 54065 RVA: 0x0031772C File Offset: 0x0031592C
		private void ResetShader()
		{
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.ResetShader();
			}
		}

		// Token: 0x0600D332 RID: 54066 RVA: 0x0031776C File Offset: 0x0031596C
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

		// Token: 0x0600D333 RID: 54067 RVA: 0x00317A38 File Offset: 0x00315C38
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

		// Token: 0x0600D334 RID: 54068 RVA: 0x00317B40 File Offset: 0x00315D40
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_FadeIn, new XComponent.XEventHandler(this.OnIn));
			base.RegisterEvent(XEventDefine.XEvent_FadeOut, new XComponent.XEventHandler(this.OnOut));
			base.RegisterEvent(XEventDefine.XEvent_Highlight, new XComponent.XEventHandler(this.HighlightSelf));
		}

		// Token: 0x0600D335 RID: 54069 RVA: 0x00317B90 File Offset: 0x00315D90
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

		// Token: 0x0600D336 RID: 54070 RVA: 0x00317C88 File Offset: 0x00315E88
		public override void Attached()
		{
			bool flag = this._entity.Equipment == null && (this._fadeEffect || this._fadeOnCreate);
			if (flag)
			{
				this._entity.EngineObject.CallCommand(XRenderComponent._initCb, this, -1, false);
			}
		}

		// Token: 0x0600D337 RID: 54071 RVA: 0x00317CD8 File Offset: 0x00315ED8
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

		// Token: 0x0600D338 RID: 54072 RVA: 0x00317F88 File Offset: 0x00316188
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

		// Token: 0x0600D339 RID: 54073 RVA: 0x00317FDC File Offset: 0x003161DC
		protected bool OnOut(XEventArgs e)
		{
			for (int i = 0; i < this.renderObjs.Count; i++)
			{
				IRenderObject renderObject = this.renderObjs[i];
				renderObject.SetRenderLayer(XQualitySetting.InVisiblityLayer);
			}
			return true;
		}

		// Token: 0x0600D33A RID: 54074 RVA: 0x00318024 File Offset: 0x00316224
		private bool HighlightSelf(XEventArgs e)
		{
			this._blinkValue = 0.2f;
			this._blinkDelta = 0.01f;
			this.SetShader(XRenderComponent.RenderAction.Blink, XRenderComponent.highlightColor);
			return true;
		}

		// Token: 0x04005FF2 RID: 24562
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Renderer");

		// Token: 0x04005FF3 RID: 24563
		private List<IRenderObject> renderObjs = new List<IRenderObject>();

		// Token: 0x04005FF4 RID: 24564
		private int _load_part_flag = 0;

		// Token: 0x04005FF5 RID: 24565
		private int _target_part_flag = 0;

		// Token: 0x04005FF6 RID: 24566
		private int _currentLayer = XRole.RoleLayer;

		// Token: 0x04005FF7 RID: 24567
		private bool _fadeOnCreate = false;

		// Token: 0x04005FF8 RID: 24568
		private bool _fadeEffect = false;

		// Token: 0x04005FF9 RID: 24569
		private bool _InFadeState = false;

		// Token: 0x04005FFA RID: 24570
		private XRenderComponent.FadeType _type = XRenderComponent.FadeType.FadeIn;

		// Token: 0x04005FFB RID: 24571
		private XRenderComponent.FadeState _fadeState = XRenderComponent.FadeState.Visible;

		// Token: 0x04005FFC RID: 24572
		private float _elapsed = 0f;

		// Token: 0x04005FFD RID: 24573
		private float _time = 0f;

		// Token: 0x04005FFE RID: 24574
		private int _targetFadeColor = 0;

		// Token: 0x04005FFF RID: 24575
		private uint _timerToken = 0U;

		// Token: 0x04006000 RID: 24576
		private float _blinkValue = 0.01f;

		// Token: 0x04006001 RID: 24577
		private float _blinkDelta = 0.01f;

		// Token: 0x04006002 RID: 24578
		private XTimerMgr.ElapsedEventHandler _onHitBackCb = null;

		// Token: 0x04006003 RID: 24579
		private XRenderComponent.RenderAction _action = XRenderComponent.RenderAction.None;

		// Token: 0x04006004 RID: 24580
		private static CommandCallback _initCb = new CommandCallback(XRenderComponent._Init);

		// Token: 0x04006005 RID: 24581
		private static Color32 hitColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 204);

		// Token: 0x04006006 RID: 24582
		private static Color32 fadeColor = new Color32(192, 192, 192, byte.MaxValue);

		// Token: 0x04006007 RID: 24583
		private static Color32 highlightColor = new Color32(133, 121, 91, 51);

		// Token: 0x020019FC RID: 6652
		private enum FadeType
		{
			// Token: 0x040081D9 RID: 33241
			NotFade,
			// Token: 0x040081DA RID: 33242
			FadeIn,
			// Token: 0x040081DB RID: 33243
			FadeOut
		}

		// Token: 0x020019FD RID: 6653
		private enum FadeState
		{
			// Token: 0x040081DD RID: 33245
			Visible,
			// Token: 0x040081DE RID: 33246
			Fading,
			// Token: 0x040081DF RID: 33247
			InVisible
		}

		// Token: 0x020019FE RID: 6654
		public enum LoadPart
		{
			// Token: 0x040081E1 RID: 33249
			Equip = 1,
			// Token: 0x040081E2 RID: 33250
			Shadow,
			// Token: 0x040081E3 RID: 33251
			Mount = 4
		}

		// Token: 0x020019FF RID: 6655
		private enum RenderAction
		{
			// Token: 0x040081E5 RID: 33253
			None,
			// Token: 0x040081E6 RID: 33254
			HitRender,
			// Token: 0x040081E7 RID: 33255
			Blink,
			// Token: 0x040081E8 RID: 33256
			Fade,
			// Token: 0x040081E9 RID: 33257
			DistanceFade
		}
	}
}
