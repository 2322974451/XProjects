using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000271 RID: 625
	[ProtoContract(Name = "GetSpActivityBigPrizeRes")]
	[Serializable]
	public class GetSpActivityBigPrizeRes : IExtensible
	{
		// Token: 0x17000AD3 RID: 2771
		// (get) Token: 0x060022CC RID: 8908 RVA: 0x00043F78 File Offset: 0x00042178
		// (set) Token: 0x060022CD RID: 8909 RVA: 0x00043FA4 File Offset: 0x000421A4
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

		// Token: 0x17000AD4 RID: 2772
		// (get) Token: 0x060022CE RID: 8910 RVA: 0x00043FB4 File Offset: 0x000421B4
		// (set) Token: 0x060022CF RID: 8911 RVA: 0x00043FD4 File Offset: 0x000421D4
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

		// Token: 0x060022D0 RID: 8912 RVA: 0x00044018 File Offset: 0x00042218
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060022D1 RID: 8913 RVA: 0x00044030 File Offset: 0x00042230
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060022D2 RID: 8914 RVA: 0x0004403C File Offset: 0x0004223C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008A3 RID: 2211
		private ErrorCode? _errorcode;

		// Token: 0x040008A4 RID: 2212
		private IExtension extensionObject;
	}
}
