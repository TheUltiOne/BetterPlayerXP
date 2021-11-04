namespace PlayerXP
{
	public class PlayerInfo
	{
		public string Name { get; set; }
		public int Level { get; set; } = 1;
		public int XP { get; set; } = PlayerXP.instance.Config.XpInitial;
		public float Karma = PlayerXP.instance.Config.KarmaInitial;

		public PlayerInfo(string name)
		{
			Name = name;
		}
	}
}
