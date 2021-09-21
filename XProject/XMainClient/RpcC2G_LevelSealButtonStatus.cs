using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001104 RID: 4356
	internal class RpcC2G_LevelSealButtonStatus : Rpc
	{
		// Token: 0x0600D8CE RID: 55502 RVA: 0x0032A108 File Offset: 0x00328308
		public override uint GetRpcType()
		{
			return 10396U;
		}

		// Token: 0x0600D8CF RID: 55503 RVA: 0x0032A11F File Offset: 0x0032831F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelSealOverExpArg>(stream, this.oArg);
		}

		// Token: 0x0600D8D0 RID: 55504 RVA: 0x0032A12F File Offset: 0x0032832F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LevelSealOverExpRes>(stream);
		}

		// Token: 0x0600D8D1 RID: 55505 RVA: 0x0032A13E File Offset: 0x0032833E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LevelSealButtonStatus.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D8D2 RID: 55506 RVA: 0x0032A15A File Offset: 0x0032835A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LevelSealButtonStatus.OnTimeout(this.oArg);
		}

		// Token: 0x040061E5 RID: 25061
		public LevelSealOverExpArg oArg = new LevelSealOverExpArg();

		// Token: 0x040061E6 RID: 25062
		public LevelSealOverExpRes oRes = new LevelSealOverExpRes();
	}
}
