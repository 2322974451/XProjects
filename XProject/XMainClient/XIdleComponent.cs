using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F2A RID: 3882
	internal sealed class XIdleComponent : XActionStateComponent<XIdleEventArgs>
	{
		// Token: 0x170035D7 RID: 13783
		// (get) Token: 0x0600CDBF RID: 52671 RVA: 0x002F8D2C File Offset: 0x002F6F2C
		public override uint ID
		{
			get
			{
				return XIdleComponent.uuID;
			}
		}

		// Token: 0x0600CDC0 RID: 52672 RVA: 0x002F8D43 File Offset: 0x002F6F43
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Idle;
			this.PrepareAnimations();
		}

		// Token: 0x0600CDC1 RID: 52673 RVA: 0x002F8D5C File Offset: 0x002F6F5C
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Idle, new XComponent.XEventHandler(base.OnActionEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnMounted, new XComponent.XEventHandler(base.OnMountEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnUnMounted, new XComponent.XEventHandler(base.OnMountEvent));
		}

		// Token: 0x0600CDC2 RID: 52674 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRejected(XStateDefine current)
		{
		}

		// Token: 0x170035D8 RID: 13784
		// (get) Token: 0x0600CDC3 RID: 52675 RVA: 0x002F8DB0 File Offset: 0x002F6FB0
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

		// Token: 0x170035D9 RID: 13785
		// (get) Token: 0x0600CDC4 RID: 52676 RVA: 0x002F8E30 File Offset: 0x002F7030
		public override bool IsUsingCurve
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170035DA RID: 13786
		// (get) Token: 0x0600CDC5 RID: 52677 RVA: 0x002F8E44 File Offset: 0x002F7044
		public override string PresentCommand
		{
			get
			{
				return "ToStand";
			}
		}

		// Token: 0x170035DB RID: 13787
		// (get) Token: 0x0600CDC6 RID: 52678 RVA: 0x002F8E5C File Offset: 0x002F705C
		public override string PresentName
		{
			get
			{
				return "Stand";
			}
		}

		// Token: 0x0600CDC7 RID: 52679 RVA: 0x002F8E74 File Offset: 0x002F7074
		protected override bool OnGetEvent(XIdleEventArgs e, XStateDefine last)
		{
			return true;
		}

		// Token: 0x0600CDC8 RID: 52680 RVA: 0x002F8E88 File Offset: 0x002F7088
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

		// Token: 0x0600CDC9 RID: 52681 RVA: 0x002F8F0C File Offset: 0x002F710C
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

		// Token: 0x04005BB2 RID: 23474
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Basic_Idle");
	}
}
