using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public class XPostEffectMgr : XSingleton<XPostEffectMgr>
	{

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

		public void OnLeaveScene()
		{
			this._radialBlur = null;
			this._blackWhite = null;
			this._gausBlur = null;
		}

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

		private XRadialBlur _radialBlur;

		private XBlackWhite _blackWhite;

		private XGausBlur _gausBlur;
	}
}
