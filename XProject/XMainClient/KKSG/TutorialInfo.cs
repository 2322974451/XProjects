using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200001B RID: 27
	[ProtoContract(Name = "TutorialInfo")]
	[Serializable]
	public class TutorialInfo : IExtensible
	{
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600023D RID: 573 RVA: 0x0000700C File Offset: 0x0000520C
		// (set) Token: 0x0600023E RID: 574 RVA: 0x00007038 File Offset: 0x00005238
		[ProtoMember(1, IsRequired = false, Name = "tutorialID", DataFormat = DataFormat.TwosComplement)]
		public uint tutorialID
		{
			get
			{
				return this._tutorialID ?? 0U;
			}
			set
			{
				this._tutorialID = new uint?(value);
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00007048 File Offset: 0x00005248
		// (set) Token: 0x06000240 RID: 576 RVA: 0x00007068 File Offset: 0x00005268
		[XmlIgnore]
		[Browsable(false)]
		public bool tutorialIDSpecified
		{
			get
			{
				return this._tutorialID != null;
			}
			set
			{
				bool flag = value == (this._tutorialID == null);
				if (flag)
				{
					this._tutorialID = (value ? new uint?(this.tutorialID) : null);
				}
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x000070AC File Offset: 0x000052AC
		private bool ShouldSerializetutorialID()
		{
			return this.tutorialIDSpecified;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x000070C4 File Offset: 0x000052C4
		private void ResettutorialID()
		{
			this.tutorialIDSpecified = false;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x000070D0 File Offset: 0x000052D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000098 RID: 152
		private uint? _tutorialID;

		// Token: 0x04000099 RID: 153
		private IExtension extensionObject;
	}
}
