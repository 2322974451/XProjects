using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200056B RID: 1387
	[ProtoContract(Name = "EffectData")]
	[Serializable]
	public class EffectData : IExtensible
	{
		// Token: 0x170015D9 RID: 5593
		// (get) Token: 0x0600475C RID: 18268 RVA: 0x00087970 File Offset: 0x00085B70
		// (set) Token: 0x0600475D RID: 18269 RVA: 0x0008799C File Offset: 0x00085B9C
		[ProtoMember(1, IsRequired = false, Name = "effectID", DataFormat = DataFormat.TwosComplement)]
		public uint effectID
		{
			get
			{
				return this._effectID ?? 0U;
			}
			set
			{
				this._effectID = new uint?(value);
			}
		}

		// Token: 0x170015DA RID: 5594
		// (get) Token: 0x0600475E RID: 18270 RVA: 0x000879AC File Offset: 0x00085BAC
		// (set) Token: 0x0600475F RID: 18271 RVA: 0x000879CC File Offset: 0x00085BCC
		[XmlIgnore]
		[Browsable(false)]
		public bool effectIDSpecified
		{
			get
			{
				return this._effectID != null;
			}
			set
			{
				bool flag = value == (this._effectID == null);
				if (flag)
				{
					this._effectID = (value ? new uint?(this.effectID) : null);
				}
			}
		}

		// Token: 0x06004760 RID: 18272 RVA: 0x00087A10 File Offset: 0x00085C10
		private bool ShouldSerializeeffectID()
		{
			return this.effectIDSpecified;
		}

		// Token: 0x06004761 RID: 18273 RVA: 0x00087A28 File Offset: 0x00085C28
		private void ReseteffectID()
		{
			this.effectIDSpecified = false;
		}

		// Token: 0x170015DB RID: 5595
		// (get) Token: 0x06004762 RID: 18274 RVA: 0x00087A34 File Offset: 0x00085C34
		[ProtoMember(2, Name = "multiParams", DataFormat = DataFormat.Default)]
		public List<EffectMultiParams> multiParams
		{
			get
			{
				return this._multiParams;
			}
		}

		// Token: 0x170015DC RID: 5596
		// (get) Token: 0x06004763 RID: 18275 RVA: 0x00087A4C File Offset: 0x00085C4C
		// (set) Token: 0x06004764 RID: 18276 RVA: 0x00087A78 File Offset: 0x00085C78
		[ProtoMember(3, IsRequired = false, Name = "isWork", DataFormat = DataFormat.Default)]
		public bool isWork
		{
			get
			{
				return this._isWork ?? false;
			}
			set
			{
				this._isWork = new bool?(value);
			}
		}

		// Token: 0x170015DD RID: 5597
		// (get) Token: 0x06004765 RID: 18277 RVA: 0x00087A88 File Offset: 0x00085C88
		// (set) Token: 0x06004766 RID: 18278 RVA: 0x00087AA8 File Offset: 0x00085CA8
		[XmlIgnore]
		[Browsable(false)]
		public bool isWorkSpecified
		{
			get
			{
				return this._isWork != null;
			}
			set
			{
				bool flag = value == (this._isWork == null);
				if (flag)
				{
					this._isWork = (value ? new bool?(this.isWork) : null);
				}
			}
		}

		// Token: 0x06004767 RID: 18279 RVA: 0x00087AEC File Offset: 0x00085CEC
		private bool ShouldSerializeisWork()
		{
			return this.isWorkSpecified;
		}

		// Token: 0x06004768 RID: 18280 RVA: 0x00087B04 File Offset: 0x00085D04
		private void ResetisWork()
		{
			this.isWorkSpecified = false;
		}

		// Token: 0x06004769 RID: 18281 RVA: 0x00087B10 File Offset: 0x00085D10
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011D5 RID: 4565
		private uint? _effectID;

		// Token: 0x040011D6 RID: 4566
		private readonly List<EffectMultiParams> _multiParams = new List<EffectMultiParams>();

		// Token: 0x040011D7 RID: 4567
		private bool? _isWork;

		// Token: 0x040011D8 RID: 4568
		private IExtension extensionObject;
	}
}
