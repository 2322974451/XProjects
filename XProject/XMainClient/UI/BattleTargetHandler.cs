using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200172A RID: 5930
	internal class BattleTargetHandler : DlgHandlerBase
	{
		// Token: 0x0600F4E2 RID: 62690 RVA: 0x00371B80 File Offset: 0x0036FD80
		protected override void Init()
		{
			base.Init();
			this.TargetFx = base.PanelObject.transform.FindChild("Taget2").gameObject;
			this.PretargetFx = base.PanelObject.transform.FindChild("Taget1").gameObject;
			this.TargetFx.transform.localPosition = XGameUI.Far_Far_Away;
			this.PretargetFx.transform.localPosition = XGameUI.Far_Far_Away;
		}

		// Token: 0x0600F4E3 RID: 62691 RVA: 0x00371C04 File Offset: 0x0036FE04
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

		// Token: 0x0600F4E4 RID: 62692 RVA: 0x00371CB8 File Offset: 0x0036FEB8
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

		// Token: 0x0600F4E5 RID: 62693 RVA: 0x00371D9C File Offset: 0x0036FF9C
		protected Vector3 EntityOnUI(XEntity e)
		{
			Vector3 vector = e.EngineObject.Position + new Vector3(0f, e.Height / 2f, 0f);
			Vector3 vector2 = XSingleton<XScene>.singleton.GameCamera.UnityCamera.WorldToViewportPoint(vector);
			return XSingleton<XGameUI>.singleton.UICamera.ViewportToWorldPoint(vector2);
		}

		// Token: 0x040069BC RID: 27068
		public GameObject TargetFx;

		// Token: 0x040069BD RID: 27069
		public GameObject PretargetFx;
	}
}
