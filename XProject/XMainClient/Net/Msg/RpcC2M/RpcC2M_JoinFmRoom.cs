using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_JoinFmRoom : Rpc
	{

		public override uint GetRpcType()
		{
			return 25303U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JoinLargeRoomArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JoinLargeRoomRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_JoinFmRoom.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_JoinFmRoom.OnTimeout(this.oArg);
		}

		public JoinLargeRoomArg oArg = new JoinLargeRoomArg();

		public JoinLargeRoomRes oRes = null;
	}
}
