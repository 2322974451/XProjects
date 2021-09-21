using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200031D RID: 797
	[ProtoContract(Name = "UpdatePartnerToClient")]
	[Serializable]
	public class UpdatePartnerToClient : IExtensible
	{
		// Token: 0x17000D8C RID: 3468
		// (get) Token: 0x06002BB8 RID: 11192 RVA: 0x00054B24 File Offset: 0x00052D24
		// (set) Token: 0x06002BB9 RID: 11193 RVA: 0x00054B50 File Offset: 0x00052D50
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PartnerUpdateType type
		{
			get
			{
				return this._type ?? PartnerUpdateType.PUType_Normal;
			}
			set
			{
				this._type = new PartnerUpdateType?(value);
			}
		}

		// Token: 0x17000D8D RID: 3469
		// (get) Token: 0x06002BBA RID: 11194 RVA: 0x00054B60 File Offset: 0x00052D60
		// (set) Token: 0x06002BBB RID: 11195 RVA: 0x00054B80 File Offset: 0x00052D80
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
					this._type = (value ? new PartnerUpdateType?(this.type) : null);
				}
			}
		}

		// Token: 0x06002BBC RID: 11196 RVA: 0x00054BC4 File Offset: 0x00052DC4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002BBD RID: 11197 RVA: 0x00054BDC File Offset: 0x00052DDC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000D8E RID: 3470
		// (get) Token: 0x06002BBE RID: 11198 RVA: 0x00054BE8 File Offset: 0x00052DE8
		// (set) Token: 0x06002BBF RID: 11199 RVA: 0x00054C15 File Offset: 0x00052E15
		[ProtoMember(2, IsRequired = false, Name = "partid", DataFormat = DataFormat.TwosComplement)]
		public ulong partid
		{
			get
			{
				return this._partid ?? 0UL;
			}
			set
			{
				this._partid = new ulong?(value);
			}
		}

		// Token: 0x17000D8F RID: 3471
		// (get) Token: 0x06002BC0 RID: 11200 RVA: 0x00054C24 File Offset: 0x00052E24
		// (set) Token: 0x06002BC1 RID: 11201 RVA: 0x00054C44 File Offset: 0x00052E44
		[XmlIgnore]
		[Browsable(false)]
		public bool partidSpecified
		{
			get
			{
				return this._partid != null;
			}
			set
			{
				bool flag = value == (this._partid == null);
				if (flag)
				{
					this._partid = (value ? new ulong?(this.partid) : null);
				}
			}
		}

		// Token: 0x06002BC2 RID: 11202 RVA: 0x00054C88 File Offset: 0x00052E88
		private bool ShouldSerializepartid()
		{
			return this.partidSpecified;
		}

		// Token: 0x06002BC3 RID: 11203 RVA: 0x00054CA0 File Offset: 0x00052EA0
		private void Resetpartid()
		{
			this.partidSpecified = false;
		}

		// Token: 0x17000D90 RID: 3472
		// (get) Token: 0x06002BC4 RID: 11204 RVA: 0x00054CAC File Offset: 0x00052EAC
		// (set) Token: 0x06002BC5 RID: 11205 RVA: 0x00054CD8 File Offset: 0x00052ED8
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17000D91 RID: 3473
		// (get) Token: 0x06002BC6 RID: 11206 RVA: 0x00054CE8 File Offset: 0x00052EE8
		// (set) Token: 0x06002BC7 RID: 11207 RVA: 0x00054D08 File Offset: 0x00052F08
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06002BC8 RID: 11208 RVA: 0x00054D4C File Offset: 0x00052F4C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06002BC9 RID: 11209 RVA: 0x00054D64 File Offset: 0x00052F64
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000D92 RID: 3474
		// (get) Token: 0x06002BCA RID: 11210 RVA: 0x00054D70 File Offset: 0x00052F70
		// (set) Token: 0x06002BCB RID: 11211 RVA: 0x00054D9C File Offset: 0x00052F9C
		[ProtoMember(4, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
		public uint degree
		{
			get
			{
				return this._degree ?? 0U;
			}
			set
			{
				this._degree = new uint?(value);
			}
		}

		// Token: 0x17000D93 RID: 3475
		// (get) Token: 0x06002BCC RID: 11212 RVA: 0x00054DAC File Offset: 0x00052FAC
		// (set) Token: 0x06002BCD RID: 11213 RVA: 0x00054DCC File Offset: 0x00052FCC
		[XmlIgnore]
		[Browsable(false)]
		public bool degreeSpecified
		{
			get
			{
				return this._degree != null;
			}
			set
			{
				bool flag = value == (this._degree == null);
				if (flag)
				{
					this._degree = (value ? new uint?(this.degree) : null);
				}
			}
		}

		// Token: 0x06002BCE RID: 11214 RVA: 0x00054E10 File Offset: 0x00053010
		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		// Token: 0x06002BCF RID: 11215 RVA: 0x00054E28 File Offset: 0x00053028
		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		// Token: 0x17000D94 RID: 3476
		// (get) Token: 0x06002BD0 RID: 11216 RVA: 0x00054E34 File Offset: 0x00053034
		// (set) Token: 0x06002BD1 RID: 11217 RVA: 0x00054E61 File Offset: 0x00053061
		[ProtoMember(5, IsRequired = false, Name = "leave_id", DataFormat = DataFormat.TwosComplement)]
		public ulong leave_id
		{
			get
			{
				return this._leave_id ?? 0UL;
			}
			set
			{
				this._leave_id = new ulong?(value);
			}
		}

		// Token: 0x17000D95 RID: 3477
		// (get) Token: 0x06002BD2 RID: 11218 RVA: 0x00054E70 File Offset: 0x00053070
		// (set) Token: 0x06002BD3 RID: 11219 RVA: 0x00054E90 File Offset: 0x00053090
		[XmlIgnore]
		[Browsable(false)]
		public bool leave_idSpecified
		{
			get
			{
				return this._leave_id != null;
			}
			set
			{
				bool flag = value == (this._leave_id == null);
				if (flag)
				{
					this._leave_id = (value ? new ulong?(this.leave_id) : null);
				}
			}
		}

		// Token: 0x06002BD4 RID: 11220 RVA: 0x00054ED4 File Offset: 0x000530D4
		private bool ShouldSerializeleave_id()
		{
			return this.leave_idSpecified;
		}

		// Token: 0x06002BD5 RID: 11221 RVA: 0x00054EEC File Offset: 0x000530EC
		private void Resetleave_id()
		{
			this.leave_idSpecified = false;
		}

		// Token: 0x17000D96 RID: 3478
		// (get) Token: 0x06002BD6 RID: 11222 RVA: 0x00054EF8 File Offset: 0x000530F8
		// (set) Token: 0x06002BD7 RID: 11223 RVA: 0x00054F19 File Offset: 0x00053119
		[ProtoMember(6, IsRequired = false, Name = "leave_name", DataFormat = DataFormat.Default)]
		public string leave_name
		{
			get
			{
				return this._leave_name ?? "";
			}
			set
			{
				this._leave_name = value;
			}
		}

		// Token: 0x17000D97 RID: 3479
		// (get) Token: 0x06002BD8 RID: 11224 RVA: 0x00054F24 File Offset: 0x00053124
		// (set) Token: 0x06002BD9 RID: 11225 RVA: 0x00054F40 File Offset: 0x00053140
		[XmlIgnore]
		[Browsable(false)]
		public bool leave_nameSpecified
		{
			get
			{
				return this._leave_name != null;
			}
			set
			{
				bool flag = value == (this._leave_name == null);
				if (flag)
				{
					this._leave_name = (value ? this.leave_name : null);
				}
			}
		}

		// Token: 0x06002BDA RID: 11226 RVA: 0x00054F70 File Offset: 0x00053170
		private bool ShouldSerializeleave_name()
		{
			return this.leave_nameSpecified;
		}

		// Token: 0x06002BDB RID: 11227 RVA: 0x00054F88 File Offset: 0x00053188
		private void Resetleave_name()
		{
			this.leave_nameSpecified = false;
		}

		// Token: 0x06002BDC RID: 11228 RVA: 0x00054F94 File Offset: 0x00053194
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AD6 RID: 2774
		private PartnerUpdateType? _type;

		// Token: 0x04000AD7 RID: 2775
		private ulong? _partid;

		// Token: 0x04000AD8 RID: 2776
		private uint? _level;

		// Token: 0x04000AD9 RID: 2777
		private uint? _degree;

		// Token: 0x04000ADA RID: 2778
		private ulong? _leave_id;

		// Token: 0x04000ADB RID: 2779
		private string _leave_name;

		// Token: 0x04000ADC RID: 2780
		private IExtension extensionObject;
	}
}
