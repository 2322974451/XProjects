using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200046C RID: 1132
	[ProtoContract(Name = "GroupChatClearS2C")]
	[Serializable]
	public class GroupChatClearS2C : IExtensible
	{
		// Token: 0x17001227 RID: 4647
		// (get) Token: 0x06003B3D RID: 15165 RVA: 0x00071380 File Offset: 0x0006F580
		// (set) Token: 0x06003B3E RID: 15166 RVA: 0x000713AC File Offset: 0x0006F5AC
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

		// Token: 0x17001228 RID: 4648
		// (get) Token: 0x06003B3F RID: 15167 RVA: 0x000713BC File Offset: 0x0006F5BC
		// (set) Token: 0x06003B40 RID: 15168 RVA: 0x000713DC File Offset: 0x0006F5DC
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

		// Token: 0x06003B41 RID: 15169 RVA: 0x00071420 File Offset: 0x0006F620
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003B42 RID: 15170 RVA: 0x00071438 File Offset: 0x0006F638
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003B43 RID: 15171 RVA: 0x00071444 File Offset: 0x0006F644
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EB7 RID: 3767
		private ErrorCode? _errorcode;

		// Token: 0x04000EB8 RID: 3768
		private IExtension extensionObject;
	}
}
