using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000629 RID: 1577
	[ProtoContract(Name = "PetSysData")]
	[Serializable]
	public class PetSysData : IExtensible
	{
		// Token: 0x17001E6E RID: 7790
		// (get) Token: 0x060060BE RID: 24766 RVA: 0x000B886C File Offset: 0x000B6A6C
		// (set) Token: 0x060060BF RID: 24767 RVA: 0x000B8899 File Offset: 0x000B6A99
		[ProtoMember(1, IsRequired = false, Name = "fightid", DataFormat = DataFormat.TwosComplement)]
		public ulong fightid
		{
			get
			{
				return this._fightid ?? 0UL;
			}
			set
			{
				this._fightid = new ulong?(value);
			}
		}

		// Token: 0x17001E6F RID: 7791
		// (get) Token: 0x060060C0 RID: 24768 RVA: 0x000B88A8 File Offset: 0x000B6AA8
		// (set) Token: 0x060060C1 RID: 24769 RVA: 0x000B88C8 File Offset: 0x000B6AC8
		[XmlIgnore]
		[Browsable(false)]
		public bool fightidSpecified
		{
			get
			{
				return this._fightid != null;
			}
			set
			{
				bool flag = value == (this._fightid == null);
				if (flag)
				{
					this._fightid = (value ? new ulong?(this.fightid) : null);
				}
			}
		}

		// Token: 0x060060C2 RID: 24770 RVA: 0x000B890C File Offset: 0x000B6B0C
		private bool ShouldSerializefightid()
		{
			return this.fightidSpecified;
		}

		// Token: 0x060060C3 RID: 24771 RVA: 0x000B8924 File Offset: 0x000B6B24
		private void Resetfightid()
		{
			this.fightidSpecified = false;
		}

		// Token: 0x17001E70 RID: 7792
		// (get) Token: 0x060060C4 RID: 24772 RVA: 0x000B8930 File Offset: 0x000B6B30
		// (set) Token: 0x060060C5 RID: 24773 RVA: 0x000B895D File Offset: 0x000B6B5D
		[ProtoMember(2, IsRequired = false, Name = "followid", DataFormat = DataFormat.TwosComplement)]
		public ulong followid
		{
			get
			{
				return this._followid ?? 0UL;
			}
			set
			{
				this._followid = new ulong?(value);
			}
		}

		// Token: 0x17001E71 RID: 7793
		// (get) Token: 0x060060C6 RID: 24774 RVA: 0x000B896C File Offset: 0x000B6B6C
		// (set) Token: 0x060060C7 RID: 24775 RVA: 0x000B898C File Offset: 0x000B6B8C
		[XmlIgnore]
		[Browsable(false)]
		public bool followidSpecified
		{
			get
			{
				return this._followid != null;
			}
			set
			{
				bool flag = value == (this._followid == null);
				if (flag)
				{
					this._followid = (value ? new ulong?(this.followid) : null);
				}
			}
		}

		// Token: 0x060060C8 RID: 24776 RVA: 0x000B89D0 File Offset: 0x000B6BD0
		private bool ShouldSerializefollowid()
		{
			return this.followidSpecified;
		}

		// Token: 0x060060C9 RID: 24777 RVA: 0x000B89E8 File Offset: 0x000B6BE8
		private void Resetfollowid()
		{
			this.followidSpecified = false;
		}

		// Token: 0x17001E72 RID: 7794
		// (get) Token: 0x060060CA RID: 24778 RVA: 0x000B89F4 File Offset: 0x000B6BF4
		// (set) Token: 0x060060CB RID: 24779 RVA: 0x000B8A20 File Offset: 0x000B6C20
		[ProtoMember(3, IsRequired = false, Name = "petseats", DataFormat = DataFormat.TwosComplement)]
		public uint petseats
		{
			get
			{
				return this._petseats ?? 0U;
			}
			set
			{
				this._petseats = new uint?(value);
			}
		}

		// Token: 0x17001E73 RID: 7795
		// (get) Token: 0x060060CC RID: 24780 RVA: 0x000B8A30 File Offset: 0x000B6C30
		// (set) Token: 0x060060CD RID: 24781 RVA: 0x000B8A50 File Offset: 0x000B6C50
		[XmlIgnore]
		[Browsable(false)]
		public bool petseatsSpecified
		{
			get
			{
				return this._petseats != null;
			}
			set
			{
				bool flag = value == (this._petseats == null);
				if (flag)
				{
					this._petseats = (value ? new uint?(this.petseats) : null);
				}
			}
		}

		// Token: 0x060060CE RID: 24782 RVA: 0x000B8A94 File Offset: 0x000B6C94
		private bool ShouldSerializepetseats()
		{
			return this.petseatsSpecified;
		}

		// Token: 0x060060CF RID: 24783 RVA: 0x000B8AAC File Offset: 0x000B6CAC
		private void Resetpetseats()
		{
			this.petseatsSpecified = false;
		}

		// Token: 0x17001E74 RID: 7796
		// (get) Token: 0x060060D0 RID: 24784 RVA: 0x000B8AB8 File Offset: 0x000B6CB8
		// (set) Token: 0x060060D1 RID: 24785 RVA: 0x000B8AE5 File Offset: 0x000B6CE5
		[ProtoMember(4, IsRequired = false, Name = "lastfollowid", DataFormat = DataFormat.TwosComplement)]
		public ulong lastfollowid
		{
			get
			{
				return this._lastfollowid ?? 0UL;
			}
			set
			{
				this._lastfollowid = new ulong?(value);
			}
		}

		// Token: 0x17001E75 RID: 7797
		// (get) Token: 0x060060D2 RID: 24786 RVA: 0x000B8AF4 File Offset: 0x000B6CF4
		// (set) Token: 0x060060D3 RID: 24787 RVA: 0x000B8B14 File Offset: 0x000B6D14
		[XmlIgnore]
		[Browsable(false)]
		public bool lastfollowidSpecified
		{
			get
			{
				return this._lastfollowid != null;
			}
			set
			{
				bool flag = value == (this._lastfollowid == null);
				if (flag)
				{
					this._lastfollowid = (value ? new ulong?(this.lastfollowid) : null);
				}
			}
		}

		// Token: 0x060060D4 RID: 24788 RVA: 0x000B8B58 File Offset: 0x000B6D58
		private bool ShouldSerializelastfollowid()
		{
			return this.lastfollowidSpecified;
		}

		// Token: 0x060060D5 RID: 24789 RVA: 0x000B8B70 File Offset: 0x000B6D70
		private void Resetlastfollowid()
		{
			this.lastfollowidSpecified = false;
		}

		// Token: 0x17001E76 RID: 7798
		// (get) Token: 0x060060D6 RID: 24790 RVA: 0x000B8B7C File Offset: 0x000B6D7C
		[ProtoMember(5, Name = "pets", DataFormat = DataFormat.Default)]
		public List<PetSingle> pets
		{
			get
			{
				return this._pets;
			}
		}

		// Token: 0x060060D7 RID: 24791 RVA: 0x000B8B94 File Offset: 0x000B6D94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001779 RID: 6009
		private ulong? _fightid;

		// Token: 0x0400177A RID: 6010
		private ulong? _followid;

		// Token: 0x0400177B RID: 6011
		private uint? _petseats;

		// Token: 0x0400177C RID: 6012
		private ulong? _lastfollowid;

		// Token: 0x0400177D RID: 6013
		private readonly List<PetSingle> _pets = new List<PetSingle>();

		// Token: 0x0400177E RID: 6014
		private IExtension extensionObject;
	}
}
