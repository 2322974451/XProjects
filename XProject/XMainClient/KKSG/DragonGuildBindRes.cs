using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004CD RID: 1229
	[ProtoContract(Name = "DragonGuildBindRes")]
	[Serializable]
	public class DragonGuildBindRes : IExtensible
	{
		// Token: 0x1700138F RID: 5007
		// (get) Token: 0x06003FDC RID: 16348 RVA: 0x00079B0C File Offset: 0x00077D0C
		// (set) Token: 0x06003FDD RID: 16349 RVA: 0x00079B38 File Offset: 0x00077D38
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17001390 RID: 5008
		// (get) Token: 0x06003FDE RID: 16350 RVA: 0x00079B48 File Offset: 0x00077D48
		// (set) Token: 0x06003FDF RID: 16351 RVA: 0x00079B68 File Offset: 0x00077D68
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06003FE0 RID: 16352 RVA: 0x00079BAC File Offset: 0x00077DAC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003FE1 RID: 16353 RVA: 0x00079BC4 File Offset: 0x00077DC4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001391 RID: 5009
		// (get) Token: 0x06003FE2 RID: 16354 RVA: 0x00079BD0 File Offset: 0x00077DD0
		// (set) Token: 0x06003FE3 RID: 16355 RVA: 0x00079BF1 File Offset: 0x00077DF1
		[ProtoMember(2, IsRequired = false, Name = "group_name", DataFormat = DataFormat.Default)]
		public string group_name
		{
			get
			{
				return this._group_name ?? "";
			}
			set
			{
				this._group_name = value;
			}
		}

		// Token: 0x17001392 RID: 5010
		// (get) Token: 0x06003FE4 RID: 16356 RVA: 0x00079BFC File Offset: 0x00077DFC
		// (set) Token: 0x06003FE5 RID: 16357 RVA: 0x00079C18 File Offset: 0x00077E18
		[XmlIgnore]
		[Browsable(false)]
		public bool group_nameSpecified
		{
			get
			{
				return this._group_name != null;
			}
			set
			{
				bool flag = value == (this._group_name == null);
				if (flag)
				{
					this._group_name = (value ? this.group_name : null);
				}
			}
		}

		// Token: 0x06003FE6 RID: 16358 RVA: 0x00079C48 File Offset: 0x00077E48
		private bool ShouldSerializegroup_name()
		{
			return this.group_nameSpecified;
		}

		// Token: 0x06003FE7 RID: 16359 RVA: 0x00079C60 File Offset: 0x00077E60
		private void Resetgroup_name()
		{
			this.group_nameSpecified = false;
		}

		// Token: 0x06003FE8 RID: 16360 RVA: 0x00079C6C File Offset: 0x00077E6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FE6 RID: 4070
		private ErrorCode? _result;

		// Token: 0x04000FE7 RID: 4071
		private string _group_name;

		// Token: 0x04000FE8 RID: 4072
		private IExtension extensionObject;
	}
}
