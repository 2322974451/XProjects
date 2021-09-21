using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B7 RID: 183
	[ProtoContract(Name = "GetGuildCheckinRecordsRes")]
	[Serializable]
	public class GetGuildCheckinRecordsRes : IExtensible
	{
		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x0001A1D8 File Offset: 0x000183D8
		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x0001A1F0 File Offset: 0x000183F0
		[ProtoMember(2, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000C60 RID: 3168 RVA: 0x0001A208 File Offset: 0x00018408
		[ProtoMember(3, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public List<uint> type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x0001A220 File Offset: 0x00018420
		[ProtoMember(4, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public List<uint> timestamp
		{
			get
			{
				return this._timestamp;
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000C62 RID: 3170 RVA: 0x0001A238 File Offset: 0x00018438
		// (set) Token: 0x06000C63 RID: 3171 RVA: 0x0001A264 File Offset: 0x00018464
		[ProtoMember(5, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000C64 RID: 3172 RVA: 0x0001A274 File Offset: 0x00018474
		// (set) Token: 0x06000C65 RID: 3173 RVA: 0x0001A294 File Offset: 0x00018494
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0001A2D8 File Offset: 0x000184D8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0001A2F0 File Offset: 0x000184F0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x0001A2FC File Offset: 0x000184FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000311 RID: 785
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x04000312 RID: 786
		private readonly List<string> _name = new List<string>();

		// Token: 0x04000313 RID: 787
		private readonly List<uint> _type = new List<uint>();

		// Token: 0x04000314 RID: 788
		private readonly List<uint> _timestamp = new List<uint>();

		// Token: 0x04000315 RID: 789
		private ErrorCode? _errorcode;

		// Token: 0x04000316 RID: 790
		private IExtension extensionObject;
	}
}
