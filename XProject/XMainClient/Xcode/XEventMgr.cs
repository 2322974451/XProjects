using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XEventMgr : XSingleton<XEventMgr>
	{

		public XEventMgr()
		{
			this._dispatchDelayEventCb = new XTimerMgr.ElapsedEventHandler(this.DispatchDelayEvent);
		}

		public override bool Init()
		{
			this.m_eventPool.Init(this.blockInit, 4);
			return true;
		}

		public void GetBuffer(ref SmallBuffer<XComponent.ComponentEventHandler> sb, int size)
		{
			this.m_eventPool.GetBlock(ref sb, size, 0);
		}

		public void ReturnBuffer(ref SmallBuffer<XComponent.ComponentEventHandler> sb)
		{
			this.m_eventPool.ReturnBlock(ref sb);
		}

		public int GetAllocCount()
		{
			return this.m_eventPool.allocBlockCount;
		}

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

		public void EndRegisterEvent()
		{
			this.m_CacheEventHandlerList = null;
		}

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

		public bool FireEvent(XEventArgs args)
		{
			return this.DispatchEvent(args);
		}

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

		public void CancelDelayEvent(uint token)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(token);
		}

		private void DispatchDelayEvent(object o)
		{
			this.DispatchEvent(o as XEventArgs);
		}

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

		public void RegisterEventPool(EventPoolClear epc)
		{
			this.m_eventPoolClearCb.Add(epc);
		}

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

		private XTimerMgr.ElapsedEventHandler _dispatchDelayEventCb = null;

		private List<EventPoolClear> m_eventPoolClearCb = new List<EventPoolClear>();

		private Dictionary<uint, List<XComponent.ComponentEventHandler>> m_EventHandlerMap = new Dictionary<uint, List<XComponent.ComponentEventHandler>>();

		private List<XComponent.ComponentEventHandler> m_CacheEventHandlerList = null;

		private SmallBufferPool<XComponent.ComponentEventHandler> m_eventPool = new SmallBufferPool<XComponent.ComponentEventHandler>();

		private BlockInfo[] blockInit = new BlockInfo[]
		{
			new BlockInfo(4, 512),
			new BlockInfo(8, 1024),
			new BlockInfo(16, 1024)
		};
	}
}
