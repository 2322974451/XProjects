using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002AB RID: 683
	[ProtoContract(Name = "BattleLogReport")]
	[Serializable]
	public class BattleLogReport : IExtensible
	{
		// Token: 0x17000BD0 RID: 3024
		// (get) Token: 0x06002602 RID: 9730 RVA: 0x00049FC0 File Offset: 0x000481C0
		[ProtoMember(1, Name = "key", DataFormat = DataFormat.Default)]
		public List<string> key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x17000BD1 RID: 3025
		// (get) Token: 0x06002603 RID: 9731 RVA: 0x00049FD8 File Offset: 0x000481D8
		[ProtoMember(2, Name = "value", DataFormat = DataFormat.Default)]
		public List<string> value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x17000BD2 RID: 3026
		// (get) Token: 0x06002604 RID: 9732 RVA: 0x00049FF0 File Offset: 0x000481F0
		// (set) Token: 0x06002605 RID: 9733 RVA: 0x0004A01C File Offset: 0x0004821C
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000BD3 RID: 3027
		// (get) Token: 0x06002606 RID: 9734 RVA: 0x0004A02C File Offset: 0x0004822C
		// (set) Token: 0x06002607 RID: 9735 RVA: 0x0004A04C File Offset: 0x0004824C
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06002608 RID: 9736 RVA: 0x0004A090 File Offset: 0x00048290
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002609 RID: 9737 RVA: 0x0004A0A8 File Offset: 0x000482A8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000BD4 RID: 3028
		// (get) Token: 0x0600260A RID: 9738 RVA: 0x0004A0B4 File Offset: 0x000482B4
		// (set) Token: 0x0600260B RID: 9739 RVA: 0x0004A0E1 File Offset: 0x000482E1
		[ProtoMember(4, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17000BD5 RID: 3029
		// (get) Token: 0x0600260C RID: 9740 RVA: 0x0004A0F0 File Offset: 0x000482F0
		// (set) Token: 0x0600260D RID: 9741 RVA: 0x0004A110 File Offset: 0x00048310
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x0600260E RID: 9742 RVA: 0x0004A154 File Offset: 0x00048354
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600260F RID: 9743 RVA: 0x0004A16C File Offset: 0x0004836C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06002610 RID: 9744 RVA: 0x0004A178 File Offset: 0x00048378
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400096C RID: 2412
		private readonly List<string> _key = new List<string>();

		// Token: 0x0400096D RID: 2413
		private readonly List<string> _value = new List<string>();

		// Token: 0x0400096E RID: 2414
		private uint? _type;

		// Token: 0x0400096F RID: 2415
		private ulong? _roleid;

		// Token: 0x04000970 RID: 2416
		private IExtension extensionObject;
	}
}
