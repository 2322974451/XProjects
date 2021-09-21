using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200056D RID: 1389
	[ProtoContract(Name = "ItemFuse")]
	[Serializable]
	public class ItemFuse : IExtensible
	{
		// Token: 0x170015E3 RID: 5603
		// (get) Token: 0x0600477A RID: 18298 RVA: 0x00087D04 File Offset: 0x00085F04
		// (set) Token: 0x0600477B RID: 18299 RVA: 0x00087D30 File Offset: 0x00085F30
		[ProtoMember(1, IsRequired = false, Name = "fuseLevel", DataFormat = DataFormat.TwosComplement)]
		public uint fuseLevel
		{
			get
			{
				return this._fuseLevel ?? 0U;
			}
			set
			{
				this._fuseLevel = new uint?(value);
			}
		}

		// Token: 0x170015E4 RID: 5604
		// (get) Token: 0x0600477C RID: 18300 RVA: 0x00087D40 File Offset: 0x00085F40
		// (set) Token: 0x0600477D RID: 18301 RVA: 0x00087D60 File Offset: 0x00085F60
		[XmlIgnore]
		[Browsable(false)]
		public bool fuseLevelSpecified
		{
			get
			{
				return this._fuseLevel != null;
			}
			set
			{
				bool flag = value == (this._fuseLevel == null);
				if (flag)
				{
					this._fuseLevel = (value ? new uint?(this.fuseLevel) : null);
				}
			}
		}

		// Token: 0x0600477E RID: 18302 RVA: 0x00087DA4 File Offset: 0x00085FA4
		private bool ShouldSerializefuseLevel()
		{
			return this.fuseLevelSpecified;
		}

		// Token: 0x0600477F RID: 18303 RVA: 0x00087DBC File Offset: 0x00085FBC
		private void ResetfuseLevel()
		{
			this.fuseLevelSpecified = false;
		}

		// Token: 0x170015E5 RID: 5605
		// (get) Token: 0x06004780 RID: 18304 RVA: 0x00087DC8 File Offset: 0x00085FC8
		// (set) Token: 0x06004781 RID: 18305 RVA: 0x00087DF4 File Offset: 0x00085FF4
		[ProtoMember(2, IsRequired = false, Name = "fuseExpCount", DataFormat = DataFormat.TwosComplement)]
		public uint fuseExpCount
		{
			get
			{
				return this._fuseExpCount ?? 0U;
			}
			set
			{
				this._fuseExpCount = new uint?(value);
			}
		}

		// Token: 0x170015E6 RID: 5606
		// (get) Token: 0x06004782 RID: 18306 RVA: 0x00087E04 File Offset: 0x00086004
		// (set) Token: 0x06004783 RID: 18307 RVA: 0x00087E24 File Offset: 0x00086024
		[XmlIgnore]
		[Browsable(false)]
		public bool fuseExpCountSpecified
		{
			get
			{
				return this._fuseExpCount != null;
			}
			set
			{
				bool flag = value == (this._fuseExpCount == null);
				if (flag)
				{
					this._fuseExpCount = (value ? new uint?(this.fuseExpCount) : null);
				}
			}
		}

		// Token: 0x06004784 RID: 18308 RVA: 0x00087E68 File Offset: 0x00086068
		private bool ShouldSerializefuseExpCount()
		{
			return this.fuseExpCountSpecified;
		}

		// Token: 0x06004785 RID: 18309 RVA: 0x00087E80 File Offset: 0x00086080
		private void ResetfuseExpCount()
		{
			this.fuseExpCountSpecified = false;
		}

		// Token: 0x06004786 RID: 18310 RVA: 0x00087E8C File Offset: 0x0008608C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011DD RID: 4573
		private uint? _fuseLevel;

		// Token: 0x040011DE RID: 4574
		private uint? _fuseExpCount;

		// Token: 0x040011DF RID: 4575
		private IExtension extensionObject;
	}
}
