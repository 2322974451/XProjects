using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000662 RID: 1634
	[ProtoContract(Name = "SRoleMultiReward")]
	[Serializable]
	public class SRoleMultiReward : IExtensible
	{
		// Token: 0x17002088 RID: 8328
		// (get) Token: 0x06006707 RID: 26375 RVA: 0x000C4D14 File Offset: 0x000C2F14
		// (set) Token: 0x06006708 RID: 26376 RVA: 0x000C4D40 File Offset: 0x000C2F40
		[ProtoMember(1, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public uint day
		{
			get
			{
				return this._day ?? 0U;
			}
			set
			{
				this._day = new uint?(value);
			}
		}

		// Token: 0x17002089 RID: 8329
		// (get) Token: 0x06006709 RID: 26377 RVA: 0x000C4D50 File Offset: 0x000C2F50
		// (set) Token: 0x0600670A RID: 26378 RVA: 0x000C4D70 File Offset: 0x000C2F70
		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new uint?(this.day) : null);
				}
			}
		}

		// Token: 0x0600670B RID: 26379 RVA: 0x000C4DB4 File Offset: 0x000C2FB4
		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		// Token: 0x0600670C RID: 26380 RVA: 0x000C4DCC File Offset: 0x000C2FCC
		private void Resetday()
		{
			this.daySpecified = false;
		}

		// Token: 0x1700208A RID: 8330
		// (get) Token: 0x0600670D RID: 26381 RVA: 0x000C4DD8 File Offset: 0x000C2FD8
		[ProtoMember(2, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public List<uint> id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x1700208B RID: 8331
		// (get) Token: 0x0600670E RID: 26382 RVA: 0x000C4DF0 File Offset: 0x000C2FF0
		[ProtoMember(3, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public List<uint> count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x0600670F RID: 26383 RVA: 0x000C4E08 File Offset: 0x000C3008
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018E3 RID: 6371
		private uint? _day;

		// Token: 0x040018E4 RID: 6372
		private readonly List<uint> _id = new List<uint>();

		// Token: 0x040018E5 RID: 6373
		private readonly List<uint> _count = new List<uint>();

		// Token: 0x040018E6 RID: 6374
		private IExtension extensionObject;
	}
}
