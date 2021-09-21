using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000337 RID: 823
	[ProtoContract(Name = "BuyPartnerShopItemArg")]
	[Serializable]
	public class BuyPartnerShopItemArg : IExtensible
	{
		// Token: 0x17000E0B RID: 3595
		// (get) Token: 0x06002D41 RID: 11585 RVA: 0x00057948 File Offset: 0x00055B48
		// (set) Token: 0x06002D42 RID: 11586 RVA: 0x00057974 File Offset: 0x00055B74
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17000E0C RID: 3596
		// (get) Token: 0x06002D43 RID: 11587 RVA: 0x00057984 File Offset: 0x00055B84
		// (set) Token: 0x06002D44 RID: 11588 RVA: 0x000579A4 File Offset: 0x00055BA4
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06002D45 RID: 11589 RVA: 0x000579E8 File Offset: 0x00055BE8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06002D46 RID: 11590 RVA: 0x00057A00 File Offset: 0x00055C00
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17000E0D RID: 3597
		// (get) Token: 0x06002D47 RID: 11591 RVA: 0x00057A0C File Offset: 0x00055C0C
		// (set) Token: 0x06002D48 RID: 11592 RVA: 0x00057A38 File Offset: 0x00055C38
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

		// Token: 0x17000E0E RID: 3598
		// (get) Token: 0x06002D49 RID: 11593 RVA: 0x00057A48 File Offset: 0x00055C48
		// (set) Token: 0x06002D4A RID: 11594 RVA: 0x00057A68 File Offset: 0x00055C68
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

		// Token: 0x06002D4B RID: 11595 RVA: 0x00057AAC File Offset: 0x00055CAC
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06002D4C RID: 11596 RVA: 0x00057AC4 File Offset: 0x00055CC4
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06002D4D RID: 11597 RVA: 0x00057AD0 File Offset: 0x00055CD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B3B RID: 2875
		private uint? _id;

		// Token: 0x04000B3C RID: 2876
		private uint? _count;

		// Token: 0x04000B3D RID: 2877
		private IExtension extensionObject;
	}
}
