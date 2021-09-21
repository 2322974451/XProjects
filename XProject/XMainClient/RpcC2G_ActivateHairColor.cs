using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001543 RID: 5443
	internal class RpcC2G_ActivateHairColor : Rpc
	{
		// Token: 0x0600EA22 RID: 59938 RVA: 0x00343C70 File Offset: 0x00341E70
		public override uint GetRpcType()
		{
			return 52321U;
		}

		// Token: 0x0600EA23 RID: 59939 RVA: 0x00343C87 File Offset: 0x00341E87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivateHairColorArg>(stream, this.oArg);
		}

		// Token: 0x0600EA24 RID: 59940 RVA: 0x00343C97 File Offset: 0x00341E97
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActivateHairColorRes>(stream);
		}

		// Token: 0x0600EA25 RID: 59941 RVA: 0x00343CA6 File Offset: 0x00341EA6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ActivateHairColor.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EA26 RID: 59942 RVA: 0x00343CC2 File Offset: 0x00341EC2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ActivateHairColor.OnTimeout(this.oArg);
		}

		// Token: 0x04006532 RID: 25906
		public ActivateHairColorArg oArg = new ActivateHairColorArg();

		// Token: 0x04006533 RID: 25907
		public ActivateHairColorRes oRes = null;
	}
}
