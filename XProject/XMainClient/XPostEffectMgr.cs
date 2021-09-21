using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D43 RID: 3395
	public class XPostEffectMgr : XSingleton<XPostEffectMgr>
	{
		// Token: 0x0600BC07 RID: 48135 RVA: 0x0026BCA0 File Offset: 0x00269EA0
		public void OnEnterScene(uint sceneid)
		{
			bool flag = XSingleton<XScene>.singleton.GameCamera.UnityCamera != null;
			if (flag)
			{
				GameObject gameObject = XSingleton<XScene>.singleton.GameCamera.UnityCamera.gameObject;
				bool flag2 = gameObject != null;
				if (flag2)
				{
					this._gausBlur = gameObject.GetComponent<XGausBlur>();
					bool flag3 = this._gausBlur == null;
					if (flag3)
					{
						this._gausBlur = gameObject.AddComponent<XGausBlur>();
					}
					this._gausBlur.shader = ShaderManager._gausBlur;
					this._gausBlur.enabled = false;
					this._blackWhite = gameObject.GetComponent<XBlackWhite>();
					bool flag4 = this._blackWhite == null;
					if (flag4)
					{
						this._blackWhite = gameObject.AddComponent<XBlackWhite>();
					}
					this._blackWhite.shader = ShaderManager._blackWhite;
					this._blackWhite.enabled = false;
					this._radialBlur = gameObject.GetComponent<XRadialBlur>();
					bool flag5 = this._radialBlur == null;
					if (flag5)
					{
						this._radialBlur = gameObject.AddComponent<XRadialBlur>();
					}
					this._radialBlur.shader = ShaderManager._radialBlur;
					this._radialBlur.enabled = false;
				}
			}
		}

		// Token: 0x0600BC08 RID: 48136 RVA: 0x0026BDC4 File Offset: 0x00269FC4
		public void OnLeaveScene()
		{
			this._radialBlur = null;
			this._blackWhite = null;
			this._gausBlur = null;
		}

		// Token: 0x0600BC09 RID: 48137 RVA: 0x0026BDDC File Offset: 0x00269FDC
		public void MakeEffectEnable(XPostEffect effect, bool enabled)
		{
			bool quality = XQualitySetting.GetQuality(EFun.ECamera);
			switch (effect)
			{
			case XPostEffect.RadialBlur:
			{
				bool flag = this._radialBlur != null;
				if (flag)
				{
					this._radialBlur.enabled = (quality && enabled);
				}
				break;
			}
			case XPostEffect.BlackWhite:
			{
				bool flag2 = this._blackWhite != null;
				if (flag2)
				{
					this._blackWhite.enabled = (quality && enabled);
				}
				break;
			}
			case XPostEffect.GausBlur:
			{
				bool flag3 = this._gausBlur != null;
				if (flag3)
				{
					this._gausBlur.enabled = (quality && enabled);
				}
				break;
			}
			}
		}

		// Token: 0x04004C4A RID: 19530
		private XRadialBlur _radialBlur;

		// Token: 0x04004C4B RID: 19531
		private XBlackWhite _blackWhite;

		// Token: 0x04004C4C RID: 19532
		private XGausBlur _gausBlur;
	}
}
