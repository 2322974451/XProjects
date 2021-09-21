using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000FC RID: 252
	[ProtoContract(Name = "PetChangeNotfiy")]
	[Serializable]
	public class PetChangeNotfiy : IExtensible
	{
		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06001031 RID: 4145 RVA: 0x00021448 File Offset: 0x0001F648
		// (set) Token: 0x06001032 RID: 4146 RVA: 0x00021474 File Offset: 0x0001F674
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PetOP type
		{
			get
			{
				return this._type ?? PetOP.PetFellow;
			}
			set
			{
				this._type = new PetOP?(value);
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06001033 RID: 4147 RVA: 0x00021484 File Offset: 0x0001F684
		// (set) Token: 0x06001034 RID: 4148 RVA: 0x000214A4 File Offset: 0x0001F6A4
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
					this._type = (value ? new PetOP?(this.type) : null);
				}
			}
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x000214E8 File Offset: 0x0001F6E8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x00021500 File Offset: 0x0001F700
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06001037 RID: 4151 RVA: 0x0002150C File Offset: 0x0001F70C
		[ProtoMember(2, Name = "pet", DataFormat = DataFormat.Default)]
		public List<PetSingle> pet
		{
			get
			{
				return this._pet;
			}
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06001038 RID: 4152 RVA: 0x00021524 File Offset: 0x0001F724
		// (set) Token: 0x06001039 RID: 4153 RVA: 0x00021550 File Offset: 0x0001F750
		[ProtoMember(3, IsRequired = false, Name = "delexp", DataFormat = DataFormat.TwosComplement)]
		public uint delexp
		{
			get
			{
				return this._delexp ?? 0U;
			}
			set
			{
				this._delexp = new uint?(value);
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x0600103A RID: 4154 RVA: 0x00021560 File Offset: 0x0001F760
		// (set) Token: 0x0600103B RID: 4155 RVA: 0x00021580 File Offset: 0x0001F780
		[XmlIgnore]
		[Browsable(false)]
		public bool delexpSpecified
		{
			get
			{
				return this._delexp != null;
			}
			set
			{
				bool flag = value == (this._delexp == null);
				if (flag)
				{
					this._delexp = (value ? new uint?(this.delexp) : null);
				}
			}
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x000215C4 File Offset: 0x0001F7C4
		private bool ShouldSerializedelexp()
		{
			return this.delexpSpecified;
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x000215DC File Offset: 0x0001F7DC
		private void Resetdelexp()
		{
			this.delexpSpecified = false;
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x0600103E RID: 4158 RVA: 0x000215E8 File Offset: 0x0001F7E8
		[ProtoMember(4, Name = "getskills", DataFormat = DataFormat.Default)]
		public List<petGetSkill> getskills
		{
			get
			{
				return this._getskills;
			}
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x0600103F RID: 4159 RVA: 0x00021600 File Offset: 0x0001F800
		// (set) Token: 0x06001040 RID: 4160 RVA: 0x0002162C File Offset: 0x0001F82C
		[ProtoMember(5, IsRequired = false, Name = "delskillid", DataFormat = DataFormat.TwosComplement)]
		public uint delskillid
		{
			get
			{
				return this._delskillid ?? 0U;
			}
			set
			{
				this._delskillid = new uint?(value);
			}
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06001041 RID: 4161 RVA: 0x0002163C File Offset: 0x0001F83C
		// (set) Token: 0x06001042 RID: 4162 RVA: 0x0002165C File Offset: 0x0001F85C
		[XmlIgnore]
		[Browsable(false)]
		public bool delskillidSpecified
		{
			get
			{
				return this._delskillid != null;
			}
			set
			{
				bool flag = value == (this._delskillid == null);
				if (flag)
				{
					this._delskillid = (value ? new uint?(this.delskillid) : null);
				}
			}
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x000216A0 File Offset: 0x0001F8A0
		private bool ShouldSerializedelskillid()
		{
			return this.delskillidSpecified;
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x000216B8 File Offset: 0x0001F8B8
		private void Resetdelskillid()
		{
			this.delskillidSpecified = false;
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x000216C4 File Offset: 0x0001F8C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000409 RID: 1033
		private PetOP? _type;

		// Token: 0x0400040A RID: 1034
		private readonly List<PetSingle> _pet = new List<PetSingle>();

		// Token: 0x0400040B RID: 1035
		private uint? _delexp;

		// Token: 0x0400040C RID: 1036
		private readonly List<petGetSkill> _getskills = new List<petGetSkill>();

		// Token: 0x0400040D RID: 1037
		private uint? _delskillid;

		// Token: 0x0400040E RID: 1038
		private IExtension extensionObject;
	}
}
