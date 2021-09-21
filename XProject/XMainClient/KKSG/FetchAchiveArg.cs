using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200001E RID: 30
	[ProtoContract(Name = "FetchAchiveArg")]
	[Serializable]
	public class FetchAchiveArg : IExtensible
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00007308 File Offset: 0x00005508
		// (set) Token: 0x06000258 RID: 600 RVA: 0x00007334 File Offset: 0x00005534
		[ProtoMember(1, IsRequired = false, Name = "AchivementID", DataFormat = DataFormat.TwosComplement)]
		public uint AchivementID
		{
			get
			{
				return this._AchivementID ?? 0U;
			}
			set
			{
				this._AchivementID = new uint?(value);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00007344 File Offset: 0x00005544
		// (set) Token: 0x0600025A RID: 602 RVA: 0x00007364 File Offset: 0x00005564
		[XmlIgnore]
		[Browsable(false)]
		public bool AchivementIDSpecified
		{
			get
			{
				return this._AchivementID != null;
			}
			set
			{
				bool flag = value == (this._AchivementID == null);
				if (flag)
				{
					this._AchivementID = (value ? new uint?(this.AchivementID) : null);
				}
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000073A8 File Offset: 0x000055A8
		private bool ShouldSerializeAchivementID()
		{
			return this.AchivementIDSpecified;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000073C0 File Offset: 0x000055C0
		private void ResetAchivementID()
		{
			this.AchivementIDSpecified = false;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000073CC File Offset: 0x000055CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000A0 RID: 160
		private uint? _AchivementID;

		// Token: 0x040000A1 RID: 161
		private IExtension extensionObject;
	}
}
