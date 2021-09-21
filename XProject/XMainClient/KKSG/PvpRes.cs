using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000136 RID: 310
	[ProtoContract(Name = "PvpRes")]
	[Serializable]
	public class PvpRes : IExtensible
	{
		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x060012ED RID: 4845 RVA: 0x00026584 File Offset: 0x00024784
		// (set) Token: 0x060012EE RID: 4846 RVA: 0x0002659C File Offset: 0x0002479C
		[ProtoMember(1, IsRequired = false, Name = "basedata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PvpBaseData basedata
		{
			get
			{
				return this._basedata;
			}
			set
			{
				this._basedata = value;
			}
		}

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x060012EF RID: 4847 RVA: 0x000265A8 File Offset: 0x000247A8
		// (set) Token: 0x060012F0 RID: 4848 RVA: 0x000265C0 File Offset: 0x000247C0
		[ProtoMember(2, IsRequired = false, Name = "history", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PvpHistory history
		{
			get
			{
				return this._history;
			}
			set
			{
				this._history = value;
			}
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x060012F1 RID: 4849 RVA: 0x000265CC File Offset: 0x000247CC
		// (set) Token: 0x060012F2 RID: 4850 RVA: 0x000265F8 File Offset: 0x000247F8
		[ProtoMember(3, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public PvpReqType reqtype
		{
			get
			{
				return this._reqtype ?? PvpReqType.PVP_REQ_IN_MATCH;
			}
			set
			{
				this._reqtype = new PvpReqType?(value);
			}
		}

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x060012F3 RID: 4851 RVA: 0x00026608 File Offset: 0x00024808
		// (set) Token: 0x060012F4 RID: 4852 RVA: 0x00026628 File Offset: 0x00024828
		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new PvpReqType?(this.reqtype) : null);
				}
			}
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x0002666C File Offset: 0x0002486C
		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x00026684 File Offset: 0x00024884
		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x060012F7 RID: 4855 RVA: 0x00026690 File Offset: 0x00024890
		// (set) Token: 0x060012F8 RID: 4856 RVA: 0x000266BC File Offset: 0x000248BC
		[ProtoMember(4, IsRequired = false, Name = "err", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode err
		{
			get
			{
				return this._err ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._err = new ErrorCode?(value);
			}
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x060012F9 RID: 4857 RVA: 0x000266CC File Offset: 0x000248CC
		// (set) Token: 0x060012FA RID: 4858 RVA: 0x000266EC File Offset: 0x000248EC
		[XmlIgnore]
		[Browsable(false)]
		public bool errSpecified
		{
			get
			{
				return this._err != null;
			}
			set
			{
				bool flag = value == (this._err == null);
				if (flag)
				{
					this._err = (value ? new ErrorCode?(this.err) : null);
				}
			}
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x00026730 File Offset: 0x00024930
		private bool ShouldSerializeerr()
		{
			return this.errSpecified;
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x00026748 File Offset: 0x00024948
		private void Reseterr()
		{
			this.errSpecified = false;
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x00026754 File Offset: 0x00024954
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004BA RID: 1210
		private PvpBaseData _basedata = null;

		// Token: 0x040004BB RID: 1211
		private PvpHistory _history = null;

		// Token: 0x040004BC RID: 1212
		private PvpReqType? _reqtype;

		// Token: 0x040004BD RID: 1213
		private ErrorCode? _err;

		// Token: 0x040004BE RID: 1214
		private IExtension extensionObject;
	}
}
