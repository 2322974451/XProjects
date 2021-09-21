using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200154B RID: 5451
	internal class RpcC2G_PetOperationOther : Rpc
	{
		// Token: 0x0600EA46 RID: 59974 RVA: 0x00343FA0 File Offset: 0x003421A0
		public override uint GetRpcType()
		{
			return 58525U;
		}

		// Token: 0x0600EA47 RID: 59975 RVA: 0x00343FB7 File Offset: 0x003421B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PetOperationOtherArg>(stream, this.oArg);
		}

		// Token: 0x0600EA48 RID: 59976 RVA: 0x00343FC7 File Offset: 0x003421C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PetOperationOtherRes>(stream);
		}

		// Token: 0x0600EA49 RID: 59977 RVA: 0x00343FD6 File Offset: 0x003421D6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PetOperationOther.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EA4A RID: 59978 RVA: 0x00343FF2 File Offset: 0x003421F2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PetOperationOther.OnTimeout(this.oArg);
		}

		// Token: 0x0400653A RID: 25914
		public PetOperationOtherArg oArg = new PetOperationOtherArg();

		// Token: 0x0400653B RID: 25915
		public PetOperationOtherRes oRes = null;
	}
}
