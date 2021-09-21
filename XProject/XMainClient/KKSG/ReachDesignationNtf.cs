using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200011B RID: 283
	[ProtoContract(Name = "ReachDesignationNtf")]
	[Serializable]
	public class ReachDesignationNtf : IExtensible
	{
		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x0600119F RID: 4511 RVA: 0x00023E98 File Offset: 0x00022098
		// (set) Token: 0x060011A0 RID: 4512 RVA: 0x00023EC4 File Offset: 0x000220C4
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

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x060011A1 RID: 4513 RVA: 0x00023ED4 File Offset: 0x000220D4
		// (set) Token: 0x060011A2 RID: 4514 RVA: 0x00023EF4 File Offset: 0x000220F4
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

		// Token: 0x060011A3 RID: 4515 RVA: 0x00023F38 File Offset: 0x00022138
		private bool ShouldSerializedesignationID()
		{
			return this.designationIDSpecified;
		}

		// Token: 0x060011A4 RID: 4516 RVA: 0x00023F50 File Offset: 0x00022150
		private void ResetdesignationID()
		{
			this.designationIDSpecified = false;
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x00023F5C File Offset: 0x0002215C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000469 RID: 1129
		private uint? _designationID;

		// Token: 0x0400046A RID: 1130
		private IExtension extensionObject;
	}
}
