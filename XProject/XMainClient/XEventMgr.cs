using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FB4 RID: 4020
	internal sealed class XEventMgr : XSingleton<XEventMgr>
	{
		// Token: 0x0600D10E RID: 53518 RVA: 0x00305718 File Offset: 0x00303918
		public XEventMgr()
		{
			this._dispatchDelayEventCb = new XTimerMgr.ElapsedEventHandler(this.DispatchDelayEvent);
		}

		// Token: 0x0600D10F RID: 53519 RVA: 0x003057B4 File Offset: 0x003039B4
		public override bool Init()
		{
			this.m_eventPool.Init(this.blockInit, 4);
			return true;
		}

		// Token: 0x0600D110 RID: 53520 RVA: 0x003057DA File Offset: 0x003039DA
		public void GetBuffer(ref SmallBuffer<XComponent.ComponentEventHandler> sb, int size)
		{
			this.m_eventPool.GetBlock(ref sb, size, 0);
		}

		// Token: 0x0600D111 RID: 53521 RVA: 0x003057EC File Offset: 0x003039EC
		public void ReturnBuffer(ref SmallBuffer<XComponent.ComponentEventHandler> sb)
		{
			this.m_eventPool.ReturnBlock(ref sb);
		}

		// Token: 0x0600D112 RID: 53522 RVA: 0x003057FC File Offset: 0x003039FC
		public int GetAllocCount()
		{
			return this.m_eventPool.allocBlockCount;
		}

		// Token: 0x0600D113 RID: 53523 RVA: 0x0030581C File Offset: 0x00303A1C
		public void BeginRegisterEvent(uint componentID)
		{
			this.m_CacheEventHandlerList = null;
			bool flag = this.m_EventHandlerMap.TryGetValue(componentID, out this.m_CacheEventHandlerList);
			if (flag)
			{
				this.m_CacheEventHandlerList = null;
			}
			else
			{
				this.m_CacheEventHandlerList = new List<XComponent.ComponentEventHandler>();
				this.m_EventHandlerMap.Add(componentID, this.m_CacheEventHandlerList);
			}
		}

		// Token: 0x0600D114 RID: 53524 RVA: 0x00305872 File Offset: 0x00303A72
		public void EndRegisterEvent()
		{
			this.m_CacheEventHandlerList = null;
		}

		// Token: 0x0600D115 RID: 53525 RVA: 0x0030587C File Offset: 0x00303A7C
		public void RegisterEvent(XEventDefine eventID, XComponent.XEventHandler handler)
		{
			bool flag = this.m_CacheEventHandlerList != null;
			if (flag)
			{
				int num = XFastEnumIntEqualityComparer<XEventDefine>.ToInt(eventID);
				int count = this.m_CacheEventHandlerList.Count;
				for (int i = 0; i < count; i++)
				{
					XComponent.ComponentEventHandler componentEventHandler = this.m_CacheEventHandlerList[i];
					bool flag2 = componentEventHandler.eventIndex == num;
					if (flag2)
					{
						return;
					}
				}
				XComponent.ComponentEventHandler item = default(XComponent.ComponentEventHandler);
				item.eventIndex = num;
				item.handler = handler;
				this.m_CacheEventHandlerList.Add(item);
			}
		}

		// Token: 0x0600D116 RID: 53526 RVA: 0x0030590C File Offset: 0x00303B0C
		public bool OnEvent(uint componentID, XEventArgs e)
		{
			List<XComponent.ComponentEventHandler> list = null;
			bool flag = this.m_EventHandlerMap.TryGetValue(componentID, out list);
			if (flag)
			{
				int num = XFastEnumIntEqualityComparer<XEventDefine>.ToInt(e.ArgsDefine);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					XComponent.ComponentEventHandler componentEventHandler = list[i];
					bool flag2 = componentEventHandler.eventIndex == num;
					if (flag2)
					{
						bool flag3 = componentEventHandler.handler != null;
						if (flag3)
						{
							return componentEventHandler.handler(e);
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600D117 RID: 53527 RVA: 0x003059A0 File Offset: 0x00303BA0
		public bool FireEvent(XEventArgs args)
		{
			return this.DispatchEvent(args);
		}

		// Token: 0x0600D118 RID: 53528 RVA: 0x003059BC File Offset: 0x00303BBC
		public uint FireEvent(XEventArgs args, float delay)
		{
			bool flag = delay <= 0f;
			uint result;
			if (flag)
			{
				this.DispatchEvent(args);
				result = 0U;
			}
			else
			{
				result = XSingleton<XTimerMgr>.singleton.SetTimer(delay, this._dispatchDelayEventCb, args);
			}
			return result;
		}

		// Token: 0x0600D119 RID: 53529 RVA: 0x003059FC File Offset: 0x00303BFC
		public void CancelDelayEvent(uint token)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(token);
		}

		// Token: 0x0600D11A RID: 53530 RVA: 0x00305A0B File Offset: 0x00303C0B
		private void DispatchDelayEvent(object o)
		{
			this.DispatchEvent(o as XEventArgs);
		}

		// Token: 0x0600D11B RID: 53531 RVA: 0x00305A1C File Offset: 0x00303C1C
		private bool DispatchEvent(XEventArgs args)
		{
			bool result = false;
			bool flag = args.Firer != null && (!args.Firer.Deprecated || args.DepracatedPass);
			if (flag)
			{
				result = args.Firer.DispatchEvent(args);
			}
			bool flag2 = !args.ManualRecycle;
			if (flag2)
			{
				args.Recycle();
			}
			return result;
		}

		// Token: 0x0600D11C RID: 53532 RVA: 0x00305A77 File Offset: 0x00303C77
		public void RegisterEventPool(EventPoolClear epc)
		{
			this.m_eventPoolClearCb.Add(epc);
		}

		// Token: 0x0600D11D RID: 53533 RVA: 0x00305A88 File Offset: 0x00303C88
		public void Clear()
		{
			for (int i = 0; i < this.m_eventPoolClearCb.Count; i++)
			{
				EventPoolClear eventPoolClear = this.m_eventPoolClearCb[i];
				bool flag = eventPoolClear != null;
				if (flag)
				{
					eventPoolClear();
				}
			}
			this.m_eventPoolClearCb.Clear();
			this.m_EventHandlerMap.Clear();
		}

		// Token: 0x04005EA0 RID: 24224
		private XTimerMgr.ElapsedEventHandler _dispatchDelayEventCb = null;

		// Token: 0x04005EA1 RID: 24225
		private List<EventPoolClear> m_eventPoolClearCb = new List<EventPoolClear>();

		// Token: 0x04005EA2 RID: 24226
		private Dictionary<uint, List<XComponent.ComponentEventHandler>> m_EventHandlerMap = new Dictionary<uint, List<XComponent.ComponentEventHandler>>();

		// Token: 0x04005EA3 RID: 24227
		private List<XComponent.ComponentEventHandler> m_CacheEventHandlerList = null;

		// Token: 0x04005EA4 RID: 24228
		private SmallBufferPool<XComponent.ComponentEventHandler> m_eventPool = new SmallBufferPool<XComponent.ComponentEventHandler>();

		// Token: 0x04005EA5 RID: 24229
		private BlockInfo[] blockInit = new BlockInfo[]
		{
			new BlockInfo(4, 512),
			new BlockInfo(8, 1024),
			new BlockInfo(16, 1024)
		};
	}
}
