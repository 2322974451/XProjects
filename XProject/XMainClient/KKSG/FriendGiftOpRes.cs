using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200014B RID: 331
	[ProtoContract(Name = "FriendGiftOpRes")]
	[Serializable]
	public class FriendGiftOpRes : IExtensible
	{
		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x0600143B RID: 5179 RVA: 0x00028CEC File Offset: 0x00026EEC
		// (set) Token: 0x0600143C RID: 5180 RVA: 0x00028D18 File Offset: 0x00026F18
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

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x0600143D RID: 5181 RVA: 0x00028D28 File Offset: 0x00026F28
		// (set) Token: 0x0600143E RID: 5182 RVA: 0x00028D48 File Offset: 0x00026F48
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

		// Token: 0x0600143F RID: 5183 RVA: 0x00028D8C File Offset: 0x00026F8C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001440 RID: 5184 RVA: 0x00028DA4 File Offset: 0x00026FA4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x00028DB0 File Offset: 0x00026FB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400050A RID: 1290
		private ErrorCode? _errorcode;

		// Token: 0x0400050B RID: 1291
		private IExtension extensionObject;
	}
}
