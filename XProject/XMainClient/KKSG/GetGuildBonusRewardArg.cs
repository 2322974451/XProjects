using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000BC RID: 188
	[ProtoContract(Name = "GetGuildBonusRewardArg")]
	[Serializable]
	public class GetGuildBonusRewardArg : IExtensible
	{
		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x0001AADC File Offset: 0x00018CDC
		// (set) Token: 0x06000CAD RID: 3245 RVA: 0x0001AB08 File Offset: 0x00018D08
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

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x0001AB18 File Offset: 0x00018D18
		// (set) Token: 0x06000CAF RID: 3247 RVA: 0x0001AB38 File Offset: 0x00018D38
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

		// Token: 0x06000CB0 RID: 3248 RVA: 0x0001AB7C File Offset: 0x00018D7C
		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x0001AB94 File Offset: 0x00018D94
		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0001ABA0 File Offset: 0x00018DA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000327 RID: 807
		private uint? _bonusID;

		// Token: 0x04000328 RID: 808
		private IExtension extensionObject;
	}
}
