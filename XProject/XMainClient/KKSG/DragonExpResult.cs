using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D5 RID: 1493
	[ProtoContract(Name = "DragonExpResult")]
	[Serializable]
	public class DragonExpResult : IExtensible
	{
		// Token: 0x17001A82 RID: 6786
		// (get) Token: 0x06005570 RID: 21872 RVA: 0x000A29C8 File Offset: 0x000A0BC8
		// (set) Token: 0x06005571 RID: 21873 RVA: 0x000A29F4 File Offset: 0x000A0BF4
		[ProtoMember(1, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
		public bool iswin
		{
			get
			{
				return this._iswin ?? false;
			}
			set
			{
				this._iswin = new bool?(value);
			}
		}

		// Token: 0x17001A83 RID: 6787
		// (get) Token: 0x06005572 RID: 21874 RVA: 0x000A2A04 File Offset: 0x000A0C04
		// (set) Token: 0x06005573 RID: 21875 RVA: 0x000A2A24 File Offset: 0x000A0C24
		[XmlIgnore]
		[Browsable(false)]
		public bool iswinSpecified
		{
			get
			{
				return this._iswin != null;
			}
			set
			{
				bool flag = value == (this._iswin == null);
				if (flag)
				{
					this._iswin = (value ? new bool?(this.iswin) : null);
				}
			}
		}

		// Token: 0x06005574 RID: 21876 RVA: 0x000A2A68 File Offset: 0x000A0C68
		private bool ShouldSerializeiswin()
		{
			return this.iswinSpecified;
		}

		// Token: 0x06005575 RID: 21877 RVA: 0x000A2A80 File Offset: 0x000A0C80
		private void Resetiswin()
		{
			this.iswinSpecified = false;
		}

		// Token: 0x17001A84 RID: 6788
		// (get) Token: 0x06005576 RID: 21878 RVA: 0x000A2A8C File Offset: 0x000A0C8C
		// (set) Token: 0x06005577 RID: 21879 RVA: 0x000A2AB8 File Offset: 0x000A0CB8
		[ProtoMember(2, IsRequired = false, Name = "bosshurthp", DataFormat = DataFormat.TwosComplement)]
		public int bosshurthp
		{
			get
			{
				return this._bosshurthp ?? 0;
			}
			set
			{
				this._bosshurthp = new int?(value);
			}
		}

		// Token: 0x17001A85 RID: 6789
		// (get) Token: 0x06005578 RID: 21880 RVA: 0x000A2AC8 File Offset: 0x000A0CC8
		// (set) Token: 0x06005579 RID: 21881 RVA: 0x000A2AE8 File Offset: 0x000A0CE8
		[XmlIgnore]
		[Browsable(false)]
		public bool bosshurthpSpecified
		{
			get
			{
				return this._bosshurthp != null;
			}
			set
			{
				bool flag = value == (this._bosshurthp == null);
				if (flag)
				{
					this._bosshurthp = (value ? new int?(this.bosshurthp) : null);
				}
			}
		}

		// Token: 0x0600557A RID: 21882 RVA: 0x000A2B2C File Offset: 0x000A0D2C
		private bool ShouldSerializebosshurthp()
		{
			return this.bosshurthpSpecified;
		}

		// Token: 0x0600557B RID: 21883 RVA: 0x000A2B44 File Offset: 0x000A0D44
		private void Resetbosshurthp()
		{
			this.bosshurthpSpecified = false;
		}

		// Token: 0x17001A86 RID: 6790
		// (get) Token: 0x0600557C RID: 21884 RVA: 0x000A2B50 File Offset: 0x000A0D50
		// (set) Token: 0x0600557D RID: 21885 RVA: 0x000A2B7C File Offset: 0x000A0D7C
		[ProtoMember(3, IsRequired = false, Name = "bosslefthp", DataFormat = DataFormat.TwosComplement)]
		public int bosslefthp
		{
			get
			{
				return this._bosslefthp ?? 0;
			}
			set
			{
				this._bosslefthp = new int?(value);
			}
		}

		// Token: 0x17001A87 RID: 6791
		// (get) Token: 0x0600557E RID: 21886 RVA: 0x000A2B8C File Offset: 0x000A0D8C
		// (set) Token: 0x0600557F RID: 21887 RVA: 0x000A2BAC File Offset: 0x000A0DAC
		[XmlIgnore]
		[Browsable(false)]
		public bool bosslefthpSpecified
		{
			get
			{
				return this._bosslefthp != null;
			}
			set
			{
				bool flag = value == (this._bosslefthp == null);
				if (flag)
				{
					this._bosslefthp = (value ? new int?(this.bosslefthp) : null);
				}
			}
		}

		// Token: 0x06005580 RID: 21888 RVA: 0x000A2BF0 File Offset: 0x000A0DF0
		private bool ShouldSerializebosslefthp()
		{
			return this.bosslefthpSpecified;
		}

		// Token: 0x06005581 RID: 21889 RVA: 0x000A2C08 File Offset: 0x000A0E08
		private void Resetbosslefthp()
		{
			this.bosslefthpSpecified = false;
		}

		// Token: 0x17001A88 RID: 6792
		// (get) Token: 0x06005582 RID: 21890 RVA: 0x000A2C14 File Offset: 0x000A0E14
		[ProtoMember(4, Name = "joinreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> joinreward
		{
			get
			{
				return this._joinreward;
			}
		}

		// Token: 0x17001A89 RID: 6793
		// (get) Token: 0x06005583 RID: 21891 RVA: 0x000A2C2C File Offset: 0x000A0E2C
		[ProtoMember(5, Name = "winreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> winreward
		{
			get
			{
				return this._winreward;
			}
		}

		// Token: 0x17001A8A RID: 6794
		// (get) Token: 0x06005584 RID: 21892 RVA: 0x000A2C44 File Offset: 0x000A0E44
		// (set) Token: 0x06005585 RID: 21893 RVA: 0x000A2C70 File Offset: 0x000A0E70
		[ProtoMember(6, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		// Token: 0x17001A8B RID: 6795
		// (get) Token: 0x06005586 RID: 21894 RVA: 0x000A2C80 File Offset: 0x000A0E80
		// (set) Token: 0x06005587 RID: 21895 RVA: 0x000A2CA0 File Offset: 0x000A0EA0
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		// Token: 0x06005588 RID: 21896 RVA: 0x000A2CE4 File Offset: 0x000A0EE4
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x06005589 RID: 21897 RVA: 0x000A2CFC File Offset: 0x000A0EFC
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x0600558A RID: 21898 RVA: 0x000A2D08 File Offset: 0x000A0F08
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014D3 RID: 5331
		private bool? _iswin;

		// Token: 0x040014D4 RID: 5332
		private int? _bosshurthp;

		// Token: 0x040014D5 RID: 5333
		private int? _bosslefthp;

		// Token: 0x040014D6 RID: 5334
		private readonly List<ItemBrief> _joinreward = new List<ItemBrief>();

		// Token: 0x040014D7 RID: 5335
		private readonly List<ItemBrief> _winreward = new List<ItemBrief>();

		// Token: 0x040014D8 RID: 5336
		private uint? _sceneid;

		// Token: 0x040014D9 RID: 5337
		private IExtension extensionObject;
	}
}
