using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000571 RID: 1393
	[ProtoContract(Name = "OutLookGuild")]
	[Serializable]
	public class OutLookGuild : IExtensible
	{
		// Token: 0x17001604 RID: 5636
		// (get) Token: 0x060047D9 RID: 18393 RVA: 0x000887F0 File Offset: 0x000869F0
		// (set) Token: 0x060047DA RID: 18394 RVA: 0x00088811 File Offset: 0x00086A11
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17001605 RID: 5637
		// (get) Token: 0x060047DB RID: 18395 RVA: 0x0008881C File Offset: 0x00086A1C
		// (set) Token: 0x060047DC RID: 18396 RVA: 0x00088838 File Offset: 0x00086A38
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x060047DD RID: 18397 RVA: 0x00088868 File Offset: 0x00086A68
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060047DE RID: 18398 RVA: 0x00088880 File Offset: 0x00086A80
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001606 RID: 5638
		// (get) Token: 0x060047DF RID: 18399 RVA: 0x0008888C File Offset: 0x00086A8C
		// (set) Token: 0x060047E0 RID: 18400 RVA: 0x000888B8 File Offset: 0x00086AB8
		[ProtoMember(2, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public uint icon
		{
			get
			{
				return this._icon ?? 0U;
			}
			set
			{
				this._icon = new uint?(value);
			}
		}

		// Token: 0x17001607 RID: 5639
		// (get) Token: 0x060047E1 RID: 18401 RVA: 0x000888C8 File Offset: 0x00086AC8
		// (set) Token: 0x060047E2 RID: 18402 RVA: 0x000888E8 File Offset: 0x00086AE8
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new uint?(this.icon) : null);
				}
			}
		}

		// Token: 0x060047E3 RID: 18403 RVA: 0x0008892C File Offset: 0x00086B2C
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x060047E4 RID: 18404 RVA: 0x00088944 File Offset: 0x00086B44
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x17001608 RID: 5640
		// (get) Token: 0x060047E5 RID: 18405 RVA: 0x00088950 File Offset: 0x00086B50
		// (set) Token: 0x060047E6 RID: 18406 RVA: 0x0008897D File Offset: 0x00086B7D
		[ProtoMember(3, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ulong id
		{
			get
			{
				return this._id ?? 0UL;
			}
			set
			{
				this._id = new ulong?(value);
			}
		}

		// Token: 0x17001609 RID: 5641
		// (get) Token: 0x060047E7 RID: 18407 RVA: 0x0008898C File Offset: 0x00086B8C
		// (set) Token: 0x060047E8 RID: 18408 RVA: 0x000889AC File Offset: 0x00086BAC
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ulong?(this.id) : null);
				}
			}
		}

		// Token: 0x060047E9 RID: 18409 RVA: 0x000889F0 File Offset: 0x00086BF0
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060047EA RID: 18410 RVA: 0x00088A08 File Offset: 0x00086C08
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x060047EB RID: 18411 RVA: 0x00088A14 File Offset: 0x00086C14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011F7 RID: 4599
		private string _name;

		// Token: 0x040011F8 RID: 4600
		private uint? _icon;

		// Token: 0x040011F9 RID: 4601
		private ulong? _id;

		// Token: 0x040011FA RID: 4602
		private IExtension extensionObject;
	}
}
