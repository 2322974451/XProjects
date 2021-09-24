using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XManipulationComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XManipulationComponent.uuID;
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Manipulation_On, new XComponent.XEventHandler(this.ManipulationOn));
			base.RegisterEvent(XEventDefine.XEvent_Manipulation_Off, new XComponent.XEventHandler(this.ManipulationOff));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnDetachFromHost()
		{
			this._item.Clear();
			base.OnDetachFromHost();
		}

		public override void Update(float fDeltaT)
		{
			bool flag = this._item.Count == 0;
			if (!flag)
			{
				foreach (KeyValuePair<long, XManipulationData> keyValuePair in this._item)
				{
					XManipulationData value = keyValuePair.Value;
					List<XEntity> list = value.TargetIsOpponent ? XSingleton<XEntityMgr>.singleton.GetOpponent(this._entity) : XSingleton<XEntityMgr>.singleton.GetAlly(this._entity);
					Vector3 vector = this._entity.EngineObject.Position + this._entity.EngineObject.Rotation * new Vector3(value.OffsetX, 0f, value.OffsetZ);
					for (int i = 0; i < list.Count; i++)
					{
						XEntity xentity = list[i];
						bool flag2 = !XEntity.ValideEntity(xentity);
						if (!flag2)
						{
							Vector3 vector2 = vector - xentity.EngineObject.Position;
							vector2.y = 0f;
							float magnitude = vector2.magnitude;
							bool flag3 = magnitude < value.Radius && (magnitude == 0f || Vector3.Angle(-vector2, this._entity.EngineObject.Forward) <= value.Degree * 0.5f);
							if (flag3)
							{
								float num = value.Force * Time.deltaTime;
								xentity.ApplyMove(vector2.normalized * Mathf.Min(magnitude, num));
							}
						}
					}
				}
			}
		}

		private bool ManipulationOn(XEventArgs e)
		{
			XManipulationOnEventArgs xmanipulationOnEventArgs = e as XManipulationOnEventArgs;
			bool flag = !this._item.ContainsKey(xmanipulationOnEventArgs.Token);
			if (flag)
			{
				this._item.Add(xmanipulationOnEventArgs.Token, xmanipulationOnEventArgs.data);
			}
			return true;
		}

		private bool ManipulationOff(XEventArgs e)
		{
			XManipulationOffEventArgs xmanipulationOffEventArgs = e as XManipulationOffEventArgs;
			bool flag = xmanipulationOffEventArgs.DenyToken == 0L;
			if (flag)
			{
				this._item.Clear();
			}
			else
			{
				this._item.Remove(xmanipulationOffEventArgs.DenyToken);
			}
			return true;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XManipulation");

		private Dictionary<long, XManipulationData> _item = new Dictionary<long, XManipulationData>();
	}
}
