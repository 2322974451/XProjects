using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F3 RID: 243
	[ProtoContract(Name = "LevelUpSlotAttrArg")]
	[Serializable]
	public class LevelUpSlotAttrArg : IExtensible
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06000F99 RID: 3993 RVA: 0x000201E4 File Offset: 0x0001E3E4
		// (set) Token: 0x06000F9A RID: 3994 RVA: 0x00020210 File Offset: 0x0001E410
		[ProtoMember(1, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public uint slot
		{
			get
			{
				return this._slot ?? 0U;
			}
			set
			{
				this._slot = new uint?(value);
			}
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06000F9B RID: 3995 RVA: 0x00020220 File Offset: 0x0001E420
		// (set) Token: 0x06000F9C RID: 3996 RVA: 0x00020240 File Offset: 0x0001E440
		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new uint?(this.slot) : null);
				}
			}
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x00020284 File Offset: 0x0001E484
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0002029C File Offset: 0x0001E49C
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06000F9F RID: 3999 RVA: 0x000202A8 File Offset: 0x0001E4A8
		// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x000202D4 File Offset: 0x0001E4D4
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x000202E4 File Offset: 0x0001E4E4
		// (set) Token: 0x06000FA2 RID: 4002 RVA: 0x00020304 File Offset: 0x0001E504
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x00020348 File Offset: 0x0001E548
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x00020360 File Offset: 0x0001E560
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x0002036C File Offset: 0x0001E56C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003E5 RID: 997
		private uint? _slot;

		// Token: 0x040003E6 RID: 998
		private uint? _count;

		// Token: 0x040003E7 RID: 999
		private IExtension extensionObject;
	}
}
