using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000037 RID: 55
	[ProtoContract(Name = "DecomposeEquipmentArg")]
	[Serializable]
	public class DecomposeEquipmentArg : IExtensible
	{
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x0000A004 File Offset: 0x00008204
		[ProtoMember(1, Name = "equipuniqueid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> equipuniqueid
		{
			get
			{
				return this._equipuniqueid;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x0000A01C File Offset: 0x0000821C
		[ProtoMember(2, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public List<uint> count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000A034 File Offset: 0x00008234
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000100 RID: 256
		private readonly List<ulong> _equipuniqueid = new List<ulong>();

		// Token: 0x04000101 RID: 257
		private readonly List<uint> _count = new List<uint>();

		// Token: 0x04000102 RID: 258
		private IExtension extensionObject;
	}
}
