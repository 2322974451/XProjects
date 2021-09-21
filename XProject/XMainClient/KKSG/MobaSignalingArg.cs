using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200042A RID: 1066
	[ProtoContract(Name = "MobaSignalingArg")]
	[Serializable]
	public class MobaSignalingArg : IExtensible
	{
		// Token: 0x1700115A RID: 4442
		// (get) Token: 0x0600387B RID: 14459 RVA: 0x0006C1B8 File Offset: 0x0006A3B8
		// (set) Token: 0x0600387C RID: 14460 RVA: 0x0006C1E4 File Offset: 0x0006A3E4
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

		// Token: 0x1700115B RID: 4443
		// (get) Token: 0x0600387D RID: 14461 RVA: 0x0006C1F4 File Offset: 0x0006A3F4
		// (set) Token: 0x0600387E RID: 14462 RVA: 0x0006C214 File Offset: 0x0006A414
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

		// Token: 0x0600387F RID: 14463 RVA: 0x0006C258 File Offset: 0x0006A458
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003880 RID: 14464 RVA: 0x0006C270 File Offset: 0x0006A470
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003881 RID: 14465 RVA: 0x0006C27C File Offset: 0x0006A47C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E03 RID: 3587
		private uint? _type;

		// Token: 0x04000E04 RID: 3588
		private IExtension extensionObject;
	}
}
