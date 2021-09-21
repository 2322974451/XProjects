using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200045B RID: 1115
	[ProtoContract(Name = "GroupChatGetGroupInfoS2C")]
	[Serializable]
	public class GroupChatGetGroupInfoS2C : IExtensible
	{
		// Token: 0x170011F8 RID: 4600
		// (get) Token: 0x06003A9C RID: 15004 RVA: 0x00070130 File Offset: 0x0006E330
		[ProtoMember(1, Name = "playerlist", DataFormat = DataFormat.Default)]
		public List<GroupChatPlayerInfo> playerlist
		{
			get
			{
				return this._playerlist;
			}
		}

		// Token: 0x170011F9 RID: 4601
		// (get) Token: 0x06003A9D RID: 15005 RVA: 0x00070148 File Offset: 0x0006E348
		// (set) Token: 0x06003A9E RID: 15006 RVA: 0x00070174 File Offset: 0x0006E374
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

		// Token: 0x170011FA RID: 4602
		// (get) Token: 0x06003A9F RID: 15007 RVA: 0x00070184 File Offset: 0x0006E384
		// (set) Token: 0x06003AA0 RID: 15008 RVA: 0x000701A4 File Offset: 0x0006E3A4
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

		// Token: 0x06003AA1 RID: 15009 RVA: 0x000701E8 File Offset: 0x0006E3E8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003AA2 RID: 15010 RVA: 0x00070200 File Offset: 0x0006E400
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003AA3 RID: 15011 RVA: 0x0007020C File Offset: 0x0006E40C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E8B RID: 3723
		private readonly List<GroupChatPlayerInfo> _playerlist = new List<GroupChatPlayerInfo>();

		// Token: 0x04000E8C RID: 3724
		private ErrorCode? _errorcode;

		// Token: 0x04000E8D RID: 3725
		private IExtension extensionObject;
	}
}
