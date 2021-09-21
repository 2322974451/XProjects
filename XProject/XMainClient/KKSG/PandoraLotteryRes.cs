using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000348 RID: 840
	[ProtoContract(Name = "PandoraLotteryRes")]
	[Serializable]
	public class PandoraLotteryRes : IExtensible
	{
		// Token: 0x17000E3F RID: 3647
		// (get) Token: 0x06002DEB RID: 11755 RVA: 0x00058D48 File Offset: 0x00056F48
		// (set) Token: 0x06002DEC RID: 11756 RVA: 0x00058D74 File Offset: 0x00056F74
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

		// Token: 0x17000E40 RID: 3648
		// (get) Token: 0x06002DED RID: 11757 RVA: 0x00058D84 File Offset: 0x00056F84
		// (set) Token: 0x06002DEE RID: 11758 RVA: 0x00058DA4 File Offset: 0x00056FA4
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

		// Token: 0x06002DEF RID: 11759 RVA: 0x00058DE8 File Offset: 0x00056FE8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002DF0 RID: 11760 RVA: 0x00058E00 File Offset: 0x00057000
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000E41 RID: 3649
		// (get) Token: 0x06002DF1 RID: 11761 RVA: 0x00058E0C File Offset: 0x0005700C
		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06002DF2 RID: 11762 RVA: 0x00058E24 File Offset: 0x00057024
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B6B RID: 2923
		private ErrorCode? _errorcode;

		// Token: 0x04000B6C RID: 2924
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04000B6D RID: 2925
		private IExtension extensionObject;
	}
}
