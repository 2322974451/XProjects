using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000132 RID: 306
	[ProtoContract(Name = "ThanksForBonusArg")]
	[Serializable]
	public class ThanksForBonusArg : IExtensible
	{
		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x060012CC RID: 4812 RVA: 0x000261B0 File Offset: 0x000243B0
		// (set) Token: 0x060012CD RID: 4813 RVA: 0x000261DC File Offset: 0x000243DC
		[ProtoMember(1, IsRequired = false, Name = "bonusID", DataFormat = DataFormat.TwosComplement)]
		public uint bonusID
		{
			get
			{
				return this._bonusID ?? 0U;
			}
			set
			{
				this._bonusID = new uint?(value);
			}
		}

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x060012CE RID: 4814 RVA: 0x000261EC File Offset: 0x000243EC
		// (set) Token: 0x060012CF RID: 4815 RVA: 0x0002620C File Offset: 0x0002440C
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusIDSpecified
		{
			get
			{
				return this._bonusID != null;
			}
			set
			{
				bool flag = value == (this._bonusID == null);
				if (flag)
				{
					this._bonusID = (value ? new uint?(this.bonusID) : null);
				}
			}
		}

		// Token: 0x060012D0 RID: 4816 RVA: 0x00026250 File Offset: 0x00024450
		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		// Token: 0x060012D1 RID: 4817 RVA: 0x00026268 File Offset: 0x00024468
		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		// Token: 0x060012D2 RID: 4818 RVA: 0x00026274 File Offset: 0x00024474
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004B1 RID: 1201
		private uint? _bonusID;

		// Token: 0x040004B2 RID: 1202
		private IExtension extensionObject;
	}
}
