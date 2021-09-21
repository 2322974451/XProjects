using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000389 RID: 905
	[ProtoContract(Name = "ForgeEquipArg")]
	[Serializable]
	public class ForgeEquipArg : IExtensible
	{
		// Token: 0x17000F2F RID: 3887
		// (get) Token: 0x06003114 RID: 12564 RVA: 0x0005E934 File Offset: 0x0005CB34
		// (set) Token: 0x06003115 RID: 12565 RVA: 0x0005E961 File Offset: 0x0005CB61
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

		// Token: 0x17000F30 RID: 3888
		// (get) Token: 0x06003116 RID: 12566 RVA: 0x0005E970 File Offset: 0x0005CB70
		// (set) Token: 0x06003117 RID: 12567 RVA: 0x0005E990 File Offset: 0x0005CB90
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

		// Token: 0x06003118 RID: 12568 RVA: 0x0005E9D4 File Offset: 0x0005CBD4
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06003119 RID: 12569 RVA: 0x0005E9EC File Offset: 0x0005CBEC
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17000F31 RID: 3889
		// (get) Token: 0x0600311A RID: 12570 RVA: 0x0005E9F8 File Offset: 0x0005CBF8
		// (set) Token: 0x0600311B RID: 12571 RVA: 0x0005EA24 File Offset: 0x0005CC24
		[ProtoMember(2, IsRequired = false, Name = "isUsedStone", DataFormat = DataFormat.Default)]
		public bool isUsedStone
		{
			get
			{
				return this._isUsedStone ?? false;
			}
			set
			{
				this._isUsedStone = new bool?(value);
			}
		}

		// Token: 0x17000F32 RID: 3890
		// (get) Token: 0x0600311C RID: 12572 RVA: 0x0005EA34 File Offset: 0x0005CC34
		// (set) Token: 0x0600311D RID: 12573 RVA: 0x0005EA54 File Offset: 0x0005CC54
		[XmlIgnore]
		[Browsable(false)]
		public bool isUsedStoneSpecified
		{
			get
			{
				return this._isUsedStone != null;
			}
			set
			{
				bool flag = value == (this._isUsedStone == null);
				if (flag)
				{
					this._isUsedStone = (value ? new bool?(this.isUsedStone) : null);
				}
			}
		}

		// Token: 0x0600311E RID: 12574 RVA: 0x0005EA98 File Offset: 0x0005CC98
		private bool ShouldSerializeisUsedStone()
		{
			return this.isUsedStoneSpecified;
		}

		// Token: 0x0600311F RID: 12575 RVA: 0x0005EAB0 File Offset: 0x0005CCB0
		private void ResetisUsedStone()
		{
			this.isUsedStoneSpecified = false;
		}

		// Token: 0x17000F33 RID: 3891
		// (get) Token: 0x06003120 RID: 12576 RVA: 0x0005EABC File Offset: 0x0005CCBC
		// (set) Token: 0x06003121 RID: 12577 RVA: 0x0005EAE8 File Offset: 0x0005CCE8
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ForgeOpType type
		{
			get
			{
				return this._type ?? ForgeOpType.Forge_Equip;
			}
			set
			{
				this._type = new ForgeOpType?(value);
			}
		}

		// Token: 0x17000F34 RID: 3892
		// (get) Token: 0x06003122 RID: 12578 RVA: 0x0005EAF8 File Offset: 0x0005CCF8
		// (set) Token: 0x06003123 RID: 12579 RVA: 0x0005EB18 File Offset: 0x0005CD18
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
					this._type = (value ? new ForgeOpType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003124 RID: 12580 RVA: 0x0005EB5C File Offset: 0x0005CD5C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003125 RID: 12581 RVA: 0x0005EB74 File Offset: 0x0005CD74
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003126 RID: 12582 RVA: 0x0005EB80 File Offset: 0x0005CD80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C31 RID: 3121
		private ulong? _uid;

		// Token: 0x04000C32 RID: 3122
		private bool? _isUsedStone;

		// Token: 0x04000C33 RID: 3123
		private ForgeOpType? _type;

		// Token: 0x04000C34 RID: 3124
		private IExtension extensionObject;
	}
}
