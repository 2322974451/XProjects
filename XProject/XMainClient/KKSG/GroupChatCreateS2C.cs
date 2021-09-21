using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000465 RID: 1125
	[ProtoContract(Name = "GroupChatCreateS2C")]
	[Serializable]
	public class GroupChatCreateS2C : IExtensible
	{
		// Token: 0x17001211 RID: 4625
		// (get) Token: 0x06003AF1 RID: 15089 RVA: 0x00070AA8 File Offset: 0x0006ECA8
		// (set) Token: 0x06003AF2 RID: 15090 RVA: 0x00070AD5 File Offset: 0x0006ECD5
		[ProtoMember(1, IsRequired = false, Name = "groupchatID", DataFormat = DataFormat.TwosComplement)]
		public ulong groupchatID
		{
			get
			{
				return this._groupchatID ?? 0UL;
			}
			set
			{
				this._groupchatID = new ulong?(value);
			}
		}

		// Token: 0x17001212 RID: 4626
		// (get) Token: 0x06003AF3 RID: 15091 RVA: 0x00070AE4 File Offset: 0x0006ECE4
		// (set) Token: 0x06003AF4 RID: 15092 RVA: 0x00070B04 File Offset: 0x0006ED04
		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatIDSpecified
		{
			get
			{
				return this._groupchatID != null;
			}
			set
			{
				bool flag = value == (this._groupchatID == null);
				if (flag)
				{
					this._groupchatID = (value ? new ulong?(this.groupchatID) : null);
				}
			}
		}

		// Token: 0x06003AF5 RID: 15093 RVA: 0x00070B48 File Offset: 0x0006ED48
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003AF6 RID: 15094 RVA: 0x00070B60 File Offset: 0x0006ED60
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x17001213 RID: 4627
		// (get) Token: 0x06003AF7 RID: 15095 RVA: 0x00070B6C File Offset: 0x0006ED6C
		// (set) Token: 0x06003AF8 RID: 15096 RVA: 0x00070B98 File Offset: 0x0006ED98
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

		// Token: 0x17001214 RID: 4628
		// (get) Token: 0x06003AF9 RID: 15097 RVA: 0x00070BA8 File Offset: 0x0006EDA8
		// (set) Token: 0x06003AFA RID: 15098 RVA: 0x00070BC8 File Offset: 0x0006EDC8
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

		// Token: 0x06003AFB RID: 15099 RVA: 0x00070C0C File Offset: 0x0006EE0C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003AFC RID: 15100 RVA: 0x00070C24 File Offset: 0x0006EE24
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003AFD RID: 15101 RVA: 0x00070C30 File Offset: 0x0006EE30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EA4 RID: 3748
		private ulong? _groupchatID;

		// Token: 0x04000EA5 RID: 3749
		private ErrorCode? _errorcode;

		// Token: 0x04000EA6 RID: 3750
		private IExtension extensionObject;
	}
}
