using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F8 RID: 248
	[ProtoContract(Name = "TShowTopListRes")]
	[Serializable]
	public class TShowTopListRes : IExtensible
	{
		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06000FD7 RID: 4055 RVA: 0x0002093C File Offset: 0x0001EB3C
		// (set) Token: 0x06000FD8 RID: 4056 RVA: 0x00020968 File Offset: 0x0001EB68
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06000FD9 RID: 4057 RVA: 0x00020978 File Offset: 0x0001EB78
		// (set) Token: 0x06000FDA RID: 4058 RVA: 0x00020998 File Offset: 0x0001EB98
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x000209DC File Offset: 0x0001EBDC
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x000209F4 File Offset: 0x0001EBF4
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06000FDD RID: 4061 RVA: 0x00020A00 File Offset: 0x0001EC00
		[ProtoMember(2, Name = "rolesInfo", DataFormat = DataFormat.Default)]
		public List<RoleBriefInfo> rolesInfo
		{
			get
			{
				return this._rolesInfo;
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06000FDE RID: 4062 RVA: 0x00020A18 File Offset: 0x0001EC18
		// (set) Token: 0x06000FDF RID: 4063 RVA: 0x00020A44 File Offset: 0x0001EC44
		[ProtoMember(3, IsRequired = false, Name = "isEnd", DataFormat = DataFormat.Default)]
		public bool isEnd
		{
			get
			{
				return this._isEnd ?? false;
			}
			set
			{
				this._isEnd = new bool?(value);
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06000FE0 RID: 4064 RVA: 0x00020A54 File Offset: 0x0001EC54
		// (set) Token: 0x06000FE1 RID: 4065 RVA: 0x00020A74 File Offset: 0x0001EC74
		[XmlIgnore]
		[Browsable(false)]
		public bool isEndSpecified
		{
			get
			{
				return this._isEnd != null;
			}
			set
			{
				bool flag = value == (this._isEnd == null);
				if (flag)
				{
					this._isEnd = (value ? new bool?(this.isEnd) : null);
				}
			}
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x00020AB8 File Offset: 0x0001ECB8
		private bool ShouldSerializeisEnd()
		{
			return this.isEndSpecified;
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x00020AD0 File Offset: 0x0001ECD0
		private void ResetisEnd()
		{
			this.isEndSpecified = false;
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x00020ADC File Offset: 0x0001ECDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003F5 RID: 1013
		private ErrorCode? _error;

		// Token: 0x040003F6 RID: 1014
		private readonly List<RoleBriefInfo> _rolesInfo = new List<RoleBriefInfo>();

		// Token: 0x040003F7 RID: 1015
		private bool? _isEnd;

		// Token: 0x040003F8 RID: 1016
		private IExtension extensionObject;
	}
}
