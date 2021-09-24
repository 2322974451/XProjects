using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChooseSpecialEffects : Rpc
	{

		public override uint GetRpcType()
		{
			return 55040U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChooseSpecialEffectsArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChooseSpecialEffectsRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChooseSpecialEffects.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChooseSpecialEffects.OnTimeout(this.oArg);
		}

		public ChooseSpecialEffectsArg oArg = new ChooseSpecialEffectsArg();

		public ChooseSpecialEffectsRes oRes = null;
	}
}
