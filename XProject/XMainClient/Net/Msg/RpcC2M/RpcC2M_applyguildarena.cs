using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_applyguildarena : Rpc
	{

		public override uint GetRpcType()
		{
			return 50879U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<applyguildarenaarg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<applyguildarenares>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_applyguildarena.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_applyguildarena.OnTimeout(this.oArg);
		}

		public applyguildarenaarg oArg = new applyguildarenaarg();

		public applyguildarenares oRes = null;
	}
}
