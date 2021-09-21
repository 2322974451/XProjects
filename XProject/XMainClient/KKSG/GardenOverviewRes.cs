using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000277 RID: 631
	[ProtoContract(Name = "GardenOverviewRes")]
	[Serializable]
	public class GardenOverviewRes : IExtensible
	{
		// Token: 0x17000AE2 RID: 2786
		// (get) Token: 0x06002303 RID: 8963 RVA: 0x000445F8 File Offset: 0x000427F8
		// (set) Token: 0x06002304 RID: 8964 RVA: 0x00044624 File Offset: 0x00042824
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000AE3 RID: 2787
		// (get) Token: 0x06002305 RID: 8965 RVA: 0x00044634 File Offset: 0x00042834
		// (set) Token: 0x06002306 RID: 8966 RVA: 0x00044654 File Offset: 0x00042854
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06002307 RID: 8967 RVA: 0x00044698 File Offset: 0x00042898
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002308 RID: 8968 RVA: 0x000446B0 File Offset: 0x000428B0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000AE4 RID: 2788
		// (get) Token: 0x06002309 RID: 8969 RVA: 0x000446BC File Offset: 0x000428BC
		// (set) Token: 0x0600230A RID: 8970 RVA: 0x000446E8 File Offset: 0x000428E8
		[ProtoMember(2, IsRequired = false, Name = "visited_times", DataFormat = DataFormat.TwosComplement)]
		public uint visited_times
		{
			get
			{
				return this._visited_times ?? 0U;
			}
			set
			{
				this._visited_times = new uint?(value);
			}
		}

		// Token: 0x17000AE5 RID: 2789
		// (get) Token: 0x0600230B RID: 8971 RVA: 0x000446F8 File Offset: 0x000428F8
		// (set) Token: 0x0600230C RID: 8972 RVA: 0x00044718 File Offset: 0x00042918
		[XmlIgnore]
		[Browsable(false)]
		public bool visited_timesSpecified
		{
			get
			{
				return this._visited_times != null;
			}
			set
			{
				bool flag = value == (this._visited_times == null);
				if (flag)
				{
					this._visited_times = (value ? new uint?(this.visited_times) : null);
				}
			}
		}

		// Token: 0x0600230D RID: 8973 RVA: 0x0004475C File Offset: 0x0004295C
		private bool ShouldSerializevisited_times()
		{
			return this.visited_timesSpecified;
		}

		// Token: 0x0600230E RID: 8974 RVA: 0x00044774 File Offset: 0x00042974
		private void Resetvisited_times()
		{
			this.visited_timesSpecified = false;
		}

		// Token: 0x17000AE6 RID: 2790
		// (get) Token: 0x0600230F RID: 8975 RVA: 0x00044780 File Offset: 0x00042980
		// (set) Token: 0x06002310 RID: 8976 RVA: 0x000447AC File Offset: 0x000429AC
		[ProtoMember(3, IsRequired = false, Name = "fish_level", DataFormat = DataFormat.TwosComplement)]
		public uint fish_level
		{
			get
			{
				return this._fish_level ?? 0U;
			}
			set
			{
				this._fish_level = new uint?(value);
			}
		}

		// Token: 0x17000AE7 RID: 2791
		// (get) Token: 0x06002311 RID: 8977 RVA: 0x000447BC File Offset: 0x000429BC
		// (set) Token: 0x06002312 RID: 8978 RVA: 0x000447DC File Offset: 0x000429DC
		[XmlIgnore]
		[Browsable(false)]
		public bool fish_levelSpecified
		{
			get
			{
				return this._fish_level != null;
			}
			set
			{
				bool flag = value == (this._fish_level == null);
				if (flag)
				{
					this._fish_level = (value ? new uint?(this.fish_level) : null);
				}
			}
		}

		// Token: 0x06002313 RID: 8979 RVA: 0x00044820 File Offset: 0x00042A20
		private bool ShouldSerializefish_level()
		{
			return this.fish_levelSpecified;
		}

		// Token: 0x06002314 RID: 8980 RVA: 0x00044838 File Offset: 0x00042A38
		private void Resetfish_level()
		{
			this.fish_levelSpecified = false;
		}

		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x06002315 RID: 8981 RVA: 0x00044844 File Offset: 0x00042A44
		// (set) Token: 0x06002316 RID: 8982 RVA: 0x00044870 File Offset: 0x00042A70
		[ProtoMember(4, IsRequired = false, Name = "fish_experiences", DataFormat = DataFormat.TwosComplement)]
		public uint fish_experiences
		{
			get
			{
				return this._fish_experiences ?? 0U;
			}
			set
			{
				this._fish_experiences = new uint?(value);
			}
		}

		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x06002317 RID: 8983 RVA: 0x00044880 File Offset: 0x00042A80
		// (set) Token: 0x06002318 RID: 8984 RVA: 0x000448A0 File Offset: 0x00042AA0
		[XmlIgnore]
		[Browsable(false)]
		public bool fish_experiencesSpecified
		{
			get
			{
				return this._fish_experiences != null;
			}
			set
			{
				bool flag = value == (this._fish_experiences == null);
				if (flag)
				{
					this._fish_experiences = (value ? new uint?(this.fish_experiences) : null);
				}
			}
		}

		// Token: 0x06002319 RID: 8985 RVA: 0x000448E4 File Offset: 0x00042AE4
		private bool ShouldSerializefish_experiences()
		{
			return this.fish_experiencesSpecified;
		}

		// Token: 0x0600231A RID: 8986 RVA: 0x000448FC File Offset: 0x00042AFC
		private void Resetfish_experiences()
		{
			this.fish_experiencesSpecified = false;
		}

		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x0600231B RID: 8987 RVA: 0x00044908 File Offset: 0x00042B08
		// (set) Token: 0x0600231C RID: 8988 RVA: 0x00044934 File Offset: 0x00042B34
		[ProtoMember(5, IsRequired = false, Name = "cooking_level", DataFormat = DataFormat.TwosComplement)]
		public uint cooking_level
		{
			get
			{
				return this._cooking_level ?? 0U;
			}
			set
			{
				this._cooking_level = new uint?(value);
			}
		}

		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x0600231D RID: 8989 RVA: 0x00044944 File Offset: 0x00042B44
		// (set) Token: 0x0600231E RID: 8990 RVA: 0x00044964 File Offset: 0x00042B64
		[XmlIgnore]
		[Browsable(false)]
		public bool cooking_levelSpecified
		{
			get
			{
				return this._cooking_level != null;
			}
			set
			{
				bool flag = value == (this._cooking_level == null);
				if (flag)
				{
					this._cooking_level = (value ? new uint?(this.cooking_level) : null);
				}
			}
		}

		// Token: 0x0600231F RID: 8991 RVA: 0x000449A8 File Offset: 0x00042BA8
		private bool ShouldSerializecooking_level()
		{
			return this.cooking_levelSpecified;
		}

		// Token: 0x06002320 RID: 8992 RVA: 0x000449C0 File Offset: 0x00042BC0
		private void Resetcooking_level()
		{
			this.cooking_levelSpecified = false;
		}

		// Token: 0x17000AEC RID: 2796
		// (get) Token: 0x06002321 RID: 8993 RVA: 0x000449CC File Offset: 0x00042BCC
		// (set) Token: 0x06002322 RID: 8994 RVA: 0x000449F8 File Offset: 0x00042BF8
		[ProtoMember(6, IsRequired = false, Name = "cooking_experiences", DataFormat = DataFormat.TwosComplement)]
		public uint cooking_experiences
		{
			get
			{
				return this._cooking_experiences ?? 0U;
			}
			set
			{
				this._cooking_experiences = new uint?(value);
			}
		}

		// Token: 0x17000AED RID: 2797
		// (get) Token: 0x06002323 RID: 8995 RVA: 0x00044A08 File Offset: 0x00042C08
		// (set) Token: 0x06002324 RID: 8996 RVA: 0x00044A28 File Offset: 0x00042C28
		[XmlIgnore]
		[Browsable(false)]
		public bool cooking_experiencesSpecified
		{
			get
			{
				return this._cooking_experiences != null;
			}
			set
			{
				bool flag = value == (this._cooking_experiences == null);
				if (flag)
				{
					this._cooking_experiences = (value ? new uint?(this.cooking_experiences) : null);
				}
			}
		}

		// Token: 0x06002325 RID: 8997 RVA: 0x00044A6C File Offset: 0x00042C6C
		private bool ShouldSerializecooking_experiences()
		{
			return this.cooking_experiencesSpecified;
		}

		// Token: 0x06002326 RID: 8998 RVA: 0x00044A84 File Offset: 0x00042C84
		private void Resetcooking_experiences()
		{
			this.cooking_experiencesSpecified = false;
		}

		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x06002327 RID: 8999 RVA: 0x00044A90 File Offset: 0x00042C90
		// (set) Token: 0x06002328 RID: 9000 RVA: 0x00044ABC File Offset: 0x00042CBC
		[ProtoMember(7, IsRequired = false, Name = "plant_amount", DataFormat = DataFormat.TwosComplement)]
		public uint plant_amount
		{
			get
			{
				return this._plant_amount ?? 0U;
			}
			set
			{
				this._plant_amount = new uint?(value);
			}
		}

		// Token: 0x17000AEF RID: 2799
		// (get) Token: 0x06002329 RID: 9001 RVA: 0x00044ACC File Offset: 0x00042CCC
		// (set) Token: 0x0600232A RID: 9002 RVA: 0x00044AEC File Offset: 0x00042CEC
		[XmlIgnore]
		[Browsable(false)]
		public bool plant_amountSpecified
		{
			get
			{
				return this._plant_amount != null;
			}
			set
			{
				bool flag = value == (this._plant_amount == null);
				if (flag)
				{
					this._plant_amount = (value ? new uint?(this.plant_amount) : null);
				}
			}
		}

		// Token: 0x0600232B RID: 9003 RVA: 0x00044B30 File Offset: 0x00042D30
		private bool ShouldSerializeplant_amount()
		{
			return this.plant_amountSpecified;
		}

		// Token: 0x0600232C RID: 9004 RVA: 0x00044B48 File Offset: 0x00042D48
		private void Resetplant_amount()
		{
			this.plant_amountSpecified = false;
		}

		// Token: 0x17000AF0 RID: 2800
		// (get) Token: 0x0600232D RID: 9005 RVA: 0x00044B54 File Offset: 0x00042D54
		[ProtoMember(8, Name = "friend_log", DataFormat = DataFormat.Default)]
		public List<FriendPlantLog> friend_log
		{
			get
			{
				return this._friend_log;
			}
		}

		// Token: 0x17000AF1 RID: 2801
		// (get) Token: 0x0600232E RID: 9006 RVA: 0x00044B6C File Offset: 0x00042D6C
		[ProtoMember(9, Name = "event_log", DataFormat = DataFormat.Default)]
		public List<GardenEventLog> event_log
		{
			get
			{
				return this._event_log;
			}
		}

		// Token: 0x17000AF2 RID: 2802
		// (get) Token: 0x0600232F RID: 9007 RVA: 0x00044B84 File Offset: 0x00042D84
		[ProtoMember(10, Name = "plant_info", DataFormat = DataFormat.Default)]
		public List<PlantInfo> plant_info
		{
			get
			{
				return this._plant_info;
			}
		}

		// Token: 0x17000AF3 RID: 2803
		// (get) Token: 0x06002330 RID: 9008 RVA: 0x00044B9C File Offset: 0x00042D9C
		[ProtoMember(11, Name = "food_id", DataFormat = DataFormat.Default)]
		public List<MapIntItem> food_id
		{
			get
			{
				return this._food_id;
			}
		}

		// Token: 0x17000AF4 RID: 2804
		// (get) Token: 0x06002331 RID: 9009 RVA: 0x00044BB4 File Offset: 0x00042DB4
		// (set) Token: 0x06002332 RID: 9010 RVA: 0x00044BE0 File Offset: 0x00042DE0
		[ProtoMember(12, IsRequired = false, Name = "server_time", DataFormat = DataFormat.TwosComplement)]
		public uint server_time
		{
			get
			{
				return this._server_time ?? 0U;
			}
			set
			{
				this._server_time = new uint?(value);
			}
		}

		// Token: 0x17000AF5 RID: 2805
		// (get) Token: 0x06002333 RID: 9011 RVA: 0x00044BF0 File Offset: 0x00042DF0
		// (set) Token: 0x06002334 RID: 9012 RVA: 0x00044C10 File Offset: 0x00042E10
		[XmlIgnore]
		[Browsable(false)]
		public bool server_timeSpecified
		{
			get
			{
				return this._server_time != null;
			}
			set
			{
				bool flag = value == (this._server_time == null);
				if (flag)
				{
					this._server_time = (value ? new uint?(this.server_time) : null);
				}
			}
		}

		// Token: 0x06002335 RID: 9013 RVA: 0x00044C54 File Offset: 0x00042E54
		private bool ShouldSerializeserver_time()
		{
			return this.server_timeSpecified;
		}

		// Token: 0x06002336 RID: 9014 RVA: 0x00044C6C File Offset: 0x00042E6C
		private void Resetserver_time()
		{
			this.server_timeSpecified = false;
		}

		// Token: 0x17000AF6 RID: 2806
		// (get) Token: 0x06002337 RID: 9015 RVA: 0x00044C78 File Offset: 0x00042E78
		// (set) Token: 0x06002338 RID: 9016 RVA: 0x00044CA4 File Offset: 0x00042EA4
		[ProtoMember(13, IsRequired = false, Name = "plant_farmland_max", DataFormat = DataFormat.TwosComplement)]
		public uint plant_farmland_max
		{
			get
			{
				return this._plant_farmland_max ?? 0U;
			}
			set
			{
				this._plant_farmland_max = new uint?(value);
			}
		}

		// Token: 0x17000AF7 RID: 2807
		// (get) Token: 0x06002339 RID: 9017 RVA: 0x00044CB4 File Offset: 0x00042EB4
		// (set) Token: 0x0600233A RID: 9018 RVA: 0x00044CD4 File Offset: 0x00042ED4
		[XmlIgnore]
		[Browsable(false)]
		public bool plant_farmland_maxSpecified
		{
			get
			{
				return this._plant_farmland_max != null;
			}
			set
			{
				bool flag = value == (this._plant_farmland_max == null);
				if (flag)
				{
					this._plant_farmland_max = (value ? new uint?(this.plant_farmland_max) : null);
				}
			}
		}

		// Token: 0x0600233B RID: 9019 RVA: 0x00044D18 File Offset: 0x00042F18
		private bool ShouldSerializeplant_farmland_max()
		{
			return this.plant_farmland_maxSpecified;
		}

		// Token: 0x0600233C RID: 9020 RVA: 0x00044D30 File Offset: 0x00042F30
		private void Resetplant_farmland_max()
		{
			this.plant_farmland_maxSpecified = false;
		}

		// Token: 0x17000AF8 RID: 2808
		// (get) Token: 0x0600233D RID: 9021 RVA: 0x00044D3C File Offset: 0x00042F3C
		// (set) Token: 0x0600233E RID: 9022 RVA: 0x00044D68 File Offset: 0x00042F68
		[ProtoMember(14, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
		public uint sprite_id
		{
			get
			{
				return this._sprite_id ?? 0U;
			}
			set
			{
				this._sprite_id = new uint?(value);
			}
		}

		// Token: 0x17000AF9 RID: 2809
		// (get) Token: 0x0600233F RID: 9023 RVA: 0x00044D78 File Offset: 0x00042F78
		// (set) Token: 0x06002340 RID: 9024 RVA: 0x00044D98 File Offset: 0x00042F98
		[XmlIgnore]
		[Browsable(false)]
		public bool sprite_idSpecified
		{
			get
			{
				return this._sprite_id != null;
			}
			set
			{
				bool flag = value == (this._sprite_id == null);
				if (flag)
				{
					this._sprite_id = (value ? new uint?(this.sprite_id) : null);
				}
			}
		}

		// Token: 0x06002341 RID: 9025 RVA: 0x00044DDC File Offset: 0x00042FDC
		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		// Token: 0x06002342 RID: 9026 RVA: 0x00044DF4 File Offset: 0x00042FF4
		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		// Token: 0x06002343 RID: 9027 RVA: 0x00044E00 File Offset: 0x00043000
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008B1 RID: 2225
		private ErrorCode? _result;

		// Token: 0x040008B2 RID: 2226
		private uint? _visited_times;

		// Token: 0x040008B3 RID: 2227
		private uint? _fish_level;

		// Token: 0x040008B4 RID: 2228
		private uint? _fish_experiences;

		// Token: 0x040008B5 RID: 2229
		private uint? _cooking_level;

		// Token: 0x040008B6 RID: 2230
		private uint? _cooking_experiences;

		// Token: 0x040008B7 RID: 2231
		private uint? _plant_amount;

		// Token: 0x040008B8 RID: 2232
		private readonly List<FriendPlantLog> _friend_log = new List<FriendPlantLog>();

		// Token: 0x040008B9 RID: 2233
		private readonly List<GardenEventLog> _event_log = new List<GardenEventLog>();

		// Token: 0x040008BA RID: 2234
		private readonly List<PlantInfo> _plant_info = new List<PlantInfo>();

		// Token: 0x040008BB RID: 2235
		private readonly List<MapIntItem> _food_id = new List<MapIntItem>();

		// Token: 0x040008BC RID: 2236
		private uint? _server_time;

		// Token: 0x040008BD RID: 2237
		private uint? _plant_farmland_max;

		// Token: 0x040008BE RID: 2238
		private uint? _sprite_id;

		// Token: 0x040008BF RID: 2239
		private IExtension extensionObject;
	}
}
