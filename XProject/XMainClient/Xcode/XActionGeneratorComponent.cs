using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XActionGeneratorComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XActionGeneratorComponent.uuID;
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Action_Generator");

		private bool _feed = false;
	}
}
