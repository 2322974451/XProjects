using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC4 RID: 4036
	internal class XFootFxComponent : XComponent
	{
		// Token: 0x170036B4 RID: 14004
		// (get) Token: 0x0600D1DF RID: 53727 RVA: 0x0030D3F4 File Offset: 0x0030B5F4
		public override uint ID
		{
			get
			{
				return XFootFxComponent.uuID;
			}
		}

		// Token: 0x0600D1E0 RID: 53728 RVA: 0x0030D40C File Offset: 0x0030B60C
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

		// Token: 0x0600D1E1 RID: 53729 RVA: 0x0030D48C File Offset: 0x0030B68C
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

		// Token: 0x0600D1E2 RID: 53730 RVA: 0x0030D4C4 File Offset: 0x0030B6C4
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

		// Token: 0x0600D1E3 RID: 53731 RVA: 0x0030D5A8 File Offset: 0x0030B7A8
		public void SetActive(bool active)
		{
			bool flag = this._fx != null;
			if (flag)
			{
				this._fx.SetActive(active, "");
			}
		}

		// Token: 0x04005F39 RID: 24377
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FootFx");

		// Token: 0x04005F3A RID: 24378
		private XGameObject _fx = null;
	}
}
