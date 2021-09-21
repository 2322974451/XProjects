using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000322 RID: 802
	[ProtoContract(Name = "MakePartnerResult")]
	[Serializable]
	public class MakePartnerResult : IExtensible
	{
		// Token: 0x17000DAE RID: 3502
		// (get) Token: 0x06002C20 RID: 11296 RVA: 0x000557C0 File Offset: 0x000539C0
		// (set) Token: 0x06002C21 RID: 11297 RVA: 0x000557EC File Offset: 0x000539EC
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000DAF RID: 3503
		// (get) Token: 0x06002C22 RID: 11298 RVA: 0x000557FC File Offset: 0x000539FC
		// (set) Token: 0x06002C23 RID: 11299 RVA: 0x0005581C File Offset: 0x00053A1C
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06002C24 RID: 11300 RVA: 0x00055860 File Offset: 0x00053A60
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002C25 RID: 11301 RVA: 0x00055878 File Offset: 0x00053A78
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000DB0 RID: 3504
		// (get) Token: 0x06002C26 RID: 11302 RVA: 0x00055884 File Offset: 0x00053A84
		// (set) Token: 0x06002C27 RID: 11303 RVA: 0x000558B1 File Offset: 0x00053AB1
		[ProtoMember(2, IsRequired = false, Name = "err_roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong err_roleid
		{
			get
			{
				return this._err_roleid ?? 0UL;
			}
			set
			{
				this._err_roleid = new ulong?(value);
			}
		}

		// Token: 0x17000DB1 RID: 3505
		// (get) Token: 0x06002C28 RID: 11304 RVA: 0x000558C0 File Offset: 0x00053AC0
		// (set) Token: 0x06002C29 RID: 11305 RVA: 0x000558E0 File Offset: 0x00053AE0
		[XmlIgnore]
		[Browsable(false)]
		public bool err_roleidSpecified
		{
			get
			{
				return this._err_roleid != null;
			}
			set
			{
				bool flag = value == (this._err_roleid == null);
				if (flag)
				{
					this._err_roleid = (value ? new ulong?(this.err_roleid) : null);
				}
			}
		}

		// Token: 0x06002C2A RID: 11306 RVA: 0x00055924 File Offset: 0x00053B24
		private bool ShouldSerializeerr_roleid()
		{
			return this.err_roleidSpecified;
		}

		// Token: 0x06002C2B RID: 11307 RVA: 0x0005593C File Offset: 0x00053B3C
		private void Reseterr_roleid()
		{
			this.err_roleidSpecified = false;
		}

		// Token: 0x17000DB2 RID: 3506
		// (get) Token: 0x06002C2C RID: 11308 RVA: 0x00055948 File Offset: 0x00053B48
		// (set) Token: 0x06002C2D RID: 11309 RVA: 0x00055969 File Offset: 0x00053B69
		[ProtoMember(3, IsRequired = false, Name = "err_rolename", DataFormat = DataFormat.Default)]
		public string err_rolename
		{
			get
			{
				return this._err_rolename ?? "";
			}
			set
			{
				this._err_rolename = value;
			}
		}

		// Token: 0x17000DB3 RID: 3507
		// (get) Token: 0x06002C2E RID: 11310 RVA: 0x00055974 File Offset: 0x00053B74
		// (set) Token: 0x06002C2F RID: 11311 RVA: 0x00055990 File Offset: 0x00053B90
		[XmlIgnore]
		[Browsable(false)]
		public bool err_rolenameSpecified
		{
			get
			{
				return this._err_rolename != null;
			}
			set
			{
				bool flag = value == (this._err_rolename == null);
				if (flag)
				{
					this._err_rolename = (value ? this.err_rolename : null);
				}
			}
		}

		// Token: 0x06002C30 RID: 11312 RVA: 0x000559C0 File Offset: 0x00053BC0
		private bool ShouldSerializeerr_rolename()
		{
			return this.err_rolenameSpecified;
		}

		// Token: 0x06002C31 RID: 11313 RVA: 0x000559D8 File Offset: 0x00053BD8
		private void Reseterr_rolename()
		{
			this.err_rolenameSpecified = false;
		}

		// Token: 0x17000DB4 RID: 3508
		// (get) Token: 0x06002C32 RID: 11314 RVA: 0x000559E4 File Offset: 0x00053BE4
		// (set) Token: 0x06002C33 RID: 11315 RVA: 0x00055A11 File Offset: 0x00053C11
		[ProtoMember(4, IsRequired = false, Name = "partnerid", DataFormat = DataFormat.TwosComplement)]
		public ulong partnerid
		{
			get
			{
				return this._partnerid ?? 0UL;
			}
			set
			{
				this._partnerid = new ulong?(value);
			}
		}

		// Token: 0x17000DB5 RID: 3509
		// (get) Token: 0x06002C34 RID: 11316 RVA: 0x00055A20 File Offset: 0x00053C20
		// (set) Token: 0x06002C35 RID: 11317 RVA: 0x00055A40 File Offset: 0x00053C40
		[XmlIgnore]
		[Browsable(false)]
		public bool partneridSpecified
		{
			get
			{
				return this._partnerid != null;
			}
			set
			{
				bool flag = value == (this._partnerid == null);
				if (flag)
				{
					this._partnerid = (value ? new ulong?(this.partnerid) : null);
				}
			}
		}

		// Token: 0x06002C36 RID: 11318 RVA: 0x00055A84 File Offset: 0x00053C84
		private bool ShouldSerializepartnerid()
		{
			return this.partneridSpecified;
		}

		// Token: 0x06002C37 RID: 11319 RVA: 0x00055A9C File Offset: 0x00053C9C
		private void Resetpartnerid()
		{
			this.partneridSpecified = false;
		}

		// Token: 0x17000DB6 RID: 3510
		// (get) Token: 0x06002C38 RID: 11320 RVA: 0x00055AA8 File Offset: 0x00053CA8
		// (set) Token: 0x06002C39 RID: 11321 RVA: 0x00055AD4 File Offset: 0x00053CD4
		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000DB7 RID: 3511
		// (get) Token: 0x06002C3A RID: 11322 RVA: 0x00055AE4 File Offset: 0x00053CE4
		// (set) Token: 0x06002C3B RID: 11323 RVA: 0x00055B04 File Offset: 0x00053D04
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

		// Token: 0x06002C3C RID: 11324 RVA: 0x00055B48 File Offset: 0x00053D48
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06002C3D RID: 11325 RVA: 0x00055B60 File Offset: 0x00053D60
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000DB8 RID: 3512
		// (get) Token: 0x06002C3E RID: 11326 RVA: 0x00055B6C File Offset: 0x00053D6C
		// (set) Token: 0x06002C3F RID: 11327 RVA: 0x00055B98 File Offset: 0x00053D98
		[ProtoMember(6, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000DB9 RID: 3513
		// (get) Token: 0x06002C40 RID: 11328 RVA: 0x00055BA8 File Offset: 0x00053DA8
		// (set) Token: 0x06002C41 RID: 11329 RVA: 0x00055BC8 File Offset: 0x00053DC8
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

		// Token: 0x06002C42 RID: 11330 RVA: 0x00055C0C File Offset: 0x00053E0C
		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		// Token: 0x06002C43 RID: 11331 RVA: 0x00055C24 File Offset: 0x00053E24
		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		// Token: 0x17000DBA RID: 3514
		// (get) Token: 0x06002C44 RID: 11332 RVA: 0x00055C30 File Offset: 0x00053E30
		[ProtoMember(7, Name = "memberid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> memberid
		{
			get
			{
				return this._memberid;
			}
		}

		// Token: 0x06002C45 RID: 11333 RVA: 0x00055C48 File Offset: 0x00053E48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AEE RID: 2798
		private ErrorCode? _result;

		// Token: 0x04000AEF RID: 2799
		private ulong? _err_roleid;

		// Token: 0x04000AF0 RID: 2800
		private string _err_rolename;

		// Token: 0x04000AF1 RID: 2801
		private ulong? _partnerid;

		// Token: 0x04000AF2 RID: 2802
		private uint? _level;

		// Token: 0x04000AF3 RID: 2803
		private uint? _degree;

		// Token: 0x04000AF4 RID: 2804
		private readonly List<ulong> _memberid = new List<ulong>();

		// Token: 0x04000AF5 RID: 2805
		private IExtension extensionObject;
	}
}
