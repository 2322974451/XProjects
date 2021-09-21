using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000EA RID: 234
	[ProtoContract(Name = "ChangeSupplementNtf")]
	[Serializable]
	public class ChangeSupplementNtf : IExtensible
	{
		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06000EFC RID: 3836 RVA: 0x0001EF88 File Offset: 0x0001D188
		// (set) Token: 0x06000EFD RID: 3837 RVA: 0x0001EFB4 File Offset: 0x0001D1B4
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

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000EFE RID: 3838 RVA: 0x0001EFC4 File Offset: 0x0001D1C4
		// (set) Token: 0x06000EFF RID: 3839 RVA: 0x0001EFE4 File Offset: 0x0001D1E4
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

		// Token: 0x06000F00 RID: 3840 RVA: 0x0001F028 File Offset: 0x0001D228
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x0001F040 File Offset: 0x0001D240
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000F02 RID: 3842 RVA: 0x0001F04C File Offset: 0x0001D24C
		[ProtoMember(2, Name = "uniqueids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uniqueids
		{
			get
			{
				return this._uniqueids;
			}
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x0001F064 File Offset: 0x0001D264
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003C4 RID: 964
		private ErrorCode? _errorcode;

		// Token: 0x040003C5 RID: 965
		private readonly List<ulong> _uniqueids = new List<ulong>();

		// Token: 0x040003C6 RID: 966
		private IExtension extensionObject;
	}
}
