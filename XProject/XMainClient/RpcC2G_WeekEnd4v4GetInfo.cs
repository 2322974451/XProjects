using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200152B RID: 5419
	internal class RpcC2G_WeekEnd4v4GetInfo : Rpc
	{
		// Token: 0x0600E9C6 RID: 59846 RVA: 0x00343340 File Offset: 0x00341540
		public override uint GetRpcType()
		{
			return 59573U;
		}

		// Token: 0x0600E9C7 RID: 59847 RVA: 0x00343357 File Offset: 0x00341557
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeekEnd4v4GetInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E9C8 RID: 59848 RVA: 0x00343367 File Offset: 0x00341567
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WeekEnd4v4GetInfoRes>(stream);
		}

		// Token: 0x0600E9C9 RID: 59849 RVA: 0x00343376 File Offset: 0x00341576
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_WeekEnd4v4GetInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E9CA RID: 59850 RVA: 0x00343392 File Offset: 0x00341592
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_WeekEnd4v4GetInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006522 RID: 25890
		public WeekEnd4v4GetInfoArg oArg = new WeekEnd4v4GetInfoArg();

		// Token: 0x04006523 RID: 25891
		public WeekEnd4v4GetInfoRes oRes = null;
	}
}
