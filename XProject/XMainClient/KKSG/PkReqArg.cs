using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E7 RID: 487
	[ProtoContract(Name = "PkReqArg")]
	[Serializable]
	public class PkReqArg : IExtensible
	{
		// Token: 0x170008C6 RID: 2246
		// (get) Token: 0x06001BF8 RID: 7160 RVA: 0x00037324 File Offset: 0x00035524
		// (set) Token: 0x06001BF9 RID: 7161 RVA: 0x00037350 File Offset: 0x00035550
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PkReqType type
		{
			get
			{
				return this._type ?? PkReqType.PKREQ_ADDPK;
			}
			set
			{
				this._type = new PkReqType?(value);
			}
		}

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x06001BFA RID: 7162 RVA: 0x00037360 File Offset: 0x00035560
		// (set) Token: 0x06001BFB RID: 7163 RVA: 0x00037380 File Offset: 0x00035580
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
					this._type = (value ? new PkReqType?(this.type) : null);
				}
			}
		}

		// Token: 0x06001BFC RID: 7164 RVA: 0x000373C4 File Offset: 0x000355C4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x000373DC File Offset: 0x000355DC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x06001BFE RID: 7166 RVA: 0x000373E8 File Offset: 0x000355E8
		// (set) Token: 0x06001BFF RID: 7167 RVA: 0x00037414 File Offset: 0x00035614
		[ProtoMember(2, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x06001C00 RID: 7168 RVA: 0x00037424 File Offset: 0x00035624
		// (set) Token: 0x06001C01 RID: 7169 RVA: 0x00037444 File Offset: 0x00035644
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
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x06001C02 RID: 7170 RVA: 0x00037488 File Offset: 0x00035688
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06001C03 RID: 7171 RVA: 0x000374A0 File Offset: 0x000356A0
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x06001C04 RID: 7172 RVA: 0x000374AC File Offset: 0x000356AC
		// (set) Token: 0x06001C05 RID: 7173 RVA: 0x000374D8 File Offset: 0x000356D8
		[ProtoMember(3, IsRequired = false, Name = "nvntype", DataFormat = DataFormat.TwosComplement)]
		public PkNVNType nvntype
		{
			get
			{
				return this._nvntype ?? PkNVNType.PK_1v1;
			}
			set
			{
				this._nvntype = new PkNVNType?(value);
			}
		}

		// Token: 0x170008CB RID: 2251
		// (get) Token: 0x06001C06 RID: 7174 RVA: 0x000374E8 File Offset: 0x000356E8
		// (set) Token: 0x06001C07 RID: 7175 RVA: 0x00037508 File Offset: 0x00035708
		[XmlIgnore]
		[Browsable(false)]
		public bool nvntypeSpecified
		{
			get
			{
				return this._nvntype != null;
			}
			set
			{
				bool flag = value == (this._nvntype == null);
				if (flag)
				{
					this._nvntype = (value ? new PkNVNType?(this.nvntype) : null);
				}
			}
		}

		// Token: 0x06001C08 RID: 7176 RVA: 0x0003754C File Offset: 0x0003574C
		private bool ShouldSerializenvntype()
		{
			return this.nvntypeSpecified;
		}

		// Token: 0x06001C09 RID: 7177 RVA: 0x00037564 File Offset: 0x00035764
		private void Resetnvntype()
		{
			this.nvntypeSpecified = false;
		}

		// Token: 0x06001C0A RID: 7178 RVA: 0x00037570 File Offset: 0x00035770
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006F6 RID: 1782
		private PkReqType? _type;

		// Token: 0x040006F7 RID: 1783
		private uint? _index;

		// Token: 0x040006F8 RID: 1784
		private PkNVNType? _nvntype;

		// Token: 0x040006F9 RID: 1785
		private IExtension extensionObject;
	}
}
