using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000457 RID: 1111
	[ProtoContract(Name = "GroupChatLeaderReviewS2C")]
	[Serializable]
	public class GroupChatLeaderReviewS2C : IExtensible
	{
		// Token: 0x170011EE RID: 4590
		// (get) Token: 0x06003A76 RID: 14966 RVA: 0x0006FCC8 File Offset: 0x0006DEC8
		// (set) Token: 0x06003A77 RID: 14967 RVA: 0x0006FCF4 File Offset: 0x0006DEF4
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

		// Token: 0x170011EF RID: 4591
		// (get) Token: 0x06003A78 RID: 14968 RVA: 0x0006FD04 File Offset: 0x0006DF04
		// (set) Token: 0x06003A79 RID: 14969 RVA: 0x0006FD24 File Offset: 0x0006DF24
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

		// Token: 0x06003A7A RID: 14970 RVA: 0x0006FD68 File Offset: 0x0006DF68
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003A7B RID: 14971 RVA: 0x0006FD80 File Offset: 0x0006DF80
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003A7C RID: 14972 RVA: 0x0006FD8C File Offset: 0x0006DF8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E82 RID: 3714
		private ErrorCode? _errorcode;

		// Token: 0x04000E83 RID: 3715
		private IExtension extensionObject;
	}
}
