using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC3 RID: 4035
	internal class XFishingComponent : XComponent
	{
		// Token: 0x170036B3 RID: 14003
		// (get) Token: 0x0600D1D7 RID: 53719 RVA: 0x0030CEE4 File Offset: 0x0030B0E4
		public override uint ID
		{
			get
			{
				return XFishingComponent.uuID;
			}
		}

		// Token: 0x0600D1D8 RID: 53720 RVA: 0x0030CEFB File Offset: 0x0030B0FB
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._fishingRodPresentation = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(50001U);
		}

		// Token: 0x0600D1D9 RID: 53721 RVA: 0x0030CF20 File Offset: 0x0030B120
		public override void Attached()
		{
			this._entity.Equipment.EquipFishing(true, XFishingComponent.fishing_present_id);
			XSingleton<XDebug>.singleton.AddGreenLog("Equip FishingRod.", null, null, null, null, null);
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
				XCameraActionEventArgs @event = XEventPool<XCameraActionEventArgs>.GetEvent();
				@event.XRotate = XSingleton<XScene>.singleton.GameCamera.Root_R_X_Default;
				float angle = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("FishingCameraDesdir"));
				float degree = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("FishingCameraDegree"));
				@event.YRotate = XSingleton<XCommon>.singleton.AngleToFloat(XSingleton<XCommon>.singleton.HorizontalRotateVetor3(XSingleton<XCommon>.singleton.FloatToAngle(angle), degree, true));
				@event.Firer = XSingleton<XScene>.singleton.GameCamera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0600D1DA RID: 53722 RVA: 0x0030CFF8 File Offset: 0x0030B1F8
		public override void OnDetachFromHost()
		{
			this._entity.Equipment.EquipFishing(false, 0U);
			XSingleton<XDebug>.singleton.AddGreenLog("delete FishingRod.", null, null, null, null, null);
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
				bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
				if (flag)
				{
					XSingleton<XEntityMgr>.singleton.Player.PlayStateBack();
					XCameraMotionEndEventArgs @event = XEventPool<XCameraMotionEndEventArgs>.GetEvent();
					@event.Target = this._entity;
					@event.Firer = XSingleton<XScene>.singleton.GameCamera;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
			}
			base.OnDetachFromHost();
		}

		// Token: 0x0600D1DB RID: 53723 RVA: 0x0030D0B0 File Offset: 0x0030B2B0
		public void PlayAnimationWithResult(bool haveFish)
		{
			this._haveFish = haveFish;
			this._currState = HomeFishingState.WAITSERVER;
			XRole xrole = this._entity as XRole;
			xrole.PlaySpecifiedAnimation(this._entity.Present.PresentLib.FishingIdle);
			this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingIdle);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
			this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.OnFishingStateChange), null);
		}

		// Token: 0x0600D1DC RID: 53724 RVA: 0x0030D144 File Offset: 0x0030B344
		private void OnFishingStateChange(object o = null)
		{
			float num = 5f;
			XRole xrole = this._entity as XRole;
			switch (this._currState)
			{
			case HomeFishingState.CAST:
			{
				this._currState = HomeFishingState.WAIT;
				num = xrole.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingWait);
				bool flag = num < 0f;
				if (flag)
				{
					return;
				}
				this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingWait);
				num = 1f;
				break;
			}
			case HomeFishingState.WAIT:
			{
				this._currState = HomeFishingState.PULL;
				num = xrole.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingPull);
				bool flag2 = num < 0f;
				if (flag2)
				{
					return;
				}
				this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingPull);
				break;
			}
			case HomeFishingState.WAITSERVER:
			{
				this._currState = HomeFishingState.CAST;
				num = xrole.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingCast);
				bool flag3 = num < 0f;
				if (flag3)
				{
					return;
				}
				this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingCast);
				break;
			}
			case HomeFishingState.PULL:
			{
				this._currState = HomeFishingState.GET;
				bool haveFish = this._haveFish;
				if (haveFish)
				{
					num = xrole.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingWin);
					bool flag4 = num < 0f;
					if (flag4)
					{
						return;
					}
					this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingWin);
				}
				else
				{
					num = xrole.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingLose);
					bool flag5 = num < 0f;
					if (flag5)
					{
						return;
					}
					this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingLose);
				}
				break;
			}
			case HomeFishingState.GET:
			{
				this._currState = HomeFishingState.WAITSERVER;
				num = xrole.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingIdle);
				bool flag6 = num < 0f;
				if (flag6)
				{
					return;
				}
				this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingIdle);
				num = -1f;
				break;
			}
			}
			bool flag7 = num > 0f;
			if (flag7)
			{
				this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(num, new XTimerMgr.ElapsedEventHandler(this.OnFishingStateChange), null);
			}
		}

		// Token: 0x04005F33 RID: 24371
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FishingComponent");

		// Token: 0x04005F34 RID: 24372
		private static uint fishing_present_id = 50001U;

		// Token: 0x04005F35 RID: 24373
		private bool _haveFish;

		// Token: 0x04005F36 RID: 24374
		private HomeFishingState _currState;

		// Token: 0x04005F37 RID: 24375
		private uint _timerToken;

		// Token: 0x04005F38 RID: 24376
		private XEntityPresentation.RowData _fishingRodPresentation;
	}
}
