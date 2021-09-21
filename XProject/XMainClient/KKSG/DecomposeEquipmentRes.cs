using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000038 RID: 56
	[ProtoContract(Name = "DecomposeEquipmentRes")]
	[Serializable]
	public class DecomposeEquipmentRes : IExtensible
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x0000A068 File Offset: 0x00008268
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x0000A094 File Offset: 0x00008294
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x0000A0A4 File Offset: 0x000082A4
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x0000A0C4 File Offset: 0x000082C4
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000A108 File Offset: 0x00008308
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000A120 File Offset: 0x00008320
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060003DB RID: 987 RVA: 0x0000A12C File Offset: 0x0000832C
		[ProtoMember(2, Name = "param", DataFormat = DataFormat.FixedSize)]
		public List<float> param
		{
			get
			{
				return this._param;
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000A144 File Offset: 0x00008344
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000103 RID: 259
		private ErrorCode? _ErrorCode;

		// Token: 0x04000104 RID: 260
		private readonly List<float> _param = new List<float>();

		// Token: 0x04000105 RID: 261
		private IExtension extensionObject;
	}
}
