using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200027C RID: 636
	[ProtoContract(Name = "BanquetNtfArg")]
	[Serializable]
	public class BanquetNtfArg : IExtensible
	{
		// Token: 0x17000B00 RID: 2816
		// (get) Token: 0x0600235F RID: 9055 RVA: 0x000450EC File Offset: 0x000432EC
		// (set) Token: 0x06002360 RID: 9056 RVA: 0x00045118 File Offset: 0x00043318
		[ProtoMember(1, IsRequired = false, Name = "banquet_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000B01 RID: 2817
		// (get) Token: 0x06002361 RID: 9057 RVA: 0x00045128 File Offset: 0x00043328
		// (set) Token: 0x06002362 RID: 9058 RVA: 0x00045148 File Offset: 0x00043348
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

		// Token: 0x06002363 RID: 9059 RVA: 0x0004518C File Offset: 0x0004338C
		private bool ShouldSerializebanquet_id()
		{
			return this.banquet_idSpecified;
		}

		// Token: 0x06002364 RID: 9060 RVA: 0x000451A4 File Offset: 0x000433A4
		private void Resetbanquet_id()
		{
			this.banquet_idSpecified = false;
		}

		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x06002365 RID: 9061 RVA: 0x000451B0 File Offset: 0x000433B0
		// (set) Token: 0x06002366 RID: 9062 RVA: 0x000451DD File Offset: 0x000433DD
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

		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x06002367 RID: 9063 RVA: 0x000451EC File Offset: 0x000433EC
		// (set) Token: 0x06002368 RID: 9064 RVA: 0x0004520C File Offset: 0x0004340C
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

		// Token: 0x06002369 RID: 9065 RVA: 0x00045250 File Offset: 0x00043450
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x0600236A RID: 9066 RVA: 0x00045268 File Offset: 0x00043468
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x0600236B RID: 9067 RVA: 0x00045274 File Offset: 0x00043474
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008C7 RID: 2247
		private uint? _banquet_id;

		// Token: 0x040008C8 RID: 2248
		private ulong? _garden_id;

		// Token: 0x040008C9 RID: 2249
		private IExtension extensionObject;
	}
}
