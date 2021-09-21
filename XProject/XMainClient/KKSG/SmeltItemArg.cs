using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000222 RID: 546
	[ProtoContract(Name = "SmeltItemArg")]
	[Serializable]
	public class SmeltItemArg : IExtensible
	{
		// Token: 0x17000999 RID: 2457
		// (get) Token: 0x06001EB1 RID: 7857 RVA: 0x0003C474 File Offset: 0x0003A674
		// (set) Token: 0x06001EB2 RID: 7858 RVA: 0x0003C4A1 File Offset: 0x0003A6A1
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x1700099A RID: 2458
		// (get) Token: 0x06001EB3 RID: 7859 RVA: 0x0003C4B0 File Offset: 0x0003A6B0
		// (set) Token: 0x06001EB4 RID: 7860 RVA: 0x0003C4D0 File Offset: 0x0003A6D0
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06001EB5 RID: 7861 RVA: 0x0003C514 File Offset: 0x0003A714
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06001EB6 RID: 7862 RVA: 0x0003C52C File Offset: 0x0003A72C
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x1700099B RID: 2459
		// (get) Token: 0x06001EB7 RID: 7863 RVA: 0x0003C538 File Offset: 0x0003A738
		// (set) Token: 0x06001EB8 RID: 7864 RVA: 0x0003C564 File Offset: 0x0003A764
		[ProtoMember(2, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public uint slot
		{
			get
			{
				return this._slot ?? 0U;
			}
			set
			{
				this._slot = new uint?(value);
			}
		}

		// Token: 0x1700099C RID: 2460
		// (get) Token: 0x06001EB9 RID: 7865 RVA: 0x0003C574 File Offset: 0x0003A774
		// (set) Token: 0x06001EBA RID: 7866 RVA: 0x0003C594 File Offset: 0x0003A794
		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new uint?(this.slot) : null);
				}
			}
		}

		// Token: 0x06001EBB RID: 7867 RVA: 0x0003C5D8 File Offset: 0x0003A7D8
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x06001EBC RID: 7868 RVA: 0x0003C5F0 File Offset: 0x0003A7F0
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x1700099D RID: 2461
		// (get) Token: 0x06001EBD RID: 7869 RVA: 0x0003C5FC File Offset: 0x0003A7FC
		// (set) Token: 0x06001EBE RID: 7870 RVA: 0x0003C628 File Offset: 0x0003A828
		[ProtoMember(3, IsRequired = false, Name = "isForge", DataFormat = DataFormat.Default)]
		public bool isForge
		{
			get
			{
				return this._isForge ?? false;
			}
			set
			{
				this._isForge = new bool?(value);
			}
		}

		// Token: 0x1700099E RID: 2462
		// (get) Token: 0x06001EBF RID: 7871 RVA: 0x0003C638 File Offset: 0x0003A838
		// (set) Token: 0x06001EC0 RID: 7872 RVA: 0x0003C658 File Offset: 0x0003A858
		[XmlIgnore]
		[Browsable(false)]
		public bool isForgeSpecified
		{
			get
			{
				return this._isForge != null;
			}
			set
			{
				bool flag = value == (this._isForge == null);
				if (flag)
				{
					this._isForge = (value ? new bool?(this.isForge) : null);
				}
			}
		}

		// Token: 0x06001EC1 RID: 7873 RVA: 0x0003C69C File Offset: 0x0003A89C
		private bool ShouldSerializeisForge()
		{
			return this.isForgeSpecified;
		}

		// Token: 0x06001EC2 RID: 7874 RVA: 0x0003C6B4 File Offset: 0x0003A8B4
		private void ResetisForge()
		{
			this.isForgeSpecified = false;
		}

		// Token: 0x06001EC3 RID: 7875 RVA: 0x0003C6C0 File Offset: 0x0003A8C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007AA RID: 1962
		private ulong? _uid;

		// Token: 0x040007AB RID: 1963
		private uint? _slot;

		// Token: 0x040007AC RID: 1964
		private bool? _isForge;

		// Token: 0x040007AD RID: 1965
		private IExtension extensionObject;
	}
}
