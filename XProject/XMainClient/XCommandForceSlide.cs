using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DF8 RID: 3576
	internal class XCommandForceSlide : XBaseCommand
	{
		// Token: 0x0600C156 RID: 49494 RVA: 0x0029247C File Offset: 0x0029067C
		public override bool Execute()
		{
			Transform uiwindow = this.GetUIWindow(this._cmd.param1);
			Transform uiwindow2 = this.GetUIWindow(this._cmd.param2);
			bool flag = uiwindow == null || uiwindow2 == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this._finger == null;
				if (flag2)
				{
					this._finger = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/SlideFinger", true, false) as GameObject);
				}
				base.SetOverlay();
				this._cloneSrc = this.CloneWindow(uiwindow);
				this._cloneDst = this.CloneWindow(uiwindow2);
				this.SetupSlide();
				IXUITweenTool ixuitweenTool = this._finger.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.PlayTween(true, -1f);
				IXUISprite ixuisprite = uiwindow.GetComponent("XUISprite") as IXUISprite;
				this._dragskillID = (uint)ixuisprite.ID;
				IXUISprite ixuisprite2 = uiwindow2.GetComponent("XUISprite") as IXUISprite;
				this._dragSlot = (uint)ixuisprite2.ID;
				IXUIDragDropItem ixuidragDropItem = this._cloneSrc.Find("Icon").GetComponent("XUIDragDropItem") as IXUIDragDropItem;
				ixuidragDropItem.RegisterOnFinishEventHandler(new OnDropReleaseEventHandler(this.OnDragEnd));
				ixuidragDropItem.RegisterOnStartEventHandler(new OnDropStartEventHandler(this.OnDragStart));
				base.SetTutorialText(this._cmd.textPos, this._cloneSrc);
				XSingleton<XTutorialMgr>.singleton.Exculsive = true;
				base.publicModule();
				result = true;
			}
			return result;
		}

		// Token: 0x0600C157 RID: 49495 RVA: 0x00292608 File Offset: 0x00290808
		protected void OnDragStart(GameObject go)
		{
			GameObject gameObject = this._cloneDst.FindChild("Can").gameObject;
			gameObject.SetActive(true);
		}

		// Token: 0x0600C158 RID: 49496 RVA: 0x00292634 File Offset: 0x00290834
		protected void OnDragEnd(GameObject go, GameObject surface)
		{
			IXUISprite ixuisprite = go.GetComponent("XUISprite") as IXUISprite;
			uint num = (uint)ixuisprite.ID;
			IXUISprite ixuisprite2 = surface.GetComponent("XUISprite") as IXUISprite;
			bool flag = ixuisprite2 != null && surface.name.StartsWith("SkillSlot");
			if (flag)
			{
				uint num2 = (uint)ixuisprite2.ID;
				RpcC2G_BindSkill rpcC2G_BindSkill = new RpcC2G_BindSkill();
				rpcC2G_BindSkill.oArg.skillhash = this._dragskillID;
				rpcC2G_BindSkill.oArg.slot = (int)this._dragSlot;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BindSkill);
				XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
			}
		}

		// Token: 0x0600C159 RID: 49497 RVA: 0x002926D8 File Offset: 0x002908D8
		protected Transform CloneWindow(Transform window)
		{
			GameObject gameObject = XCommon.Instantiate<GameObject>(window.gameObject);
			gameObject.transform.parent = XBaseCommand._Overlay.transform;
			XSingleton<UiUtility>.singleton.AddChild(XSingleton<XGameUI>.singleton.UIRoot, XBaseCommand._Overlay.transform);
			Vector3 position = window.transform.position;
			Vector3 localPosition = XSingleton<XGameUI>.singleton.UIRoot.InverseTransformPoint(position);
			localPosition.z = 0f;
			gameObject.transform.localPosition = localPosition;
			gameObject.transform.localScale = Vector3.one;
			return gameObject.transform;
		}

		// Token: 0x0600C15A RID: 49498 RVA: 0x00292778 File Offset: 0x00290978
		protected void SetupSlide()
		{
			this._finger.transform.parent = XBaseCommand._Overlay.transform;
			this._finger.transform.localPosition = Vector3.zero;
			this._finger.transform.localScale = Vector3.one;
			Vector3 vector = XSingleton<XGameUI>.singleton.UIRoot.InverseTransformPoint(this._cloneSrc.transform.position);
			Vector3 vector2 = XSingleton<XGameUI>.singleton.UIRoot.InverseTransformPoint(this._cloneDst.transform.position);
			Vector3 localPosition = (vector + vector2) / 2f;
			float magnitude = (vector - vector2).magnitude;
			float num = Vector3.Angle(vector - vector2, Vector3.right);
			localPosition.z = 0f;
			this._finger.transform.localPosition = localPosition;
			this._finger.transform.localScale = new Vector3(magnitude / 712f, 1f, 1f);
			this._finger.transform.Rotate(0f, 0f, num - 180f);
		}

		// Token: 0x0600C15B RID: 49499 RVA: 0x002928AC File Offset: 0x00290AAC
		protected Transform GetUIWindow(string name)
		{
			Transform transform = XSingleton<XGameUI>.singleton.UIRoot.FindChild("SkillDlg(Clone)");
			bool flag = !transform || !transform.gameObject.activeInHierarchy;
			Transform result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Transform transform2 = XSingleton<UiUtility>.singleton.FindChild(transform.transform, name);
				result = transform2;
			}
			return result;
		}

		// Token: 0x0600C15C RID: 49500 RVA: 0x001E3B34 File Offset: 0x001E1D34
		public override void OnFinish()
		{
			this.Stop();
		}

		// Token: 0x0600C15D RID: 49501 RVA: 0x00292907 File Offset: 0x00290B07
		public override void Stop()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			base.Stop();
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
		}

		// Token: 0x0400517D RID: 20861
		private GameObject _finger;

		// Token: 0x0400517E RID: 20862
		private Transform _cloneSrc;

		// Token: 0x0400517F RID: 20863
		private Transform _cloneDst;

		// Token: 0x04005180 RID: 20864
		private uint _dragskillID;

		// Token: 0x04005181 RID: 20865
		private uint _dragSlot;
	}
}
