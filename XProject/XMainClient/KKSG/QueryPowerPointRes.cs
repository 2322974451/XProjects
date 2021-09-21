using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B9 RID: 441
	[ProtoContract(Name = "QueryPowerPointRes")]
	[Serializable]
	public class QueryPowerPointRes : IExtensible
	{
		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x060019C4 RID: 6596 RVA: 0x000331BC File Offset: 0x000313BC
		[ProtoMember(1, Name = "bqID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bqID
		{
			get
			{
				return this._bqID;
			}
		}

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x060019C5 RID: 6597 RVA: 0x000331D4 File Offset: 0x000313D4
		[ProtoMember(2, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public List<double> ppt
		{
			get
			{
				return this._ppt;
			}
		}

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x060019C6 RID: 6598 RVA: 0x000331EC File Offset: 0x000313EC
		// (set) Token: 0x060019C7 RID: 6599 RVA: 0x00033218 File Offset: 0x00031418
		[ProtoMember(3, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x060019C8 RID: 6600 RVA: 0x00033228 File Offset: 0x00031428
		// (set) Token: 0x060019C9 RID: 6601 RVA: 0x00033248 File Offset: 0x00031448
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

		// Token: 0x060019CA RID: 6602 RVA: 0x0003328C File Offset: 0x0003148C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060019CB RID: 6603 RVA: 0x000332A4 File Offset: 0x000314A4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060019CC RID: 6604 RVA: 0x000332B0 File Offset: 0x000314B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000668 RID: 1640
		private readonly List<uint> _bqID = new List<uint>();

		// Token: 0x04000669 RID: 1641
		private readonly List<double> _ppt = new List<double>();

		// Token: 0x0400066A RID: 1642
		private ErrorCode? _errorcode;

		// Token: 0x0400066B RID: 1643
		private IExtension extensionObject;
	}
}
