using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F9 RID: 1529
	[ProtoContract(Name = "RewardRecord")]
	[Serializable]
	public class RewardRecord : IExtensible
	{
		// Token: 0x17001C75 RID: 7285
		// (get) Token: 0x06005B04 RID: 23300 RVA: 0x000AD500 File Offset: 0x000AB700
		[ProtoMember(1, Name = "RewardInfo", DataFormat = DataFormat.Default)]
		public List<RewardInfo> RewardInfo
		{
			get
			{
				return this._RewardInfo;
			}
		}

		// Token: 0x17001C76 RID: 7286
		// (get) Token: 0x06005B05 RID: 23301 RVA: 0x000AD518 File Offset: 0x000AB718
		// (set) Token: 0x06005B06 RID: 23302 RVA: 0x000AD535 File Offset: 0x000AB735
		[ProtoMember(2, IsRequired = false, Name = "given", DataFormat = DataFormat.Default)]
		public byte[] given
		{
			get
			{
				return this._given ?? null;
			}
			set
			{
				this._given = value;
			}
		}

		// Token: 0x17001C77 RID: 7287
		// (get) Token: 0x06005B07 RID: 23303 RVA: 0x000AD540 File Offset: 0x000AB740
		// (set) Token: 0x06005B08 RID: 23304 RVA: 0x000AD55C File Offset: 0x000AB75C
		[XmlIgnore]
		[Browsable(false)]
		public bool givenSpecified
		{
			get
			{
				return this._given != null;
			}
			set
			{
				bool flag = value == (this._given == null);
				if (flag)
				{
					this._given = (value ? this.given : null);
				}
			}
		}

		// Token: 0x06005B09 RID: 23305 RVA: 0x000AD58C File Offset: 0x000AB78C
		private bool ShouldSerializegiven()
		{
			return this.givenSpecified;
		}

		// Token: 0x06005B0A RID: 23306 RVA: 0x000AD5A4 File Offset: 0x000AB7A4
		private void Resetgiven()
		{
			this.givenSpecified = false;
		}

		// Token: 0x17001C78 RID: 7288
		// (get) Token: 0x06005B0B RID: 23307 RVA: 0x000AD5B0 File Offset: 0x000AB7B0
		// (set) Token: 0x06005B0C RID: 23308 RVA: 0x000AD5CD File Offset: 0x000AB7CD
		[ProtoMember(3, IsRequired = false, Name = "taken", DataFormat = DataFormat.Default)]
		public byte[] taken
		{
			get
			{
				return this._taken ?? null;
			}
			set
			{
				this._taken = value;
			}
		}

		// Token: 0x17001C79 RID: 7289
		// (get) Token: 0x06005B0D RID: 23309 RVA: 0x000AD5D8 File Offset: 0x000AB7D8
		// (set) Token: 0x06005B0E RID: 23310 RVA: 0x000AD5F4 File Offset: 0x000AB7F4
		[XmlIgnore]
		[Browsable(false)]
		public bool takenSpecified
		{
			get
			{
				return this._taken != null;
			}
			set
			{
				bool flag = value == (this._taken == null);
				if (flag)
				{
					this._taken = (value ? this.taken : null);
				}
			}
		}

		// Token: 0x06005B0F RID: 23311 RVA: 0x000AD624 File Offset: 0x000AB824
		private bool ShouldSerializetaken()
		{
			return this.takenSpecified;
		}

		// Token: 0x06005B10 RID: 23312 RVA: 0x000AD63C File Offset: 0x000AB83C
		private void Resettaken()
		{
			this.takenSpecified = false;
		}

		// Token: 0x17001C7A RID: 7290
		// (get) Token: 0x06005B11 RID: 23313 RVA: 0x000AD648 File Offset: 0x000AB848
		// (set) Token: 0x06005B12 RID: 23314 RVA: 0x000AD674 File Offset: 0x000AB874
		[ProtoMember(4, IsRequired = false, Name = "nextdayreward", DataFormat = DataFormat.TwosComplement)]
		public uint nextdayreward
		{
			get
			{
				return this._nextdayreward ?? 0U;
			}
			set
			{
				this._nextdayreward = new uint?(value);
			}
		}

		// Token: 0x17001C7B RID: 7291
		// (get) Token: 0x06005B13 RID: 23315 RVA: 0x000AD684 File Offset: 0x000AB884
		// (set) Token: 0x06005B14 RID: 23316 RVA: 0x000AD6A4 File Offset: 0x000AB8A4
		[XmlIgnore]
		[Browsable(false)]
		public bool nextdayrewardSpecified
		{
			get
			{
				return this._nextdayreward != null;
			}
			set
			{
				bool flag = value == (this._nextdayreward == null);
				if (flag)
				{
					this._nextdayreward = (value ? new uint?(this.nextdayreward) : null);
				}
			}
		}

		// Token: 0x06005B15 RID: 23317 RVA: 0x000AD6E8 File Offset: 0x000AB8E8
		private bool ShouldSerializenextdayreward()
		{
			return this.nextdayrewardSpecified;
		}

		// Token: 0x06005B16 RID: 23318 RVA: 0x000AD700 File Offset: 0x000AB900
		private void Resetnextdayreward()
		{
			this.nextdayrewardSpecified = false;
		}

		// Token: 0x17001C7C RID: 7292
		// (get) Token: 0x06005B17 RID: 23319 RVA: 0x000AD70C File Offset: 0x000AB90C
		[ProtoMember(5, Name = "onlinereward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> onlinereward
		{
			get
			{
				return this._onlinereward;
			}
		}

		// Token: 0x06005B18 RID: 23320 RVA: 0x000AD724 File Offset: 0x000AB924
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001624 RID: 5668
		private readonly List<RewardInfo> _RewardInfo = new List<RewardInfo>();

		// Token: 0x04001625 RID: 5669
		private byte[] _given;

		// Token: 0x04001626 RID: 5670
		private byte[] _taken;

		// Token: 0x04001627 RID: 5671
		private uint? _nextdayreward;

		// Token: 0x04001628 RID: 5672
		private readonly List<uint> _onlinereward = new List<uint>();

		// Token: 0x04001629 RID: 5673
		private IExtension extensionObject;
	}
}
