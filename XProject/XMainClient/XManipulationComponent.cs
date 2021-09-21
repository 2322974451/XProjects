using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F2C RID: 3884
	internal sealed class XManipulationComponent : XComponent
	{
		// Token: 0x170035E0 RID: 13792
		// (get) Token: 0x0600CDDB RID: 52699 RVA: 0x002F9270 File Offset: 0x002F7470
		public override uint ID
		{
			get
			{
				return XManipulationComponent.uuID;
			}
		}

		// Token: 0x0600CDDC RID: 52700 RVA: 0x002F9287 File Offset: 0x002F7487
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Manipulation_On, new XComponent.XEventHandler(this.ManipulationOn));
			base.RegisterEvent(XEventDefine.XEvent_Manipulation_Off, new XComponent.XEventHandler(this.ManipulationOff));
		}

		// Token: 0x0600CDDD RID: 52701 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600CDDE RID: 52702 RVA: 0x002F92BA File Offset: 0x002F74BA
		public override void OnDetachFromHost()
		{
			this._item.Clear();
			base.OnDetachFromHost();
		}

		// Token: 0x0600CDDF RID: 52703 RVA: 0x002F92D0 File Offset: 0x002F74D0
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

		// Token: 0x0600CDE0 RID: 52704 RVA: 0x002F947C File Offset: 0x002F767C
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

		// Token: 0x0600CDE1 RID: 52705 RVA: 0x002F94C8 File Offset: 0x002F76C8
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

		// Token: 0x04005BB9 RID: 23481
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XManipulation");

		// Token: 0x04005BBA RID: 23482
		private Dictionary<long, XManipulationData> _item = new Dictionary<long, XManipulationData>();
	}
}
