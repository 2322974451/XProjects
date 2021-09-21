using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000218 RID: 536
	[ProtoContract(Name = "NotifyEnhanceSuit")]
	[Serializable]
	public class NotifyEnhanceSuit : IExtensible
	{
		// Token: 0x17000965 RID: 2405
		// (get) Token: 0x06001E0B RID: 7691 RVA: 0x0003B098 File Offset: 0x00039298
		// (set) Token: 0x06001E0C RID: 7692 RVA: 0x0003B0C4 File Offset: 0x000392C4
		[ProtoMember(1, IsRequired = false, Name = "enhanceSuit", DataFormat = DataFormat.TwosComplement)]
		public uint enhanceSuit
		{
			get
			{
				return this._enhanceSuit ?? 0U;
			}
			set
			{
				this._enhanceSuit = new uint?(value);
			}
		}

		// Token: 0x17000966 RID: 2406
		// (get) Token: 0x06001E0D RID: 7693 RVA: 0x0003B0D4 File Offset: 0x000392D4
		// (set) Token: 0x06001E0E RID: 7694 RVA: 0x0003B0F4 File Offset: 0x000392F4
		[XmlIgnore]
		[Browsable(false)]
		public bool enhanceSuitSpecified
		{
			get
			{
				return this._enhanceSuit != null;
			}
			set
			{
				bool flag = value == (this._enhanceSuit == null);
				if (flag)
				{
					this._enhanceSuit = (value ? new uint?(this.enhanceSuit) : null);
				}
			}
		}

		// Token: 0x06001E0F RID: 7695 RVA: 0x0003B138 File Offset: 0x00039338
		private bool ShouldSerializeenhanceSuit()
		{
			return this.enhanceSuitSpecified;
		}

		// Token: 0x06001E10 RID: 7696 RVA: 0x0003B150 File Offset: 0x00039350
		private void ResetenhanceSuit()
		{
			this.enhanceSuitSpecified = false;
		}

		// Token: 0x06001E11 RID: 7697 RVA: 0x0003B15C File Offset: 0x0003935C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000783 RID: 1923
		private uint? _enhanceSuit;

		// Token: 0x04000784 RID: 1924
		private IExtension extensionObject;
	}
}
