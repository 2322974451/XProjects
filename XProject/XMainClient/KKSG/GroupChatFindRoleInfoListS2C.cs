using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200044F RID: 1103
	[ProtoContract(Name = "GroupChatFindRoleInfoListS2C")]
	[Serializable]
	public class GroupChatFindRoleInfoListS2C : IExtensible
	{
		// Token: 0x170011DA RID: 4570
		// (get) Token: 0x06003A30 RID: 14896 RVA: 0x0006F4FC File Offset: 0x0006D6FC
		[ProtoMember(1, Name = "rolelist", DataFormat = DataFormat.Default)]
		public List<GroupChatFindRoleInfo> rolelist
		{
			get
			{
				return this._rolelist;
			}
		}

		// Token: 0x170011DB RID: 4571
		// (get) Token: 0x06003A31 RID: 14897 RVA: 0x0006F514 File Offset: 0x0006D714
		// (set) Token: 0x06003A32 RID: 14898 RVA: 0x0006F540 File Offset: 0x0006D740
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

		// Token: 0x170011DC RID: 4572
		// (get) Token: 0x06003A33 RID: 14899 RVA: 0x0006F550 File Offset: 0x0006D750
		// (set) Token: 0x06003A34 RID: 14900 RVA: 0x0006F570 File Offset: 0x0006D770
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

		// Token: 0x06003A35 RID: 14901 RVA: 0x0006F5B4 File Offset: 0x0006D7B4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003A36 RID: 14902 RVA: 0x0006F5CC File Offset: 0x0006D7CC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003A37 RID: 14903 RVA: 0x0006F5D8 File Offset: 0x0006D7D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E6E RID: 3694
		private readonly List<GroupChatFindRoleInfo> _rolelist = new List<GroupChatFindRoleInfo>();

		// Token: 0x04000E6F RID: 3695
		private ErrorCode? _errorcode;

		// Token: 0x04000E70 RID: 3696
		private IExtension extensionObject;
	}
}
