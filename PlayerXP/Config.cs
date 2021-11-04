using System.Collections.Generic;
using Exiled.API.Interfaces;
using System.ComponentModel;
using System.Linq;
using Exiled.API.Features;

namespace PlayerXP
{
	public class Config : IConfig
	{
		// --- GENERAL SETTINGS ---

		[Description("Whether or not the plugin is enabled.")]
		public bool IsEnabled { get; set; } = true;

		[Description("Whether or not debug information should be output to the console.")]
		public bool IsDebug { get; set; } = false;

		[Description("Threat Tutorials as SCPs (Serpent's Hand Compatibilty).")]
		public bool IsSH { get; set; } = false;

		[Description("The amount of XP all players start with.")]
		public int XpInitial { get; set; } = 100;

		[Description("A global scaling factor for all XP values.")]
		public float XpScale { get; set; } = 1.0f;

		[Description("How much more XP it should take to get to the next level than the previous one.")]
		public int XpIncrement { get; set; } = 250;

		// --- KARMA ---

		[Description("If karma is enabled.")]
		public bool KarmaEnabled { get; set; } = true;

		[Description("If a player's karma can exceed the maximum karma until the maximum overflow karma when escorting a detained member of the opposing team.")]
		public bool KarmaOnlyOverflowOnDisarmedEscape { get; set; } = true;

		[Description("How much karma is lost when a player kills another player who doesn't have any weapons.")]
		public float KarmaLostOnDefenselessKill { get; set; } = 0.1f;

		[Description("How much karma is gained when a player does a good deed.")]
		public float KarmaGainedOnGoodDeed { get; set; } = 0.05f;

		[Description("How much karma is gained for escorting a detained member of the opposing team.")]
		public float KarmaGainedOnDisarmedEscape { get; set; } = 0.1f;

		[Description("The minimum amount of karma a player can have.")]
		public float KarmaMinimum { get; set; } = 0f;

		[Description("The amount of karma all players start with.")]
		public float KarmaInitial { get; set; } = 1f;

		[Description("The maximum amount of karma a player can have without karma overflow.")]
		public float KarmaMaximum { get; set; } = 1f;

		[Description("The maximum amount of karma a player can have with karma overflow.")]
		public float KarmaMaximumOverflow { get; set; } = 1.5f;

		[Description("The amount of karma a player must have to be able to play as SCP.")]
		public float KarmaLabeledBadActor { get; set; } = 0.5f;

		// --- TRANSLATIONS ---

		[Description("The text a player is shown for killing another player.")]
		public string PlayerKillMessage { get; set; } = "You have gained {xp} xp for killing {target}!";

		[Description("The text shown to a player who is killed.")]
		public string PlayerDeathMessage { get; set; } = "You were killed by {killer}, level {level}.";

		[Description("The text shown to a player when they teamkill.")]
		public string PlayerTeamkillMessage { get; set; } = "You have lost {xp} xp for teamkilling {target}.";

		[Description("The text shown to Tutorials after an SCP gets a kill.")]
		public string TutorialScpKillsPlayerMessage { get; set; } = "You have gained {xp} xp for an SCP killing an enemy!";

		[Description("The text shown to SCP-079 after another SCP gets a kill.")]
		public string Scp079AssistedKillMessage { get; set; } = "You have gained {xp} xp for another SCP killing an enemy!";

		[Description("The text shown to SCP-106 after a player dies in the pocket dimension.")]
		public string Scp106PocketDimensionDeathMessage { get; set; } = "You have gained {xp} for killing {target} in the pocket dimension!";

		[Description("The text shown to SCP-049 after they create a zombie.")]
		public string Scp049CreateZombieMessage { get; set; } = "You have gained {xp} xp for turning {target} into a zombie!";

		[Description("The text shown to a Class-D for escaping.")]
		public string DclassEscapeMessage { get; set; } = "You have gained {xp} xp for escaping as a Class-D!";

		[Description("The text shown to Chaos for a Class-D escaping.")]
		public string ChaosDclassEscapeMessage { get; set; } = "You have gained {xp} xp for {target} escaping as a Class-D!";

		[Description("The text shown to a Scientist for escaping.")]
		public string ScientistEscapeMessage { get; set; } = "You have gained {xp} xp for escaping as a Scientist!";

		[Description("The text shown to MTF for a Scientist escaping.")]
		public string MtfScientistEscapeMessage { get; set; } = "You have gained {xp} xp for {target} escaping as a Scientist!";

		// --- XP VALUES ---
		// All
		public int RoundWin { get; set; } = 500;
		public int TeamKillPunishment { get; set; } = 200;

