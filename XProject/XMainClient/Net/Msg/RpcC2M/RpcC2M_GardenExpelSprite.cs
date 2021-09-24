using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GardenExpelSprite : Rpc
	{

		public override uint GetRpcType()
		{
			return 3250U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenExpelSpriteArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenExpelSpriteRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenExpelSprite.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenExpelSprite.OnTimeout(this.oArg);
		}

		public GardenExpelSpriteArg oArg = new GardenExpelSpriteArg();

		public GardenExpelSpriteRes oRes = null;
	}
}
