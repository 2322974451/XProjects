using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000FA RID: 250
	[ProtoContract(Name = "PetOperationRes")]
	[Serializable]
	public class PetOperationRes : IExtensible
	{
		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06000FFA RID: 4090 RVA: 0x00020D7C File Offset: 0x0001EF7C
		// (set) Token: 0x06000FFB RID: 4091 RVA: 0x00020DA8 File Offset: 0x0001EFA8
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06000FFC RID: 4092 RVA: 0x00020DB8 File Offset: 0x0001EFB8
		// (set) Token: 0x06000FFD RID: 4093 RVA: 0x00020DD8 File Offset: 0x0001EFD8
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

		// Token: 0x06000FFE RID: 4094 RVA: 0x00020E1C File Offset: 0x0001F01C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x00020E34 File Offset: 0x0001F034
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06001000 RID: 4096 RVA: 0x00020E40 File Offset: 0x0001F040
		// (set) Token: 0x06001001 RID: 4097 RVA: 0x00020E6D File Offset: 0x0001F06D
		[ProtoMember(2, IsRequired = false, Name = "followpetid", DataFormat = DataFormat.TwosComplement)]
		public ulong followpetid
		{
			get
			{
				return this._followpetid ?? 0UL;
			}
			set
			{
				this._followpetid = new ulong?(value);
			}
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06001002 RID: 4098 RVA: 0x00020E7C File Offset: 0x0001F07C
		// (set) Token: 0x06001003 RID: 4099 RVA: 0x00020E9C File Offset: 0x0001F09C
		[XmlIgnore]
		[Browsable(false)]
		public bool followpetidSpecified
		{
			get
			{
				return this._followpetid != null;
			}
			set
			{
				bool flag = value == (this._followpetid == null);
				if (flag)
				{
					this._followpetid = (value ? new ulong?(this.followpetid) : null);
				}
			}
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x00020EE0 File Offset: 0x0001F0E0
		private bool ShouldSerializefollowpetid()
		{
			return this.followpetidSpecified;
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x00020EF8 File Offset: 0x0001F0F8
		private void Resetfollowpetid()
		{
			this.followpetidSpecified = false;
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06001006 RID: 4102 RVA: 0x00020F04 File Offset: 0x0001F104
		// (set) Token: 0x06001007 RID: 4103 RVA: 0x00020F30 File Offset: 0x0001F130
		[ProtoMember(3, IsRequired = false, Name = "ismoodup", DataFormat = DataFormat.Default)]
		public bool ismoodup
		{
			get
			{
				return this._ismoodup ?? false;
			}
			set
			{
				this._ismoodup = new bool?(value);
			}
		}

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06001008 RID: 4104 RVA: 0x00020F40 File Offset: 0x0001F140
		// (set) Token: 0x06001009 RID: 4105 RVA: 0x00020F60 File Offset: 0x0001F160
		[XmlIgnore]
		[Browsable(false)]
		public bool ismoodupSpecified
		{
			get
			{
				return this._ismoodup != null;
			}
			set
			{
				bool flag = value == (this._ismoodup == null);
				if (flag)
				{
					this._ismoodup = (value ? new bool?(this.ismoodup) : null);
				}
			}
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x00020FA4 File Offset: 0x0001F1A4
		private bool ShouldSerializeismoodup()
		{
			return this.ismoodupSpecified;
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00020FBC File Offset: 0x0001F1BC
		private void Resetismoodup()
		{
			this.ismoodupSpecified = false;
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x0600100C RID: 4108 RVA: 0x00020FC8 File Offset: 0x0001F1C8
		// (set) Token: 0x0600100D RID: 4109 RVA: 0x00020FF4 File Offset: 0x0001F1F4
		[ProtoMember(4, IsRequired = false, Name = "ishuneryup", DataFormat = DataFormat.Default)]
		public bool ishuneryup
		{
			get
			{
				return this._ishuneryup ?? false;
			}
			set
			{
				this._ishuneryup = new bool?(value);
			}
		}

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x0600100E RID: 4110 RVA: 0x00021004 File Offset: 0x0001F204
		// (set) Token: 0x0600100F RID: 4111 RVA: 0x00021024 File Offset: 0x0001F224
		[XmlIgnore]
		[Browsable(false)]
		public bool ishuneryupSpecified
		{
			get
			{
				return this._ishuneryup != null;
			}
			set
			{
				bool flag = value == (this._ishuneryup == null);
				if (flag)
				{
					this._ishuneryup = (value ? new bool?(this.ishuneryup) : null);
				}
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x00021068 File Offset: 0x0001F268
		private bool ShouldSerializeishuneryup()
		{
			return this.ishuneryupSpecified;
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x00021080 File Offset: 0x0001F280
		private void Resetishuneryup()
		{
			this.ishuneryupSpecified = false;
		}

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06001012 RID: 4114 RVA: 0x0002108C File Offset: 0x0001F28C
		[ProtoMember(5, Name = "invite", DataFormat = DataFormat.Default)]
		public List<PetInviteInfo> invite
		{
			get
			{
				return this._invite;
			}
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x000210A4 File Offset: 0x0001F2A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003FD RID: 1021
		private ErrorCode? _errorcode;

		// Token: 0x040003FE RID: 1022
		private ulong? _followpetid;

		// Token: 0x040003FF RID: 1023
		private bool? _ismoodup;

		// Token: 0x04000400 RID: 1024
		private bool? _ishuneryup;

		// Token: 0x04000401 RID: 1025
		private readonly List<PetInviteInfo> _invite = new List<PetInviteInfo>();

		// Token: 0x04000402 RID: 1026
		private IExtension extensionObject;
	}
}
