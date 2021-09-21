using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000BA RID: 186
	[ProtoContract(Name = "GetGuildBonusDetailInfoArg")]
	[Serializable]
	public class GetGuildBonusDetailInfoArg : IExtensible
	{
		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000C75 RID: 3189 RVA: 0x0001A44C File Offset: 0x0001864C
		// (set) Token: 0x06000C76 RID: 3190 RVA: 0x0001A478 File Offset: 0x00018678
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

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000C77 RID: 3191 RVA: 0x0001A488 File Offset: 0x00018688
		// (set) Token: 0x06000C78 RID: 3192 RVA: 0x0001A4A8 File Offset: 0x000186A8
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

		// Token: 0x06000C79 RID: 3193 RVA: 0x0001A4EC File Offset: 0x000186EC
		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x0001A504 File Offset: 0x00018704
		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x0001A510 File Offset: 0x00018710
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400031B RID: 795
		private uint? _bonusID;

		// Token: 0x0400031C RID: 796
		private IExtension extensionObject;
	}
}
