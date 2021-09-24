using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_MTShowTopList : Rpc
	{

		public override uint GetRpcType()
		{
			return 10166U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TShowTopListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TShowTopListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MTShowTopList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MTShowTopList.OnTimeout(this.oArg);
		}

		public TShowTopListArg oArg = new TShowTopListArg();

		public TShowTopListRes oRes = null;
	}
}
