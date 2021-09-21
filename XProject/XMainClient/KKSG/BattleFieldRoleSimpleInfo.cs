using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000736 RID: 1846
	[ProtoContract(Name = "BattleFieldRoleSimpleInfo")]
	[Serializable]
	public class BattleFieldRoleSimpleInfo : IExtensible
	{
		// Token: 0x17002882 RID: 10370
		// (get) Token: 0x06007FC5 RID: 32709 RVA: 0x000F455C File Offset: 0x000F275C
		// (set) Token: 0x06007FC6 RID: 32710 RVA: 0x000F4589 File Offset: 0x000F2789
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17002883 RID: 10371
		// (get) Token: 0x06007FC7 RID: 32711 RVA: 0x000F4598 File Offset: 0x000F2798
		// (set) Token: 0x06007FC8 RID: 32712 RVA: 0x000F45B8 File Offset: 0x000F27B8
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06007FC9 RID: 32713 RVA: 0x000F45FC File Offset: 0x000F27FC
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007FCA RID: 32714 RVA: 0x000F4614 File Offset: 0x000F2814
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17002884 RID: 10372
		// (get) Token: 0x06007FCB RID: 32715 RVA: 0x000F4620 File Offset: 0x000F2820
		// (set) Token: 0x06007FCC RID: 32716 RVA: 0x000F4641 File Offset: 0x000F2841
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002885 RID: 10373
		// (get) Token: 0x06007FCD RID: 32717 RVA: 0x000F464C File Offset: 0x000F284C
		// (set) Token: 0x06007FCE RID: 32718 RVA: 0x000F4668 File Offset: 0x000F2868
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

		// Token: 0x06007FCF RID: 32719 RVA: 0x000F4698 File Offset: 0x000F2898
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007FD0 RID: 32720 RVA: 0x000F46B0 File Offset: 0x000F28B0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06007FD1 RID: 32721 RVA: 0x000F46BC File Offset: 0x000F28BC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DF7 RID: 7671
		private ulong? _roleid;

		// Token: 0x04001DF8 RID: 7672
		private string _name;

		// Token: 0x04001DF9 RID: 7673
		private IExtension extensionObject;
	}
}
