using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F22 RID: 3874
	internal class XActionGeneratorComponent : XComponent
	{
		// Token: 0x170035AB RID: 13739
		// (get) Token: 0x0600CD2F RID: 52527 RVA: 0x002F462C File Offset: 0x002F282C
		public override uint ID
		{
			get
			{
				return XActionGeneratorComponent.uuID;
			}
		}

		// Token: 0x0600CD30 RID: 52528 RVA: 0x002F4644 File Offset: 0x002F2844
		public override void PostUpdate(float fDeltaT)
		{
			this.UpdateGesture();
			bool hasNpc = XSingleton<XInput>.singleton.HasNpc;
			if (hasNpc)
			{
				bool flag = !XSingleton<XScene>.singleton.GameCamera.IsCloseUp;
				if (flag)
				{
					XNpc xnpc = XSingleton<XInput>.singleton.LastNpc as XNpc;
					bool flag2 = xnpc != null;
					if (flag2)
					{
						XNavigationEventArgs @event = XEventPool<XNavigationEventArgs>.GetEvent();
						@event.Firer = this._entity;
						@event.Dest = xnpc.EngineObject.Position;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
				}
			}
		}

		// Token: 0x0600CD31 RID: 52529 RVA: 0x002F46D0 File Offset: 0x002F28D0
		private void UpdateGesture()
		{
			bool feeding = XSingleton<XVirtualTab>.singleton.Feeding;
			if (feeding)
			{
				bool isCloseUp = XSingleton<XScene>.singleton.GameCamera.IsCloseUp;
				if (!isCloseUp)
				{
					this._entity.Net.ReportMoveAction(XSingleton<XVirtualTab>.singleton.Direction, 0.0);
					this._feed = true;
				}
			}
			else
			{
				bool feed = this._feed;
				if (feed)
				{
					this._entity.Net.ReportMoveAction(Vector3.zero, 0.0);
					this._feed = false;
				}
			}
		}

		// Token: 0x04005B3E RID: 23358
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Action_Generator");

		// Token: 0x04005B3F RID: 23359
		private bool _feed = false;
	}
}
