using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EBE RID: 3774
	public abstract class Protocol
	{
		// Token: 0x170034F9 RID: 13561
		// (get) Token: 0x0600C87A RID: 51322 RVA: 0x002CE804 File Offset: 0x002CCA04
		// (set) Token: 0x0600C87B RID: 51323 RVA: 0x002CE81C File Offset: 0x002CCA1C
		public EProtocolErrCode ThreadErrCode
		{
			get
			{
				return this.m_threadErrCode;
			}
			set
			{
				this.m_threadErrCode = value;
			}
		}

		// Token: 0x0600C87C RID: 51324 RVA: 0x002CE828 File Offset: 0x002CCA28
		public virtual uint GetProtoType()
		{
			return 0U;
		}

		// Token: 0x0600C87D RID: 51325 RVA: 0x002CE83C File Offset: 0x002CCA3C
		public void SerializeWithHead(MemoryStream stream)
		{
			long position = stream.Position;
			ProtocolHead sharedHead = ProtocolHead.SharedHead;
			sharedHead.Reset();
			sharedHead.type = this.GetProtoType();
			sharedHead.flag = 0U;
			sharedHead.Serialize(stream);
			this.Serialize(stream);
			long position2 = stream.Position;
			uint value = (uint)(position2 - position - 4L);
			stream.Position = position;
			stream.Write(BitConverter.GetBytes(value), 0, 4);
			stream.Position = position2;
		}

		// Token: 0x0600C87E RID: 51326
		public abstract void Serialize(MemoryStream stream);

		// Token: 0x0600C87F RID: 51327
		public abstract void DeSerialize(MemoryStream stream);

		// Token: 0x0600C880 RID: 51328 RVA: 0x002CE8B0 File Offset: 0x002CCAB0
		public static Protocol GetProtocolThread(uint dwType)
		{
			Protocol result = null;
			Monitor.Enter(Protocol.sm_RegistProtocolFactory);
			Protocol.ProtocolFactry protocolFactry = null;
			bool flag = Protocol.sm_RegistProtocolFactory.TryGetValue(dwType, out protocolFactry);
			if (flag)
			{
				result = protocolFactry.Get();
			}
			Monitor.Exit(Protocol.sm_RegistProtocolFactory);
			return result;
		}

		// Token: 0x0600C881 RID: 51329 RVA: 0x002CE8F8 File Offset: 0x002CCAF8
		public static void ReturnProtocolThread(Protocol protocol)
		{
			bool flag = Protocol.sm_RegistProtocolFactory != null && protocol != null;
			if (flag)
			{
				Monitor.Enter(Protocol.sm_RegistProtocolFactory);
				Protocol.ProtocolFactry protocolFactry = null;
				bool flag2 = Protocol.sm_RegistProtocolFactory.TryGetValue(protocol.GetProtoType(), out protocolFactry);
				if (flag2)
				{
					protocolFactry.Return(protocol);
				}
				Monitor.Exit(Protocol.sm_RegistProtocolFactory);
			}
		}

		// Token: 0x0600C882 RID: 51330 RVA: 0x002CE954 File Offset: 0x002CCB54
		public static bool RegistProtocol(Protocol protocol)
		{
			bool flag = Protocol.sm_RegistProtocolFactory.ContainsKey(protocol.GetProtoType());
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Protocol.sm_RegistProtocolFactory.Add(protocol.GetProtoType(), new Protocol.ProtocolFactry(protocol));
				result = true;
			}
			return result;
		}

		// Token: 0x0600C883 RID: 51331 RVA: 0x002CE997 File Offset: 0x002CCB97
		public static void ManualReturn()
		{
			CNetProcessor.ManualReturnProtocol();
		}

		// Token: 0x0600C884 RID: 51332 RVA: 0x002CE9A0 File Offset: 0x002CCBA0
		public virtual bool CheckPValid()
		{
			bool flag = this.m_threadErrCode == EProtocolErrCode.EDeSerializeErr;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Ptc EDeSerializeErr Type:", this.GetProtoType().ToString(), null, null, null, null);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600C885 RID: 51333 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Process()
		{
		}

		// Token: 0x040058A9 RID: 22697
		public static Dictionary<uint, Protocol.ProtocolFactry> sm_RegistProtocolFactory = new Dictionary<uint, Protocol.ProtocolFactry>(120);

		// Token: 0x040058AA RID: 22698
		protected EProtocolErrCode m_threadErrCode = EProtocolErrCode.ENoErr;

		// Token: 0x020019D8 RID: 6616
		public class ProtocolFactry
		{
			// Token: 0x060110A6 RID: 69798 RVA: 0x00455585 File Offset: 0x00453785
			public ProtocolFactry(Protocol p)
			{
				this.protocol = p;
				this.queue = new Queue<Protocol>();
			}

			// Token: 0x060110A7 RID: 69799 RVA: 0x004555A8 File Offset: 0x004537A8
			public Protocol Create()
			{
				bool flag = this.protocol != null;
				Protocol result;
				if (flag)
				{
					result = (Activator.CreateInstance(this.protocol.GetType()) as Protocol);
				}
				else
				{
					result = null;
				}
				return result;
			}

			// Token: 0x060110A8 RID: 69800 RVA: 0x004555E0 File Offset: 0x004537E0
			public Protocol Get()
			{
				bool flag = this.queue.Count > 0;
				Protocol result;
				if (flag)
				{
					result = this.queue.Dequeue();
				}
				else
				{
					result = this.Create();
				}
				return result;
			}

			// Token: 0x060110A9 RID: 69801 RVA: 0x0045561A File Offset: 0x0045381A
			public void Return(Protocol protocol)
			{
				this.queue.Enqueue(protocol);
			}

			// Token: 0x04008024 RID: 32804
			public Protocol protocol = null;

			// Token: 0x04008025 RID: 32805
			public Queue<Protocol> queue;
		}
	}
}
