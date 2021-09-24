using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XWoozyComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XWoozyComponent.uuID;
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_ArmorBroken, new XComponent.XEventHandler(this.OnArmorBroken));
			base.RegisterEvent(XEventDefine.XEvent_ArmorRecover, new XComponent.XEventHandler(this.OnArmorRecover));
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnDeath));
		}

		public override void Attached()
		{
			this._woozy_enabled = this._entity.Attributes.HasWoozyStatus;
		}

		public override void OnDetachFromHost()
		{
			this.Clear();
			base.OnDetachFromHost();
		}

		public bool OnBroken
		{
			get
			{
				return this._OnBroken;
			}
		}

		public bool OnRecover
		{
			get
			{
				return this._OnRecover;
			}
		}

		public bool InTransfer
		{
			get
			{
				return this._transfer;
			}
		}

		public override void Update(float fDeltaT)
		{
			bool onRecover = this._OnRecover;
			if (onRecover)
			{
				this.RecoverArmor();
			}
			bool onBroken = this._OnBroken;
			if (onBroken)
			{
				this.BrokenArmor();
			}
			bool onWoozy = this._OnWoozy;
			if (onWoozy)
			{
				this.Woozy();
			}
			this.UpdateFx();
		}

		private bool OnArmorBroken(XEventArgs e)
		{
			this._OnBroken = true;
			this._transfer = true;
			return true;
		}

		private bool OnArmorRecover(XEventArgs e)
		{
			this._OnRecover = true;
			this._transfer = true;
			return true;
		}

		private bool OnDeath(XEventArgs e)
		{
			this.Clear();
			return true;
		}

		private void Clear()
		{
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
			this._OnBroken = false;
			this._OnRecover = false;
			this._transfer = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token_on);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token_off);
		}

		private void BrokenArmor()
		{
			bool woozy_enabled = this._woozy_enabled;
			if (woozy_enabled)
			{
				bool flag = !XSingleton<XGame>.singleton.SyncMode;
				if (flag)
				{
					XSingleton<XEntityMgr>.singleton.Idled(this._entity);
					this._entity.SkillMgr.CoolDown(this._entity.SkillMgr.GetBrokenIdentity());
					this._entity.Net.ReportSkillAction(null, this._entity.SkillMgr.GetBrokenIdentity(), -1);
				}
				this._OnBroken = false;
				this._entity.OverrideAnimClip("Idle", this._entity.Present.PresentLib.Feeble, true, false);
				float time = this._entity.SkillMgr.GetSkill(this._entity.SkillMgr.GetBrokenIdentity()).Soul.Time;
				this._token_on = XSingleton<XTimerMgr>.singleton.SetTimer(time - Time.deltaTime, new XTimerMgr.ElapsedEventHandler(this.WoozyOn), null);
				this._entity.BeginSlowMotion(0.3f, (time > 0.3f) ? 0.3f : time, false);
				XCoolDownAllSkillsArgs @event = XEventPool<XCoolDownAllSkillsArgs>.GetEvent();
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			else
			{
				this._OnBroken = false;
				this.WoozyOn(null);
			}
		}

		private void RecoverArmor()
		{
			bool woozy_enabled = this._woozy_enabled;
			if (woozy_enabled)
			{
				XEntity target = null;
				bool flag = !XSingleton<XGame>.singleton.SyncMode;
				if (flag)
				{
					List<XEntity> list = (this._entity.AI != null) ? this._entity.AI.EnmityList.GetHateEntity(false) : null;
					bool flag2 = list != null && list.Count > 0;
					if (flag2)
					{
						target = list[0];
					}
					this._entity.SkillMgr.CoolDown(this._entity.SkillMgr.GetRecoveryIdentity());
				}
				bool flag3 = XSingleton<XGame>.singleton.SyncMode || this._entity.Net.ReportSkillAction(target, this._entity.SkillMgr.GetRecoveryIdentity(), -1);
				if (flag3)
				{
					XSkillCore skill = this._entity.SkillMgr.GetSkill(this._entity.SkillMgr.GetRecoveryIdentity());
					float time = this._entity.SkillMgr.GetSkill(this._entity.SkillMgr.GetRecoveryIdentity()).Soul.Time;
					this._token_off = XSingleton<XTimerMgr>.singleton.SetTimer(time - Time.deltaTime, new XTimerMgr.ElapsedEventHandler(this.WoozyOff), null);
					this._OnRecover = false;
				}
				bool flag4 = !this._OnRecover;
				if (flag4)
				{
					this._recovery = false;
					bool flag5 = this._fx != null;
					if (flag5)
					{
						XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
						this._fx = null;
					}
				}
			}
			else
			{
				this._OnRecover = false;
				this.WoozyOff(null);
			}
		}

		private void Woozy()
		{
			bool recovery = this._recovery;
			if (recovery)
			{
				bool flag = !XSingleton<XGame>.singleton.SyncMode;
				if (flag)
				{
					XSingleton<XEntityMgr>.singleton.Idled(this._entity);
				}
				bool flag2 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.FeebleFx);
				if (flag2)
				{
					this.PlayFx(this._entity.Present.PresentLib.FeebleFx, true);
				}
			}
			else
			{
				this._entity.OverrideAnimClip("Idle", this._entity.Present.PresentLib.AttackIdle, true, false);
			}
			this._OnWoozy = false;
		}

		private void PlayFx(string fx, bool follow)
		{
			bool flag = this._fx != null && this._fx.FxName != fx;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
			bool flag2 = XEntity.FilterFx(this._entity, XFxMgr.FilterFxDis1);
			if (!flag2)
			{
				bool flag3 = this._fx == null;
				if (flag3)
				{
					this._fx = XSingleton<XFxMgr>.singleton.CreateFx(fx, null, true);
					this._fx.Play(this._entity.EngineObject, Vector3.zero, Vector3.one, 1f, follow, false, "", 0f);
				}
			}
		}

		private void WoozyOn(object o)
		{
			this._recovery = true;
			bool woozy_enabled = this._woozy_enabled;
			if (woozy_enabled)
			{
				this._OnWoozy = true;
			}
			this._transfer = false;
			XWoozyOnArgs @event = XEventPool<XWoozyOnArgs>.GetEvent();
			@event.Firer = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			@event = XEventPool<XWoozyOnArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			@event.Self = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		private void WoozyOff(object o)
		{
			bool woozy_enabled = this._woozy_enabled;
			if (woozy_enabled)
			{
				this._OnWoozy = true;
			}
			this._transfer = false;
			XWoozyOffArgs @event = XEventPool<XWoozyOffArgs>.GetEvent();
			@event.Firer = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			@event = XEventPool<XWoozyOffArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			@event.Self = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		private void UpdateFx()
		{
			bool recovery = this._recovery;
			if (recovery)
			{
				switch (this._entity.GetQTESpecificPhase())
				{
				case XQTEState.QTE_HitBackPresent:
				case XQTEState.QTE_HitBackStraight:
				case XQTEState.QTE_HitRollPresent:
				case XQTEState.QTE_HitRollStraight:
				{
					this.PlayFx(this._entity.Present.PresentLib.RecoveryHitSlowFX, true);
					bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetupSpeedFx(this._entity, true, new Color32(byte.MaxValue, 174, 0, byte.MaxValue));
					}
					bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
					if (flag2)
					{
						DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetupSpeedFx(this._entity, true, new Color32(byte.MaxValue, 174, 0, byte.MaxValue));
					}
					goto IL_1CC;
				}
				case XQTEState.QTE_HitFlyPresent:
				case XQTEState.QTE_HitFlyLand:
				case XQTEState.QTE_HitFlyBounce:
				case XQTEState.QTE_HitFreeze:
				{
					this.PlayFx(this._entity.Present.PresentLib.RecoveryHitStopFX, true);
					bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag3)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetupSpeedFx(this._entity, true, Color.red);
					}
					bool flag4 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
					if (flag4)
					{
						DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetupSpeedFx(this._entity, true, Color.red);
					}
					goto IL_1CC;
				}
				}
				this.PlayFx(this._entity.Present.PresentLib.RecoveryFX, true);
				bool flag5 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag5)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetupSpeedFx(this._entity, false, Color.white);
				}
				bool flag6 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag6)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetupSpeedFx(this._entity, false, Color.white);
				}
				IL_1CC:;
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WoozyComponent");

		private bool _OnBroken = false;

		private bool _OnRecover = false;

		private bool _OnWoozy = false;

		private bool _recovery = false;

		private bool _transfer = false;

		private bool _woozy_enabled = false;

		private XFx _fx = null;

		private uint _token_on = 0U;

		private uint _token_off = 0U;
	}
}
