using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandForceSlide : XBaseCommand
	{

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

		protected void OnDragStart(GameObject go)
		{
			GameObject gameObject = this._cloneDst.FindChild("Can").gameObject;
			gameObject.SetActive(true);
		}

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

		public override void OnFinish()
		{
			this.Stop();
		}

		public override void Stop()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			base.Stop();
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
		}

		private GameObject _finger;

		private Transform _cloneSrc;

		private Transform _cloneDst;

		private uint _dragskillID;

		private uint _dragSlot;
	}
}
