using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200102F RID: 4143
	internal class RpcC2G_DecomposeEquipment : Rpc
	{
		// Token: 0x0600D569 RID: 54633 RVA: 0x00323FC4 File Offset: 0x003221C4
		public override uint GetRpcType()
		{
			return 6556U;
		}

		// Token: 0x0600D56A RID: 54634 RVA: 0x00323FDB File Offset: 0x003221DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DecomposeEquipmentArg>(stream, this.oArg);
		}

		// Token: 0x0600D56B RID: 54635 RVA: 0x00323FEB File Offset: 0x003221EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DecomposeEquipmentRes>(stream);
		}

		// Token: 0x0600D56C RID: 54636 RVA: 0x00323FFA File Offset: 0x003221FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DecomposeEquipment.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D56D RID: 54637 RVA: 0x00324016 File Offset: 0x00322216
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DecomposeEquipment.OnTimeout(this.oArg);
		}

		// Token: 0x04006121 RID: 24865
		public DecomposeEquipmentArg oArg = new DecomposeEquipmentArg();

		// Token: 0x04006122 RID: 24866
		public DecomposeEquipmentRes oRes = new DecomposeEquipmentRes();
	}
}