		public List<KillXP> XPOnKill = new List<KillXP>()
		{
			// SCPs
			new KillXP { AttackerRole = RoleType.Scp049 },
			new KillXP { AttackerRole = RoleType.Scp0492},
			new KillXP { AttackerRole = RoleType.Scp096 },
			new KillXP { AttackerRole = RoleType.Scp106 },
			new KillXP { AttackerRole = RoleType.Scp93953 },
			new KillXP { AttackerRole = RoleType.Scp93989 },
			
			// Class-D
			new KillXP { AttackerRole = RoleType.ClassD, TargetRole = RoleType.Scientist, XPRewarded = 50 },
			new KillXP { AttackerRole = RoleType.ClassD, TargetRole = RoleType.NtfPrivate, XPRewarded = 75 },
			new KillXP { AttackerRole = RoleType.ClassD, TargetRole = RoleType.NtfSergeant, XPRewarded = 100 },
			new KillXP { AttackerRole = RoleType.ClassD, TargetRole = RoleType.NtfSpecialist, XPRewarded = 125 },
			new KillXP { AttackerRole = RoleType.ClassD, TargetRole = RoleType.NtfCaptain, XPRewarded = 150 },
			new KillXP { AttackerRole = RoleType.ClassD, TargetRole = RoleType.Scp0492, XPRewarded = 150 },
			new KillXP { AttackerRole = RoleType.ClassD, TargetTeam = Team.SCP, XPRewarded = 250 },
			new KillXP { AttackerRole = RoleType.ClassD, TargetRole = RoleType.Tutorial, XPRewarded = 100 },
			
			// Scientist
			new KillXP { AttackerRole = RoleType.Scientist, TargetRole = RoleType.ClassD, XPRewarded = 50 },
			new KillXP { AttackerRole = RoleType.Scientist, TargetTeam = Team.CHI, XPRewarded = 100 },
		};

		// SCPs
		public int Scp049Kill { get; set; } = 25;
		public int Scp0492Kill { get; set; } = 25;
		public int Scp096Kill { get; set; } = 25;
		public int Scp106Kill { get; set; } = 25;
		public int Scp173Kill { get; set; } = 25;
		public int Scp939Kill { get; set; } = 25;

		// Class-D
		public int DclassScientistKill { get; set; } = 50;
		public int DclassMtfKill { get; set; } = 100;
		public int DclassScpKill { get; set; } = 200;
		public int DclassTutorialKill { get; set; } = 100;
		public int DclassEscape { get; set; } = 250;

		// Scientist
		public int ScientistDclassKill { get; set; } = 50;
		public int ScientistChaosKill { get; set; } = 100;
		public int ScientistScpKill { get; set; } = 200;
		public int ScientistTutorialKill { get; set; } = 100;
		public int ScientistEscape { get; set; } = 250;

		// MTF
		public int MtfDclassKill { get; set; } = 25;
		public int MtfChaosKill { get; set; } = 50;
		public int MtfScpKill { get; set; } = 100;
		public int MtfTutorialKill { get; set; } = 50;
		public int MtfScientistEscape { get; set; } = 25;

		// Chaos
		public int ChaosScientistKill { get; set; } = 25;
		public int ChaosMtfKill { get; set; } = 50;
		public int ChaosScpKill { get; set; } = 100;
		public int ChaosTutorialKill { get; set; } = 50;
		public int ChaosDclassEscape { get; set; } = 25;

		// Tutorial
		public int TutorialDclassKill { get; set; } = 25;
		public int TutorialScientistKill { get; set; } = 25;
		public int TutorialMtfKill { get; set; } = 50;
		public int TutorialChaosKill { get; set; } = 50;
		public int TutorialScpKillsPlayer { get; set; } = 10;

		// SCP-106
		public int Scp106PocketDeath { get; set; } = 50;

		// SCP-049
		public int Scp049ZombieCreated { get; set; } = 25;

		// SCP-079
		public int Scp079AssistedKill { get; set; } = 10;
	}

	public class KillXP
	{
		public RoleType AttackerRole { get; set; }
		public Team AttackerTeam { get; set; }

		public RoleType TargetRole { get; set; } = RoleType.None;
		public Team TargetTeam { get; set; } = Team.RIP;
		public int XPRewarded { get; set; } = 25;

		public static KillXP GetKillXP(Player attacker, Player target)
		{
			var result = PlayerXP.instance.Config.XPOnKill.FirstOrDefault(x => (x.AttackerRole == RoleType.None ? attacker.Team == x.AttackerTeam : attacker.Role == x.AttackerRole) && (x.TargetRole == RoleType.None ? (x.TargetTeam == Team.RIP)));
			if (result == null)
		}
	}

	public class SelfEscapeXP
	{
		public RoleType Role { get; set; }
		public int XPRewarded { get; set; }
	}

	public class TeamEscapeXP
	{
		public RoleType RoleEscaped { get; set; }
		public Team TeamToGiveXP { get; set; }
		public int XPRewarded { get; set; }
	}
}
