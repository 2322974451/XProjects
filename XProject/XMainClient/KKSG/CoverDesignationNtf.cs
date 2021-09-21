using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000111 RID: 273
	[ProtoContract(Name = "CoverDesignationNtf")]
	[Serializable]
	public class CoverDesignationNtf : IExtensible
	{
		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x0600113B RID: 4411 RVA: 0x00023334 File Offset: 0x00021534
		// (set) Token: 0x0600113C RID: 4412 RVA: 0x00023360 File Offset: 0x00021560
		[ProtoMember(1, IsRequired = false, Name = "designationID", DataFormat = DataFormat.TwosComplement)]
		public uint designationID
		{
			get
			{
				return this._designationID ?? 0U;
			}
			set
			{
				this._designationID = new uint?(value);
			}
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x0600113D RID: 4413 RVA: 0x00023370 File Offset: 0x00021570
		// (set) Token: 0x0600113E RID: 4414 RVA: 0x00023390 File Offset: 0x00021590
		[XmlIgnore]
		[Browsable(false)]
		public bool designationIDSpecified
		{
			get
			{
				return this._designationID != null;
			}
			set
			{
				bool flag = value == (this._designationID == null);
				if (flag)
				{
					this._designationID = (value ? new uint?(this.designationID) : null);
				}
			}
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x000233D4 File Offset: 0x000215D4
		private bool ShouldSerializedesignationID()
		{
			return this.designationIDSpecified;
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x000233EC File Offset: 0x000215EC
		private void ResetdesignationID()
		{
			this.designationIDSpecified = false;
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06001141 RID: 4417 RVA: 0x000233F8 File Offset: 0x000215F8
		// (set) Token: 0x06001142 RID: 4418 RVA: 0x00023419 File Offset: 0x00021619
		[ProtoMember(2, IsRequired = false, Name = "desname", DataFormat = DataFormat.Default)]
		public string desname
		{
			get
			{
				return this._desname ?? "";
			}
			set
			{
				this._desname = value;
			}
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06001143 RID: 4419 RVA: 0x00023424 File Offset: 0x00021624
		// (set) Token: 0x06001144 RID: 4420 RVA: 0x00023440 File Offset: 0x00021640
		[XmlIgnore]
		[Browsable(false)]
		public bool desnameSpecified
		{
			get
			{
				return this._desname != null;
			}
			set
			{
				bool flag = value == (this._desname == null);
				if (flag)
				{
					this._desname = (value ? this.desname : null);
				}
			}
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x00023470 File Offset: 0x00021670
		private bool ShouldSerializedesname()
		{
			return this.desnameSpecified;
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x00023488 File Offset: 0x00021688
		private void Resetdesname()
		{
			this.desnameSpecified = false;
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x00023494 File Offset: 0x00021694
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000450 RID: 1104
		private uint? _designationID;

		// Token: 0x04000451 RID: 1105
		private string _desname;

		// Token: 0x04000452 RID: 1106
		private IExtension extensionObject;
	}
}
