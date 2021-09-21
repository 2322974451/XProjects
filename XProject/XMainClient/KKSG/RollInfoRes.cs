using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D3 RID: 211
	[ProtoContract(Name = "RollInfoRes")]
	[Serializable]
	public class RollInfoRes : IExtensible
	{
		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000D90 RID: 3472 RVA: 0x0001C4DC File Offset: 0x0001A6DC
		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<RollInfo> info
		{
			get
			{
				return this._info;
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000D91 RID: 3473 RVA: 0x0001C4F4 File Offset: 0x0001A6F4
		// (set) Token: 0x06000D92 RID: 3474 RVA: 0x0001C520 File Offset: 0x0001A720
		[ProtoMember(2, IsRequired = false, Name = "errCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errCode
		{
			get
			{
				return this._errCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000D93 RID: 3475 RVA: 0x0001C530 File Offset: 0x0001A730
		// (set) Token: 0x06000D94 RID: 3476 RVA: 0x0001C550 File Offset: 0x0001A750
		[XmlIgnore]
		[Browsable(false)]
		public bool errCodeSpecified
		{
			get
			{
				return this._errCode != null;
			}
			set
			{
				bool flag = value == (this._errCode == null);
				if (flag)
				{
					this._errCode = (value ? new ErrorCode?(this.errCode) : null);
				}
			}
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x0001C594 File Offset: 0x0001A794
		private bool ShouldSerializeerrCode()
		{
			return this.errCodeSpecified;
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x0001C5AC File Offset: 0x0001A7AC
		private void ReseterrCode()
		{
			this.errCodeSpecified = false;
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x0001C5B8 File Offset: 0x0001A7B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000369 RID: 873
		private readonly List<RollInfo> _info = new List<RollInfo>();

		// Token: 0x0400036A RID: 874
		private ErrorCode? _errCode;

		// Token: 0x0400036B RID: 875
		private IExtension extensionObject;
	}
}
