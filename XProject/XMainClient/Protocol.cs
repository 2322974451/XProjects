using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using XUtliPoolLib;

namespace XMainClient
{

	public abstract class Protocol
	{

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

		public virtual uint GetProtoType()
		{
			return 0U;
		}

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

		public abstract void Serialize(MemoryStream stream);

		public abstract void DeSerialize(MemoryStream stream);

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

		public static void ManualReturn()
		{
			CNetProcessor.ManualReturnProtocol();
		}

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

		public virtual void Process()
		{
		}

		public static Dictionary<uint, Protocol.ProtocolFactry> sm_RegistProtocolFactory = new Dictionary<uint, Protocol.ProtocolFactry>(120);

		protected EProtocolErrCode m_threadErrCode = EProtocolErrCode.ENoErr;

		public class ProtocolFactry
		{

			public ProtocolFactry(Protocol p)
			{
				this.protocol = p;
				this.queue = new Queue<Protocol>();
			}

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

			public void Return(Protocol protocol)
			{
				this.queue.Enqueue(protocol);
			}

			public Protocol protocol = null;

			public Queue<Protocol> queue;
		}
	}
}
