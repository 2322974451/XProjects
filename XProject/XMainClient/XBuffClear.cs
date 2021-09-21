using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200089A RID: 2202
	internal class XBuffClear : BuffEffect
	{
		// Token: 0x060085EF RID: 34287 RVA: 0x0010CA48 File Offset: 0x0010AC48
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

		// Token: 0x060085F0 RID: 34288 RVA: 0x0010CA8C File Offset: 0x0010AC8C
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

		// Token: 0x060085F1 RID: 34289 RVA: 0x0010CAE8 File Offset: 0x0010ACE8
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

		// Token: 0x060085F2 RID: 34290 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		// Token: 0x060085F3 RID: 34291 RVA: 0x0010CB94 File Offset: 0x0010AD94
		public override bool CanBuffAdd(int clearType)
		{
			bool flag = this.m_Types.Contains(clearType);
			return !flag;
		}

		// Token: 0x040029B1 RID: 10673
		private XEntity _entity;

		// Token: 0x040029B2 RID: 10674
		private HashSet<int> m_Types;
	}
}
