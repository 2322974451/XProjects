using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000088 RID: 136
	[ProtoContract(Name = "RoleStateReport")]
	[Serializable]
	public class RoleStateReport : IExtensible
	{
		// Token: 0x170002EE RID: 750
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x000139F8 File Offset: 0x00011BF8
		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x060008ED RID: 2285 RVA: 0x00013A10 File Offset: 0x00011C10
		[ProtoMember(2, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public List<uint> state
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x00013A28 File Offset: 0x00011C28
		[ProtoMember(3, Name = "timelastlogin", DataFormat = DataFormat.TwosComplement)]
		public List<uint> timelastlogin
		{
			get
			{
				return this._timelastlogin;
			}
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00013A40 File Offset: 0x00011C40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400024D RID: 589
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x0400024E RID: 590
		private readonly List<uint> _state = new List<uint>();

		// Token: 0x0400024F RID: 591
		private readonly List<uint> _timelastlogin = new List<uint>();

		// Token: 0x04000250 RID: 592
		private IExtension extensionObject;
	}
}
