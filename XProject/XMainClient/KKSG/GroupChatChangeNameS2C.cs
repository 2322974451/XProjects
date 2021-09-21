using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200048A RID: 1162
	[ProtoContract(Name = "GroupChatChangeNameS2C")]
	[Serializable]
	public class GroupChatChangeNameS2C : IExtensible
	{
		// Token: 0x170012A0 RID: 4768
		// (get) Token: 0x06003CBB RID: 15547 RVA: 0x00073F74 File Offset: 0x00072174
		// (set) Token: 0x06003CBC RID: 15548 RVA: 0x00073FA0 File Offset: 0x000721A0
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

		// Token: 0x170012A1 RID: 4769
		// (get) Token: 0x06003CBD RID: 15549 RVA: 0x00073FB0 File Offset: 0x000721B0
		// (set) Token: 0x06003CBE RID: 15550 RVA: 0x00073FD0 File Offset: 0x000721D0
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

		// Token: 0x06003CBF RID: 15551 RVA: 0x00074014 File Offset: 0x00072214
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003CC0 RID: 15552 RVA: 0x0007402C File Offset: 0x0007222C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003CC1 RID: 15553 RVA: 0x00074038 File Offset: 0x00072238
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F1E RID: 3870
		private ErrorCode? _errorcode;

		// Token: 0x04000F1F RID: 3871
		private IExtension extensionObject;
	}
}
