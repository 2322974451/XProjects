using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200010E RID: 270
	[ProtoContract(Name = "SetDesignationRes")]
	[Serializable]
	public class SetDesignationRes : IExtensible
	{
		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x0600111B RID: 4379 RVA: 0x00022FA8 File Offset: 0x000211A8
		// (set) Token: 0x0600111C RID: 4380 RVA: 0x00022FD4 File Offset: 0x000211D4
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

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x0600111D RID: 4381 RVA: 0x00022FE4 File Offset: 0x000211E4
		// (set) Token: 0x0600111E RID: 4382 RVA: 0x00023004 File Offset: 0x00021204
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

		// Token: 0x0600111F RID: 4383 RVA: 0x00023048 File Offset: 0x00021248
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x00023060 File Offset: 0x00021260
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06001121 RID: 4385 RVA: 0x0002306C File Offset: 0x0002126C
		[ProtoMember(2, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<bool> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06001122 RID: 4386 RVA: 0x00023084 File Offset: 0x00021284
		// (set) Token: 0x06001123 RID: 4387 RVA: 0x000230A5 File Offset: 0x000212A5
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06001124 RID: 4388 RVA: 0x000230B0 File Offset: 0x000212B0
		// (set) Token: 0x06001125 RID: 4389 RVA: 0x000230CC File Offset: 0x000212CC
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x000230FC File Offset: 0x000212FC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x00023114 File Offset: 0x00021314
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x00023120 File Offset: 0x00021320
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000447 RID: 1095
		private ErrorCode? _result;

		// Token: 0x04000448 RID: 1096
		private readonly List<bool> _dataList = new List<bool>();

		// Token: 0x04000449 RID: 1097
		private string _name;

		// Token: 0x0400044A RID: 1098
		private IExtension extensionObject;
	}
}
