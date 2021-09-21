using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200027D RID: 637
	[ProtoContract(Name = "BanquetAwardArg")]
	[Serializable]
	public class BanquetAwardArg : IExtensible
	{
		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x0600236D RID: 9069 RVA: 0x00045294 File Offset: 0x00043494
		// (set) Token: 0x0600236E RID: 9070 RVA: 0x000452C0 File Offset: 0x000434C0
		[ProtoMember(1, IsRequired = false, Name = "Banquet_id", DataFormat = DataFormat.TwosComplement)]
		public uint Banquet_id
		{
			get
			{
				return this._Banquet_id ?? 0U;
			}
			set
			{
				this._Banquet_id = new uint?(value);
			}
		}

		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x0600236F RID: 9071 RVA: 0x000452D0 File Offset: 0x000434D0
		// (set) Token: 0x06002370 RID: 9072 RVA: 0x000452F0 File Offset: 0x000434F0
		[XmlIgnore]
		[Browsable(false)]
		public bool Banquet_idSpecified
		{
			get
			{
				return this._Banquet_id != null;
			}
			set
			{
				bool flag = value == (this._Banquet_id == null);
				if (flag)
				{
					this._Banquet_id = (value ? new uint?(this.Banquet_id) : null);
				}
			}
		}

		// Token: 0x06002371 RID: 9073 RVA: 0x00045334 File Offset: 0x00043534
		private bool ShouldSerializeBanquet_id()
		{
			return this.Banquet_idSpecified;
		}

		// Token: 0x06002372 RID: 9074 RVA: 0x0004534C File Offset: 0x0004354C
		private void ResetBanquet_id()
		{
			this.Banquet_idSpecified = false;
		}

		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x06002373 RID: 9075 RVA: 0x00045358 File Offset: 0x00043558
		// (set) Token: 0x06002374 RID: 9076 RVA: 0x00045385 File Offset: 0x00043585
		[ProtoMember(2, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
		public ulong garden_id
		{
			get
			{
				return this._garden_id ?? 0UL;
			}
			set
			{
				this._garden_id = new ulong?(value);
			}
		}

		// Token: 0x17000B07 RID: 2823
		// (get) Token: 0x06002375 RID: 9077 RVA: 0x00045394 File Offset: 0x00043594
		// (set) Token: 0x06002376 RID: 9078 RVA: 0x000453B4 File Offset: 0x000435B4
		[XmlIgnore]
		[Browsable(false)]
		public bool garden_idSpecified
		{
			get
			{
				return this._garden_id != null;
			}
			set
			{
				bool flag = value == (this._garden_id == null);
				if (flag)
				{
					this._garden_id = (value ? new ulong?(this.garden_id) : null);
				}
			}
		}

		// Token: 0x06002377 RID: 9079 RVA: 0x000453F8 File Offset: 0x000435F8
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x06002378 RID: 9080 RVA: 0x00045410 File Offset: 0x00043610
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x06002379 RID: 9081 RVA: 0x0004541C File Offset: 0x0004361C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008CA RID: 2250
		private uint? _Banquet_id;

		// Token: 0x040008CB RID: 2251
		private ulong? _garden_id;

		// Token: 0x040008CC RID: 2252
		private IExtension extensionObject;
	}
}
