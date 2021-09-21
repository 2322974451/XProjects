using System;

namespace XUtliPoolLib
{
	// Token: 0x02000054 RID: 84
	public interface IApolloManager
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060002BB RID: 699
		// (set) Token: 0x060002BC RID: 700
		bool openMusic { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060002BD RID: 701
		// (set) Token: 0x060002BE RID: 702
		bool openSpeak { get; set; }

		// Token: 0x060002BF RID: 703
		void Init(int channel, string openid);

		// Token: 0x060002C0 RID: 704
		void SetRealtimeMode();

		// Token: 0x060002C1 RID: 705
		void ForbitMember(int memberId, bool bEnable);

		// Token: 0x060002C2 RID: 706
		void JoinRoom(string url1, string url2, string url3, long roomId, long roomKey, short memberId);

		// Token: 0x060002C3 RID: 707
		void JoinBigRoom(string urls, int role, uint busniessID, long roomid, long roomkey, short memberid);

		// Token: 0x060002C4 RID: 708
		bool GetJoinRoomResult();

		// Token: 0x060002C5 RID: 709
		bool GetJoinRoomBigResult();

		// Token: 0x060002C6 RID: 710
		int[] GetMembersState(ref int size);

		// Token: 0x060002C7 RID: 711
		void QuitRoom(long roomId, short memberId);

		// Token: 0x060002C8 RID: 712
		void QuitBigRoom();

		// Token: 0x060002C9 RID: 713
		int GetSpeakerVolume();

		// Token: 0x060002CA RID: 714
		void SetMusicVolum(int nVol);

		// Token: 0x060002CB RID: 715
		int InitApolloEngine(int ip1, int ip2, int ip3, int ip4, byte[] key, int len);

		// Token: 0x060002CC RID: 716
		int StartRecord(string filename);

		// Token: 0x060002CD RID: 717
		int StopApolloRecord();

		// Token: 0x060002CE RID: 718
		int GetApolloUploadStatus();

		// Token: 0x060002CF RID: 719
		int UploadRecordFile(string filename);

		// Token: 0x060002D0 RID: 720
		string GetFileID();

		// Token: 0x060002D1 RID: 721
		int GetMicLevel();

		// Token: 0x060002D2 RID: 722
		int StartPlayVoice(string filepath);

		// Token: 0x060002D3 RID: 723
		int StopPlayVoice();

		// Token: 0x060002D4 RID: 724
		int SetApolloMode(int mode);
	}
}
