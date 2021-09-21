using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DA1 RID: 3489
	internal class XCommandForceSkill : XBaseCommand
	{
		// Token: 0x0600BD99 RID: 48537 RVA: 0x002766F0 File Offset: 0x002748F0
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

		// Token: 0x0600BD9A RID: 48538 RVA: 0x0027677C File Offset: 0x0027497C
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

		// Token: 0x0600BD9B RID: 48539 RVA: 0x00276898 File Offset: 0x00274A98
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

		// Token: 0x0600BD9C RID: 48540 RVA: 0x002768FC File Offset: 0x00274AFC
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

		// Token: 0x0600BD9D RID: 48541 RVA: 0x002769F4 File Offset: 0x00274BF4
		protected override void OnMouseClick(IXUISprite sp)
		{
			base.OnMouseClick(sp);
			bool flag = !string.IsNullOrEmpty(this._cmd.ailinText2);
			if (flag)
			{
				this._SetupFinger();
			}
		}

		// Token: 0x0600BD9E RID: 48542 RVA: 0x00276A2C File Offset: 0x00274C2C
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

		// Token: 0x0600BD9F RID: 48543 RVA: 0x00276B4C File Offset: 0x00274D4C
		protected bool OnBtnClick(IXUIButton go)
		{
			int num = int.Parse(this._cmd.param2);
			XSingleton<XShell>.singleton.Pause = false;
			this._time2 = XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.CastSkill), num);
			return true;
		}

		// Token: 0x0600BDA0 RID: 48544 RVA: 0x00276BA4 File Offset: 0x00274DA4
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

		// Token: 0x04004D3C RID: 19772
		private GameObject _finger;

		// Token: 0x04004D3D RID: 19773
		private GameObject _clickGo;

		// Token: 0x04004D3E RID: 19774
		private GameObject _cloneGo;

		// Token: 0x04004D3F RID: 19775
		private int orgWidth;

		// Token: 0x04004D40 RID: 19776
		private int orgHeight;

		// Token: 0x04004D41 RID: 19777
		private uint _time1 = 0U;

		// Token: 0x04004D42 RID: 19778
		private uint _time2 = 0U;
	}
}
