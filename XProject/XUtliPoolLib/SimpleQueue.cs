using System;

namespace XUtliPoolLib
{

	public class SimpleQueue
	{

		public bool HasData
		{
			get
			{
				return this.Root != null;
			}
		}

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

		private IQueueObject Root = null;

		private IQueueObject Last = null;
	}
}
