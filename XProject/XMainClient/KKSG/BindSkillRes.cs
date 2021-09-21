using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200002A RID: 42
	[ProtoContract(Name = "BindSkillRes")]
	[Serializable]
	public class BindSkillRes : IExtensible
	{
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00008500 File Offset: 0x00006700
		// (set) Token: 0x060002EF RID: 751 RVA: 0x0000852C File Offset: 0x0000672C
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

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x0000853C File Offset: 0x0000673C
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x0000855C File Offset: 0x0000675C
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

		// Token: 0x060002F2 RID: 754 RVA: 0x000085A0 File Offset: 0x000067A0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x000085B8 File Offset: 0x000067B8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x000085C4 File Offset: 0x000067C4
		[ProtoMember(2, Name = "skillslot", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skillslot
		{
			get
			{
				return this._skillslot;
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000085DC File Offset: 0x000067DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000C7 RID: 199
		private ErrorCode? _errorcode;

		// Token: 0x040000C8 RID: 200
		private readonly List<uint> _skillslot = new List<uint>();

		// Token: 0x040000C9 RID: 201
		private IExtension extensionObject;
	}
}
