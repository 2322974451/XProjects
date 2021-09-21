using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C2 RID: 450
	[ProtoContract(Name = "GetPayAllInfoRes")]
	[Serializable]
	public class GetPayAllInfoRes : IExtensible
	{
		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x06001A21 RID: 6689 RVA: 0x00033C00 File Offset: 0x00031E00
		// (set) Token: 0x06001A22 RID: 6690 RVA: 0x00033C2C File Offset: 0x00031E2C
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x06001A23 RID: 6691 RVA: 0x00033C3C File Offset: 0x00031E3C
		// (set) Token: 0x06001A24 RID: 6692 RVA: 0x00033C5C File Offset: 0x00031E5C
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001A25 RID: 6693 RVA: 0x00033CA0 File Offset: 0x00031EA0
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001A26 RID: 6694 RVA: 0x00033CB8 File Offset: 0x00031EB8
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x06001A27 RID: 6695 RVA: 0x00033CC4 File Offset: 0x00031EC4
		// (set) Token: 0x06001A28 RID: 6696 RVA: 0x00033CDC File Offset: 0x00031EDC
		[ProtoMember(2, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayAllInfo info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x00033CE8 File Offset: 0x00031EE8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000680 RID: 1664
		private ErrorCode? _errcode;

		// Token: 0x04000681 RID: 1665
		private PayAllInfo _info = null;

		// Token: 0x04000682 RID: 1666
		private IExtension extensionObject;
	}
}
