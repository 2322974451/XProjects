using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D4 RID: 1492
	[ProtoContract(Name = "PVPResult")]
	[Serializable]
	public class PVPResult : IExtensible
	{
		// Token: 0x17001A78 RID: 6776
		// (get) Token: 0x06005554 RID: 21844 RVA: 0x000A2648 File Offset: 0x000A0848
		// (set) Token: 0x06005555 RID: 21845 RVA: 0x000A2674 File Offset: 0x000A0874
		[ProtoMember(1, IsRequired = false, Name = "mygroup", DataFormat = DataFormat.TwosComplement)]
		public int mygroup
		{
			get
			{
				return this._mygroup ?? 0;
			}
			set
			{
				this._mygroup = new int?(value);
			}
		}

		// Token: 0x17001A79 RID: 6777
		// (get) Token: 0x06005556 RID: 21846 RVA: 0x000A2684 File Offset: 0x000A0884
		// (set) Token: 0x06005557 RID: 21847 RVA: 0x000A26A4 File Offset: 0x000A08A4
		[XmlIgnore]
		[Browsable(false)]
		public bool mygroupSpecified
		{
			get
			{
				return this._mygroup != null;
			}
			set
			{
				bool flag = value == (this._mygroup == null);
				if (flag)
				{
					this._mygroup = (value ? new int?(this.mygroup) : null);
				}
			}
		}

		// Token: 0x06005558 RID: 21848 RVA: 0x000A26E8 File Offset: 0x000A08E8
		private bool ShouldSerializemygroup()
		{
			return this.mygroupSpecified;
		}

		// Token: 0x06005559 RID: 21849 RVA: 0x000A2700 File Offset: 0x000A0900
		private void Resetmygroup()
		{
			this.mygroupSpecified = false;
		}

		// Token: 0x17001A7A RID: 6778
		// (get) Token: 0x0600555A RID: 21850 RVA: 0x000A270C File Offset: 0x000A090C
		// (set) Token: 0x0600555B RID: 21851 RVA: 0x000A2738 File Offset: 0x000A0938
		[ProtoMember(2, IsRequired = false, Name = "wingroup", DataFormat = DataFormat.TwosComplement)]
		public int wingroup
		{
			get
			{
				return this._wingroup ?? 0;
			}
			set
			{
				this._wingroup = new int?(value);
			}
		}

		// Token: 0x17001A7B RID: 6779
		// (get) Token: 0x0600555C RID: 21852 RVA: 0x000A2748 File Offset: 0x000A0948
		// (set) Token: 0x0600555D RID: 21853 RVA: 0x000A2768 File Offset: 0x000A0968
		[XmlIgnore]
		[Browsable(false)]
		public bool wingroupSpecified
		{
			get
			{
				return this._wingroup != null;
			}
			set
			{
				bool flag = value == (this._wingroup == null);
				if (flag)
				{
					this._wingroup = (value ? new int?(this.wingroup) : null);
				}
			}
		}

		// Token: 0x0600555E RID: 21854 RVA: 0x000A27AC File Offset: 0x000A09AC
		private bool ShouldSerializewingroup()
		{
			return this.wingroupSpecified;
		}

		// Token: 0x0600555F RID: 21855 RVA: 0x000A27C4 File Offset: 0x000A09C4
		private void Resetwingroup()
		{
			this.wingroupSpecified = false;
		}

		// Token: 0x17001A7C RID: 6780
		// (get) Token: 0x06005560 RID: 21856 RVA: 0x000A27D0 File Offset: 0x000A09D0
		// (set) Token: 0x06005561 RID: 21857 RVA: 0x000A27FC File Offset: 0x000A09FC
		[ProtoMember(3, IsRequired = false, Name = "killleadercount", DataFormat = DataFormat.TwosComplement)]
		public int killleadercount
		{
			get
			{
				return this._killleadercount ?? 0;
			}
			set
			{
				this._killleadercount = new int?(value);
			}
		}

		// Token: 0x17001A7D RID: 6781
		// (get) Token: 0x06005562 RID: 21858 RVA: 0x000A280C File Offset: 0x000A0A0C
		// (set) Token: 0x06005563 RID: 21859 RVA: 0x000A282C File Offset: 0x000A0A2C
		[XmlIgnore]
		[Browsable(false)]
		public bool killleadercountSpecified
		{
			get
			{
				return this._killleadercount != null;
			}
			set
			{
				bool flag = value == (this._killleadercount == null);
				if (flag)
				{
					this._killleadercount = (value ? new int?(this.killleadercount) : null);
				}
			}
		}

		// Token: 0x06005564 RID: 21860 RVA: 0x000A2870 File Offset: 0x000A0A70
		private bool ShouldSerializekillleadercount()
		{
			return this.killleadercountSpecified;
		}

		// Token: 0x06005565 RID: 21861 RVA: 0x000A2888 File Offset: 0x000A0A88
		private void Resetkillleadercount()
		{
			this.killleadercountSpecified = false;
		}

		// Token: 0x17001A7E RID: 6782
		// (get) Token: 0x06005566 RID: 21862 RVA: 0x000A2894 File Offset: 0x000A0A94
		// (set) Token: 0x06005567 RID: 21863 RVA: 0x000A28C0 File Offset: 0x000A0AC0
		[ProtoMember(4, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		// Token: 0x17001A7F RID: 6783
		// (get) Token: 0x06005568 RID: 21864 RVA: 0x000A28D0 File Offset: 0x000A0AD0
		// (set) Token: 0x06005569 RID: 21865 RVA: 0x000A28F0 File Offset: 0x000A0AF0
		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		// Token: 0x0600556A RID: 21866 RVA: 0x000A2934 File Offset: 0x000A0B34
		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		// Token: 0x0600556B RID: 21867 RVA: 0x000A294C File Offset: 0x000A0B4C
		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		// Token: 0x17001A80 RID: 6784
		// (get) Token: 0x0600556C RID: 21868 RVA: 0x000A2958 File Offset: 0x000A0B58
		[ProtoMember(5, Name = "dayjoinreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dayjoinreward
		{
			get
			{
				return this._dayjoinreward;
			}
		}

		// Token: 0x17001A81 RID: 6785
		// (get) Token: 0x0600556D RID: 21869 RVA: 0x000A2970 File Offset: 0x000A0B70
		[ProtoMember(6, Name = "winreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> winreward
		{
			get
			{
				return this._winreward;
			}
		}

		// Token: 0x0600556E RID: 21870 RVA: 0x000A2988 File Offset: 0x000A0B88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014CC RID: 5324
		private int? _mygroup;

		// Token: 0x040014CD RID: 5325
		private int? _wingroup;

		// Token: 0x040014CE RID: 5326
		private int? _killleadercount;

		// Token: 0x040014CF RID: 5327
		private bool? _ismvp;

		// Token: 0x040014D0 RID: 5328
		private readonly List<ItemBrief> _dayjoinreward = new List<ItemBrief>();

		// Token: 0x040014D1 RID: 5329
		private readonly List<ItemBrief> _winreward = new List<ItemBrief>();

		// Token: 0x040014D2 RID: 5330
		private IExtension extensionObject;
	}
}
