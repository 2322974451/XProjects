using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000656 RID: 1622
	[ProtoContract(Name = "STransformBuff")]
	[Serializable]
	public class STransformBuff : IExtensible
	{
		// Token: 0x17001FDD RID: 8157
		// (get) Token: 0x060064FF RID: 25855 RVA: 0x000C0C94 File Offset: 0x000BEE94
		// (set) Token: 0x06006500 RID: 25856 RVA: 0x000C0CC0 File Offset: 0x000BEEC0
		[ProtoMember(1, IsRequired = false, Name = "ispassive", DataFormat = DataFormat.Default)]
		public bool ispassive
		{
			get
			{
				return this._ispassive ?? false;
			}
			set
			{
				this._ispassive = new bool?(value);
			}
		}

		// Token: 0x17001FDE RID: 8158
		// (get) Token: 0x06006501 RID: 25857 RVA: 0x000C0CD0 File Offset: 0x000BEED0
		// (set) Token: 0x06006502 RID: 25858 RVA: 0x000C0CF0 File Offset: 0x000BEEF0
		[XmlIgnore]
		[Browsable(false)]
		public bool ispassiveSpecified
		{
			get
			{
				return this._ispassive != null;
			}
			set
			{
				bool flag = value == (this._ispassive == null);
				if (flag)
				{
					this._ispassive = (value ? new bool?(this.ispassive) : null);
				}
			}
		}

		// Token: 0x06006503 RID: 25859 RVA: 0x000C0D34 File Offset: 0x000BEF34
		private bool ShouldSerializeispassive()
		{
			return this.ispassiveSpecified;
		}

		// Token: 0x06006504 RID: 25860 RVA: 0x000C0D4C File Offset: 0x000BEF4C
		private void Resetispassive()
		{
			this.ispassiveSpecified = false;
		}

		// Token: 0x17001FDF RID: 8159
		// (get) Token: 0x06006505 RID: 25861 RVA: 0x000C0D58 File Offset: 0x000BEF58
		// (set) Token: 0x06006506 RID: 25862 RVA: 0x000C0D84 File Offset: 0x000BEF84
		[ProtoMember(2, IsRequired = false, Name = "iseffecting", DataFormat = DataFormat.Default)]
		public bool iseffecting
		{
			get
			{
				return this._iseffecting ?? false;
			}
			set
			{
				this._iseffecting = new bool?(value);
			}
		}

		// Token: 0x17001FE0 RID: 8160
		// (get) Token: 0x06006507 RID: 25863 RVA: 0x000C0D94 File Offset: 0x000BEF94
		// (set) Token: 0x06006508 RID: 25864 RVA: 0x000C0DB4 File Offset: 0x000BEFB4
		[XmlIgnore]
		[Browsable(false)]
		public bool iseffectingSpecified
		{
			get
			{
				return this._iseffecting != null;
			}
			set
			{
				bool flag = value == (this._iseffecting == null);
				if (flag)
				{
					this._iseffecting = (value ? new bool?(this.iseffecting) : null);
				}
			}
		}

		// Token: 0x06006509 RID: 25865 RVA: 0x000C0DF8 File Offset: 0x000BEFF8
		private bool ShouldSerializeiseffecting()
		{
			return this.iseffectingSpecified;
		}

		// Token: 0x0600650A RID: 25866 RVA: 0x000C0E10 File Offset: 0x000BF010
		private void Resetiseffecting()
		{
			this.iseffectingSpecified = false;
		}

		// Token: 0x17001FE1 RID: 8161
		// (get) Token: 0x0600650B RID: 25867 RVA: 0x000C0E1C File Offset: 0x000BF01C
		// (set) Token: 0x0600650C RID: 25868 RVA: 0x000C0E34 File Offset: 0x000BF034
		[ProtoMember(3, IsRequired = false, Name = "buff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Buff buff
		{
			get
			{
				return this._buff;
			}
			set
			{
				this._buff = value;
			}
		}

		// Token: 0x0600650D RID: 25869 RVA: 0x000C0E40 File Offset: 0x000BF040
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400187C RID: 6268
		private bool? _ispassive;

		// Token: 0x0400187D RID: 6269
		private bool? _iseffecting;

		// Token: 0x0400187E RID: 6270
		private Buff _buff = null;

		// Token: 0x0400187F RID: 6271
		private IExtension extensionObject;
	}
}
