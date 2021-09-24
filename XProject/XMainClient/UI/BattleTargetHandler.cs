using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleTargetHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.TargetFx = base.PanelObject.transform.FindChild("Taget2").gameObject;
			this.PretargetFx = base.PanelObject.transform.FindChild("Taget1").gameObject;
			this.TargetFx.transform.localPosition = XGameUI.Far_Far_Away;
			this.PretargetFx.transform.localPosition = XGameUI.Far_Far_Away;
		}

		public void ShowTargetFx(bool show, XEntity e)
		{
			bool flag = !show;
			if (flag)
			{
				this.TargetFx.transform.localPosition = XGameUI.Far_Far_Away;
			}
			bool flag2 = !XEntity.ValideEntity(e);
			if (!flag2)
			{
				XSingleton<XTutorialHelper>.singleton.HasTarget = true;
				this.TargetFx.transform.position = this.EntityOnUI(e);
				Vector3 localPosition = this.TargetFx.transform.localPosition;
				localPosition.x = (float)Mathf.FloorToInt(localPosition.x);
				localPosition.y = (float)Mathf.FloorToInt(localPosition.y);
				localPosition.z = 0f;
				this.TargetFx.transform.localPosition = localPosition;
			}
		}

		public void ShowPretargetFx(bool show, XEntity e)
		{
			bool flag = !show;
			if (flag)
			{
				this.PretargetFx.transform.localPosition = XGameUI.Far_Far_Away;
			}
			bool flag2 = !XEntity.ValideEntity(e);
			if (!flag2)
			{
				this.PretargetFx.transform.position = this.EntityOnUI(e);
				bool flag3 = this.PretargetFx.transform.position.z < 0f;
				if (flag3)
				{
					this.PretargetFx.transform.localPosition = XGameUI.Far_Far_Away;
				}
				else
				{
					Vector3 localPosition = this.PretargetFx.transform.localPosition;
					localPosition.x = (float)Mathf.FloorToInt(localPosition.x);
					localPosition.y = (float)Mathf.FloorToInt(localPosition.y);
					localPosition.z = 0f;
					this.PretargetFx.transform.localPosition = localPosition;
				}
			}
		}

		protected Vector3 EntityOnUI(XEntity e)
		{
			Vector3 vector = e.EngineObject.Position + new Vector3(0f, e.Height / 2f, 0f);
			Vector3 vector2 = XSingleton<XScene>.singleton.GameCamera.UnityCamera.WorldToViewportPoint(vector);
			return XSingleton<XGameUI>.singleton.UICamera.ViewportToWorldPoint(vector2);
		}

		public GameObject TargetFx;

		public GameObject PretargetFx;
	}
}
