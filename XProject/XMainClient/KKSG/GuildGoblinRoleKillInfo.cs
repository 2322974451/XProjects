using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005C4 RID: 1476
	[ProtoContract(Name = "GuildGoblinRoleKillInfo")]
	[Serializable]
	public class GuildGoblinRoleKillInfo : IExtensible
	{
		// Token: 0x170019A2 RID: 6562
		// (get) Token: 0x060052D8 RID: 21208 RVA: 0x0009D954 File Offset: 0x0009BB54
		// (set) Token: 0x060052D9 RID: 21209 RVA: 0x0009D981 File Offset: 0x0009BB81
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x170019A3 RID: 6563
		// (get) Token: 0x060052DA RID: 21210 RVA: 0x0009D990 File Offset: 0x0009BB90
		// (set) Token: 0x060052DB RID: 21211 RVA: 0x0009D9B0 File Offset: 0x0009BBB0
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x060052DC RID: 21212 RVA: 0x0009D9F4 File Offset: 0x0009BBF4
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x060052DD RID: 21213 RVA: 0x0009DA0C File Offset: 0x0009BC0C
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x170019A4 RID: 6564
		// (get) Token: 0x060052DE RID: 21214 RVA: 0x0009DA18 File Offset: 0x0009BC18
		// (set) Token: 0x060052DF RID: 21215 RVA: 0x0009DA39 File Offset: 0x0009BC39
		[ProtoMember(2, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
		public string roleName
		{
			get
			{
				return this._roleName ?? "";
			}
			set
			{
				this._roleName = value;
			}
		}

		// Token: 0x170019A5 RID: 6565
		// (get) Token: 0x060052E0 RID: 21216 RVA: 0x0009DA44 File Offset: 0x0009BC44
		// (set) Token: 0x060052E1 RID: 21217 RVA: 0x0009DA60 File Offset: 0x0009BC60
		[XmlIgnore]
		[Browsable(false)]
		public bool roleNameSpecified
		{
			get
			{
				return this._roleName != null;
			}
			set
			{
				bool flag = value == (this._roleName == null);
				if (flag)
				{
					this._roleName = (value ? this.roleName : null);
				}
			}
		}

		// Token: 0x060052E2 RID: 21218 RVA: 0x0009DA90 File Offset: 0x0009BC90
		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		// Token: 0x060052E3 RID: 21219 RVA: 0x0009DAA8 File Offset: 0x0009BCA8
		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		// Token: 0x170019A6 RID: 6566
		// (get) Token: 0x060052E4 RID: 21220 RVA: 0x0009DAB4 File Offset: 0x0009BCB4
		// (set) Token: 0x060052E5 RID: 21221 RVA: 0x0009DAE0 File Offset: 0x0009BCE0
		[ProtoMember(3, IsRequired = false, Name = "killNum", DataFormat = DataFormat.TwosComplement)]
		public int killNum
		{
			get
			{
				return this._killNum ?? 0;
			}
			set
			{
				this._killNum = new int?(value);
			}
		}

		// Token: 0x170019A7 RID: 6567
		// (get) Token: 0x060052E6 RID: 21222 RVA: 0x0009DAF0 File Offset: 0x0009BCF0
		// (set) Token: 0x060052E7 RID: 21223 RVA: 0x0009DB10 File Offset: 0x0009BD10
		[XmlIgnore]
		[Browsable(false)]
		public bool killNumSpecified
		{
			get
			{
				return this._killNum != null;
			}
			set
			{
				bool flag = value == (this._killNum == null);
				if (flag)
				{
					this._killNum = (value ? new int?(this.killNum) : null);
				}
			}
		}

		// Token: 0x060052E8 RID: 21224 RVA: 0x0009DB54 File Offset: 0x0009BD54
		private bool ShouldSerializekillNum()
		{
			return this.killNumSpecified;
		}

		// Token: 0x060052E9 RID: 21225 RVA: 0x0009DB6C File Offset: 0x0009BD6C
		private void ResetkillNum()
		{
			this.killNumSpecified = false;
		}

		// Token: 0x170019A8 RID: 6568
		// (get) Token: 0x060052EA RID: 21226 RVA: 0x0009DB78 File Offset: 0x0009BD78
		// (set) Token: 0x060052EB RID: 21227 RVA: 0x0009DBA4 File Offset: 0x0009BDA4
		[ProtoMember(4, IsRequired = false, Name = "ability", DataFormat = DataFormat.TwosComplement)]
		public int ability
		{
			get
			{
				return this._ability ?? 0;
			}
			set
			{
				this._ability = new int?(value);
			}
		}

		// Token: 0x170019A9 RID: 6569
		// (get) Token: 0x060052EC RID: 21228 RVA: 0x0009DBB4 File Offset: 0x0009BDB4
		// (set) Token: 0x060052ED RID: 21229 RVA: 0x0009DBD4 File Offset: 0x0009BDD4
		[XmlIgnore]
		[Browsable(false)]
		public bool abilitySpecified
		{
			get
			{
				return this._ability != null;
			}
			set
			{
				bool flag = value == (this._ability == null);
				if (flag)
				{
					this._ability = (value ? new int?(this.ability) : null);
				}
			}
		}

		// Token: 0x060052EE RID: 21230 RVA: 0x0009DC18 File Offset: 0x0009BE18
		private bool ShouldSerializeability()
		{
			return this.abilitySpecified;
		}

		// Token: 0x060052EF RID: 21231 RVA: 0x0009DC30 File Offset: 0x0009BE30
		private void Resetability()
		{
			this.abilitySpecified = false;
		}

		// Token: 0x170019AA RID: 6570
		// (get) Token: 0x060052F0 RID: 21232 RVA: 0x0009DC3C File Offset: 0x0009BE3C
		// (set) Token: 0x060052F1 RID: 21233 RVA: 0x0009DC68 File Offset: 0x0009BE68
		[ProtoMember(5, IsRequired = false, Name = "roleLevel", DataFormat = DataFormat.TwosComplement)]
		public int roleLevel
		{
			get
			{
				return this._roleLevel ?? 0;
			}
			set
			{
				this._roleLevel = new int?(value);
			}
		}

		// Token: 0x170019AB RID: 6571
		// (get) Token: 0x060052F2 RID: 21234 RVA: 0x0009DC78 File Offset: 0x0009BE78
		// (set) Token: 0x060052F3 RID: 21235 RVA: 0x0009DC98 File Offset: 0x0009BE98
		[XmlIgnore]
		[Browsable(false)]
		public bool roleLevelSpecified
		{
			get
			{
				return this._roleLevel != null;
			}
			set
			{
				bool flag = value == (this._roleLevel == null);
				if (flag)
				{
					this._roleLevel = (value ? new int?(this.roleLevel) : null);
				}
			}
		}

		// Token: 0x060052F4 RID: 21236 RVA: 0x0009DCDC File Offset: 0x0009BEDC
		private bool ShouldSerializeroleLevel()
		{
			return this.roleLevelSpecified;
		}

		// Token: 0x060052F5 RID: 21237 RVA: 0x0009DCF4 File Offset: 0x0009BEF4
		private void ResetroleLevel()
		{
			this.roleLevelSpecified = false;
		}

		// Token: 0x060052F6 RID: 21238 RVA: 0x0009DD00 File Offset: 0x0009BF00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001442 RID: 5186
		private ulong? _roleID;

		// Token: 0x04001443 RID: 5187
		private string _roleName;

		// Token: 0x04001444 RID: 5188
		private int? _killNum;

		// Token: 0x04001445 RID: 5189
		private int? _ability;

		// Token: 0x04001446 RID: 5190
		private int? _roleLevel;

		// Token: 0x04001447 RID: 5191
		private IExtension extensionObject;
	}
}
