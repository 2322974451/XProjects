using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000142 RID: 322
	[ProtoContract(Name = "DoAddFriendRes")]
	[Serializable]
	public class DoAddFriendRes : IExtensible
	{
		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x060013E3 RID: 5091 RVA: 0x000282CC File Offset: 0x000264CC
		// (set) Token: 0x060013E4 RID: 5092 RVA: 0x000282F8 File Offset: 0x000264F8
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

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x060013E5 RID: 5093 RVA: 0x00028308 File Offset: 0x00026508
		// (set) Token: 0x060013E6 RID: 5094 RVA: 0x00028328 File Offset: 0x00026528
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

		// Token: 0x060013E7 RID: 5095 RVA: 0x0002836C File Offset: 0x0002656C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x00028384 File Offset: 0x00026584
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x060013E9 RID: 5097 RVA: 0x00028390 File Offset: 0x00026590
		[ProtoMember(2, Name = "failedlist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> failedlist
		{
			get
			{
				return this._failedlist;
			}
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x000283A8 File Offset: 0x000265A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004EE RID: 1262
		private ErrorCode? _errorcode;

		// Token: 0x040004EF RID: 1263
		private readonly List<ulong> _failedlist = new List<ulong>();

		// Token: 0x040004F0 RID: 1264
		private IExtension extensionObject;
	}
}
