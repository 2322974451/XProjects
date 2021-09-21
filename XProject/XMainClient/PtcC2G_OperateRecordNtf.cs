using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001070 RID: 4208
	internal class PtcC2G_OperateRecordNtf : Protocol
	{
		// Token: 0x0600D678 RID: 54904 RVA: 0x003262D8 File Offset: 0x003244D8
		public override uint GetProtoType()
		{
			return 56173U;
		}

		// Token: 0x0600D679 RID: 54905 RVA: 0x003262EF File Offset: 0x003244EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OperateRecord>(stream, this.Data);
		}

		// Token: 0x0600D67A RID: 54906 RVA: 0x003262FF File Offset: 0x003244FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OperateRecord>(stream);
		}

		// Token: 0x0600D67B RID: 54907 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006179 RID: 24953
		public OperateRecord Data = new OperateRecord();
	}
}
