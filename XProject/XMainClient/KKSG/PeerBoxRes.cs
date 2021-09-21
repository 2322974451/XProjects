using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000507 RID: 1287
	[ProtoContract(Name = "PeerBoxRes")]
	[Serializable]
	public class PeerBoxRes : IExtensible
	{
		// Token: 0x17001450 RID: 5200
		// (get) Token: 0x06004263 RID: 16995 RVA: 0x0007E5FC File Offset: 0x0007C7FC
		// (set) Token: 0x06004264 RID: 16996 RVA: 0x0007E628 File Offset: 0x0007C828
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

		// Token: 0x17001451 RID: 5201
		// (get) Token: 0x06004265 RID: 16997 RVA: 0x0007E638 File Offset: 0x0007C838
		// (set) Token: 0x06004266 RID: 16998 RVA: 0x0007E658 File Offset: 0x0007C858
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

		// Token: 0x06004267 RID: 16999 RVA: 0x0007E69C File Offset: 0x0007C89C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004268 RID: 17000 RVA: 0x0007E6B4 File Offset: 0x0007C8B4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17001452 RID: 5202
		// (get) Token: 0x06004269 RID: 17001 RVA: 0x0007E6C0 File Offset: 0x0007C8C0
		// (set) Token: 0x0600426A RID: 17002 RVA: 0x0007E6D8 File Offset: 0x0007C8D8
		[ProtoMember(2, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		// Token: 0x17001453 RID: 5203
		// (get) Token: 0x0600426B RID: 17003 RVA: 0x0007E6E4 File Offset: 0x0007C8E4
		// (set) Token: 0x0600426C RID: 17004 RVA: 0x0007E710 File Offset: 0x0007C910
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17001454 RID: 5204
		// (get) Token: 0x0600426D RID: 17005 RVA: 0x0007E720 File Offset: 0x0007C920
		// (set) Token: 0x0600426E RID: 17006 RVA: 0x0007E740 File Offset: 0x0007C940
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x0600426F RID: 17007 RVA: 0x0007E784 File Offset: 0x0007C984
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004270 RID: 17008 RVA: 0x0007E79C File Offset: 0x0007C99C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06004271 RID: 17009 RVA: 0x0007E7A8 File Offset: 0x0007C9A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400108E RID: 4238
		private ErrorCode? _errorcode;

		// Token: 0x0400108F RID: 4239
		private ItemBrief _item = null;

		// Token: 0x04001090 RID: 4240
		private uint? _type;

		// Token: 0x04001091 RID: 4241
		private IExtension extensionObject;
	}
}
