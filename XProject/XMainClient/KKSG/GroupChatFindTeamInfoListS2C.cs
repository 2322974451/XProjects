using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200044D RID: 1101
	[ProtoContract(Name = "GroupChatFindTeamInfoListS2C")]
	[Serializable]
	public class GroupChatFindTeamInfoListS2C : IExtensible
	{
		// Token: 0x170011D5 RID: 4565
		// (get) Token: 0x06003A1F RID: 14879 RVA: 0x0006F308 File Offset: 0x0006D508
		[ProtoMember(1, Name = "teamlist", DataFormat = DataFormat.Default)]
		public List<GroupChatFindTeamInfo> teamlist
		{
			get
			{
				return this._teamlist;
			}
		}

		// Token: 0x170011D6 RID: 4566
		// (get) Token: 0x06003A20 RID: 14880 RVA: 0x0006F320 File Offset: 0x0006D520
		// (set) Token: 0x06003A21 RID: 14881 RVA: 0x0006F34C File Offset: 0x0006D54C
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

		// Token: 0x170011D7 RID: 4567
		// (get) Token: 0x06003A22 RID: 14882 RVA: 0x0006F35C File Offset: 0x0006D55C
		// (set) Token: 0x06003A23 RID: 14883 RVA: 0x0006F37C File Offset: 0x0006D57C
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

		// Token: 0x06003A24 RID: 14884 RVA: 0x0006F3C0 File Offset: 0x0006D5C0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003A25 RID: 14885 RVA: 0x0006F3D8 File Offset: 0x0006D5D8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003A26 RID: 14886 RVA: 0x0006F3E4 File Offset: 0x0006D5E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E69 RID: 3689
		private readonly List<GroupChatFindTeamInfo> _teamlist = new List<GroupChatFindTeamInfo>();

		// Token: 0x04000E6A RID: 3690
		private ErrorCode? _errorcode;

		// Token: 0x04000E6B RID: 3691
		private IExtension extensionObject;
	}
}
