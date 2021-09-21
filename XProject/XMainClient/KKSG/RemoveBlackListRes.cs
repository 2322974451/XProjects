using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200007B RID: 123
	[ProtoContract(Name = "RemoveBlackListRes")]
	[Serializable]
	public class RemoveBlackListRes : IExtensible
	{
		// Token: 0x1700029B RID: 667
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x00011F44 File Offset: 0x00010144
		// (set) Token: 0x06000810 RID: 2064 RVA: 0x00011F70 File Offset: 0x00010170
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

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x00011F80 File Offset: 0x00010180
		// (set) Token: 0x06000812 RID: 2066 RVA: 0x00011FA0 File Offset: 0x000101A0
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

		// Token: 0x06000813 RID: 2067 RVA: 0x00011FE4 File Offset: 0x000101E4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00011FFC File Offset: 0x000101FC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00012008 File Offset: 0x00010208
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000209 RID: 521
		private ErrorCode? _errorcode;

		// Token: 0x0400020A RID: 522
		private IExtension extensionObject;
	}
}
