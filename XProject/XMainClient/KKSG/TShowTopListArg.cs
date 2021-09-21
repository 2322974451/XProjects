using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F7 RID: 247
	[ProtoContract(Name = "TShowTopListArg")]
	[Serializable]
	public class TShowTopListArg : IExtensible
	{
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06000FC9 RID: 4041 RVA: 0x00020780 File Offset: 0x0001E980
		// (set) Token: 0x06000FCA RID: 4042 RVA: 0x000207AC File Offset: 0x0001E9AC
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06000FCB RID: 4043 RVA: 0x000207BC File Offset: 0x0001E9BC
		// (set) Token: 0x06000FCC RID: 4044 RVA: 0x000207DC File Offset: 0x0001E9DC
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
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x06000FCD RID: 4045 RVA: 0x00020820 File Offset: 0x0001EA20
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06000FCE RID: 4046 RVA: 0x00020838 File Offset: 0x0001EA38
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06000FCF RID: 4047 RVA: 0x00020844 File Offset: 0x0001EA44
		// (set) Token: 0x06000FD0 RID: 4048 RVA: 0x00020870 File Offset: 0x0001EA70
		[ProtoMember(2, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06000FD1 RID: 4049 RVA: 0x00020880 File Offset: 0x0001EA80
		// (set) Token: 0x06000FD2 RID: 4050 RVA: 0x000208A0 File Offset: 0x0001EAA0
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x000208E4 File Offset: 0x0001EAE4
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x000208FC File Offset: 0x0001EAFC
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00020908 File Offset: 0x0001EB08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003F2 RID: 1010
		private int? _type;

		// Token: 0x040003F3 RID: 1011
		private int? _index;

		// Token: 0x040003F4 RID: 1012
		private IExtension extensionObject;
	}
}
