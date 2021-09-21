using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D7 RID: 983
	[ProtoContract(Name = "NotifySkyTeamCreate")]
	[Serializable]
	public class NotifySkyTeamCreate : IExtensible
	{
		// Token: 0x1700101C RID: 4124
		// (get) Token: 0x06003456 RID: 13398 RVA: 0x00064670 File Offset: 0x00062870
		// (set) Token: 0x06003457 RID: 13399 RVA: 0x0006469D File Offset: 0x0006289D
		[ProtoMember(1, IsRequired = false, Name = "sky_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong sky_teamid
		{
			get
			{
				return this._sky_teamid ?? 0UL;
			}
			set
			{
				this._sky_teamid = new ulong?(value);
			}
		}

		// Token: 0x1700101D RID: 4125
		// (get) Token: 0x06003458 RID: 13400 RVA: 0x000646AC File Offset: 0x000628AC
		// (set) Token: 0x06003459 RID: 13401 RVA: 0x000646CC File Offset: 0x000628CC
		[XmlIgnore]
		[Browsable(false)]
		public bool sky_teamidSpecified
		{
			get
			{
				return this._sky_teamid != null;
			}
			set
			{
				bool flag = value == (this._sky_teamid == null);
				if (flag)
				{
					this._sky_teamid = (value ? new ulong?(this.sky_teamid) : null);
				}
			}
		}

		// Token: 0x0600345A RID: 13402 RVA: 0x00064710 File Offset: 0x00062910
		private bool ShouldSerializesky_teamid()
		{
			return this.sky_teamidSpecified;
		}

		// Token: 0x0600345B RID: 13403 RVA: 0x00064728 File Offset: 0x00062928
		private void Resetsky_teamid()
		{
			this.sky_teamidSpecified = false;
		}

		// Token: 0x1700101E RID: 4126
		// (get) Token: 0x0600345C RID: 13404 RVA: 0x00064734 File Offset: 0x00062934
		// (set) Token: 0x0600345D RID: 13405 RVA: 0x00064755 File Offset: 0x00062955
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

		// Token: 0x1700101F RID: 4127
		// (get) Token: 0x0600345E RID: 13406 RVA: 0x00064760 File Offset: 0x00062960
		// (set) Token: 0x0600345F RID: 13407 RVA: 0x0006477C File Offset: 0x0006297C
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

		// Token: 0x06003460 RID: 13408 RVA: 0x000647AC File Offset: 0x000629AC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003461 RID: 13409 RVA: 0x000647C4 File Offset: 0x000629C4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06003462 RID: 13410 RVA: 0x000647D0 File Offset: 0x000629D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D00 RID: 3328
		private ulong? _sky_teamid;

		// Token: 0x04000D01 RID: 3329
		private string _name;

		// Token: 0x04000D02 RID: 3330
		private IExtension extensionObject;
	}
}
