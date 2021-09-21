using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200001C RID: 28
	[ProtoContract(Name = "Systems")]
	[Serializable]
	public class Systems : IExtensible
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00007110 File Offset: 0x00005310
		[ProtoMember(1, Name = "sysIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> sysIDs
		{
			get
			{
				return this._sysIDs;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00007128 File Offset: 0x00005328
		[ProtoMember(2, Name = "closeSysIDs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> closeSysIDs
		{
			get
			{
				return this._closeSysIDs;
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00007140 File Offset: 0x00005340
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400009A RID: 154
		private readonly List<uint> _sysIDs = new List<uint>();

		// Token: 0x0400009B RID: 155
		private readonly List<uint> _closeSysIDs = new List<uint>();

		// Token: 0x0400009C RID: 156
		private IExtension extensionObject;
	}
}
