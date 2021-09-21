using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000546 RID: 1350
	[ProtoContract(Name = "MarriageNewPrivilegeNtfData")]
	[Serializable]
	public class MarriageNewPrivilegeNtfData : IExtensible
	{
		// Token: 0x17001514 RID: 5396
		// (get) Token: 0x060044F8 RID: 17656 RVA: 0x00083224 File Offset: 0x00081424
		// (set) Token: 0x060044F9 RID: 17657 RVA: 0x00083250 File Offset: 0x00081450
		[ProtoMember(1, IsRequired = false, Name = "marriageLevel", DataFormat = DataFormat.TwosComplement)]
		public int marriageLevel
		{
			get
			{
				return this._marriageLevel ?? 0;
			}
			set
			{
				this._marriageLevel = new int?(value);
			}
		}

		// Token: 0x17001515 RID: 5397
		// (get) Token: 0x060044FA RID: 17658 RVA: 0x00083260 File Offset: 0x00081460
		// (set) Token: 0x060044FB RID: 17659 RVA: 0x00083280 File Offset: 0x00081480
		[XmlIgnore]
		[Browsable(false)]
		public bool marriageLevelSpecified
		{
			get
			{
				return this._marriageLevel != null;
			}
			set
			{
				bool flag = value == (this._marriageLevel == null);
				if (flag)
				{
					this._marriageLevel = (value ? new int?(this.marriageLevel) : null);
				}
			}
		}

		// Token: 0x060044FC RID: 17660 RVA: 0x000832C4 File Offset: 0x000814C4
		private bool ShouldSerializemarriageLevel()
		{
			return this.marriageLevelSpecified;
		}

		// Token: 0x060044FD RID: 17661 RVA: 0x000832DC File Offset: 0x000814DC
		private void ResetmarriageLevel()
		{
			this.marriageLevelSpecified = false;
		}

		// Token: 0x060044FE RID: 17662 RVA: 0x000832E8 File Offset: 0x000814E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400113E RID: 4414
		private int? _marriageLevel;

		// Token: 0x0400113F RID: 4415
		private IExtension extensionObject;
	}
}
