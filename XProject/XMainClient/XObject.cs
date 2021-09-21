using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FED RID: 4077
	internal class XObject
	{
		// Token: 0x0600D41F RID: 54303 RVA: 0x0031F583 File Offset: 0x0031D783
		public XObject()
		{
			this.Deprecated = false;
			this.Destroying = false;
		}

		// Token: 0x0600D420 RID: 54304 RVA: 0x0031F5AC File Offset: 0x0031D7AC
		public virtual bool Initilize(int flag)
		{
			this.Deprecated = false;
			this.Destroying = false;
			return true;
		}

		// Token: 0x0600D421 RID: 54305 RVA: 0x0031F5D0 File Offset: 0x0031D7D0
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

		// Token: 0x17003704 RID: 14084
		// (get) Token: 0x0600D422 RID: 54306 RVA: 0x0031F690 File Offset: 0x0031D890
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

		// Token: 0x17003705 RID: 14085
		// (get) Token: 0x0600D423 RID: 54307 RVA: 0x0031F6C4 File Offset: 0x0031D8C4
		public virtual XGameObject EngineObject
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17003706 RID: 14086
		// (get) Token: 0x0600D424 RID: 54308 RVA: 0x0031F6D8 File Offset: 0x0031D8D8
		public virtual ulong ID
		{
			get
			{
				return (this._attr != null) ? this._attr.EntityID : 0UL;
			}
		}

		// Token: 0x17003707 RID: 14087
		// (get) Token: 0x0600D425 RID: 54309 RVA: 0x0031F701 File Offset: 0x0031D901
		// (set) Token: 0x0600D426 RID: 54310 RVA: 0x0031F709 File Offset: 0x0031D909
		public bool Deprecated { get; set; }

		// Token: 0x17003708 RID: 14088
		// (get) Token: 0x0600D427 RID: 54311 RVA: 0x0031F712 File Offset: 0x0031D912
		// (set) Token: 0x0600D428 RID: 54312 RVA: 0x0031F71A File Offset: 0x0031D91A
		public bool Destroying { get; set; }

		// Token: 0x0600D429 RID: 54313 RVA: 0x0031F724 File Offset: 0x0031D924
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

		// Token: 0x0600D42A RID: 54314 RVA: 0x0031F81C File Offset: 0x0031DA1C
		public virtual void OnCreated()
		{
			for (int i = 0; i < this.Components.Count; i++)
			{
				this.Components[i].Attached();
			}
		}

		// Token: 0x0600D42B RID: 54315 RVA: 0x0031F858 File Offset: 0x0031DA58
		public virtual void OnDestroy()
		{
			this.Deprecated = true;
			this.Destroying = false;
		}

		// Token: 0x0600D42C RID: 54316 RVA: 0x0031F86C File Offset: 0x0031DA6C
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

		// Token: 0x0600D42D RID: 54317 RVA: 0x0031F8C0 File Offset: 0x0031DAC0
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

		// Token: 0x0600D42E RID: 54318 RVA: 0x0031F914 File Offset: 0x0031DB14
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

		// Token: 0x0600D42F RID: 54319 RVA: 0x0031F978 File Offset: 0x0031DB78
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

		// Token: 0x0600D430 RID: 54320 RVA: 0x0031F9E0 File Offset: 0x0031DBE0
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

		// Token: 0x0600D431 RID: 54321 RVA: 0x0031FA94 File Offset: 0x0031DC94
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

		// Token: 0x0600D432 RID: 54322 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnComponentAttached(XComponent componentObject)
		{
		}

		// Token: 0x0600D433 RID: 54323 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnComponentDetached(XComponent componentObject)
		{
		}

		// Token: 0x0600D434 RID: 54324 RVA: 0x0031FADC File Offset: 0x0031DCDC
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

		// Token: 0x0600D435 RID: 54325 RVA: 0x001C5366 File Offset: 0x001C3566
		public virtual void FixedUpdate()
		{
		}

		// Token: 0x0600D436 RID: 54326 RVA: 0x0031FB2C File Offset: 0x0031DD2C
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

		// Token: 0x0600D437 RID: 54327 RVA: 0x0031FC04 File Offset: 0x0031DE04
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

		// Token: 0x040060C0 RID: 24768
		private bool needDetachComponent = false;

		// Token: 0x040060C1 RID: 24769
		protected XAttributes _attr = null;

		// Token: 0x040060C2 RID: 24770
		private List<XComponent> internalIterator;
	}
}
