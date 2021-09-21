using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000116 RID: 278
	[ProtoContract(Name = "ReachAchieveNtf")]
	[Serializable]
	public class ReachAchieveNtf : IExtensible
	{
		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06001177 RID: 4471 RVA: 0x00023A24 File Offset: 0x00021C24
		// (set) Token: 0x06001178 RID: 4472 RVA: 0x00023A50 File Offset: 0x00021C50
		[ProtoMember(1, IsRequired = false, Name = "achieveID", DataFormat = DataFormat.TwosComplement)]
		public uint achieveID
		{
			get
			{
				return this._achieveID ?? 0U;
			}
			set
			{
				this._achieveID = new uint?(value);
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06001179 RID: 4473 RVA: 0x00023A60 File Offset: 0x00021C60
		// (set) Token: 0x0600117A RID: 4474 RVA: 0x00023A80 File Offset: 0x00021C80
		[XmlIgnore]
		[Browsable(false)]
		public bool achieveIDSpecified
		{
			get
			{
				return this._achieveID != null;
			}
			set
			{
				bool flag = value == (this._achieveID == null);
				if (flag)
				{
					this._achieveID = (value ? new uint?(this.achieveID) : null);
				}
			}
		}

		// Token: 0x0600117B RID: 4475 RVA: 0x00023AC4 File Offset: 0x00021CC4
		private bool ShouldSerializeachieveID()
		{
			return this.achieveIDSpecified;
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x00023ADC File Offset: 0x00021CDC
		private void ResetachieveID()
		{
			this.achieveIDSpecified = false;
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x00023AE8 File Offset: 0x00021CE8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400045F RID: 1119
		private uint? _achieveID;

		// Token: 0x04000460 RID: 1120
		private IExtension extensionObject;
	}
}
