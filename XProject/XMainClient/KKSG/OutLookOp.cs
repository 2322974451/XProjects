using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000575 RID: 1397
	[ProtoContract(Name = "OutLookOp")]
	[Serializable]
	public class OutLookOp : IExtensible
	{
		// Token: 0x17001615 RID: 5653
		// (get) Token: 0x0600480E RID: 18446 RVA: 0x00088DF0 File Offset: 0x00086FF0
		// (set) Token: 0x0600480F RID: 18447 RVA: 0x00088E1C File Offset: 0x0008701C
		[ProtoMember(1, IsRequired = false, Name = "weapon", DataFormat = DataFormat.TwosComplement)]
		public OutLookType weapon
		{
			get
			{
				return this._weapon ?? OutLookType.OutLook_Fashion;
			}
			set
			{
				this._weapon = new OutLookType?(value);
			}
		}

		// Token: 0x17001616 RID: 5654
		// (get) Token: 0x06004810 RID: 18448 RVA: 0x00088E2C File Offset: 0x0008702C
		// (set) Token: 0x06004811 RID: 18449 RVA: 0x00088E4C File Offset: 0x0008704C
		[XmlIgnore]
		[Browsable(false)]
		public bool weaponSpecified
		{
			get
			{
				return this._weapon != null;
			}
			set
			{
				bool flag = value == (this._weapon == null);
				if (flag)
				{
					this._weapon = (value ? new OutLookType?(this.weapon) : null);
				}
			}
		}

		// Token: 0x06004812 RID: 18450 RVA: 0x00088E90 File Offset: 0x00087090
		private bool ShouldSerializeweapon()
		{
			return this.weaponSpecified;
		}

		// Token: 0x06004813 RID: 18451 RVA: 0x00088EA8 File Offset: 0x000870A8
		private void Resetweapon()
		{
			this.weaponSpecified = false;
		}

		// Token: 0x17001617 RID: 5655
		// (get) Token: 0x06004814 RID: 18452 RVA: 0x00088EB4 File Offset: 0x000870B4
		// (set) Token: 0x06004815 RID: 18453 RVA: 0x00088EE0 File Offset: 0x000870E0
		[ProtoMember(2, IsRequired = false, Name = "clothes", DataFormat = DataFormat.TwosComplement)]
		public OutLookType clothes
		{
			get
			{
				return this._clothes ?? OutLookType.OutLook_Fashion;
			}
			set
			{
				this._clothes = new OutLookType?(value);
			}
		}

		// Token: 0x17001618 RID: 5656
		// (get) Token: 0x06004816 RID: 18454 RVA: 0x00088EF0 File Offset: 0x000870F0
		// (set) Token: 0x06004817 RID: 18455 RVA: 0x00088F10 File Offset: 0x00087110
		[XmlIgnore]
		[Browsable(false)]
		public bool clothesSpecified
		{
			get
			{
				return this._clothes != null;
			}
			set
			{
				bool flag = value == (this._clothes == null);
				if (flag)
				{
					this._clothes = (value ? new OutLookType?(this.clothes) : null);
				}
			}
		}

		// Token: 0x06004818 RID: 18456 RVA: 0x00088F54 File Offset: 0x00087154
		private bool ShouldSerializeclothes()
		{
			return this.clothesSpecified;
		}

		// Token: 0x06004819 RID: 18457 RVA: 0x00088F6C File Offset: 0x0008716C
		private void Resetclothes()
		{
			this.clothesSpecified = false;
		}

		// Token: 0x0600481A RID: 18458 RVA: 0x00088F78 File Offset: 0x00087178
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001205 RID: 4613
		private OutLookType? _weapon;

		// Token: 0x04001206 RID: 4614
		private OutLookType? _clothes;

		// Token: 0x04001207 RID: 4615
		private IExtension extensionObject;
	}
}
