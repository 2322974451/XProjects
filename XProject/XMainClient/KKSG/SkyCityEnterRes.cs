using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000241 RID: 577
	[ProtoContract(Name = "SkyCityEnterRes")]
	[Serializable]
	public class SkyCityEnterRes : IExtensible
	{
		// Token: 0x170009FF RID: 2559
		// (get) Token: 0x0600200E RID: 8206 RVA: 0x0003ED0C File Offset: 0x0003CF0C
		// (set) Token: 0x0600200F RID: 8207 RVA: 0x0003ED38 File Offset: 0x0003CF38
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000A00 RID: 2560
		// (get) Token: 0x06002010 RID: 8208 RVA: 0x0003ED48 File Offset: 0x0003CF48
		// (set) Token: 0x06002011 RID: 8209 RVA: 0x0003ED68 File Offset: 0x0003CF68
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06002012 RID: 8210 RVA: 0x0003EDAC File Offset: 0x0003CFAC
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002013 RID: 8211 RVA: 0x0003EDC4 File Offset: 0x0003CFC4
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06002014 RID: 8212 RVA: 0x0003EDD0 File Offset: 0x0003CFD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000801 RID: 2049
		private ErrorCode? _error;

		// Token: 0x04000802 RID: 2050
		private IExtension extensionObject;
	}
}
