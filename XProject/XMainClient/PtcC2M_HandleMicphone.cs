using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013BF RID: 5055
	internal class PtcC2M_HandleMicphone : Protocol
	{
		// Token: 0x0600E3F8 RID: 58360 RVA: 0x0033B13C File Offset: 0x0033933C
		public override uint GetProtoType()
		{
			return 50175U;
		}

		// Token: 0x0600E3F9 RID: 58361 RVA: 0x0033B153 File Offset: 0x00339353
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HandleMicphoneArg>(stream, this.Data);
		}

		// Token: 0x0600E3FA RID: 58362 RVA: 0x0033B163 File Offset: 0x00339363
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HandleMicphoneArg>(stream);
		}

		// Token: 0x0600E3FB RID: 58363 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006408 RID: 25608
		public HandleMicphoneArg Data = new HandleMicphoneArg();
	}
}
