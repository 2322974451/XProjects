using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PeerBox : Rpc
	{

		public override uint GetRpcType()
		{
			return 21959U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PeerBoxArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PeerBoxRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PeerBox.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PeerBox.OnTimeout(this.oArg);
		}

		public PeerBoxArg oArg = new PeerBoxArg();

		public PeerBoxRes oRes = null;
	}
}
