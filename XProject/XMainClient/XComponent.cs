using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F21 RID: 3873
	internal abstract class XComponent
	{
		// Token: 0x170035A5 RID: 13733
		// (get) Token: 0x0600CD10 RID: 52496
		public abstract uint ID { get; }

		// Token: 0x170035A6 RID: 13734
		// (get) Token: 0x0600CD11 RID: 52497 RVA: 0x002F43B8 File Offset: 0x002F25B8
		// (set) Token: 0x0600CD12 RID: 52498 RVA: 0x002F43DE File Offset: 0x002F25DE
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

		// Token: 0x170035A7 RID: 13735
		// (get) Token: 0x0600CD13 RID: 52499 RVA: 0x002F43E8 File Offset: 0x002F25E8
		// (set) Token: 0x0600CD14 RID: 52500 RVA: 0x002F4400 File Offset: 0x002F2600
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

		// Token: 0x170035A8 RID: 13736
		// (get) Token: 0x0600CD15 RID: 52501 RVA: 0x002F440C File Offset: 0x002F260C
		// (set) Token: 0x0600CD16 RID: 52502 RVA: 0x002F4424 File Offset: 0x002F2624
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

		// Token: 0x170035A9 RID: 13737
		// (get) Token: 0x0600CD17 RID: 52503 RVA: 0x002F4430 File Offset: 0x002F2630
		public XObject Host
		{
			get
			{
				return this._host;
			}
		}

		// Token: 0x170035AA RID: 13738
		// (get) Token: 0x0600CD18 RID: 52504 RVA: 0x002F4448 File Offset: 0x002F2648
		public XEntity Entity
		{
			get
			{
				return this._entity;
			}
		}

		// Token: 0x0600CD19 RID: 52505 RVA: 0x002F4460 File Offset: 0x002F2660
		public virtual void InitilizeBuffer()
		{
			XSingleton<XEventMgr>.singleton.GetBuffer(ref this._eventMap, 8);
		}

		// Token: 0x0600CD1A RID: 52506 RVA: 0x002F4475 File Offset: 0x002F2675
		public virtual void UninitilizeBuffer()
		{
			XSingleton<XEventMgr>.singleton.ReturnBuffer(ref this._eventMap);
		}

		// Token: 0x0600CD1B RID: 52507 RVA: 0x002F448C File Offset: 0x002F268C
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

		// Token: 0x0600CD1C RID: 52508 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnReconnect(UnitAppearance data)
		{
		}

		// Token: 0x0600CD1D RID: 52509 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Attached()
		{
		}

		// Token: 0x0600CD1E RID: 52510 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnEnterScene()
		{
		}

		// Token: 0x0600CD1F RID: 52511 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnLeaveScene()
		{
		}

		// Token: 0x0600CD20 RID: 52512 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Update(float fDeltaT)
		{
		}

		// Token: 0x0600CD21 RID: 52513 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void FixedUpdate()
		{
		}

		// Token: 0x0600CD22 RID: 52514 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void PostUpdate(float fDeltaT)
		{
		}

		// Token: 0x0600CD23 RID: 52515 RVA: 0x002F44E8 File Offset: 0x002F26E8
		public bool OnEvent(XEventArgs e)
		{
			int eventIndex = XFastEnumIntEqualityComparer<XEventDefine>.ToInt(e.ArgsDefine);
			XComponent.XEventHandler xeventHandler = this.FindEventHandler(eventIndex);
			bool flag = xeventHandler != null;
			return flag && xeventHandler(e);
		}

		// Token: 0x0600CD24 RID: 52516 RVA: 0x002F4522 File Offset: 0x002F2722
		public virtual void OnAttachToHost(XObject host)
		{
			this._host = host;
			this._entity = (this._host as XEntity);
			this.BeginRegisterEvent();
			this.EventSubscribe();
			this.EndRegisterEvent();
		}

		// Token: 0x0600CD25 RID: 52517 RVA: 0x002F4552 File Offset: 0x002F2752
		public virtual void OnDetachFromHost()
		{
			this.EventUnsubscribe();
			this._host = null;
			this._entity = null;
		}

		// Token: 0x0600CD26 RID: 52518 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnComponentAttachToHost(XComponent c)
		{
		}

		// Token: 0x0600CD27 RID: 52519 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OnComponentDetachFromHost(XComponent c)
		{
		}

		// Token: 0x0600CD28 RID: 52520 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void BeginRegisterEvent()
		{
		}

		// Token: 0x0600CD29 RID: 52521 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void EndRegisterEvent()
		{
		}

		// Token: 0x0600CD2A RID: 52522 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void EventSubscribe()
		{
		}

		// Token: 0x0600CD2B RID: 52523 RVA: 0x002F456A File Offset: 0x002F276A
		protected void EventUnsubscribe()
		{
			this._eventMap.Clear();
		}

		// Token: 0x0600CD2C RID: 52524 RVA: 0x002F457C File Offset: 0x002F277C
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

		// Token: 0x04005B37 RID: 23351
		public static readonly uint uuID = 0U;

		// Token: 0x04005B38 RID: 23352
		protected XObject _host = null;

		// Token: 0x04005B39 RID: 23353
		protected XEntity _entity = null;

		// Token: 0x04005B3A RID: 23354
		private bool _enabled = true;

		// Token: 0x04005B3B RID: 23355
		private bool _detached = false;

		// Token: 0x04005B3C RID: 23356
		protected bool _manualUnitBuff = false;

		// Token: 0x04005B3D RID: 23357
		protected SmallBuffer<XComponent.ComponentEventHandler> _eventMap;

		// Token: 0x020019EE RID: 6638
		// (Invoke) Token: 0x060110DF RID: 69855
		public delegate bool XEventHandler(XEventArgs e);

		// Token: 0x020019EF RID: 6639
		public struct ComponentEventHandler
		{
			// Token: 0x040080A6 RID: 32934
			public int eventIndex;

			// Token: 0x040080A7 RID: 32935
			public XComponent.XEventHandler handler;
		}
	}
}
