using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XObject
	{

		public XObject()
		{
			this.Deprecated = false;
			this.Destroying = false;
		}

		public virtual bool Initilize(int flag)
		{
			this.Deprecated = false;
			this.Destroying = false;
			return true;
		}

		public virtual void Uninitilize()
		{
			bool flag = this.internalIterator != null;
			if (flag)
			{
				for (int i = this.internalIterator.Count - 1; i >= 0; i--)
				{
					XComponent xcomponent = this.internalIterator[i];
					xcomponent.OnDetachFromHost();
					this.OnComponentDetached(xcomponent);
					this.Components.RemoveAt(i);
					XSingleton<XComponentMgr>.singleton.RemoveComponent(xcomponent);
				}
				ListPool<XComponent>.Release(this.internalIterator);
				this.internalIterator = null;
			}
			XOnEntityDeletedArgs @event = XEventPool<XOnEntityDeletedArgs>.GetEvent();
			@event.Id = this.ID;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this._attr = null;
		}

		public List<XComponent> Components
		{
			get
			{
				bool flag = this.internalIterator == null;
				if (flag)
				{
					this.internalIterator = ListPool<XComponent>.Get();
				}
				return this.internalIterator;
			}
		}

		public virtual XGameObject EngineObject
		{
			get
			{
				return null;
			}
		}

		public virtual ulong ID
		{
			get
			{
				return (this._attr != null) ? this._attr.EntityID : 0UL;
			}
		}

		public bool Deprecated { get; set; }

		public bool Destroying { get; set; }

		public virtual bool DispatchEvent(XEventArgs e)
		{
			bool flag = false;
			int count = this.Components.Count;
			for (int i = 0; i < this.Components.Count; i++)
			{
				bool flag2 = i >= this.Components.Count;
				if (flag2)
				{
					break;
				}
				XComponent xcomponent = this.Components[i];
				bool flag3 = xcomponent != null && xcomponent.Enabled;
				if (flag3)
				{
					bool flag4 = xcomponent.OnEvent(e);
					flag = (flag4 || flag);
				}
				bool flag5 = count != this.Components.Count;
				if (flag5)
				{
					XSingleton<XDebug>.singleton.AddWarningLog2("Components Count change:{0}-{1}-{2}-{3}", new object[]
					{
						count,
						this.Components.Count,
						i,
						xcomponent.ID
					});
					break;
				}
			}
			return flag;
		}

		public virtual void OnCreated()
		{
			for (int i = 0; i < this.Components.Count; i++)
			{
				this.Components[i].Attached();
			}
		}

		public virtual void OnDestroy()
		{
			this.Deprecated = true;
			this.Destroying = false;
		}

		public void OnEnterScene()
		{
			for (int i = 0; i < this.Components.Count; i++)
			{
				XComponent xcomponent = this.Components[i];
				bool flag = xcomponent != null && !xcomponent.Detached;
				if (flag)
				{
					xcomponent.OnEnterScene();
				}
			}
		}

		public void OnLeaveScene()
		{
			for (int i = 0; i < this.Components.Count; i++)
			{
				XComponent xcomponent = this.Components[i];
				bool flag = xcomponent != null && !xcomponent.Detached;
				if (flag)
				{
					xcomponent.OnLeaveScene();
				}
			}
		}

		public XComponent GetXComponent(uint uuid)
		{
			int i = 0;
			int count = this.Components.Count;
			while (i < count)
			{
				XComponent xcomponent = this.Components[i];
				bool flag = xcomponent != null && xcomponent.ID == uuid && !xcomponent.Detached;
				if (flag)
				{
					return xcomponent;
				}
				i++;
			}
			return null;
		}

		private XComponent GetXComponent(uint uuid, ref int index)
		{
			int i = 0;
			int count = this.Components.Count;
			while (i < count)
			{
				XComponent xcomponent = this.Components[i];
				bool flag = xcomponent != null && xcomponent.ID == uuid && !xcomponent.Detached;
				if (flag)
				{
					index = i;
					return xcomponent;
				}
				i++;
			}
			return null;
		}

		public void AttachComponent(XComponent componentObject)
		{
			bool flag = componentObject == null;
			if (!flag)
			{
				int num = this.Components.IndexOf(componentObject);
				bool flag2 = num >= 0 && num < this.Components.Count;
				if (flag2)
				{
					bool detached = componentObject.Detached;
					if (detached)
					{
						componentObject.Detached = false;
					}
					else
					{
						this.Components[num] = componentObject;
						XSingleton<XDebug>.singleton.AddErrorLog("Component ", componentObject.ToString(), " for ", this.ToString(), " added too many times.", null);
					}
				}
				else
				{
					this.Components.Add(componentObject);
				}
				componentObject.OnAttachToHost(this);
				this.OnComponentAttached(componentObject);
			}
		}

		public void DetachComponent(uint id)
		{
			int num = -1;
			XComponent xcomponent = this.GetXComponent(id, ref num);
			bool flag = xcomponent != null && num >= 0 && num < this.Components.Count;
			if (flag)
			{
				this.needDetachComponent = true;
				xcomponent.Detached = true;
			}
		}

		protected virtual void OnComponentAttached(XComponent componentObject)
		{
		}

		protected virtual void OnComponentDetached(XComponent componentObject)
		{
		}

		public virtual void Update(float fDeltaT)
		{
			for (int i = 0; i < this.Components.Count; i++)
			{
				XComponent xcomponent = this.Components[i];
				bool flag = xcomponent != null && xcomponent.Enabled;
				if (flag)
				{
					xcomponent.Update(fDeltaT);
				}
			}
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void PostUpdate(float fDeltaT)
		{
			for (int i = 0; i < this.Components.Count; i++)
			{
				XComponent xcomponent = this.Components[i];
				bool flag = xcomponent != null && xcomponent.Enabled;
				if (flag)
				{
					xcomponent.PostUpdate(fDeltaT);
				}
			}
			bool flag2 = this.needDetachComponent;
			if (flag2)
			{
				for (int j = this.Components.Count - 1; j >= 0; j--)
				{
					XComponent xcomponent2 = this.Components[j];
					bool detached = xcomponent2.Detached;
					if (detached)
					{
						xcomponent2.OnDetachFromHost();
						this.OnComponentDetached(xcomponent2);
						this.Components.RemoveAt(j);
						XSingleton<XComponentMgr>.singleton.RemoveComponent(xcomponent2);
					}
				}
				this.needDetachComponent = false;
			}
		}

		public virtual void OnReconnect(UnitAppearance data)
		{
			for (int i = 0; i < this.Components.Count; i++)
			{
				XComponent xcomponent = this.Components[i];
				bool flag = xcomponent != null && !xcomponent.Detached;
				if (flag)
				{
					xcomponent.OnReconnect(data);
				}
			}
		}

		private bool needDetachComponent = false;

		protected XAttributes _attr = null;

		private List<XComponent> internalIterator;
	}
}
