using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000451 RID: 1105
	[ProtoContract(Name = "GroupChatLeaderReviewListS2C")]
	[Serializable]
	public class GroupChatLeaderReviewListS2C : IExtensible
	{
		// Token: 0x170011DD RID: 4573
		// (get) Token: 0x06003A3B RID: 14907 RVA: 0x0006F62C File Offset: 0x0006D82C
		[ProtoMember(1, Name = "roleinfolist", DataFormat = DataFormat.Default)]
		public List<GroupChatFindRoleInfo> roleinfolist
		{
			get
			{
				return this._roleinfolist;
			}
		}

		// Token: 0x170011DE RID: 4574
		// (get) Token: 0x06003A3C RID: 14908 RVA: 0x0006F644 File Offset: 0x0006D844
		// (set) Token: 0x06003A3D RID: 14909 RVA: 0x0006F670 File Offset: 0x0006D870
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

		// Token: 0x170011DF RID: 4575
		// (get) Token: 0x06003A3E RID: 14910 RVA: 0x0006F680 File Offset: 0x0006D880
		// (set) Token: 0x06003A3F RID: 14911 RVA: 0x0006F6A0 File Offset: 0x0006D8A0
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

		// Token: 0x06003A40 RID: 14912 RVA: 0x0006F6E4 File Offset: 0x0006D8E4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003A41 RID: 14913 RVA: 0x0006F6FC File Offset: 0x0006D8FC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003A42 RID: 14914 RVA: 0x0006F708 File Offset: 0x0006D908
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E72 RID: 3698
		private readonly List<GroupChatFindRoleInfo> _roleinfolist = new List<GroupChatFindRoleInfo>();

		// Token: 0x04000E73 RID: 3699
		private ErrorCode? _errorcode;

		// Token: 0x04000E74 RID: 3700
		private IExtension extensionObject;
	}
}
