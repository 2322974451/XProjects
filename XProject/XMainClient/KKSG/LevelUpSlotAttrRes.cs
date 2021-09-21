using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F4 RID: 244
	[ProtoContract(Name = "LevelUpSlotAttrRes")]
	[Serializable]
	public class LevelUpSlotAttrRes : IExtensible
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06000FA7 RID: 4007 RVA: 0x000203A0 File Offset: 0x0001E5A0
		// (set) Token: 0x06000FA8 RID: 4008 RVA: 0x000203CC File Offset: 0x0001E5CC
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

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06000FA9 RID: 4009 RVA: 0x000203DC File Offset: 0x0001E5DC
		// (set) Token: 0x06000FAA RID: 4010 RVA: 0x000203FC File Offset: 0x0001E5FC
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

		// Token: 0x06000FAB RID: 4011 RVA: 0x00020440 File Offset: 0x0001E640
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x00020458 File Offset: 0x0001E658
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06000FAD RID: 4013 RVA: 0x00020464 File Offset: 0x0001E664
		[ProtoMember(2, Name = "uplevels", DataFormat = DataFormat.TwosComplement)]
		public List<uint> uplevels
		{
			get
			{
				return this._uplevels;
			}
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0002047C File Offset: 0x0001E67C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003E8 RID: 1000
		private ErrorCode? _errorcode;

		// Token: 0x040003E9 RID: 1001
		private readonly List<uint> _uplevels = new List<uint>();

		// Token: 0x040003EA RID: 1002
		private IExtension extensionObject;
	}
}
