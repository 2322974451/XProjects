using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000074 RID: 116
	[ProtoContract(Name = "AddFriendRes")]
	[Serializable]
	public class AddFriendRes : IExtensible
	{
		// Token: 0x17000285 RID: 645
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x000116DC File Offset: 0x0000F8DC
		// (set) Token: 0x060007C2 RID: 1986 RVA: 0x00011708 File Offset: 0x0000F908
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

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x00011718 File Offset: 0x0000F918
		// (set) Token: 0x060007C4 RID: 1988 RVA: 0x00011738 File Offset: 0x0000F938
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

		// Token: 0x060007C5 RID: 1989 RVA: 0x0001177C File Offset: 0x0000F97C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00011794 File Offset: 0x0000F994
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x060007C7 RID: 1991 RVA: 0x000117A0 File Offset: 0x0000F9A0
		// (set) Token: 0x060007C8 RID: 1992 RVA: 0x000117B8 File Offset: 0x0000F9B8
		[ProtoMember(2, IsRequired = false, Name = "frienddata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Friend2Client frienddata
		{
			get
			{
				return this._frienddata;
			}
			set
			{
				this._frienddata = value;
			}
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x000117C4 File Offset: 0x0000F9C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001F6 RID: 502
		private ErrorCode? _errorcode;

		// Token: 0x040001F7 RID: 503
		private Friend2Client _frienddata = null;

		// Token: 0x040001F8 RID: 504
		private IExtension extensionObject;
	}
}
