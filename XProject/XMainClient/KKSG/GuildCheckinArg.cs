using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000AF RID: 175
	[ProtoContract(Name = "GuildCheckinArg")]
	[Serializable]
	public class GuildCheckinArg : IExtensible
	{
		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x00019A84 File Offset: 0x00017C84
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x00019AB0 File Offset: 0x00017CB0
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

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x00019AC0 File Offset: 0x00017CC0
		// (set) Token: 0x06000C21 RID: 3105 RVA: 0x00019AE0 File Offset: 0x00017CE0
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

		// Token: 0x06000C22 RID: 3106 RVA: 0x00019B24 File Offset: 0x00017D24
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x00019B3C File Offset: 0x00017D3C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00019B48 File Offset: 0x00017D48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000301 RID: 769
		private uint? _type;

		// Token: 0x04000302 RID: 770
		private IExtension extensionObject;
	}
}
