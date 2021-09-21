using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000200 RID: 512
	[ProtoContract(Name = "SpriteOperationArg")]
	[Serializable]
	public class SpriteOperationArg : IExtensible
	{
		// Token: 0x17000912 RID: 2322
		// (get) Token: 0x06001CFC RID: 7420 RVA: 0x00039130 File Offset: 0x00037330
		// (set) Token: 0x06001CFD RID: 7421 RVA: 0x0003915C File Offset: 0x0003735C
		[ProtoMember(1, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public SpriteType Type
		{
			get
			{
				return this._Type ?? SpriteType.Sprite_Feed;
			}
			set
			{
				this._Type = new SpriteType?(value);
			}
		}

		// Token: 0x17000913 RID: 2323
		// (get) Token: 0x06001CFE RID: 7422 RVA: 0x0003916C File Offset: 0x0003736C
		// (set) Token: 0x06001CFF RID: 7423 RVA: 0x0003918C File Offset: 0x0003738C
		[XmlIgnore]
		[Browsable(false)]
		public bool TypeSpecified
		{
			get
			{
				return this._Type != null;
			}
			set
			{
				bool flag = value == (this._Type == null);
				if (flag)
				{
					this._Type = (value ? new SpriteType?(this.Type) : null);
				}
			}
		}

		// Token: 0x06001D00 RID: 7424 RVA: 0x000391D0 File Offset: 0x000373D0
		private bool ShouldSerializeType()
		{
			return this.TypeSpecified;
		}

		// Token: 0x06001D01 RID: 7425 RVA: 0x000391E8 File Offset: 0x000373E8
		private void ResetType()
		{
			this.TypeSpecified = false;
		}

		// Token: 0x17000914 RID: 2324
		// (get) Token: 0x06001D02 RID: 7426 RVA: 0x000391F4 File Offset: 0x000373F4
		// (set) Token: 0x06001D03 RID: 7427 RVA: 0x00039221 File Offset: 0x00037421
		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000915 RID: 2325
		// (get) Token: 0x06001D04 RID: 7428 RVA: 0x00039230 File Offset: 0x00037430
		// (set) Token: 0x06001D05 RID: 7429 RVA: 0x00039250 File Offset: 0x00037450
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

		// Token: 0x06001D06 RID: 7430 RVA: 0x00039294 File Offset: 0x00037494
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06001D07 RID: 7431 RVA: 0x000392AC File Offset: 0x000374AC
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17000916 RID: 2326
		// (get) Token: 0x06001D08 RID: 7432 RVA: 0x000392B8 File Offset: 0x000374B8
		// (set) Token: 0x06001D09 RID: 7433 RVA: 0x000392E4 File Offset: 0x000374E4
		[ProtoMember(3, IsRequired = false, Name = "FeedItemID", DataFormat = DataFormat.TwosComplement)]
		public uint FeedItemID
		{
			get
			{
				return this._FeedItemID ?? 0U;
			}
			set
			{
				this._FeedItemID = new uint?(value);
			}
		}

		// Token: 0x17000917 RID: 2327
		// (get) Token: 0x06001D0A RID: 7434 RVA: 0x000392F4 File Offset: 0x000374F4
		// (set) Token: 0x06001D0B RID: 7435 RVA: 0x00039314 File Offset: 0x00037514
		[XmlIgnore]
		[Browsable(false)]
		public bool FeedItemIDSpecified
		{
			get
			{
				return this._FeedItemID != null;
			}
			set
			{
				bool flag = value == (this._FeedItemID == null);
				if (flag)
				{
					this._FeedItemID = (value ? new uint?(this.FeedItemID) : null);
				}
			}
		}

		// Token: 0x06001D0C RID: 7436 RVA: 0x00039358 File Offset: 0x00037558
		private bool ShouldSerializeFeedItemID()
		{
			return this.FeedItemIDSpecified;
		}

		// Token: 0x06001D0D RID: 7437 RVA: 0x00039370 File Offset: 0x00037570
		private void ResetFeedItemID()
		{
			this.FeedItemIDSpecified = false;
		}

		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x06001D0E RID: 7438 RVA: 0x0003937C File Offset: 0x0003757C
		[ProtoMember(4, Name = "uids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uids
		{
			get
			{
				return this._uids;
			}
		}

		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x06001D0F RID: 7439 RVA: 0x00039394 File Offset: 0x00037594
		[ProtoMember(5, Name = "notToChoose", DataFormat = DataFormat.TwosComplement)]
		public List<uint> notToChoose
		{
			get
			{
				return this._notToChoose;
			}
		}

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x06001D10 RID: 7440 RVA: 0x000393AC File Offset: 0x000375AC
		// (set) Token: 0x06001D11 RID: 7441 RVA: 0x000393D8 File Offset: 0x000375D8
		[ProtoMember(6, IsRequired = false, Name = "resetTrainChoose", DataFormat = DataFormat.TwosComplement)]
		public uint resetTrainChoose
		{
			get
			{
				return this._resetTrainChoose ?? 0U;
			}
			set
			{
				this._resetTrainChoose = new uint?(value);
			}
		}

		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x06001D12 RID: 7442 RVA: 0x000393E8 File Offset: 0x000375E8
		// (set) Token: 0x06001D13 RID: 7443 RVA: 0x00039408 File Offset: 0x00037608
		[XmlIgnore]
		[Browsable(false)]
		public bool resetTrainChooseSpecified
		{
			get
			{
				return this._resetTrainChoose != null;
			}
			set
			{
				bool flag = value == (this._resetTrainChoose == null);
				if (flag)
				{
					this._resetTrainChoose = (value ? new uint?(this.resetTrainChoose) : null);
				}
			}
		}

		// Token: 0x06001D14 RID: 7444 RVA: 0x0003944C File Offset: 0x0003764C
		private bool ShouldSerializeresetTrainChoose()
		{
			return this.resetTrainChooseSpecified;
		}

		// Token: 0x06001D15 RID: 7445 RVA: 0x00039464 File Offset: 0x00037664
		private void ResetresetTrainChoose()
		{
			this.resetTrainChooseSpecified = false;
		}

		// Token: 0x06001D16 RID: 7446 RVA: 0x00039470 File Offset: 0x00037670
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400073A RID: 1850
		private SpriteType? _Type;

		// Token: 0x0400073B RID: 1851
		private ulong? _uid;

		// Token: 0x0400073C RID: 1852
		private uint? _FeedItemID;

		// Token: 0x0400073D RID: 1853
		private readonly List<ulong> _uids = new List<ulong>();

		// Token: 0x0400073E RID: 1854
		private readonly List<uint> _notToChoose = new List<uint>();

		// Token: 0x0400073F RID: 1855
		private uint? _resetTrainChoose;

		// Token: 0x04000740 RID: 1856
		private IExtension extensionObject;
	}
}
