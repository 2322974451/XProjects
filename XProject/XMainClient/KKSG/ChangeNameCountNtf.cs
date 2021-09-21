using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F6 RID: 758
	[ProtoContract(Name = "ChangeNameCountNtf")]
	[Serializable]
	public class ChangeNameCountNtf : IExtensible
	{
		// Token: 0x17000CED RID: 3309
		// (get) Token: 0x060029A9 RID: 10665 RVA: 0x00050D80 File Offset: 0x0004EF80
		// (set) Token: 0x060029AA RID: 10666 RVA: 0x00050DAC File Offset: 0x0004EFAC
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

		// Token: 0x17000CEE RID: 3310
		// (get) Token: 0x060029AB RID: 10667 RVA: 0x00050DBC File Offset: 0x0004EFBC
		// (set) Token: 0x060029AC RID: 10668 RVA: 0x00050DDC File Offset: 0x0004EFDC
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

		// Token: 0x060029AD RID: 10669 RVA: 0x00050E20 File Offset: 0x0004F020
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x060029AE RID: 10670 RVA: 0x00050E38 File Offset: 0x0004F038
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x060029AF RID: 10671 RVA: 0x00050E44 File Offset: 0x0004F044
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A58 RID: 2648
		private uint? _count;

		// Token: 0x04000A59 RID: 2649
		private IExtension extensionObject;
	}
}
