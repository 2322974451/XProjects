using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000623 RID: 1571
	[ProtoContract(Name = "PayAwardRecord")]
	[Serializable]
	public class PayAwardRecord : IExtensible
	{
		// Token: 0x17001E42 RID: 7746
		// (get) Token: 0x0600602E RID: 24622 RVA: 0x000B76E8 File Offset: 0x000B58E8
		// (set) Token: 0x0600602F RID: 24623 RVA: 0x000B7714 File Offset: 0x000B5914
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public int id
		{
			get
			{
				return this._id ?? 0;
			}
			set
			{
				this._id = new int?(value);
			}
		}

		// Token: 0x17001E43 RID: 7747
		// (get) Token: 0x06006030 RID: 24624 RVA: 0x000B7724 File Offset: 0x000B5924
		// (set) Token: 0x06006031 RID: 24625 RVA: 0x000B7744 File Offset: 0x000B5944
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
					this._id = (value ? new int?(this.id) : null);
				}
			}
		}

		// Token: 0x06006032 RID: 24626 RVA: 0x000B7788 File Offset: 0x000B5988
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06006033 RID: 24627 RVA: 0x000B77A0 File Offset: 0x000B59A0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001E44 RID: 7748
		// (get) Token: 0x06006034 RID: 24628 RVA: 0x000B77AC File Offset: 0x000B59AC
		// (set) Token: 0x06006035 RID: 24629 RVA: 0x000B77D8 File Offset: 0x000B59D8
		[ProtoMember(2, IsRequired = false, Name = "lastGetAwardTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastGetAwardTime
		{
			get
			{
				return this._lastGetAwardTime ?? 0U;
			}
			set
			{
				this._lastGetAwardTime = new uint?(value);
			}
		}

		// Token: 0x17001E45 RID: 7749
		// (get) Token: 0x06006036 RID: 24630 RVA: 0x000B77E8 File Offset: 0x000B59E8
		// (set) Token: 0x06006037 RID: 24631 RVA: 0x000B7808 File Offset: 0x000B5A08
		[XmlIgnore]
		[Browsable(false)]
		public bool lastGetAwardTimeSpecified
		{
			get
			{
				return this._lastGetAwardTime != null;
			}
			set
			{
				bool flag = value == (this._lastGetAwardTime == null);
				if (flag)
				{
					this._lastGetAwardTime = (value ? new uint?(this.lastGetAwardTime) : null);
				}
			}
		}

		// Token: 0x06006038 RID: 24632 RVA: 0x000B784C File Offset: 0x000B5A4C
		private bool ShouldSerializelastGetAwardTime()
		{
			return this.lastGetAwardTimeSpecified;
		}

		// Token: 0x06006039 RID: 24633 RVA: 0x000B7864 File Offset: 0x000B5A64
		private void ResetlastGetAwardTime()
		{
			this.lastGetAwardTimeSpecified = false;
		}

		// Token: 0x0600603A RID: 24634 RVA: 0x000B7870 File Offset: 0x000B5A70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400175D RID: 5981
		private int? _id;

		// Token: 0x0400175E RID: 5982
		private uint? _lastGetAwardTime;

		// Token: 0x0400175F RID: 5983
		private IExtension extensionObject;
	}
}
