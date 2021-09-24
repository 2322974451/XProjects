using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XIdleComponent : XActionStateComponent<XIdleEventArgs>
	{

		public override uint ID
		{
			get
			{
				return XIdleComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Idle;
			this.PrepareAnimations();
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Idle, new XComponent.XEventHandler(base.OnActionEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnMounted, new XComponent.XEventHandler(base.OnMountEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnUnMounted, new XComponent.XEventHandler(base.OnMountEvent));
		}

		public override void OnRejected(XStateDefine current)
		{
		}

		public override bool SyncPredicted
		{
			get
			{
				bool isViewGridScene = XSingleton<XScene>.singleton.IsViewGridScene;
				bool result;
				if (isViewGridScene)
				{
					result = true;
				}
				else
				{
					bool syncMode = XSingleton<XGame>.singleton.SyncMode;
					if (syncMode)
					{
						bool flag = this._entity.Skill != null && this._entity.Skill.IsCasting();
						result = (!flag && this._entity.IsPlayer && !this._entity.IsPassive);
					}
					else
					{
						result = true;
					}
				}
				return result;
			}
		}

		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		public override string PresentCommand
		{
			get
			{
				return "ToStand";
			}
		}

		public override string PresentName
		{
			get
			{
				return "Stand";
			}
		}

		protected override bool OnGetEvent(XIdleEventArgs e, XStateDefine last)
		{
			return true;
		}

		protected override void OnMount(XMount mount)
		{
			bool flag = mount != null;
			if (flag)
			{
				this._entity.OverrideAnimClip("Idle", this._entity.Present.PresentLib.AnimLocation.Replace('/', '_') + mount.Present.PresentLib.Idle + (this._entity.IsCopilotMounted ? "_follow" : ""), true, false);
			}
			else
			{
				this.PrepareAnimations();
			}
		}

		private void PrepareAnimations()
		{
			bool isNotEmptyObject = this._entity.EngineObject.IsNotEmptyObject;
			if (isNotEmptyObject)
			{
				bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && !string.IsNullOrEmpty(this._entity.Present.PresentLib.AttackIdle);
				if (flag)
				{
					this._entity.OverrideAnimClip("Idle", this._entity.Present.PresentLib.AttackIdle, true, false);
				}
				else
				{
					this._entity.OverrideAnimClip("Idle", this._entity.Present.PresentLib.Idle, true, false);
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Idle");
	}
}
