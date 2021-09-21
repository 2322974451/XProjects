using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000361 RID: 865
	[ProtoContract(Name = "GuildBonusGetAllData")]
	[Serializable]
	public class GuildBonusGetAllData : IExtensible
	{
		// Token: 0x17000EA5 RID: 3749
		// (get) Token: 0x06002F48 RID: 12104 RVA: 0x0005B458 File Offset: 0x00059658
		// (set) Token: 0x06002F49 RID: 12105 RVA: 0x0005B484 File Offset: 0x00059684
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

		// Token: 0x17000EA6 RID: 3750
		// (get) Token: 0x06002F4A RID: 12106 RVA: 0x0005B494 File Offset: 0x00059694
		// (set) Token: 0x06002F4B RID: 12107 RVA: 0x0005B4B4 File Offset: 0x000596B4
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

		// Token: 0x06002F4C RID: 12108 RVA: 0x0005B4F8 File Offset: 0x000596F8
		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		// Token: 0x06002F4D RID: 12109 RVA: 0x0005B510 File Offset: 0x00059710
		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		// Token: 0x06002F4E RID: 12110 RVA: 0x0005B51C File Offset: 0x0005971C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BB9 RID: 3001
		private uint? _bonusID;

		// Token: 0x04000BBA RID: 3002
		private IExtension extensionObject;
	}
}
