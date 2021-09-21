using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000531 RID: 1329
	[ProtoContract(Name = "CrossGvgOperArg")]
	[Serializable]
	public class CrossGvgOperArg : IExtensible
	{
		// Token: 0x170014E5 RID: 5349
		// (get) Token: 0x06004454 RID: 17492 RVA: 0x00081FE4 File Offset: 0x000801E4
		// (set) Token: 0x06004455 RID: 17493 RVA: 0x00082010 File Offset: 0x00080210
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CrossGvgOperType type
		{
			get
			{
				return this._type ?? CrossGvgOperType.CGOT_EnterPointRace;
			}
			set
			{
				this._type = new CrossGvgOperType?(value);
			}
		}

		// Token: 0x170014E6 RID: 5350
		// (get) Token: 0x06004456 RID: 17494 RVA: 0x00082020 File Offset: 0x00080220
		// (set) Token: 0x06004457 RID: 17495 RVA: 0x00082040 File Offset: 0x00080240
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
					this._type = (value ? new CrossGvgOperType?(this.type) : null);
				}
			}
		}

		// Token: 0x06004458 RID: 17496 RVA: 0x00082084 File Offset: 0x00080284
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004459 RID: 17497 RVA: 0x0008209C File Offset: 0x0008029C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170014E7 RID: 5351
		// (get) Token: 0x0600445A RID: 17498 RVA: 0x000820A8 File Offset: 0x000802A8
		[ProtoMember(2, Name = "support_guildid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> support_guildid
		{
			get
			{
				return this._support_guildid;
			}
		}

		// Token: 0x0600445B RID: 17499 RVA: 0x000820C0 File Offset: 0x000802C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400110C RID: 4364
		private CrossGvgOperType? _type;

		// Token: 0x0400110D RID: 4365
		private readonly List<ulong> _support_guildid = new List<ulong>();

		// Token: 0x0400110E RID: 4366
		private IExtension extensionObject;
	}
}
