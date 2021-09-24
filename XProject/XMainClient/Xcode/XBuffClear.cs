using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffClear : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.ClearTypes == null || rowData.ClearTypes.Length == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffClear(rowData.ClearTypes));
				result = true;
			}
			return result;
		}

		public XBuffClear(byte[] _Types)
		{
			this.m_Types = new HashSet<int>();
			bool flag = _Types != null;
			if (flag)
			{
				for (int i = 0; i < _Types.Length; i++)
				{
					bool flag2 = _Types[i] == 0;
					if (!flag2)
					{
						this.m_Types.Add((int)_Types[i]);
					}
				}
			}
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
			XBuffComponent xbuffComponent = entity.GetXComponent(XBuffComponent.uuID) as XBuffComponent;
			bool flag = xbuffComponent == null;
			if (!flag)
			{
				for (int i = 0; i < xbuffComponent.BuffList.Count; i++)
				{
					XBuff xbuff = xbuffComponent.BuffList[i];
					bool flag2 = xbuff.Valid && this.m_Types.Contains((int)xbuff.ClearType);
					if (flag2)
					{
						XBuffRemoveEventArgs @event = XEventPool<XBuffRemoveEventArgs>.GetEvent();
						@event.xBuffID = xbuff.ID;
						@event.Firer = entity;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
				}
			}
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		public override bool CanBuffAdd(int clearType)
		{
			bool flag = this.m_Types.Contains(clearType);
			return !flag;
		}

		private XEntity _entity;

		private HashSet<int> m_Types;
	}
}
