using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000667 RID: 1639
	[ProtoContract(Name = "SChatRecord")]
	[Serializable]
	public class SChatRecord : IExtensible
	{
		// Token: 0x170020AD RID: 8365
		// (get) Token: 0x0600676E RID: 26478 RVA: 0x000C59A4 File Offset: 0x000C3BA4
		// (set) Token: 0x0600676F RID: 26479 RVA: 0x000C59D0 File Offset: 0x000C3BD0
		[ProtoMember(1, IsRequired = false, Name = "lastupdatetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastupdatetime
		{
			get
			{
				return this._lastupdatetime ?? 0U;
			}
			set
			{
				this._lastupdatetime = new uint?(value);
			}
		}

		// Token: 0x170020AE RID: 8366
		// (get) Token: 0x06006770 RID: 26480 RVA: 0x000C59E0 File Offset: 0x000C3BE0
		// (set) Token: 0x06006771 RID: 26481 RVA: 0x000C5A00 File Offset: 0x000C3C00
		[XmlIgnore]
		[Browsable(false)]
		public bool lastupdatetimeSpecified
		{
			get
			{
				return this._lastupdatetime != null;
			}
			set
			{
				bool flag = value == (this._lastupdatetime == null);
				if (flag)
				{
					this._lastupdatetime = (value ? new uint?(this.lastupdatetime) : null);
				}
			}
		}

		// Token: 0x06006772 RID: 26482 RVA: 0x000C5A44 File Offset: 0x000C3C44
		private bool ShouldSerializelastupdatetime()
		{
			return this.lastupdatetimeSpecified;
		}

		// Token: 0x06006773 RID: 26483 RVA: 0x000C5A5C File Offset: 0x000C3C5C
		private void Resetlastupdatetime()
		{
			this.lastupdatetimeSpecified = false;
		}

		// Token: 0x170020AF RID: 8367
		// (get) Token: 0x06006774 RID: 26484 RVA: 0x000C5A68 File Offset: 0x000C3C68
		// (set) Token: 0x06006775 RID: 26485 RVA: 0x000C5A94 File Offset: 0x000C3C94
		[ProtoMember(2, IsRequired = false, Name = "worldchattimes", DataFormat = DataFormat.TwosComplement)]
		public uint worldchattimes
		{
			get
			{
				return this._worldchattimes ?? 0U;
			}
			set
			{
				this._worldchattimes = new uint?(value);
			}
		}

		// Token: 0x170020B0 RID: 8368
		// (get) Token: 0x06006776 RID: 26486 RVA: 0x000C5AA4 File Offset: 0x000C3CA4
		// (set) Token: 0x06006777 RID: 26487 RVA: 0x000C5AC4 File Offset: 0x000C3CC4
		[XmlIgnore]
		[Browsable(false)]
		public bool worldchattimesSpecified
		{
			get
			{
				return this._worldchattimes != null;
			}
			set
			{
				bool flag = value == (this._worldchattimes == null);
				if (flag)
				{
					this._worldchattimes = (value ? new uint?(this.worldchattimes) : null);
				}
			}
		}

		// Token: 0x06006778 RID: 26488 RVA: 0x000C5B08 File Offset: 0x000C3D08
		private bool ShouldSerializeworldchattimes()
		{
			return this.worldchattimesSpecified;
		}

		// Token: 0x06006779 RID: 26489 RVA: 0x000C5B20 File Offset: 0x000C3D20
		private void Resetworldchattimes()
		{
			this.worldchattimesSpecified = false;
		}

		// Token: 0x0600677A RID: 26490 RVA: 0x000C5B2C File Offset: 0x000C3D2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018FF RID: 6399
		private uint? _lastupdatetime;

		// Token: 0x04001900 RID: 6400
		private uint? _worldchattimes;

		// Token: 0x04001901 RID: 6401
		private IExtension extensionObject;
	}
}
