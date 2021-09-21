using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200027F RID: 639
	[ProtoContract(Name = "ActiveCookbookArg")]
	[Serializable]
	public class ActiveCookbookArg : IExtensible
	{
		// Token: 0x17000B0D RID: 2829
		// (get) Token: 0x0600238A RID: 9098 RVA: 0x00045610 File Offset: 0x00043810
		// (set) Token: 0x0600238B RID: 9099 RVA: 0x0004563D File Offset: 0x0004383D
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

		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x0600238C RID: 9100 RVA: 0x0004564C File Offset: 0x0004384C
		// (set) Token: 0x0600238D RID: 9101 RVA: 0x0004566C File Offset: 0x0004386C
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

		// Token: 0x0600238E RID: 9102 RVA: 0x000456B0 File Offset: 0x000438B0
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x0600238F RID: 9103 RVA: 0x000456C8 File Offset: 0x000438C8
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x06002390 RID: 9104 RVA: 0x000456D4 File Offset: 0x000438D4
		// (set) Token: 0x06002391 RID: 9105 RVA: 0x00045700 File Offset: 0x00043900
		[ProtoMember(2, IsRequired = false, Name = "cook_book_id", DataFormat = DataFormat.TwosComplement)]
		public uint cook_book_id
		{
			get
			{
				return this._cook_book_id ?? 0U;
			}
			set
			{
				this._cook_book_id = new uint?(value);
			}
		}

		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x06002392 RID: 9106 RVA: 0x00045710 File Offset: 0x00043910
		// (set) Token: 0x06002393 RID: 9107 RVA: 0x00045730 File Offset: 0x00043930
		[XmlIgnore]
		[Browsable(false)]
		public bool cook_book_idSpecified
		{
			get
			{
				return this._cook_book_id != null;
			}
			set
			{
				bool flag = value == (this._cook_book_id == null);
				if (flag)
				{
					this._cook_book_id = (value ? new uint?(this.cook_book_id) : null);
				}
			}
		}

		// Token: 0x06002394 RID: 9108 RVA: 0x00045774 File Offset: 0x00043974
		private bool ShouldSerializecook_book_id()
		{
			return this.cook_book_idSpecified;
		}

		// Token: 0x06002395 RID: 9109 RVA: 0x0004578C File Offset: 0x0004398C
		private void Resetcook_book_id()
		{
			this.cook_book_idSpecified = false;
		}

		// Token: 0x06002396 RID: 9110 RVA: 0x00045798 File Offset: 0x00043998
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008D1 RID: 2257
		private ulong? _garden_id;

		// Token: 0x040008D2 RID: 2258
		private uint? _cook_book_id;

		// Token: 0x040008D3 RID: 2259
		private IExtension extensionObject;
	}
}
