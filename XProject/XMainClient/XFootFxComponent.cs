using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFootFxComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XFootFxComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			string footFx = XSingleton<XProfessionSkillMgr>.singleton.GetFootFx(XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID);
			bool flag = string.IsNullOrEmpty(footFx);
			if (!flag)
			{
				this._fx = XGameObject.CreateXGameObject(footFx, true, true);
				this._fx.SetParent(this._entity.MoveObj);
				this._fx.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, Vector3.one, false);
			}
		}

		public override void OnDetachFromHost()
		{
			bool flag = this._fx != null;
			if (flag)
			{
				XGameObject.DestroyXGameObject(this._fx);
				this._fx = null;
			}
			base.OnDetachFromHost();
		}

		public override void PostUpdate(float fDeltaT)
		{
			Vector3 zero = Vector3.zero;
			zero.y = (this._entity.StandOn ? 0f : (XSingleton<XScene>.singleton.TerrainY(this._entity.MoveObj.Position) - this._entity.MoveObj.Position.y)) + 0.025f;
			bool bMounted = this._entity.Attributes.Outlook.state.bMounted;
			if (bMounted)
			{
				zero.y -= 0.9f;
			}
			this._fx.SetLocalPRS(zero, true, Quaternion.identity, false, Vector3.one, false);
			this._fx.Rotation = XSingleton<XCommon>.singleton.RotateToGround(this._entity.MoveObj.Position, this._entity.MoveObj.Forward);
		}

		public void SetActive(bool active)
		{
			bool flag = this._fx != null;
			if (flag)
			{
				this._fx.SetActive(active, "");
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FootFx");

		private XGameObject _fx = null;
	}
}
