using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000279 RID: 633
	[ProtoContract(Name = "GetLevelSealSealGiftArg")]
	[Serializable]
	public class GetLevelSealSealGiftArg : IExtensible
	{
		// Token: 0x17000AFC RID: 2812
		// (get) Token: 0x0600234D RID: 9037 RVA: 0x00044F04 File Offset: 0x00043104
		// (set) Token: 0x0600234E RID: 9038 RVA: 0x00044F30 File Offset: 0x00043130
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

		// Token: 0x17000AFD RID: 2813
		// (get) Token: 0x0600234F RID: 9039 RVA: 0x00044F40 File Offset: 0x00043140
		// (set) Token: 0x06002350 RID: 9040 RVA: 0x00044F60 File Offset: 0x00043160
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

		// Token: 0x06002351 RID: 9041 RVA: 0x00044FA4 File Offset: 0x000431A4
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06002352 RID: 9042 RVA: 0x00044FBC File Offset: 0x000431BC
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06002353 RID: 9043 RVA: 0x00044FC8 File Offset: 0x000431C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008C2 RID: 2242
		private uint? _count;

		// Token: 0x040008C3 RID: 2243
		private IExtension extensionObject;
	}
}
