using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008A8 RID: 2216
	internal class XBuffManipulate : BuffEffect
	{
		// Token: 0x06008636 RID: 34358 RVA: 0x0010E074 File Offset: 0x0010C274
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.Manipulate == null || rowData.Manipulate.Length == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffManipulate(buff));
				result = true;
			}
			return result;
		}

		// Token: 0x06008637 RID: 34359 RVA: 0x0010E0B1 File Offset: 0x0010C2B1
		public XBuffManipulate(XBuff buff)
		{
			this._Buff = buff;
		}

		// Token: 0x06008638 RID: 34360 RVA: 0x0010E0C4 File Offset: 0x0010C2C4
		private float _GetParam(int index)
		{
			bool flag = this._Buff.BuffInfo.Manipulate == null || this._Buff.BuffInfo.Manipulate.Length <= index;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				result = this._Buff.BuffInfo.Manipulate[index];
			}
			return result;
		}

		// Token: 0x06008639 RID: 34361 RVA: 0x0010E124 File Offset: 0x0010C324
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
			XManipulationData xmanipulationData = new XManipulationData();
			xmanipulationData.Degree = 360f;
			xmanipulationData.Force = this._GetParam(0);
			xmanipulationData.Radius = this._GetParam(1);
			xmanipulationData.TargetIsOpponent = ((int)this._GetParam(2) == 0);
			XManipulationOnEventArgs @event = XEventPool<XManipulationOnEventArgs>.GetEvent();
			@event.data = xmanipulationData;
			@event.Firer = this._entity;
			this._Token = @event.Token;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600863A RID: 34362 RVA: 0x0010E1A8 File Offset: 0x0010C3A8
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			XManipulationOffEventArgs @event = XEventPool<XManipulationOffEventArgs>.GetEvent();
			@event.DenyToken = this._Token;
			@event.Firer = entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x040029D8 RID: 10712
		private XEntity _entity;

		// Token: 0x040029D9 RID: 10713
		private XBuff _Buff;

		// Token: 0x040029DA RID: 10714
		private long _Token;
	}
}
