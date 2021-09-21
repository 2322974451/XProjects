using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005AC RID: 1452
	[ProtoContract(Name = "FashionData")]
	[Serializable]
	public class FashionData : IExtensible
	{
		// Token: 0x1700184C RID: 6220
		// (get) Token: 0x06004EC1 RID: 20161 RVA: 0x00095C84 File Offset: 0x00093E84
		// (set) Token: 0x06004EC2 RID: 20162 RVA: 0x00095CB0 File Offset: 0x00093EB0
		[ProtoMember(1, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public uint itemID
		{
			get
			{
				return this._itemID ?? 0U;
			}
			set
			{
				this._itemID = new uint?(value);
			}
		}

		// Token: 0x1700184D RID: 6221
		// (get) Token: 0x06004EC3 RID: 20163 RVA: 0x00095CC0 File Offset: 0x00093EC0
		// (set) Token: 0x06004EC4 RID: 20164 RVA: 0x00095CE0 File Offset: 0x00093EE0
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new uint?(this.itemID) : null);
				}
			}
		}

		// Token: 0x06004EC5 RID: 20165 RVA: 0x00095D24 File Offset: 0x00093F24
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x06004EC6 RID: 20166 RVA: 0x00095D3C File Offset: 0x00093F3C
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x1700184E RID: 6222
		// (get) Token: 0x06004EC7 RID: 20167 RVA: 0x00095D48 File Offset: 0x00093F48
		// (set) Token: 0x06004EC8 RID: 20168 RVA: 0x00095D74 File Offset: 0x00093F74
		[ProtoMember(2, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x1700184F RID: 6223
		// (get) Token: 0x06004EC9 RID: 20169 RVA: 0x00095D84 File Offset: 0x00093F84
		// (set) Token: 0x06004ECA RID: 20170 RVA: 0x00095DA4 File Offset: 0x00093FA4
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06004ECB RID: 20171 RVA: 0x00095DE8 File Offset: 0x00093FE8
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06004ECC RID: 20172 RVA: 0x00095E00 File Offset: 0x00094000
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17001850 RID: 6224
		// (get) Token: 0x06004ECD RID: 20173 RVA: 0x00095E0C File Offset: 0x0009400C
		// (set) Token: 0x06004ECE RID: 20174 RVA: 0x00095E39 File Offset: 0x00094039
		[ProtoMember(3, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001851 RID: 6225
		// (get) Token: 0x06004ECF RID: 20175 RVA: 0x00095E48 File Offset: 0x00094048
		// (set) Token: 0x06004ED0 RID: 20176 RVA: 0x00095E68 File Offset: 0x00094068
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

		// Token: 0x06004ED1 RID: 20177 RVA: 0x00095EAC File Offset: 0x000940AC
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06004ED2 RID: 20178 RVA: 0x00095EC4 File Offset: 0x000940C4
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17001852 RID: 6226
		// (get) Token: 0x06004ED3 RID: 20179 RVA: 0x00095ED0 File Offset: 0x000940D0
		// (set) Token: 0x06004ED4 RID: 20180 RVA: 0x00095EFC File Offset: 0x000940FC
		[ProtoMember(4, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		// Token: 0x17001853 RID: 6227
		// (get) Token: 0x06004ED5 RID: 20181 RVA: 0x00095F0C File Offset: 0x0009410C
		// (set) Token: 0x06004ED6 RID: 20182 RVA: 0x00095F2C File Offset: 0x0009412C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x06004ED7 RID: 20183 RVA: 0x00095F70 File Offset: 0x00094170
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x06004ED8 RID: 20184 RVA: 0x00095F88 File Offset: 0x00094188
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x17001854 RID: 6228
		// (get) Token: 0x06004ED9 RID: 20185 RVA: 0x00095F94 File Offset: 0x00094194
		// (set) Token: 0x06004EDA RID: 20186 RVA: 0x00095FC0 File Offset: 0x000941C0
		[ProtoMember(5, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public uint pos
		{
			get
			{
				return this._pos ?? 0U;
			}
			set
			{
				this._pos = new uint?(value);
			}
		}

		// Token: 0x17001855 RID: 6229
		// (get) Token: 0x06004EDB RID: 20187 RVA: 0x00095FD0 File Offset: 0x000941D0
		// (set) Token: 0x06004EDC RID: 20188 RVA: 0x00095FF0 File Offset: 0x000941F0
		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new uint?(this.pos) : null);
				}
			}
		}

		// Token: 0x06004EDD RID: 20189 RVA: 0x00096034 File Offset: 0x00094234
		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		// Token: 0x06004EDE RID: 20190 RVA: 0x0009604C File Offset: 0x0009424C
		private void Resetpos()
		{
			this.posSpecified = false;
		}

		// Token: 0x17001856 RID: 6230
		// (get) Token: 0x06004EDF RID: 20191 RVA: 0x00096058 File Offset: 0x00094258
		[ProtoMember(6, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		// Token: 0x17001857 RID: 6231
		// (get) Token: 0x06004EE0 RID: 20192 RVA: 0x00096070 File Offset: 0x00094270
		// (set) Token: 0x06004EE1 RID: 20193 RVA: 0x0009609C File Offset: 0x0009429C
		[ProtoMember(7, IsRequired = false, Name = "timeend", DataFormat = DataFormat.TwosComplement)]
		public uint timeend
		{
			get
			{
				return this._timeend ?? 0U;
			}
			set
			{
				this._timeend = new uint?(value);
			}
		}

		// Token: 0x17001858 RID: 6232
		// (get) Token: 0x06004EE2 RID: 20194 RVA: 0x000960AC File Offset: 0x000942AC
		// (set) Token: 0x06004EE3 RID: 20195 RVA: 0x000960CC File Offset: 0x000942CC
		[XmlIgnore]
		[Browsable(false)]
		public bool timeendSpecified
		{
			get
			{
				return this._timeend != null;
			}
			set
			{
				bool flag = value == (this._timeend == null);
				if (flag)
				{
					this._timeend = (value ? new uint?(this.timeend) : null);
				}
			}
		}

		// Token: 0x06004EE4 RID: 20196 RVA: 0x00096110 File Offset: 0x00094310
		private bool ShouldSerializetimeend()
		{
			return this.timeendSpecified;
		}

		// Token: 0x06004EE5 RID: 20197 RVA: 0x00096128 File Offset: 0x00094328
		private void Resettimeend()
		{
			this.timeendSpecified = false;
		}

		// Token: 0x06004EE6 RID: 20198 RVA: 0x00096134 File Offset: 0x00094334
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001377 RID: 4983
		private uint? _itemID;

		// Token: 0x04001378 RID: 4984
		private uint? _level;

		// Token: 0x04001379 RID: 4985
		private ulong? _uid;

		// Token: 0x0400137A RID: 4986
		private uint? _timeleft;

		// Token: 0x0400137B RID: 4987
		private uint? _pos;

		// Token: 0x0400137C RID: 4988
		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		// Token: 0x0400137D RID: 4989
		private uint? _timeend;

		// Token: 0x0400137E RID: 4990
		private IExtension extensionObject;
	}
}
