using System;

namespace XUtliPoolLib
{
	// Token: 0x020001DF RID: 479
	public class SimpleQueue
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x0003A1AC File Offset: 0x000383AC
		public bool HasData
		{
			get
			{
				return this.Root != null;
			}
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x0003A1C8 File Offset: 0x000383C8
		public void Clear()
		{
			IQueueObject next;
			for (IQueueObject queueObject = this.Root; queueObject != null; queueObject = next)
			{
				next = queueObject.next;
				queueObject.next = null;
			}
			this.Root = null;
			this.Last = null;
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x0003A208 File Offset: 0x00038408
		public void Enqueue(IQueueObject obj)
		{
			bool flag = obj != null;
			if (flag)
			{
				obj.next = null;
				bool flag2 = this.Root == null;
				if (flag2)
				{
					this.Root = obj;
					this.Last = this.Root;
				}
				else
				{
					bool flag3 = this.Last != null;
					if (flag3)
					{
						this.Last.next = obj;
						this.Last = obj;
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("queue state error", null, null, null, null, null);
					}
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddWarningLog("can not enqueue null object", null, null, null, null, null);
			}
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x0003A2A4 File Offset: 0x000384A4
		public T Dequeue<T>() where T : IQueueObject, new()
		{
			IQueueObject queueObject = null;
			bool flag = this.Root != null;
			if (flag)
			{
				queueObject = this.Root;
				this.Root = this.Root.next;
			}
			bool flag2 = this.Root == null;
			if (flag2)
			{
				this.Last = null;
			}
			return (T)(queueObject);
		}

		// Token: 0x0400056C RID: 1388
		private IQueueObject Root = null;

		// Token: 0x0400056D RID: 1389
		private IQueueObject Last = null;
	}
}
