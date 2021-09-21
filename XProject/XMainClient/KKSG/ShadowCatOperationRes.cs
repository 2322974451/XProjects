using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200055F RID: 1375
	[ProtoContract(Name = "ShadowCatOperationRes")]
	[Serializable]
	public class ShadowCatOperationRes : IExtensible
	{
		// Token: 0x1700157D RID: 5501
		// (get) Token: 0x06004661 RID: 18017 RVA: 0x00085AF0 File Offset: 0x00083CF0
		// (set) Token: 0x06004662 RID: 18018 RVA: 0x00085B1C File Offset: 0x00083D1C
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

		// Token: 0x1700157E RID: 5502
		// (get) Token: 0x06004663 RID: 18019 RVA: 0x00085B2C File Offset: 0x00083D2C
		// (set) Token: 0x06004664 RID: 18020 RVA: 0x00085B4C File Offset: 0x00083D4C
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

		// Token: 0x06004665 RID: 18021 RVA: 0x00085B90 File Offset: 0x00083D90
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004666 RID: 18022 RVA: 0x00085BA8 File Offset: 0x00083DA8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x1700157F RID: 5503
		// (get) Token: 0x06004667 RID: 18023 RVA: 0x00085BB4 File Offset: 0x00083DB4
		[ProtoMember(2, Name = "treasures", DataFormat = DataFormat.TwosComplement)]
		public List<uint> treasures
		{
			get
			{
				return this._treasures;
			}
		}

		// Token: 0x06004668 RID: 18024 RVA: 0x00085BCC File Offset: 0x00083DCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400118D RID: 4493
		private ErrorCode? _errorcode;

		// Token: 0x0400118E RID: 4494
		private readonly List<uint> _treasures = new List<uint>();

		// Token: 0x0400118F RID: 4495
		private IExtension extensionObject;
	}
}
