using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200029E RID: 670
	[ProtoContract(Name = "GoldClickArg")]
	[Serializable]
	public class GoldClickArg : IExtensible
	{
		// Token: 0x17000B9A RID: 2970
		// (get) Token: 0x06002554 RID: 9556 RVA: 0x00048B04 File Offset: 0x00046D04
		// (set) Token: 0x06002555 RID: 9557 RVA: 0x00048B30 File Offset: 0x00046D30
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000B9B RID: 2971
		// (get) Token: 0x06002556 RID: 9558 RVA: 0x00048B40 File Offset: 0x00046D40
		// (set) Token: 0x06002557 RID: 9559 RVA: 0x00048B60 File Offset: 0x00046D60
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06002558 RID: 9560 RVA: 0x00048BA4 File Offset: 0x00046DA4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002559 RID: 9561 RVA: 0x00048BBC File Offset: 0x00046DBC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000B9C RID: 2972
		// (get) Token: 0x0600255A RID: 9562 RVA: 0x00048BC8 File Offset: 0x00046DC8
		// (set) Token: 0x0600255B RID: 9563 RVA: 0x00048BF4 File Offset: 0x00046DF4
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

		// Token: 0x17000B9D RID: 2973
		// (get) Token: 0x0600255C RID: 9564 RVA: 0x00048C04 File Offset: 0x00046E04
		// (set) Token: 0x0600255D RID: 9565 RVA: 0x00048C24 File Offset: 0x00046E24
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

		// Token: 0x0600255E RID: 9566 RVA: 0x00048C68 File Offset: 0x00046E68
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x0600255F RID: 9567 RVA: 0x00048C80 File Offset: 0x00046E80
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06002560 RID: 9568 RVA: 0x00048C8C File Offset: 0x00046E8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000940 RID: 2368
		private uint? _type;

		// Token: 0x04000941 RID: 2369
		private uint? _count;

		// Token: 0x04000942 RID: 2370
		private IExtension extensionObject;
	}
}
