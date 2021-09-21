using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000426 RID: 1062
	[ProtoContract(Name = "TransSkillNotfiy")]
	[Serializable]
	public class TransSkillNotfiy : IExtensible
	{
		// Token: 0x1700114A RID: 4426
		// (get) Token: 0x06003847 RID: 14407 RVA: 0x0006BBAC File Offset: 0x00069DAC
		[ProtoMember(1, Name = "skillhash", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skillhash
		{
			get
			{
				return this._skillhash;
			}
		}

		// Token: 0x1700114B RID: 4427
		// (get) Token: 0x06003848 RID: 14408 RVA: 0x0006BBC4 File Offset: 0x00069DC4
		[ProtoMember(2, Name = "skilllevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> skilllevel
		{
			get
			{
				return this._skilllevel;
			}
		}

		// Token: 0x1700114C RID: 4428
		// (get) Token: 0x06003849 RID: 14409 RVA: 0x0006BBDC File Offset: 0x00069DDC
		// (set) Token: 0x0600384A RID: 14410 RVA: 0x0006BC08 File Offset: 0x00069E08
		[ProtoMember(3, IsRequired = false, Name = "isincreasing", DataFormat = DataFormat.Default)]
		public bool isincreasing
		{
			get
			{
				return this._isincreasing ?? false;
			}
			set
			{
				this._isincreasing = new bool?(value);
			}
		}

		// Token: 0x1700114D RID: 4429
		// (get) Token: 0x0600384B RID: 14411 RVA: 0x0006BC18 File Offset: 0x00069E18
		// (set) Token: 0x0600384C RID: 14412 RVA: 0x0006BC38 File Offset: 0x00069E38
		[XmlIgnore]
		[Browsable(false)]
		public bool isincreasingSpecified
		{
			get
			{
				return this._isincreasing != null;
			}
			set
			{
				bool flag = value == (this._isincreasing == null);
				if (flag)
				{
					this._isincreasing = (value ? new bool?(this.isincreasing) : null);
				}
			}
		}

		// Token: 0x0600384D RID: 14413 RVA: 0x0006BC7C File Offset: 0x00069E7C
		private bool ShouldSerializeisincreasing()
		{
			return this.isincreasingSpecified;
		}

		// Token: 0x0600384E RID: 14414 RVA: 0x0006BC94 File Offset: 0x00069E94
		private void Resetisincreasing()
		{
			this.isincreasingSpecified = false;
		}

		// Token: 0x0600384F RID: 14415 RVA: 0x0006BCA0 File Offset: 0x00069EA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DF6 RID: 3574
		private readonly List<uint> _skillhash = new List<uint>();

		// Token: 0x04000DF7 RID: 3575
		private readonly List<uint> _skilllevel = new List<uint>();

		// Token: 0x04000DF8 RID: 3576
		private bool? _isincreasing;

		// Token: 0x04000DF9 RID: 3577
		private IExtension extensionObject;
	}
}
