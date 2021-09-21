using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200124B RID: 4683
	internal class RpcC2G_SpriteOperation : Rpc
	{
		// Token: 0x0600DDFF RID: 56831 RVA: 0x00332AEC File Offset: 0x00330CEC
		public override uint GetRpcType()
		{
			return 62961U;
		}

		// Token: 0x0600DE00 RID: 56832 RVA: 0x00332B03 File Offset: 0x00330D03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpriteOperationArg>(stream, this.oArg);
		}

		// Token: 0x0600DE01 RID: 56833 RVA: 0x00332B13 File Offset: 0x00330D13
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SpriteOperationRes>(stream);
		}

		// Token: 0x0600DE02 RID: 56834 RVA: 0x00332B22 File Offset: 0x00330D22
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SpriteOperation.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE03 RID: 56835 RVA: 0x00332B3E File Offset: 0x00330D3E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SpriteOperation.OnTimeout(this.oArg);
		}

		// Token: 0x040062E0 RID: 25312
		public SpriteOperationArg oArg = new SpriteOperationArg();

		// Token: 0x040062E1 RID: 25313
		public SpriteOperationRes oRes = new SpriteOperationRes();
	}
}
