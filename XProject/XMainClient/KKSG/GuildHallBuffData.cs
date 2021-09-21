using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000743 RID: 1859
	[ProtoContract(Name = "GuildHallBuffData")]
	[Serializable]
	public class GuildHallBuffData : IExtensible
	{
		// Token: 0x17002913 RID: 10515
		// (get) Token: 0x0600818B RID: 33163 RVA: 0x000F7C40 File Offset: 0x000F5E40
		// (set) Token: 0x0600818C RID: 33164 RVA: 0x000F7C6C File Offset: 0x000F5E6C
		[ProtoMember(1, IsRequired = false, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public uint buffid
		{
			get
			{
				return this._buffid ?? 0U;
			}
			set
			{
				this._buffid = new uint?(value);
			}
		}

		// Token: 0x17002914 RID: 10516
		// (get) Token: 0x0600818D RID: 33165 RVA: 0x000F7C7C File Offset: 0x000F5E7C
		// (set) Token: 0x0600818E RID: 33166 RVA: 0x000F7C9C File Offset: 0x000F5E9C
		[XmlIgnore]
		[Browsable(false)]
		public bool buffidSpecified
		{
			get
			{
				return this._buffid != null;
			}
			set
			{
				bool flag = value == (this._buffid == null);
				if (flag)
				{
					this._buffid = (value ? new uint?(this.buffid) : null);
				}
			}
		}

		// Token: 0x0600818F RID: 33167 RVA: 0x000F7CE0 File Offset: 0x000F5EE0
		private bool ShouldSerializebuffid()
		{
			return this.buffidSpecified;
		}

		// Token: 0x06008190 RID: 33168 RVA: 0x000F7CF8 File Offset: 0x000F5EF8
		private void Resetbuffid()
		{
			this.buffidSpecified = false;
		}

		// Token: 0x17002915 RID: 10517
		// (get) Token: 0x06008191 RID: 33169 RVA: 0x000F7D04 File Offset: 0x000F5F04
		// (set) Token: 0x06008192 RID: 33170 RVA: 0x000F7D30 File Offset: 0x000F5F30
		[ProtoMember(2, IsRequired = false, Name = "maxlevel", DataFormat = DataFormat.TwosComplement)]
		public uint maxlevel
		{
			get
			{
				return this._maxlevel ?? 0U;
			}
			set
			{
				this._maxlevel = new uint?(value);
			}
		}

		// Token: 0x17002916 RID: 10518
		// (get) Token: 0x06008193 RID: 33171 RVA: 0x000F7D40 File Offset: 0x000F5F40
		// (set) Token: 0x06008194 RID: 33172 RVA: 0x000F7D60 File Offset: 0x000F5F60
		[XmlIgnore]
		[Browsable(false)]
		public bool maxlevelSpecified
		{
			get
			{
				return this._maxlevel != null;
			}
			set
			{
				bool flag = value == (this._maxlevel == null);
				if (flag)
				{
					this._maxlevel = (value ? new uint?(this.maxlevel) : null);
				}
			}
		}

		// Token: 0x06008195 RID: 33173 RVA: 0x000F7DA4 File Offset: 0x000F5FA4
		private bool ShouldSerializemaxlevel()
		{
			return this.maxlevelSpecified;
		}

		// Token: 0x06008196 RID: 33174 RVA: 0x000F7DBC File Offset: 0x000F5FBC
		private void Resetmaxlevel()
		{
			this.maxlevelSpecified = false;
		}

		// Token: 0x17002917 RID: 10519
		// (get) Token: 0x06008197 RID: 33175 RVA: 0x000F7DC8 File Offset: 0x000F5FC8
		// (set) Token: 0x06008198 RID: 33176 RVA: 0x000F7DF4 File Offset: 0x000F5FF4
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002918 RID: 10520
		// (get) Token: 0x06008199 RID: 33177 RVA: 0x000F7E04 File Offset: 0x000F6004
		// (set) Token: 0x0600819A RID: 33178 RVA: 0x000F7E24 File Offset: 0x000F6024
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

		// Token: 0x0600819B RID: 33179 RVA: 0x000F7E68 File Offset: 0x000F6068
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x0600819C RID: 33180 RVA: 0x000F7E80 File Offset: 0x000F6080
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17002919 RID: 10521
		// (get) Token: 0x0600819D RID: 33181 RVA: 0x000F7E8C File Offset: 0x000F608C
		// (set) Token: 0x0600819E RID: 33182 RVA: 0x000F7EB8 File Offset: 0x000F60B8
		[ProtoMember(4, IsRequired = false, Name = "isenable", DataFormat = DataFormat.Default)]
		public bool isenable
		{
			get
			{
				return this._isenable ?? false;
			}
			set
			{
				this._isenable = new bool?(value);
			}
		}

		// Token: 0x1700291A RID: 10522
		// (get) Token: 0x0600819F RID: 33183 RVA: 0x000F7EC8 File Offset: 0x000F60C8
		// (set) Token: 0x060081A0 RID: 33184 RVA: 0x000F7EE8 File Offset: 0x000F60E8
		[XmlIgnore]
		[Browsable(false)]
		public bool isenableSpecified
		{
			get
			{
				return this._isenable != null;
			}
			set
			{
				bool flag = value == (this._isenable == null);
				if (flag)
				{
					this._isenable = (value ? new bool?(this.isenable) : null);
				}
			}
		}

		// Token: 0x060081A1 RID: 33185 RVA: 0x000F7F2C File Offset: 0x000F612C
		private bool ShouldSerializeisenable()
		{
			return this.isenableSpecified;
		}

		// Token: 0x060081A2 RID: 33186 RVA: 0x000F7F44 File Offset: 0x000F6144
		private void Resetisenable()
		{
			this.isenableSpecified = false;
		}

		// Token: 0x1700291B RID: 10523
		// (get) Token: 0x060081A3 RID: 33187 RVA: 0x000F7F50 File Offset: 0x000F6150
		// (set) Token: 0x060081A4 RID: 33188 RVA: 0x000F7F7C File Offset: 0x000F617C
		[ProtoMember(5, IsRequired = false, Name = "dailybegintime", DataFormat = DataFormat.TwosComplement)]
		public uint dailybegintime
		{
			get
			{
				return this._dailybegintime ?? 0U;
			}
			set
			{
				this._dailybegintime = new uint?(value);
			}
		}

		// Token: 0x1700291C RID: 10524
		// (get) Token: 0x060081A5 RID: 33189 RVA: 0x000F7F8C File Offset: 0x000F618C
		// (set) Token: 0x060081A6 RID: 33190 RVA: 0x000F7FAC File Offset: 0x000F61AC
		[XmlIgnore]
		[Browsable(false)]
		public bool dailybegintimeSpecified
		{
			get
			{
				return this._dailybegintime != null;
			}
			set
			{
				bool flag = value == (this._dailybegintime == null);
				if (flag)
				{
					this._dailybegintime = (value ? new uint?(this.dailybegintime) : null);
				}
			}
		}

		// Token: 0x060081A7 RID: 33191 RVA: 0x000F7FF0 File Offset: 0x000F61F0
		private bool ShouldSerializedailybegintime()
		{
			return this.dailybegintimeSpecified;
		}

		// Token: 0x060081A8 RID: 33192 RVA: 0x000F8008 File Offset: 0x000F6208
		private void Resetdailybegintime()
		{
			this.dailybegintimeSpecified = false;
		}

		// Token: 0x060081A9 RID: 33193 RVA: 0x000F8014 File Offset: 0x000F6214
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E4F RID: 7759
		private uint? _buffid;

		// Token: 0x04001E50 RID: 7760
		private uint? _maxlevel;

		// Token: 0x04001E51 RID: 7761
		private uint? _level;

		// Token: 0x04001E52 RID: 7762
		private bool? _isenable;

		// Token: 0x04001E53 RID: 7763
		private uint? _dailybegintime;

		// Token: 0x04001E54 RID: 7764
		private IExtension extensionObject;
	}
}
