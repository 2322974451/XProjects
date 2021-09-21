using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001BA RID: 442
	[ProtoContract(Name = "WorldBossAttrNtf")]
	[Serializable]
	public class WorldBossAttrNtf : IExtensible
	{
		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x060019CE RID: 6606 RVA: 0x000332D0 File Offset: 0x000314D0
		// (set) Token: 0x060019CF RID: 6607 RVA: 0x000332FC File Offset: 0x000314FC
		[ProtoMember(1, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x060019D0 RID: 6608 RVA: 0x0003330C File Offset: 0x0003150C
		// (set) Token: 0x060019D1 RID: 6609 RVA: 0x0003332C File Offset: 0x0003152C
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

		// Token: 0x060019D2 RID: 6610 RVA: 0x00033370 File Offset: 0x00031570
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060019D3 RID: 6611 RVA: 0x00033388 File Offset: 0x00031588
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x060019D4 RID: 6612 RVA: 0x00033394 File Offset: 0x00031594
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400066C RID: 1644
		private uint? _count;

		// Token: 0x0400066D RID: 1645
		private IExtension extensionObject;
	}
}
