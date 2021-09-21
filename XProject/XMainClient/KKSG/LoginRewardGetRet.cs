using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000126 RID: 294
	[ProtoContract(Name = "LoginRewardGetRet")]
	[Serializable]
	public class LoginRewardGetRet : IExtensible
	{
		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x0600122D RID: 4653 RVA: 0x00024EF8 File Offset: 0x000230F8
		// (set) Token: 0x0600122E RID: 4654 RVA: 0x00024F24 File Offset: 0x00023124
		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ret
		{
			get
			{
				return this._ret ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ret = new ErrorCode?(value);
			}
		}

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x00024F34 File Offset: 0x00023134
		// (set) Token: 0x06001230 RID: 4656 RVA: 0x00024F54 File Offset: 0x00023154
		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new ErrorCode?(this.ret) : null);
				}
			}
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x00024F98 File Offset: 0x00023198
		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x00024FB0 File Offset: 0x000231B0
		private void Resetret()
		{
			this.retSpecified = false;
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x00024FBC File Offset: 0x000231BC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400048D RID: 1165
		private ErrorCode? _ret;

		// Token: 0x0400048E RID: 1166
		private IExtension extensionObject;
	}
}
