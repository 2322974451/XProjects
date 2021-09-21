using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001AE RID: 430
	[ProtoContract(Name = "NotifyEnemyEnterFight")]
	[Serializable]
	public class NotifyEnemyEnterFight : IExtensible
	{
		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x0600195E RID: 6494 RVA: 0x000325F0 File Offset: 0x000307F0
		// (set) Token: 0x0600195F RID: 6495 RVA: 0x0003261C File Offset: 0x0003081C
		[ProtoMember(1, IsRequired = false, Name = "enterfight", DataFormat = DataFormat.Default)]
		public bool enterfight
		{
			get
			{
				return this._enterfight ?? false;
			}
			set
			{
				this._enterfight = new bool?(value);
			}
		}

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x06001960 RID: 6496 RVA: 0x0003262C File Offset: 0x0003082C
		// (set) Token: 0x06001961 RID: 6497 RVA: 0x0003264C File Offset: 0x0003084C
		[XmlIgnore]
		[Browsable(false)]
		public bool enterfightSpecified
		{
			get
			{
				return this._enterfight != null;
			}
			set
			{
				bool flag = value == (this._enterfight == null);
				if (flag)
				{
					this._enterfight = (value ? new bool?(this.enterfight) : null);
				}
			}
		}

		// Token: 0x06001962 RID: 6498 RVA: 0x00032690 File Offset: 0x00030890
		private bool ShouldSerializeenterfight()
		{
			return this.enterfightSpecified;
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x000326A8 File Offset: 0x000308A8
		private void Resetenterfight()
		{
			this.enterfightSpecified = false;
		}

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06001964 RID: 6500 RVA: 0x000326B4 File Offset: 0x000308B4
		// (set) Token: 0x06001965 RID: 6501 RVA: 0x000326E1 File Offset: 0x000308E1
		[ProtoMember(2, IsRequired = false, Name = "enemyid", DataFormat = DataFormat.TwosComplement)]
		public ulong enemyid
		{
			get
			{
				return this._enemyid ?? 0UL;
			}
			set
			{
				this._enemyid = new ulong?(value);
			}
		}

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06001966 RID: 6502 RVA: 0x000326F0 File Offset: 0x000308F0
		// (set) Token: 0x06001967 RID: 6503 RVA: 0x00032710 File Offset: 0x00030910
		[XmlIgnore]
		[Browsable(false)]
		public bool enemyidSpecified
		{
			get
			{
				return this._enemyid != null;
			}
			set
			{
				bool flag = value == (this._enemyid == null);
				if (flag)
				{
					this._enemyid = (value ? new ulong?(this.enemyid) : null);
				}
			}
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x00032754 File Offset: 0x00030954
		private bool ShouldSerializeenemyid()
		{
			return this.enemyidSpecified;
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x0003276C File Offset: 0x0003096C
		private void Resetenemyid()
		{
			this.enemyidSpecified = false;
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x00032778 File Offset: 0x00030978
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400064E RID: 1614
		private bool? _enterfight;

		// Token: 0x0400064F RID: 1615
		private ulong? _enemyid;

		// Token: 0x04000650 RID: 1616
		private IExtension extensionObject;
	}
}
