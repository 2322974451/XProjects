using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200126A RID: 4714
	internal class PtcC2G_RemoveIBShopIcon : Protocol
	{
		// Token: 0x0600DE83 RID: 56963 RVA: 0x0033360C File Offset: 0x0033180C
		public override uint GetProtoType()
		{
			return 33988U;
		}

		// Token: 0x0600DE84 RID: 56964 RVA: 0x00333623 File Offset: 0x00331823
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RemoveIBShopIcon>(stream, this.Data);
		}

		// Token: 0x0600DE85 RID: 56965 RVA: 0x00333633 File Offset: 0x00331833
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RemoveIBShopIcon>(stream);
		}

		// Token: 0x0600DE86 RID: 56966 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040062FB RID: 25339
		public RemoveIBShopIcon Data = new RemoveIBShopIcon();
	}
}
