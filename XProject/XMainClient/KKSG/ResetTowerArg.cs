using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000197 RID: 407
	[ProtoContract(Name = "ResetTowerArg")]
	[Serializable]
	public class ResetTowerArg : IExtensible
	{
		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x0600187A RID: 6266 RVA: 0x00030C38 File Offset: 0x0002EE38
		// (set) Token: 0x0600187B RID: 6267 RVA: 0x00030C64 File Offset: 0x0002EE64
		[ProtoMember(1, IsRequired = false, Name = "hardLevel", DataFormat = DataFormat.TwosComplement)]
		public int hardLevel
		{
			get
			{
				return this._hardLevel ?? 0;
			}
			set
			{
				this._hardLevel = new int?(value);
			}
		}

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x0600187C RID: 6268 RVA: 0x00030C74 File Offset: 0x0002EE74
		// (set) Token: 0x0600187D RID: 6269 RVA: 0x00030C94 File Offset: 0x0002EE94
		[XmlIgnore]
		[Browsable(false)]
		public bool hardLevelSpecified
		{
			get
			{
				return this._hardLevel != null;
			}
			set
			{
				bool flag = value == (this._hardLevel == null);
				if (flag)
				{
					this._hardLevel = (value ? new int?(this.hardLevel) : null);
				}
			}
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x00030CD8 File Offset: 0x0002EED8
		private bool ShouldSerializehardLevel()
		{
			return this.hardLevelSpecified;
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x00030CF0 File Offset: 0x0002EEF0
		private void ResethardLevel()
		{
			this.hardLevelSpecified = false;
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x00030CFC File Offset: 0x0002EEFC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400060C RID: 1548
		private int? _hardLevel;

		// Token: 0x0400060D RID: 1549
		private IExtension extensionObject;
	}
}
