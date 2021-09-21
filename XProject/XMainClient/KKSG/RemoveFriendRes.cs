using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000076 RID: 118
	[ProtoContract(Name = "RemoveFriendRes")]
	[Serializable]
	public class RemoveFriendRes : IExtensible
	{
		// Token: 0x1700028A RID: 650
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x000118C8 File Offset: 0x0000FAC8
		// (set) Token: 0x060007D4 RID: 2004 RVA: 0x000118F4 File Offset: 0x0000FAF4
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

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x00011904 File Offset: 0x0000FB04
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x00011924 File Offset: 0x0000FB24
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

		// Token: 0x060007D7 RID: 2007 RVA: 0x00011968 File Offset: 0x0000FB68
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00011980 File Offset: 0x0000FB80
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0001198C File Offset: 0x0000FB8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001FB RID: 507
		private ErrorCode? _errorcode;

		// Token: 0x040001FC RID: 508
		private IExtension extensionObject;
	}
}
