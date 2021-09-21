using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000295 RID: 661
	[ProtoContract(Name = "GardenBanquetNtf")]
	[Serializable]
	public class GardenBanquetNtf : IExtensible
	{
		// Token: 0x17000B7C RID: 2940
		// (get) Token: 0x060024F4 RID: 9460 RVA: 0x00048078 File Offset: 0x00046278
		// (set) Token: 0x060024F5 RID: 9461 RVA: 0x000480A5 File Offset: 0x000462A5
		[ProtoMember(1, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000B7D RID: 2941
		// (get) Token: 0x060024F6 RID: 9462 RVA: 0x000480B4 File Offset: 0x000462B4
		// (set) Token: 0x060024F7 RID: 9463 RVA: 0x000480D4 File Offset: 0x000462D4
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

		// Token: 0x060024F8 RID: 9464 RVA: 0x00048118 File Offset: 0x00046318
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x00048130 File Offset: 0x00046330
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000B7E RID: 2942
		// (get) Token: 0x060024FA RID: 9466 RVA: 0x0004813C File Offset: 0x0004633C
		// (set) Token: 0x060024FB RID: 9467 RVA: 0x00048168 File Offset: 0x00046368
		[ProtoMember(2, IsRequired = false, Name = "banquet_id", DataFormat = DataFormat.TwosComplement)]
		public uint banquet_id
		{
			get
			{
				return this._banquet_id ?? 0U;
			}
			set
			{
				this._banquet_id = new uint?(value);
			}
		}

		// Token: 0x17000B7F RID: 2943
		// (get) Token: 0x060024FC RID: 9468 RVA: 0x00048178 File Offset: 0x00046378
		// (set) Token: 0x060024FD RID: 9469 RVA: 0x00048198 File Offset: 0x00046398
		[XmlIgnore]
		[Browsable(false)]
		public bool banquet_idSpecified
		{
			get
			{
				return this._banquet_id != null;
			}
			set
			{
				bool flag = value == (this._banquet_id == null);
				if (flag)
				{
					this._banquet_id = (value ? new uint?(this.banquet_id) : null);
				}
			}
		}

		// Token: 0x060024FE RID: 9470 RVA: 0x000481DC File Offset: 0x000463DC
		private bool ShouldSerializebanquet_id()
		{
			return this.banquet_idSpecified;
		}

		// Token: 0x060024FF RID: 9471 RVA: 0x000481F4 File Offset: 0x000463F4
		private void Resetbanquet_id()
		{
			this.banquet_idSpecified = false;
		}

		// Token: 0x17000B80 RID: 2944
		// (get) Token: 0x06002500 RID: 9472 RVA: 0x00048200 File Offset: 0x00046400
		// (set) Token: 0x06002501 RID: 9473 RVA: 0x0004822C File Offset: 0x0004642C
		[ProtoMember(3, IsRequired = false, Name = "banquet_stage", DataFormat = DataFormat.TwosComplement)]
		public uint banquet_stage
		{
			get
			{
				return this._banquet_stage ?? 0U;
			}
			set
			{
				this._banquet_stage = new uint?(value);
			}
		}

		// Token: 0x17000B81 RID: 2945
		// (get) Token: 0x06002502 RID: 9474 RVA: 0x0004823C File Offset: 0x0004643C
		// (set) Token: 0x06002503 RID: 9475 RVA: 0x0004825C File Offset: 0x0004645C
		[XmlIgnore]
		[Browsable(false)]
		public bool banquet_stageSpecified
		{
			get
			{
				return this._banquet_stage != null;
			}
			set
			{
				bool flag = value == (this._banquet_stage == null);
				if (flag)
				{
					this._banquet_stage = (value ? new uint?(this.banquet_stage) : null);
				}
			}
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x000482A0 File Offset: 0x000464A0
		private bool ShouldSerializebanquet_stage()
		{
			return this.banquet_stageSpecified;
		}

		// Token: 0x06002505 RID: 9477 RVA: 0x000482B8 File Offset: 0x000464B8
		private void Resetbanquet_stage()
		{
			this.banquet_stageSpecified = false;
		}

		// Token: 0x17000B82 RID: 2946
		// (get) Token: 0x06002506 RID: 9478 RVA: 0x000482C4 File Offset: 0x000464C4
		// (set) Token: 0x06002507 RID: 9479 RVA: 0x000482F0 File Offset: 0x000464F0
		[ProtoMember(4, IsRequired = false, Name = "timesTSWK", DataFormat = DataFormat.TwosComplement)]
		public uint timesTSWK
		{
			get
			{
				return this._timesTSWK ?? 0U;
			}
			set
			{
				this._timesTSWK = new uint?(value);
			}
		}

		// Token: 0x17000B83 RID: 2947
		// (get) Token: 0x06002508 RID: 9480 RVA: 0x00048300 File Offset: 0x00046500
		// (set) Token: 0x06002509 RID: 9481 RVA: 0x00048320 File Offset: 0x00046520
		[XmlIgnore]
		[Browsable(false)]
		public bool timesTSWKSpecified
		{
			get
			{
				return this._timesTSWK != null;
			}
			set
			{
				bool flag = value == (this._timesTSWK == null);
				if (flag)
				{
					this._timesTSWK = (value ? new uint?(this.timesTSWK) : null);
				}
			}
		}

		// Token: 0x0600250A RID: 9482 RVA: 0x00048364 File Offset: 0x00046564
		private bool ShouldSerializetimesTSWK()
		{
			return this.timesTSWKSpecified;
		}

		// Token: 0x0600250B RID: 9483 RVA: 0x0004837C File Offset: 0x0004657C
		private void ResettimesTSWK()
		{
			this.timesTSWKSpecified = false;
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x00048388 File Offset: 0x00046588
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000923 RID: 2339
		private ulong? _garden_id;

		// Token: 0x04000924 RID: 2340
		private uint? _banquet_id;

		// Token: 0x04000925 RID: 2341
		private uint? _banquet_stage;

		// Token: 0x04000926 RID: 2342
		private uint? _timesTSWK;

		// Token: 0x04000927 RID: 2343
		private IExtension extensionObject;
	}
}
