using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffManipulate : BuffEffect
	{

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

		public XBuffManipulate(XBuff buff)
		{
			this._Buff = buff;
		}

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

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			XManipulationOffEventArgs @event = XEventPool<XManipulationOffEventArgs>.GetEvent();
			@event.DenyToken = this._Token;
			@event.Firer = entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		private XEntity _entity;

		private XBuff _Buff;

		private long _Token;
	}
}
