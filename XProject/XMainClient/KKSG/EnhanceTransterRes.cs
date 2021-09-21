using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000153 RID: 339
	[ProtoContract(Name = "EnhanceTransterRes")]
	[Serializable]
	public class EnhanceTransterRes : IExtensible
	{
		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x060014AE RID: 5294 RVA: 0x00029A58 File Offset: 0x00027C58
		// (set) Token: 0x060014AF RID: 5295 RVA: 0x00029A84 File Offset: 0x00027C84
		[ProtoMember(1, IsRequired = false, Name = "isperfect", DataFormat = DataFormat.Default)]
		public bool isperfect
		{
			get
			{
				return this._isperfect ?? false;
			}
			set
			{
				this._isperfect = new bool?(value);
			}
		}

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x060014B0 RID: 5296 RVA: 0x00029A94 File Offset: 0x00027C94
		// (set) Token: 0x060014B1 RID: 5297 RVA: 0x00029AB4 File Offset: 0x00027CB4
		[XmlIgnore]
		[Browsable(false)]
		public bool isperfectSpecified
		{
			get
			{
				return this._isperfect != null;
			}
			set
			{
				bool flag = value == (this._isperfect == null);
				if (flag)
				{
					this._isperfect = (value ? new bool?(this.isperfect) : null);
				}
			}
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x00029AF8 File Offset: 0x00027CF8
		private bool ShouldSerializeisperfect()
		{
			return this.isperfectSpecified;
		}

		// Token: 0x060014B3 RID: 5299 RVA: 0x00029B10 File Offset: 0x00027D10
		private void Resetisperfect()
		{
			this.isperfectSpecified = false;
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x060014B4 RID: 5300 RVA: 0x00029B1C File Offset: 0x00027D1C
		// (set) Token: 0x060014B5 RID: 5301 RVA: 0x00029B48 File Offset: 0x00027D48
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x060014B6 RID: 5302 RVA: 0x00029B58 File Offset: 0x00027D58
		// (set) Token: 0x060014B7 RID: 5303 RVA: 0x00029B78 File Offset: 0x00027D78
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

		// Token: 0x060014B8 RID: 5304 RVA: 0x00029BBC File Offset: 0x00027DBC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x00029BD4 File Offset: 0x00027DD4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x00029BE0 File Offset: 0x00027DE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000525 RID: 1317
		private bool? _isperfect;

		// Token: 0x04000526 RID: 1318
		private ErrorCode? _errorcode;

		// Token: 0x04000527 RID: 1319
		private IExtension extensionObject;
	}
}
