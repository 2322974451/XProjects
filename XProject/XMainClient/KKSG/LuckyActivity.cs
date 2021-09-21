using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000660 RID: 1632
	[ProtoContract(Name = "LuckyActivity")]
	[Serializable]
	public class LuckyActivity : IExtensible
	{
		// Token: 0x1700207D RID: 8317
		// (get) Token: 0x060066E4 RID: 26340 RVA: 0x000C48C8 File Offset: 0x000C2AC8
		[ProtoMember(1, Name = "itemrecord", DataFormat = DataFormat.Default)]
		public List<ItemRecord> itemrecord
		{
			get
			{
				return this._itemrecord;
			}
		}

		// Token: 0x1700207E RID: 8318
		// (get) Token: 0x060066E5 RID: 26341 RVA: 0x000C48E0 File Offset: 0x000C2AE0
		// (set) Token: 0x060066E6 RID: 26342 RVA: 0x000C490C File Offset: 0x000C2B0C
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x1700207F RID: 8319
		// (get) Token: 0x060066E7 RID: 26343 RVA: 0x000C491C File Offset: 0x000C2B1C
		// (set) Token: 0x060066E8 RID: 26344 RVA: 0x000C493C File Offset: 0x000C2B3C
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x060066E9 RID: 26345 RVA: 0x000C4980 File Offset: 0x000C2B80
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060066EA RID: 26346 RVA: 0x000C4998 File Offset: 0x000C2B98
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17002080 RID: 8320
		// (get) Token: 0x060066EB RID: 26347 RVA: 0x000C49A4 File Offset: 0x000C2BA4
		// (set) Token: 0x060066EC RID: 26348 RVA: 0x000C49D0 File Offset: 0x000C2BD0
		[ProtoMember(3, IsRequired = false, Name = "ispay", DataFormat = DataFormat.Default)]
		public bool ispay
		{
			get
			{
				return this._ispay ?? false;
			}
			set
			{
				this._ispay = new bool?(value);
			}
		}

		// Token: 0x17002081 RID: 8321
		// (get) Token: 0x060066ED RID: 26349 RVA: 0x000C49E0 File Offset: 0x000C2BE0
		// (set) Token: 0x060066EE RID: 26350 RVA: 0x000C4A00 File Offset: 0x000C2C00
		[XmlIgnore]
		[Browsable(false)]
		public bool ispaySpecified
		{
			get
			{
				return this._ispay != null;
			}
			set
			{
				bool flag = value == (this._ispay == null);
				if (flag)
				{
					this._ispay = (value ? new bool?(this.ispay) : null);
				}
			}
		}

		// Token: 0x060066EF RID: 26351 RVA: 0x000C4A44 File Offset: 0x000C2C44
		private bool ShouldSerializeispay()
		{
			return this.ispaySpecified;
		}

		// Token: 0x060066F0 RID: 26352 RVA: 0x000C4A5C File Offset: 0x000C2C5C
		private void Resetispay()
		{
			this.ispaySpecified = false;
		}

		// Token: 0x060066F1 RID: 26353 RVA: 0x000C4A68 File Offset: 0x000C2C68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018DB RID: 6363
		private readonly List<ItemRecord> _itemrecord = new List<ItemRecord>();

		// Token: 0x040018DC RID: 6364
		private uint? _state;

		// Token: 0x040018DD RID: 6365
		private bool? _ispay;

		// Token: 0x040018DE RID: 6366
		private IExtension extensionObject;
	}
}
