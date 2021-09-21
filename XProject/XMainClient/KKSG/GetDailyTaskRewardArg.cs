using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002CF RID: 719
	[ProtoContract(Name = "GetDailyTaskRewardArg")]
	[Serializable]
	public class GetDailyTaskRewardArg : IExtensible
	{
		// Token: 0x17000C59 RID: 3161
		// (get) Token: 0x060027B4 RID: 10164 RVA: 0x0004D2F8 File Offset: 0x0004B4F8
		// (set) Token: 0x060027B5 RID: 10165 RVA: 0x0004D324 File Offset: 0x0004B524
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000C5A RID: 3162
		// (get) Token: 0x060027B6 RID: 10166 RVA: 0x0004D334 File Offset: 0x0004B534
		// (set) Token: 0x060027B7 RID: 10167 RVA: 0x0004D354 File Offset: 0x0004B554
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

		// Token: 0x060027B8 RID: 10168 RVA: 0x0004D398 File Offset: 0x0004B598
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060027B9 RID: 10169 RVA: 0x0004D3B0 File Offset: 0x0004B5B0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000C5B RID: 3163
		// (get) Token: 0x060027BA RID: 10170 RVA: 0x0004D3BC File Offset: 0x0004B5BC
		// (set) Token: 0x060027BB RID: 10171 RVA: 0x0004D3E8 File Offset: 0x0004B5E8
		[ProtoMember(2, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17000C5C RID: 3164
		// (get) Token: 0x060027BC RID: 10172 RVA: 0x0004D3F8 File Offset: 0x0004B5F8
		// (set) Token: 0x060027BD RID: 10173 RVA: 0x0004D418 File Offset: 0x0004B618
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060027BE RID: 10174 RVA: 0x0004D45C File Offset: 0x0004B65C
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060027BF RID: 10175 RVA: 0x0004D474 File Offset: 0x0004B674
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x060027C0 RID: 10176 RVA: 0x0004D480 File Offset: 0x0004B680
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009E1 RID: 2529
		private uint? _type;

		// Token: 0x040009E2 RID: 2530
		private uint? _id;

		// Token: 0x040009E3 RID: 2531
		private IExtension extensionObject;
	}
}
