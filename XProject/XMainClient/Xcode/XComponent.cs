using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XComponent
	{

		public abstract uint ID { get; }

		public bool Enabled
		{
			get
			{
				return this._enabled && !this._detached;
			}
			set
			{
				this._enabled = value;
			}
		}

		public bool Detached
		{
			get
			{
				return this._detached;
			}
			set
			{
				this._detached = value;
			}
		}

		public bool ManualUnitBuff
		{
			get
			{
				return this._manualUnitBuff;
			}
			set
			{
				this._manualUnitBuff = value;
			}
		}

		public XObject Host
		{
			get
			{
				return this._host;
			}
		}

		public XEntity Entity
		{
			get
			{
				return this._entity;
			}
		}

		public virtual void InitilizeBuffer()
		{
			XSingleton<XEventMgr>.singleton.GetBuffer(ref this._eventMap, 8);
		}

		public virtual void UninitilizeBuffer()
		{
			XSingleton<XEventMgr>.singleton.ReturnBuffer(ref this._eventMap);
		}

		private XComponent.XEventHandler FindEventHandler(int eventIndex)
		{
			int count = this._eventMap.Count;
			for (int i = 0; i < count; i++)
			{
				XComponent.ComponentEventHandler componentEventHandler = this._eventMap[i];
				bool flag = componentEventHandler.eventIndex == eventIndex;
				if (flag)
				{
					return componentEventHandler.handler;
				}
			}
			return null;
		}

		public virtual void OnReconnect(UnitAppearance data)
		{
		}

		public virtual void Attached()
		{
		}

		public virtual void OnEnterScene()
		{
		}

		public virtual void OnLeaveScene()
		{
		}

		public virtual void Update(float fDeltaT)
		{
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void PostUpdate(float fDeltaT)
		{
		}

		public bool OnEvent(XEventArgs e)
		{
			int eventIndex = XFastEnumIntEqualityComparer<XEventDefine>.ToInt(e.ArgsDefine);
			XComponent.XEventHandler xeventHandler = this.FindEventHandler(eventIndex);
			bool flag = xeventHandler != null;
			return flag && xeventHandler(e);
		}

		public virtual void OnAttachToHost(XObject host)
		{
			this._host = host;
			this._entity = (this._host as XEntity);
			this.BeginRegisterEvent();
			this.EventSubscribe();
			this.EndRegisterEvent();
		}

		public virtual void OnDetachFromHost()
		{
			this.EventUnsubscribe();
			this._host = null;
			this._entity = null;
		}

		public virtual void OnComponentAttachToHost(XComponent c)
		{
		}

		public virtual void OnComponentDetachFromHost(XComponent c)
		{
		}

		private void BeginRegisterEvent()
		{
		}

		private void EndRegisterEvent()
		{
		}

		protected virtual void EventSubscribe()
		{
		}

		protected void EventUnsubscribe()
		{
			this._eventMap.Clear();
		}

		protected void RegisterEvent(XEventDefine eventID, XComponent.XEventHandler handler)
		{
			int num = XFastEnumIntEqualityComparer<XEventDefine>.ToInt(eventID);
			int count = this._eventMap.Count;
			for (int i = 0; i < count; i++)
			{
				XComponent.ComponentEventHandler componentEventHandler = this._eventMap[i];
				bool flag = componentEventHandler.eventIndex == num;
				if (flag)
				{
					return;
				}
			}
			this._eventMap.Add(new XComponent.ComponentEventHandler
			{
				eventIndex = num,
				handler = handler
			});
		}

		public static readonly uint uuID = 0U;

		protected XObject _host = null;

		protected XEntity _entity = null;

		private bool _enabled = true;

		private bool _detached = false;

		protected bool _manualUnitBuff = false;

		protected SmallBuffer<XComponent.ComponentEventHandler> _eventMap;

		public delegate bool XEventHandler(XEventArgs e);

		public struct ComponentEventHandler
		{

			public int eventIndex;

			public XComponent.XEventHandler handler;
		}
	}
}
