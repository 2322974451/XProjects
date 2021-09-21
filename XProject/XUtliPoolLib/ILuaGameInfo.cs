using System;

namespace XUtliPoolLib
{
	// Token: 0x02000064 RID: 100
	public interface ILuaGameInfo
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000334 RID: 820
		// (set) Token: 0x06000335 RID: 821
		string name { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000336 RID: 822
		// (set) Token: 0x06000337 RID: 823
		uint exp { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000338 RID: 824
		// (set) Token: 0x06000339 RID: 825
		uint maxexp { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600033A RID: 826
		// (set) Token: 0x0600033B RID: 827
		uint level { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600033C RID: 828
		// (set) Token: 0x0600033D RID: 829
		int ppt { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600033E RID: 830
		// (set) Token: 0x0600033F RID: 831
		uint coin { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000340 RID: 832
		// (set) Token: 0x06000341 RID: 833
		uint dia { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000342 RID: 834
		// (set) Token: 0x06000343 RID: 835
		uint energy { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000344 RID: 836
		// (set) Token: 0x06000345 RID: 837
		uint draggon { get; set; }
	}
}
