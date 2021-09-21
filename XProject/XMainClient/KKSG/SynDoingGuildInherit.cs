using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E1 RID: 737
	[ProtoContract(Name = "SynDoingGuildInherit")]
	[Serializable]
	public class SynDoingGuildInherit : IExtensible
	{
		// Token: 0x17000C97 RID: 3223
		// (get) Token: 0x06002886 RID: 10374 RVA: 0x0004EBA8 File Offset: 0x0004CDA8
		// (set) Token: 0x06002887 RID: 10375 RVA: 0x0004EBD5 File Offset: 0x0004CDD5
		[ProtoMember(1, IsRequired = false, Name = "roleOne", DataFormat = DataFormat.TwosComplement)]
		public ulong roleOne
		{
			get
			{
				return this._roleOne ?? 0UL;
			}
			set
			{
				this._roleOne = new ulong?(value);
			}
		}

		// Token: 0x17000C98 RID: 3224
		// (get) Token: 0x06002888 RID: 10376 RVA: 0x0004EBE4 File Offset: 0x0004CDE4
		// (set) Token: 0x06002889 RID: 10377 RVA: 0x0004EC04 File Offset: 0x0004CE04
		[XmlIgnore]
		[Browsable(false)]
		public bool roleOneSpecified
		{
			get
			{
				return this._roleOne != null;
			}
			set
			{
				bool flag = value == (this._roleOne == null);
				if (flag)
				{
					this._roleOne = (value ? new ulong?(this.roleOne) : null);
				}
			}
		}

		// Token: 0x0600288A RID: 10378 RVA: 0x0004EC48 File Offset: 0x0004CE48
		private bool ShouldSerializeroleOne()
		{
			return this.roleOneSpecified;
		}

		// Token: 0x0600288B RID: 10379 RVA: 0x0004EC60 File Offset: 0x0004CE60
		private void ResetroleOne()
		{
			this.roleOneSpecified = false;
		}

		// Token: 0x17000C99 RID: 3225
		// (get) Token: 0x0600288C RID: 10380 RVA: 0x0004EC6C File Offset: 0x0004CE6C
		// (set) Token: 0x0600288D RID: 10381 RVA: 0x0004EC99 File Offset: 0x0004CE99
		[ProtoMember(2, IsRequired = false, Name = "roleTwo", DataFormat = DataFormat.TwosComplement)]
		public ulong roleTwo
		{
			get
			{
				return this._roleTwo ?? 0UL;
			}
			set
			{
				this._roleTwo = new ulong?(value);
			}
		}

		// Token: 0x17000C9A RID: 3226
		// (get) Token: 0x0600288E RID: 10382 RVA: 0x0004ECA8 File Offset: 0x0004CEA8
		// (set) Token: 0x0600288F RID: 10383 RVA: 0x0004ECC8 File Offset: 0x0004CEC8
		[XmlIgnore]
		[Browsable(false)]
		public bool roleTwoSpecified
		{
			get
			{
				return this._roleTwo != null;
			}
			set
			{
				bool flag = value == (this._roleTwo == null);
				if (flag)
				{
					this._roleTwo = (value ? new ulong?(this.roleTwo) : null);
				}
			}
		}

		// Token: 0x06002890 RID: 10384 RVA: 0x0004ED0C File Offset: 0x0004CF0C
		private bool ShouldSerializeroleTwo()
		{
			return this.roleTwoSpecified;
		}

		// Token: 0x06002891 RID: 10385 RVA: 0x0004ED24 File Offset: 0x0004CF24
		private void ResetroleTwo()
		{
			this.roleTwoSpecified = false;
		}

		// Token: 0x17000C9B RID: 3227
		// (get) Token: 0x06002892 RID: 10386 RVA: 0x0004ED30 File Offset: 0x0004CF30
		// (set) Token: 0x06002893 RID: 10387 RVA: 0x0004ED5C File Offset: 0x0004CF5C
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000C9C RID: 3228
		// (get) Token: 0x06002894 RID: 10388 RVA: 0x0004ED6C File Offset: 0x0004CF6C
		// (set) Token: 0x06002895 RID: 10389 RVA: 0x0004ED8C File Offset: 0x0004CF8C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06002896 RID: 10390 RVA: 0x0004EDD0 File Offset: 0x0004CFD0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002897 RID: 10391 RVA: 0x0004EDE8 File Offset: 0x0004CFE8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06002898 RID: 10392 RVA: 0x0004EDF4 File Offset: 0x0004CFF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A15 RID: 2581
		private ulong? _roleOne;

		// Token: 0x04000A16 RID: 2582
		private ulong? _roleTwo;

		// Token: 0x04000A17 RID: 2583
		private uint? _type;

		// Token: 0x04000A18 RID: 2584
		private IExtension extensionObject;
	}
}
