using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandForceSkill : XBaseCommand
	{

		public override bool Execute()
		{
			Transform transform = XSingleton<XGameUI>.singleton.UIRoot.FindChild(this._cmd.param1);
			bool flag = transform == null || !transform.gameObject.activeInHierarchy;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._clickGo = transform.gameObject;
				this._time1 = XSingleton<XTimerMgr>.singleton.SetTimer(this._cmd.interalDelay, new XTimerMgr.ElapsedEventHandler(this.ShowFinger), null);
				base.publicModule();
				result = true;
			}
			return result;
		}

		public override void Stop()
		{
			bool flag = this._time1 > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._time1);
				this._time1 = 0U;
			}
			bool flag2 = this._time2 > 0U;
			if (flag2)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._time2);
				this._time2 = 0U;
			}
			bool flag3 = this._finger != null;
			if (flag3)
			{
				IXUISprite ixuisprite = this._finger.transform.FindChild("Quan1").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteWidth = this.orgWidth;
				ixuisprite.spriteHeight = this.orgHeight;
				XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			}
			bool flag4 = this._cloneGo != null;
			if (flag4)
			{
				this._cloneGo.transform.parent = null;
				UnityEngine.Object.Destroy(this._cloneGo);
				this._cloneGo = null;
			}
			base.DestroyAilin();
			base.DestroyOverlay();
			XSingleton<XShell>.singleton.Pause = false;
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
		}

		protected void ShowFinger(object o)
		{
			base.SetOverlay();
			DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.SetVisible(false, true);
			bool flag = string.IsNullOrEmpty(this._cmd.ailinText2);
			if (flag)
			{
				this._SetupFinger();
			}
			base.SetAilin();
			bool pause = this._cmd.pause;
			if (pause)
			{
				XSingleton<XShell>.singleton.Pause = true;
			}
		}

		protected void _SetupFinger()
		{
			bool flag = this._finger == null;
			if (flag)
			{
				this._finger = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/Quan", true, false) as GameObject);
			}
			this._finger.SetActive(false);
			float num = float.Parse(this._cmd.param3);
			bool flag2 = num > 0f;
			if (flag2)
			{
				IXUISprite ixuisprite = this._finger.transform.FindChild("Quan1").GetComponent("XUISprite") as IXUISprite;
				this.orgWidth = ixuisprite.spriteWidth;
				this.orgHeight = ixuisprite.spriteHeight;
				ixuisprite.spriteWidth = (int)((float)ixuisprite.spriteWidth * num);
				ixuisprite.spriteHeight = (int)((float)ixuisprite.spriteHeight * num);
			}
			this._cloneGo = XCommon.Instantiate<GameObject>(this._clickGo.gameObject);
			this.SetupCloneButton(this._clickGo.gameObject, this._cloneGo);
		}

		protected override void OnMouseClick(IXUISprite sp)
		{
			base.OnMouseClick(sp);
			bool flag = !string.IsNullOrEmpty(this._cmd.ailinText2);
			if (flag)
			{
				this._SetupFinger();
			}
		}

		protected void SetupCloneButton(GameObject targetGo, GameObject cloneGo)
		{
			XSingleton<UiUtility>.singleton.AddChild(cloneGo.transform, this._finger.transform);
			this._finger.transform.localRotation *= Quaternion.Euler(0f, 0f, -90f);
			cloneGo.name = targetGo.name;
			IXUIObject ixuiobject = cloneGo.GetComponent("XUIObject") as IXUIObject;
			ixuiobject.Exculsive = true;
			cloneGo.transform.parent = XBaseCommand._Overlay.transform;
			Vector3 position = targetGo.transform.position;
			Vector3 localPosition = XBaseCommand._Overlay.transform.InverseTransformPoint(position);
			localPosition.z = 0f;
			cloneGo.transform.localPosition = localPosition;
			cloneGo.transform.localScale = targetGo.transform.localScale;
			this._finger.SetActive(true);
			IXUIButton ixuibutton = cloneGo.GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClick));
			XSingleton<XTutorialMgr>.singleton.Exculsive = true;
		}

		protected bool OnBtnClick(IXUIButton go)
		{
			int num = int.Parse(this._cmd.param2);
			XSingleton<XShell>.singleton.Pause = false;
			this._time2 = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.CastSkill), num);
			return true;
		}

		protected void CastSkill(object o)
		{
			int num = (int)o;
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			XPlayerAttributes xplayerAttributes = player.Attributes as XPlayerAttributes;
			switch (num)
			{
			case 0:
				player.Net.ReportSkillAction(null, player.SkillMgr.GetPhysicalIdentity(), -1);
				break;
			case 1:
			{
				uint skillid = XSingleton<XCommon>.singleton.XHash(player.Present.PresentLib.Dash);
				player.Net.ReportSkillAction(null, skillid, -1);
				break;
			}
			case 2:
			{
				uint skillid2 = xplayerAttributes.skillSlot[0];
				player.Net.ReportSkillAction(null, skillid2, -1);
				break;
			}
			}
		}

		private GameObject _finger;

		private GameObject _clickGo;

		private GameObject _cloneGo;

		private int orgWidth;

		private int orgHeight;

		private uint _time1 = 0U;

		private uint _time2 = 0U;
	}
}
