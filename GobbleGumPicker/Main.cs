using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GobbleGumPicker.Properties;

namespace GobbleGumPicker
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
			Init();
		}

		public class Gobblegum
		{
			public enum Color
			{
				Blue, // round-based
				Orange, // activates immediately
				Green, // time-based
				Purple // activated
			}

			public enum Rarity
			{
				Classic,
				Whimsical,
				Mega,
				RareMega,
				UltraRareMega
			}

			public string name;
			public string description;
			public Image image;
			public Color color;
			public Rarity rarity;

			public Gobblegum(string gobblegumName, Image gobblegumImage, Color gobblegumColor, Rarity gobblegumRarity, string gobblegumDescription)
			{
				name = gobblegumName;
				image = gobblegumImage;
				color = gobblegumColor;
				rarity = gobblegumRarity;
				description = gobblegumDescription;
			}
		}

		public static readonly List<Gobblegum> GobblegumDatabase = new List<Gobblegum>()
		{
			new Gobblegum("Always Done Swiftly", Resources.AlwaysDoneSwiftly, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 full rounds)\nWalk faster while aiming. Raise and lower your weapon to aim more quickly."),
			new Gobblegum("Arms Grace", Resources.ArmsGrace, Gobblegum.Color.Orange, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts until next respawn)\nRespawn with the guns you had when you bled out."),
			new Gobblegum("Coagulant", Resources.Coagulant, Gobblegum.Color.Green, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 20 minutes)\nLonger bleedout time."),
			new Gobblegum("In Plain Sight", Resources.InPlainSight, Gobblegum.Color.Purple, Gobblegum.Rarity.Classic, "Activated (2x Activations, 10 seconds each)\nYou are ignored by zombies for 10 seconds."),
			new Gobblegum("Stock Option", Resources.StockOption, Gobblegum.Color.Green, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 minutes)\nAmmo is taken from your stockpile instead of your weapon's magazine."),

			new Gobblegum("Impatient", Resources.Impatient, Gobblegum.Color.Orange, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts until bleedout)\nRespawn near the end of the current round instead of at the start of the next round."),
			new Gobblegum("Sword Flay", Resources.SwordFlay, Gobblegum.Color.Green, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 2.5 minutes)\nMelee attacks deal zombies 5x as much damage."),
			new Gobblegum("Anywhere But Here!", Resources.AnywhereButHere, Gobblegum.Color.Purple, Gobblegum.Rarity.Classic, "Activated (2x Activations)\nInstantly teleport to a random location. A concussive blast knocks away any nearby zombies, keeping you safe."),
			new Gobblegum("Danger Closest", Resources.DangerClosest, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 full rounds)\nZero explosive damage."),
			new Gobblegum("Armamental Accomplishment", Resources.ArmamentalAccomplishment, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 full rounds)\nSwitch weapons and recover from performing melee attacks faster. Reload and use items more quickly."),
			new Gobblegum("Firing On All Cylinders", Resources.FiringOnAllCylinders, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 3 full rounds)\nCan fire while sprinting."),
			new Gobblegum("Arsenal Accelerator", Resources.ArmamentalAccomplishment, Gobblegum.Color.Green, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 10 minutes)\nCharge your special weapon faster."),
			new Gobblegum("Lucky Crit", Resources.LuckyCrit, Gobblegum.Color.Blue, Gobblegum.Rarity.Classic, "Activates Immediately (Lasts 1 full round)\nImproves your chances of activating an Alternate Ammo Type."),
			new Gobblegum("Now You See Me", Resources.NowYouSeeMe, Gobblegum.Color.Purple, Gobblegum.Rarity.Classic, "Activated (2x Activations)\nAll zombies will chase you for 10 seconds."),
			new Gobblegum("Alchemical Antithesis", Resources.AlchemicalAntithesis, Gobblegum.Color.Purple, Gobblegum.Rarity.Classic, "Activated (2x Activations, 60 seconds each)\nEvery 10 points earned is instead awarded 1 ammo in the stock of the current weapon."),

			new Gobblegum("Eye Candy", Resources.EyeCandy, Gobblegum.Color.Purple, Gobblegum.Rarity.Whimsical, "Activated (4x Activations)\nOverrides the colors you see."),
			new Gobblegum("Tone Death", Resources.ToneDeath, Gobblegum.Color.Orange, Gobblegum.Rarity.Whimsical, "Auto-activates when killing a zombie (25x Activations)\nSilly sounds play when zombies are killed."),
			new Gobblegum("Projectile Vomiting", Resources.ProjectileVomiting, Gobblegum.Color.Blue, Gobblegum.Rarity.Whimsical, "Activates Immediately (Lasts 5 full rounds)\nZombies you kill with grenades and large projectiles vomit uncontrollably."),
			new Gobblegum("Newtonian Negation", Resources.NewtonianNegation, Gobblegum.Color.Green, Gobblegum.Rarity.Whimsical, "Activates Immediately (Lasts 25 minutes)\nZombies you kill fall straight up."),

			new Gobblegum("Aftertaste", Resources.Aftertaste, Gobblegum.Color.Blue, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts 3 full rounds)\nKeep all perks after being revived."),
			new Gobblegum("Board Games", Resources.BoardGames, Gobblegum.Color.Blue, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts 5 full rounds)\nRepairing a board immediately repairs all boards at that window."),
			new Gobblegum("Board To Death", Resources.BoardToDeath, Gobblegum.Color.Green, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts for 5 minutes)\nRepairing a board will kill all nearby zombies."),
			new Gobblegum("Burned Out", Resources.BurnedOut, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts two hits)\nThe next time you take melee damage, nearby zombies burst into fire."),
			new Gobblegum("Crawl Space", Resources.CrawlSpace, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (5x Activations)\nAll nearby zombies become crawlers."),
			new Gobblegum("Dead of Nuclear Winter", Resources.DeadOfNuclearWinter, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nSpawns a nuke power up."),
			new Gobblegum("Disorderly Combat", Resources.DisorderlyCombat, Gobblegum.Color.Green, Gobblegum.Rarity.Mega, "Activates Immediately (Lasts for 5 minutes)\nGives a random gun every 10 seconds."),
			new Gobblegum("Ephemeral Enhancement", Resources.EphemeralEnhancement, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations, 60 seconds each)\nTurns the weapon in your hands into Pack-a-Punched weapon."),
			new Gobblegum("Fatal Contraption", Resources.FatalContraption, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nSpawn a Death Machine power up."),
			new Gobblegum("Flavor Hexed", Resources.FlavorHexed, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Activates Immediately (2x Activations)\nTransforms into a random Mega GobbleGum not in your Pack."),
			new Gobblegum("Idle Eyes", Resources.IdleEyes, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (3x Activations, 30 seconds each)\nAll zombies will ignore all players."),
			new Gobblegum("I'm Feeling Lucky", Resources.ImFeelingLucky, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nSpawn a random power up."),
			new Gobblegum("Immolation Liquidation", Resources.ImmolationLiquidation, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (3x Activations)\nSpawn a fire sale power up."),
			new Gobblegum("Licensed Contractor", Resources.LicensedContractor, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (3x Activations)\nSpawn a Carpenter power up."),
			new Gobblegum("Mind Blown", Resources.MindBlown, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (3x Activations)\nGib the heads of all zombies you can see, killing them."),
			new Gobblegum("Phoenix Up", Resources.PhoenixUp, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (1x Activation)\nRevives all teammates. Teammates keep all of their perks."),
			new Gobblegum("Pop Shocks", Resources.PopShocks, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Auto-activates when melee attacking zombies (5x Activations)\nMelee attacks trigger an electrostatic discharge, electrocuting nearby zombies."),
			new Gobblegum("Respin Cycle", Resources.RespinCycle, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nRe-spins the weapons in a magic box after it has been activated."),
			new Gobblegum("Slaughter Slide", Resources.SlaughterSlide, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Auto-activates when sliding (6x Activations)\nCreate 2 lethal explosions by sliding."),
			new Gobblegum("Unbearable", Resources.Unbearable, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Auto-activates when a teddy bear appears in the magic box.\nMagic box re-spins automatically. Magic box will not move for several uses."),
			new Gobblegum("Unquenchable", Resources.Unquenchable, Gobblegum.Color.Orange, Gobblegum.Rarity.Mega, "Auto-activates when you have maximum perks.\nCan buy an extra perk."),
			new Gobblegum("Who's Keeping Score?", Resources.WhosKeepingScore, Gobblegum.Color.Purple, Gobblegum.Rarity.Mega, "Activated (2x Activations)\nSpawns a double points power up."),

			new Gobblegum("Bullet Boost", Resources.BulletBoost, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (2x Activations)\nRe-Pack your current Pack-a-Punched gun (if supported)."),
			new Gobblegum("Cache Back", Resources.CacheBack, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (1x Activation)\nSpawns a max ammo power up."),
			new Gobblegum("Crate Power", Resources.CratePower, Gobblegum.Color.Orange, Gobblegum.Rarity.RareMega, "Auto-activates next time you take a gun from the magic box\nThe next gun taken from the magic box comes Pack-a-Punched."),
			new Gobblegum("Extra Credit", Resources.ExtraCredit, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (4x Activations)\nSpawns a personal 1250 point power up."),
			new Gobblegum("Fear in Headlights", Resources.FearInHeadlights, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (1x Activation, 2 minutes)\nZombies seen by players will not move."),
			new Gobblegum("Kill Joy", Resources.KillJoy, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (2x Activations)\nSpawns an Instakill power up."),
			new Gobblegum("On the House", Resources.OnTheHouse, Gobblegum.Color.Purple, Gobblegum.Rarity.RareMega, "Activated (1x Activation)\nSpawns a free perk power up."),
			new Gobblegum("Soda Fountain", Resources.SodaFountain, Gobblegum.Color.Orange, Gobblegum.Rarity.RareMega, "Auto-activates when you buy a perk (5x Activations)\nCan buy an extra perk. Gives you a free perk after you buy one."),
			new Gobblegum("Temporal Gift", Resources.TemporalGift, Gobblegum.Color.Blue, Gobblegum.Rarity.RareMega, "Activates Immediately (Lasts 1 full round)\nPower ups last longer."),
			new Gobblegum("Undead Man Walking", Resources.UndeadManWalking, Gobblegum.Color.Green, Gobblegum.Rarity.RareMega, "Activates Immediately (Lasts 4 minutes)\nSlow down all zombies to shambling speed."),
			new Gobblegum("Wall Power", Resources.WallPower, Gobblegum.Color.Orange, Gobblegum.Rarity.RareMega, "Auto-activates on your next wall-buy gun purchase\nThe next gun bought off a wall comes Pack-a-Punched."),

			new Gobblegum("Head Drama", Resources.HeadDrama, Gobblegum.Color.Blue, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts for the remainder of the round)\nAny bullet which hits a zombie will damage its head."),
			new Gobblegum("Killing Time", Resources.KillingTime, Gobblegum.Color.Purple, Gobblegum.Rarity.UltraRareMega, "Activated (1x Activation)\nAll zombies freeze in place for 20 seconds. If they are shot, they will be annihilated when the time is up."),
			new Gobblegum("Near Death Experience", Resources.NearDeathExperience, Gobblegum.Color.Blue, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts 3 full rounds)\nRevive, or be revived, simply by being near other players. Revived players keep all of their perks."),
			new Gobblegum("Perkaholic", Resources.Perkaholic, Gobblegum.Color.Orange, Gobblegum.Rarity.UltraRareMega, "Activated Immediately\nGives you all perks in the map."),
			new Gobblegum("Power Vacuum", Resources.PowerVacuum, Gobblegum.Color.Blue, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts for 4 full rounds)\nMore power ups can drop each round."),
			new Gobblegum("Profit Sharing", Resources.ProfitSharing, Gobblegum.Color.Green, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts 10 minutes)\nPoints you earn are also received by nearby players, and vice versa."),
			new Gobblegum("Reign Drops", Resources.ReignDrops, Gobblegum.Color.Purple, Gobblegum.Rarity.UltraRareMega, "Activated (2x Activations)\nSpawns one of each of the nine core power ups."),
			new Gobblegum("Round Robbin'", Resources.RoundRobbin, Gobblegum.Color.Purple, Gobblegum.Rarity.UltraRareMega, "Activated (1x Activation)\nEnds the current round. All players gain 1600 points."),
			new Gobblegum("Secret Shopper", Resources.SecretShopper, Gobblegum.Color.Green, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts 10 minutes)\nAny gun wall-buy can be used to buy ammo for any gun."),
			new Gobblegum("Self Medication", Resources.SelfMedication, Gobblegum.Color.Orange, Gobblegum.Rarity.UltraRareMega, "Auto-activates by getting a kill in last stand (3x Activations)\nAuto revive yourself. Keep all of your perks."),
			new Gobblegum("Shopping Free", Resources.ShoppingFree, Gobblegum.Color.Green, Gobblegum.Rarity.UltraRareMega, "Activates Immediately (Lasts 1 minute)\nAll purchases are free.")
		};

		private List<Gobblegum> CurrentSet = new List<Gobblegum>();

		private bool EnableLeveled = true;
		private bool EnableWhimsical = true;

		private void Init()
		{
			RefreshTooltips();

			VersionLabel.Text = ProductVersion;
		}

		private void GobblegumMachineClick(object sender, EventArgs e)
		{
			TutorialLabel.Visible = false;

			GenerateGobblegumSet();
			RefreshGobblegumsDisplay();
			RefreshTooltips();
		}

		private void LeveledCheckedChanged(object sender, EventArgs e)
		{
			EnableLeveled = LeveledCheckBox.Checked;
			RefreshTooltips();
		}

		private void WhimsicalCheckedChanged(object sender, EventArgs e)
		{
			EnableWhimsical = WhimsicalCheckBox.Checked;
			RefreshTooltips();
		}

		private void RefreshTooltips()
		{
			ToolTip.SetToolTip(LeveledCheckBox, (EnableLeveled ? "Disable" : "Enable") + " rolling of level-awarded GobbleGums (Impatient, Sword Flay, etc.)");
			ToolTip.SetToolTip(WhimsicalCheckBox, (EnableWhimsical ? "Disable" : "Enable") + " rolling of Whimsical GobbleGums (Eye Candy, Tone Death, etc.)");

			if (CurrentSet.Count < 5) return;

			ToolTip.SetToolTip(GobbleGum1Image, CurrentSet[0].description);
			ToolTip.SetToolTip(GobbleGum2Image, CurrentSet[1].description);
			ToolTip.SetToolTip(GobbleGum3Image, CurrentSet[2].description);
			ToolTip.SetToolTip(GobbleGum4Image, CurrentSet[3].description);
			ToolTip.SetToolTip(GobbleGum5Image, CurrentSet[4].description);
		}

		private void RefreshGobblegumsDisplay()
		{
			if (CurrentSet.Count < 5) return;

			GobbleGum1Label.Text = CurrentSet[0].name;
			GobbleGum1Image.Image = CurrentSet[0].image;

			GobbleGum2Label.Text = CurrentSet[1].name;
			GobbleGum2Image.Image = CurrentSet[1].image;

			GobbleGum3Label.Text = CurrentSet[2].name;
			GobbleGum3Image.Image = CurrentSet[2].image;

			GobbleGum4Label.Text = CurrentSet[3].name;
			GobbleGum4Image.Image = CurrentSet[3].image;

			GobbleGum5Label.Text = CurrentSet[4].name;
			GobbleGum5Image.Image = CurrentSet[4].image;
		}

		private void GenerateGobblegumSet()
		{
			CurrentSet = new List<Gobblegum>
			{
				GenerateGobblegum(),
				GenerateGobblegum(),
				GenerateGobblegum(),
				GenerateGobblegum(),
				GenerateGobblegum()
			};
		}

		private Gobblegum GenerateGobblegum()
		{
			List<Gobblegum> Gobblegums = new List<Gobblegum>(GobblegumDatabase);

			if (!EnableWhimsical)
			{
				Gobblegums.RemoveAll(gobblegum => gobblegum.rarity == Gobblegum.Rarity.Whimsical);
			}

			if (!EnableLeveled)
			{
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Impatient"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Sword Flay"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Anywhere But Here!"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Danger Closest"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Armamental Accomplishment"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Firing On All Cylinders"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Arsenal Accelerator"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Lucky Crit"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Now You See Me"));
				Gobblegums.Remove(Gobblegums.Find(gobblegum => gobblegum.name == "Alchemical Antithesis"));
			}

			Gobblegum GeneratedGobblegum = Gobblegums[RandomProvider.GetThreadRandom().Next(0, Gobblegums.Count)];

			while (CurrentSet.Contains(GeneratedGobblegum) && Gobblegums.Count >= 5)
			{
				GeneratedGobblegum = Gobblegums[RandomProvider.GetThreadRandom().Next(0, Gobblegums.Count)];
			}

			return GeneratedGobblegum;
		}
	}
}
